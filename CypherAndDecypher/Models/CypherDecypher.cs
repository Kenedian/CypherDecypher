using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CypherAndDecypher.CyphersAlg;
using CypherAndDecypher.Interfaces;

namespace CypherAndDecypher.Models
{
    public class CypherDecypher
    {
        public string cypherFrom { get; set; }
        public string cypherTo { get; set; }
        public string cypherSubmit { get; set; }
        public string cypherDropFrom { get; set; }
        public string cypherDropTo { get; set; }
        private static Morse morse = new Morse();
        private static Caesar caesar = new Caesar();
        public Dictionary<string, ICyphers> cyphers = new Dictionary<string, ICyphers>
        {
            {"Morse", morse },
            {"Caesar", caesar }
        };
        
    }
}