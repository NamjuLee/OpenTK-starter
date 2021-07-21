using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace NOpenGLPlatform {
    public partial class NOpenGLPlatformAppCore { // NOpenGL_Platform
        public NOpenGLPlatform.Core.MouseEvent mouseEvent;
        public NOpenGLPlatform.Core.GeomtryCommon geometryCommon;
        public NOpenGLPlatform.Core.ActiveCommandController activeCommandController;
        public NOpenGLPlatform.Core.Camera camera;
        public NOpenGLPlatform.Renderer.SceneOpenGL sceneOpenGL;
        public NOpenGLPlatform.Core.Renderer renderer;
        public NOpenGLPlatformMain gl;
        public NOpenGLPlatformAppCore(NOpenGLPlatformMain gl) {
            this.gl = gl;
        }
        public void Initialize() {
            this.mouseEvent = new Core.MouseEvent(this);
            this.geometryCommon = new Core.GeomtryCommon(this);
            this.activeCommandController = new Core.ActiveCommandController(this);
            this.camera = new Core.Camera(this, 100, 100);
            this.sceneOpenGL = new Renderer.SceneOpenGL(this);
            this.renderer = new Core.Renderer(this);

            GL.Enable(EnableCap.Blend);
            GL.Enable(EnableCap.PointSmooth);
            GL.Enable(EnableCap.LineSmooth);

            GL.ColorMaterial(MaterialFace.FrontAndBack, ColorMaterialParameter.Diffuse);
            GL.Enable(EnableCap.ColorMaterial);
            GL.Enable(EnableCap.Normalize);

            GL.LightModel(LightModelParameter.LightModelTwoSide, 1);
            GL.LightModel(LightModelParameter.LightModelLocalViewer, 1);

            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

        }
        public void Terminate() {
            // TODO :
        }
        public void OnFrameUpdate() {

            //...............................................................................Set Up Camera
            this.camera.Update();
            GL.ClearColor(0.6f, 0.6f, 0.6f, 1.0f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref this.camera.pmat);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref this.camera.vmat);

            //................................................................................Set Up Lighting
            GL.Enable(EnableCap.Lighting); //enable lighting calculations
            GL.Enable(EnableCap.Light0);    //enable the first light
            GL.Light(LightName.Light0, LightParameter.Position, new Vector4(30.0f, 30.0f, 30.0f, 1.0f)); //set light position and color
            GL.Light(LightName.Light0, LightParameter.Diffuse, new Vector4(1.0f, 1.0f, 1.0f, 1.0f));

            GL.ColorMaterial(MaterialFace.FrontAndBack, ColorMaterialParameter.Diffuse); //enable material
            GL.Enable(EnableCap.ColorMaterial);

            GL.LightModel(LightModelParameter.LightModelTwoSide, 1); //set lighting model 
            GL.LightModel(LightModelParameter.LightModelLocalViewer, 1);
            GL.Enable(EnableCap.DepthTest);

            this.renderer.Render();
        }
    }
}