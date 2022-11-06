using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Subscriber
    {
        public int id { get; set; }
        public string phone { get; set; }
        public string address { get; set; }

        public string owner { get; set; }

        public int sumTime { get; set; }
        public Subscriber(int id, string phone, string address, string owner, int sumTime)
        {
            this.id = id;
            this.phone = phone;
            this.address = address;
            this.owner = owner;
            this.sumTime = sumTime;
        }
        public Subscriber(string phone, string address, string owner, int sumTime) {
            this.id = 0;
            this.phone = phone;
            this.address = address;
            this.owner = owner;
            this.sumTime = sumTime;
        }
        public Subscriber() { }
        public override string ToString()
        {
            return $"Owner:{owner} with id {id}";
        }
    }
}
