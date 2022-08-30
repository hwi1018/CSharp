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
using BeeCompany;

namespace HeadFirst
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {

        Queen queen;
        Worker[] workers;
        public MainWindow()
        {
            InitializeComponent();

            workers = new Worker[4];

            workers[0] = new Worker(new string[] { "Nectar Collector", "Honey Manufacturing" }, 175);
            workers[1] = new Worker(new string[] { "Egg Care", "Baby Bee Tutoring" }, 114);
            workers[2] = new Worker(new string[] { "Hive Maintenance", "Sting Patrol" }, 149);
            workers[3] = new Worker(new string[] { "Nectar Collector", "Honey Manufacturing",
            "Egg Care", "Baby Bee Tutoring", "Hive Maintenance"}, 155);

            queen = new Queen(workers);
           
        }

        private void BtnAssign_Click(object sender, RoutedEventArgs e)
        {
            if (queen.AssignWork(cmbWorks.Text, int.Parse(numericUpDown.ShiftValue)))
            {
                MessageBox.Show("No Workers are available to do the job " + cmbWorks.Text,
                    "The Queen Bee Says");
            }
            else
            {
                MessageBox.Show(
                    "The Job " + cmbWorks.SelectedItem.ToString() + " will be done in " + numericUpDown.ShiftValue + "shift",
                    "The Queen Bee Says");
            }
        }
        
        private void BtnWorkShift_Click(object sender, RoutedEventArgs e)
        {
            txtWorkLog.Text = queen.WorkTheNextShift();
        }
    }
}
