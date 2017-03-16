using System;
using System.Threading;
using System.Windows.Forms;

namespace AsyncExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //label1.Text = BigLongImportantMethod("ALexxxxx");
        }

        private string BigLongImportantMethod(string name)
        {
            Thread.Sleep(10000);
            return "Hello, " + name;
        }
    }
}
