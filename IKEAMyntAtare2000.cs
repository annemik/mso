using System.Windows.Forms;

namespace Lab3
{
    public class IKEAMyntAtare2000
    {

        public void Starta()
        {
            MessageBox.Show("Välkommen till IKEA Mynt Ätare 2000");
        }

        public void Stoppa()
        {
            MessageBox.Show("Hejdå!");
        }

        public void Betala(int pris)
        {
            MessageBox.Show(pris + " cent");
        }
    }
}