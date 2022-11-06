using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            
            SubscriberTable subscriber = new SubscriberTable();
            Subscriber project = new Subscriber(1, "09934423424", "ukraine", "Sasha", 42);

            subscriber.Save(project);

            Console.WriteLine(project.id);

            foreach (var item in subscriber.GetAll())
            {
                Console.WriteLine(item);
            }

            project.owner = "qwer";
            subscriber.Save(project);

            foreach (var item in subscriber.GetAll())
            {
                Console.WriteLine(item);
            }

            subscriber.Remove(project);

            foreach (var item in subscriber.GetAll())
            {
                Console.WriteLine(item);
            }

            Subscriber project1 = subscriber.GetById(1);
            Console.WriteLine(project1);

            Console.WriteLine(subscriber.GetAvg(2));

            Singleton.CloseConnection();

        }
    }
}
