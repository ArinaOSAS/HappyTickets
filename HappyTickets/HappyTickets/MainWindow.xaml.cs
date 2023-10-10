using System;
using System.Collections.Generic;
using System.IO;
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

namespace HappyTickets
{

    //База данных
    public class Partion
    {
        public Partion(DateOnly date, int partionNumber)
        {
            this.date = date;
            this.partionNumber = partionNumber;
        }
        public Partion() { }

        public DateOnly date { get; set; }
        public List<int> tickets { get; set; } = new List<int>();
        public int partionNumber { get; set; }
    }


    //Загрузка данных из файла
    public static class LoaderPartion
    {
        public static List<Partion> Load(string path)
        {
            string fileTickets = File.ReadAllText(path);
            string[] ArrayTickets = fileTickets.Split().Where(c => c != "" && c != " ").ToArray();
            List<Partion> partions = new List<Partion>();
            for (int i = 0; i < ArrayTickets.Length; i++)
            {
                if (ArrayTickets[i].Contains("."))
                {
                    var splited = ArrayTickets[i].Split('.');
                    int day = int.Parse(splited[0]);
                    int month = int.Parse(splited[1]);
                    int year = int.Parse(splited[2]);
                    DateOnly date = new DateOnly(year, month, day);
                    i++;
                    int partionNumber = int.Parse(ArrayTickets[i]);
                    partions.Add(new Partion(date, partionNumber));
                    i++;
                }
                int ticketNumder = int.Parse(ArrayTickets[i]);
                partions.Last().tickets.Add(ticketNumder);
            }
            return partions;
        }
    }



    public partial class MainWindow : Window
    {
        public MainWindow()
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


        //Количество счастливых билетов
        private void SetCountHappy()
        {
            int quantityHappy = 0;

            if (NumberPartionsCombo.SelectedItem != null)
            {
                int combo = (int)NumberPartionsCombo.SelectedItem;

                Partion? partion = ResourceManager.GetPartionByNumber(combo);
                if (partion == null) return;

                var tickets = partion.tickets;

                for (int j = 0; j < tickets.Count; j++)
                {
                    var happy = HelperTickets.IsHappyTicket(tickets[j]);

                    if (happy)
                    {
                        quantityHappy++;
                    }
                }
            }
            quantityHappytickets.Text = quantityHappy.ToString();
        }


        List<int> LastHappy = new List<int>();

        //Перечисление счастливых билетов
        private void Button_SearhHappyTicket(object sender, RoutedEventArgs e)
        {
            int one = 0;
            int ticket2 = 0;
            int ticket3 = 0;
            int ticket4 = 0;
            SetCountHappy();

            if (NumberPartionsCombo.SelectedItem != null)
            {
                int combo = (int)NumberPartionsCombo.SelectedItem;

                Partion? partion = ResourceManager.GetPartionByNumber(combo);
                if (partion == null) return;

                var tickets = partion.tickets;

                for (int j = 0; j < tickets.Count; j++)
                {
                   bool happy = HelperTickets.IsHappyTicket(tickets[j]);

                    if (happy && !LastHappy.Contains(tickets[j]))
                    {
                        one = tickets[j] / 1000 % 10;
                        ticket2 = tickets[j] / 100 % 10;
                        ticket3 = tickets[j] / 10 % 10;
                        ticket4 = tickets[j] / 1 % 10;
                        if (one == 0)
                        {
                            if(ticket2 == 0 && ticket3 == 0 && ticket4 == 0)
                            {
                                NumberHappy1.Text = "0000";
                                NumberHappy2.Text = "0000";
                            }
                            else
                            {
                                NumberHappy1.Text = "0" + tickets[j];
                                NumberHappy2.Text = "0" + tickets[j];
                            }

                        }
                        else
                        {
                            NumberHappy1.Text = tickets[j].ToString();
                            NumberHappy2.Text = tickets[j].ToString();
                        }

                        LastHappy.Add(tickets[j]);

                        return;
                    }
                    else if(!happy)
                    {
                        continue;
                    }
                    if (j == tickets.Count - 1)
                    {
                        LastHappy.Clear();
                        j = 0;
                    }
                }


            }
        }


        //Количество простых билетов
        private void Button_SearhimpleTickets(object sender, RoutedEventArgs e)
        {
            int NumberSimple = 0;

            if (NumberPartionsCombo.SelectedItem != null)
            {
                int combo = (int)NumberPartionsCombo.SelectedItem;


                Partion? partion = ResourceManager.GetPartionByNumber(combo);
                if (partion == null) return;

                var tickets = partion.tickets;

                for (int j = 0; j < tickets.Count; j++)
                {
                    int leftBlock = tickets[j] / 1000 % 10 + tickets[j] / 100 % 10;
                    int rightBlock = tickets[j] / 10 % 10 + tickets[j] / 1 % 10;
                    if (leftBlock != rightBlock)
                    {
                        NumberSimple++;
                        quantitytickets.Text = NumberSimple.ToString();
                    }
                }
            }
        }

        //ComboBox партий
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextComboBox.Text = NumberPartionsCombo.SelectedItem.ToString();
            PartionComboBox.Text = "№ партии";
        }

        //Назад
        private void Button_Graph(object sender, RoutedEventArgs e)
        {
            DensityGraph densityGraph = new DensityGraph();
            densityGraph.Show();
            this.Close();
        }

        //Переход на окно действия с счастливыми билетами
        private void Button_HappyTickets(object sender, RoutedEventArgs e)
        {
            HappyTicketsActions happyTicketsActions = new HappyTicketsActions();
            happyTicketsActions.Show();
            this.Close();
        }

        //Переход на окно действия совсеми билетами
        private void Button_SimpleTickets(object sender, RoutedEventArgs e)
        {
            SimpleTickets simpleTickets = new SimpleTickets();
            simpleTickets.Show();
            this.Close();
        }
    }
    
}

