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
    internal partial class Form2 : Form
    {
        Program program;
        public Form2(Program program)
        {
            InitializeComponent();
            this.program = program;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Form3 fr3 = new Form3(this);
            //fr3.Show();
            program.GetData(new object[] { "login" });
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Form4 fr4 = new Form4(this);
            //fr4.Show();
            program.GetData(new object[] { "register" });
            Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            program.GetData(new object[] {"exit" });
            Application.Exit();
        }
    }
}
