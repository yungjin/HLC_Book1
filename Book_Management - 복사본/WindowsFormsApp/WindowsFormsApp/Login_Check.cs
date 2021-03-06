﻿using System;
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
    public partial class Login_Check : Form
    {
        BOOK_INFO_FORM form;
        int sX = 490, sY = 240; // 폼 사이즈 지정.
        public Login_Check(BOOK_INFO_FORM form)
        {
            InitializeComponent();
            this.form = form;
            Load += Login_Check_Load;
        }
        Panel pan1 = new Panel();
        private void Login_Check_Load(object sender, EventArgs e)
        {
            COMMON_Create_Ctl comm = new COMMON_Create_Ctl();
            ClientSize = new Size(sX, sY);  // 폼 사이즈 지정.
            //FormBorderStyle = FormBorderStyle.None;// 폼 상단 표시줄 제거
            this.BackColor = Color.FromArgb(218, 234, 244); //백컬러
            Label lb = comm.lb(new LBclass(this, "messeg", "로그인이 필요한 서비스 입니다.", 15, 300, 50, 85, 80 - 20, label_Click));

            Button btn = comm.btn(new BTNclass(this, "확인", "확인", 70, 40, 200, 110, btn1_Click));
            btn.Font = new Font("견명조", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));  // FontStyle.Regular
            btn.FlatStyle = FlatStyle.Flat;
            btn.ForeColor = Color.White;
            btn.BackColor = Color.FromArgb(80, 200, 223);
            btn.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, btn.Width, btn.Height, 15, 15));
            btn.BackColor = Color.FromArgb(114, 241, 168);  // rgb(218,234,244)
            btn.BackColor = Color.FromArgb(114, 241, 168);  // rgb(218,234,244)

            //pan1.Height = 50;
            //pan1.Width = 50;
            //pan1.Location = new Point(5, 55);
            //pan1.BackColor = Color.FromArgb(218, 234, 244);

            Controls.Add(btn);
            Controls.Add(lb);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label_Click(object sender, EventArgs e)
        {
            
        }
    }
}
