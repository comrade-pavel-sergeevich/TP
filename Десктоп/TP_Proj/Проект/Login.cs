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
    public partial class Login : Form
    {
        Program program;
        Connect conn = new Connect();
        internal Login(Program program)
        {
            this.program = program;
            InitializeComponent();
            textBox1.Text = "Имя пользователя";
            textBox2.Text = "Пароль";
            textBox1.ForeColor = Color.Orange;
            textBox2.ForeColor = Color.Orange;
            this.textBox2.AutoSize = false;
            this.textBox2.Size = new Size(this.textBox2.Size.Width, 64);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Form2 fr2 = new Form2(this);
            //fr2.Show();
            //Hide();
            program.GetData(new object[] { "back" });
            Close();
        }
   

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Имя пользователя")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Пароль")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Имя пользователя";
                textBox1.ForeColor = Color.Orange;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Пароль";
                textBox2.ForeColor = Color.Orange;
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            program.GetData(new object[] { "exit" });
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (conn.Autoriz(textBox1.Text, textBox2.Text))
            //{
            //    Form5 fr5 = new Form5();
            //    fr5.Show();
            //    Hide();

            //    MessageBox.Show("autoriz successful");
            //}
            //else
            //{
            //    MessageBox.Show("user doesn't exist or wrong password");
            //}
            program.GetData(new object[] { textBox1.Text, textBox2.Text });
            textBox1.Clear();
            textBox2.Clear();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}
