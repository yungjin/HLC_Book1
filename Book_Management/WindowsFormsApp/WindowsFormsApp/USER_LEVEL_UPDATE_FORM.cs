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

    public partial class USER_LEVEL_UPDATE_FORM : Form
    {
        int sX = 800, sY = 450; // 폼 사이즈 지정.

        ///////// 좌표 체크시 추가 /////////
        static ToolStripStatusLabel StripLb;
        StatusStrip statusStrip;
        ///////////////////////////////////

        COMMON_Create_Ctl comm = new COMMON_Create_Ctl();

        private OpenFileDialog openFileDialog1 = new OpenFileDialog();  // openFileDialog1 변수 선언 및 초기화
        public static string _Slected_File_RootPath;
        PictureBox 책이미지;
        TextBox 텍스트박스;

        TextBox 회원등급값;
        TextBox 회원ID값;
        TextBox 회원이름값;
        TextBox 회원번호값;
        TextBox 연락처값;

        string 회원등급Temp값;
        string 회원IDTemp값;
        string 회원이름Temp값;
        string 회원번호Temp값;
        string 연락처Temp값;

        RadioButton 관리자라디오버튼;
        RadioButton 회원라디오버튼;

        string user_number;

        public USER_LEVEL_UPDATE_FORM()
        {
            InitializeComponent();

            Load += USER_LEVEL_UPDATE_FORM_Load;
        }

        public USER_LEVEL_UPDATE_FORM(string user_number)
        {
            InitializeComponent();

            this.user_number = user_number;
            Load += USER_LEVEL_UPDATE_FORM_Load;
        }

        private void USER_LEVEL_UPDATE_FORM_Load(object sender, EventArgs e)
        {
            this.Paint += new PaintEventHandler(this.Form_Paint);

            //FormBorderStyle = FormBorderStyle.None; 폼 상단 표시줄 제거

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





            // 회원등급 수정 고정라벨
            ArrayList arry = new ArrayList();
            arry.Add(new LBclass(this, "회원등급제목", "회원 등급 수정", 17, 200, 30, 30, 30, label_Click));
            arry.Add(new LBclass(this, "회원등급", "회원 등급", 17, 140, 30, 30, 115, label_Click));
            arry.Add(new LBclass(this, "회원ID", "회원 ID", 17, 140, 30, 30, 175, label_Click));
            arry.Add(new LBclass(this, "회원이름", "회원 이름", 17, 140, 30, 30, 235, label_Click));
            arry.Add(new LBclass(this, "회원번호", "회원 번호", 17, 140, 30, 30, 295, label_Click));
            arry.Add(new LBclass(this, "연락처", "연락처", 17, 140, 40, 30, 355, label_Click));
            arry.Add(new LBclass(this, "", ":", 12, 30, 40, 210, 115, label_Click));
            arry.Add(new LBclass(this, "", ":", 12, 30, 40, 210, 175, label_Click));
            arry.Add(new LBclass(this, "", ":", 12, 30, 40, 210, 235, label_Click));
            arry.Add(new LBclass(this, "", ":", 12, 30, 40, 210, 295, label_Click));
            arry.Add(new LBclass(this, "", ":", 12, 30, 40, 210, 355, label_Click));

            for (int i = 0; i < arry.Count; i++)
            {
                Label label = comm.lb((LBclass)arry[i]);

                label.Font = new Font(label.Font.Name, 20, FontStyle.Bold);


                Controls.Add(label);
            }


            MySql mysql = new MySql();
            ArrayList userinfoSearch_arry = mysql.Select(string.Format("select * from signup where user_number = {0}", user_number));
            foreach (Hashtable ht in userinfoSearch_arry)
            {
                회원등급Temp값 = ht["member_rank"].ToString();
                회원IDTemp값 = ht["id"].ToString();
                회원이름Temp값 = ht["name"].ToString();
                회원번호Temp값 = ht["user_number"].ToString();
                연락처Temp값 = ht["phone_number"].ToString();
            }


            // 회원등급 TextBox 변동값
            ArrayList userinfoArry = new ArrayList();
            userinfoArry.Add(new TXTBOXclass(this, "회원등급값", "회원등급값", 250, 40, 250, 110, txtbox_Click));
            userinfoArry.Add(new TXTBOXclass(this, "회원ID값", "회원ID값", 250, 40, 250, 170, txtbox_Click));
            userinfoArry.Add(new TXTBOXclass(this, "회원이름값", "회원이름값", 250, 40, 250, 230, txtbox_Click));
            userinfoArry.Add(new TXTBOXclass(this, "회원번호값", "회원번호값", 250, 40, 250, 290, txtbox_Click));
            userinfoArry.Add(new TXTBOXclass(this, "연락처값", "연락처값", 250, 40, 250, 350, txtbox_Click));

            for (int i = 0; i < userinfoArry.Count; i++)
            {
                TextBox textBox = comm.txtbox((TXTBOXclass)userinfoArry[i]);
                textBox.ReadOnly = true;
                textBox.Font = new Font(textBox.Font.Name, 18, FontStyle.Bold);

                if (textBox.Name == "회원등급값")
                {
                    if (회원등급Temp값 == "0")
                    {
                        textBox.Text = "관리자";
                    }
                    else if (회원등급Temp값 == "1")
                    {
                        textBox.Text = "일반회원";
                    }
                    else
                    {
                        textBox.Text = "비회원";
                    }

                    
                }
                else if (textBox.Name == "회원ID값")
                {
                    textBox.Text = 회원IDTemp값;
                }
                else if (textBox.Name == "회원이름값")
                {
                    textBox.Text = 회원이름Temp값;
                }
                else if (textBox.Name == "회원번호값")
                {
                    textBox.Text = 회원번호Temp값;
                }
                else if (textBox.Name == "연락처값")
                {
                    textBox.Text = 연락처Temp값;
                }

                Controls.Add(textBox);
            }


            // 권한 선택 - 라디오 버튼
            ArrayList radio_arry = new ArrayList();
            radio_arry.Add(new RADIOclass(this, "관리자권한", "관리자 권한", 250, 40, 570, 160, radio_btn_Click));
            radio_arry.Add(new RADIOclass(this, "회원권한", "회원 권한", 250, 40, 570, 255, radio_btn_Click));

            for (int i = 0; i < radio_arry.Count; i++)
            {
                RadioButton 권한선택라디오 = comm.radio_btn((RADIOclass)radio_arry[i]);

                권한선택라디오.Font = new Font(권한선택라디오.Font.Name, 20, FontStyle.Bold);
                Controls.Add(권한선택라디오);

                if (권한선택라디오.Name == "관리자권한")
                {
                    관리자라디오버튼 = 권한선택라디오;

                }
                else if (권한선택라디오.Name == "회원권한")
                {
                    회원라디오버튼 = 권한선택라디오;

                }
            }


            // 권한 선택 - 설정 버튼
            ArrayList btn_arry = new ArrayList();
            btn_arry.Add(new BTNclass(this, "설정완료", "설정 완료", 100, 40, 570, 345, btn_Click));
            btn_arry.Add(new BTNclass(this, "취소", "취 소", 100, 40, 680, 345, btn_Click));

            for (int i = 0; i < btn_arry.Count; i++)
            {
                Button 권한설정버튼 = comm.btn((BTNclass)btn_arry[i]);

                권한설정버튼.BackColor = Color.FromArgb(50, 178, 223);
                권한설정버튼.Font = new Font(권한설정버튼.Font.Name, 12, FontStyle.Bold);
                권한설정버튼.FlatStyle = FlatStyle.Flat;
                권한설정버튼.ForeColor = Color.White;
                권한설정버튼.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, 권한설정버튼.Width, 권한설정버튼.Height, 10, 10));
                Controls.Add(권한설정버튼);
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
            //MessageBox.Show("동작확인 : btn_Click");

            Button button = (Button)o;

            if (button.Name == "설정완료")
            {
                if(관리자라디오버튼.Checked == false && 회원라디오버튼.Checked == false)
                {
                    MessageBox.Show("회원의 권한을 선택해주세요");
                }

                //MessageBox.Show("설정완료");
                if (관리자라디오버튼.Checked == true)
                {
                    MessageBox.Show("관리자 권한 변경 완료");
                    MySql mysql = new MySql();                   
                    mysql.NonQuery_INSERT(string.Format("update signup set member_rank = 0 where user_number = {0};", 회원번호Temp값));
                }
                else if (회원라디오버튼.Checked == true)
                {
                    MessageBox.Show("회원 권한 변경 완료");
                    MySql mysql = new MySql();  
                    mysql.NonQuery_INSERT(string.Format("update signup set member_rank = 1 where user_number = {0};", 회원번호Temp값));
                }

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
            MessageBox.Show("동작확인 : txtbox_Click");
        }

        private void chkbox_Click(Object o, EventArgs e)
        {
            MessageBox.Show("동작확인 : chkbox_Click2");
        }

        private void radio_btn_Click(Object o, EventArgs e)
        {
            //MessageBox.Show("동작확인 : radio_btn_Click");

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


        private void Image_Select()
        {
            try
            {
                OpenFileDialog openFileDlg = new OpenFileDialog();
                openFileDlg.DefaultExt = "jpg";
                openFileDlg.Title = "이미지 업로드";
                openFileDlg.Filter = "이미지 파일|*.jpg|png 파일|*.png";
                openFileDialog1.FileName = "";
                openFileDlg.ShowDialog();
                if (openFileDlg.FileName.Length > 0)
                {
                    foreach (string file_root in openFileDlg.FileNames)
                    {
                        _Slected_File_RootPath = file_root;
                        string fileName = _Slected_File_RootPath.Substring(_Slected_File_RootPath.LastIndexOf("\\") + 1);

                        //MessageBox.Show("_Slected_File_RootPath : " + _Slected_File_RootPath + ", fileName : " + fileName);

                        comm.UploadFTPFile(_Slected_File_RootPath, fileName);
                        책이미지.ImageLocation = "http://ljh5432.iptime.org:81/ImageCollection/" + fileName; // fileName : FTP에서 불러올 파일 이름.
                        텍스트박스.Text = fileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("이미지 지정 실패");
            }
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

        private void Form_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0), 2);
            e.Graphics.DrawLine(pen, 30, 70, 770, 70);
        }
    }
}