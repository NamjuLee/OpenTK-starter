using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using System;
using OpenTK;

using Rhino.Geometry;

namespace NOpenGLPlatform.Core {
    public class Renderer {
        public NOpenGLPlatformAppCore app;
        public Renderer(NOpenGLPlatformAppCore app) {
            this.app = app;
            this.Init();
        }
        public void Init() {
            this.app.sceneOpenGL.Start();
        }
        public void Render() {
            this.app.sceneOpenGL.Loop();
        }
    }
}
