using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitofWorkDemo.Core;
using UnitofWorkDemo.Core.POCOs;
using ServiceStack.OrmLite;
using System.Threading;
using System.Globalization;
using UnitofWorkDemo.Core.Repositories;
using UnitofWorkDemo.Core.UnitofWork;

namespace UnitofWorkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

            OrmLiteConfig.DialectProvider = SqlServerDialect.Provider;

            string connectionStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UnitofWork;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            #region Init database table


            //var conn = connectionStr.OpenDbConnection();
            ////Try init data if not existing, for demo only.
            //var c = new Customer() { Id = 2, Name = "John Doe" };

            //if (!conn.TableExists("Customer"))
            //{
            //    conn.CreateTableIfNotExists<Customer>();                
            //}
            //if (!conn.TableExists("Order"))
            //{
            //    conn.CreateTableIfNotExists<Order>();                
            //}

            //conn.Save<Customer>(c);
            //var o = new Order() { CustomerId = c.Id, Customer = c, OrderDate = DateTime.Now };
            //conn.Save<Order>(o);
            //conn.Close();
            #endregion


            var conn = connectionStr.OpenDbConnection();

            //using a UOW with Repository Factory
            using (var uow = new UnitOfWork(conn)) {
                var custRep = uow.GetRepository<Customer>();
                var orderRep = uow.GetRepository<Order>();

                var customer = new Customer { Id = 5, Name = "Matthew Dino" };
                custRep.Save(customer);

                var order = new Order { Customer = customer, CustomerId = customer.Id, OrderDate = DateTime.Now };
                //var order = new Order { Customer = customer, CustomerId = customer.Id};  // <- this line throw an exception
                orderRep.Save(order);

                uow.Commit();
            }


            Console.WriteLine();
            Console.WriteLine("List customers");

            conn = connectionStr.OpenDbConnection();
            var  custRep2 = new Repository<Customer>(conn);
            var customers = custRep2.GetAll();
            foreach (var c in customers)
            {
                Console.WriteLine("{0} - {1}", c.Id, c.Name);
            }

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();



        }



    }
}