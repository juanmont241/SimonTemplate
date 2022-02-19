using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;
using System.Threading;

namespace SimonSays
{
    public partial class GameScreen : UserControl
    {
        //TODO: create guess variable to track what part of the pattern the user is at
        int guessNumber = 0;
        Random randGen = new Random();

        int oneNumber = 0;
        int twoNumber = 1;
        int threeNumber = 2;
        int fourNumber = 3;

        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            //TODO: clear the pattern list from form1, refresh, pause for a bit, and run ComputerTurn()
            Form1.numPattern.Clear();
            Refresh();
            Thread.Sleep(1000);
            ComputerTurn();
        }

        private void ComputerTurn()
        {
            //TODO: get rand num between 0 and 4 (0, 1, 2, 3) and add to pattern list
            guessNumber = randGen.Next(0, 4);
            Form1.numPattern.Add(guessNumber);

            //TODO: create a for loop that shows each value in the pattern by lighting up approriate button
            for (int i = 0; i < Form1.numPattern.Count(); i++)
            {
                if (oneNumber == Form1.numPattern[i])
                {
                    greenButton.BackColor = Color.LimeGreen;
                    Refresh();
                    //Place Sound
                    Thread.Sleep(500);
                    greenButton.BackColor = Color.ForestGreen;
                    Refresh();
                }

                else if (twoNumber == Form1.numPattern[i])
                {
                    redButton.BackColor = Color.Firebrick;
                    Refresh();
                    //Place Sound
                    Thread.Sleep(500);
                    redButton.BackColor = Color.DarkRed;
                    Refresh();
                }

                else if (threeNumber == Form1.numPattern[i])
                {
                    yellowButton.BackColor = Color.Yellow;
                    Refresh();
                    //Place Sound
                    Thread.Sleep(500);
                    yellowButton.BackColor = Color.Goldenrod;
                    Refresh();
                }

                else if (fourNumber == Form1.numPattern[i])
                {
                    blueButton.BackColor = Color.RoyalBlue;
                    Refresh();
                    //Place Sound
                    Thread.Sleep(500);
                    blueButton.BackColor = Color.DarkBlue;
                    Refresh();
                }
            }

            //TODO: get guess index value back to 0
            guessNumber = 0;
        }

        public void GameOver()
        {
            //TODO: Play a game over sound

            //TODO: close this screen and open the GameOverScreen
            Form1.ChangeScreen(this, new GameOverScreen());

        }

        //TODO: create one of these event methods for each button
        private void greenButton_Click(object sender, EventArgs e)
        {
            if (Form1.numPattern[guessNumber] == 0)
            {
                greenButton.BackColor = Color.LimeGreen;
                Refresh();
                //Place Sound
                Thread.Sleep(500);
                greenButton.BackColor = Color.ForestGreen;
                Refresh();
                guessNumber++;
            }

            else
            {
                GameOver();
            }

            if (guessNumber == Form1.numPattern.Count)
                //Play Sound
                Thread.Sleep(500);
                guessNumber = 0;
                ComputerTurn();
        }

        private void redButton_Click(object sender, EventArgs e)
        {
            if (Form1.numPattern[guessNumber] == 1)
            {
                redButton.BackColor = Color.Firebrick;
                Refresh();
                //Place Sound
                Thread.Sleep(500);
                redButton.BackColor = Color.DarkRed;
                Refresh();
                guessNumber++;
            }
            else
            {
                GameOver();
            }
        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            if (Form1.numPattern[guessNumber] == 2)
            {
                yellowButton.BackColor = Color.Yellow;
                Refresh();
                //Place Sound
                Thread.Sleep(500);
                yellowButton.BackColor = Color.Goldenrod;
                Refresh();
                guessNumber++;
            }
            else
            {
                GameOver();
            }
        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            if (Form1.numPattern[guessNumber] == 3)
            {
                blueButton.BackColor = Color.RoyalBlue;
                Refresh();
                //Place Sound
                Thread.Sleep(500);
                blueButton.BackColor = Color.DarkBlue;
                Refresh();
                guessNumber++;
            }
            else
            {
                GameOver();
            }

            //TODO: is the value at current guess index equal to a green. If so:
            // light up button, play sound, and pause
            // set button colour back to original
            // add one to the guess index
            // check to see if we are at the end of the pattern. If so:
            // call ComputerTurn() method
            // else call GameOver method
        }
    }
}
