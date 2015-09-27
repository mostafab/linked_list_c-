using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListProject
{
    class Tester
    {

        static void Main() {
            LinkedList<int> ints = new LinkedList<int>();
            int i = 0;
            while (i < 10)
            {
                ints.addToTail(i);
                i++;
            }
            Console.WriteLine(ints);
            ints.removeAtIndex(1);
            Console.WriteLine(ints);
        }
        
    }
}
