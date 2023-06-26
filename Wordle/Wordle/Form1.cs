using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wordle;

namespace Wordle
{
    public partial class Wordle : Form
    {


        Scene scene;
        public int TimeLeft { get; set; }

        public int n { get; set; } = 0;

        public Wordle(int number)
        {
            InitializeComponent();
            DoubleBuffered = true;
            scene = new Scene(new Point(50, 50), number);
            TimeLeft = 300;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeLeft -= 1;
            label1.Text = $"{(TimeLeft / 60).ToString("D2")}:{(TimeLeft % 60).ToString("D2")}";
            if (TimeLeft == 0)
            {
                timer1.Stop();
                MessageBox.Show("You have no more time left!");
                this.Close();
            }
            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            KeysConverter converter = new KeysConverter();
            if ((int)e.KeyCode >= 65 && (int)e.KeyCode <= 90)
            {
                if (!scene.full)
                {
                    string s = converter.ConvertToString(e.KeyCode);
                    scene.AddLetter(s);
                    for (int i = n; i < scene.Words.Count; i++)
                    {
                        if (scene.Words[i].IsFull)
                        {
                            scene.full = true;
                            n++;
                        }
                    }
                }

            }

            if (e.KeyCode == Keys.Back) // Check if Backspace key is pressed
            {
                foreach (Word word in scene.Words)
                {

                    for (int i = word.Squares.Count - 1; i >= 0; i--)
                    {
                        if (!string.IsNullOrEmpty(word.Squares[i].Letter) && word.Squares[i].Status==0)
                        {
                            if (i == word.Squares.Count - 1)
                                word.IsFull = false;
                            word.Squares[i].Letter = "";
                            word.Squares[i].Empty = true;
                            break;
                        }
                    }

                }
            }

            if (e.KeyValue == 13)
            {
                if (scene.full)
                {
                    bool green = scene.Check();
                    Invalidate();

                    if (green)
                    {
                        //TODO: Open new intro window 
                        DialogResult dlg = MessageBox.Show("YOU GUESSED THE WORD! Do you want to start over?",
                            "CONGRATULATIONS!", MessageBoxButtons.YesNo);
                        if (dlg == DialogResult.Yes)
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        foreach (Word w in scene.Words)
                        {

                            w.IsCorrect();
                        }
                    }
                    scene.full = false;

                    if (scene.GameOver)
                    {
                        //TODO: open new intro window 
                        DialogResult dlg = MessageBox.Show("No more attepts left. Do you want to try again?", "Game Over", MessageBoxButtons.YesNo);
                        if (dlg == DialogResult.Yes)
                        {
                            this.Close();
                        }
                    }
                }

            }

            Invalidate();
        }
    }
}

      


    

