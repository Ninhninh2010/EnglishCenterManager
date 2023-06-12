using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDoAn.ChildPage.Personnel
{

    public partial class UC_PERSONNEL_BANGLUONG : UserControl
    {
        BangLuongDao bang=new BangLuongDao();
        public UC_PERSONNEL_BANGLUONG()
        {
            InitializeComponent();
        }

        private void dataGrView_DSGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            this.dataGrView_DSGV.DataSource = bang.LayThongTinLuong("5");
            dataGrView_DSGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void UC_PERSONNEL_BANGLUONG_Load(object sender, EventArgs e)
        {
            this.dataGrView_DSGV.DataSource = bang.LayThongTinLuong("5");
            dataGrView_DSGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
