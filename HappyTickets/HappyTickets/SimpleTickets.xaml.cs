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

    public partial class SimpleTickets : Window
    {
        public SimpleTickets()
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

        //Кнопка функции делится ли половина на другую половину
        private void Click_DivisionInteger(object sender, RoutedEventArgs e)
        { 
            bool divided = false;

            if (NumberPartionsCombo.SelectedItem != null && NumberTicketsCombo.SelectedItem == null)
            {
                int combo = (int)NumberPartionsCombo.SelectedItem;

                Partion? partion = ResourceManager.GetPartionByNumber(combo);
                if (partion == null) return;

                var tickets = partion.tickets;

                for (int j = 0; j < tickets.Count; j++)
                {
                    int leftBlock = tickets[j] / 100 % 100;
                    int rightBlock = tickets[j] / 1 % 100;
                    if (leftBlock == 0 && rightBlock == 0)
                    {
                        divided = true;
                    }
                    else if(rightBlock == 0 && leftBlock != 0)
                    {
                        divided = false;
                    }
                    else if (leftBlock % rightBlock == 0)
                    {

                        divided = true;
                    }
                }
                if (divided)
                {
                    DivisionInteger.Text = null;
                    DivisionInteger.Text = "Да, такие билеты есть, у которых одна половина номера делится нацело на другую";
                }
                else
                {
                    DivisionInteger.Text = null;
                    DivisionInteger.Text = "Нет, таких билетов нет, у которых одна половина номера делится нацело на другую";
                }
            }  
            else if ( NumberPartionsCombo.SelectedItem != null && NumberTicketsCombo.SelectedItem != null)
            {
                int comboPartion = (int)NumberPartionsCombo.SelectedItem;
                int comboTickets = (int)NumberTicketsCombo.SelectedItem;

                Partion? partion = ResourceManager.GetPartionByNumber(comboPartion);
                if (partion == null) return;

                int leftBlock = comboPartion / 100 % 100;
                int rightBlock = comboPartion / 1 % 100;
                if (leftBlock == 0 && rightBlock == 0)
                {
                    divided = true;
                }
                else if (rightBlock == 0 && leftBlock != 0)
                {
                    divided = false;
                }
                else if (leftBlock % rightBlock == 0)
                {

                    divided = true;
                }
                
                if (divided)
                {
                    DivisionInteger.Text = null;
                    DivisionInteger.Text = "Да, у этого билета одна половина номера делится нацело на другую";
                }
                else
                {
                    DivisionInteger.Text = null;
                    DivisionInteger.Text = "Нет, у этого билета одна половина номера не делится нацело на другу";
                }
            }
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
                NumberTicketsCombo.Items.Add(partion.tickets[i]).ToString();
            }

        }

        //Кнопка назад
        private void Click_Back(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }


        //Полный квадрат и куб
        private void Button_FullCubesSquares(object sender, RoutedEventArgs e)
        {
            bool SquareCheck = false;
            bool CubeCheck = false;

            if (NumberPartionsCombo.SelectedItem != null && NumberTicketsCombo.SelectedItem == null)
            {
                int combo = (int)NumberPartionsCombo.SelectedItem;

                //Полный квадрат
                Partion? partion = ResourceManager.GetPartionByNumber(combo);
                if (partion == null) return;

                var tickets = partion.tickets;

                for (int j = 0; j < tickets.Count; j++)
                {
                    int SumNumberSquare = tickets[j] / 1000 % 10 + tickets[j] / 100 % 10 + tickets[j] / 10 % 10 + tickets[j] / 1 % 10;
                    double SquareDouble = Math.Sqrt(SumNumberSquare);
                    int SquareInt = (int)SquareDouble;

                    if (SquareDouble == SquareInt)
                    {
                        SquareCheck = true;
                    }
                }
                if (SquareCheck)
                {
                    fullSquare.Text = null;
                    fullSquare.Text = "Полный квадрат есть";
                }
                else
                {
                    fullSquare.Text = null;
                    fullSquare.Text = "Полного квадрата нет";
                }

                //Полный куб
                for (int j = 0; j < tickets.Count; j++)
                {
                    int SumNumberCube = tickets[j] / 1000 % 10 + tickets[j] / 100 % 10 + tickets[j] / 10 % 10 + tickets[j] / 1 % 10;
                    double CubeDouble = Math.Pow(SumNumberCube, 1.0 / 3.0);
                    int CubeInt = (int)CubeDouble;

                    if (CubeDouble == CubeInt)
                    {
                        CubeCheck = true;
                    }
                }
                if (CubeCheck)
                {
                    fullCube.Text = null;
                    fullCube.Text = "Полный куб есть";
                }
                else
                {
                    fullCube.Text = null;
                    fullCube.Text = "Полного куба нет";
                }
            }
            else if (NumberPartionsCombo.SelectedItem != null && NumberTicketsCombo.SelectedItem != null)
            {
                int comboPartion = (int)NumberPartionsCombo.SelectedItem;
                int comboTickets = (int)NumberTicketsCombo.SelectedItem;

                //Полный квадрат
                Partion? partion = ResourceManager.GetPartionByNumber(comboPartion);
                if (partion == null) return;

                int SumNumberSquare = comboTickets / 1000 % 10 + comboTickets / 100 % 10 + comboTickets / 10 % 10 + comboTickets / 1 % 10;
                double SquareDouble = Math.Sqrt(SumNumberSquare);
                int SquareInt = (int)SquareDouble;

                if (SquareDouble == SquareInt)
                {
                    SquareCheck = true;
                }
                
                if (SquareCheck)
                {
                    fullSquare.Text = null;
                    fullSquare.Text = "Полный квадрат";
                }
                else
                {
                    fullSquare.Text = null;
                    fullSquare.Text = "Не полный квадрат";
                }

                //Полный куб

                int SumNumberСube = comboTickets / 1000 % 10 + comboTickets / 100 % 10 + comboTickets / 10 % 10 + comboTickets / 1 % 10;
                double CubeDouble = Math.Pow(SumNumberСube, 1.0 / 3.0);
                int CubeInt = (int)CubeDouble;

                if (CubeDouble == CubeInt)
                {
                    CubeCheck = true;
                }
                
                if (CubeCheck)
                {
                    fullCube.Text = null;
                    fullCube.Text = "Не полный квадрат";
                }
                else
                {
                    fullCube.Text = null;
                    fullCube.Text = "Не полный куб";
                }
            }
        }

        //Четные и нечетные
        private void Button_EvenOdd(object sender, RoutedEventArgs e)
        {
            int even = 0;
            int odd = 0;

            if (NumberPartionsCombo.SelectedItem != null && NumberTicketsCombo.SelectedItem == null)
            {
                int combo = (int)NumberPartionsCombo.SelectedItem;

                Partion? partion = ResourceManager.GetPartionByNumber(combo);
                if (partion == null) return;

                var tickets = partion.tickets;

                for (int j = 0; j < tickets.Count; j++)
                {
                    //Четные билеты
                    int SumNumberEven = tickets[j] / 1000 % 10 + tickets[j] / 100 % 10 + tickets[j] / 10 % 10 + tickets[j] / 1 % 10;
                    int SumNumberOdd = tickets[j] / 1000 % 10 + tickets[j] / 100 % 10 + tickets[j] / 10 % 10 + tickets[j] / 1 % 10;

                    if (SumNumberEven % 2 == 0)
                    {
                        even++;
                        //EvenOdd.Text = even.ToString();
                    }
                    //Нечетные билеты
                    if (SumNumberOdd % 2 != 0)
                    {
                        odd++;
                        //EvenOdd.Text = odd.ToString();
                    }
                }
                    EvenOdd.Text = "Количество четных: " + even +"                           " + "Количество нечетных: " + odd;

            }
            else if (NumberPartionsCombo.SelectedItem != null && NumberTicketsCombo.SelectedItem != null)
            {
                int comboPartion = (int)NumberPartionsCombo.SelectedItem;
                int comboTickets = (int)NumberTicketsCombo.SelectedItem;

                Partion? partion = ResourceManager.GetPartionByNumber(comboPartion);
                if (partion == null) return;

                //Четный билеты
                int SumNumberEven = comboTickets / 1000 % 10 + comboTickets / 100 % 10 + comboTickets / 10 % 10 + comboTickets / 1 % 10;
                if (SumNumberEven % 2 == 0)
                {
                    EvenOdd.Text = "Этот билет четный";
                }

                //Нечетный билеты
                int SumNumberOdd = comboTickets / 1000 % 10 + comboTickets / 100 % 10 + comboTickets / 10 % 10 + comboTickets / 1 % 10;
                if (SumNumberOdd % 2 != 0)
                {
                    EvenOdd.Text = "Этот билет нечетный";
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
