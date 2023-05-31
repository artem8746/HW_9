    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_9
{
    public class Person
    {
        public string Name { get; set; }

        [DisplayName("Number")]
        public int Id { get; set; }

        public string Gender { get; set; }

        [DisplayName("Living here")]
        public string Address { get; set; }
    }
}
