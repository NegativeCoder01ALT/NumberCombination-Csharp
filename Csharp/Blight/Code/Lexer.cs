using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BlightLang
{
    public class Lexer
    {
        private static readonly string[] _keywords = { "let", "print" };
        private static readonly Regex _identifierRegex = new(@"^[a-zA-Z_][a-zA-Z0-9_]*$");
        private static readonly Regex _numberRegex = new(@"^\d+(\.\d+)?$");  // Match integers and floats/doubles
        private static readonly Regex _stringRegex = new(@"^\"".*\""$"); // Match string literals (e.g., "hello")

        public Lexer() { }

        public List<Token> Tokenize(string code)
        {
            var tokens = new List<Token>();
            var lines = code.Split('\n');

            foreach (var line in lines)
            {
                var words = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                {
                    if (Array.Exists(_keywords, keyword => keyword == word))
                    {
                        tokens.Add(new Token("Keyword", word));
                    }
                    else if (_identifierRegex.IsMatch(word))
                    {
                        tokens.Add(new Token("Identifier", word));
                    }
                    else if (_numberRegex.IsMatch(word))
                    {
                        tokens.Add(new Token("Number", word));
                    }
                    else if (_stringRegex.IsMatch(word))
                    {
                        tokens.Add(new Token("String", word));
                    }
                    else
                    {
                        tokens.Add(new Token("Symbol", word));
                    }
                }
            }

            tokens.Add(new Token("EOF", ""));
            return tokens;
        }
    }
}
