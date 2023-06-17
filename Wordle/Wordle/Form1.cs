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

        public Form1(int number)
        {
            InitializeComponent();
            DoubleBuffered = true;
            scene = new Scene(new Point(50, 50), number);
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

                if (e.KeyValue == 13)
                {
                   
                    if (scene.Check())
                    {
                        DialogResult dlg = MessageBox.Show("YOU GUESSED THE WORD! Do you want to start over?",
                            "CONGRATULATIONS!", MessageBoxButtons.YesNo);
                        if (dlg == DialogResult.Yes)
                        {
                            this.Close();

                        }
                    }
                   
                }
            Invalidate();
        }
    }
}

    

