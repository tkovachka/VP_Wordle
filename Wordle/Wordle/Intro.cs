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
    public partial class Intro : Form
    {
        public Intro()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {   
            Form1 form = new Form1((int)numNumber.Value);
            
            form.Show();


            //this.Hide();
        }
    }
}
