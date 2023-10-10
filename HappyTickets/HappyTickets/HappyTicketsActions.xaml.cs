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
using System.Windows.Shapes;

namespace HappyTickets
{
    public partial class HappyTicketsActions : Window
    {
        public HappyTicketsActions()
        {
            InitializeComponent();

            //Загрузка ComboBox
            foreach (var partion in ResourceManager.Partions)
            {
                NumberPartionsCombo.Items.Add(partion.partionNumber).ToString();
            }
        }

        //Сварачивание окна
        private void Button_minimized(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //Закрытие окна
        private void Button_close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Перемещение окна
        private void WrapPanel_mouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        //Кнопка назад
        private void Click_Back(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        //ComboBox партий
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextComboBox.Text = NumberPartionsCombo.SelectedItem.ToString();
            PartionComboBox.Text = "№ партии";

            TextComboBoxTickets.Text = "Билеты";
            TicketsComboBox.Text = null;
            NumberTicketsCombo.SelectedItem = null;

            int combo = (int)NumberPartionsCombo.SelectedItem;

            Partion? partion = ResourceManager.GetPartionByNumber(combo);
            if (partion == null) return;

            NumberTicketsCombo.Items.Clear();

            for (int i = 0; i < partion.tickets.Count; i++)
            {
                var happy = HelperTickets.IsHappyTicket(partion.tickets[i]);

                if (happy)
                {
                    NumberTicketsCombo.Items.Add(partion.tickets[i]).ToString();
                }
            }
        }

        //Короткий и длинный промежуток между счастливыми билетами
        private void Button_ShortLong(object sender, RoutedEventArgs e)
        {
            List<int> distanceHistory = new List<int>();
            distanceHistory.Add(0);
            int countHappy = 0;


            if (NumberPartionsCombo.SelectedItem != null)
            {
                int combo = (int)NumberPartionsCombo.SelectedItem;

                Partion? partion = ResourceManager.GetPartionByNumber(combo);
                if (partion == null) return;

                var tickets = partion.tickets;

                for (int j = 0; j < tickets.Count; j++)
                {
                    if (HelperTickets.IsHappyTicket(tickets[j]))
                    {
                        countHappy++;
                        distanceHistory.Add(-1);
                    }
                    distanceHistory[distanceHistory.Count - 1]++;
                }

                if (distanceHistory.Count > 0 && countHappy != 1 && countHappy != 0)
                {
                    distanceHistory.RemoveAt(distanceHistory.Count - 1);
                    distanceHistory.RemoveAt(0);

                    int minDistance = distanceHistory.Min();
                    int maxDistance = distanceHistory.Max();

                    Short.Text = minDistance.ToString();
                    Long.Text = maxDistance.ToString();
                }
                else
                {
                    Short.Text = "0";
                    Long.Text = "0";
                }
            }

        }


        //Количество палиндромов
        private void Click_Palindrome(object sender, RoutedEventArgs e)
        {
            if (NumberPartionsCombo.SelectedItem != null && NumberTicketsCombo.SelectedItem == null)
            {
                int countPalindrome = 0;

                int combo = (int)NumberPartionsCombo.SelectedItem;

                Partion? partion = ResourceManager.GetPartionByNumber(combo);
                if (partion == null) return;

               
                var tickets = partion.tickets;

                for (int i = 0; i < tickets.Count; i++)
                {
                    var happy = HelperTickets.IsHappyTicket(tickets[i]);

                    if (happy)
                    { 
                            int aBlock = tickets[i] / 1000 % 10;
                            int bBlock = tickets[i] / 100 % 10;
                            int cBlock = tickets[i] / 10 % 10;
                            int dBlock = tickets[i] / 1 % 10;
                            if (aBlock == dBlock && bBlock == cBlock)
                            {
                                countPalindrome++;
                                Palindrome.Text = "Количество палиндромов: " + countPalindrome;
                            }
                            else
                            {
                                Palindrome.Text = "Количество палиндромов: " + countPalindrome;
                            }
                    }
                }

               
            }
            else if(NumberPartionsCombo.SelectedItem != null && NumberTicketsCombo != null)
            {
                int comboPartion = (int)NumberPartionsCombo.SelectedItem;
                int comboTickets = (int)NumberTicketsCombo.SelectedItem;

                Partion? partion = ResourceManager.GetPartionByNumber(comboPartion);
                if (partion == null) return;

                var tickets = partion.tickets;

                for (int j = 0; j < tickets.Count; j++)
                {
                    var happy = HelperTickets.IsHappyTicket(tickets[j]);

                    if (happy)
                    {
                        int aBlock = comboTickets / 1000 % 10;
                        int bBlock = comboTickets / 100 % 10;
                        int cBlock = comboTickets / 10 % 10;
                        int dBlock = comboTickets / 1 % 10;
                        if (aBlock == dBlock && bBlock == cBlock)
                        {
                            Palindrome.Text = "Этот билет является палиндромом";
                        }
                        else
                        {
                            Palindrome.Text = "Этот билет не является палиндромом";
                        }
                    }
                }
            }
        }

        //ComboBox билетов
        private void ComboBox_SelectionChangedTickets(object sender, SelectionChangedEventArgs e)
        {
            if (NumberTicketsCombo.SelectedItem == null) return;
            TextComboBoxTickets.Text = NumberTicketsCombo.SelectedItem.ToString();
            TicketsComboBox.Text = "№ билета";
        }
    }
}
