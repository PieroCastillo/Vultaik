﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systems;

namespace _04__Color_
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var App = new Core())
            {
                App.Initialize();
                App.Run();
            }
        }
    }
}
