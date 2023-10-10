using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTickets
{
    public class DensityGraphViewModel : ViewModelBase
    {

        public DensityGraphViewModel()
        {

        }

        public PlotModel PlotModel { get; set; }

        public void Update(int step, Partion partion)
        {
            PlotModel = new PlotModel()
            {
                Title = "График плотности счастливых билетов на числовом промежутке"
            };

            int density = partion.tickets.Count / step;


            var line = new OxyPlot.Series.LineSeries()
            {
                Title = "График плотности",
                Color = OxyPlot.OxyColors.Blue,
                StrokeThickness = 1,
                InterpolationAlgorithm = InterpolationAlgorithms.CatmullRomSpline
            };

            for (int i = 0; i < density; i++)
            {
                int happyCount = 0;
                for (int depth = 0; depth < step; depth++)
                {
                    if (i * step + depth >= partion.tickets.Count) continue;

                    if (HelperTickets.IsHappyTicket(partion.tickets[i * step + depth]))
                    {
                        happyCount++;
                    }
                }
                line.Points.Add(new OxyPlot.DataPoint(i + 1, happyCount));
            }

            PlotModel.Series.Clear();
            PlotModel.Series.Add(line);

            OnPropertyChanged("PlotModel");
        }
    }
}
