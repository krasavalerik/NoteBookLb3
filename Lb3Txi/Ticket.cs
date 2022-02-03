using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb3Txi
{
    [Serializable]
    public class Ticket
    {
        private int price;
        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        private int coach;
        public int Coach
        {
            get { return coach; }
            set { coach = value; }
        }

        private int place;
        public int Place
        {
            get { return place; }
            set { place = value; }
        }

        private String name;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public Ticket() { }

        public virtual void Discount() 
        {
            if (age >= 65)
                price = price / 2;
        }
    }
}
