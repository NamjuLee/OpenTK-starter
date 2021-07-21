using System;
using OpenTK;

namespace NOpenGLPlatform.Core {
    public class Camera {
        public NOpenGLPlatform.NOpenGLPlatformAppCore app;
        public CAMERA_TYPE type = CAMERA_TYPE.PERSPECTIVE;
        public Vector3 vecCamera;
        public Vector3 vecTarget = new Vector3(0.0f, 0.0f, 10.0f);
        public Vector3 vecUp = new Vector3(0.0f, 0.0f, 1.0f);

        public int modeToggle = 0;

        public float angleXY; // = -1.54;
        public float angleZ; // = 0.0;
        public float distance; // = 75.0;
        public float aspect = 0.0f;
        public float fov = 45f;

        public float nearDistance = 1;
        public float farDistance = 800.0f;

        public int width = 100;
        public int height = 100;

        public double t = 0.0;

        public Matrix4 pmat = Matrix4.Identity;
        public Matrix4 vmat = Matrix4.Identity;

        public Camera(NOpenGLPlatform.NOpenGLPlatformAppCore app, int width, int height) {
            this.app = app;
            this.angleXY = -1.54f;
            this.angleZ = 1.0f;
            this.distance = 45.0f;

            this.aspect = 0.5f;

            this.InitGL();
            this.InitCamera();
        }
        public void InitGL() {
            this.vmat = Matrix4.LookAt(vecCamera, vecTarget, vecUp);
        }
        public void InitCamera() {
            this.Resize(width, height);
            this.ArcRotation(0, 0);
        }
        public void Update() {
            if (type == CAMERA_TYPE.PERSPECTIVE) {
                this.pmat = Matrix4.CreatePerspectiveFieldOfView(45 * ((float)Math.PI / 180f), aspect, nearDistance, farDistance);
                this.vmat = Matrix4.LookAt(vecCamera, vecTarget, vecUp);
            }
            t += 1;
        }
        public void ArcRotation(float dx, float dy) {
            this.angleXY += -dx * 0.01f;
            this.angleZ += -dy * 0.01f;

            this.vecCamera.X = vecTarget.X + distance * (float)Math.Cos(angleXY) * (float)Math.Cos(angleZ);
            this.vecCamera.Y = vecTarget.Y + distance * (float)Math.Sin(angleXY) * (float)Math.Cos(angleZ);
            this.vecCamera.Z = vecTarget.Z + distance * (float)Math.Sin(angleZ);
        }
        public void Pan(float dx, float dy) {
            this.vecCamera.X += -dx * 0.1f;
            this.vecCamera.Z += -dy * 0.1f;

            this.vecTarget.X += -dx * 0.1f;
            this.vecTarget.Z += -dy * 0.1f;
        }
        public void SetDistance(float v) {
            this.distance += v;

            this.vecCamera.X = vecTarget.X + this.distance * (float)Math.Cos(angleXY) * (float)Math.Cos(angleZ);
            this.vecCamera.Y = vecTarget.Y + this.distance * (float)Math.Sin(angleXY) * (float)Math.Cos(angleZ);
            this.vecCamera.Z = vecTarget.Z + this.distance * (float)Math.Sin(angleZ);
        }
        public void Resize(int width, int height) {
            this.width = width;
            this.height = height;
            this.aspect = width / height;
        }
    }
}

