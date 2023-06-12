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
    public partial class F_NV_THEMNHANVIEN : Form
    {
        NhanVienDao nvDao = new NhanVienDao();
        public F_NV_THEMNHANVIEN()
        {
            InitializeComponent();
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       


        //them
        private void btn_HoanThanh_Click(object sender, EventArgs e)
        {
            string accID = "";
            string username = txt_UserName.Text.ToString().Trim();
            string password = txt_Pass.Text.ToString().Trim();
            string re_password = txt_RePass.Text.ToString().Trim();
            string nvid = "";
            string hoten = txt_Ten.Text.ToString().Trim();
            string cmnd = txt_CCCD.Text.ToString().Trim();
            DateTime ngaysinh = dPTime_NgaySinh.Value;
            string gioitinh = txt_GioiTinh.Text.ToString().Trim();
            string sdt = txt_SDT.Text.ToString().Trim();
            string diachi = txt_DiaChi.Text.ToString().Trim();
            string email = txt_Email.Text.ToString().Trim();
           
            
            NhanVien nv = new NhanVien(nvid, hoten, gioitinh, ngaysinh, diachi, cmnd, sdt, email, accID, username, password);
            NhanVien bangluongnv = new NhanVien(nvid, hoten);
            //check thong tin rong
            if (kiemTraThongTin(nv,  re_password))
            {
                if (kiemTraPass(password, re_password))
                {
                    //check username tồn tại chưa
                    if (kiemTraTaiKhoan(username) == true)
                    {
                        //luu acc
                        nvDao.themTaiKhoan(username, password);

                        //lấy acc id
                        DataTable dt_accID = new DataTable();
                        dt_accID = nvDao.LayAccID(nv.USERNAME);
                        nv.ACCID = dt_accID.Rows[0][0].ToString();

                        //lưu thông tin với accID đó
                        nvDao.themNhanVien(nv);
                        nvDao.themLuongNhanVien(bangluongnv);
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Tài khoản đã tồn tại!");
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu không trùng nhau!");
                }
            }
            else
            {
                MessageBox.Show("Kiểm tra lại thông tin!");
            }
        }

        //check username
        private bool kiemTraTaiKhoan(string username)
        {
            DataTable dt_accID = new DataTable();
            dt_accID = nvDao.LayAccID(username);
            if (dt_accID.Rows.Count > 0)
            {
                //đôi icon check
                return false;
            }
            else
            {
                //đổi icon check//
                return true;
            }

        }

        //check pass
        private bool kiemTraPass(string pass, string re_pass)
        {
            return pass == re_pass;
        }

        //check thong tin rong
        private bool kiemTraThongTin(NhanVien nv, string rePass)
        {
            if (String.IsNullOrEmpty(nv.USERNAME) || String.IsNullOrEmpty(nv.PASSWORD) || String.IsNullOrEmpty(rePass) || String.IsNullOrEmpty(nv.HOTEN) || String.IsNullOrEmpty(nv.GIOITINH) || String.IsNullOrEmpty(nv.NGAYSINH.ToString()) || String.IsNullOrEmpty(nv.CMND) || String.IsNullOrEmpty(nv.SDT) || String.IsNullOrEmpty(nv.EMAIL) || String.IsNullOrEmpty(nv.DIACHI))
            { return false; }
            return true;
        }

    }
}
