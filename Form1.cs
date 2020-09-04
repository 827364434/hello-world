using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;
using System.Threading;
using CameraAcc;




namespace Crmera
{
    public partial class Form1 : Form
    {
        Thread thread;
        HTuple hv_AcqHandle = null;

        public Form1()
        {
            InitializeComponent();
            CamerSet.m_pInstance.CameraLst["笔记本相机"].hw = this.hWindowControl1.HalconWindow;
            CamerSet.m_pInstance.CameraLst["上相机"].hw1 = this.hWindowControl2.HalconWindow;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            CamerSet.m_pInstance.CameraLst["笔记本相机"].Cmbs += Instan_Cmbs;
            CamerSet.m_pInstance.CameraLst["上相机"].UpCmbs += Form1_UpCmbs;
            CamerSet.m_pInstance.CameraLst["上相机"].TrbExposureTime = this.TrbExposureTime;
            CamerSet.m_pInstance.CameraLst["笔记本相机"].TrbExposureTime = this.TrbExposureTime;
        }

        private void Form1_UpCmbs(HObject ho_Image, int index)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    break;
                default:
                    break;
            }
        }

        private void Instan_Cmbs(HObject ho_Image, int index)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    break;
                default:
                    break;
            }
            // throw new NotImplementedException();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        //打开相机按钮
        private void Button1_Click(object sender, EventArgs e)
        {
            /* try
             {
                 switch (comboBox1.SelectedIndex)
                 {
                     case 0:
                         thread = new Thread(CameraHalcon.instan.Open);
                         thread.Start();
                         CameraHalcon.instan.bCameraStop = false;
                         richTextBox1.Text = "打开原图相机成功!";
                         break;
                     case 1:
                         thread = new Thread(CameraHalcon.instan.Open);
                         thread.Start();
                         CameraHalcon.instan.bCameraStop = false;
                         richTextBox1.Text = "打开十字显示相机成功!";
                         break;
                     default:
                         break;
                 }
             }
             catch(Exception ex)
             {
                 richTextBox1.Text = ex.Message;
             }*/
            
            CamerSet.m_pInstance.CameraLst["笔记本相机"].Open("笔记本相机");
            if (comboBox1.SelectedIndex == 0)
            {
                richTextBox1.Text = "打开原图相机成功!";
            }
            else
            {
                richTextBox1.Text = "打开十字显示相机成功!";
            }
            
        }
        //关闭相机
        private void Button8_Click(object sender, EventArgs e)
        {
            try
            {
                //  thread = null;
                //   CameraHalcon.instan.Close();
                CamerSet.m_pInstance.CameraLst["笔记本相机"].Close(CamerSet.m_pInstance.CameraLst["笔记本相机"].hw);
                richTextBox1.Text = "关闭相机成功！！！";
            }
            catch (Exception ex)
            {
                richTextBox1.Text = ex.Message.ToString();
            }
        }
        //拍照
        private void Button2_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    CamerSet.m_pInstance.CameraLst["笔记本相机"].TakePhoto(0, CamerSet.m_pInstance.CameraLst["笔记本相机"].hw);
                    break;
                case 1:
                    CamerSet.m_pInstance.CameraLst["笔记本相机"].TakePhoto(1, CamerSet.m_pInstance.CameraLst["笔记本相机"].hw);
                    break;
                default:
                    break;
            }
        }

        //打开图片
        private void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                CamerSet.m_pInstance.CameraLst["笔记本相机"].OpenPhoto(CamerSet.m_pInstance.CameraLst["笔记本相机"].hw);
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
        }
        //保存图片
        private void Button7_Click(object sender, EventArgs e)
        {
            try
            {
                CamerSet.m_pInstance.CameraLst["笔记本相机"].SavePhoto(CamerSet.m_pInstance.CameraLst["笔记本相机"].hw);
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
        }
        //点×结束这个线程
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                System.Environment.Exit(0);
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
        }
        //录像
        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                CamerSet.m_pInstance.CameraLst["笔记本相机"].VideoRecorder(CamerSet.m_pInstance.CameraLst["笔记本相机"].hw);
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
        }
        //录像停止
        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                CamerSet.m_pInstance.CameraLst["笔记本相机"].StopVideoRecorder();
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
        }
        //上相机打开
        private void Button1_Click_1(object sender, EventArgs e)
        {
            CamerSet.m_pInstance.CameraLst["上相机"].Open("上相机");
            richTextBox2.Text = "上相机打开成功！";
        }
        //上相机录像
        private void Button11_Click(object sender, EventArgs e)
        {
            try
            {
                CamerSet.m_pInstance.CameraLst["上相机"].VideoRecorder(CamerSet.m_pInstance.CameraLst["上相机"].hw1);
                richTextBox2.Text = "上相机录像成功！";
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
        }
        //上相机拍照
        private void Button9_Click(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    CamerSet.m_pInstance.CameraLst["上相机"].TakePhoto(0, CamerSet.m_pInstance.CameraLst["上相机"].hw1);
                    break;
                case 1:
                    CamerSet.m_pInstance.CameraLst["上相机"].TakePhoto(1, CamerSet.m_pInstance.CameraLst["上相机"].hw1);
                    break;
                default:
                    break;
            }
            richTextBox2.Text = "上相机拍照成功！";
        }
        //上相机停止录像
        private void Button13_Click(object sender, EventArgs e)
        {
            try
            {
                CamerSet.m_pInstance.CameraLst["上相机"].StopVideoRecorder();
                richTextBox2.Text = "上相机停止录像成功！";
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
        }
        //上相机打开图片
        private void Button12_Click(object sender, EventArgs e)
        {
            try
            {
                CamerSet.m_pInstance.CameraLst["上相机"].OpenPhoto(CamerSet.m_pInstance.CameraLst["上相机"].hw1);
                richTextBox2.Text = "上相机打开图片成功！";
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
        }
        //上相机保存图片
        private void Button10_Click(object sender, EventArgs e)
        {
            try
            {
                CamerSet.m_pInstance.CameraLst["上相机"].SavePhoto(CamerSet.m_pInstance.CameraLst["上相机"].hw1);
                richTextBox2.Text = "上相机保存图片成功！";
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
        }
        //上相机关闭相机
        private void Button6_Click(object sender, EventArgs e)
        {
            try
            {
                //  thread = null;
                //   CameraHalcon.instan.Close();
                CamerSet.m_pInstance.CameraLst["上相机"].Close(CamerSet.m_pInstance.CameraLst["上相机"].hw1);
                richTextBox1.Text = "关闭上相机成功！！！";
            }
            catch (Exception ex)
            {
                richTextBox1.Text = ex.Message.ToString();
            }
        }
        //TxbWidth 只能输入数字
        private void TxbWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))   // 如果当前输入的不是数字
            {
               // MessageBox.Show("请输入数字！", "操作提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);   // 给出错误提示
                e.Handled = true;   // 取消当前操作，即取消在控件中现实该字符的操作
                richTextBox2.Text = "请输入数字！";
            }
        }
        //TextBoxHeight只能输入数字
        private void TxbHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))   // 如果当前输入的不是数字
            {
                // MessageBox.Show("请输入数字！", "操作提示：", MessageBoxButtons.OK, MessageBoxIcon.Information);   // 给出错误提示
                e.Handled = true;   // 取消当前操作，即取消在控件中现实该字符的操作
                richTextBox2.Text = "请输入数字！";
            }
        }
        //曝光时间每次滑动
        private void TrbExposureTime_Scroll(object sender, EventArgs e)
        {
            
            if (tabControl1.SelectedIndex == 0)
            {
                CamerSet.m_pInstance.CameraLst["上相机"].ExPosure(TrbExposureTime.Value);
            }
            else if (tabControl1.SelectedIndex == 1)
            {

            }
            else if (tabControl1.SelectedIndex == 2)
            {
                CamerSet.m_pInstance.CameraLst["笔记本相机"].ExPosure(TrbExposureTime.Value);
            }
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                TrbExposureTime.Maximum = 100000;
                TrbExposureTime.Minimum = 0;
                TrbExposureTime.Value = 8000;
            }
            else if (tabControl1.SelectedIndex == 1)
            {

            }
            else if (tabControl1.SelectedIndex == 2)
            {
                TrbExposureTime.Maximum = 64;
                TrbExposureTime.Minimum = -64;
                TrbExposureTime.Value = 30;

            }
        }
    }
}
