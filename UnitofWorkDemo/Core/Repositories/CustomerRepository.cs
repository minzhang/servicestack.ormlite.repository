using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitofWorkDemo.Core.POCOs;

namespace UnitofWorkDemo.Core.Repositories
{
    public class CustomerRepository 
    {
        private Repository<Customer> rep;

        public CustomerRepository(IDbConnection db)
        {
            rep = new Repository<Customer>(db);
        }

        public List<Customer> GetAllCustomers()
        {
            return rep.GetAll();
        }

        public void Save(Customer c)
        {
            rep.Save(c);
        }
    }
}