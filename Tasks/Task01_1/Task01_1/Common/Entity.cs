using System;
using System.Collections.Generic;
using System.Text;

namespace Task01_1
{
    public class Entity
    {
        public static int maxDescriptionSize = 256;

        private string _description;

        public Guid EntityGuid { get; set; }

        public string Description 
        {
            get => _description;
            set
            {
                if(value != null && value.Length > maxDescriptionSize)
                    throw new ArgumentOutOfRangeException($"The description size should be less than {maxDescriptionSize} characters!");
                _description = value;
            } 
        }

        public override bool Equals(Object obj)
        {
            return obj is Entity equalsWith && equalsWith.EntityGuid == this.EntityGuid;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
