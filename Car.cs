using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilbasen_Mini_projekt
{
    internal class Car
    {
        protected int id;
        protected string type;
        protected string numberplate;
        protected int year;
        protected double price;

        public Car(int id, string type, string numberplate, int year, double price)
        {
            this.id = id;
            this.type = type;
            this.numberplate = numberplate;
            this.year = year;
            this.price = price;
        }

        public int ShowID()
        {
            return id;
        }

        public int AlterID()
        {
            id--;
            return id;
        }
        
        public string CarToString()
        {
            return id + "," + type + "," + numberplate + "," + year + "," + price;
        }

        public void MenuInfo()
        {
            Console.WriteLine(id + ")       " + type);
        }

        public void ShowInfo()
        {
            Console.WriteLine("Car model: " + type);
            Console.WriteLine("Numberplate: " + numberplate);
            Console.WriteLine("Produced in: " + year);
            Console.WriteLine("Price: " + price + " kr.");
        }

        
    }
}
