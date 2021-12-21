using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CameraCapture
{
    public class ScreenCapture
    {
        public static Bitmap captureScreen()
        {
            return captureWindow(User32.GetDesktopWindow());
        }

        public static Size getResolution()
        {
            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            return new Size(resolution.Width, resolution.Height);
        }

        public static Bitmap captureWindow(IntPtr handle)
        {
            IntPtr hDCSrc = User32.GetWindowDC(handle);
            User32.RECT windowRect = new User32.RECT();
            User32.GetWindowRect(handle, ref windowRect);
            int width = windowRect.right - windowRect.left;
            int height = windowRect.bottom - windowRect.top;

            IntPtr hDCDest = GDI32.CreateCompatibleDC(hDCSrc);
            IntPtr hBitmap = GDI32.CreateCompatibleBitmap(hDCSrc, width, height);
            IntPtr hOld = GDI32.SelectObject(hDCDest, hBitmap);
            GDI32.BitBlt(hDCDest, 0, 0, width, height, hDCSrc, 0, 0, GDI32.SRCCOPY);
            GDI32.SelectObject(hDCDest, hOld);

            GDI32.DeleteDC(hDCDest);
            User32.ReleaseDC(handle, hDCSrc);

            Bitmap ret = Image.FromHbitmap(hBitmap);
            GDI32.DeleteObject(hBitmap);
            return ret;
        }

        public static void captureWindowToFile(IntPtr handle, string fileName, ImageFormat format)
        {
            Bitmap bitmap = captureWindow(handle);
            bitmap.Save(fileName, format);
        }

        public static void captureScreenToFile(string fileName, ImageFormat format)
        {
            Bitmap bitmap = captureScreen();
            bitmap.Save(fileName, format);
        }

        private static class GDI32
        {
            public const int SRCCOPY = 0x00CC0020;

            [DllImport("gdi32.dll")]
            public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hObjectSource, int nXSrc, int nYSrc, int dwRop);

            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth, int nHeight);

            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

            [DllImport("gdi32.dll")]
            public static extern bool DeleteDC(IntPtr hDC);

            [DllImport("gdi32.dll")]
            public static extern bool DeleteObject(IntPtr hObject);

            [DllImport("gdi32.dll")]
            public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
        }

        private static class User32
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int left;
                public int top;
                public int right;
                public int bottom;
            }

            [DllImport("user32.dll")]
            public static extern IntPtr GetDesktopWindow();

            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowDC(IntPtr hWnd);

            [DllImport("user32.dll")]
            public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);

            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);
        }
    }
}