using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wordle
{
    public partial class Form1 : Form
    {
        Scene scene;

        public object Character { get; private set; }

        public Form1(int number)
        {
            InitializeComponent();
            DoubleBuffered = true;
            scene=new Scene(new Point(50,50),number);
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            KeysConverter converter = new KeysConverter();
            if ((int)e.KeyCode >= 65 && (int)e.KeyCode <= 90)
            {
                string s = converter.ConvertToString(e.KeyCode);
                scene.AddLetter(s);
            }
            Invalidate();
        }
    }
}
