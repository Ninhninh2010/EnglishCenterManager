using DemoDoAn.ChildPage.General_Management;
using DemoDoAn.ChildPage.HocTap;
using DemoDoAn.ChildPage.Personnel;
using DemoDoAn.ChildPage.QLThuChi;
using DemoDoAn.ChildPage.ThongKe;
using DemoDoAn.HOCVIEN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDoAn.FORM
{
    public partial class F_Addmin : Form
    {
        ImageList imgL = new ImageList();
        
        public F_Addmin()
        {
            InitializeComponent();
            //imgL.Images.Add("pic1", new Bitmap(Application.))
            hideSubMenu();
        }
        
        private void picBox_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //ẩn menu con
        private void hideSubMenu()
        {
            foreach(var pnl in pnl_Menu.Controls.OfType<Panel>())
                pnl.Visible = false;    
        }
        //hiện menu con 
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        //
        private void selectButton(UserControl uc, PictureBox pBox)
        {
            
            switch(pBox.Name)
            {
                case "pBox_Information": pBox.Image = imgL.Images["pic1"]; break;
                case "pBox_Class": pBox.Image = imgL.Images["pic1"]; break;
                case "pBox_Room": pBox.Image = imgL.Images["pic1"]; break;
                case "pBox_Course": pBox.Image = imgL.Images["pic1"]; break;
                case "pBox_DiemSo": pBox.Image = imgL.Images["pic1"]; break;
                case "pBox_DSHV": pBox.Image = imgL.Images["pic1"]; break;
                case "pBox_DiemDanh": pBox.Image = imgL.Images["pic1"]; break;
                case "pBox_XepLop": pBox.Image = imgL.Images["pic1"]; break;
                case "pBox_GiangVien": pBox.Image = imgL.Images["pic1"]; break;
                case "pBox_NhanVien": pBox.Image = imgL.Images["pic1"]; break;
                case "pBox_BangLuong": pBox.Image = imgL.Images["pic1"]; break;
                case "pBox_PhieuThu": pBox.Image = imgL.Images["pic1"]; break;
                case "pBox_PhieuChi": pBox.Image = imgL.Images["pic1"]; break;
                case "pBox_HocPhi": pBox.Image = imgL.Images["pic1"]; break;
                case "pBox_GhiDanh": pBox.Image = imgL.Images["pic1"]; break;
                case "pBox_HocTap": pBox.Image = imgL.Images["pic1"]; break;
                case "pBox_ChamCong": pBox.Image = imgL.Images["pic1"]; break;
                default:break;
            }
            pnl_Page.Controls.Clear();
            pnl_Page.Controls.Add(uc);
        }
        private void btn_QLChung_Click(object sender, EventArgs e)
        {
        
            showSubMenu(pnl_QLManagement);
        }

        private void btn_QLHocTap_Click(object sender, EventArgs e)
        {
           
            showSubMenu(pnl_QLHocTap);
        }

        private void btn_QLHocSinh_Click(object sender, EventArgs e)
        {
            showSubMenu(pnl_QLHocVien);
        }

        private void btn_QLNhanSu_Click(object sender, EventArgs e)
        {
            showSubMenu(pnl_QLNhanSu);
        }

        private void btn_QLThuChi_Click(object sender, EventArgs e)
        {
            showSubMenu(pnl_QLThuChi);
        }

        private void btn_QLThongKe_Click(object sender, EventArgs e)
        {
            showSubMenu(pnl_QLThongKe);
        }

        private void picBox_Minisize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_DSHocSinh_Click(object sender, EventArgs e)
        {
            ChildPage.Student.UC_STUDENT_DSHocVien ucGMInfo = new ChildPage.Student.UC_STUDENT_DSHocVien();
            selectButton(ucGMInfo, pBox_DSHV);
        }

        private void btn_XepLop_Click(object sender, EventArgs e)
        {
            ChildPage.UC_STUDENT_XEPLOP ucXepLop = new ChildPage.UC_STUDENT_XEPLOP();
            selectButton(ucXepLop, pBox_XepLop);
        }

        private void btn_GiangVien_Click(object sender, EventArgs e)
        {
            ChildPage.UC_PERSONNEL_LECTURE ucLecture = new ChildPage.UC_PERSONNEL_LECTURE();
            selectButton(ucLecture, pBox_GiangVien);
        }

        private void btn_DSLop_Click(object sender, EventArgs e)
        {
            ChildPage.UC_DSLopMoi uc_Class = new ChildPage.UC_DSLopMoi();
            selectButton(uc_Class, pBox_DSHV);
        }

        private void btn_Class_Click(object sender, EventArgs e)
        {
            ChildPage.UC_GM_CLASS uc_Class = new ChildPage.UC_GM_CLASS();
            selectButton(uc_Class, pBox_Class);
        }

        private void btn_Room_Click(object sender, EventArgs e)
        {
            ChildPage.UC_GM_ROOM ucRoom = new ChildPage.UC_GM_ROOM();
            selectButton(ucRoom, pBox_Room);
        }

        private void btn_PhieuThu_Click(object sender, EventArgs e)
        {
            ChildPage.QLThuChi.UC_THUCHI_THU ucThu = new ChildPage.QLThuChi.UC_THUCHI_THU();
            selectButton(ucThu, pBox_PhieuThu);
        }

        private void btn_PhieuChi_Click(object sender, EventArgs e)
        {
            UC_THUCHI_CHI uCChi = new UC_THUCHI_CHI();
            selectButton(uCChi, pBox_PhieuChi);
        }

        private void btn_Course_Click(object sender, EventArgs e)
        {
            UC_GM_COURSE uC_Course = new UC_GM_COURSE();
            selectButton(uC_Course, pBox_Course);
        }

        private void btn_NhanVien_Click(object sender, EventArgs e)
        {
            UC_PERSONNEL_NV ucNV = new UC_PERSONNEL_NV();
            selectButton(ucNV, pBox_NhanVien);
        }

        private void btn_DiemSo_Click(object sender, EventArgs e)
        {
            UC_HOCTAP_QLDiem ucDiem = new UC_HOCTAP_QLDiem();
            selectButton(ucDiem, pBox_DiemSo);
        }

        private void btn_HocPhi_Click(object sender, EventArgs e)
        {
            UC_THONGKE_HOCPHI uC_hocPhi = new UC_THONGKE_HOCPHI();
            selectButton(uC_hocPhi, pBox_HocPhi);
        }

        private void pBox_DSHV_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            UC_HAMTHUGOPY hamThu = new UC_HAMTHUGOPY();
            selectButton(hamThu, pBox_DiemSo);
        }

        private void btn_BangLuong_Click(object sender, EventArgs e)
        {
            UC_PERSONNEL_BANGLUONG bangLuong = new UC_PERSONNEL_BANGLUONG();
            selectButton(bangLuong, pBox_BangLuong);
        }

        private void btn_GhiDanh_Click(object sender, EventArgs e)
        {
            UC_THONGKE_GHIDANH ghiDanh = new UC_THONGKE_GHIDANH();
            selectButton(ghiDanh, pBox_GhiDanh);
        }

        private void btn_HocTap_Click(object sender, EventArgs e)
        {
            UC_THONGKE_HOCTAP hocTap = new UC_THONGKE_HOCTAP();
            selectButton(hocTap, pBox_HocTap);
        }

        private void btn_ChamCong_Click(object sender, EventArgs e)
        {
            UC_THONGKE_CHAMCONG chamCong = new UC_THONGKE_CHAMCONG();
            selectButton(chamCong, pBox_ChamCong);
        }

        private void btn_LichHoc_Click(object sender, EventArgs e)
        {
            UC_GM_SCHEDULE lichhoc = new UC_GM_SCHEDULE();
            selectButton(lichhoc, pBox_Information);
        }

        private void pBox_Logout_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            if (MessageBox.Show("Bạn có muốn đăng xuất?","Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // user clicked yes
                this.Close();
                log.Show();
            }
            else
            {
                // user clicked no
            }
            
        }
    }
}
