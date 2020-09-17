using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Courses
{
    public enum Options
    {
        Active,
        Deleted
    }
    public abstract class BaseClass
    {
        public Options Status { get; set; }
        public bool IsNew { get; private set; }
        public bool HasChanges { get; set; }
        public bool IsValid => Validate();


        public abstract bool Validate();

    }
   
}
