using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using TemplateSamples.Models;

namespace TemplateSamples.Presentations.Selectors
{
    // DataTemplateSelector 구현 클래스
    public class ListViewItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate? PersonTemplate { get; set; }
        public DataTemplate? SubjectTemplate { get; set; }

        public override DataTemplate? SelectTemplate(object item, DependencyObject container)
        {
            switch (item)
            {
                case Person:
                    return PersonTemplate;
                case Subject:
                    return SubjectTemplate;
                default:
                    throw new NotSupportedException($"{item.GetType().Name} is not supported.");
            }
        }
    }

}
