using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CypherAndDecypher.Interfaces;

namespace CypherAndDecypher.CyphersAlg
{
    public class Caesar : ICyphers
    {

        public string Cypher(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }

            string result = "";
            int ascii = 0;
            text = text.ToUpper();
            //ascii 65-90 (A-Z)
            foreach (char c in text)
            {
                ascii = (int)c;
                if (ascii >= 65 && ascii <= 90)
                {
                    ascii -= 3;
                    if (ascii < 65)
                    {
                        ascii = 91 - (65 - ascii);
                    }
                }
                result += (char)ascii;
            }
            return result;
        }

        public string Decypher(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }

            string result = "";
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
                result += (char)ascii;
            }
            return result;
        }
    }
}
