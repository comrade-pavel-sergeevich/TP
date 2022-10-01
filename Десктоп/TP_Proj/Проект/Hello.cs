namespace Проект
{
    internal partial class Hello : Form
    {
        public Hello()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Start();
            bool fileExist = File.Exists("Users.json");
            if (!fileExist)
            {
                File.Create("Users.json");
                JsonObject user = new JsonObject()
                {
                    UserInf = new List<UserInf> { }
                };
            }
            else { }
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