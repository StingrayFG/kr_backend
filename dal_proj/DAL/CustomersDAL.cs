using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kr_lib;

#nullable enable

namespace dal_proj.DAL
{
    public class CustomersDAL
    {
        ApplicationContext db = new ApplicationContext();

        public void AddCustomer(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
        }
            
        public int GetLastID()
        {
            int? id = db.Customers.Max(mb => (int?)mb.ID);
            if (id == null) { return 1; }
            else { return (int)id; }
        }

        public List<Customer>? GetCustomers()
        {
            List<Customer>? customers = db.Customers.ToList();
            return customers;
        }

        public Customer? GetCustomerByID(int customerID)
        {
            Customer? customer = (from p in db.Customers where p.ID == customerID select p).First();
            return customer;
        }

        public List<Customer>? GetCustomersByName(string name)
        {
            List<Customer>? customers = (from c in db.Customers where c.Name.Contains(name) select c).ToList();
            return customers;
        }

        public List<Customer>? GetCustomersByPhoneNumber(string phoneNumber)
        {
            List<Customer>? customers = (from c in db.Customers where c.PhoneNumber.Contains(phoneNumber) select c).ToList();
            return customers;
        }

        public Customer? GetCustomerByLogin(string phoneNumber, string password)
        {
            Customer? customer = (from p in db.Customers where ((p.PhoneNumber == phoneNumber) && (p.Password == password)) select p).FirstOrDefault();
            return customer;
        }

        public void UpdateCustomerName(int customerID, string newName)
        {
            Customer? customer = (from c in db.Customers where c.ID == customerID select c).First();
            if (customer != null)
            {
                customer.Name = newName;
                db.SaveChanges();
            }
        }

        public void UpdateCustomerPhoneNumber(int customerID, string newPhoneNumber)
        {
            Customer? customer = (from c in db.Customers where c.ID == customerID select c).First();
            if (customer != null)
            {
                customer.PhoneNumber = newPhoneNumber;
                db.SaveChanges();
            }
        }

        public void RemoveCustomer(int customerID)
        {
            Customer? customer = (from c in db.Customers where c.ID == customerID select c).First();
            if (customer != null)
            {
                db.Customers.Remove(customer);
                db.SaveChanges();
            }
        }
    }
}
