using System;

namespace Lab3
{
    public class Prijsberekening
    {
        int tariefeenheden;
        int tableColumn;

        public void DefinitievePrijs(TicketautomaatInvoer info)
        {
            // Get number of tariefeenheden
            Database.AddTracks();
            tariefeenheden = Database.GetTariefeenheden(Database.alleTracks, info.From, info.To);
                       
            // Get price
            GetClass(info);
            GetDiscount(info);
            Prijsberekening P = new Prijsberekening();
            float price = P.PriceColumn(tariefeenheden, tableColumn);
            CalcRetour(info, price);
            CreditCardFee(info, price);
            
            // Verwerken betaling
            Ticketautomaat t = new Ticketautomaat();
            t.VerwerkBetaling(info, price);
        }
        
        public float PriceColumn(int tariefeenheden, int col)
        {
            double price = 0;

            switch (col)
            {
                case 0:
                    price = 2.10;
                    break;
                case 1:
                    price = 1.70;
                    break;
                case 2:
                    price = 1.30;
                    break;
                case 3:
                    price = 3.60;
                    break;
                case 4:
                    price = 2.90;
                    break;
                case 5:
                    price = 2.20;
                    break;
                default:
                    throw new Exception("Unknown column number");
            }

            price = CalcPrice(price, tariefeenheden);
            return (float)price;
        }

        public double CalcPrice(double price, int tariefeenheden)
        {
            price = price * 0.02 * tariefeenheden;
            return (float)Math.Round(price, 2);
        }

        public void GetClass(TicketautomaatInvoer info)
        {
            if (info.Class == UIClass.FirstClass)
            {
                tableColumn = 3;
            }

            else
                tableColumn = 0;
        }

        public void GetDiscount(TicketautomaatInvoer info)
        {
            if (info.Discount == UIDiscount.TwentyDiscount)
            {
                tableColumn += 1;
            }

            if (info.Discount == UIDiscount.FortyDiscount)
                tableColumn += 2;
        }

        public void CalcRetour(TicketautomaatInvoer info, float price)
        {
            if (info.Way == UIWay.Return)
            {
                price *= 2;
            }
        }

        public void CreditCardFee(TicketautomaatInvoer info, float price)
        {
            if (info.From == info.To)
            {
                price = 0;
            }

            else if (info.Payment == UIPayment.CreditCard)
            {
                price += 0.50f;
            }
        }
    }
}
