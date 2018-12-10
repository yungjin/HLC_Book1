using System;
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
    public partial class BOOK_INFO_FORM : Form
    {
        public BOOK_INFO_FORM()
        {
            InitializeComponent();

            Load += User1_Load;
        }

        private void User1_Load(object sender, EventArgs e)
        {
            COMMON_Create_Ctl comm = new COMMON_Create_Ctl();
            LISTVIEWclass bookLv_valu = new LISTVIEWclass(this, "ListView1", 500, 500, 10, 10, BookLv_Click, 3, "id", 100, "name", 100, "passwd", 100);

            ListView bookLv = comm.listView(bookLv_valu);


        }

        private void BookLv_Click(object sender, MouseEventArgs e)
        {

        }
    }
}
