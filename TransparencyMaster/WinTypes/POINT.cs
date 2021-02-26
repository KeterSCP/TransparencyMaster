using System.Runtime.InteropServices;

namespace TransparencyMaster.Core.WinTypes
{
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int x;
        public int y;
    }
}