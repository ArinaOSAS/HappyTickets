using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTickets
{
    public class HelperTickets
    {
        //Определение счастливого билета

        public static bool IsHappyTicket(int ticket)
        {
            int leftBlock = ticket / 1000 % 10 + ticket / 100 % 10;
            int rightBlock = ticket / 10 % 10 + ticket / 1 % 10;
            if (leftBlock == rightBlock) return true;
            return false;
        }
    }
}
