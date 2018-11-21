using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGameRee
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
        }

        PictureBox gazo1;
        byte b;
        byte matching = 8;
        byte time = 60;

       void Ichi()
        {
            foreach (Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    (x as PictureBox).Image = Properties.Resources._0;
                }
            }
        }

        void ni()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    (x as PictureBox).Tag= "0";
                }
            }
        }

        void san()
        {
            int[] a = new int[16];
            Random r = new Random();


            byte i = 0;
            while(i<16)
            {
                int v = r.Next(1, 17);
                if(Array.IndexOf(a,v) == -1)
                {
                    a[i] = v;
                    i++;
                }
            }

            for (byte y=0;y<16;y++)
            {
                if (a[y] > 8) a[y] -= 8;
            }
            byte t =0;
            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    x.Tag = a[t].ToString();
                    t++;
                }
            }
        }


        void yon(PictureBox one, PictureBox two)     //disappear if same else q pic appear
        {
            if(one.Tag.ToString() == two.Tag.ToString())
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);
                one.Visible = false;
                two.Visible = false;
                matching--;
                movesleft.Text ="" +matching;

            }
            else
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);
                one.Image = Image.FromFile("0.jpg");
                two.Image = Image.FromFile("0.jpg");
            }
        }
        private void Game_Load(object sender, EventArgs e)       //initialisation of methods 
        {
            Ichi();
             ni();
            san();


        }

        private void picture_Box1_Click(object sender, EventArgs e)
        {
            PictureBox hana1 = (sender as PictureBox);
            (sender as PictureBox).Image = Image.FromFile((sender as PictureBox).Tag.ToString() + ".jpg"); 
            if(b == 0)
            {
                gazo1 = hana1;

                b++;

            }

            else
            {
                if(gazo1 == hana1)
                {
                    MessageBox.Show("Not Allowed!");
                    b = 0;
                    gazo1.Image = Image.FromFile("0.jpg");
                }
                else
                {
                    yon(gazo1,hana1);
                    b = 0;
                }
            }
        }

       
        void Showall()
        {
            foreach(Control x in this.Controls)
                if(x is PictureBox)
                {
                    (x as PictureBox).Image = Image.FromFile(x.Tag.ToString() + ".jpg");

                }
        }



        void backfromshowall()
        {
            foreach(Control x in this.Controls)
                {
                if(x is PictureBox)
                {
                    (x as PictureBox).Image = Image.FromFile("0.jpg");


                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Showall();
            Application.DoEvents();
            System.Threading.Thread.Sleep(500);
            backfromshowall();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        void newgamevisibility()                             //toget back the matched and gone ones
        {
            foreach(Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    (x as PictureBox).Visible = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            Ichi();
            ni();
            san();
            newgamevisibility();
            matching = 8;
            b = 0;
            time = 60;
            time60.Text = "" + time;
            time -= 1;
           // timer1.Tick += new  EventHandler(timer1_Tick);




        }
        void timeup()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    (x as PictureBox).Enabled = false;
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            time -= 1;
            time60.Text = "" + time;
            if(time == 0)
            {
                this.Enabled = false;
                timeup();
                
                time60.Text = "Times up!";
                
               


            }

        }

        private void button2_Click(object sender, EventArgs e) //start button 2
        {
            if (timer1.Enabled)
            {
                return;
            }

            time = 60;
            time60.Text = "" + time;
            timer1.Start();
            button1.Enabled = true;
            button3.Enabled = true;

        }

        private void time60_Click(object sender, EventArgs e)
        {

        }
    }
}
 //button3 new game
 //button1 showall