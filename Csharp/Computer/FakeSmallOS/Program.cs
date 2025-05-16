using System;

namespace breadOS
{
    public class Program
    {
        public static void Main()
        {
            bool user_Exist = false;
            bool user_Logged = false;
            string password = "";
            string username = "";

            while (true)
            {
                if (user_Exist == false)
                {
                    Console.WriteLine("Create new user...");
                    Console.Write("Enter new username: ");
                    username = Console.ReadLine();
                    Console.Write("Enter your new password: ");
                    password = Console.ReadLine();
                    Console.WriteLine("New user created...");
                    user_Exist = true;
                }
                else
                {
                    if (user_Logged == false)
                    {
                        Console.WriteLine("Login");
                        Console.Write("Enter your username: ");
                        string usernameLoginInput = Console.ReadLine();
                        Console.Write("Enter your password: ");
                        string passwordLoginInput = Console.ReadLine();

                        if (usernameLoginInput == username && passwordLoginInput == password)
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
                                Console.WriteLine("Enter your password: ");
                                string passwordDelInput = Console.ReadLine();

                                if (usernameDelInput == username && passwordDelInput == password)
                                {
                                    Console.Write($"Are your sure your want to delete the user \"{username}\"? N/y: ");
                                    string userDelConfirmInput = Console.ReadLine();

                                    if (userDelConfirmInput == "y")
                                    {
                                        Console.WriteLine("User deletion is a success");
                                        Console.WriteLine("goddbye...");
                                        user_Exist = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("User deletion cancled...");
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
                                Console.WriteLine("Enter your password: ");
                                string passwordChangePassInput = Console.ReadLine();

                                if (usernameChangePassInput == username && passwordChangePassInput == password)
                                {
                                    Console.Write("Enter new password: ");
                                    string newPassword = Console.ReadLine();

                                    password = newPassword;
                                }
                                else
                                {
                                    Console.WriteLine("INCORRECT USERNAME OR PASSWORD!");
                                }
                                break;
                            case "user --change username":
                                Console.Write("Enter your username: ");
                                string usernameChangeNameInput = Console.ReadLine();
                                Console.WriteLine("Enter your password: ");
                                string passwordChangeNameInput = Console.ReadLine();

                                if (usernameChangeNameInput == username && passwordChangeNameInput == password)
                                {
                                    Console.Write("Enter new username: ");
                                    string newUsername = Console.ReadLine();

                                    username = newUsername;
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
                                Console.WriteLine("Goodbye...");
                                user_Logged = false;
                                break;
                            case "sys --reboot.wipe":
                                Console.Write("Enter your username: ");
                                string usernameSysWipe = Console.ReadLine();
                                Console.WriteLine("Enter your password: ");
                                string passwordSysWipe = Console.ReadLine();

                                if (usernameSysWipe == username && passwordSysWipe == password)
                                {
                                    Console.Write("Are you sure you want to wipe the system? N/y: ");
                                    string wipeConfirmation = Console.ReadLine();

                                    if (wipeConfirmation == "y")
                                    {
                                        Console.WriteLine("Goodbye...");
                                        user_Exist = false;
                                        user_Logged = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Wipe cancled...");
                                    }
                                }
                                break;


                        }
                    }

                }
            }
        }
    }
}