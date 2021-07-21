using System;

using System.Windows.Forms;
using NOpenGLPlatform;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace NOpenGLPlatform {
    public partial class NOpenGLPlatformMain : Form {
        public NOpenGLPlatformAppCore app;
        public bool loaded = false;
        public Timer timer = new Timer();
        public MouseButtons db = MouseButtons.None;
        public int numm = 0;
        public NOpenGLPlatformMain() {
            app = new NOpenGLPlatformAppCore(this);
            InitializeComponent();

            glControl1.Load += GLLoad;
            glControl1.Resize += GLResize;
            glControl1.Paint += GLPaint;

            glControl1.MouseDown += GLMouseDown;
            glControl1.MouseMove += GLMouseMove;
            glControl1.MouseWheel += GLMouseWheel;
            glControl1.MouseUp += GLMouseUp;

            glControl1.KeyPress += GLKeyPress;
            glControl1.KeyDown += GLKeyDown;
            glControl1.KeyUp += GLKeyUp;

            this.FormClosing += GLFormClosing;

        }
        private void GLKeyDown(object sender, System.Windows.Forms.KeyEventArgs e) {
            if (e.Shift) {
                this.app.activeCommandController.shift = true;
            }
            //  Console.WriteLine(e.);
        }
        private void GLKeyUp(object sender, System.Windows.Forms.KeyEventArgs e) {
            if (!e.Shift) {
                this.app.activeCommandController.shift = false;
            }
        }
        private void GLKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e) {
            Console.WriteLine(e.KeyChar.ToString());
        }
        private void GLFormClosing(object sender, FormClosingEventArgs e) {
            app.Terminate();
        }
        void UpdateFrame() {
            if (!loaded) return;
            app.OnFrameUpdate();
            glControl1.SwapBuffers();
        }
        public void UpdateLabel(float x, float y) {
            this.label1.Text = "x: " + x.ToString() + ", " + " y: " + y.ToString();
        }
        private void GLLoad(object sender, EventArgs e) {
            app.Initialize();

            loaded = true;
            timer.Interval = 35;
            timer.Enabled = true;
            timer.Start();
            timer.Tick += new EventHandler(timer_Tick);
        }
        private void GLMouseUp(object sender, MouseEventArgs e) {
            db = MouseButtons.None;
            glControl1.Capture = false;
            app.mouseEvent.MouseUp(e.X, glControl1.Height - e.Y, db);
        }
        private void GLMouseMove(object sender, MouseEventArgs e) {
            app.mouseEvent.MouseMove(e.X, glControl1.Height - e.Y, db);
        }
        private void GLMouseWheel(object sender, MouseEventArgs e) {
            app.mouseEvent.MouseWheel(e.Delta);
        }
        private void GLMouseDown(object sender, MouseEventArgs e) {
            db = e.Button;
            glControl1.Capture = true;
            numm++;
            app.mouseEvent.MouseDown(e.X, glControl1.Height - e.Y, db);
        }
        void timer_Tick(object sender, EventArgs e) {
            if (!loaded) return;
            UpdateFrame();
        }
        private void GLResize(object sender, EventArgs e) {
            if (!loaded) return;
            app.camera.Resize(glControl1.Width, glControl1.Height);
            GL.Viewport(0, 0, app.camera.width, app.camera.height); // Use all of the glControl painting area

            UpdateFrame();
        }
        private void GLPaint(object sender, PaintEventArgs e) {
            if (!loaded) return;
            UpdateFrame();
        }
        // ................................................................ event
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            Form formPopup = new Form();
            formPopup.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            formPopup.Size = new System.Drawing.Size(200, 150);
            formPopup.Text = "About NJSTUDIO";

            Label textBox1 = new Label();
            textBox1.Text = "Click: NJSTUDIO";
            textBox1.BackColor = System.Drawing.Color.Black;
            textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            textBox1.ForeColor = System.Drawing.Color.MediumSeaGreen;
            textBox1.Location = new System.Drawing.Point(0, 33);
            textBox1.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            textBox1.Size = new System.Drawing.Size(200, 150);
            textBox1.TabIndex = 0;
            textBox1.Click += new EventHandler(LB_Click);

            formPopup.Controls.Add(textBox1);
            formPopup.Show(this);
        }
        protected void LB_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("http://www.njstudio.co.kr");
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Rhino3d Files|*.3dm";
            openFileDialog1.Title = "Select File";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                string path = openFileDialog1.FileName;
                string[] pathList = path.Split('.');
                string extesion = pathList[pathList.Length - 1];

                if (extesion == "3dm") {
                    this.app.sceneOpenGL.Load3dm(path);
                    label1.Text = path;
                }

            }
        }
    }
}


