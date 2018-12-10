using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class MAIN_FORM : Form
    {
        // MDI 자식폼 테스트 
        Sample_Form Child1 = new Sample_Form();

        int user_rank = 4;

        int sX = 1160, sY = 680; // 폼 사이즈 지정.

        ///////// 좌표 체크시 추가 /////////
        static ToolStripStatusLabel StripLb;
        StatusStrip statusStrip;
        ///////////////////////////////////


        public MAIN_FORM()
        {
            InitializeComponent();

            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            ClientSize = new Size(sX, sY);  // 폼 사이즈 지정.
            this.IsMdiContainer = true;     // MDI 설정.

            //좌표 체크시 추가  
            Point_Print();

            // 컨트롤 객체생성. 
            COMMON_Create_Ctl comm_create_ctl = new COMMON_Create_Ctl();

            // 생성할 패널 정보 객체 생성.
            PANELclass pn1 = new PANELclass(this, "panel1", "panel_main", 1160, 530, 0, 100, panel_MouseMove);

            Panel panel1 = comm_create_ctl.panel(pn1);  // ex) 판넬만들기 :  create_ctl.CTL명(CTL값);           
            Controls.Add(panel1);  // 원하는 컨트롤에 추가함.

            BTNclass bt1 = new BTNclass(this, "유저1", "도서정보", 200, 100, 0, 0, btn1_Click);
            BTNclass bt2 = new BTNclass(this, "유저2", "대여목록", 200, 100, 200, 0, btn2_Click);
            BTNclass bt3 = new BTNclass(this, "유저3", "나의정보", 200, 100, 400, 0, btn3_Click);
            BTNclass bt4 = new BTNclass(this, "유저4", "도서위치MAP", 200, 100, 600, 0, btn4_Click);
            BTNclass bt5 = new BTNclass(this, "관리1", "도서정보", 200, 100, 0, 0, btn5_Click);
            BTNclass bt6 = new BTNclass(this, "관리2", "회원정보", 200, 100, 200, 0, btn6_Click);
            BTNclass bt7 = new BTNclass(this, "관리3", "도서관리", 200, 100, 400, 0, btn7_Click);
            BTNclass bt8 = new BTNclass(this, "관리4", "연체관리", 200, 100, 600, 0, btn8_Click);

            Button btn = comm_create_ctl.btn(bt1);
            Button btn1 = comm_create_ctl.btn(bt2);
            Button btn2 = comm_create_ctl.btn(bt3);
            Button btn3 = comm_create_ctl.btn(bt4);
            //Button btn4 = comm_create_ctl.btn(bt5);
            //Button btn5 = comm_create_ctl.btn(bt6);
            //Button btn6 = comm_create_ctl.btn(bt7);
            //Button btn7 = comm_create_ctl.btn(bt8);
            Controls.Add(btn);
            Controls.Add(btn1);
            Controls.Add(btn2);
            Controls.Add(btn3);
            


            // Set the Parent Form of the Child window.
            //Child1.TopLevel = false;
            //Child1.TopMost = true;
            //Child1.MdiParent = this;
            //Child1.Dock = DockStyle.Fill; //판넬크기에 맞게 사이즈 늘림.
            //panel1.Controls.Add(Child1);

            //Child2.Show();
            //Child1.Show();
            //Child1.Dispose();

            Logo_Load();//로고 이미지
        }
        private void Logo_Load()
        {
            PictureBox pictureBox = new PictureBox();

            pictureBox.Image = (Bitmap)WindowsFormsApp.Properties.Resources.ResourceManager.GetObject("hlc11");
            pictureBox.Location = new Point(800, 0);
            pictureBox.Size = new Size(360, 100);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            Controls.Add(pictureBox);
        }

        private void btn1_Click(Object o, EventArgs e)
        {
            //MessageBox.Show("동작확인 : btn_Click");
            //if (Child1.Visible)
            //{
            //    Child1.Hide();
                
            //}
            //else
            //{
                
            //    Child1.Show();
            //}

        }

        private void btn2_Click(Object o, EventArgs e)
        {
            
            //MessageBox.Show("동작확인 : btn_Click");
            //if (Child1.Visible)
            //{
            //    Child1.Hide();

            //}
            //else
            //{

            //    Child1.Show();
            //}

        }

        private void btn3_Click(Object o, EventArgs e)
        {
            //MessageBox.Show("동작확인 : btn_Click");
            //if (Child1.Visible)
            //{
            //    Child1.Hide();

            //}
            //else
            //{

            //    Child1.Show();
            //}

        }

        private void btn4_Click(Object o, EventArgs e)
        {
            //MessageBox.Show("동작확인 : btn_Click");
            //if (Child1.Visible)
            //{
            //    Child1.Hide();

            //}
            //else
            //{

            //    Child1.Show();
            //}

        }

        private void btn5_Click(Object o, EventArgs e)
        {
            //MessageBox.Show("동작확인 : btn_Click");
            //if (Child1.Visible)
            //{
            //    Child1.Hide();

            //}
            //else
            //{

            //    Child1.Show();
            //}

        }

        private void btn6_Click(Object o, EventArgs e)
        {
            //MessageBox.Show("동작확인 : btn_Click");
            //if (Child1.Visible)
            //{
            //    Child1.Hide();

            //}
            //else
            //{

            //    Child1.Show();
            //}

        }

        private void btn7_Click(Object o, EventArgs e)
        {
            //MessageBox.Show("동작확인 : btn_Click");
            //if (Child1.Visible)
            //{
            //    Child1.Hide();

            //}
            //else
            //{

            //    Child1.Show();
            //}

        }

        private void btn8_Click(Object o, EventArgs e)
        {
            //MessageBox.Show("동작확인 : btn_Click");
            //if (Child1.Visible)
            //{
            //    Child1.Hide();

            //}
            //else
            //{

            //    Child1.Show();
            //}

        }

        private void label_Click(Object o, EventArgs e)
        {
            MessageBox.Show("동작확인 : label_Click");
        }

        private void txtbox_Click(Object o, EventArgs e)
        {
            MessageBox.Show("동작확인 : txtbox_Click");
        }

        private void chkbox_Click(Object o, EventArgs e)
        {
            MessageBox.Show("동작확인 : chkbox_Click2");
        }

        private void radio_btn_Click(Object o, EventArgs e)
        {
            MessageBox.Show("동작확인 : radio_btn_Click");
        }

        private void picturbox_Click(Object o, EventArgs e)
        {
            MessageBox.Show("동작확인 : picturbox_Click");
        }

        private void panel_Click(Object o, EventArgs e)
        {
            MessageBox.Show("동작확인 : panel_Click");
        }
        private void panel_MouseMove(Object o, MouseEventArgs e)
        {
            StripLb.Text = "(" + e.X + ", " + e.Y + ")";
        }

        private void tabctl_Click(Object o, EventArgs e)
        {
            MessageBox.Show("동작확인 : tabctl_Click");
        }
        private void tabctl_MouseMove(Object o, MouseEventArgs e)
        {
            StripLb.Text = "(" + e.X + ", " + e.Y + ")";
        }

        private void tabpage_Click(Object o, EventArgs e)
        {
            MessageBox.Show("동작확인 : tabpage_Click");
        }
        private void tabpage_MouseMove(Object o, MouseEventArgs e)
        {
            StripLb.Text = "(" + e.X + ", " + e.Y + ")";
        }


        ///////////////////////// 좌표 체크시 추가 /////////////////////////////

        private void Point_Print()
        {
            MouseMove += new MouseEventHandler(this.Current_FORM_MouseMove);
            statusStrip = new StatusStrip();
            StripLb = new ToolStripStatusLabel();
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { StripLb });
            statusStrip.Location = new Point(0, sY);
            statusStrip.Name = "statusStrip1";
            statusStrip.Size = new Size(sX, 22);
            statusStrip.TabIndex = 0;
            statusStrip.Text = "statusStrip1";
            // toolStripStatusLabel1
            StripLb.Name = "StripLb1";
            StripLb.Size = new Size(121, 17);
            StripLb.Text = "StripLb1";
            Controls.Add(statusStrip);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Current_FORM_MouseMove(object sender, MouseEventArgs e)
        {
            StripLb.Text = "(" + e.X + ", " + e.Y + ")";
        }
        ///////////////////////////////////////////////////////////////////////
    }
}