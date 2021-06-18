using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsc
{
    class Program
    {   
        static void Main(string[] args)
        {
            KomodoUserInterface.KomodoUI program = new KomodoUserInterface.KomodoUI();
            program.Run();
        }
    }
}
