using System;
using System.Collections.Generic;
using System.Linq;

namespace BlightLang
{
    public class Interpreter
    {
        private readonly Dictionary<string, object> _variables = new();

        public void Execute(List<Token> tokens)
        {
            for (int i = 0; i < tokens.Count; i++)
            {
                Token token = tokens[i];

                // Skip EOF token
                if (token.Type == "EOF") continue;

                if (token.Type == "Keyword")
                {
                    if (token.Value == "let")
                    {
                        // Handle variable assignment
                        string varName = tokens[++i].Value;

                        if (tokens[++i].Value != "=")
                            throw new Exception("Expected '=' after variable name");

                        var valueToken = tokens[++i];
                        object value = ParseValue(valueToken.Value, valueToken.Type);

                        if (value == null)
                        {
                            throw new Exception($"Invalid value for variable {varName}: {valueToken.Value} is not a valid type.");
                        }

                        _variables[varName] = value;
                    }
                    else if (token.Value == "print")
                    {
                        string varName = tokens[++i].Value;
                        int runCount = 1;

                        // Handle {run N} part
                        if (tokens[i + 1]?.Value == "{run")
                        {
                            // Extract the number inside {run N}
                            string runToken = tokens[++i + 1].Value;

                            // Remove the closing brace (}) from the token if it exists
                            if (runToken.EndsWith("}"))
                            {
                                runToken = runToken.Substring(0, runToken.Length - 1);
                            }

                            // Try to parse the run count
                            if (int.TryParse(runToken, out runCount))
                            {
                                i += 2; // Skip over {run N} part
                            }
                            else
                            {
                                throw new Exception($"Invalid number format in {runToken}.");
                            }
                        }

                        if (_variables.ContainsKey(varName))
                        {
                            for (int j = 0; j < runCount; j++)
                            {
                                Console.WriteLine(_variables[varName]);
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Error: Variable '{varName}' is not defined.");
                        }
                    }
                }
            }
        }

        // Method to automatically detect and parse values into their appropriate types
        private object ParseValue(string value, string type)
        {
            if (type == "Number")
            {
                if (value.Contains("."))
                {
                    if (value.Contains("f") || value.Contains("F"))
                        return float.Parse(value); // float
                    else
                        return double.Parse(value); // double
                }
                else
                {
                    return int.Parse(value); // int
                }
            }
            else if (type == "String")
            {
                return value.Trim('"'); // Remove quotes around string literals
            }
            else
            {
                return null; // Handle unrecognized value types
            }
        }
    }
}
