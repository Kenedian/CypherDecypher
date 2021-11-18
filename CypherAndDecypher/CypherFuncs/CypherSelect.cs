using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CypherAndDecypher.Models;

namespace CypherAndDecypher.CypherFuncs
{
    public class CypherSelect
    {
        public static CypherAndDecypher.Models.CypherDecypher Select(CypherDecypher cd)
        {

            if (cd.cypherDropTo == "Normal")
            {
                cd.cypherTo = CyphersList.cyphers[cd.cypherDropFrom].Decypher(cd.cypherFrom);
            }
            else if (cd.cypherDropFrom == "Normal")
            {
                cd.cypherTo = CyphersList.cyphers[cd.cypherDropTo].Cypher(cd.cypherFrom);
            }
            else
            {
                string tempCypher;
                tempCypher = CyphersList.cyphers[cd.cypherDropFrom].Decypher(cd.cypherFrom);
                cd.cypherTo = CyphersList.cyphers[cd.cypherDropTo].Cypher(tempCypher);
            }

            return cd;
        }
    }
}
