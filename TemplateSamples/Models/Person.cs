using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateSamples.Models
{
    public class Person : TemplateItem
    {

        public Person() : base()
        {
        }
        public Person(string name, string description) : base(name, description)
        {
        }
    }
}
