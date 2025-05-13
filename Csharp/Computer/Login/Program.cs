using System;

namespace login
{
    public class Program
    {
        public static void Main()
        {
            bool userLogged = false;
            bool userExist = false;
            string username = "";
            string password = "";

            while (true)
            {
                if (!userExist)
                {
                    Console.WriteLine("Create user...");
                    Console.Write("Enter your new username: ");
                    username = Console.ReadLine();
                    Console.Write("Enter your new password: ");
                    password = Console.ReadLine();
                    userExist = true;
                }
                else
                {
                    if (!userLogged)
                    {
                        Console.WriteLine("Login...");
                        Console.Write("Enter your username: ");
                        string usernameInput = Console.ReadLine();
                        Console.Write("Enter your password: ");
                        string passwordInput = Console.ReadLine();

                        if (usernameInput == username && passwordInput == password)
                        {
                            Console.WriteLine("Login successful!");
                            userLogged = true;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect Username or Password!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nCommands:");
                        Console.WriteLine("change-password : changes the password");
                        Console.WriteLine("change-username : changes the username");
                        Console.WriteLine("logout : logs out the user");
                        Console.Write("Enter a command: ");
                        string command = Console.ReadLine();

                        if (command == "change-password")
                        {
                            Console.Write("Enter current password: ");
                            string passwordChangeInput = Console.ReadLine();

                            if (passwordChangeInput == password)
                            {
                                Console.Write("Enter new password: ");
                                password = Console.ReadLine();
                                Console.WriteLine("Password changed successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Incorrect password!");
                            }
                        }
                        else if (command == "change-username")
                        {
                            Console.Write("Enter current password: ");
                            string usernameChangeInput = Console.ReadLine();

                            if (usernameChangeInput == password)
                            {
                                Console.Write("Enter new username: ");
                                username = Console.ReadLine();
                                Console.WriteLine("Username changed successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Incorrect password!");
                            }
                        }
                        else if (command == "logout")
                        {
                            Console.Write("Are you sure you want to log out? (y/N): ");
                            string logoutInput = Console.ReadLine();

                            if (logoutInput.ToLower() == "y")
                            {
                                userLogged = false;
                                Console.WriteLine("Logged out successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Logout canceled.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Unknown command.");
                        }
                    }
                }

                Console.WriteLine(); 
            }
        }
    }
}

