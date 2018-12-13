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
        public RENTAL_INFO_FORM()
        {
            InitializeComponent();
            Load += RENTAL_INFO_FORM_Load;
        }

        int sX = 1500, sY = 800; // 폼 사이즈 지정.

        ///////// 좌표 체크시 추가 /////////
        static ToolStripStatusLabel StripLb;
        StatusStrip statusStrip;
        ///////////////////////////////////

        private void RENTAL_INFO_FORM_Load(object sender, EventArgs e)
        {
            Point_Print(); //좌표 
            ClientSize = new Size(sX, sY);  // 폼 사이즈 지정.
            COMMON_Create_Ctl comm = new COMMON_Create_Ctl();
            MySql mysql = new MySql();
            this.BackColor = Color.FromArgb(201, 253, 223); //백컬러
            //리스트뷰====================================================================================================================================================
            LISTVIEWclass lv_value = new LISTVIEWclass(this, "ListView1", 1300, 600, 100, 50, listview_mousedoubleclick, 3, "id", 100, "passwod", 100, "name", 100);
            ListView lv = comm.listView(lv_value);
            Controls.Add(lv);

            //버튼=========================================================================================================================================================

            ArrayList btnArray = new ArrayList();
            btnArray.Add(new BTNclass(this, "반납", "반납", 150, 80, 1250, 660, btn1_Click));

            Button btn = comm.btn((BTNclass)btnArray[0]);
            btn.Font = new Font("견명조", 24F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));  // FontStyle.Regular
            btn.FlatStyle = FlatStyle.Flat;
            btn.ForeColor = Color.LawnGreen;
            btn.BackColor = Color.ForestGreen;
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
            
        }

        private void listview_mousedoubleclick(object sender, MouseEventArgs e)
        {
            
        }

        public ArrayList GetSelect()
        {
            MySql my = new MySql();
            string sql = "select * from signup;";
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
