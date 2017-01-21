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
        }
    }
}
