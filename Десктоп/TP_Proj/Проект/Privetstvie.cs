namespace Проект
{
    internal partial class Privetstvie : Form
    {
        Program program;
        public Privetstvie(Program program)
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Start();
            this.program = program;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Form2 frm = new Form2(program);
            frm.Show();
            timer1.Stop();
            Hide();
        }
    }
}