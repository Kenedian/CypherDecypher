using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CypherAndDecypher.Models
{
    public class CypherDecypher
    {
        public string cypherFrom { get; set; }
        public string cypherTo { get; set; }
        public string cypherSubmit { get; set; }
        public string cypherDropFrom { get; set; }
        public string cypherDropTo { get; set; }

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

        public void InvokeMethod(string methodName, List<object> args)
        {
            GetType().GetMethod(methodName).Invoke(this, args.ToArray());
        }
        public void NormalToMorse(string text)
        {
            
            string cypher = "";
            string cU = "";
            foreach (char c in text)
            {
                cU = c.ToString().ToUpper();
                if (AlphabetToMorse.ContainsKey(cU[0]) || (cU[0] == ' '))
                {
                    if (c == ' ')
                    {
                        cypher += "| ";
                    }
                    else
                    {
                        cypher += AlphabetToMorse[cU[0]];
                        cypher += " ";
                    }
                }
            }

            this.cypherTo = cypher;
        }
        public void NormalToCaesar(string text)
        {
            string cypher = "";
            int ascii = 0;
            text = text.ToUpper();
            //ascii 65-90 (A-Z)
            foreach (char c in text)
            {
                ascii = (int)c;
                if(ascii >=65 && ascii <= 90)
                {
                    ascii -= 3;
                    if(ascii < 65)
                    {
                        ascii = 91 - (65-ascii);
                    }
                }
                cypher += (char)ascii;
            }

            cypherTo = cypher;
        }

        public void MorseToNormal(string text)
        {


            string decypher = "";
            string[] splitText = text.Split(' ', StringSplitOptions.TrimEntries);


            foreach (string s in splitText)
            {

                    if (s == "")
                    {
                        //Do nothing.
                    }
                    else if (s.Contains("|"))
                    {
                        if (s == "|")
                        {
                            decypher += " ";
                        }
                        else if (s[0] == '|')
                        {
                            string tempS = s.Remove(0, 1);
                            if (MorseToAlphabet.ContainsKey(tempS))
                            {
                                decypher += " ";
                                decypher += MorseToAlphabet[tempS];
                            }
                        }
                        else if (s[s.Length - 1] == '|')
                        {
                            string tempS = s.Remove(s.Length - 1, 1);
                            if (MorseToAlphabet.ContainsKey(tempS))
                            {
                                decypher += MorseToAlphabet[tempS];
                                decypher += " ";
                            }
                        }
                        else
                        {
                            string[] tempS = s.Split('|', StringSplitOptions.RemoveEmptyEntries);
                            if (MorseToAlphabet.ContainsKey(tempS[0]))
                            {
                                decypher += MorseToAlphabet[tempS[0]];
                            }
                            decypher += " ";
                            if (MorseToAlphabet.ContainsKey(tempS[1]))
                            {
                                decypher += MorseToAlphabet[tempS[1]];
                            }

                        }
                    }
                    else
                    {
                        if (MorseToAlphabet.ContainsKey(s))
                        {
                            decypher += MorseToAlphabet[s];
                        }
                    }
                
            }

            cypherTo = decypher;
        }
        public void CaesarToNormal(string text)
        {
            string cypher = "";
            int ascii = 0;
            text = text.ToUpper();
            //ascii 65-90 (A-Z)
            foreach (char c in text)
            {
                ascii = (int)c;
                if (ascii >= 65 && ascii <= 90)
                {
                    ascii += 3;
                    if (ascii > 90)
                    {
                        ascii = 64 + (ascii % 90);
                    }
                }
                cypher += (char)ascii;
            }

            cypherTo = cypher;
        }
    }
}