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
    public partial class UC_DANGKILOP : UserControl
    {
        DangKiLopDao dklDao = new DangKiLopDao();
        HocSinhDao hsDao = new HocSinhDao();
        DataTable dtKQ = new DataTable("DS_KQ");
        DataTable dtTTCT = new DataTable("TTChiTiet");
        string trangThai;
        string hvID;

        enum nameCol_DSL
        {
            STT_DSL,
            MaLop_DSL,
            TenMon_DSL,
            TenKH_DSL,
            HocPhi_DSL,
            HOTEN_DSL,
            TrangThai_DSL
        }


        public UC_DANGKILOP()
        {
            InitializeComponent();
            DataTable dtINFO = new DataTable();
            dtINFO = hsDao.Lay_MSSV(Login.userName);
            hvID = dtINFO.Rows[0]["ID"].ToString().Trim();
            
        }


        private void UC_DANGKILOP_Load(object sender, EventArgs e)
        {
            taiDSL_DaDangKy();
            taiDSLDangKy();
            hienThongTinLopDaDangKy();
            //load danh sach lop hoc noi bat
            LopHoc lopHoc = new LopHoc();
            for (int r = 0; r < dataGrView_DSLop.Rows.Count - 1; r++)
            {
                lopHoc.TENLOP = dataGrView_DSLop.Rows[r].Cells["TenMon_DSL"].Value.ToString().Trim();
                lopHoc.KHOAHOC = dataGrView_DSLop.Rows[r].Cells["TenKH_DSL"].Value.ToString().Trim();
                lopHoc.HOCPHI = dataGrView_DSLop.Rows[r].Cells["HocPhi_DSL"].Value.ToString().Trim();
                lopHoc.GIANGVIEN = dataGrView_DSLop.Rows[r].Cells["HOTEN_DSL"].Value.ToString().Trim();
                fLPnl_DSL.Controls.Add(new UC_DANHSACHLOP_CHILD(lopHoc.KHOAHOC.ToString(), lopHoc.TENLOP.ToString(), lopHoc.HOCPHI.ToString(), lopHoc.GIANGVIEN.ToString()));
            }

            //load danh sach lop hoc da duoc dang ki

        }

        //load dtg
        private void loadForm(DataGridView dtg, DataTable dt)
        {
            dtg.DataSource = dt;
        }
        //tai DSL DKy
        private void taiDSLDangKy()
        {
            loadForm(dataGrView_DSLop, dklDao.LayDanhSachLop());
            //ẩn full các cột     
            for (int i = 0; i < dataGrView_DSLop.Columns.Count; i++)
            {
                DataGridViewColumn colDtg = dataGrView_DSLop.Columns[i];
                colDtg.Visible = false;
            }
            //hiện những cột cần, name của các cột được lưu trong Enum
            foreach (nameCol_DSL day in Enum.GetValues(typeof(nameCol_DSL)))
            {
                for (int i = 0; i < dataGrView_DSLop.Columns.Count; i++)
                {
                    DataGridViewColumn colDtg = dataGrView_DSLop.Columns[i];
                    if (colDtg.Name.ToString() == day.ToString())
                    {
                        colDtg.Visible = true;
                        break;
                    }
                }
            }
            dataGrView_DSLop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        ////load danh sach lop hoc da duoc dang ki
        private void hienThongTinLopDaDangKy()
        {
            fLPnl_KQ.Controls.Clear();
            taiDSL_DaDangKy();
            string maLop_Temp = "";
            int stt = 1;
            for (int i = 0; i < dtKQ.Rows.Count; i++)
            {
                if (dtKQ.Rows[i]["MaLop"].ToString() != maLop_Temp)
                {
                    fLPnl_KQ.Controls.Add(new UC_DANGKILOP_CHILD((stt++).ToString(), dtKQ.Rows[i]["MaLop"].ToString(), dtKQ.Rows[i]["TenMon"].ToString(), Convert.ToDateTime(dtKQ.Rows[i]["NgayBatDau"]), Convert.ToDateTime(dtKQ.Rows[i]["NgayKetThuc"]), dtKQ.Rows[i]["HOTEN"].ToString(), dtKQ.Rows[i]["TrangThai"].ToString()));
                    maLop_Temp = dtKQ.Rows[i]["MaLop"].ToString();
                }
                //else --i;
            }
        }
        //tai DSLdaDangKy
        private void taiDSL_DaDangKy()
        {
            dtKQ.Rows.Clear();
            dtKQ = dklDao.LayDanhSachLopDaDangKi(hvID);
        }

        private void btn_DangKi_Click(object sender, EventArgs e)
        {
            DataTable dtINFO = new DataTable();
            dtINFO = hsDao.Lay_MSSV(Login.userName);
            string hvID = dtINFO.Rows[0]["ID"].ToString().Trim();
            //check trung lich

            //check lop da dang ky
            if (kiemTraLop()== true)
            {
                //thêm học viên vào lớp + cập nhật sĩ số lớp đó
                dklDao.DangKiLop(hvID, lbl_MaLop.Text, trangThai);
                hienThongTinLopDaDangKy();
                taiDSLDangKy();
            }
            else
            {
                MessageBox.Show("Lớp học đã được đăng ký trước đó!");
            }
            
        }

        //check lop da dang ky
        private bool kiemTraLop()
        {
            string maLop = lbl_MaLop.Text.ToString();
            for (int r = 0; r < dtKQ.Rows.Count; r++)
            {
                if (dtKQ.Rows[r]["MaLop"].ToString() == maLop)
                {
                    return false;
                }
            }
            return true;
        }
        //check trung lich
        private bool kiemTraTrungLich(string maLop)
        {

            return true;
        }

        //xu li truyen thong tin
        private void dataGrView_DSLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGrView_DSLop.Rows[e.RowIndex];

            lbl_MaLop.Text = row.Cells["MaLop_DSL"].Value.ToString();
            lbl_TT_TenKhoaHoc.Text = row.Cells["TenKH_DSL"].Value.ToString();
            lbl_TT_TenLopHoc.Text = row.Cells["TenMon_DSL"].Value.ToString();
            trangThai = row.Cells["TrangThai_DSL"].Value.ToString();

            //đọc dữ liệu
            dtTTCT = dklDao.LayThongTinLop(row.Cells["MaLop_DSL"].Value.ToString());
            //gán thứ
            lbl_Thu.Text = String.Empty;
            for (int r = 0; r < dtTTCT.Rows.Count; r++)
            {
                lbl_Thu.Text += "Thứ " + dtTTCT.Rows[r]["Thu"].ToString() + "\n\n";
            }
            //phòng
            lbl_SoPhongHoc.Text = dtTTCT.Rows[0]["Phong"].ToString();

            //giờ BD: TIME -> TimeSpan
            TimeSpan gioBD = (TimeSpan)dtTTCT.Rows[0]["GioBatDau"];
            lbl_GioBatDau.Text = gioBD.ToString(@"hh\:mm");

            //Giờ KT
            TimeSpan gioKT = (TimeSpan)dtTTCT.Rows[0]["GioKetThuc"];
            lbl_GioKetThuc.Text = gioKT.ToString(@"hh\:mm");

            //Ngày BD: DATE -> DateTime
            DateTime ngayBD = (DateTime)dtTTCT.Rows[0]["NgayBatDau"];
            lbl_NgayBatDau.Text = ngayBD.ToString("dd/MM/yyyy");

            //NgàyKT
            DateTime ngayKT = (DateTime)dtTTCT.Rows[0]["NgayKetThuc"];
            lbl_NgayKetThuc.Text = ngayKT.ToString("dd/MM/yyyy");
        }

        //danh STT
        private void dataGrView_DSLop_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGrView_DSLop.Rows[e.RowIndex];
            if (row != dataGrView_DSLop.Rows[dataGrView_DSLop.Rows.Count - 1])
            {
                row.Cells[0].Value = (e.RowIndex + 1).ToString();
            }
        }

        //to mau
        private void dataGrView_DSLop_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           

        }
    }
}
