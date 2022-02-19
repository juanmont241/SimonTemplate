﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.Drawing.Drawing2D;

namespace SimonSays
{
    public partial class Form1 : Form
    {
        public static List<int> numPattern = new List<int>();
        //TODO: create a List to store the pattern. Must be accessable on other screens

        public Form1()
        {
            InitializeComponent();
        }

        public static void ChangeScreen(object sender, UserControl next)
        {
            Form f; // will either be the sender or parent of sender 

            if (sender is Form)
            {
                f = (Form)sender;    //f is sender
            }

            else
            {
                UserControl current = (UserControl)sender;  //create UserControl from sender 
                f = current.FindForm();                     //find Form UserControl is on 
                f.Controls.Remove(current);                 //remove current UserControl
            }

            // add the new UserControl to the middle of the screen and focus on it 
            next.Location = new Point((f.ClientSize.Width - next.Width) / 2,
                (f.ClientSize.Height - next.Height) / 2);

            f.Controls.Add(next);
            next.Focus();
        }

        public static void ChangeScreen(UserControl current, UserControl next)
        {

            Form f = current.FindForm();
            f.Controls.Remove(current);

            next.Location = new Point((f.ClientSize.Width - next.Width) / 2,
                (f.ClientSize.Height - next.Height) / 2);

            next.Focus();
            f.Controls.Add(next);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //TODO: Launch MenuScreen
            Form1.ChangeScreen(this, new MenuScreen());

        }
    }
}
