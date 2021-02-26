using System;
using TransparencyMaster.Core.WinTypes;

namespace TransparencyMaster.Core
{
    public static class ManagedProxy
    {
        public static IntPtr GetWindowFromPoint(POINT point) => PInvokeManager.WindowFromPoint(point);

        public static uint GetProcessIdFromWindowHandle(IntPtr hWnd)
        {
            PInvokeManager.GetWindowThreadProcessId(hWnd, out uint processId);
            return processId;
        }

        public static POINT GetCursorPosition()
        {
            var point = new POINT();
            PInvokeManager.GetCursorPos(ref point);
            return point;
        }

        public static void SetWindowTransparency(IntPtr hWnd, byte transparency)
        {
            const int GWL_EXSTYLE = -20;
            const int WS_EX_LAYERED = 0x80000;
            const int LWA_ALPHA = 0x00000002;
            
            int wAttr = PInvokeManager.GetWindowLongA(hWnd, GWL_EXSTYLE);
            PInvokeManager.SetWindowLongA(hWnd, GWL_EXSTYLE, wAttr | WS_EX_LAYERED);
            PInvokeManager.SetLayeredWindowAttributes(hWnd, 0, transparency, LWA_ALPHA);
        }
    }
}
