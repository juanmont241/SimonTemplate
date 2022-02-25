using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace SimonSays
{
    public partial class GameOverScreen : UserControl
    {
        public GameOverScreen()
        {
            InitializeComponent();
        }

        private void GameOverScreen_Load(object sender, EventArgs e)
        {
            Form1.soundJumpscare.Play();
            //TODO: show the length of the pattern
            lengthLabel.Text += $"{Form1.numPattern.Count}";

   
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
        //TODO: close this screen and open the MenuScreen
        Form1.ChangeScreen(this, new MenuScreen());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;

        }
    }
   }

