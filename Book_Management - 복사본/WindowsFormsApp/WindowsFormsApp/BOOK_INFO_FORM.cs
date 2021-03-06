﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class BOOK_INFO_FORM : Form
    {
        bool user = true;
        bool admin = false;

        MAIN_FORM form;
        Login_Check Login_ck;
        string search_category = "";
        int sX = 1500, sY = 800; // 폼 사이즈 지정.

        ///////// 좌표 체크시 추가 /////////
        static ToolStripStatusLabel StripLb;
        StatusStrip statusStrip;
        ///////////////////////////////////
        LOGIN_FORM login_frm;

        COMMON_Create_Ctl comm = new COMMON_Create_Ctl();
        
        private OpenFileDialog openFileDialog1 = new OpenFileDialog();  // openFileDialog1 변수 선언 및 초기화
        public static string _Slected_File_RootPath;
        PictureBox 책이미지;
        ListView 책정보검색_리스트뷰;
        TextBox 책정보검색상자;
        TextBox 간략소개상자;
        ComboBox 콤보박스검색카테고리;
        Panel 책정보패널;
        Button 정보수정;
        Button 수정취소;
        Button 수정완료;

        Label 번호값;
        Label 제목값;
        Label 저자값;
        Label 출판사값;
        Label 장르값;
        Label 대여가능여부값;
        Label 대여자여부값;
        Label 도서위치값;

        TextBox 텍스트박스_번호값;
        TextBox 텍스트박스_제목값;
        TextBox 텍스트박스_저자값;
        TextBox 텍스트박스_출판사값;
        TextBox 텍스트박스_장르값;
        TextBox 텍스트박스_대여가능여부값;
        TextBox 텍스트박스_대여자여부값;
        TextBox 텍스트박스_도서위치값;


        public BOOK_INFO_FORM(MAIN_FORM form)
        {
            InitializeComponent();
            this.form = form;
            Load += BOOK_INFO_FORM_Load;
        }
        
        private void BOOK_INFO_FORM_Load(object sender, EventArgs e)
        {
            comm.delay_rental_check();
            login_frm = new LOGIN_FORM(form);

            if (login_frm.Member_rank == 1)
            {
                user = true;
                admin = false;
            }
            else if(login_frm.Member_rank == 0)
            {
                user = false;
                admin = true;
            }
            //else if (MAIN_FORM.member_rank == 4)
            //{
            //    user = true;
            //    admin = false;
            //}



            FormBorderStyle = FormBorderStyle.None; //폼 상단 표시줄 제거
            //this.BackColor = Color.Aquamarine;
            this.BackColor = Color.FromArgb(201, 253, 223);

            ClientSize = new Size(sX, sY);  // 폼 사이즈 지정.

            /// 좌표 체크시 추가 ///
            //Point_Print();

            COMMON_Create_Ctl create_ctl = new COMMON_Create_Ctl();

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

            if (user)
            {
                // 책정보패널
                PANELclass 책정보패널값 = new PANELclass(this, "책정보패널", "책정보패널", 550, 600, 10, 10);
                책정보패널 = comm.panel(책정보패널값);
            }
            else
            {
                // 책정보패널
                PANELclass 책정보패널값 = new PANELclass(this, "책정보패널", "책정보패널", 550, 750, 10, 10);
                책정보패널 = comm.panel(책정보패널값);
            }

            //(좌측상단여백, 우측상단여백, 컨트롤 넓이, 컨트롤 높이, 가로 모서리 원기울기, 세로 모서리 원기울기)
            책정보패널.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, 책정보패널.Width, 책정보패널.Height, 15, 15));
            책정보패널.BackColor = Color.FromArgb(218, 234, 244);  // rgb(218,234,244)
            Controls.Add(책정보패널);

            // 도서사진 픽쳐박스
            PICTUREBOXclass picturboxValue = new PICTUREBOXclass(this, "picturebox1", "picturebox_txt1", 220, 260, 10, 20, "default_book_image.png", picturbox_Click);
            책이미지 = comm.load_PictureBox(picturboxValue);
            책정보패널.Controls.Add(책이미지);

            // 간략소개상자 - TextBOX
            TXTBOXclass 간략소개상자값 = new TXTBOXclass(this, "간략소개상자", "", 500, 150, 26, 324, txtbox_Click);
            간략소개상자 = comm.txtbox(간략소개상자값);
            간략소개상자.Font = new Font("Arial", 24, FontStyle.Bold);
            간략소개상자.ReadOnly = true;
            간략소개상자.Multiline = true;
            간략소개상자.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, 간략소개상자.Width, 간략소개상자.Height, 18, 18));
            간략소개상자.ScrollBars = ScrollBars.Vertical;
            책정보패널.Controls.Add(간략소개상자);

            // 책정보 검색박스상자 - TextBOX
            TXTBOXclass 책정보검색상자값 = new TXTBOXclass(this, "책정보_검색박스", "", 430, 150, 920, 89, txtbox_Click);
            책정보검색상자 = comm.txtbox(책정보검색상자값);
            책정보검색상자.Font = new Font(책정보검색상자.Font.Name, 24, FontStyle.Bold);
            Controls.Add(책정보검색상자); // 수정중


            // 책정보패널 고정라벨
            ArrayList arry = new ArrayList();
            arry.Add(new LBclass(this, "번호", "번호    :", 17, 110, 40, 235, 40, label_Click));
            arry.Add(new LBclass(this, "제목", "제목    :", 17, 110, 40, 235, 90, label_Click));
            arry.Add(new LBclass(this, "저자", "저자    :", 17, 110, 40, 235, 140, label_Click));
            arry.Add(new LBclass(this, "출판사", "출판사 :", 17, 110, 40, 235, 190, label_Click));
            arry.Add(new LBclass(this, "장르", "장르    :", 17, 110, 40, 235, 240, label_Click));
            arry.Add(new LBclass(this, "간략소개", "간략소개 :", 17, 110, 40, 26, 293, label_Click));
            if (user)
            {
                arry.Add(new LBclass(this, "대여가능여부", "대여가능여부    :", 17, 200, 40, 22, 496, label_Click));
                arry.Add(new LBclass(this, "도서위치", "    도서위치    :", 17, 180, 40, 38, 540, label_Click));
            }
            else
            {
                arry.Add(new LBclass(this, "대여가능여부", "대여가능여부   :", 17, 220, 40, 22, 530, label_Click));
                arry.Add(new LBclass(this, "대여자", "대여자  :", 17, 130, 40, 115, 600, label_Click));
                arry.Add(new LBclass(this, "도서위치", "도서위치   :", 17, 170, 40, 75, 670, label_Click));
            }


            for (int i = 0; i < arry.Count; i++)
            {
                Label label = comm.lb((LBclass)arry[i]);

                if (label.Name == "간략소개")
                {
                    label.Font = new Font(label.Font.Name, 14, FontStyle.Bold | FontStyle.Underline);
                }
                else if (admin && label.Name == "대여가능여부")
                {
                    label.Font = new Font(label.Font.Name, 20, FontStyle.Bold);

                }
                else if (admin && label.Name == "대여자")
                {
                    label.Font = new Font(label.Font.Name, 20, FontStyle.Bold);
                }
                else if (admin && label.Name == "도서위치")
                {
                    label.Font = new Font(label.Font.Name, 20, FontStyle.Bold);
                }
                else
                {
                    label.Font = new Font(label.Font.Name, 17, FontStyle.Bold);
                }

                책정보패널.Controls.Add(label);
            }

            // 책정보패널 선택한 리스트 라벨값
            ArrayList arryValue = new ArrayList();
            arryValue.Add(new LBclass(this, "번호값", "번호값", 17, 200, 40, 349, 40, label_Click));
            arryValue.Add(new LBclass(this, "제목값", "제목값", 17, 200, 40, 349, 90, label_Click));
            arryValue.Add(new LBclass(this, "저자값", "저자값", 17, 200, 40, 349, 140, label_Click));
            arryValue.Add(new LBclass(this, "출판사값", "출판사값", 17, 200, 40, 349, 190, label_Click));
            arryValue.Add(new LBclass(this, "장르값", "장르값", 17, 200, 40, 349, 240, label_Click));

            if (user)
            {
                arryValue.Add(new LBclass(this, "대여가능여부값", "가능", 17, 110, 40, 236, 497, label_Click));
                arryValue.Add(new LBclass(this, "도서위치값", "A열 2 - 1", 17, 110, 40, 238, 540, label_Click));
            }

            else
            {
                arryValue.Add(new LBclass(this, "대여가능여부값", "가능", 17, 1000, 40, 246, 530, label_Click));
                arryValue.Add(new LBclass(this, "대여자여부값", "없음", 17, 100, 40, 245, 600, label_Click));
                arryValue.Add(new LBclass(this, "도서위치값", "A열 2 - 1", 17, 100, 40, 248, 670, label_Click));
            }

            for (int i = 0; i < arryValue.Count; i++)
            {
                Label label = comm.lb((LBclass)arryValue[i]);
                label.Font = new Font(label.Font.Name, 17, FontStyle.Bold);
                책정보패널.Controls.Add(label);

                if (label.Name == "번호값")
                {
                    번호값 = label;
                }
                else if (label.Name == "제목값")
                {
                    제목값 = label;
                }
                else if (label.Name == "저자값")
                {
                    저자값 = label;
                }
                else if (label.Name == "출판사값")
                {
                    출판사값 = label;
                }
                else if (label.Name == "장르값")
                {
                    장르값 = label;
                }
                else if (label.Name == "대여가능여부값")
                {
                    대여가능여부값 = label;
                }
                else if (label.Name == "도서위치값")
                {
                    도서위치값 = label;
                }

                if (admin && label.Name == "대여가능여부값")
                {
                    label.Font = new Font(label.Font.Name, 20, FontStyle.Bold);
                }
                else if (admin && label.Name == "대여자여부값")
                {
                    대여자여부값 = label;
                    label.Font = new Font(label.Font.Name, 20, FontStyle.Bold);
                }
                else if (admin && label.Name == "도서위치값")
                {
                    label.Font = new Font(label.Font.Name, 20, FontStyle.Bold);
                }

            }


            /*
                제목값.Hide();
                저자값.Hide();
                출판사값.Hide();
                장르값.Hide();
                도서위치값.Hide();
             
             */



            if (user)
            {
                // 입고요청패널
                PANELclass 입고요청패널값 = new PANELclass(this, "입고요청패널", "입고요청패널", 550, 160, 10, 610);
                Panel 입고요청패널 = comm.panel(입고요청패널값);

                //(좌측상단여백, 우측상단여백, 컨트롤 넓이, 컨트롤 높이, 가로 모서리 원기울기, 세로 모서리 원기울기)
                입고요청패널.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, 입고요청패널.Width, 입고요청패널.Height, 15, 15));
                입고요청패널.BackColor = Color.FromArgb(114, 241, 168);  // rgb(218,234,244)
                Controls.Add(입고요청패널);

                // 입고요청 고정라벨
                LBclass 입고요청라벨값 = new LBclass(this, "입고요청", "※ 찾으시는 도서가 없으신가요?\n    그럼 입고요청을 해주세요.", 17, 360, 50, 17, 17, label_Click);
                Label 입고요청라벨 = comm.lb(입고요청라벨값);
                입고요청패널.Controls.Add(입고요청라벨);

                // 대여 버튼
                BTNclass 버튼대여버튼값 = new BTNclass(this, "대여버튼", "대여", 130, 60, 410, 530, btn_Click);
                Button 대여버튼 = comm.btn(버튼대여버튼값);
                대여버튼.BackColor = Color.FromArgb(50, 178, 223);
                대여버튼.Font = new Font(대여버튼.Font.Name, 17, FontStyle.Bold);
                대여버튼.FlatStyle = FlatStyle.Flat;
                대여버튼.ForeColor = Color.White;
                대여버튼.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, 대여버튼.Width, 대여버튼.Height, 18, 18));
                책정보패널.Controls.Add(대여버튼);

                // 입고 버튼
                BTNclass 버튼입고요청값 = new BTNclass(this, "입고버튼", "입고요청", 130, 60, 410, 30, btn_Click);
                Button 버튼입고요청 = comm.btn(버튼입고요청값);
                버튼입고요청.BackColor = Color.FromArgb(50, 178, 223);
                버튼입고요청.Font = new Font(버튼입고요청.Font.Name, 17, FontStyle.Bold);
                버튼입고요청.FlatStyle = FlatStyle.Flat;
                버튼입고요청.ForeColor = Color.White;
                버튼입고요청.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, 버튼입고요청.Width, 버튼입고요청.Height, 18, 18));
                입고요청패널.Controls.Add(버튼입고요청);
            }
            else
            {
                // 정보수정 && 수정 취소 버튼  
                ArrayList btnArray = new ArrayList();
                btnArray.Add(new BTNclass(this, "정보수정버튼", "정보 수정", 140, 60, 385, 640, btn_Click));
                btnArray.Add(new BTNclass(this, "수정취소버튼", "수정 취소", 140, 60, 385, 640, btn_Click));
                btnArray.Add(new BTNclass(this, "수정완료버튼", "수정 완료", 140, 60, 385, 570, btn_Click));

                for (int i = 0; i < btnArray.Count; i++)
                {
                    Button 버튼 = comm.btn((BTNclass)btnArray[i]);

                    버튼.BackColor = Color.FromArgb(50, 178, 223);
                    버튼.Font = new Font(버튼.Font.Name, 17, FontStyle.Bold);
                    버튼.FlatStyle = FlatStyle.Flat;
                    버튼.ForeColor = Color.White;
                    버튼.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, 버튼.Width, 버튼.Height, 18, 18));
                    책정보패널.Controls.Add(버튼);

                    if (버튼.Name == "정보수정버튼")
                    {
                        정보수정 = 버튼;

                    }
                    else if (버튼.Name == "수정취소버튼")
                    {
                        수정취소 = 버튼;
                    }
                    else if (버튼.Name == "수정완료버튼")
                    {
                        수정완료 = 버튼;
                    }
                }
                수정취소.Hide();
                수정완료.Hide();

                // 책정보패널 - 책정보 수정을 위한 텍스트박스 값
                ArrayList TextBox_arryValue = new ArrayList();
                TextBox_arryValue.Add(new TXTBOXclass(this, "텍스트박스_제목값", "텍스트박스_제목값", 180, 40, 349, 80, txtbox_Click)); //  200, 40, 349, 90,
                TextBox_arryValue.Add(new TXTBOXclass(this, "텍스트박스_저자값", "텍스트박스_저자값", 180, 40, 349, 130, txtbox_Click));
                TextBox_arryValue.Add(new TXTBOXclass(this, "텍스트박스_출판사값", "텍스트박스_출판사값", 180, 40, 349, 180, txtbox_Click));
                TextBox_arryValue.Add(new TXTBOXclass(this, "텍스트박스_장르값", "텍스트박스_장르값", 180, 40, 349, 230, txtbox_Click));
                TextBox_arryValue.Add(new TXTBOXclass(this, "텍스트박스_도서위치값", "A열 2 - 1", 100, 40, 248, 660, txtbox_Click));

                for (int i = 0; i < TextBox_arryValue.Count; i++)
                {
                    TextBox textbox = comm.txtbox((TXTBOXclass)TextBox_arryValue[i]);
                    textbox.Font = new Font(textbox.Font.Name, 20, FontStyle.Bold);
                    책정보패널.Controls.Add(textbox);

                    if (textbox.Name == "텍스트박스_제목값")
                    {
                        텍스트박스_제목값 = textbox;
                    }
                    else if (textbox.Name == "텍스트박스_저자값")
                    {
                        텍스트박스_저자값 = textbox;
                    }
                    else if (textbox.Name == "텍스트박스_출판사값")
                    {
                        텍스트박스_출판사값 = textbox;
                    }
                    else if (textbox.Name == "텍스트박스_장르값")
                    {
                        텍스트박스_장르값 = textbox;
                    }
                    else if (textbox.Name == "텍스트박스_도서위치값")
                    {
                        텍스트박스_도서위치값 = textbox;
                    }

                }
                텍스트박스_제목값.Hide();
                텍스트박스_저자값.Hide();
                텍스트박스_출판사값.Hide();
                텍스트박스_장르값.Hide();
                텍스트박스_도서위치값.Hide();

            }


            BTNclass 검색버튼값 = new BTNclass(this, "검색버튼", "검색버튼", 130, 48, 1350, 87, btn_Click);
            Button 버튼검색 = comm.btn(검색버튼값);
            버튼검색.BackColor = Color.FromArgb(50, 178, 223);
            버튼검색.Font = new Font(버튼검색.Font.Name, 17, FontStyle.Bold);
            버튼검색.FlatStyle = FlatStyle.Flat;
            버튼검색.ForeColor = Color.White;
            //버튼검색.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, 버튼검색.Width, 버튼검색.Height, 18, 18));
            Controls.Add(버튼검색);


            LBclass 라벨책정보검색값 = new LBclass(this, "책정보", "도서 검색 :", 26, 200, 40, 590, 95, label_Click);
            Label 라벨책정보검색 = comm.lb(라벨책정보검색값);
            Controls.Add(라벨책정보검색);


            LISTVIEWclass 책정보검색_리스트뷰값 = new LISTVIEWclass(this, "ListView1", 900, 580, 589, 190, listView_MouseClick, listview_mousedoubleclick, 6, "", 0, "책번호", 100, "대여", 120, "도서명", 460, "저자", 100, "출판사", 115);
            책정보검색_리스트뷰 = comm.listView(책정보검색_리스트뷰값);


            책정보검색_리스트뷰.Font = new Font("Arial", 24, FontStyle.Bold);

            MySql mysql = new MySql();

            ArrayList bookinfoSearch_arry = mysql.GetSelect();
            foreach (Hashtable ht in bookinfoSearch_arry)
            {
                ListViewItem item = new ListViewItem("");
                item.SubItems.Add(ht["book_number"].ToString());
                item.SubItems.Add(ht["availability"].ToString());
                item.SubItems.Add(ht["title"].ToString());
                item.SubItems.Add(ht["author"].ToString());
                item.SubItems.Add(ht["publisher"].ToString());
                item.Font = new Font("Arial", 18, FontStyle.Italic);


                책정보검색_리스트뷰.Items.Add(item);
            }

            Controls.Add(책정보검색_리스트뷰);



            COMBOBOXclass 검색카테고리값 = new COMBOBOXclass(this, "ComboBox1", 130, 120, 790, 89, ComboBox_SelectedIndexChanged, 3, "도서명", "저자", "출판사");

            콤보박스검색카테고리 = comm.comboBox(검색카테고리값);
            콤보박스검색카테고리.Font = new Font(콤보박스검색카테고리.Font.Name, 27, FontStyle.Regular);
            콤보박스검색카테고리.DropDownStyle = ComboBoxStyle.DropDownList;
            콤보박스검색카테고리.SelectedIndex = 0;
            Controls.Add(콤보박스검색카테고리);








        }



        ////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary> 아래는 이벤트 처리 부분
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        //////////////////////////////////////////////////////////////////////////////////////////////// 


        // 리스트뷰 더블클릭
        private void listview_mousedoubleclick(object sender, MouseEventArgs e)
        {
           // MessageBox.Show("동작확인 : listview_mousedoubleclick");

            int index;
            index = 책정보검색_리스트뷰.FocusedItem.Index;  // 선택돈 아이템 인덱스 번호 얻기
            string book_name = 책정보검색_리스트뷰.Items[index].SubItems[3].Text; // 인덱스 번호의 n번째 아이템 얻기


            DETAIL_BOOK_FORM detail_form = new DETAIL_BOOK_FORM(book_name);
            detail_form.StartPosition = FormStartPosition.CenterParent;
            detail_form.ShowDialog();
        }

        // 리스트뷰 마우스클릭
        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("동작확인 : listView_MouseClick");

            int index;
            index = 책정보검색_리스트뷰.FocusedItem.Index;  // 선택돈 아이템 인덱스 번호 얻기
            int book_number = Convert.ToInt32(책정보검색_리스트뷰.Items[index].SubItems[1].Text); // 인덱스 번호의 n번째 아이템 얻기

            MySql mysql = new MySql();
            ArrayList bookinfoSearch_arry = mysql.Select(string.Format("select * from book_info where book_number = {0}", book_number));
            foreach (Hashtable ht in bookinfoSearch_arry)
            {
                번호값.Text = ht["book_number"].ToString();
                제목값.Text = ht["title"].ToString();
                저자값.Text = ht["author"].ToString();
                출판사값.Text = ht["publisher"].ToString();
                장르값.Text = ht["genre"].ToString();
                대여가능여부값.Text = ht["availability"].ToString();
                도서위치값.Text = ht["book_location"].ToString();
                책이미지.ImageLocation = ht["image_location"].ToString();
                간략소개상자.Text = ht["brief_introduction"].ToString();

            }
        }


        // 콤보박스 인덱스 선택
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;

            search_category = (string)combo.SelectedItem;

            //MessageBox.Show(search_category);

            if (search_category == "도서명")
            {
                search_category = "title";
            }
            else if (search_category == "저자")
            {
                search_category = "author";
            }
            else if (search_category == "출판사")
            {
                search_category = "publisher";
            }


        }


        // 버튼클릭
        private void btn_Click(Object o, EventArgs e)
        {
            //MessageBox.Show("동작확인 : btn_Click");

            Button button = (Button)o;
            
            

            if(button.Name == "대여버튼")
            {
                if (login_frm.Member_rank == 4)
                {
                    Login_ck = new Login_Check(this);
                    Login_ck.StartPosition = FormStartPosition.CenterParent;
                    Login_ck.ShowDialog();
                    this.Hide();
                    form.Login.Show();
                }
                else
                {
                    if (대여가능여부값.Text == "가능")
                    {
                        GetInsert();
                    }
                    else MessageBox.Show("대여불가 상태입니다.");
                }
            }

            /// 입고요청 버튼 설정. 
            if (button.Name == "입고버튼")
            {
                if(login_frm.Member_rank == 4)
                {
                    Login_ck = new Login_Check(this);
                    Login_ck.StartPosition = FormStartPosition.CenterParent;
                    Login_ck.ShowDialog();
                    this.Hide();
                    form.Login.Show();
                }
                else
                {
                    REQUEST_BOOK_FORM REQUEST_FORM = new REQUEST_BOOK_FORM();
                    REQUEST_FORM.StartPosition = FormStartPosition.CenterParent;
                    REQUEST_FORM.ShowDialog();
                }
                
            }

            /// 검색버튼 클릭 시 리스트 뷰 넣는 부분 
            if (button.Name == "정보수정버튼") // admin 모드일 경우 
            {
                // 라벨값 그대로 텍스트 박스로 옮기는  부분.
                텍스트박스_제목값.Text = 제목값.Text;
                텍스트박스_저자값.Text = 저자값.Text;
                텍스트박스_출판사값.Text = 출판사값.Text;
                텍스트박스_장르값.Text = 장르값.Text;
                텍스트박스_도서위치값.Text = 도서위치값.Text;
                간략소개상자.Text = 간략소개상자.Text;

                // 정보수정 버튼 숨기기
                정보수정.Hide();
                수정취소.Show();
                수정완료.Show();

                // 라벨 값 숨기기
                제목값.Hide();
                저자값.Hide();
                출판사값.Hide();
                장르값.Hide();
                도서위치값.Hide();

                // 텍스트박스 보이기
                텍스트박스_제목값.Show();
                텍스트박스_저자값.Show();
                텍스트박스_출판사값.Show();
                텍스트박스_장르값.Show();
                텍스트박스_도서위치값.Show();

                간략소개상자.ReadOnly = false;
            }
            else if (button.Name == "수정취소버튼")
            {
                // 정보수정 버튼 보이기
                정보수정.Show();
                수정취소.Hide();
                수정완료.Hide();

                // 라벨 값 숨기기
                제목값.Show();
                저자값.Show();
                출판사값.Show();
                장르값.Show();
                도서위치값.Show();

                // 텍스트박스 보이기
                텍스트박스_제목값.Hide();
                텍스트박스_저자값.Hide();
                텍스트박스_출판사값.Hide();
                텍스트박스_장르값.Hide();
                텍스트박스_도서위치값.Hide();

                간략소개상자.ReadOnly = true;
            }
            else if (button.Name == "수정완료버튼")
            {
               // MessageBox.Show("수정완료");


                if (번호값.Text == "번호값" || 텍스트박스_제목값.Text == "" || 텍스트박스_저자값.Text == "" || 텍스트박스_출판사값.Text == "" || 텍스트박스_장르값.Text == "" || 텍스트박스_도서위치값.Text == "" || 간략소개상자.Text == "")
                {
                    MessageBox.Show("입력칸을 모두 채워주세요.");
                    return;
                }

                MySql mysql = new MySql();
                string sql = string.Format("update book_info set title = '{1}', author = '{2}', publisher = '{3}', genre = '{4}', brief_introduction = '{5}', book_location = '{6}' where book_number = {0};", 번호값.Text, 텍스트박스_제목값.Text, 텍스트박스_저자값.Text, 텍스트박스_출판사값.Text, 텍스트박스_장르값.Text, 간략소개상자.Text, 텍스트박스_도서위치값.Text);
                bool status = mysql.NonQuery_INSERT(sql);

                if (status)
                {
                    MessageBox.Show("수정이 완료 되었습니다.");
                }
                else
                {
                    MessageBox.Show("수정 중 오류가 발생했습니다.");
                }



                mysql = new MySql();
                ArrayList bookinfoSearch_arry = mysql.Select(string.Format("select * from book_info where book_number = {0}", 번호값.Text));
                foreach (Hashtable ht in bookinfoSearch_arry)
                {
                    제목값.Text = ht["title"].ToString();
                    저자값.Text = ht["author"].ToString();
                    출판사값.Text = ht["publisher"].ToString();
                    장르값.Text = ht["genre"].ToString();
                    도서위치값.Text = ht["book_location"].ToString();
                    책이미지.ImageLocation = ht["image_location"].ToString();
                    간략소개상자.Text = ht["brief_introduction"].ToString();

                }


                // 정보수정 버튼 보이기
                정보수정.Show();
                수정취소.Hide();
                수정완료.Hide();

                // 라벨 값 숨기기
                제목값.Show();
                저자값.Show();
                출판사값.Show();
                장르값.Show();
                도서위치값.Show();

                // 텍스트박스 보이기
                텍스트박스_제목값.Hide();
                텍스트박스_저자값.Hide();
                텍스트박스_출판사값.Hide();
                텍스트박스_장르값.Hide();
                텍스트박스_도서위치값.Hide();

                간략소개상자.ReadOnly = true;

            }
            else if (button.Name == "검색버튼") // admin / user 둘다 사용
            {
                if (search_category == "")
                {
                    MessageBox.Show("카테고리를 선택 해주세요.");
                    return;
                }


                책정보검색_리스트뷰.Items.Clear();

                MySql mysql = new MySql();
                //ArrayList bookinfoSearch_arry = mysql.Select(string.Format("select * from book_info where {0} LIKE '%{1}%'", search_category, 책정보검색상자.Text));
                ArrayList bookinfoSearch_arry = mysql.Select(string.Format("select * from book_info where {0} LIKE '%{1}%'", search_category, 책정보검색상자.Text));

                foreach (Hashtable ht in bookinfoSearch_arry)
                {
                    ListViewItem item = new ListViewItem("");
                    item.SubItems.Add(ht["book_number"].ToString());
                    item.SubItems.Add(ht["availability"].ToString());
                    item.SubItems.Add(ht["title"].ToString());
                    item.SubItems.Add(ht["author"].ToString());
                    item.SubItems.Add(ht["publisher"].ToString());
                    item.Font = new Font("Arial", 18, FontStyle.Italic);

                    책정보검색_리스트뷰.Items.Add(item);
                }

                Controls.Add(책정보검색_리스트뷰);
            }
        }
        public void GetInsert()
        {
            MySql my = new MySql();
            string sql = string.Format("INSERT INTO book_rental(book_number, user_number) VALUES({0}, {1}); update book_info set availability = '불가' where book_number = {0};", 번호값.Text, login_frm.User_Number.ToString());
                                        

            if (my.NonQuery(sql))
            {
                MessageBox.Show("대여 완료!");

            }

            else
            {
                MessageBox.Show("대여 실패!");
            }


        }

        private void label_Click(Object o, EventArgs e)
        {
            MessageBox.Show("동작확인 : label_Click");
        }

        private void txtbox_Click(Object o, EventArgs e)
        {
            return;
            //MessageBox.Show("동작확인 : txtbox_Click");
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





    }
}