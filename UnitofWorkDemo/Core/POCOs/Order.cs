using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace UnitofWorkDemo.Core.POCOs
{
    public class Order
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [References(typeof(Customer))]
        public int CustomerId { get; set; }
        [Reference]
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
