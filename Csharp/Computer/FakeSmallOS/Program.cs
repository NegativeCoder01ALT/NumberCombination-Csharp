using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace breadOS
{
    public class Program
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static Dictionary<string, string> LoadConfig(string path)
        {
            var config = new Dictionary<string, string>();
            if (!File.Exists(path))
                return config;

            foreach (var line in File.ReadAllLines(path))
            {
                if (line.Contains('='))
                {
                    var parts = line.Split('=', 2);
                    config[parts[0].Trim()] = parts[1].Trim();
                }
            }
            return config;
        }

        public static void SaveConfig(string path, Dictionary<string, string> config)
        {
            using (var writer = new StreamWriter(path))
            {
                foreach (var kv in config)
                {
                    writer.WriteLine($"{kv.Key}={kv.Value}");
                }
            }
        }

        public static void Main()
        {
            string configPath = "/workspaces/MeIsNegative/Csharp/Computer/FakeSmallOS/data.conf";
            var config = LoadConfig(configPath);

            bool user_Exist = config.ContainsKey("user_Exist") && config["user_Exist"] == "true";
            bool user_Logged = false;
            string username = config.ContainsKey("username") ? config["username"] : "";
            string passwordHash = config.ContainsKey("password") ? config["password"] : "";

            while (true)
            {
                if (!user_Exist)
                {
                    Console.WriteLine("Create new user...");
                    Console.Write("Enter new username: ");
                    username = Console.ReadLine();

                    Console.Write("Enter your new password: ");
                    string newPassword = Console.ReadLine();
                    passwordHash = HashPassword(newPassword);

                    Console.WriteLine("New user created...");
                    user_Exist = true;

                    config["username"] = username;
                    config["password"] = passwordHash;
                    config["user_Exist"] = "true";
                    SaveConfig(configPath, config);
                }
                else
                {
                    if (!user_Logged)
                    {
                        Console.WriteLine("Login");
                        Console.Write("Enter your username: ");
                        string usernameLoginInput = Console.ReadLine();

                        Console.Write("Enter your password: ");
                        string passwordLoginInput = Console.ReadLine();
                        string hashedInput = HashPassword(passwordLoginInput);

                        if (usernameLoginInput == username && hashedInput == passwordHash)
                        {
                            Console.WriteLine("Logged in successfully...");
                            user_Logged = true;
                        }
                        else
                        {
                            Console.WriteLine("INCORRECT USERNAME OR PASSWORD!");
                        }
                    }
                    else
                    {
                        Console.Write("Type your command (Type --help for help): ");
                        string commandInput = Console.ReadLine();

                        switch (commandInput)
                        {
                            case "--help":
                                Console.WriteLine("Help: ");
                                Console.WriteLine(" ");
                                Console.WriteLine("User commands: ");
                                Console.WriteLine("user --del user[]: Deletes user");
                                Console.WriteLine("user --change password : changes password");
                                Console.WriteLine("user --change username : Changes username");
                                Console.WriteLine("user --logout : logs out the user");
                                Console.WriteLine("");
                                Console.WriteLine("System commands: ");
                                Console.WriteLine("sys --reboot : Reboots the OS");
                                Console.WriteLine("sys --reboot.wipe : Reboots and wipes everything");
                                break;

                            case "user --del user[]":
                                Console.Write("Enter your username: ");
                                string usernameDelInput = Console.ReadLine();

                                Console.Write("Enter your password: ");
                                string passwordDelInput = Console.ReadLine();
                                string hashedDelInput = HashPassword(passwordDelInput);

                                if (usernameDelInput == username && hashedDelInput == passwordHash)
                                {
                                    Console.Write($"Are you sure you want to delete the user \"{username}\"? N/y: ");
                                    string userDelConfirmInput = Console.ReadLine();

                                    if (userDelConfirmInput == "y")
                                    {
                                        Console.WriteLine("User deletion is a success");
                                        Console.WriteLine("Goodbye...");
                                        user_Exist = false;
                                        user_Logged = false;
                                        username = "";
                                        passwordHash = "";

                                        config["user_Exist"] = "false";
                                        config["username"] = "";
                                        config["password"] = "";
                                        SaveConfig(configPath, config);
                                    }
                                    else
                                    {
                                        Console.WriteLine("User deletion cancelled...");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("INCORRECT USERNAME OR PASSWORD!");
                                }
                                break;

                            case "user --change password":
                                Console.Write("Enter your username: ");
                                string usernameChangePassInput = Console.ReadLine();

                                Console.Write("Enter your password: ");
                                string passwordChangePassInput = Console.ReadLine();
                                string hashedChangePassInput = HashPassword(passwordChangePassInput);

                                if (usernameChangePassInput == username && hashedChangePassInput == passwordHash)
                                {
                                    Console.Write("Enter new password: ");
                                    string newPassword = Console.ReadLine();

                                    passwordHash = HashPassword(newPassword);
                                    config["password"] = passwordHash;
                                    SaveConfig(configPath, config);
                                }
                                else
                                {
                                    Console.WriteLine("INCORRECT USERNAME OR PASSWORD!");
                                }
                                break;

                            case "user --change username":
                                Console.Write("Enter your username: ");
                                string usernameChangeNameInput = Console.ReadLine();

                                Console.Write("Enter your password: ");
                                string passwordChangeNameInput = Console.ReadLine();
                                string hashedChangeNamePassInput = HashPassword(passwordChangeNameInput);

                                if (usernameChangeNameInput == username && hashedChangeNamePassInput == passwordHash)
                                {
                                    Console.Write("Enter new username: ");
                                    string newUsername = Console.ReadLine();

                                    username = newUsername;
                                    config["username"] = username;
                                    SaveConfig(configPath, config);
                                }
                                else
                                {
                                    Console.WriteLine("INCORRECT USERNAME OR PASSWORD!");
                                }
                                break;

                            case "user --logout":
                                Console.WriteLine("Goodbye...");
                                user_Logged = false;
                                break;

                            case "sys --reboot":
                                Console.WriteLine("Rebooting...");
                                user_Logged = false;
                                break;

                            case "sys --reboot.wipe":
                                Console.Write("Enter your username: ");
                                string usernameSysWipe = Console.ReadLine();

                                Console.Write("Enter your password: ");
                                string passwordSysWipe = Console.ReadLine();
                                string hashedSysWipePass = HashPassword(passwordSysWipe);

                                if (usernameSysWipe == username && hashedSysWipePass == passwordHash)
                                {
                                    Console.Write("Are you sure you want to wipe the system? N/y: ");
                                    string wipeConfirmation = Console.ReadLine();

                                    if (wipeConfirmation == "y")
                                    {
                                        Console.WriteLine("Wiping system...");
                                        user_Exist = false;
                                        user_Logged = false;
                                        username = "";
                                        passwordHash = "";

                                        config["user_Exist"] = "false";
                                        config["username"] = "";
                                        config["password"] = "";
                                        SaveConfig(configPath, config);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Wipe cancelled...");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("INCORRECT USERNAME OR PASSWORD!");
                                }
                                break;

                            default:
                                Console.WriteLine("Unknown command. Type --help for available commands.");
                                break;
                        }
                    }
                }
            }
        }
    }
}
