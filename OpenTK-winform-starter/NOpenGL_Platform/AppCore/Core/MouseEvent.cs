using System.Windows.Forms;

namespace NOpenGLPlatform.Core {
    public class MouseEvent {
        public NOpenGLPlatform.NOpenGLPlatformAppCore app;
        public float mouseX = 0.0f;
        public float mouseY = 0.0f;
        private float mouseXPre = 0.0f;
        private float mouseYPre = 0.0f;

        public MouseEvent(NOpenGLPlatform.NOpenGLPlatformAppCore app) {
            this.app = app;
        }
        public void MouseMove(float x, float y, MouseButtons button) {
            this.app.gl.UpdateLabel(x, y);

            mouseXPre = mouseX;
            mouseYPre = mouseY;

            mouseX = x;
            mouseY = y;

            float dx = mouseX - mouseXPre;
            float dy = mouseY - mouseYPre;

            if (button == MouseButtons.Left) { // Left
                if (!this.app.activeCommandController.shift) {
                    if (this.app.camera.type == NOpenGLPlatform.Core.CAMERA_TYPE.PERSPECTIVE) {
                        this.app.camera.ArcRotation(dx, dy);
                    }

                }
                else {
                    this.app.camera.Pan(dx, dy);
                }
            }
            else if (button == MouseButtons.Right) {

                this.app.camera.SetDistance(-dy * 0.1f);

            }
            else if (button == MouseButtons.Middle) {
            }
        }
        public void MouseDown(int x, int y, MouseButtons button) {
            this.app.activeCommandController.MouseDown(x, y, button);
        }
        public void MouseUp(int x, int y, MouseButtons button) {
            this.app.activeCommandController.MouseUp(x, y, button);
        }
        public void MouseWheel(int v) {
            this.app.camera.SetDistance(-v * 0.05f);
        }
    }
    public class Size {
        public float width;
        public float height;
        public Size(float width, float height) {
            this.width = width;
            this.height = height;
        }
    }
    public enum CAMERA_TYPE {
        PERSPECTIVE = 0,
        TOP = 1,
        FRONT = 2,
    }
    public class MouseEventData {
        public double mouseX;
        public double mouseY;
        public double mouseXPre;
        public double mouseYPre;
        public MouseEventData() { }
    }
}
