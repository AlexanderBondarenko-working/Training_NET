using System;
using System.Collections.Generic;
using System.Text;

namespace Task01_1
{
    public static class CommonExtensions
    {
        public static void GenerateGuid(this Entity entity)
        {
            entity.EntityGuid = Guid.NewGuid();
        }
    }
}
