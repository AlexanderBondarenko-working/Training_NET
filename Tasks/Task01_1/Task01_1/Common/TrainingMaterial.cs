using System;
using System.Collections.Generic;
using System.Text;

namespace Task01_1
{
    public abstract class TrainingMaterial : Entity, ICloneable
    {
        public abstract object Clone();
    }
}
