using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myWeb.Options
{
    public class DatabaseOptions
    {
        public DatabaseOptions() { }

        public string DatabaseName { get; set; }
        public string DatabaseUser { get; set; }
        public string DatabasePassword { get; set; }
        public string DatabasePort { get; set; }
        public string DatabaseHost { get; set; }

        public string DatabaseConnection()
        {
            //"MySqlConnection": "server=localhost;port=3306;database=IdSrv;user=xxxx;password=xxxx"

            return $"server={DatabaseHost};port={DatabasePort};database={DatabaseName};user={DatabaseUser};password={DatabasePassword}";
        }
    }
}
