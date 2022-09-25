namespace Проект
{
    internal partial class Hello : Form
    {
        public Hello()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Close();
        }

        private void Hello_Load(object sender, EventArgs e)
        {
            Activate();
        }
    }
}