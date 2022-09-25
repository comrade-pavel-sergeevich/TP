using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Проект
{
    public partial class ChoosingDB : Form
    {
        Program program;
        internal ChoosingDB(Program pr)
        {
            program = pr;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            program.GetData(new object[] { "exit" });
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            program.GetData(new object[] { new DB() });
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            program.GetData(new object[] { new JSON() });
            Close();
        }
    }
}
