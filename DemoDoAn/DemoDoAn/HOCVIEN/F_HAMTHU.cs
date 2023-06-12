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
    public partial class F_HAMTHU : Form
    {
        LoginDAO logDao = new LoginDAO();
        HocSinhDao hsDao = new HocSinhDao();
        HamThuDAO thuDao = new HamThuDAO();

        DataTable dtFULL_INFO = new DataTable();
        string IDGui ;
        string IDNhan;

        public F_HAMTHU()
        {
            InitializeComponent();
            
            //dtFULL_INFO = hsDao.LayAccID(Login.userName);
            dtFULL_INFO = logDao.loadFull();
            layIDNguoiGui();
        }

        //lay accID nguoi gui
        private void layIDNguoiGui()
        {
           for(int i = 0; i < dtFULL_INFO.Rows.Count; i++)
            {
                DataRow row  = dtFULL_INFO.Rows[i];
                if (row["USERNAME"].ToString().Trim() == Login.userName.ToString().Trim()) 
                {
                    IDGui = row["ID"].ToString().Trim();
                }
            }
            
        }

        private void picBox_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void F_HAMTHU_Load(object sender, EventArgs e)
        {
            //string AccID = hsDao.Lay_MSSV(Login.userName);
            //dt_HV = hsDao.LoadThongTin(accID);
            //lbl_HoTen.Text = dtFULL_INFO.Rows[0]["HOTEN"].ToString();
            for (int i = 0; i < dtFULL_INFO.Rows.Count; i++)
            {
                DataRow row = dtFULL_INFO.Rows[i];
                if (row["USERNAME"].ToString().Trim() == Login.userName.ToString().Trim())
                {
                    lbl_HoTen.Text = row["HOTEN"].ToString().Trim();
                }
            }
        }


        private void pBox_Gui_Click(object sender, EventArgs e)
        {
            //string accID = hsDao.LayAccID(Login.userName);
            
            HamThu thu = new HamThu(IDGui, txt_TieuDe.Text.ToString(), rTxt_NoiDung.Text.ToString(), DateTime.Now, DateTime.Now, false, IDNhan, lbl_ChucVu.Text.ToString().Trim());
            thuDao.Them(thu);
        }

        private void txt_IDNhan_TextChanged(object sender, EventArgs e)
        {
            IDNhan = txt_IDNhan.Text.ToString();
            for (int i = 0; i < dtFULL_INFO.Rows.Count; i++)
            {
                DataRow row = dtFULL_INFO.Rows[i];
                if (row["ID"].ToString().Trim() == IDNhan)
                {
                    lbl_HoTenNhan.Text = "(" + row["HOTEN"].ToString() + ")";
                    lbl_ChucVu.Text = row["ChucVu"].ToString().Trim();
                    return;
                }
                else
                {
                    lbl_HoTenNhan.Text = null;
                }
            }
        }

        //check ID
        private void loadNguoiNhan(string IDNhan)
        {
            for(int i = 0; i < dtFULL_INFO.Rows.Count; i++)
            {
                DataRow row = dtFULL_INFO.Rows[i];
                if (row["ID"].ToString().Trim() == IDNhan)
                {
                    lbl_HoTenNhan.Text = row["HOTEN"].ToString();
                }
            }
        }
    }
}
