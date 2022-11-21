using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XMLConfiguration
{
    public static class ConfigurationHelper
    {

        public static void TryAddElement(this XElement target, string nameOfElementForAdd, string valueOfElementForAdd)
        {
            if (target.Element(nameOfElementForAdd) == null)
            {
                target.Add(new XElement(nameOfElementForAdd) { Value = valueOfElementForAdd });
            }
        }
    }
}
