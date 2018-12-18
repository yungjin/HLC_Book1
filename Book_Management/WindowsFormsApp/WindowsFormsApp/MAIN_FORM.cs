using System;
using System.Collections;
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
        public static int member_rank = 4; // 0 관리자 / 1 유저 / 4 비회원
        public static int user_Number;
        PictureBox pictureBox;
        // MDI 자식폼 테스트 
        Sample_Form Child1 = new Sample_Form();
        public Label lb_Login;
        public Label lb_Signup;
        public Button btn;
        public Button btn1;
        public Button btn2;
        public Button btn3;
        //로긴/회원가입==================================================================================================
        public LOGIN_FORM Login;
        public SIGNUP_FORM Signup = new SIGNUP_FORM();


        //유저 폼 =======================================================================================================
        public BOOK_INFO_FORM user1 = new BOOK_INFO_FORM();
        public RENTAL_INFO_FORM user2 = new RENTAL_INFO_FORM();
        public MY_INFO_FORM user3 = new MY_INFO_FORM();
        public BOOK_LOC_FORM user4 = new BOOK_LOC_FORM();

        //===============================================================================================================
        int user_rank = 4;

        int sX = 1500, sY = 900; // 폼 사이즈 지정.

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
            PANELclass pn1 = new PANELclass(this, "panel1", "panel_main", 1500, 780, 0, 100, panel_MouseMove);

            Panel panel1 = comm_create_ctl.panel(pn1);  // ex) 판넬만들기 :  create_ctl.CTL명(CTL값);           
            Controls.Add(panel1);  // 원하는 컨트롤에 추가함.

            BTNclass bt1 = new BTNclass(this, "유저1", "도서정보", 285, 100, 0, 0, btn1_Click);
            BTNclass bt2 = new BTNclass(this, "유저2", "대여목록", 285, 100, 285, 0, btn2_Click);
            BTNclass bt3 = new BTNclass(this, "유저3", "나의정보", 285, 100, 570, 0, btn3_Click);
            BTNclass bt4 = new BTNclass(this, "유저4", "도서위치MAP", 285, 100, 855, 0, btn4_Click);
            BTNclass bt5 = new BTNclass(this, "관리1", "도서정보", 285, 100, 0, 0, btn5_Click);
            BTNclass bt6 = new BTNclass(this, "관리2", "회원정보", 285, 100, 285, 0, btn6_Click);
            BTNclass bt7 = new BTNclass(this, "관리3", "도서관리", 285, 100, 570, 0, btn7_Click);
            BTNclass bt8 = new BTNclass(this, "관리4", "연체관리", 285, 100, 855, 0, btn8_Click);

            btn = comm_create_ctl.btn(bt1);
            btn1 = comm_create_ctl.btn(bt2);
            btn2 = comm_create_ctl.btn(bt3);
            btn3 = comm_create_ctl.btn(bt4);


            Button btn4 = comm_create_ctl.btn(bt5);
            Button btn5 = comm_create_ctl.btn(bt6);
            Button btn6 = comm_create_ctl.btn(bt7);
            Button btn7 = comm_create_ctl.btn(bt8);


            Controls.Add(btn);


            Controls.Add(btn1);
            Controls.Add(btn2);
            Controls.Add(btn3);


            Controls.Add(btn4);
            Controls.Add(btn5);
            Controls.Add(btn6);
            Controls.Add(btn7);

            if(member_rank == 4) // 비회원
            {
                user1.Show();
                btn1.Hide();
                btn2.Hide();
                btn3.Hide();
                btn4.Hide();
                btn5.Hide();
                btn6.Hide();
                btn7.Hide();
            }
            else if(member_rank == 0) //관리자
            {

                btn.Hide();
                btn1.Hide();
                btn2.Hide();
                btn3.Hide();
            }
            //else if(member_rank == 1) //유저
            //{
            //    user1.Show();
            //    btn4.Hide();
            //    btn5.Hide();
            //    btn6.Hide();
            //    btn7.Hide();
            //}

            


            //라벨 ==============================================================================================================================================
            ArrayList lbarray = new ArrayList();
            lbarray.Add(new LBclass(this, "Login", "Login", 10, 70, 15, 1500-72, 3, label_Click));
            lbarray.Add(new LBclass(this, "Signup", "Signup", 10, 70, 15, 1500 - 72, 20, label2_Click));
            
            for (int i = 0; i < lbarray.Count; i++)
            {

                Label lb = comm_create_ctl.lb((LBclass)lbarray[i]);
                lb.Visible = true;
                lb.Cursor = Cursors.Hand;
                lb.Parent = pictureBox;
                lb.BackColor = Color.Transparent;
                lb.BringToFront();

                if (lb.Name == "Login")
                {
                    lb.Font = new Font("견명조", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));
                    lb_Login = lb;
                }
                else if (lb.Name == "Signup")
                {
                    lb.Font = new Font("견명조", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));
                    lb_Signup = lb;
                }
                Controls.Add(lb);
            }
            

            //=====================================================================================================================================================

            Logo_Load();//로고 이미지

            // Set the Parent Form of the Child window.
            //Child1.TopLevel = false;
            //Child1.TopMost = true;
            //Child1.MdiParent = this;
            //Child1.Dock = DockStyle.Fill; //판넬크기에 맞게 사이즈 늘림.
            //panel1.Controls.Add(Child1);

            //Child2.Show();
            //Child1.Show();
            //Child1.Dispose();

            //Set the Parent Form of the Child window.
            user1.TopLevel = false;
            user1.TopMost = true;
            user1.MdiParent = this;
            user1.Dock = DockStyle.Fill; //판넬크기에 맞게 사이즈 늘림.
            panel1.Controls.Add(user1);
            
            user2.TopLevel = false;
            user2.TopMost = true;
            user2.MdiParent = this;
            user2.Dock = DockStyle.Fill; //판넬크기에 맞게 사이즈 늘림.
            panel1.Controls.Add(user2);

            user3.TopLevel = false;
            user3.TopMost = true;
            user3.MdiParent = this;
            user3.Dock = DockStyle.Fill; //판넬크기에 맞게 사이즈 늘림.
            panel1.Controls.Add(user3);

            user4.TopLevel = false;
            user4.TopMost = true;
            user4.MdiParent = this;
            user4.Dock = DockStyle.Fill; //판넬크기에 맞게 사이즈 늘림.
            panel1.Controls.Add(user4);


            Login = new LOGIN_FORM(this);
            Login.TopLevel = false;
            Login.TopMost = true;
            Login.MdiParent = this;
            Login.Dock = DockStyle.Fill; //판넬크기에 맞게 사이즈 늘림.
            panel1.Controls.Add(Login);

            Signup.TopLevel = false;
            Signup.TopMost = true;
            Signup.MdiParent = this;
            Signup.Dock = DockStyle.Fill; //판넬크기에 맞게 사이즈 늘림.
            panel1.Controls.Add(Signup);

        }

        

        private void Logo_Load()
        {
            pictureBox = new PictureBox();

            pictureBox.Image = (Bitmap)WindowsFormsApp.Properties.Resources.ResourceManager.GetObject("hlc11");
            pictureBox.Location = new Point(1500-360, 0);
            pictureBox.Size = new Size(360, 100);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            //pictureBox.Paint += new PaintEventHandler(this.pictureBox1_Paint);
            Controls.Add(pictureBox);
        }

        private void btn1_Click(Object o, EventArgs e)
        {
            user1.Show();
            user2.Hide();
            user3.Hide();
            user4.Hide();
            Login.Hide();
            Signup.Hide();

        }

        private void btn2_Click(Object o, EventArgs e)
        {

            user2.Show();
            user1.Hide();
            user3.Hide();
            user4.Hide();
            Login.Hide();
            Signup.Hide();
        }

        private void btn3_Click(Object o, EventArgs e)
        {
            user3.Show();
            user2.Hide();
            user1.Hide();
            user4.Hide();
            Login.Hide();
            Signup.Hide();

        }

        private void btn4_Click(Object o, EventArgs e)
        {
            user4.Show();
            user2.Hide();
            user3.Hide();
            user1.Hide();
            Login.Hide();
            Signup.Hide();

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
        //로긴 회원 =======================================================================================
        private void label_Click(Object o, EventArgs e)//로긴
        {
            user1.Hide();
            user2.Hide();
            user3.Hide();
            user4.Hide();
            Login.Show();
            Signup.Hide();
        }

        private void label2_Click(object sender, EventArgs e)//회원
        {
            user1.Hide();
            user2.Hide();
            user3.Hide();
            user4.Hide();
            Login.Hide();
            Signup.Show();
        }
        //===============================================================================================
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

        private void pictureBox1_Paint(Object o, PaintEventArgs e)
        {
            e.Graphics.DrawString(lb_Login.Text, lb_Login.Font, new SolidBrush(lb_Login.ForeColor), lb_Login.Left - pictureBox.Left, lb_Login.Top - pictureBox.Top);
            e.Graphics.DrawString(lb_Signup.Text, lb_Login.Font, new SolidBrush(lb_Signup.ForeColor), lb_Signup.Left - pictureBox.Left, lb_Signup.Top - pictureBox.Top);
        }


        private void picturbox_Click(Object o, EventArgs e)
        {
            
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