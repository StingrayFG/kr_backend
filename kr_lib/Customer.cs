using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace kr_lib
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }    

        public LinkedList<Order> Orders { get; set; }
    }
}
