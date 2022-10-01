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
    public partial class Register : Form
    {
        Program program;
        internal Register(Program program)
        {
            InitializeComponent();
            textBox1.Text = "Имя пользователя";
            textBox2.Text = "Почта";
            textBox3.Text = "Пароль";
            textBox4.Text = "Повторите пароль";
            textBox1.ForeColor = Color.Orange;
            textBox2.ForeColor = Color.Orange;
            textBox3.ForeColor = Color.Orange;
            textBox4.ForeColor = Color.Orange;
            textBox3.AutoSize = false;
            textBox3.Size = new Size(textBox3.Size.Width, 55);
            textBox4.AutoSize = false;
            textBox4.Size = new Size(textBox4.Size.Width, 55);
            this.program = program;
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Имя пользователя";
                textBox1.ForeColor = Color.Orange;
            }
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Почта")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Почта";
                textBox2.ForeColor = Color.Orange;
            }
        }
        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Пароль")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
                textBox3.UseSystemPasswordChar = true;
            }
        }
        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Пароль";
                textBox3.ForeColor = Color.Orange;
                textBox3.UseSystemPasswordChar = false;
            }
        }
        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Повторите пароль")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
                textBox4.UseSystemPasswordChar = true;
            }
        }
        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Повторите пароль";
                textBox4.ForeColor = Color.Orange;
                textBox4.UseSystemPasswordChar = false;
            }
        }
        private void label6_Click(object sender, EventArgs e)
        {
            program.GetData(new object[] { "exit" });
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != textBox4.Text) { MessageBox.Show("different passwords"); return; }
            program.GetData(new object[] { textBox1.Text, textBox2.Text, textBox3.Text });           
        }
        public void RegisterComplete()
        {
            MessageBox.Show("Вы успешно зарегистрировались");
            Application.Exit();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            this.ActiveControl = button2;
        }
    }
}
