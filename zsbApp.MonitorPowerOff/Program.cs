using System;

namespace zsbApp.MonitorPowerOff
{
    class Program
    {
        private const uint WM_SYSCOMMAND = 0x112; //系统消息
        private const int SC_MONITORPOWER = 0xF170; //关闭显示器的系统命令
        private const int FLAG_MONITOR_POWEROFF = 2; //2为PowerOff, 1为省电状态，-1为开机
        private static readonly IntPtr HWND_BROADCAST = new IntPtr(0xffff); //广播消息，所有顶级窗体都会接收

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);


        static void Main(string[] args)
        {
            System.Timers.Timer t = new System.Timers.Timer(50);
            t.Enabled = true;
            t.Elapsed+=(s, e) => System.Environment.Exit(0);
            SendMessage(HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, FLAG_MONITOR_POWEROFF);
        }
    }
}
