using CypherAndDecypher.CyphersAlg;
using CypherAndDecypher.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CypherAndDecypher.Models
{
    public class CyphersList
    {
        public static Dictionary<string, ICyphers> cyphers = new Dictionary<string, ICyphers>
        {
            {"Morse", new Morse() },
            {"Caesar", new Caesar() }
        };
    }
}
