using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace random_db_make_for_plate
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {

            SqlConnection baglan=new SqlConnection(@"Data Source=.;Initial Catalog=license plate recognition_test_db;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
            
    }
}
