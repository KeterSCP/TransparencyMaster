using System;
using System.Runtime.InteropServices;
using System.Text;
using TransparencyMaster.Core.WinTypes;

namespace TransparencyMaster.Core
{
    public static class PInvokeManager
    {
        [DllImport("User32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.I4)]
        internal static extern int GetWindowLongA(IntPtr hWnd, int nIndex);

        [DllImport("User32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.I4)]
        internal static extern int SetWindowLongA(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("User32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SetLayeredWindowAttributes(IntPtr hWnd, uint crKey, byte bAlpha, uint dwFlags);

        [DllImport("User32.dll", SetLastError = true)]
        internal static extern IntPtr WindowFromPoint(POINT point);

        [DllImport("User32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref POINT point);

        [DllImport("User32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.I4)]
        internal static extern int GetWindowTextA(IntPtr hWNd, StringBuilder lpString, int nMaxCount);

        [DllImport("User32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.U4)]
        internal static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);
    }
}
