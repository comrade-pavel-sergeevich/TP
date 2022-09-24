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
    public partial class Choosing_of__BD : Form
    {
        Program program;
        public Choosing_of__BD()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            program.GetData(new object[] { "exit" });
            Application.Exit();
        }
    }
}
