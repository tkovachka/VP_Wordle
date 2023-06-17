﻿using System;
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
            if (scene.GameOver)
            {
                DialogResult dlg = MessageBox.Show("No more attepts left. Do you want to try again?", "Game Over", MessageBoxButtons.YesNo);
                if (dlg == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            if (e.KeyCode == Keys.Back) // Check if Backspace key is pressed
            {
                foreach (Word word in scene.Words)
                {
                    
                    for (int i = word.Squares.Count - 1; i >= 0; i--)
                    {
                        if (!string.IsNullOrEmpty(word.Squares[i].Letter))
                        {
                            if (i == word.Squares.Count - 1)
                                word.IsFull = false;
                            word.Squares[i].Letter = "";
                            word.Squares[i].Empty=true;
                            break;
                        }
                    }
                    
                }
            }
            if (e.KeyValue == 13)
                {

                if (scene.Check())
                {
                    Invalidate();
                    DialogResult dlg = MessageBox.Show("YOU GUESSED THE WORD! Do you want to start over?",
                        "CONGRATULATIONS!", MessageBoxButtons.YesNo);
                    if (dlg == DialogResult.Yes)
                    {
                        Intro intro = new Intro();
                        this.Hide();
                        intro.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
            Invalidate();
        }
    }
}

    

