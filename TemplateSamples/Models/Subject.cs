using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateSamples.Models
{
    public class Subject : TemplateItem
    {
        public int Tuition { get; set; }

        public Subject() : base()
        {
            Tuition = 1000000;
        }
        public Subject(string name, string description, int tuition) : base(name, description)
        {
            this.Tuition = tuition;
        }
    }
}
