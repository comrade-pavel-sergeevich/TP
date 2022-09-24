using System.Runtime.InteropServices;


namespace Проект
{
    internal class Program: UserInterfaceFunctions
    {
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        const int SW_Min = 2;
        const int SW_Max = 3;
        const int SW_Norm = 4;
        object[] bufer=null;
        List<Form> forms=new List<Form>();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            [DllImport("kernel32.dll")]
            static extern IntPtr GetConsoleWindow();

            [DllImport("user32.dll")]
            static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
            AllocConsole();
            [DllImport("kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool AllocConsole();
            object? a;
            do
            {
                Console.Write("Для выбора консольного интерфейса введите \"1\"\nДля выбора графического интерфейса введите \"2\": ");
                a = Console.ReadLine();
                switch (a)
                {
                    case "1":
                        {
                            UserInterfaceManager um = new UserInterfaceManager(new Consolnoe());
                            return;
                        }
                        case "2":
                        {
                            var handle = GetConsoleWindow();
                            ShowWindow(handle, SW_HIDE);
                            UserInterfaceManager um = new UserInterfaceManager(new Program());
                            return;
                        }
                }
            } while (true);
            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
        }
        public void Hello()
        {
            ApplicationConfiguration.Initialize();
            Thread t = new Thread(() => Application.Run(new Privetstvie(this)));
            t.Start();
        }
        public void Vhod() { }

        public object[] Login()
        {
            forms.Insert(0, new Form3(this));
            Thread t = new Thread(() => { Application.Run(forms[0]);forms.RemoveAt(0); }) ;
            t.Start();
            bufer = null;
            while (bufer == null) Thread.Sleep(100);
            return bufer;
        }
        public object[] Register()
        {
            forms.Insert(0, new Form4(this));
            Thread t = new Thread(() => { Application.Run(forms[0]); forms.RemoveAt(0); });
            t.Start();
            bufer = null;
            while (bufer == null) Thread.Sleep(100);
            return bufer;
        }
        public void GetData(object[] data)
        {
            bufer = data;
        }
        public string GetDeistvie()
        {
            bufer = null;
            while (bufer == null) Thread.Sleep(100);
            return bufer[0] as string;
        }
        public void RegisterComplete()
        {
            (forms[0] as Form4).RegisterComplete();
            //Console.WriteLine("Вы успешно зарегистрировались");
        }
        public void Exit() { }
    }

}