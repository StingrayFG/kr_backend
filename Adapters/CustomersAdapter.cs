using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dal_proj.DAL;
using kr_lib;

#nullable enable

namespace bll_proj.Adapters
{
    public class CustomersAdapter
    {
        private CustomersDAL DAL = new CustomersDAL();

        public void AddCustomer(Customer customer)
        {
            DAL.AddCustomer(customer);
        }

        public int GetLastID()
        {
            return DAL.GetLastID();
        }

        public List<Customer>? GetCustomers()
        {
            return DAL.GetCustomers();
        }

        public Customer? GetCustomerByID(int customerID)
        {
            return DAL.GetCustomerByID(customerID);
        }

        public List<Customer>? GetCustomersByName(string name)
        {
            return DAL.GetCustomersByName(name);
        }

        public List<Customer>? GetCustomersByPhoneNumber(string phoneNumber)
        {
            return DAL.GetCustomersByPhoneNumber(phoneNumber);
        }

        public Customer? GetCustomerByLogin(string phoneNumber, string password)
        {
            return DAL.GetCustomerByLogin(phoneNumber, password);
        }

        public void UpdateCustomerName(int customerID, string newName)
        {
            DAL.UpdateCustomerName(customerID, newName);
        }

        public void UpdateCustomerPhoneNumber(int customerID, string newPhoneNumber)
        {
            DAL.UpdateCustomerPhoneNumber(customerID, newPhoneNumber);
        }

        public void RemoveCustomer(int customerID)
        {
            DAL.RemoveCustomer(customerID);
        }
    }
}
