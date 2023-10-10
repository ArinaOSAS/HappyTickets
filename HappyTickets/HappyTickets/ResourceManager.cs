using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTickets
{
    public static class ResourceManager
    {
        static ResourceManager()
        {
            Partions = LoaderPartion.Load("C:\\Users\\arina\\OneDrive\\Рабочий стол\\Новая папка\\Tickets.txt");
        }
        public static List<Partion> Partions { get; set; }

        //Соответствует ли партия выбранной
        public static Partion? GetPartionByNumber(int partionNumber)
        {
            return Partions.First(part => part.partionNumber == partionNumber);
        }
    }
}
