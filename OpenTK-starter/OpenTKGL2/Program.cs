using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTKApp;

namespace OpenTKApp {
    class Program {
        static void Main(string[] args) {
            GameWindow window = new GameWindow(500, 500);
            App app = new App(window);
        }
    }
}
