using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace QQ找茬辅助
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        // 开始截屏
        private void button_cap_Click(object sender, EventArgs e)
        {
            Bitmap gameWindows = Utils.CaptureWindow();
            if (gameWindows == null) {
                MessageBox.Show("没有找到游戏");
                return;
            }
            Bitmap leftBM = Utils.getImageZone(gameWindows, 0);
            Bitmap rightBM = Utils.getImageZone(gameWindows, 1);
            int thre = Convert.ToInt32(numericUpDown_diffthre.Value);
            Bitmap diffBM = Utils.diffTwoBitmap(leftBM, rightBM, 1, thre);


            //gameWindows.Save(@"C:\g.png");
            //leftBM.Save(@"C:\1.png");
            //rightBM.Save(@"C:\2.png");
            //diffBM.Save(@"C:\diff.png");
            pictureBox1.Image = diffBM;

            //开启时钟
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int x = Control.MousePosition.X;
            int y = Control.MousePosition.Y;

            int m_x = 0, m_y = 0;

            if (x - Utils.WIN_X >= Utils.R_POS_X)
            {
                m_x = x - Utils.WIN_X - Utils.R_POS_X;
                m_y = y - Utils.WIN_Y - Utils.R_POS_Y;
            }
            else {
                m_x = x - Utils.WIN_X - Utils.L_POS_X;
                m_y = y - Utils.WIN_Y - Utils.L_POS_Y;
            }


            if (m_x >= 0 && m_x <= Utils.BITMAP_WIDTH && m_y >= 0 && m_y <= Utils.BITMAP_HEIGHT) {
                button1.Location = new Point(pictureBox1.Location.X + m_x - button1.Width / 2, pictureBox1.Location.Y + m_y - button1.Height / 2);
                
            }

        }
    }
}
