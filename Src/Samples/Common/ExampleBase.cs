﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vultaik;
using Vultaik.Desktop;
using Vultaik.Physics;
using Vultaik.Toolkit;

namespace Samples.Common
{
    public class ExampleBase
    {
        public ExampleBase()
        {
            Window = new("Vultaik", 1200, 800);
            Camera = new(45f, 1f, 0.1f, 64f);
            Time = new();
            Model = Matrix4x4.Identity;
            Models = new();
        }

        public Window Window { get; set; }
        public Input? Input => Window.Input;
        public ApplicationTime Time { get; }
        public Matrix4x4 Model { get; set; }
        public List<Matrix4x4> Models { get; set; }
        public Camera Camera { get; set; }


        public virtual void Initialize()
        {
        }

        public virtual Task LoadContentAsync()
        {
            return Task.CompletedTask;
        }

        public virtual void Draw(ApplicationTime time)
        {
        }

        public virtual void Update(ApplicationTime time)
        {
        }

        public virtual void Resize(int width, int height)
        {

        }

        public void Run()
        {

            Initialize();
            LoadContentAsync();

            Time.Update();
            Window?.Show();
            Window!.Resize += ExampleBase_Resize;
            Window.RenderLoop(() =>
            {
                Update(Time);
                Draw(Time);
            });


        }

        private void ExampleBase_Resize((int Width, int Height) obj)
        {
            if (obj.Width == 0 || obj.Height == 0)
                return;

            Resize(obj.Width, obj.Height);
        }

        public SwapchainSource GetSwapchainSource(Adapter adapter)
        {
            if (adapter.SupportsSurface)
            {
                if (adapter.SupportsWin32Surface)
                    return Window.SwapchainWin32!;

                if (adapter.SupportsX11Surface)
                    return Window.SwapchainX11!;

                if (adapter.SupportsWaylandSurface)
                    return Window.SwapchainWayland!;

                if (adapter.SupportsMacOSSurface)
                    return Window.SwapchainNS!;
            }

            throw new PlatformNotSupportedException("Cannot create a SwapchainSource.");
        }

    }
}