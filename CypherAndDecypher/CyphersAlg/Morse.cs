using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CypherAndDecypher.Interfaces;

namespace CypherAndDecypher.CyphersAlg
{
    public class Morse : ICyphers
    {

        private Dictionary<string, char> MorseToAlphabet = new Dictionary<string, char>
            {
                {".-",'A'},
                {"-...",'B'},
                {"-.-.",'C'},
                {"-..",'D'},
                {".",'E'},
                {"..-.",'F'},
                {"--.",'G'},
                {"....",'H'},
                {"..",'I'},
                {".---",'J'},
                {"-.-",'K'},
                {".-..",'L'},
                {"--",'M'},
                {"-.",'N'},
                {"---",'O'},
                {".--.",'P'},
                {"--.-",'Q'},
                {".-.",'R'},
                {"...",'S'},
                {"-",'T'},
                {"..-",'U'},
                {"...-",'V'},
                {".--",'W'},
                {"-..-",'X'},
                {"-.--",'Y'},
                {"--..",'Z'},
            };

        private Dictionary<char, string> AlphabetToMorse = new Dictionary<char, string>
            {
                {'A',".-"},
                {'B',"-..."},
                {'C',"-.-."},
                {'D',"-.."},
                {'E',"."},
                {'F',"..-."},
                {'G',"--."},
                {'H',"...."},
                {'I',".."},
                {'J',".---"},
                {'K',"-.-"},
                {'L',".-.."},
                {'M',"--"},
                {'N',"-."},
                {'O',"---"},
                {'P',".--."},
                {'Q',"--.-"},
                {'R',".-."},
                {'S',"..."},
                {'T',"-"},
                {'U',"..-"},
                {'V',"...-"},
                {'W',".--"},
                {'X',"-..-"},
                {'Y',"-.--"},
                {'Z',"--.."}
            };

        public string Cypher(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }

            string result = "";
            string cU = "";
            foreach (char c in text)
            {
                cU = c.ToString().ToUpper();
                if (AlphabetToMorse.ContainsKey(cU[0]) || (cU[0] == ' '))
                {
                    if (c == ' ')
                    {
                        result += "| ";
                    }
                    else
                    {
                        result += AlphabetToMorse[cU[0]];
                        result += " ";
                    }
                }
            }
            return result;
        }

        public string Decypher(string text)
        {
            if(text == null || text == "")
            {
                return "";
            }

            string result = "";
            string[] splitText = text.Split(' ', StringSplitOptions.TrimEntries);


            foreach (string s in splitText)
            {

                if (s == "")
                {
                    continue;
                }
                else if (s.Contains("|"))
                {
                    if (s == "|")
                    {
                        result += " ";
                    }
                    else if (s[0] == '|')
                    {
                        string tempS = s.Remove(0, 1);
                        if (MorseToAlphabet.ContainsKey(tempS))
                        {
                            result += " ";
                            result += MorseToAlphabet[tempS];
                        }
                    }
                    else if (s[s.Length - 1] == '|')
                    {
                        string tempS = s.Remove(s.Length - 1, 1);
                        if (MorseToAlphabet.ContainsKey(tempS))
                        {
                            result += MorseToAlphabet[tempS];
                            result += " ";
                        }
                    }
                    else
                    {
                        string[] tempS = s.Split('|', StringSplitOptions.RemoveEmptyEntries);
                        if (MorseToAlphabet.ContainsKey(tempS[0]))
                        {
                            result += MorseToAlphabet[tempS[0]];
                        }
                        result += " ";
                        if (MorseToAlphabet.ContainsKey(tempS[1]))
                        {
                            result += MorseToAlphabet[tempS[1]];
                        }

                    }
                }
                else
                {
                    if (MorseToAlphabet.ContainsKey(s))
                    {
                        result += MorseToAlphabet[s];
                    }
                }

            }
            return result;
        }
    }
}
