﻿using Samples.Samples;
using System;

namespace Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            //using var App = new ClearScreen();
            using var App = new Triangle();
            App.Run();
        }
    }
}