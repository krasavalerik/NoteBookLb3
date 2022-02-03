using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb3Txi
{
    [Serializable]
    public class TicketTrain : Ticket
    {
        private bool discount_ticket = false;
        public bool Discount_ticket
        {
            get { return discount_ticket; }
            set { discount_ticket = value; }
        }

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
        }

        public TicketTrain() { date = DateTime.Now; }

        public override void Discount()
        {
            if (discount_ticket)
                this.Price = this.Price / 4;
        }
    }
}
