using System;
using System.IO;
using System.Collections.Generic;

namespace BlightLang
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "path to file";
            
            string code = File.ReadAllText(filePath);

            Lexer lexer = new Lexer();

            List<Token> tokens = lexer.Tokenize(code);

            Interpreter interpreter = new Interpreter();

            interpreter.Execute(tokens);
        }
    }
}
