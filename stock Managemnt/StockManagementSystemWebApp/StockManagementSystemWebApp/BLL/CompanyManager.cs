using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Gateway;
using StockManagementSystemWebApp.DAL.Model;

namespace StockManagementSystemWebApp.BLL
{
    public class CompanyManager
    {
        CompanyGateway companyGateway = new CompanyGateway();
        public string SaveCompany(Company companyObj)
        {
            Company acompany = companyGateway.IsExistedCompany(companyObj);

            if (acompany == null)
            {
                int row = companyGateway.SaveCompany(companyObj);
                if (row > 0)
                {
                    return "Successfully Inserted";
                }
                else
                {
                    return "Insert Failed";
                }
            }
            else
            {
                return "Company Already Existed";
            }

        }

        public List<Company> GetAllCompany()
        {
            return companyGateway.GetAllCompany();
        }

        public int GetCompanyByName(string companyName)
        {
            return companyGateway.GetCompanyByName(companyName);
        }
    }
}