using MySql.Data.MySqlClient;
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


    public partial class LOGIN_FORM : Form
    {
        MAIN_FORM form;
        public BOOK_INFO_FORM user1;
        public static int member_rank = 4; // 0 관리자 / 1 유저 / 4 비회원
        public static int user_Number;
        
        public LOGIN_FORM(MAIN_FORM form)
        {
            InitializeComponent();
            this.form = form;
            Load += LOGIN_FORM_Load;
        }
        int sX = 1500, sY = 800; // 폼 사이즈 지정.

        ///////// 좌표 체크시 추가 /////////
        static ToolStripStatusLabel StripLb;
        StatusStrip statusStrip;
        ///////////////////////////////////

        TextBox Tb1, Tb2 = new TextBox();//텍스트박스 
        Panel pan1 = new Panel();

        private void LOGIN_FORM_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;// 폼 상단 표시줄 제거

            COMMON_Create_Ctl comm = new COMMON_Create_Ctl();
            this.BackColor = Color.FromArgb(201, 253, 223); //백컬러
            Point_Print(); //좌표 
            ClientSize = new Size(sX, sY);  // 폼 사이즈 지정.
            //라벨 ==============================================================================================================================================
            ArrayList lbarray = new ArrayList();
            lbarray.Add(new LBclass(this, "lb_Login", "로그인", 20, 150, 50, 180, 50, label_Click));
            lbarray.Add(new LBclass(this, "lb_ID", "아이디", 10, 80, 20, 80, 250, label_Click));
            lbarray.Add(new LBclass(this, "lb_Pass", "비밀번호", 10, 80, 20, 80, 300, label_Click));

            for (int i = 0; i < lbarray.Count; i++)
            {

                Label lb = comm.lb((LBclass)lbarray[i]);

                if (lb.Name == "lb_Login")
                {
                    lb.Font = new Font("견명조", 32F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));
                }

                pan1.Controls.Add(lb);
            }
            //=================================================================================================================================================



            Tb1 = comm.txtbox(new TXTBOXclass(this, "ID", "", 150, 20, 175, 245, Tb_click));
            Tb2 = comm.txtbox(new TXTBOXclass(this, "Pass", "", 150, 20, 175, 295, Tb_click));
            pan1.Controls.Add(Tb1);
            pan1.Controls.Add(Tb2);


            //=================================================================================================================================================

            
            pan1.Height = 600;
            pan1.Width = 500;
            pan1.Location = new Point(470, 120);
            pan1.BackColor = Color.FromArgb(218, 234, 244);
            

            Controls.Add(pan1);
            //==================================================================================================================================================
            // BTNclass bt1 = new BTNclass(this, "버튼Name", "버튼Text", 가로사이즈, 세로사이즈, 가로포인트, 세로포인트, 버튼클릭이벤트);
            ArrayList btnArray = new ArrayList();
            btnArray.Add(new BTNclass(this, "로그인", "로그인", 80, 80, 345, 240, btn1_Click));
            btnArray.Add(new BTNclass(this, "회원가입", "회원가입", 80, 40, 345, 320, btn2_Click));
            btnArray.Add(new BTNclass(this, "뒤로가기", "←", 50, 40, 450, 0, btn3_Click));



            for (int i = 0; i < btnArray.Count; i++)
            {
                Button btn = comm.btn((BTNclass)btnArray[i]);

                if (btn.Name == "로그인")
                {
                    btn.Font = new Font("견명조", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));  // FontStyle.Regular
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.ForeColor = Color.LawnGreen;
                    btn.BackColor = Color.ForestGreen;
                }
                else if (btn.Name == "뒤로가기")
                {
                    btn.Font = new Font("견명조", 15F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));  // FontStyle.Regular
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.ForeColor = Color.LawnGreen;
                    btn.BackColor = Color.ForestGreen;
                }
                pan1.Controls.Add(btn);
            }
            //=================================================================================================================================================
        }

        private void Tb_click(object sender, EventArgs e)
        {
            
        }

        private void label_Click(object sender, EventArgs e)
        {
            
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            
            if (Tb1.Text == ID_Select(Tb1.Text) && Tb2.Text == PW_Select(Tb2.Text))
            {
                MessageBox.Show("로그인 성공");

                MySql my = new MySql();
                string sql = string.Format("select user_number, member_rank from signup where id = '{0}';", Tb1.Text);
                MySqlDataReader sdr = my.Reader(sql);
                while (sdr.Read())
                {
                    user_Number = Convert.ToInt32(sdr.GetValue(0).ToString());
                    member_rank = Convert.ToInt32(sdr.GetValue(1).ToString());
                    MessageBox.Show(sdr.GetValue(1).ToString());
                }

                this.Close();
                if(member_rank == 1)
                {
                    form.user1.Show();
                    form.btn1.Show();
                    form.btn2.Show();
                    form.btn3.Show();
                    form.btn.Show();
                    form.Login.Hide();
                    form.Signup.Hide();

                    if (member_rank == 4)
                    {
                        form.lb_Login.Show();
                        form.lb_Signup.Show();
                    }
                    else
                    {
                        form.lb_Login.Hide();
                        form.lb_Signup.Hide();
                    }
                }
                if (member_rank == 0)
                {
                    form.user1.Hide();
                    form.user1.Dispose();
                    BOOK_INFO_FORM login_user1 = new BOOK_INFO_FORM(form);
                    //user1.FormBorderStyle = FormBorderStyle.None;
                    login_user1.TopLevel = false;
                    login_user1.TopMost = true;
                    login_user1.MdiParent = form;
                    login_user1.Dock = DockStyle.Fill; //판넬크기에 맞게 사이즈 늘림.
                    form.panel1.Controls.Add(login_user1);
                    form.user1 = login_user1;

                    form.user1.Show();
                    form.btn5.Show();
                    form.btn6.Show();
                    form.btn7.Show();
                    form.btn.Show();
                    form.Login.Hide();
                    form.Signup.Hide();

                    if (member_rank == 4)
                    {
                        form.lb_Login.Show();
                        form.lb_Signup.Show();
                    }
                    else
                    {
                        form.lb_Login.Hide();
                        form.lb_Signup.Hide();
                    }
                }


            }

            else MessageBox.Show("아이디 또는 비밀번호가 틀립니다.");
        }

        public int Member_rank
        {
            get
            {
                return member_rank;
            }
            //set
            //{
            //    member_rank = value;
            //}
        }

        public int User_Number
        {
            get
            {
                return user_Number;
            }
            //set
            //{
            //    user_Number = value;
            //}
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            
        }

        private void btn3_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        public void Login_Select(string Idtext)
        {
            
        }

        public string ID_Select(string Idtext)
        {
            string i = ".";
            MySql my = new MySql();
            string  sql = string.Format("select id from signup where id = '{0}';",Idtext);
            MySqlDataReader sdr = my.Reader(sql);
            while (sdr.Read())
            {
                i = sdr.GetValue(0).ToString();
            }
            return i;
        }



        public string PW_Select(string PWtext)
        {
            string p = ".";
            string sql;
            MySql my = new MySql();
            sql = string.Format("select passwod from signup where passwod = '{0}';", PWtext);
            MySqlDataReader sdr = my.Reader(sql);
            while (sdr.Read())
            {
                p = sdr.GetValue(0).ToString();
            }
            return p;
        }

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
        private void Current_FORM_MouseMove(object sender, MouseEventArgs e)
        {
            StripLb.Text = "(" + e.X + ", " + e.Y + ")";
        }
    }
}
