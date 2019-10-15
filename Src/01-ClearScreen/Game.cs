﻿// Copyright (c) 2019-2020 Faber Leonardo. All Rights Reserved.

/*=============================================================================
	Game.cs
=============================================================================*/

using System;
using System.Collections.Generic;
using System.Text;
using Zeckoxe.Desktop;
using Zeckoxe.Graphics;
//using Zeckoxe.Mathematics;

namespace _01_ClearScreen
{
    public class Game : IDisposable
    {
        public Window Window { get; set; }

        public PresentationParameters Parameters { get; set; }

        public GraphicsAdapter Adapter { get; set; }

        public GraphicsDevice Device { get; set; }

        //public Texture Texture { get; set; }

        //public GraphicsContext Context { get; set; }





        public Game()
        {
            Window = new Window("Zeckoxe Engine - (Clear Screen)", 1000, 720, BorderStyle.Sizable);


            Parameters = new PresentationParameters()
            {
                BackBufferWidth = Window.Width,
                BackBufferHeight = Window.Height,
                DeviceHandle = Window.Handle,
                Settings = new Settings()
                {
                    Validation = true,
                    Fullscreen = true,
                    VSync = false,
                },
            };
        }

        public void Initialize()
        {

            Adapter = new GraphicsAdapter();

            Device = new GraphicsDevice(Adapter);

            //Texture = new Texture(Device);

            //Context = new GraphicsContext(Device);
        }


        public void Run()
        {
            Initialize();

            BeginRun();

            Window?.Show();

            Tick();
        }

        public void Tick()
        {
            Window.RenderLoop(() =>
            {
                Update();
                Draw();
            });
        }



        public void BeginRun()
        {
            foreach (var Description in Device.NativeAdapter.Description)
                Console.WriteLine(Description);

            
            Console.WriteLine();
            Console.WriteLine(Device.NativeAdapter.VendorId);
            Console.WriteLine();
        }

        public void Update()
        {

        }

        public void Draw()
        {

        }

        public void Dispose()
        {
            //Device.Dispose();
        }

    }
}