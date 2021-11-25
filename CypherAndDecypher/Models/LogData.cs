using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CypherAndDecypher.Models
{
    public class LogData
    {
        public DateTime date { get; set; }
        public string cypherFrom { get; set; }
        public string cypherTo { get; set; }

        public string cypherFromText { get; set; }
        public string cypherToText { get; set; }
    }
}
