using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2praktos__
{
    internal class node
    {
        public string name, desc;
        public DateTime date;

        public node(string name, string desc, DateTime date)
        {
            this.name = name;
            this.desc = desc;
            this.date = date;
        }
    }
}
