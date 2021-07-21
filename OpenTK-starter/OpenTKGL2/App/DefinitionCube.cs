using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenTKApp {
    public class DefinitionCube : DefinitionBase {

        public override void Start() {
  
        }
        public override void Update(object o, EventArgs e) {
            // https://docs.microsoft.com/en-us/dotnet/api/opentk.graphics.es11.gl.translate?view=xamarin-ios-sdk-12#OpenTK_Graphics_ES11_GL_Translate_System_Single_System_Single_System_Single_
            GL.Translate(0, 0, -85);
            GL.Rotate(t, 0, 0, 1);
            GL.Rotate(t, 0, 1, 0);

            // https://www.google.com/search?q=GL.Begin(BeginMode.Quads)&sxsrf=ALeKk01Niap7qdXTc42bvDhVHQkLvYTQPQ:1626566800644&source=lnms&tbm=isch&sa=X&ved=2ahUKEwiJ2-vCqevxAhVlEVkFHbPkA18Q_AUoAXoECAEQAw&biw=1881&bih=1042#imgrc=3Fv621Q1huj1XM
            GL.Begin(PrimitiveType.Quads);

            GL.Normal3(-1.0, 0.0, 0.0);
            GL.Color3(1.0, 1.0, 0.0);
            GL.Vertex3(-10.0, 10.0, 10.0);
            GL.Vertex3(-10.0, 10.0, -10.0);
            GL.Vertex3(-10.0, -10.0, -10.0);
            GL.Vertex3(-10.0, -10.0, 10.0);

            GL.Normal3(1.0, 0.0, 0.0);
            GL.Color3(1.0, 0.0, 1.0);
            GL.Vertex3(10.0, 10.0, 10.0);
            GL.Vertex3(10.0, 10.0, -10.0);
            GL.Vertex3(10.0, -10.0, -10.0);
            GL.Vertex3(10.0, -10.0, 10.0);

            GL.Normal3(0.0, -1.0, 0.0);
            GL.Color3(0.0, 1.0, 1.0);
            GL.Vertex3(10.0, -10.0, 10.0);
            GL.Vertex3(10.0, -10.0, -10.0);
            GL.Vertex3(-10.0, -10.0, -10.0);
            GL.Vertex3(-10.0, -10.0, 10.0);

            GL.Normal3(0.0, 1.0, 0.0);
            GL.Color3(1.0, 0.0, 0.0);
            GL.Vertex3(10.0, 10.0, 10.0);
            GL.Vertex3(10.0, 10.0, -10.0);
            GL.Vertex3(-10.0, 10.0, -10.0);
            GL.Vertex3(-10.0, 10.0, 10.0);

            GL.Normal3(0.0, 0.0, -1.0);
            GL.Color3(0.0, 1.0, 0.0);
            GL.Vertex3(10.0, 10.0, -10.0);
            GL.Vertex3(10.0, -10.0, -10.0);
            GL.Vertex3(-10.0, -10.0, -10.0);
            GL.Vertex3(-10.0, 10.0, -10.0);

            GL.Normal3(0.0, 0.0, 1.0);
            GL.Color3(0.0, 0.0, 1.0);
            GL.Vertex3(10.0, 10.0, 10.0);
            GL.Vertex3(10.0, -10.0, 10.0);
            GL.Vertex3(-10.0, -10.0, 10.0);
            GL.Vertex3(-10.0, 10.0, 10.0);

            GL.End();
            this.t += 0.751f;
        }
    }
}
