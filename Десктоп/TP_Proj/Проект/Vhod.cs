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
    internal partial class Vhod : Form
    {
        Program program;
        public Vhod(Program program)
        {
            InitializeComponent();
            this.program = program;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            program.GetData(new object[] { "login" });
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            program.GetData(new object[] { "register" });
            Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            program.GetData(new object[] {"exit" });
            Application.Exit();
        }

        private void Vhod_Load(object sender, EventArgs e)
        {
            Activate();
        }
    }
}
