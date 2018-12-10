﻿using System;
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
    public partial class SIGNUP_FORM : Form
    {
        int sX = 500, sY = 700; // 폼 사이즈 지정.

        ///////// 좌표 체크시 추가 /////////
        static ToolStripStatusLabel StripLb;
        StatusStrip statusStrip;
        ///////////////////////////////////

        public SIGNUP_FORM()
        {
            InitializeComponent();
            Load += SIGNUP_FORM_Load;
        }

        private void SIGNUP_FORM_Load(object sender, EventArgs e)
        {


            ClientSize = new Size(sX, sY);  // 폼 사이즈 지정.

            /// 좌표 체크시 추가 ///
            Point_Print();

            COMMON_Create_Ctl comm = new COMMON_Create_Ctl();
            ArrayList lbarray = new ArrayList();
            ArrayList Tbarray = new ArrayList();
            ArrayList btnArray = new ArrayList();
            lbarray.Add(new LBclass(this, "lb1", "회원가입", 18, 200, 40,90, 10, label_Click));
            lbarray.Add(new LBclass(this, "lb_ID", "아이디", 10, 150, 20, 20, 60, label_Click));
            lbarray.Add(new LBclass(this, "lb_Pass", "비밀번호", 10, 150, 20, 20, 120, label_Click));
            lbarray.Add(new LBclass(this, "lb_PassCon", "비밀번호 확인", 10, 50, 20, 20, 180, label_Click));
            lbarray.Add(new LBclass(this, "lb_Name", "이름", 10, 150, 20, 20, 240, label_Click));
            lbarray.Add(new LBclass(this, "lb_Gender", "성별", 10, 150, 20, 20, 300, label_Click));
            lbarray.Add(new LBclass(this, "lb_Birth", "생일", 10, 150, 20, 20, 360, label_Click));
            lbarray.Add(new LBclass(this, "lb_email", "이메일", 10, 150, 20, 20, 420, label_Click));
            lbarray.Add(new LBclass(this, "lb_Phon", "휴대폰 번호", 10, 150, 20, 20, 480, label_Click));
            lbarray.Add(new LBclass(this, "lb_addres", "주소", 10, 150, 20, 20, 540, label_Click));

            Tbarray.Add(new TXTBOXclass(this, "ID", "", 150, 20, 40, 60, Tb_click));
            Tbarray.Add(new TXTBOXclass(this, "Pass", "", 150, 20, 40, 60, Tb_click));
            Tbarray.Add(new TXTBOXclass(this, "PassCon", "", 150, 20, 40, 60, Tb_click));
            Tbarray.Add(new TXTBOXclass(this, "ID", "", 150, 20, 40, 60, Tb_click));
            Tbarray.Add(new TXTBOXclass(this, "ID", "", 150, 20, 40, 60, Tb_click));
            Tbarray.Add(new TXTBOXclass(this, "ID", "", 150, 20, 40, 60, Tb_click));
            Tbarray.Add(new TXTBOXclass(this, "ID", "", 150, 20, 40, 60, Tb_click));
            Tbarray.Add(new TXTBOXclass(this, "ID", "", 150, 20, 40, 60, Tb_click));
            Tbarray.Add(new TXTBOXclass(this, "ID", "", 150, 20, 40, 60, Tb_click));


            // BTNclass bt1 = new BTNclass(this, "버튼Name", "버튼Text", 가로사이즈, 세로사이즈, 가로포인트, 세로포인트, 버튼클릭이벤트);

            btnArray.Add(new BTNclass(this, "가입", "가입", 100, 50, 100, 580, btn1_Click));
            btnArray.Add(new BTNclass(this, "닫기", "닫기", 100, 50, 300, 580, btn2_Click));

            for (int i = 0; i < btnArray.Count; i++)
            {
                Button btn = comm.btn((BTNclass)btnArray[i]);

                if (btn.Name == "가입")
                {
                    btn.Font = new Font("견명조", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));  // FontStyle.Regular
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.ForeColor = Color.LawnGreen;
                    btn.BackColor = Color.ForestGreen;
                }
                else if (btn.Name == "닫기")
                {
                    btn.Font = new Font("견명조", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));  // FontStyle.Regular
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.ForeColor = Color.LawnGreen;
                    btn.BackColor = Color.ForestGreen;
                }
                Controls.Add(btn);
            }

            for (int i = 0; i < lbarray.Count; i++)
            {
                Label lb = comm.lb((LBclass)lbarray[i]);

                Controls.Add(lb);
            }
            
        }

        private void Tb_click(object sender, EventArgs e)
        {
            
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            

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

        private void label_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
