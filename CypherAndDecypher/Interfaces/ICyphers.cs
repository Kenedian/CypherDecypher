using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CypherAndDecypher.Interfaces
{
    public interface ICyphers
    {

        string Cypher(string text);
        string Decypher(string text);
    }
}
