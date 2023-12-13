using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis321_makeup_jgswartwood
{
    public class ConnectionString
    {
        public string cs {get; set;}

        public ConnectionString() {
            string server = "s29oj5odr85rij2o.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "aaoof9lgihd2vky5";
            string port = "3306";
            string username = "qj58ja3a5tqwf726";
            string password = "megsqtmdbduytlq8";

            cs = $@"server={server};database={database};port={port};username={username};password={password};";
        }
    }
}