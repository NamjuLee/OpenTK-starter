using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenTKApp {
   public class App {

        public GameWindow win;
        public DefinitionBase definition;

        public App(GameWindow win) {
            this.win = win;
            this.win.MouseMove += (sender, e) => {
                this.definition.mouse.X = e.X;
                this.definition.mouse.Y = e.Y;
            };

            // this.definition = new DefinitionGrid();
            // this.definition = new DefinitionCube();
            this.definition = new DefinitionShader();

            this.definition.Start();
            this.Init();
        }
        void Init() {
            this.win.Load += this.Load;
            this.win.RenderFrame += RenderFrame;
            this.win.UpdateFrame += UpdateFrame;
            this.win.Run(1.0/60.0);

        }
        void Load(object o , EventArgs e) {
            Console.WriteLine("project loaded");
            GL.ClearColor(0f, 0.0f, 0.0f, 0.0f);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.ColorMaterial);

            GL.MatrixMode(MatrixMode.Projection);
            Matrix4 pMat = Matrix4.CreatePerspectiveFieldOfView (45f * (3.14159265358979f / 180.0f), (float)(win.Width / win.Height), 0.1f, 100f);
            Console.WriteLine(pMat);

            GL.LoadMatrix(ref pMat);
            GL.MatrixMode(MatrixMode.Modelview);
        }
        void UpdateFrame(object o, EventArgs e) { 
            // TO DO: Update
        }
        void RenderFrame(object o, EventArgs e) {
            GL.Viewport(0, 0, win.Width, win.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit); // (ClearBuffer.Color);
            Matrix4 pMat = Matrix4.CreatePerspectiveFieldOfView(45f * (3.14159265358979f / 180.0f), (float)(win.Width / win.Height), 0.1f, 100f);
            GL.LoadMatrix(ref pMat);
            definition.Update(o, e);
            win.SwapBuffers();
        }
    }
}
