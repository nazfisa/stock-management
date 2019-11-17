using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Model;

namespace StockManagementSystemWebApp.DAL.Gateway
{
    public class CompanyGateway : BaseGateway
    {
        public Company IsExistedCompany(Company company)
        {
            SetConnection();
            string query = "SELECT * FROM Company WHERE CompanyName='" + company.CompanyName + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            Company aCompany = null;
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                int companyId = Convert.ToInt32(reader["CompanyId"]);
                string companyName = reader["CompanyName"].ToString();
                aCompany = new Company(companyId, companyName);


                reader.Close();
                connection.Close();
                return aCompany;
            }
            reader.Close();
            connection.Close();
            return aCompany;
        }

        public int SaveCompany(Company companyObj)
        {
            SetConnection();
            string query = "INSERT INTO Company VALUES('" + companyObj.CompanyName + "')";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<Company> GetAllCompany()
        {
            SetConnection();
            string query = "SELECT * FROM Company";
            command = new SqlCommand(query, connection);
            connection.Open();

            List<Company> Companylist = new List<Company>();
            reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                int CompanyID = (int)reader["CompanyId"];
                string CompanyName = reader["CompanyName"].ToString();
                Company aCompany = new Company();
                aCompany.CompanyId = CompanyID;
                aCompany.CompanyName = CompanyName;
                Companylist.Add(aCompany);
            }
            reader.Close();
            connection.Close();

            return Companylist;
        }

        public int GetCompanyByName(string companyName)
        {
            SetConnection();
            string query = "SELECT CompanyId FROM Company WHERE CompanyName='" + companyName + "'";
            command = new SqlCommand(query, connection);
            connection.Open();

            reader = command.ExecuteReader();
            reader.Read();
            int CompanyID = Convert.ToInt32(reader["CompanyId"]);
            reader.Close();
            connection.Close();
            return CompanyID;
        }
    }
}