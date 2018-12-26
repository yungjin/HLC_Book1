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
    public partial class LATE_MGT_FORM : Form
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
        ListView 연체정보리스트;

        public LATE_MGT_FORM()
        {
            InitializeComponent();

            Load += LATE_MGT_FORM_Load;
        }

        private void LATE_MGT_FORM_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None; // 폼 상단 표시줄 제거

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
            PANELclass pn1 = new PANELclass(this, "panel1", "panel_txt~", 200, 200, 100, 100);
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


            BTNclass 연체정보리플레시버튼값 = new BTNclass(this, "리플레시버튼", "Refresh", 150, 50, 1285, 70, btn_Click);
            Button 연체정보리플레시버튼 = comm.btn(연체정보리플레시버튼값);
            연체정보리플레시버튼.Font = new Font("신명조", 20, FontStyle.Bold);
            Controls.Add(연체정보리플레시버튼);


            LBclass 연체정보라벨값 = new LBclass(this, "연체정보라벨", "연체자 정보", 30, 250, 50, 30, 50, label_Click);
            Label 연체정보라벨 = comm.lb(연체정보라벨값);
            Controls.Add(연체정보라벨);


            LISTVIEWclass 연체정보리스트값 = new LISTVIEWclass(this, "연체정보리스트", 1400, 600, 38, 130, listview_mousedoubleclick, listview_mousedoubleclick, 8, "", 0, "회원번호", 200, "연락처", 200, "이름", 200, "도서명", 200, "도서번호", 200, "대여일", 200, "연체일", 200);
            연체정보리스트 = comm.listView(연체정보리스트값);
            연체정보리스트.Font = new Font("신명조", 24, FontStyle.Bold);

            연체정보리스트.OwnerDraw = true;
            연체정보리스트.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(lv_DrawColumnHeader);

            //연체정보리스트.BackColor = Color.AliceBlue;  // Color.FromArgb(201, 253, 223); 
            연체정보리스트.DrawSubItem += new DrawListViewSubItemEventHandler(lv_DrawSubItem);

            MySql mysql = new MySql();

            ArrayList arry = mysql.Select("select S.user_number, S.phone_number, S.name, I.title, I.book_number, R.rental_day, TO_DAYS(now()) - TO_DAYS(R.return_schedule) 연체일 from book_info as I inner join book_rental as R on (I.book_number = R.book_number and TO_DAYS(now()) - TO_DAYS(R.return_schedule) > 0 and R.rental_status <> 2) inner join signup as S on (S.user_number = R.user_number);");
            foreach (Hashtable ht in arry)
            {
                ListViewItem item = new ListViewItem("");
                item.SubItems.Add(ht["user_number"].ToString());
                item.SubItems.Add(ht["phone_number"].ToString());
                item.SubItems.Add(ht["name"].ToString());
                item.SubItems.Add(ht["title"].ToString());
                item.SubItems.Add(ht["book_number"].ToString());
                item.SubItems.Add(ht["rental_day"].ToString());
                item.SubItems.Add(ht["연체일"].ToString());

                연체정보리스트.Items.Add(item);

                for (int i = 0; i < item.SubItems.Count; i++)
                {
                    item.SubItems[i].Font = new Font("Arial", 14, FontStyle.Italic);
                }
            }

            Controls.Add(연체정보리스트);


        }

        public void Refresh_ListView()
        {
            연체정보리스트.Items.Clear();

            연체정보리스트.OwnerDraw = true;
            연체정보리스트.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(lv_DrawColumnHeader);

            //연체정보리스트.BackColor = Color.AliceBlue;  // Color.FromArgb(201, 253, 223); 
            연체정보리스트.DrawSubItem += new DrawListViewSubItemEventHandler(lv_DrawSubItem);

            MySql mysql = new MySql();
            ArrayList arry = mysql.Select("select S.user_number, S.phone_number, S.name, I.title, I.book_number, R.rental_day, TO_DAYS(now()) - TO_DAYS(R.return_schedule) 연체일 from book_info as I inner join book_rental as R on (I.book_number = R.book_number and TO_DAYS(now()) - TO_DAYS(R.return_schedule) > 0 and R.rental_status <> 2) inner join signup as S on (S.user_number = R.user_number);");
            foreach (Hashtable ht in arry)
            {
                ListViewItem item = new ListViewItem("");
                item.SubItems.Add(ht["user_number"].ToString());
                item.SubItems.Add(ht["phone_number"].ToString());
                item.SubItems.Add(ht["name"].ToString());
                item.SubItems.Add(ht["title"].ToString());
                item.SubItems.Add(ht["book_number"].ToString());
                item.SubItems.Add(ht["rental_day"].ToString());
                item.SubItems.Add(ht["연체일"].ToString());

                연체정보리스트.Items.Add(item);

                for (int i = 0; i < item.SubItems.Count; i++)
                {
                    item.SubItems[i].Font = new Font("Arial", 14, FontStyle.Italic);
                }
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
            MessageBox.Show("동작확인 : btn_Click");

            Button button = (Button)o;           

            if(button.Name == "연체정보라벨")
            {
                Refresh_ListView();
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

        // 리스트뷰 헤더 컬러추가
        void lv_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
            e.DrawText();
        }

        // 리스트뷰 Subitem 컬러추가
        void lv_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawText();
        }

    }
}