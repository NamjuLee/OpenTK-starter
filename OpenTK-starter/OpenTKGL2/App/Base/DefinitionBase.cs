using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenTKApp {
    public abstract class DefinitionBase {
        public float t = 0.0f;
        public Vector3 mouse;
        public DefinitionBase() {
        }
        public abstract void Start();
        public abstract void Update(object o, EventArgs e);
    }
}
