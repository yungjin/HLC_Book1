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
    public partial class USER_INFO_FORM : Form
    {
        int sX = 1500, sY = 800; // 폼 사이즈 지정.

        ///////// 좌표 체크시 추가 /////////
        static ToolStripStatusLabel StripLb;
        StatusStrip statusStrip;
        ///////////////////////////////////

        COMMON_Create_Ctl comm = new COMMON_Create_Ctl();

        private OpenFileDialog openFileDialog1 = new OpenFileDialog();  // openFileDialog1 변수 선언 및 초기화
        public static string _Slected_File_RootPath;
        PictureBox 책이미지;
        TextBox 텍스트박스;
        TextBox 회원번호값;
        TextBox 연락처값;
        TextBox 이름값;
        TextBox ID값;
        TextBox 블랙리스트값;
        string search_category = "";
        TextBox 회원정보검색상자;
        ListView 회원정보검색_리스트뷰;
        ListView 대여목록_리스트뷰;
        MySql mysql;
        string sql;

        public USER_INFO_FORM()
        {
            InitializeComponent();

            Load += USER_INFO_FORM_Load;
        }

        private void USER_INFO_FORM_Load(object sender, EventArgs e)
        {
            this.Paint += new PaintEventHandler(this.Form_Paint);


            FormBorderStyle = FormBorderStyle.None; //폼 상단 표시줄 제거

            this.BackColor = Color.FromArgb(201, 253, 223);

            ClientSize = new Size(sX, sY);  // 폼 사이즈 지정.

            /// 좌표 체크시 추가 ///
            //Point_Print();

            COMMON_Create_Ctl create_ctl = new COMMON_Create_Ctl();

            create_ctl.delay_rental_check();

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

            // 회원정보패널
            PANELclass 회원정보패널값 = new PANELclass(this, "회원정보패널", "회원정보패널", 700, 300, 20, 20, panel_MouseMove);
            Panel 회원정보패널 = comm.panel(회원정보패널값);

            회원정보패널.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, 회원정보패널.Width, 회원정보패널.Height, 15, 15));
            회원정보패널.BackColor = Color.FromArgb(218, 234, 244);  // rgb(218,234,244)
            Controls.Add(회원정보패널);


            // 회원정보패널 고정라벨
            ArrayList arry = new ArrayList();
            arry.Add(new LBclass(this, "회원번호", "회원번호", 17, 110, 30, 20, 30, label_Click));
            arry.Add(new LBclass(this, "연락처", "연락처", 17, 110, 30, 20, 80, label_Click));
            arry.Add(new LBclass(this, "이름", "이름", 17, 110, 30, 20, 130, label_Click));
            arry.Add(new LBclass(this, "ID", "ID", 17, 110, 30, 20, 180, label_Click));
            arry.Add(new LBclass(this, "블랙리스트여부", "블랙리스트 여부", 17, 190, 40, 20, 230, label_Click));
            arry.Add(new LBclass(this, "", ":", 12, 30, 40, 210, 30, label_Click));
            arry.Add(new LBclass(this, "", ":", 12, 30, 40, 210, 80, label_Click));
            arry.Add(new LBclass(this, "", ":", 12, 30, 40, 210, 130, label_Click));
            arry.Add(new LBclass(this, "", ":", 12, 30, 40, 210, 180, label_Click));
            arry.Add(new LBclass(this, "", ":", 12, 30, 40, 210, 230, label_Click));

            for (int i = 0; i < arry.Count; i++)
            {
                Label label = comm.lb((LBclass)arry[i]);

                label.Font = new Font(label.Font.Name, 17, FontStyle.Bold);


                회원정보패널.Controls.Add(label);
            }

            // 회원정보TextBox 변동값
            ArrayList userinfoArry = new ArrayList();
            userinfoArry.Add(new TXTBOXclass(this, "회원번호값", "회원번호값", 430, 40, 240, 30, txtbox_Click));
            userinfoArry.Add(new TXTBOXclass(this, "연락처값", "연락처값", 430, 40, 240, 80, txtbox_Click));
            userinfoArry.Add(new TXTBOXclass(this, "이름값", "이름값", 430, 40, 240, 130, txtbox_Click));
            userinfoArry.Add(new TXTBOXclass(this, "ID값", "ID값", 430, 40, 240, 180, txtbox_Click));
            userinfoArry.Add(new TXTBOXclass(this, "블랙리스트값", "블랙리스트값", 430, 40, 240, 230, txtbox_Click));

            for (int i = 0; i < userinfoArry.Count; i++)
            {
                TextBox textBox = comm.txtbox((TXTBOXclass)userinfoArry[i]);
                textBox.ReadOnly = true;
                textBox.Font = new Font(textBox.Font.Name, 12, FontStyle.Bold);

                if (textBox.Name == "회원번호값")
                {
                    회원번호값 = textBox;
                }
                else if (textBox.Name == "연락처값")
                {
                    연락처값 = textBox;
                }
                else if (textBox.Name == "이름값")
                {
                    이름값 = textBox;
                }
                else if (textBox.Name == "ID값")
                {
                    ID값 = textBox;
                }
                else if (textBox.Name == "블랙리스트값")
                {
                    블랙리스트값 = textBox;
                }

                회원정보패널.Controls.Add(textBox);
            }




            /// 버튼 - 회원정보 변경버튼
            BTNclass 버튼등급수정값 = new BTNclass(this, "버튼등급수정", "회원 등급 수정", 150, 40, 570, 340, btn_Click);
            Button 버튼등급수정 = comm.btn(버튼등급수정값);
            버튼등급수정.BackColor = Color.FromArgb(50, 178, 223);
            버튼등급수정.Font = new Font(버튼등급수정.Font.Name, 12, FontStyle.Bold);
            버튼등급수정.FlatStyle = FlatStyle.Flat;
            버튼등급수정.ForeColor = Color.White;
            버튼등급수정.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, 버튼등급수정.Width, 버튼등급수정.Height, 10, 10));
            Controls.Add(버튼등급수정);

            /// 라벨 - 대여목록  
            LBclass 대여목록라벨값 = new LBclass(this, "대여목록", "대여 목록", 20, 200, 30, 20, 365, label_Click);
            Label 대여목록라벨 = comm.lb(대여목록라벨값);
            대여목록라벨.Font = new Font(대여목록라벨.Font.Name, 20, FontStyle.Bold);
            Controls.Add(대여목록라벨);


            // 리스트뷰 - 대여목록
            LISTVIEWclass 대여목록_리스트뷰값 = new LISTVIEWclass(this, "대여목록_ListVIew", 700, 350, 20, 407, listView_MouseClick, listview_mousedoubleclick, 6, "", 0, "책번호", 70, "책 이름", 260, "저자", 120, "출판사", 120, "대여현황", 125);
            대여목록_리스트뷰 = comm.listView(대여목록_리스트뷰값);
            대여목록_리스트뷰.Font = new Font("Arial", 14, FontStyle.Bold);

            //mysql = new MySql();
            //string sql = string.Format("select * from book_info;");
            //ArrayList bookinfoSearch_arry2 = mysql.Select(sql);
            //foreach (Hashtable ht in bookinfoSearch_arry2)
            //{
            //    ListViewItem item = new ListViewItem("");
            //    item.SubItems.Add(ht["book_number"].ToString());
            //    item.SubItems.Add(ht["title"].ToString());
            //    item.SubItems.Add(ht["author"].ToString());
            //    item.SubItems.Add(ht["publisher"].ToString());
            //    item.Font = new Font("Arial", 14, FontStyle.Italic);
            //    대여목록_리스트뷰.Items.Add(item);
            //}

            Controls.Add(대여목록_리스트뷰);

            //  회원정보검색 - 라벨
            LBclass 회원정보검색값 = new LBclass(this, "회원정보검색", "회원정보검색 :", 20, 200, 40, 790, 95, label_Click);
            Label 회원정보검색 = comm.lb(회원정보검색값);
            회원정보검색.Font = new Font(회원정보검색.Font.Name, 20, FontStyle.Bold);
            Controls.Add(회원정보검색);

            // 회원정보검색 - 콤보박스
            COMBOBOXclass 검색카테고리값 = new COMBOBOXclass(this, "ComboBox1", 90, 120, 990, 90, ComboBox_SelectedIndexChanged, 2, "이름", "ID");
            ComboBox 콤보박스검색카테고리 = comm.comboBox(검색카테고리값);
            콤보박스검색카테고리.Font = new Font(콤보박스검색카테고리.Font.Name, 22, FontStyle.Regular);
            콤보박스검색카테고리.DropDownStyle = ComboBoxStyle.DropDownList;
            콤보박스검색카테고리.SelectedIndex = 0;
            Controls.Add(콤보박스검색카테고리);


            // 회원정보검색 검색박스상자 - TextBOX
            TXTBOXclass 회원정보검색상자값 = new TXTBOXclass(this, "회원정보검색상자", "", 250, 150, 1080, 90, txtbox_Click);
            회원정보검색상자 = comm.txtbox(회원정보검색상자값);
            회원정보검색상자.Font = new Font(회원정보검색상자.Font.Name, 20, FontStyle.Bold);
            Controls.Add(회원정보검색상자); // 수정중

            // 회원정보검색 - 버튼
            BTNclass 검색버튼값 = new BTNclass(this, "검색버튼", "검색", 100, 40, 1330, 89, btn_Click);
            Button 버튼검색 = comm.btn(검색버튼값);
            버튼검색.BackColor = Color.FromArgb(50, 178, 223);
            버튼검색.Font = new Font(버튼검색.Font.Name, 17, FontStyle.Bold);
            버튼검색.FlatStyle = FlatStyle.Flat;
            버튼검색.ForeColor = Color.White;
            //버튼검색.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, 버튼검색.Width, 버튼검색.Height, 18, 18));
            Controls.Add(버튼검색);


            // 리스트뷰 - 회원정보검색
            LISTVIEWclass 회원정보검색_리스트뷰값 = new LISTVIEWclass(this, "회원정보검색_ListVIew", 645, 575, 800, 182, listView_MouseClick, listview_mousedoubleclick, 5, "", 0, "회원번호", 120, "회원이름", 120, "주민번호 앞자리", 200, "ID", 200);
            회원정보검색_리스트뷰 = comm.listView(회원정보검색_리스트뷰값);
            회원정보검색_리스트뷰.Font = new Font("Arial", 14, FontStyle.Bold);

            mysql = new MySql();
            sql = string.Format("select * from signup;");
            ArrayList signupinfoSearch_arry = mysql.Select(sql);
            foreach (Hashtable ht in signupinfoSearch_arry)
            {
                ListViewItem item = new ListViewItem("");
                item.SubItems.Add(ht["user_number"].ToString());
                item.SubItems.Add(ht["name"].ToString());
                item.SubItems.Add(ht["birthday"].ToString().Substring(0, 10));
                item.SubItems.Add(ht["id"].ToString());
                item.Font = new Font("Arial", 14, FontStyle.Italic);
                회원정보검색_리스트뷰.Items.Add(item);
            }
            Controls.Add(회원정보검색_리스트뷰);
        }



        ////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary> 아래는 이벤트 처리 부분
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        //////////////////////////////////////////////////////////////////////////////////////////////// 

        private void listview_mousedoubleclick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("동작확인 : listview_mousedoubleclick");
        }

        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("동작확인 : listView_MouseClick");

            int index;
            index = 회원정보검색_리스트뷰.FocusedItem.Index;  // 선택돈 아이템 인덱스 번호 얻기
            int user_number = Convert.ToInt32(회원정보검색_리스트뷰.Items[index].SubItems[1].Text); // 인덱스 번호의 n번째 아이템 얻기

            MySql mysql = new MySql();
            ArrayList bookinfoSearch_arry = mysql.Select(string.Format("select * from signup where user_number = {0}", user_number));
            foreach (Hashtable ht in bookinfoSearch_arry)
            {
                회원번호값.Text = ht["user_number"].ToString();
                연락처값.Text = ht["phone_number"].ToString();
                이름값.Text = ht["name"].ToString();
                ID값.Text = ht["id"].ToString();
                블랙리스트값.Text = ht["blacklist"].ToString();
            }

            대여목록_리스트뷰.Items.Clear();
            mysql = new MySql();
            sql = string.Format("select	I.book_number, I.title, I.author, I.publisher, case when R.rental_status = 0 then '대여중' when R.rental_status = 1 then '미반납' end as 'rental_status' from	book_info I inner join	book_rental  R on (R.user_number = {0} and I.book_number = R.book_number and R.rental_status <> 2);", user_number);
            ArrayList bookinfoSearch_arry2 = mysql.Select(sql);
            foreach (Hashtable ht in bookinfoSearch_arry2)
            {
                ListViewItem item = new ListViewItem("");
                item.SubItems.Add(ht["book_number"].ToString());
                item.SubItems.Add(ht["title"].ToString());
                item.SubItems.Add(ht["author"].ToString());
                item.SubItems.Add(ht["publisher"].ToString());
                item.SubItems.Add(ht["rental_status"].ToString());
                item.Font = new Font("Arial", 14, FontStyle.Italic);
                대여목록_리스트뷰.Items.Add(item);
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;

            search_category = (string)combo.SelectedItem;

            //MessageBox.Show(search_category);

            if (search_category == "이름")
            {
                search_category = "name";
            }
            else if (search_category == "ID")
            {
                search_category = "id";
            }

        }

        private void btn_Click(Object o, EventArgs e)
        {
            //MessageBox.Show("동작확인 : btn_Click");

            Button button = (Button)o;

            if (button.Name == "검색버튼")
            {
                회원정보검색_리스트뷰.Items.Clear();

                MySql mysql = new MySql();
                //ArrayList bookinfoSearch_arry = mysql.Select(string.Format("select * from book_info where {0} LIKE '%{1}%'", search_category, 책정보검색상자.Text));
                ArrayList userinfoSearch_arry = mysql.Select(string.Format("select * from signup where {0} LIKE '%{1}%'", search_category, 회원정보검색상자.Text));

                foreach (Hashtable ht in userinfoSearch_arry)
                {
                    ListViewItem item = new ListViewItem("");
                    item.SubItems.Add(ht["user_number"].ToString());
                    item.SubItems.Add(ht["name"].ToString());
                    item.SubItems.Add(ht["birthday"].ToString().Substring(0, 10));
                    item.SubItems.Add(ht["id"].ToString());
                    item.Font = new Font("Arial", 14, FontStyle.Italic);
                    회원정보검색_리스트뷰.Items.Add(item);
                }

                Controls.Add(회원정보검색_리스트뷰);
            }
            else if (button.Name == "버튼등급수정")
            {
                if (회원번호값.Text == "회원번호값")
                {
                    MessageBox.Show("변경 할 회원정보를 오른쪽 리스트에서 선택해주세요");
                    return;
                }
                USER_LEVEL_UPDATE_FORM user_level_update_form = new USER_LEVEL_UPDATE_FORM(회원번호값.Text);
                user_level_update_form.StartPosition = FormStartPosition.CenterParent;
                user_level_update_form.ShowDialog();
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
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            e.Graphics.DrawLine(pen, 750, 0, 750, 800);
        }
    }
}