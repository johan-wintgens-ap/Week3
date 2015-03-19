using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.IO;

namespace SQLlite
{
    public partial class MainWindow : Window
    {
        
        private SQLiteConnection mDbconnection;

        
        public MainWindow()
        {
            InitializeComponent();
            
            SQLiteConnection.CreateFile("MyDatabase.sqlite");
            mDbconnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");

            mDbconnection.Open();

            string sql = "create table highscores (name varchar(20), score int)";

            SQLiteCommand command = new SQLiteCommand(sql, mDbconnection);
            command.ExecuteNonQuery();

            sql = "select * from highscores order by score desc";
            command = new SQLiteCommand(sql, mDbconnection);
            SQLiteDataReader reader = command.ExecuteReader();

            mDbconnection.Close();
        }     
    }
}
