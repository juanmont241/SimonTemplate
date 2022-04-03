using System;
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

    //Juan Montoya
    //February 25th 2022
    //Simion Says - Five Nights At Freddy's Themed

    public partial class Form1 : Form
    {
        public static List<int> numPattern = new List<int>();
        //Creates a list for the Pattern the AI is going to set

        public Form1()
        {
            InitializeComponent();
        }

        public static void ChangeScreen(object sender, UserControl next) //Code for changing from screen to screen
        {
            Form f; 

            if (sender is Form)
            {
                f = (Form)sender;    
            }

            else
            {
                UserControl current = (UserControl)sender;  
                f = current.FindForm();                     
                f.Controls.Remove(current);                
            }

            next.Location = new Point((f.ClientSize.Width - next.Width) / 2,
                (f.ClientSize.Height - next.Height) / 2);

            f.Controls.Add(next);
            next.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Changes screen to MenuScreen
            Form1.ChangeScreen(this, new MenuScreen());

        }
    }
}
