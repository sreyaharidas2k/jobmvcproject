using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace jobmvcproject.Models
{
    public class CompanyIdDB
    {
        string connectionString = ConfigurationManager.ConnectionStrings["TestCon"].ConnectionString;
        SqlConnection con;

        public CompanyIdDB()//constructor
        {
            con = new SqlConnection(connectionString);
        }

        public List<company_class> SelectId()
        {
            var getdata = new List<company_class>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_companyid", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    var o = new company_class
                    {
                        cid = Convert.ToInt32(dr["Company_Id"]),//set
                        cname = dr["Company_Name"].ToString()
                    };
                    getdata.Add(o);
                }
                con.Close();
                return getdata;
            }
            catch(Exception)
            {
                if(con.State==ConnectionState.Open)
                {
                    con.Close();
                }
                throw;
            }
        }
    }
}