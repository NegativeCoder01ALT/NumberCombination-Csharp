using System;

while (true)
{
    Console.Write(">>> ");
    string input = Console.ReadLine();

    switch (input)
    {
        case "app --install git.numbercombo.bap":
            // [INSERT INSTALL CODE FROM EARLIER HERE]
            break;

        case "exit":
            Console.WriteLine("Exiting and launching FakeSmallOS...");

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = "run",
                WorkingDirectory = "/workspaces/MeIsNegative/Csharp/Computer/FakeSmallOS",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            try
            {
                using Process proc = Process.Start(startInfo);
                proc.WaitForExit();

                string output = proc.StandardOutput.ReadToEnd();
                string error = proc.StandardError.ReadToEnd();

                Console.WriteLine("Output:\n" + output);
                if (!string.IsNullOrEmpty(error))
                    Console.WriteLine("Errors:\n" + error);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to launch FakeSmallOS: " + ex.Message);
            }

            return; // Exit the current program after running the other one

        default:
            Console.WriteLine("Unknown command. Try again or type 'exit' to launch FakeSmallOS.");
            break;
    }
}
