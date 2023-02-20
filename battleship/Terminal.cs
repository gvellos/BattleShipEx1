using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Runtime.InteropServices.ComTypes;
using static System.Net.WebRequestMethods;
using File = System.IO.File;
using System.Data.SQLite;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace battleship
{
    public partial class Terminal : Form
    {
        int tempUser = 0;
        int tempBot = 0;
        String name ;
        int timeRemaining;
        String winner;

        String connectionString = "Data source=csharp2022_2.db;Version=3";
        SQLiteConnection connection;

        Statistics statistics = new Statistics();

        public Terminal()
        {
            InitializeComponent();
        }

        public Terminal(string gameResult, Statistics statistics, int timeRemaining, String name)
        {
            InitializeComponent();          
            this.statistics = statistics;
            this.timeRemaining = timeRemaining;
            this.name = name;
            winner = gameResult;
            labelResult.Text = gameResult;
            labelTimeNeed.Text = timeRemaining.ToString();
            labelTimesUntilWin.Text = statistics.TimesUntiliWin.ToString();
        }


        private void buttonPlayAgain_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Close();
            form1.Show();
            form1.StartPosition = FormStartPosition.Manual;
            form1.Location = this.Location;
            form1.Size = this.Size;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            String myfile = @"stats.ser";
            File.Delete(myfile);
            System.Windows.Forms.Application.Exit();
        }

        private void Terminal_Load(object sender, EventArgs e)
        {
            createTable();

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("stats.ser", FileMode.Open, FileAccess.Read);
            List<Statistics> playersList = (List<Statistics>)formatter.Deserialize(stream);
   
            foreach (Statistics stat in playersList)
            {
                tempUser += stat.WinUser;
                tempBot += stat.WinBot;

            }
            labelWinsUser.Text = "User wins: " + tempUser.ToString();
            labelWinsBot.Text = "Bot wins" + tempBot.ToString();

            stream.Close();
            IFormatter formatter1 = new BinaryFormatter();
            Stream stream1 = new FileStream("stats.ser", FileMode.Open, FileAccess.Write);
            formatter1.Serialize(stream1, playersList);
            stream1.Close();


        }

        private void buttonShowStats_Click(object sender, EventArgs e)
        {
            connection.Open();
            String insertSQL = "Insert into BattleShips(Name,Winner,Time) values(@name,@winner,@time)";
            SQLiteCommand command = new SQLiteCommand(insertSQL, connection);
            command.Parameters.AddWithValue("name", name);
            command.Parameters.AddWithValue("winner", winner);
            command.Parameters.AddWithValue("time", timeRemaining);
            command.ExecuteNonQuery();
            connection.Close();
            show();
        }
        public void show()
        {
            richTextBox1.Clear();
            connection.Open();
            String selectSQL = "Select * from BattleShips";
            SQLiteCommand command = new SQLiteCommand(selectSQL, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                richTextBox1.AppendText(reader.GetString(1));
                richTextBox1.AppendText(",");
                richTextBox1.AppendText(reader.GetString(2));
                richTextBox1.AppendText(",");
                richTextBox1.AppendText(reader.GetInt32(3).ToString());
                richTextBox1.AppendText(Environment.NewLine);
            }
            connection.Close();
        }

        public void createTable()
        {
            connection = new SQLiteConnection(connectionString);
            connection.Open();
            String createSQL = "Create table if not exists BattleShips(BattleShip integer primary key autoincrement," +
                "Name Text,Winner Text,Time Int)";
            SQLiteCommand command = new SQLiteCommand(createSQL, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
