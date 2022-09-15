using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MySql_Login_Panel
{
    public class Method
    {
        #region Users Control

        string constr = "SERVER=localhost; DATABASE=sales; UID=root; PWD=1234";
        
        public int UserControl(string userType, string userBranch)
        {
            int result = 0;

            using(var connection= new MySqlConnection(constr))
            {
                using (var cmd = new MySqlCommand($"SELECT customer, branch FROM sales WHERE customer='{userType}' AND branch='{userBranch}' ", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        MySqlDataReader dtr =(cmd.ExecuteReader());
                        if(dtr.Read())
                        {
                            string d_u = dtr["customer"].ToString();
                            string d_b = dtr["branch"].ToString();
                            if(d_u==userType && d_b==userBranch)
                            {
                                result=1;
                            }
                            else
                            {
                                result=0;
                            }
                        }

                    }
                    catch 
                    {

                       result=0;
                    }
                }
            }
            return result;
        }
        #endregion
    }
}
