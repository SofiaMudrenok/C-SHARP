using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleApp5
{
    public class Ware
    {
        public string name { get; set; }
        public string country { get; set; }
        public int quantity { get; set; }

        public Ware(string name, string price, int quantity)
        {
            this.name = name;
            this.country = price;
            this.quantity = quantity;
        }

        public override string ToString()
        {
            return $"Goods: '{name}' from {country}$ in quantity {quantity}";
        }
    }
    public class Goods
    {
        public List<Ware> ware = new List<Ware>();

        public Goods()
        {

        }

        public void Add(string name, string price, int quantity)
        {
            ware.Add(new Ware(name, price, quantity));
        }

        public void CreatePO(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Goods));
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
            using (fs)
            {
                serializer.Serialize(fs, this);
            }
        }

        public void ReadPO(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Goods));
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
            using (fs)
            {
                Goods obj = (Goods)serializer.Deserialize(fs);
                this.ware = obj.ware;
            }
        }

        public void Delete()
        {
            int maxPrice = this.ware.Max(x => x.quantity);
            this.ware = this.ware.Where(elem => elem.quantity < maxPrice).ToList();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"C:\Users\Sonya\source\repos\ConsoleApp4\ConsoleApp4";

            Goods goods = new Goods();
            goods.Add("Xiomi", "China", 10000);
            goods.Add("IPhone", "USA", 9900);
            goods.Add("MacBook", "USA", 100);
            goods.Add("Camera", "China", 2000);
            goods.Add("Rug", "Turkey", 6000);
            goods.Add("Pasta", "Italia", 12000);
            goods.Add("IMac", "USA", 2100);
            goods.Add("Plade", "China", 2000);
            goods.Add("Car", "Spain", 600);
            goods.Add("Blender", "Mexica", 200);
            goods.CreatePO(fileName);

            Goods goods2 = new Goods();
            goods2.ReadPO(fileName);

            goods2.Delete();

            foreach (Ware ware in goods2.ware)
            {
                Console.WriteLine(ware.ToString());
            }
            Console.WriteLine();

            var task = goods.ware
            .GroupBy(group => group.quantity, group => group.country)
            .Select(item => new { item.Key, Value = item.Count() });

            foreach (var item in task)
            {
                Console.WriteLine($"{item.Key}, quantity: {item.Value}");
            }
            Console.WriteLine();
        }
    }
}
