﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab3
{
    class Printer
    {
        public void PrintTicket(string from, string to, UIClass cls, UIWay way, UIDiscount discount, UIPayment payment)
        {
            MessageBox.Show("Uw ticket\nStart location: " + from + "\nDestination: " + to +
                "\nClass: " + cls + "\nWay: " + way + "\nDiscount: " + discount + "\nPayment method: " + payment);
        }
    }
}
