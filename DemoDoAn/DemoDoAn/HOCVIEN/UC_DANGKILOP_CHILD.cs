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
    public partial class UC_DANGKILOP_CHILD : UserControl
    {
        string STT, maLop, tenLop, giangVien, trangThai;
        DateTime ngayBD, ngayKT;
        DangKiLopDao dklDao = new DangKiLopDao();
        HocSinhDao hsDao = new HocSinhDao();    
        PhieuThuDao ptDao = new PhieuThuDao();  

        private void UC_DANGKILOP_CHILD_Load(object sender, EventArgs e)
        {
            btn_STT.Text = STT.ToString();
            btn_MaLop.Text = maLop.ToString();
            btn_TenLop.Text = tenLop.ToString();
            btn_NgayBatDau.Text = ngayBD.ToString("dd/MM/yyyy");
            btn_NgayKetThuc.Text = ngayKT.ToString("dd/MM/yyyy");
            btn_GiangVien.Text = giangVien.ToString();
            btn_TrangThai.Text = trangThai.ToString();
        }

        public UC_DANGKILOP_CHILD()
        {
            InitializeComponent();
        }
        public UC_DANGKILOP_CHILD(string STT, string maLop, string tenLop, DateTime ngayBD, DateTime ngayKT, string giangVien, string trangThai)
        {
            InitializeComponent();
            this.STT = STT;
            this.maLop = maLop;
            this.tenLop = tenLop;
            this.ngayBD = ngayBD;
            this.ngayKT = ngayKT;
            this.giangVien = giangVien;
            this.trangThai = trangThai;
        }
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DataTable dtINFO = new DataTable();
            dtINFO = hsDao.Lay_MSSV(Login.userName);      
            string hvID = dtINFO.Rows[0]["ID"].ToString().Trim();

            //xoa lop
            dklDao.XoaLop(hvID, btn_MaLop.Text.ToString());
            //cap nhat si so lop
            dklDao.CapNhatSiSoLop();
            //xoa lich su phieu thu
            ptDao.xoaLichSuThu(hvID, btn_MaLop.Text.ToString());

            this.Hide();
        }
    }
}
