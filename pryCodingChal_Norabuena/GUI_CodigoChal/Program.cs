using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL_CodingChal;
using System.Threading;

namespace GUI_CodigoChal
{
    class Program
    {
        static void Main(string[] args)
        {
            bl_response _bl = new bl_response();
            Console.Title = "searchfight.exe";
            Console.WriteLine("Enter query:");
            string query = Console.ReadLine();
            _bl.GetResults(query);
            Thread.Sleep(3000);
        }
    }
}
