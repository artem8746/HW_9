using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_9
{
    public class DisplayNameAttribute : Attribute
    {
        public DisplayNameAttribute(string name = null) 
        {
            Name = name;
        }
        public string Name { get;}
    }
}
