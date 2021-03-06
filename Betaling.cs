﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab3
{
    public abstract class Betaling
    {
        // Define the methods that the credit card and debit card have in common
        public virtual void Connect()
        { }

        public virtual void Disconnect()
        { }

        public virtual int BeginTransaction(float amount)
        {
            MessageBox.Show("Begin transaction 1 of " + amount + " EUR");
            return 1;
        }

        public virtual bool EndTransaction(int id)
        {
            if (id != 1)
                return false;

            MessageBox.Show("End transaction 1");
            return true;
        }

        public virtual void CancelTransaction(int id)
        {
            if (id != 1)
                throw new Exception("Incorrect transaction id");

            MessageBox.Show("Cancel transaction 1");
        }
    }

    // Mock CreditCard implementation
    public class CreditCard : Betaling
    {
        public override void Connect()
        {
            MessageBox.Show("Connecting to credit card reader");
        }
        
        public override void Disconnect()
        {
            MessageBox.Show("Disconnecting from credit card reader");
        }
    }

    // Mock DebitCard implementation
    public class DebitCard : Betaling
    {
        public override void Connect()
        {
            MessageBox.Show("Connecting to debit card reader");
        }

        public override void Disconnect()
        {
            MessageBox.Show("Disconnecting from debit card reader");
        }
    }

    public class CashPayment : Betaling
    {
        public IKEAMyntAtare2000 coinmachine;

        public CashPayment()
        {
            coinmachine = new IKEAMyntAtare2000();
        }

        public override void Connect()
        {
            coinmachine.Starta();
        }

        public override void Disconnect()
        {
            coinmachine.Stoppa();
        }

        public override int BeginTransaction(float amount)
        {
            coinmachine.Betala((int)Math.Round(amount * 100));
            return 1;
        }

        public override bool EndTransaction(int id)
        {
            if (id != 1)
                return false;

            coinmachine.Stoppa();
            return true;
        }
    }
}
