using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimmeringerAK.Migration.Transformations;

namespace SimmeringerAK.Migration
{
    class Program
    {
        static void Main(string[] args)
        {
            TransformMVC3ToMVC4.Transform();
        }
    }
}
