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

        public int TimeLeft { get; set; } = 300;

        public Form1(int number)
        {
            InitializeComponent();
            DoubleBuffered = true;
            scene = new Scene(new Point(50, 50), number);
            timer1.Start();
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
        }

        public bool EnterClicked { get; set; } = false;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

           
                KeysConverter converter = new KeysConverter();
                if ((int)e.KeyCode >= 65 && (int)e.KeyCode <= 90)
                {
                    string s = converter.ConvertToString(e.KeyCode);
                //if (EnterClicked || !scene.SceneIsFull())
                //{
                    scene.AddLetter(s);
                  //  EnterClicked = false;
                //}
                //else
                //{
                  //  MessageBox.Show("Press ENTER to guess!");
                //}
                }

                if (e.KeyValue == 13)
                {
                //if (scene.SceneIsFull())
                //{
                  //  EnterClicked = true;
                //}
                    if (scene.Check())
                    {
                    Invalidate();
                        DialogResult dlg = MessageBox.Show("YOU GUESSED THE WORD! Do you want to start over?",
                            "CONGRATULATIONS!", MessageBoxButtons.YesNo);
                        if (dlg == DialogResult.Yes)
                        {
                            this.Close();

                        }
                    }
                //Invalidate();
                }
            Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeLeft -= 1;
            label1.Text = $"{TimeLeft / 60}:{TimeLeft % 60}";
            if (TimeLeft == 0)
            {
                timer1.Stop();
                MessageBox.Show("You have no more time left!");
                this.Close();
            }
            Invalidate();
        }
    }
}

    

