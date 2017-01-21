using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QQ找茬辅助
{
    class Utils
    {
        public static int BITMAP_WIDTH = 381;
        public static int BITMAP_HEIGHT = 286;

        public static int L_POS_X = 93;
        public static int L_POS_Y = 312;
        public static int R_POS_X = 550;
        public static int R_POS_Y = 312;


        public static int WIN_X = 0;
        public static int WIN_Y = 0;

        //截取图片区域;which=0:left;which=1:right;
        public static Bitmap getImageZone(Bitmap bitmap,int which) {
            Bitmap retbm = new Bitmap(BITMAP_WIDTH, BITMAP_HEIGHT);
            Graphics graphic = Graphics.FromImage(retbm);
            //截取原图相应区域写入作图区   
            if (which == 0)
            {
                graphic.DrawImage(bitmap, 0, 0, new Rectangle(93, 312, BITMAP_WIDTH, BITMAP_HEIGHT), GraphicsUnit.Pixel);
            }
            else if (which == 1) {
                graphic.DrawImage(bitmap, 0, 0, new Rectangle(550, 312, BITMAP_WIDTH, BITMAP_HEIGHT), GraphicsUnit.Pixel);
            }
            graphic.Dispose();  
            return retbm;
        }

        //用一个二值化的图体现出两个图的diff
        public static Bitmap diffTwoBitmap(Bitmap bm1, Bitmap bm2,int rad,int thre) {
            Bitmap bitmap = new Bitmap(BITMAP_WIDTH, BITMAP_HEIGHT);
            Graphics graphic = Graphics.FromImage(bitmap);

            for (int i = 0; i < BITMAP_WIDTH; i++) {
                for (int j = 0; j < BITMAP_HEIGHT; j++) {
                    Color cl1 = bm1.GetPixel(i, j);
                    Color cl2 = bm2.GetPixel(i, j);
                    if (getDistanceOfColors(cl1, cl2) > thre)
                    {
                        bitmap.SetPixel(i, j, Color.Black);
                    }
                }
            }


            return bitmap;
        }

        //定义了颜色的空间距离，范围是0~443
        public static int getDistanceOfColors(Color c1, Color c2) {
            int ret = (c1.R - c2.R) * (c1.R - c2.R) + (c1.G - c2.G) * (c1.G - c2.G) + (c1.B - c2.B) * (c1.B - c2.B);
            ret=(int)Math.Sqrt((double)ret);
            //Console.Out.WriteLine(ret + "");
            return ret;
        }


        //找茬的process，没找到返回null
        public static Process getTheProcess() {
            Process[] myProcesses = Process.GetProcesses();
            foreach(Process p in myProcesses){
                //Console.Out.WriteLine(p.ProcessName);
                if (p.ProcessName.Equals("ZhaoCha"))
                {
                    return p;
                }
            }
            return null;
        }


        //截屏，没有则返回null
        public static Bitmap CaptureWindow()
        {
            Process pGame = getTheProcess();
            if (pGame == null) {
                return null;
            }

            IntPtr handle = pGame.MainWindowHandle;
            int dwRop = GDI32.SRCCOPY;


            // get te hDC of the target window
            IntPtr hdcSrc = User32.GetWindowDC(handle);
            // get the size
            User32.RECT windowRect = new User32.RECT();
            User32.GetWindowRect(handle, ref windowRect);
            int width = windowRect.right - windowRect.left;
            int height = windowRect.bottom - windowRect.top;
            
            /* 这里更新当前窗口坐标 */
            Utils.WIN_X = windowRect.left;
            Utils.WIN_Y = windowRect.top;
            
            // create a device context we can copy to
            IntPtr hdcDest = GDI32.CreateCompatibleDC(hdcSrc);
            // create a bitmap we can copy it to,
            // using GetDeviceCaps to get the width/height
            IntPtr hBitmap = GDI32.CreateCompatibleBitmap(hdcSrc, width, height);
            // select the bitmap object
            IntPtr hOld = GDI32.SelectObject(hdcDest, hBitmap);
            // bitblt over
            GDI32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, dwRop);
            // restore selection
            GDI32.SelectObject(hdcDest, hOld);
            // clean up
            GDI32.DeleteDC(hdcDest);
            User32.ReleaseDC(handle, hdcSrc);
            // get a .NET image object for it
            Bitmap bitmap = Bitmap.FromHbitmap(hBitmap);
            // free up the Bitmap object
            GDI32.DeleteObject(hBitmap);
            return bitmap;
        }

        /// <summary>
        /// Helper class containing Gdi32 API functions
        /// </summary>
        private class GDI32
        {
            public const int SRCCOPY = 0x00CC0020; // BitBlt dwRop parameter
            [DllImport("gdi32.dll")]
            public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest,
            int nWidth, int nHeight, IntPtr hObjectSource,
            int nXSrc, int nYSrc, int dwRop);
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth,int nHeight);
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
            [DllImport("gdi32.dll")]
            public static extern bool DeleteDC(IntPtr hDC);
            [DllImport("gdi32.dll")]
            public static extern bool DeleteObject(IntPtr hObject);
            [DllImport("gdi32.dll")]
            public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
        }
        /// <summary>
        /// Helper class containing User32 API functions
        /// </summary>
        private class User32
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
