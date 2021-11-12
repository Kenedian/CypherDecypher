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
            string cypher = "";
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
                cypher += (char)ascii;
            }

            //this.cypherTo = cypher;
            return cypher;
        }

        public string Decypher(string text)
        {
            string decypher = "";
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
                decypher += (char)ascii;
            }

            //this.cypherTo = cypher;
            return decypher;
        }
    }
}
