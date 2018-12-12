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
            //==============================================================================================================================
            LISTVIEWclass lv_value = new LISTVIEWclass(this, "ListView1", 500, 500, 10, 10, listview_mousedoubleclick, 3, "id", 100, "passwod", 100, "name", 100);
            ListView lv = comm.listView(lv_value);
            Controls.Add(lv);
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
