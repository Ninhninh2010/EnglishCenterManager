using DemoDoAn.Custom_Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDoAn.ChildPage.General_Management.UC_GM_CLASS
{
    public partial class F_GM_CLASS_TaoLopMoi : Form
    {
        LopHocDao lopHocDao = new LopHocDao();
        KhoaHocDao khoaHocDao = new KhoaHocDao();
        DataTable dtKhoaHoc = new DataTable("KhoaHoc");

        public F_GM_CLASS_TaoLopMoi()
        {
            InitializeComponent();
        }

        private void F_GM_CLASS_TaoLopMoi_Load(object sender, EventArgs e)
        {
            loadCbbKhoaHoc();
        }

        private void cbb_ChonKhoaHoc_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            RJComboBox cbb = sender as RJComboBox;
            txt_ChonKhoaHoc.Visible = false;
        }

        //load khoa hoc len cbb
        private void loadCbbKhoaHoc()
        {
            dtKhoaHoc.Rows.Clear();
            dtKhoaHoc = khoaHocDao.LayKhoaHoc();
            //duyet lui chứ mỗi lần xóa bị lỗi
            int rows = dtKhoaHoc.Rows.Count;
            for (int r = rows - 1; r >= 0; r--)
            {
                DataRow row = dtKhoaHoc.Rows[r];
                if (Convert.ToInt32(row["TrangThaiKH"]) == 0)
                    dtKhoaHoc.Rows.Remove(row);
            }
            loadCombobox(cbb_ChonKhoaHoc, dtKhoaHoc, "TenKH", "MaKH");
        }

        //load combobox
        private void loadCombobox(RJComboBox cbb, DataTable dt, string displayMember, string valueMember)
        {
            cbb.DataSource = dt;
            cbb.DisplayMember = displayMember;
            cbb.ValueMember = displayMember;
        }

        //rut gon tu
        private string rutGonTen(string tenlop)
        {
            return tenlop;
        }

        //them
        private void btn_HoanThanh_Click(object sender, EventArgs e)
        {
            string maKH = ((DataRowView)cbb_ChonKhoaHoc.SelectedItem)["MaKH"].ToString();
            string tengon = rutGonTen(txt_TenLopMoi.Text.ToString());
            LopHoc lop = new LopHoc(maKH, txt_TenLopMoi.Text.ToString(), txt_HocPhi.Text.ToString());
            lopHocDao.themLopHoc(lop, tengon);
            this.Close();
        }

        //thoat
        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
