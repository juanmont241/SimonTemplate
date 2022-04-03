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

        int guessNumber = 0; //Set the guessNumber
        Random randGen = new Random(); //Declare the randomGen

        List<SoundPlayer> soundList = new List<SoundPlayer>(); //List to store all sounds

        public GameScreen()
        {
            //Declare all the sounds that will be use for the game
            SoundPlayer buttonRed = new SoundPlayer(Properties.Resources.TrueRed);
            SoundPlayer buttonYellow = new SoundPlayer(Properties.Resources.TrueYellow);
            SoundPlayer buttonGreen = new SoundPlayer(Properties.Resources.TrueGreen);
            SoundPlayer buttonBlue = new SoundPlayer(Properties.Resources.TrueBlue);
            SoundPlayer soundJumpscare = new SoundPlayer(Properties.Resources.Jumpscare1);

            //Add thoses said sounds to the soundList
            soundList.Add(buttonRed);
            soundList.Add(buttonYellow);
            soundList.Add(buttonGreen);
            soundList.Add(buttonBlue);
            soundList.Add(soundJumpscare);

            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            //Reset the pattern list from form 1
            Form1.numPattern.Clear();
            Refresh(); 
            //Wait for a moment
            Thread.Sleep(1000);
            //Then its the computer's turn
            ComputerTurn();
        }

        private void ComputerTurn() //What would the Computer player do
        {
            //Set which number is asigned to the guessNumber
            guessNumber = randGen.Next(0, 4);
            //Add that said number to the numPattern List
            Form1.numPattern.Add(guessNumber);

            
            for (int i = 0; i < Form1.numPattern.Count(); i++) //For loop (The numPattern Count increaces each time the player completes a pattern)
            {
                //if statements showing what happens if the guessNumber has either 0, 1, 2, or 3
                if (Form1.numPattern[i] == 0) //If the list pattern from Form1 is #.
                {
                    soundList[2].Play(); //Plays color sound
                    greenButton.BackColor = Color.LimeGreen; //Change to a lighter Color
                    Refresh(); //Refresh the screen
                    Thread.Sleep(600); //Wait for a moment
                    greenButton.BackColor = Color.ForestGreen; //Change the color back to its normal state
                    Refresh();
                }

                else if (Form1.numPattern[i] == 1) //Red Button
                {
                    soundList[0].Play();
                    redButton.BackColor = Color.Firebrick;
                    Refresh();
                    Thread.Sleep(600);
                    redButton.BackColor = Color.DarkRed;
                    Refresh();
                }

                else if (Form1.numPattern[i] == 2) //Yellow Button
                {
                    soundList[1].Play();
                    yellowButton.BackColor = Color.Yellow;
                    Refresh();
                    Thread.Sleep(600);
                    yellowButton.BackColor = Color.Goldenrod;
                    Refresh();
                }

                else if (Form1.numPattern[i] == 3) //Blue Button
                {
                    soundList[3].Play();
                    blueButton.BackColor = Color.RoyalBlue;
                    Refresh();
                    Thread.Sleep(600);
                    blueButton.BackColor = Color.DarkBlue;
                    Refresh();
                }
            }

            //Sets the guessNumber back to 0
            guessNumber = 0;
        }

        public void GameOver()
        {
            //Plays the jumpscare sound
            soundList[4].Play();

            //Changes the screen to the GameOverScreen
            Form1.ChangeScreen(this, new GameOverScreen());

           //NOTE: When the GameScreen changes to the GameOverScreen a jumpscare gif will start the moment the change from screen happens
        }

        //Now its the Player's turn to do the pattern

        private void greenButton_Click(object sender, EventArgs e) //Green Button (Same code from ComputerTurn())
        {
            if (Form1.numPattern[guessNumber] == 0)
            {
                soundList[2].Play();
                greenButton.BackColor = Color.LimeGreen;
                Refresh();
                Thread.Sleep(500);
                greenButton.BackColor = Color.ForestGreen;
                Refresh();
                guessNumber++; //Add one to the guessNumber so the game doesn't softlock
            }

            else
            {
                GameOver(); //This is if the player messes up the Pattern
            }

            if (guessNumber == Form1.numPattern.Count) //If the player choses the right color pattern and reaches the end of the numPattern.Count
            {
                Thread.Sleep(500); //Wait for a moment
                guessNumber = 0; //Reset the guessNumber
                ComputerTurn(); //Now its the Computer's Turn
            }
        }

        private void redButton_Click(object sender, EventArgs e) //Red Button (Same code from ComputerTurn())
        {
            if (Form1.numPattern[guessNumber] == 1)
            {
                soundList[0].Play();
                redButton.BackColor = Color.Firebrick;
                Refresh();
                Thread.Sleep(500);
                redButton.BackColor = Color.DarkRed;
                Refresh();
                guessNumber++;
            }
            else
            {
                GameOver();
            }

            if (guessNumber == Form1.numPattern.Count)
            {
                Thread.Sleep(500);
                guessNumber = 0;
                ComputerTurn();
            }
        }

        private void yellowButton_Click(object sender, EventArgs e) //Yellow Button (Same code from ComputerTurn())
        {
            if (Form1.numPattern[guessNumber] == 2)
            {
                soundList[1].Play();
                yellowButton.BackColor = Color.Yellow;
                Refresh();
                Thread.Sleep(500);
                yellowButton.BackColor = Color.Goldenrod;
                Refresh();
                guessNumber++;
            }
            else
            {
                GameOver();
            }

            if (guessNumber == Form1.numPattern.Count)
            {
                Thread.Sleep(500);
                guessNumber = 0;
                ComputerTurn();
            }
        }

        private void blueButton_Click(object sender, EventArgs e) //Blue Button (Same code from ComputerTurn())
        {
            if (Form1.numPattern[guessNumber] == 3)
            {
                soundList[3].Play();
                blueButton.BackColor = Color.RoyalBlue;
                Refresh();
                Thread.Sleep(500);
                blueButton.BackColor = Color.DarkBlue;
                Refresh();
                guessNumber++;
            }
            else
            {
                GameOver();
            }

            if (guessNumber == Form1.numPattern.Count)
            {
                Thread.Sleep(500);
                guessNumber = 0;
                ComputerTurn();
            }
        }
    }
}
