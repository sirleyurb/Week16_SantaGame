using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SantaGame
{
    public partial class Form1 : Form
    {
        int gravity = 10;
        int santaSpeed = 6;
        int score = 0;   

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            santa.Top += gravity;
            sun.Left -= santaSpeed;
            house.Left -= santaSpeed;
            tree.Left -= santaSpeed;
            snowflake.Left -= santaSpeed;
            scoreLabel.Text = $"score:{score}";


            if (sun.Left < -100)
            {
                sun.Left = 500;
                score++;
            }

            if (house.Left < -100)
            {
                house.Left = 500;
                score++;
            }

            if (tree.Left < -100)
            {
                tree.Left = 500;
                score++;
            }

            if (snowflake.Left < -100)
            {
                snowflake.Left = 500;
                score++;
            }

            if (santa.Top < -25)
            {
                gameOver();
            }

            if (santa.Bounds.IntersectsWith(sun.Bounds) || santa.Bounds.IntersectsWith(house.Bounds) || santa.Bounds.IntersectsWith(tree.Bounds) || santa.Bounds.IntersectsWith(snowflake.Bounds))
            {
                gameOver();
            }    


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -5;    
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = 5;   
            }
        }
        private void gameOver()
        {
            timer1.Stop();
            scoreLabel.Text = $"Game over!";
            button1.Visible = true;            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 NewForm = new Form1();
            NewForm.Show();
            this.Dispose(false);    
        }
    }
}
