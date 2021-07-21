using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenTKApp {
    public class DefinitionGrid : DefinitionBase {
        public override void Start() {

        }
        public override void Update(object o, EventArgs e) {

            // https://docs.microsoft.com/en-us/dotnet/api/opentk.graphics.es11.gl.translate?view=xamarin-ios-sdk-12
            GL.Translate(0, 0, -45);
            // https://docs.microsoft.com/en-us/dotnet/api/opentk.graphics.es11.gl.rotate?view=xamarin-ios-sdk-12
            GL.Rotate(-45, 1, 0, 0);

            // https://docs.microsoft.com/en-us/dotnet/api/opentk.graphics.es30.primitivetype?view=xamarin-ios-sdk-12
            GL.Begin(PrimitiveType.Points);
            GL.PointSize(this.t);
            GL.Color4(0.0, 1.0f, 0.0f, 1.0);

            for (int j = -10; j < 10; j += 3) {
                for (int i = -10; i < 10; i += 3) {
                    GL.Vertex3(i, j, Math.Cos(i * j * this.t));
                }
            }
            GL.End();

            this.t += 0.01f;
        }
    }
}
