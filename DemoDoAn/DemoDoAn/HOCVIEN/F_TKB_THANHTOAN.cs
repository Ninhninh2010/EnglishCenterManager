using DemoDoAn.Custom_Control;
using DemoDoAn.HOCVIEN.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDoAn.HOCVIEN
{
    public partial class F_TKB_THANHTOAN : Form
    {
        TKBDao tkbDao = new TKBDao();
        HocSinhDao hsDao = new HocSinhDao();
        DataTable dt = new DataTable("ThanhToan");

        public F_TKB_THANHTOAN()
        {
            InitializeComponent();
            taiThongTinThanhToan();
        }

        //exit
        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //thanh toan hoc phi
        private void btn_HoanThanh_Click(object sender, EventArgs e)
        {
            DataTable dtINFO = new DataTable();
            dtINFO = hsDao.Lay_MSSV(Login.userName);
            string hvID = dtINFO.Rows[0]["ID"].ToString().Trim();
            string tienTaiKhoan = tkbDao.LaySoDuTK(hvID);
            int soTienDong;
            string maLop = ((DataRowView)cbb_ChonLopHoc.SelectedItem)["MaLop"].ToString();
            
            if (int.TryParse(txt_TienDong.Text, out soTienDong) == true)
            {
                if (Convert.ToInt32(txt_TienDong.Text) > Convert.ToInt32(lbl_ConNo.Text) || Convert.ToInt32(txt_TienDong.Text) > Convert.ToInt32(tienTaiKhoan))
                {
                    MessageBox.Show("Vui lòng kiểm tra số dư tài khoản và học phí của bạn!");
                }
                else
                {
                    tkbDao.thanhToanTien(hvID, maLop, soTienDong);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra số tiền thanh toán!");
            }

            
        }

        private void F_TKB_THANHTOAN_Load(object sender, EventArgs e)
        {
            taiThongTinThanhToan();
        }

        //
        private void taiThongTinThanhToan()
        {
            DataTable dtINFO = new DataTable();
            dtINFO = hsDao.Lay_MSSV(Login.userName);
            string hvid = dtINFO.Rows[0]["ID"].ToString().Trim();
            dt = tkbDao.loadDSL(hvid);
            //load combobox
            loadCombobox(cbb_ChonKhoaHoc, dt, "TenKH", "TenMon");
            loadCombobox(cbb_ChonLopHoc, dt, "TenMon", "MaLop");
        }

        //load combobox
        private void loadCombobox(RJComboBox cbb, DataTable dt, string displayMember, string valueMember)
        {
            cbb.DataSource = dt;
            cbb.DisplayMember = displayMember;
            cbb.ValueMember = displayMember;
        }

        private void cbb_ChonKhoaHoc_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        //hiện học phí và số tiền còn nợ
        private void cbb_ChonLopHoc_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            txt_ChonLopHoc.Visible = false;
            //MessageBox.Show(((DataRowView)cbb_ChonLopHoc.SelectedItem)["ConNo"].ToString());
            lbl_TienHP.Text =((DataRowView)cbb_ChonLopHoc.SelectedItem)["HocPhi"].ToString();
            lbl_ConNo.Text = ((DataRowView)cbb_ChonLopHoc.SelectedItem)["ConNo"].ToString();
        }
    }

}
