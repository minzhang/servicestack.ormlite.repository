using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitofWorkDemo.Core.POCOs;

namespace UnitofWorkDemo.Core.Repositories
{
    class OrderRepository
    {
        private Repository<Order> orders;

        public OrderRepository(IDbConnection db)
        {
            orders = new Repository<Order>(db);
        }

        public List<Order> GetAllOrders()
        {
            return orders.GetAll();
        }

        public void Save(Order c)
        {
            orders.Save(c);
        }
    }
}
