using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form1 = new Form1();
            form1.enableUsbDeviceNotification(() =>
            {
                Console.Error.WriteLine("Added");
            }, () =>
            {
                Console.Error.WriteLine("Added");
            });

            Thread interfaceThread = new Thread((Object obj) =>
            {
                String msg;
                while ((msg = Console.In.ReadLine()) != null)
                {
                    Console.Out.WriteLine(">>" + msg);
                }
                form1.unregisterUsbDeviceEvent();
                Application.Exit();
            });

            interfaceThread.Start();
            Application.Run(form1);
        }
    }
}
