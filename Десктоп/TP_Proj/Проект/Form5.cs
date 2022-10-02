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
    public partial class Form5 : Form
    {
        Program program;
        internal Form5(Program program)
        {
            InitializeComponent();
            this.program = program;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            program.GetData(new object[] { "exit" });
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            program.GetData(new object[] { "exit" });
            Application.Exit();
            Hide();
        }
    }
}
