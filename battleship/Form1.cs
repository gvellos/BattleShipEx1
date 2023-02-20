using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace battleship
{
    public partial class Form1 : Form
    {
        string nameb;
        string name;
        string gameResult;
        int aeroplanoforo = 5;
        int antitorpiliko = 4;
        int polemiko = 3;
        int ypovrixio = 2;

        int aeroplanoforoBot = 5;
        int antitorpilikoBot = 4;
        int polemikoBot = 3;
        int ypovrixioBot = 2;

        String nameUser;
        int winUser;
        int winBot;
        int timesUntilWin = 0;

        Statistics stats = new Statistics();     
        List<Statistics> playersList = new List<Statistics>();
       // private CountdownTimer timerRemaining;

        int[,] userArray = new int[10, 10];
        int[,] botArray = new int[10, 10];
        List<PictureBox> pictureBoxes = new List<PictureBox>();
        List<PictureBox> pictureBoxesUser = new List<PictureBox>();
        List<string> randCordinates = new List<string>();
        List<string> userShips = new List<string>();
        List<string> botShips = new List<string>();


        public Form1()
        {
            InitializeComponent();
           // timerRemaining = new CountdownTimer(label3);
        }

        public Form1(String name)
        {
            InitializeComponent();
            nameUser = name;
           // timerRemaining = new CountdownTimer(label3);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer2min.Enabled = true;
            Random random = new Random();

           
            userShips.Add("Aeroplanoforo");
            userShips.Add("Antitorpiliko");
            userShips.Add("Polemiko");
            userShips.Add("Ypovrixio");

            botShips.Add("Aeroplanoforo");
            botShips.Add("Antitorpiliko");
            botShips.Add("Polemiko");
            botShips.Add("Ypovrixio");

            int locx = 100;
            int locy = 100;
            int locbx = 500;
            int locby = 100;

            
            
            for (int i = 0; i < 10; i++)
            {
                for (int y = 0; y < 10; y++)
                {
                    userArray[i, y] = 0;
                    botArray[i, y] = 0;
                }
            }

            insertShip(userArray, userShips, random);
            insertShip(botArray, botShips, random);

            for (int i = 0; i < 10; i++)
            {
                for (int y = 0; y < 10; y++)
                {
                    name = $"{i},{y}";
                    PictureBox picturebox1 = new PictureBox();
                    picturebox1.Name = $"{name}";
                    picturebox1.Location = new Point(locx, locy);
                    picturebox1.Size = new Size(25, 25);
                    picturebox1.BackColor = Color.Black;
                    picturebox1.ForeColor = Color.GhostWhite;
                    Controls.Add(picturebox1);
                    randCordinates.Add(name);
                    pictureBoxesUser.Add(picturebox1);
                    locx = locx + 30;
                    if (userArray[i, y] != 0)
                    {
                        picturebox1.BackColor = Color.Gray;
                    } 
                }
                locy = locy + 30;
                locx = locx - 300;
            }

            var result = randCordinates.OrderBy(item => random.Next()).ToList();
            for(int i = 0; i < result.Count; i++)
            {
                randCordinates[i] = result[i];
            }

            for (int i = 0; i < 10; i++)
            {
                for (int y = 0; y < 10; y++)
                {
                    nameb = $"{i},{y}";                    
                    PictureBox picturebox1 = new PictureBox();
                    picturebox1.Name = $"{nameb}";
                    picturebox1.Location = new Point(locbx, locby);
                    picturebox1.Size = new Size(25, 25);
                    picturebox1.BackColor = Color.Black;
                    picturebox1.ForeColor = Color.GhostWhite;
                    picturebox1.MouseDown += Picturebox1_MouseDown;
                    pictureBoxes.Add(picturebox1);
                    Controls.Add(picturebox1);
                    locbx = locbx + 30;
                }
                locby = locby + 30;
                locbx = locbx - 300;
            }
        }
        void Picturebox1_MouseDown(object sender, EventArgs e)
        {
            timesUntilWin += 1;
            if (sender is PictureBox)
            {
                string name  = ((PictureBox)sender).Name;
                string[] result = name.Split(',');
                int x = Int32.Parse(result[0]);
                int y = Int32.Parse(result[1]);
                foreach(PictureBox picturebox in pictureBoxes)
                {
                    if(picturebox.Name == name)
                    {
                        if (botArray[x,y] == 5)
                        {
                            picturebox.BackColor = Color.Green;
                            aeroplanoforo -= 1;
                            if (aeroplanoforo == 0)
                            {
                                label2.Text = "Βυθίστηκε το Αεροπλανοφόρο του υπολογιστή";
                                botShips.Remove("Aeroplanoforo");
                            }
                        }
                        else if (botArray[x, y] == 4)
                        {
                            picturebox.BackColor = Color.Green;
                            antitorpiliko -= 1;
                            if (antitorpiliko == 0)
                            {
                                label2.Text = "Βυθίστηκε το Αντιτορπιλικό του υπολογιστή";
                                botShips.Remove("Antitorpiliko");
                            }
                        }
                        else if (botArray[x, y] == 3)
                        {
                            picturebox.BackColor = Color.Green;
                            polemiko -= 1;
                            if (polemiko == 0)
                            {
                                label2.Text = "Βυθίστηκε το Πολεμικό του υπολογιστή";
                                botShips.Remove("Polemiko");
                            }
                        }
                        else if (botArray[x, y] == 2)
                        {
                            picturebox.BackColor = Color.Green;
                            ypovrixio -= 1;
                            if (ypovrixio == 0)
                            {
                                label2.Text = "Βυθίστηκε το Υποβρήχιο του υπολογιστή";
                                botShips.Remove("Ypovrixio");
                            }
                        }
                        else
                        {
                            picturebox.BackColor = Color.Red;
                        }

                        string resultBotForUser = randCordinates[0];
                        string[] resultBotCordinates = resultBotForUser.Split(',');
                        int xBot = Int32.Parse(resultBotCordinates[0]);
                        int yBot = Int32.Parse(resultBotCordinates[1]);
                        randCordinates.RemoveAt(0);

                      
                        PictureBox tempPictureBox = pictureBoxesUser[xBot * 10 + yBot];
                        if (userArray[xBot, yBot] == 5)
                        {
                            tempPictureBox.BackColor = Color.Green;
                            aeroplanoforoBot -= 1;
                            if (aeroplanoforoBot == 0)
                            {
                                label1.Text = "Βυθίστηκε το Αεροπλανοφόρο μου";
                                userShips.Remove("Aeroplanoforo");

                            }
                        }
                        else if (userArray[xBot, yBot] == 4)
                        {
                            tempPictureBox.BackColor = Color.Green;
                            antitorpilikoBot -= 1;
                            if (antitorpilikoBot == 0)
                            {
                                label1.Text = "Βυθίστηκε το Αντιτορπιλικό μου";
                                userShips.Remove("Antitorpiliko");
                            }
                        }
                        else if (userArray[xBot, yBot] == 3)
                        {
                            tempPictureBox.BackColor = Color.Green;
                            polemikoBot -= 1;
                            if (polemikoBot == 0)
                            {
                                label1.Text = "Βυθίστηκε το Πολεμικό μου";
                                userShips.Remove("Polemiko");
                            }
                        }
                        else if (userArray[xBot, yBot] == 2)
                        {
                            tempPictureBox.BackColor = Color.Green;
                            ypovrixioBot -= 1;
                            if (ypovrixioBot == 0)
                            {
                                label1.Text = "Βυθίστηκε το Υποβρήχιο μου";
                                userShips.Remove("Ypovrixio");
                            }
                        }
                        else
                        {
                            tempPictureBox.BackColor = Color.Red;
                        }
                    }
                }
                
                if (userShips.Count == 0)
                {
                    gameResult = "The winner is the Bot";
                    winBot = 1;
                    winUser = 0;
                    stats.WinBot += winBot;
                    stats.WinUser += winUser;
                    stats.TimesUntiliWin = timesUntilWin;
                    playersList.Add(stats);

                    ser();
                    Terminal terminal = new Terminal(gameResult, stats, timeRemaining, nameUser);
                    this.Close();
                    terminal.Show();
                    terminal.StartPosition = FormStartPosition.Manual;
                    terminal.Location = this.Location;
                    terminal.Size = this.Size;
                    timer2min.Enabled = false;

                }
                if (botShips.Count == 0)
                {
                    gameResult = "The winner is the User";
                    winBot = 0;
                    winUser = 1;
                    stats.TimesUntiliWin = timesUntilWin;
                    stats.WinBot += winBot;
                    stats.WinUser += winUser;
                    playersList.Add(stats);
                    ser();

                    Terminal terminal = new Terminal(gameResult, stats,timeRemaining, nameUser);
                    this.Close();
                    terminal.Show();
                    terminal.StartPosition = FormStartPosition.Manual;
                    terminal.Location = this.Location;
                    terminal.Size = this.Size;
                    timer2min.Enabled = false;

                }
            }
           
        }

        public void ser()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("stats.ser", FileMode.OpenOrCreate, FileAccess.Write); 
            formatter.Serialize(stream, playersList);
            stream.Close();
        }

        public void insertShip(int[,] shipArray , List<string> shipNames, Random random)
        {
           
            int tempxy = random.Next(0, 2);
            int tempx = random.Next(0, 6); //orizontia
            int tempy = random.Next(0, 6); // katheta
            if (shipNames[0] == "Aeroplanoforo")
            {
                if (tempxy == 0) // θα ειναι καθετα τα πλοια
                {
                    shipArray[tempx, tempy] = 5;
                    shipArray[tempx + 1, tempy] = 5;
                    shipArray[tempx + 2, tempy] = 5;
                    shipArray[tempx + 3, tempy] = 5;
                    shipArray[tempx + 4, tempy] = 5;
                }
                else
                {
                    shipArray[tempx, tempy] = 5;
                    shipArray[tempx, tempy + 1] = 5;
                    shipArray[tempx, tempy + 2] = 5;
                    shipArray[tempx, tempy + 3] = 5;
                    shipArray[tempx, tempy + 4] = 5;
                }
            }

            if (shipNames[1] == "Antitorpiliko")
            {
                tempx = random.Next(0, 7); // orizontia
                tempy = random.Next(0, 7);
                tempxy = random.Next(0, 2);
                if (tempxy == 0) // το πλοιο θα ειναι καθετα
                {
                    while (shipArray[tempx, tempy] == 5 || shipArray[tempx + 1, tempy] == 5 || shipArray[tempx + 2, tempy] == 5 || shipArray[tempx + 3, tempy] == 5)
                    {
                        tempx = random.Next(0, 7); // orizontia
                    }
                    shipArray[tempx, tempy] = 4;
                    shipArray[tempx + 1, tempy] = 4;
                    shipArray[tempx + 2, tempy] = 4;
                    shipArray[tempx + 3, tempy] = 4;
                }
                else
                {
                    while (shipArray[tempx, tempy] == 5 || shipArray[tempx, tempy + 1] == 5 || shipArray[tempx, tempy + 2] == 5 || shipArray[tempx, tempy + 3] == 5)
                    {
                        tempy = random.Next(0, 7);
                    }
                    shipArray[tempx, tempy] = 4;
                    shipArray[tempx, tempy + 1] = 4;
                    shipArray[tempx, tempy + 2] = 4;
                    shipArray[tempx, tempy + 3] = 4;
                }
            }

            if (shipNames[2] == "Polemiko")
            {
                tempx = random.Next(0, 8);
                tempy = random.Next(0, 8);
                tempxy = random.Next(0, 2);
                if (tempxy == 0)// το πλοιο θα ειναι καθετα
                {
                    while (shipArray[tempx, tempy] == 5 || shipArray[tempx + 1, tempy] == 5 || shipArray[tempx + 2, tempy] == 5 || shipArray[tempx, tempy] == 4 || shipArray[tempx + 1, tempy] == 4 || shipArray[tempx + 2, tempy] == 4)
                    {
                        tempx = random.Next(0, 8); // orizontia
                    }
                    shipArray[tempx, tempy] = 3;
                    shipArray[tempx + 1, tempy] = 3;
                    shipArray[tempx + 2, tempy] = 3;
                }
                else // το πλοιο θα ειναι orizontia
                {
                    while (shipArray[tempx, tempy] == 5 || shipArray[tempx, tempy + 1] == 5 || shipArray[tempx, tempy + 2] == 5 || shipArray[tempx, tempy] == 4 || shipArray[tempx, tempy + 1] == 4 || shipArray[tempx, tempy + 2] == 4)
                    {
                        tempy = random.Next(0, 8);
                    }
                    shipArray[tempx, tempy] = 3;
                    shipArray[tempx, tempy + 1] = 3;
                    shipArray[tempx, tempy + 2] = 3;
                }
            }

            if (shipNames[3] == "Ypovrixio")
            {
                tempx = random.Next(0, 9);
                tempy = random.Next(0, 9);
                tempxy = random.Next(0, 2);
                if (tempxy == 0)// το πλοιο θα ειναι καθετα
                {
                    while (shipArray[tempx, tempy] == 5 || shipArray[tempx + 1, tempy] == 5 || shipArray[tempx, tempy] == 4 || shipArray[tempx + 1, tempy] == 4 || shipArray[tempx, tempy] == 3 || shipArray[tempx + 1, tempy] == 3)
                    {
                        tempx = random.Next(0, 9); // orizontia
                    }
                    shipArray[tempx, tempy] = 2;
                    shipArray[tempx + 1, tempy] = 2;
                }
                else // το πλοιο θα ειναι orizontia
                {
                    while (shipArray[tempx, tempy] == 5 || shipArray[tempx, tempy + 1] == 5 || shipArray[tempx, tempy] == 4 || shipArray[tempx, tempy + 1] == 4 || shipArray[tempx, tempy] == 3 || shipArray[tempx, tempy + 1] == 3)
                    {
                        tempy = random.Next(0, 9);
                    }
                    shipArray[tempx, tempy] = 2;
                    shipArray[tempx, tempy + 1] = 2;
                }
            }
        }

        int timeRemaining = 120000;
        private void timer2min_Tick(object sender, EventArgs e)
        {
            timeRemaining--;
            if (timeRemaining >= 0)
            {
                int minutes = timeRemaining / 60;
                int seconds = timeRemaining % 60;
                label3.Text = string.Format("{0:00}:{1:00}", minutes, seconds); 
            }

            gameResult = "Time is over";
            winBot = 0;
            winUser = 0;

            stats.WinBot += winBot;
            stats.WinUser += winUser;
            playersList.Add(stats);
            ser();


            Terminal terminal = new Terminal(gameResult, stats, timeRemaining, nameUser);
            this.Close();
            terminal.Show();
            terminal.StartPosition = FormStartPosition.Manual;
            terminal.Location = this.Location;
            terminal.Size = this.Size;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }
    }
}
