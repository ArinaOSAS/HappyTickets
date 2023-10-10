using OxyPlot;
using OxyPlot.Series;
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
    public partial class DensityGraph : Window
    {
        public DensityGraph()
        {
            InitializeComponent();
            DataContext = new DensityGraphViewModel();
            foreach (var partion in ResourceManager.Partions)
            {
                NumberPartionsCombo.Items.Add(partion.partionNumber).ToString();
            }

        }

        public PlotModel PlotModel { get; set; }

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

        //Назад
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
        }

        //Обработчик количества билетов на промежутке
        private void Step_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NumberPartionsCombo.SelectedItem == null) return;
            int combo = (int)NumberPartionsCombo.SelectedItem;

            Partion? partion = ResourceManager.GetPartionByNumber(combo);
            if (partion == null) return;

            try
            {
                int step = int.Parse(Step.Text);
                ((DensityGraphViewModel)DataContext).Update(step, partion);
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
