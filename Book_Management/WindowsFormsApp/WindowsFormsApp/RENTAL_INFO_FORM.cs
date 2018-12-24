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
    public partial class RENTAL_INFO_FORM : Form
    {
        public LOGIN_FORM Login;
        public RENTAL_INFO_FORM()
        {
            InitializeComponent();
            Load += RENTAL_INFO_FORM_Load;
        }
        public RENTAL_INFO_FORM(LOGIN_FORM Logi)
        {
            InitializeComponent();
            this.Login = Login;
        }
        
        private ListView lv;
        int sX = 1500, sY = 800; // 폼 사이즈 지정.

        //===================================================================================
        COMMON_Create_Ctl comm;
        MySql mysql;

        LISTVIEWclass lv_value;
        ///////// 좌표 체크시 추가 /////////
        static ToolStripStatusLabel StripLb;
        StatusStrip statusStrip;
        ///////////////////////////////////
        private string no;
        private void RENTAL_INFO_FORM_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;// 폼 상단 표시줄 제거

            Login = new LOGIN_FORM();

            //this.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, this.Width, this.Height, 15, 15));
            Point_Print(); //좌표 
            ClientSize = new Size(sX, sY);  // 폼 사이즈 지정.
            comm = new COMMON_Create_Ctl();
            comm.delay_rental_check();
            mysql = new MySql();
            this.BackColor = Color.FromArgb(201, 253, 223); //백컬러
            //리스트뷰===============================================================================================================================================

            lv_value = new LISTVIEWclass(this, "ListView1", 1300, 600, 100, 50, listView_MouseClick, listview_mousedoubleclick, 8, "대여번호", 100, "도서명", 260, "저자", 158, "출판사", 180, "대여일", 200, "반납일", 200, "연체일", 100, "상태", 100);
            lv = comm.listView(lv_value);
            Controls.Add(lv);
            lv.Font = new Font("Arial", 18, FontStyle.Bold);


            List_Views();
            //버튼=========================================================================================================================================================
            ArrayList btnArray = new ArrayList();
            btnArray.Add(new BTNclass(this, "반납", "반납", 150, 80, 1250, 660, btn1_Click));

            Button btn = comm.btn((BTNclass)btnArray[0]);
            btn.Font = new Font("견명조", 24F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));  // FontStyle.Regular
            btn.FlatStyle = FlatStyle.Flat;
            btn.ForeColor = Color.LawnGreen;
            btn.BackColor = Color.ForestGreen;
            btn.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, 150, 80, 15, 15));
            Controls.Add(btn);
            //라벨 ========================================================================================================================================================
            ArrayList lbarray = new ArrayList();
            lbarray.Add(new LBclass(this, "상태", "상태:", 30, 70, 50, 95, 660, label_Click));
            lbarray.Add(new LBclass(this, "staitus", "대여가능", 15, 100, 20, 170, 668, label_Click));
            lbarray.Add(new LBclass(this, "설명1", "※3회 연체, 7일이상 연체시 대여 불가상태가 됩니다.", 12, 390, 20, 830, 670, label_Click));
            lbarray.Add(new LBclass(this, "설명2", "해당 도서를 선택후 반납 버튼을 클릭하여 주세요.", 12, 380, 20, 845 ,690, label_Click));

            for (int i = 0; i < lbarray.Count; i++)
            {

                Label lb = comm.lb((LBclass)lbarray[i]);

                if (lb.Name == "상태")
                {
                    lb.Font = new Font("견명조", 20F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));
                }

                Controls.Add(lb);
            }
            //=================================================================================================================================================

        }
        
        private void label_Click(object sender, EventArgs e)
        {
         
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            GetUpdate();
            List_Views();
        }
        // 리스트뷰 ============================================================================================================================================
        public void List_Views() 
        {

            lv.Items.Clear();
            ArrayList arry = GetSelect();
            foreach (Hashtable ht in arry)
            {
                ListViewItem item = new ListViewItem(ht["대여번호"].ToString());
                item.SubItems.Add(ht["도서명"].ToString());
                item.SubItems.Add(ht["저자"].ToString());
                item.SubItems.Add(ht["출판사"].ToString());
                item.SubItems.Add(ht["대여일"].ToString().Substring(0, 10));
                item.SubItems.Add(ht["반납일"].ToString().Substring(0, 10));             
                item.SubItems.Add(ht["연체일"].ToString());                
                item.SubItems.Add(ht["상태"].ToString());
                lv.Items.Add(item);
            }
             
            Controls.Add(lv);

        }
        // 리스트뷰 클릭 =====================================================================================================
        private void listview_mousedoubleclick(object sender, MouseEventArgs e)
        {
            
        }
        // 리스트뷰 클릭 =====================================================================================================
        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("동작확인 : listView_MouseClick");
            ListView lv = (ListView)sender;
            ListView.SelectedListViewItemCollection slv = lv.SelectedItems;
            for (int i = 0; i < slv.Count; i++)
            {
                ListViewItem item = slv[i];
                no = item.SubItems[0].Text;
                //MessageBox.Show(no);
            }
        }

        public ArrayList GetSelect()
        {
            
            MySql my = new MySql();
            string sql = string.Format("select    R.rental_number 대여번호,	I.title 도서명, I.author 저자, I.publisher 출판사, R.rental_day 대여일, R.return_schedule 반납일," +
                            " case	" +
                            " when TO_DAYS(now()) - TO_DAYS(return_schedule) > 0 then '연체됨' " +
                            " when TO_DAYS(now()) - TO_DAYS(return_schedule) <= 0 then '연체안됨' " +
                            " else '' " +
                            " end 연체일," +
                            " case	" +
                            " when R.rental_status = 0 then '대여중' " +
                            " when R.rental_status = 1 then '반납요망' " +
                            " else '' " +
                            " end 상태 " +
                            " from	book_info as I " +
                            " inner join book_rental as R on " +
                            " (I.book_number = R.book_number)" +
                            "WHERE R.user_number = {0} && (R.rental_status = 1 || R.rental_status = 0);",Login.User_Number.ToString());
            MySqlDataReader sdr = my.Reader(sql);
            //string result = "";
            ArrayList list = new ArrayList();
            while (sdr.Read())
            {
                Hashtable ht = new Hashtable();
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    //result += string.Format("{0}\t:\t{1}\t", sdr.GetName(i), sdr.GetValue(i));
                    ht.Add(sdr.GetName(i), sdr.GetValue(i));

                }
                //result += "\n";
                list.Add(ht);
                Console.WriteLine(list.ToString());
            }
            return list;
        }

        public void GetUpdate()
        {
            
            MySql mysql = new MySql();
            string sql = string.Format("update book_rental set rental_status = 2 WHERE rental_number = {0};", no );
            bool status = mysql.NonQuery_INSERT(sql);

            if (status)
            {
                mysql = new MySql();
                sql = string.Format("update book_info set availability = '가능' where book_number in (select book_number from book_rental where rental_status = 2);");
                status = mysql.NonQuery_INSERT(sql);
                MessageBox.Show("반납성공");
            }
            else
            {
                MessageBox.Show("반납실패 관리자에게 문의해 주세요.");
            }
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
