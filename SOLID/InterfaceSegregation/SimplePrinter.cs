using System;

namespace SOLID.InterfaceSegregation
{
    public class SimplePrinter : IPrinter {

        
        public void Print() {
            Console.WriteLine("Print pages");
        }
    }
}
