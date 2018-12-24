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
    public partial class DETAIL_BOOK_FORM : Form
    {
        int sX = 500, sY = 400; // 폼 사이즈 지정.

        ///////// 좌표 체크시 추가 /////////
        static ToolStripStatusLabel StripLb;
        StatusStrip statusStrip;
        ///////////////////////////////////

        COMMON_Create_Ctl comm = new COMMON_Create_Ctl();

        private OpenFileDialog openFileDialog1 = new OpenFileDialog();  // openFileDialog1 변수 선언 및 초기화
        public static string _Slected_File_RootPath;
        PictureBox 책이미지;
        TextBox 텍스트박스;
        ListView 도서상세정보_리스트뷰;
        string book_name;
        Label 도서이름라벨;
        Label 보유권수총갯수라벨;

        public DETAIL_BOOK_FORM()
        {
            InitializeComponent();

            Load += DETAIL_BOOK_FORM_Load;
        }
        public DETAIL_BOOK_FORM(string book_name)
        {
            InitializeComponent();

            this.book_name = book_name;
            Load += DETAIL_BOOK_FORM_Load;
        }

        private void DETAIL_BOOK_FORM_Load(object sender, EventArgs e)
        {
            //FormBorderStyle = FormBorderStyle.None; 폼 상단 표시줄 제거

            this.BackColor = Color.FromArgb(149, 165, 165);

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

            ////// 고정 라벨 
            ArrayList labelArr = new ArrayList();
            labelArr.Add(new LBclass(this, "도서상세정보", "도서 상세 정보", 26, 300, 40, 30, 30, label_Click));
            labelArr.Add(new LBclass(this, "도서명", "도서명", 15, 80, 40, 30, 110, label_Click));
            labelArr.Add(new LBclass(this, "보유정보", "보유정보", 12, 100, 40, 30, 160, label_Click));
            labelArr.Add(new LBclass(this, "", ":", 12, 30, 40, 140, 108, label_Click));
            labelArr.Add(new LBclass(this, "", ":", 12, 30, 40, 140, 158, label_Click));


            for (int i = 0; i < labelArr.Count; i++)
            {
                Label 라벨 = comm.lb((LBclass)labelArr[i]);

                라벨.Font = new Font("신명조", 15, FontStyle.Bold);

                if (라벨.Name == "도서상세정보")
                {
                    라벨.Font = new Font("신명조", 24, FontStyle.Bold);
                }
                else if (라벨.Name == "도서명")
                {

                }
                else if (라벨.Name == "보유정보")
                {

                }



                Controls.Add(라벨);
            }


            /// 변경되는 라벨 
            ArrayList Value_labelArr = new ArrayList();
            Value_labelArr.Add(new LBclass(this, "도서명파라미터", "도서명파라미터", 10, 280, 40, 172, 112, label_Click));
            Value_labelArr.Add(new LBclass(this, "보유권수파라미터", "보유권수파라미터", 10, 250, 40, 172, 162, label_Click));

            for (int i = 0; i < Value_labelArr.Count; i++)
            {
                Label 변경라벨 = comm.lb((LBclass)Value_labelArr[i]);

                변경라벨.Font = new Font("신명조", 12, FontStyle.Bold);

                if (변경라벨.Name == "도서명파라미터")
                {
                    도서이름라벨 = 변경라벨;
                }
                else if (변경라벨.Name == "보유권수파라미터")
                {
                    보유권수총갯수라벨 = 변경라벨;
                }



                Controls.Add(변경라벨);
            }




            /// 도서상세정보 리스트
            LISTVIEWclass 도서상세정보_리스트뷰값 = new LISTVIEWclass(this, "도서상세정보_ListVIew", 324, 140, 38, 210, listView_MouseClick, listview_mousedoubleclick, 4, "", 0, "책번호", 100, "책위치", 110, "대여", 110);
            도서상세정보_리스트뷰 = comm.listView(도서상세정보_리스트뷰값);


            도서상세정보_리스트뷰.Font = new Font("Arial", 14, FontStyle.Bold);

            도서상세정보_리스트뷰.OwnerDraw = true;
            도서상세정보_리스트뷰.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(lv_DrawColumnHeader);

            도서상세정보_리스트뷰.BackColor = Color.FromArgb(149, 165, 165);
            도서상세정보_리스트뷰.DrawSubItem += new DrawListViewSubItemEventHandler(lv_DrawSubItem);


            MySql mysql = new MySql();
            string sql = string.Format("select title, count(*) COUNT from book_info where title = '{0}';", book_name);
            //MessageBox.Show(sql);
            ArrayList bookinfoSearch_arry1 = mysql.Select(sql);
            foreach (Hashtable ht in bookinfoSearch_arry1)
            {
                도서이름라벨.Text = ht["title"].ToString();
                보유권수총갯수라벨.Text = "총 " + ht["COUNT"].ToString() + "권";
            }
            mysql.ConnectionClose();

            mysql = new MySql();
            sql = string.Format("select * from book_info where title = '{0}';", book_name);
            ArrayList bookinfoSearch_arry2 = mysql.Select(sql);
            foreach (Hashtable ht in bookinfoSearch_arry2)
            {
                ListViewItem item = new ListViewItem("");
                item.SubItems.Add(ht["book_number"].ToString());
                item.SubItems.Add(ht["book_location"].ToString());
                item.SubItems.Add(ht["availability"].ToString());
                도서상세정보_리스트뷰.Items.Add(item);

                for (int i = 0; i < item.SubItems.Count; i++)
                {
                    item.SubItems[i].Font = new Font("Arial", 12, FontStyle.Bold | FontStyle.Italic);
                }
            }

            Controls.Add(도서상세정보_리스트뷰);


            /// 닫기 버튼
            BTNclass 버튼닫기값 = new BTNclass(this, "닫기버튼", "닫기", 80, 40, 397, 312, btn_Click);
            Button 버튼닫기 = comm.btn(버튼닫기값);
            버튼닫기.BackColor = Color.FromArgb(50, 178, 223);
            버튼닫기.Font = new Font(버튼닫기.Font.Name, 12, FontStyle.Bold);
            버튼닫기.FlatStyle = FlatStyle.Flat;
            버튼닫기.ForeColor = Color.White;
            버튼닫기.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, 버튼닫기.Width, 버튼닫기.Height, 10, 10));
            Controls.Add(버튼닫기);

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

            if (button.Name == "닫기버튼")
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