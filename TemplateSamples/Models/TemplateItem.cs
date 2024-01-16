using System;

namespace TemplateSamples.Models
{
    public class TemplateItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public TemplateItem()
        {
            Id = Guid.NewGuid().ToString();
            Name = string.Empty;
            Description = string.Empty;
        }

        public TemplateItem(string name, string description) : this()
        {
            Name = name;
            Description = description;
        }   
    }
}