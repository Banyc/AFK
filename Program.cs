using System;
using System.Collections.Generic;
using System.Threading;

namespace AFK
{
    class Program
    {
        const UInt32 WM_KEYDOWN = 0x0100;
        const UInt32 WM_KEYUP = 0x0101;
        const int VK_F5 = 0x74;
        const int VK_W = 0x57;
        const int VK_S = 0x53;
        const int VK_A = 0x41;
        const int VK_D = 0x44;
        const int VK_F = 0x46;
        const int VK_J = 0x4A;
        const int VK_Z = 0x5A;
        const int VK_C = 0x43;
        const int VK_1 = 0x31;
        const int VK_2 = 0x32;
        const int VK_3 = 0x33;
        const int VK_4 = 0x34;
        const int VK_OEM_2 = 0xBF;

        static void Main(string[] args)
        {
            Random rnd = new Random();
            List<int> keyList = new List<int>()
            {
                // VK_F5,

                // VK_W,
                // VK_S,
                // VK_A,
                // VK_D,
                VK_F,
                // VK_Z,
                // VK_C,
                // VK_1,
                // VK_2,
                // VK_3,
                // VK_4,
            };
            Console.WriteLine("Allow you to perform automatic key pressing to a running process");

            // Console.WriteLine("Please enter a key to escape");
            // Console.Write("> ");
            // ConsoleKeyInfo hotkey = Console.ReadKey();
            // hkmgr.Register(hotkey.KeyChar, hotkey.Modifiers);

            Console.WriteLine("Please enter the freezing time in seconds before running");
            Console.Write("> ");

            string freezingStr = Console.ReadLine();
            int freezing;
            if (!int.TryParse(freezingStr, out freezing)) freezing = 7;

            Console.WriteLine("sleeping");
            Thread.Sleep(freezing * 1000);

            Console.WriteLine("running");
            AutoKeyPress(keyList, rnd);
        }

        [STAThread]
        static void AutoKeyPress(List<int> keyList, Random rnd)
        {
            while (true)
            {
                foreach (int key in keyList)
                {
                    WinAPI.MouseKeyboard.PressKey(key, false, false, false, rnd.Next(500, 1000));
                }
                Thread.Sleep(rnd.Next(400, 2000));
            }
        }
    }
}
