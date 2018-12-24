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
    public partial class REQUEST_BOOK_FORM : Form
    {
        int sX = 580, sY = 480; // 폼 사이즈 지정.

        ///////// 좌표 체크시 추가 /////////
        static ToolStripStatusLabel StripLb;
        StatusStrip statusStrip;
        ///////////////////////////////////

        TextBox Textbox1;
        TextBox Textbox2;
        TextBox Textbox3;
        TextBox Textbox4;


        public REQUEST_BOOK_FORM()
        {
            InitializeComponent();

            Load += REQUEST_BOOK_FORM_Load;
        }

        private void REQUEST_BOOK_FORM_Load(object sender, EventArgs e)
        {
            // 테두리 색깔 추가
            this.Paint += new PaintEventHandler(UserControl1_Paint);


            //(좌측상단여백, 우측상단여백, 컨트롤 넓이, 컨트롤 높이, 가로 모서리 원기울기, 세로 모서리 원기울기)
            //this.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, this.Width, this.Height, 15, 15));

            FormBorderStyle = FormBorderStyle.None; //폼 상단 표시줄 제거

            this.BackColor = Color.FromArgb(218, 234, 244);

            ClientSize = new Size(sX, sY);  // 폼 사이즈 지정.

            /// 좌표 체크시 추가 ///
            //Point_Print();

            COMMON_Create_Ctl create_ctl = new COMMON_Create_Ctl();

            // BTNclass bt1 = new BTNclass(this, "버튼Name", "버튼Text", 가로사이즈, 세로사이즈, 가로포인트, 세로포인트, 버튼클릭이벤트);
            BTNclass bt1 = new BTNclass(this, "Home", "button1", 100, 100, 10, 10, btn_Click);
            // LBclass lb1 = new LBclass(this, "라벨Name", "라벨Text", 라벨Font사이즈, 가로사이즈, 세로사이즈, 가로포인트, 세로포인트, 라벨클릭이벤트);
            LBclass lb1 = new LBclass(this, "label1", "label_name~", 24, 100, 100, 10, 10, label_Click);
            // PANELclass pn1 = new PANELclass(this, "패널Name", "패널Text", 가로사이즈, 세로사이즈, 가로포인트, 세로포인트, 패널마우스이동이벤트);
            PANELclass pn1 = new PANELclass(this, "panel1", "panel_txt~", 200, 200, 100, 100, panel_MouseMove);
            // TABCTLclass tabctl = new TABCTLclass(this, "탭컨트롤Name", "탭컨트롤Text", 가로사이즈, 세로사이즈, 가로포인트, 세로포인트, 탭높이, 탭컨트롤마우스이동이벤트);
            TABCTLclass tabctl = new TABCTLclass(this, "tabctl1", "tabctl1~", 450, 160, 7, 313, 30, tabctl_MouseMove);
            // TABPAGEclass tabpg1 = new TABPAGEclass(this, "탭페이지Name", "탭페이지Text", 가로사이즈, 세로사이즈, 가로포인트, 세로포인트, 탭페이지마우스이동이벤트);
            TABPAGEclass tabpg1 = new TABPAGEclass(this, "tabpage1", "tapage1~", 100, 100, 0, 0, tabpage_MouseMove);
            // CHKBOXclass bhkbox1 = new CHKBOXclass(this, "체크박스Name", 체크박스Text", 가로사이즈, 세로사이즈, 가로포인트, 세로포인트, 체크박스클릭이벤트);
            CHKBOXclass chkbox1 = new CHKBOXclass(this, "chkbox1", "chkbox1~", 100, 100, 20, 20, chkbox_Click);
            // LISTVIEWclass listview1 = new LISTVIEWclass(this, "리스트뷰Name", 가로사이즈, 세로사이즈, 가로포인트, 세로포인트, 리스트뷰더블클릭이벤트, 컬럼갯수, "컬럼1번Name", 컬럼1간격, "컬럼2번Name", 컬럼2간격, "컬럼3번Name", 컬럼3간격, ~ 동일방식 10개 컬럼까지 가능);
            LISTVIEWclass listview1 = new LISTVIEWclass(this, "ListView1", 500, 500, 10, 10, listview_mousedoubleclick, listview_mousedoubleclick, 3, "col1", 100, "col2", 100, "col3", 100);
            // COMBOBOXclass combobox1 = new COMBOBOXclass(this, "콤보박스Name", 가로사이즈, 세로사이즈, 가로포인트, 세로포인트, 콤보박스클릭이벤트, 리스트추가갯수, "test1", "test2", "test3", "test4", "test5");
            COMBOBOXclass combobox1 = new COMBOBOXclass(this, "ComboBox1", 100, 100, 721, 12, ComboBox_SelectedIndexChanged, 5, "test1", "test2", "test3", "test4", "test5");

            COMMON_Create_Ctl comm = new COMMON_Create_Ctl();

            /// 라벨 ArrayList
            ArrayList labelArr = new ArrayList();
            labelArr.Add(new LBclass(this, "입고요청상단", "입고 요청", 26, 200, 40, 40, 40, label_Click));
            labelArr.Add(new LBclass(this, "제목", "제목", 20, 80, 40, 46, 130, label_Click));
            labelArr.Add(new LBclass(this, "저자", "저자", 20, 80, 40, 46, 180, label_Click));
            labelArr.Add(new LBclass(this, "출판사", "출판사", 20, 80, 40, 46, 230, label_Click));
            labelArr.Add(new LBclass(this, "장르", "장르", 20, 80, 40, 46, 280, label_Click));
            labelArr.Add(new LBclass(this, "", ":", 20, 20, 30, 140, 130, label_Click));
            labelArr.Add(new LBclass(this, "", ":", 20, 20, 30, 140, 180, label_Click));
            labelArr.Add(new LBclass(this, "", ":", 20, 20, 30, 140, 230, label_Click));
            labelArr.Add(new LBclass(this, "", ":", 20, 20, 30, 140, 280, label_Click));

            for (int i = 0; i < labelArr.Count; i++)
            {
                Label 라벨 = comm.lb((LBclass)labelArr[i]);

                if (라벨.Name == "입고요청상단")
                {
                    라벨.Font = new Font("신명조", 30, FontStyle.Bold);
                }
                else
                {
                    라벨.Font = new Font("신명조", 20, FontStyle.Bold);
                }
                Controls.Add(라벨);
            }

            // 텍스트박스 ArrayList
            ArrayList TextBoxArr = new ArrayList();
            TextBoxArr.Add(new TXTBOXclass(this, "입고텍스트제목", "", 330, 40, 200, 135, txtbox_Click));
            TextBoxArr.Add(new TXTBOXclass(this, "입고텍스트저자", "", 330, 40, 200, 185, txtbox_Click));
            TextBoxArr.Add(new TXTBOXclass(this, "입고텍스트출판사", "", 330, 40, 200, 235, txtbox_Click));
            TextBoxArr.Add(new TXTBOXclass(this, "입고텍스트장르", "", 330, 40, 200, 285, txtbox_Click));

            for (int i = 0; i < TextBoxArr.Count; i++)
            {
                TextBox 텍스트박스 = comm.txtbox((TXTBOXclass)TextBoxArr[i]);
                텍스트박스.Font = new Font(텍스트박스.Font.Name, 15, FontStyle.Bold);

                if (텍스트박스.Name == "입고텍스트제목")
                {
                    Textbox1 = 텍스트박스;
                }
                else if (텍스트박스.Name == "입고텍스트저자")
                {
                    Textbox2 = 텍스트박스;
                }
                else if (텍스트박스.Name == "입고텍스트출판사")
                {
                    Textbox3 = 텍스트박스;
                }
                else if (텍스트박스.Name == "입고텍스트장르")
                {
                    Textbox4 = 텍스트박스;
                }

                Controls.Add(텍스트박스);
            }


            ArrayList btnArray = new ArrayList();
            btnArray.Add(new BTNclass(this, "등록", "등록", 120, 50, 280, 380, btn_Click));
            btnArray.Add(new BTNclass(this, "취소", "취소", 120, 50, 415, 380, btn_Click));

            for (int i = 0; i < btnArray.Count; i++)
            {
                Button 버튼 = comm.btn((BTNclass)btnArray[i]);

                버튼.Font = new Font("견명조", 24F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));  // FontStyle.Regular                
                버튼.BackColor = Color.FromArgb(50, 178, 223);
                버튼.FlatStyle = FlatStyle.Flat;
                버튼.ForeColor = Color.White;
                버튼.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, 버튼.Width, 버튼.Height, 18, 18));

                Controls.Add(버튼);
            }

        }


        private void listview_mousedoubleclick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("동작확인 : listview_mousedoubleclick");
        }

        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("동작확인 : listView_MouseClick");
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_Click(Object o, EventArgs e)
        {
            Button button = (Button)o;

            ///  버튼 설정. 
            if (button.Name == "등록")
            {
                if (Textbox1.Text == "" || Textbox2.Text == "" || Textbox3.Text == "" || Textbox4.Text == "")
                {
                    MessageBox.Show("입력칸을 모두 채워주세요");
                    return;
                }

                LOGIN_FORM login = new LOGIN_FORM();

                MySql mysql = new MySql();
                string sql = string.Format("insert into Receiving_equest(title, author, publisher, genre, user_number) values('{0}', '{1}', '{2}', '{3}', {4});", Textbox1.Text, Textbox2.Text, Textbox3.Text, Textbox4.Text, login.User_Number); // 1 : 입고 요청한 user_number 로 등록되도록 변경 필요. 
                mysql.NonQuery_INSERT(sql);
            }
            else if (button.Name == "취소")
            {
                this.Close();
            }
        }

        private void label_Click(Object o, EventArgs e)
        {
            MessageBox.Show("동작확인 : label_Click");
        }

        private void txtbox_Click(Object o, EventArgs e)
        {
            return;
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
        private void Current_FORM_MouseMove(object sender, MouseEventArgs e)
        {
            StripLb.Text = "(" + e.X + ", " + e.Y + ")";
        }
        ///////////////////////////////////////////////////////////////////////
        ///


        // 테두리 색상 추가
        private void UserControl1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }


    }
}