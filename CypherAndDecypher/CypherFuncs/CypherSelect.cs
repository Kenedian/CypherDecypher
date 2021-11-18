using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CypherAndDecypher.CypherFuncs
{
    public class CypherSelect
    {
        public static CypherAndDecypher.Models.CypherDecypher Select(CypherAndDecypher.Models.CypherDecypher cd)
        {

            if (cd.cypherDropTo == "Normal")
            {
                cd.cypherTo = cd.cyphers[cd.cypherDropFrom].Decypher(cd.cypherFrom);
            }
            else if (cd.cypherDropFrom == "Normal")
            {
                cd.cypherTo = cd.cyphers[cd.cypherDropTo].Cypher(cd.cypherFrom);
            }
            else
            {
                string tempCypher;
                tempCypher = cd.cyphers[cd.cypherDropFrom].Decypher(cd.cypherFrom);
                cd.cypherTo = cd.cyphers[cd.cypherDropTo].Cypher(tempCypher);
            }

            return cd;
        }
    }
}
