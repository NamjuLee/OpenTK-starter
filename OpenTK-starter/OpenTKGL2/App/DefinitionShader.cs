using System;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using NJS.NJSOpenGL.ShaderUtility;

namespace OpenTKApp {
    public class DefinitionShader : DefinitionBase {

        private readonly float[] vertices = {
            -0.5f, -0.5f, 0.0f, // Bottom-left vertex
             0.5f, -0.5f, 0.0f, // Bottom-right vertex
             0.0f,  0.5f, 0.0f  // Top vertex
        };
        private int vertexBufferObject;
        private int vertexArrayObject;

        private Shader shader;

        // https://opentk.net/learn/chapter1/4-shaders.html
        private string vert =
            "layout(location = 0) in vec3 aPosition;" +
            "out vec3 pos;" +
            "out float dis;" +
            "void main(void) {" +
            "   pos = aPosition;" +
            "   gl_Position = vec4(aPosition, 1.0);" +
            "}";

        // https://www.shaderific.com/glsl-functions
        private string frag =
            "out vec4 outputColor;" +
            "in vec3 pos;" +
            "uniform vec2 mouse;" +
            "void main(void) {" +
            "   float r = pos.x * mouse.x * 0.01;" +
            "   float g = pos.y * mouse.y * 0.01;" +
            "   vec2 m = normalize(mouse);" +
            "   float b = distance(m, vec2(pos.xy));" +
            "   outputColor = vec4(r * b, g * b, b, 1.0);" +
            "}";

        public override void Start() {
            mouse = new Vector3(0, 0, 0);

            vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(vertexArrayObject);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            shader = new Shader(vert, frag);
        }
        public override void Update(object o, EventArgs e) {

            shader.Use();

            int vertexColorLocation = GL.GetUniformLocation(this.shader.Handle, "mouse");
            GL.Uniform2(vertexColorLocation,  mouse.X, mouse.Y);

            GL.BindVertexArray(vertexArrayObject);

            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
        }
        public void Destroy() {
            // Unbind all the resources by binding the targets to 0/null.
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);

            // Delete all the resources.
            GL.DeleteBuffer(vertexBufferObject);
            GL.DeleteVertexArray(vertexArrayObject);
            GL.DeleteProgram(shader.Handle);
        }
    }
}