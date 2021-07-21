using System;
using System.Windows.Forms;

namespace NOpenGLPlatform.Core {
    public class ActiveCommandController {
        public NOpenGLPlatform.NOpenGLPlatformAppCore app;
        private bool _shift = false;

        public ActiveCommandController(NOpenGLPlatform.NOpenGLPlatformAppCore app) {
            this.app = app;
        }
        public void MouseDown(int x, int y, MouseButtons button) {
            this.app.geometryCommon.FindGeometry(x, y);
        }
        public void MouseUp(double x, double y, MouseButtons button) {

        }
        public bool shift {
            get {
                Console.WriteLine(this._shift);
                return this._shift;
            }
            set {
                this._shift = value;
                Console.WriteLine(this._shift);
            }
        }

    }
}
