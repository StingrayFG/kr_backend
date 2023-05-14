using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bll_proj.Adapters;
using kr_lib;

#nullable enable

namespace bll_proj.BLL
{
    [System.ComponentModel.DataObject]
    public class CustomersBLL
    {
        private CustomersTableAdapter Adapter = new CustomersTableAdapter();

        [System.ComponentModel.DataObjectMethod
        (System.ComponentModel.DataObjectMethodType.Select, true)]

        public void AddCustomer(string name, string phoneNumber, string password)
        {
            Adapter.AddCustomer(new Customer
            {
                ID = Adapter.GetLastID() + 1,
                Name = name,
                PhoneNumber = phoneNumber,
                Password = password
            });
        }

        public List<Customer>? GetCustomers()
        {
            return Adapter.GetCustomers();
        }

        public Customer? GetCustomerByID(int customerID)
        {
            return Adapter.GetCustomerByID(customerID);
        }

        public List<Customer>? GetCustomersByName(string name)
        {
            return Adapter.GetCustomersByName(name);
        }

        public List<Customer>? GetCustomersByPhoneNumber(string phoneNumber)
        {
            return Adapter.GetCustomersByName(phoneNumber);
        }

        public Customer? GetCustomerByLogin(string phoneNumber, string password)
        {
            return Adapter.GetCustomerByLogin(phoneNumber, password);
        }

        public void UpdateCustomerName(int customerID, string newName)
        {
            Adapter.UpdateCustomerName(customerID, newName);
        }

        public void UpdateCustomerPhoneNumber(int customerID, string newPhoneNumber)
        {
            Adapter.UpdateCustomerName(customerID, newPhoneNumber);
        }

        public void RemoveCustomer(int customerID)
        {
            Adapter.RemoveCustomer(customerID);
        }
    }
}
