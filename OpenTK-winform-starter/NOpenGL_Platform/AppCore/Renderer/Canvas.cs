using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

using Rhino.Geometry;
using NJS.NJSOpenGL.RhinoUtility;

namespace NOpenGLPlatform.Renderer {
    public class SceneOpenGL {
        public NOpenGLPlatformAppCore app;
        public List<RhinoCurveGL> curve = new List<RhinoCurveGL>();
        public List<RhinoMeshGL> mesh = new List<RhinoMeshGL>();
        public SceneOpenGL(NOpenGLPlatformAppCore app) {
            this.app = app;
        }
        public void Start() {
            // this.Load3dm();
        }
        public void Load3dm(string path = "C:/njz/repository/OpenTK-starter/OpenTK-Winform-starter/sampleMesh.3dm") {
            curve = new List<RhinoCurveGL>();
            mesh = new List<RhinoMeshGL>();
            IO.LoadRhinoFile(path, out mesh, out curve);
        }
        public void Loop() {
            Draw2dgrid(100, 100, 50, 50, 0, 20, 20, 0.5f, new Color4(0.98f, 0.98f, 0.98f, 0.3f));

            // Visualizing Rhino geometries(Mesh and Curve)
            foreach (var o in mesh) o.Render();
            foreach (var o in curve) o.Render();



            // Construct Rhino Points
            List<Point3d> pts = new List<Point3d>();
            for (int i = -15; i < 15; ++i) {
                Point3d p = new Point3d(i, Math.Sin(i * 1.2) * 2.1, 0);
                pts.Add(p);
            }


            // Visualizing the NURBS Curve
            NurbsCurve ns = NurbsCurve.Create(false, 3, pts);
            GL.LineWidth(1f); // 0.6f
            GL.Color4(new Vector4(0, 1, 0, 1));
            GL.Begin(PrimitiveType.LineStrip);

            int resolution = 100;
            for (int i = 0; i <= resolution; ++i) {
                double t = ((ns.Domain[1] - ns.Domain[0]) / resolution);
                Point3d p = ns.PointAt(t * i);
                GL.Vertex3(p.X, p.Y, p.Z);
            }
            GL.End();


            // Visualizing Rhino Points
            GL.PointSize(5f); // 0.6f
            GL.Color4(new Vector4(1, 0, 0, 1));
            GL.Begin(PrimitiveType.Points);
            foreach (var p in pts) {
                GL.Vertex3(p.X, p.Y, p.Z);
            }
            GL.End();

        }
        public static void Draw2dgrid(int xRes, int yRes, int xOffset, int yOffset, int zOffset, int xn, int yn, float lineWidth, Color4 color) {
            GL.LineWidth(lineWidth); // 0.6f
            GL.Color4(color); // 0.5f, 0.5f, 0.5f, 0.6f

            double xd = xRes / xn;
            double yd = yRes / xn;

            for (int i = 0; i <= xn; i++) {
                GL.Begin(PrimitiveType.Lines);
                GL.Vertex3((i * xd) - xOffset, 0 - yOffset, zOffset);
                GL.Vertex3((i * xd) - xOffset, yRes - yOffset, zOffset);
                GL.End();

                GL.Begin(PrimitiveType.Lines);
                GL.Vertex3(0 - xOffset, (i * yd) - yOffset, zOffset);
                GL.Vertex3(xRes - xOffset, (i * yd) - yOffset, zOffset);
                GL.End();
            }
        }
    }
}
