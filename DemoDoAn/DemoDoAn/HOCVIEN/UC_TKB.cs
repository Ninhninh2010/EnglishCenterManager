using DemoDoAn.ChildPage.HocTap;
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
    public partial class UC_TKB : UserControl
    {
        int chucVu; // 0 la admin;  1 la hocvien;  2 la giao vien

        TKBDao tkbDao = new TKBDao();
        HocSinhDao hsDao = new HocSinhDao();
        BangDiemDAO bangDiemDao = new BangDiemDAO();
        LopHocDao lopDao = new LopHocDao();

        DataTable dt = new DataTable("TKB");
        DataTable dtBangDiemGV = new DataTable();
        DataTable dtKhoaHoc = new DataTable();

        string ID;
        //bang diem HV
        enum nameCol_BangDiem
        {
            STT_BD,
            MaLop_BD,
            TenMon_BD,
            DiemGiuaKy_BD,
            DiemCuoiKy_BD,
            DiemTB_BD
        }
        //bang nhap diem GV
        enum nameCol_BD
        {
            STT,
            HVID,
            HOTEN,
            DiemGiuaKy,
            DiemCuoiKy,
            DiemTB,
            ThuHang
        }

        //list luu img màu nền 
        List<string> linkBG = new List<string>
            {
                "01_tkb@3x",
                "02_tkb@3x",
                "03_tkb@3x",
                "04_tkb@3x",
                "05_tkb@3x",
                "06_tkb@3x"
            };
        //luu bảng màu tương ứng
        List<Color> colorBG = new List<Color>
            {
                Color.FromArgb(1, 118, 225),
                Color.FromArgb(152, 86, 250),
                Color.FromArgb(253, 82, 97),
                Color.FromArgb(14, 216, 75),
                Color.FromArgb(254, 188, 67),
                Color.FromArgb(58, 54, 96)
            };


        public UC_TKB(int chucVu)
        {
            InitializeComponent();
            this.chucVu = chucVu;
        }

        private void UC_TKB_Load(object sender, EventArgs e)
        {
            DataTable dtINFO = new DataTable();
            dtINFO = hsDao.Lay_MSSV(Login.userName);
            string hvID = dtINFO.Rows[0]["ID"].ToString().Trim();
            creTKB();
            LoadForm(dataGrView_DSLop, tkbDao.loadDSL(hvID));
            layID();

            //
            if (chucVu == 1)//hocvien
            {
                taiBangDiemHV(hvID);
                pnl_QLCapNhatDiem.Visible = false;
                fLPnl_QLTable.Height -= 359;
                pnl_PHANCACH.Location = new Point(pnl_PHANCACH.Location.X, pnl_PHANCACH.Location.Y - 659);
            }
            else if (chucVu == 2)//giang vien
            {
                loadCbb_KhoaHoc();
                pnl_QLThanhToan.Visible = false;
                pnl_QLDiemHV.Visible = false;
                fLPnl_QLTable.Height -= (pnl_QLThanhToan.Height + pnl_QLDiemHV.Height);
                pnl_PHANCACH.Location = new Point(pnl_PHANCACH.Location.X, pnl_PHANCACH.Location.Y - pnl_QLThanhToan.Height - pnl_QLDiemHV.Height);
            }
            
        }

        //lay ID user
        private void layID()
        {
            DataTable dtID = new DataTable();
            dtID = hsDao.Lay_MSSV(Login.userName);
            ID = dtID.Rows[0]["ID"].ToString().Trim();
        }

        //tai bang cap nhat diem
        private void taiBangDiemGV(DataGridView dtg, string maLop)
        {

            dtBangDiemGV.Rows.Clear();
            dtBangDiemGV = bangDiemDao.taiBangDiem(maLop);
            LoadForm(dtg, dtBangDiemGV);

            //ẩn full các cột     
            for (int i = 0; i < dtg.Columns.Count; i++)
            {
                DataGridViewColumn colDtg = dtg.Columns[i];
                colDtg.Visible = false;
            }
            //hiện những cột cần, name của các cột được lưu trong Enum
            foreach (nameCol_BD day in Enum.GetValues(typeof(nameCol_BD)))
            {
                for (int i = 0; i < dtg.Columns.Count; i++)
                {
                    DataGridViewColumn colDtg = dtg.Columns[i];
                    if (colDtg.Name.ToString() == day.ToString())
                    {
                        colDtg.Visible = true;
                        break;
                    }
                }
            }

            //xem hang
            dataGrView_CapNhatDiem.Sort(dataGrView_CapNhatDiem.Columns["XepHang"], ListSortDirection.Descending);
            xepThuHang();
            dtg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        //xep thu hang
        private void xepThuHang()
        {
            double diem = 11;
            int idxRank = 0;
            for (int r = 0; r < dataGrView_CapNhatDiem.Rows.Count; r++)
            {
                DataGridViewRow row = dataGrView_CapNhatDiem.Rows[r];

                if (Convert.ToDouble(row.Cells["DiemTB"].Value) < diem)
                {
                    row.Cells["ThuHang"].Value = (++idxRank).ToString();
                    diem = Convert.ToDouble(row.Cells["DiemTB"].Value);
                }
                else row.Cells["ThuHang"].Value = (idxRank).ToString();
            }
            //dataGrView_CapNhatDiem.Refresh();
        }


        //load bang diem
        private void taiBangDiemHV(string hvID)
        {
            LoadForm(dataGrView_BangDiem, hsDao.taiBangDiem(hvID));
            for (int i = 0; i < dataGrView_BangDiem.Columns.Count; i++)
            {
                DataGridViewColumn colDtg = dataGrView_BangDiem.Columns[i];
                colDtg.Visible = false;
            }
            //hiện những cột cần, name của các cột được lưu trong Enum
            foreach (nameCol_BangDiem day in Enum.GetValues(typeof(nameCol_BangDiem)))
            {
                for (int i = 0; i < dataGrView_BangDiem.Columns.Count; i++)
                {
                    DataGridViewColumn colDtg = dataGrView_BangDiem.Columns[i];
                    if (colDtg.Name.ToString() == day.ToString())
                    {
                        colDtg.Visible = true;
                        break;
                    }
                }
            }
            dataGrView_BangDiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        //thanh toan hoc phi
        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            F_TKB_THANHTOAN thanhtoan = new F_TKB_THANHTOAN();
            thanhtoan.ShowDialog();
            DataTable dtINFO = new DataTable();
            dtINFO = hsDao.Lay_MSSV(Login.userName);
            string hvID = dtINFO.Rows[0]["ID"].ToString().Trim();
            LoadForm(dataGrView_DSLop, tkbDao.loadDSL(hvID));
        }

        //xu li TKB
        private void creTKB()
        {
            //lưu lịch học 
            DataTable dtINFO = new DataTable();
            dtINFO = hsDao.Lay_MSSV(Login.userName);
            string ID = dtINFO.Rows[0]["ID"].ToString().Trim();

            //
            if (chucVu == 1)//hoc vien
            {
                dt = tkbDao.LayTKB(ID);
            }
            else if (chucVu == 2)
            {
                dt = tkbDao.loadDSLopDay(ID);
            }


            //tạo List lưu tên các môn của học sinh đó đã đăng kí
            List<string> MonHocList = new List<string>();
            string temp = "";
            for (int row = 0; row < dt.Rows.Count; row++)
            {
                if (dt.Rows[row]["TenMon"].ToString() != temp)
                {
                    MonHocList.Add(dt.Rows[row]["TenMon"].ToString());
                    temp = dt.Rows[row]["TenMon"].ToString();
                }
            }

            //in môn + phòng vào TKB
            for (int i = 0; i < MonHocList.Count; i++)
            {
                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    string pnlQlThu = "pnl_QLThu";//lưu pnl quản lí các thứ
                    string pnlName = "pnl";//lưu pnl trong mỗi pnl thứ
                    string pBoxName = "pBox";
                    if (dt.Rows[r]["TenMon"].ToString() == MonHocList[i])
                    {
                        pBoxName += "_T" + dt.Rows[r]["Thu"].ToString() + "_" + dt.Rows[r]["Ca"].ToString();//pBox_T2_1
                        pnlName += "_T" + dt.Rows[r]["Thu"].ToString() + "_" + dt.Rows[r]["Ca"].ToString();//pnl_T2_1
                        pnlQlThu += dt.Rows[r]["Thu"].ToString();//pnlQLThu_2
                        //duyệt từng lớp Panel
                        foreach (Panel pnlQLThu in pnl_QLTKB.Controls.OfType<Panel>())
                        {
                            if (pnlQLThu.Name == pnlQlThu)
                                foreach (Panel pnl in pnlQLThu.Controls.OfType<Panel>())
                                    if (pnl.Name == pnlName)
                                        foreach (PictureBox pBox in pnl.Controls.OfType<PictureBox>())
                                            if (pBox.Name == pBoxName)
                                            {
                                                insertMH(dt.Rows[r]["TenMonGon"].ToString(), dt.Rows[r]["Phong"].ToString(), pBox, linkBG[i], pnl, i);
                                                break;
                                            }

                        }
                    }
                }

            }
        }

        //insert to TKB
        private void insertMH(string tenMonGon, string phongHoc, PictureBox pBox, string imgBG, Panel pnlGioHoc, int idxColor)
        {
            //in tên môn học
            Label lbl_tenMH = new Label();
            cusLable(lbl_tenMH, tenMonGon, pBox, imgBG, pnlGioHoc, 20, 21, idxColor);
            //in tên phòng học
            Label lbl_phong = new Label();
            cusLable(lbl_phong, phongHoc, pBox, imgBG, pnlGioHoc, 20, 52, idxColor);
        }

        //custom Lable
        private void cusLable(Label lbl, string lblText, PictureBox pBox, string imgName, Panel pnlGioHoc, int x, int y, int idxColor)
        {
            pnlGioHoc.Controls.Add(lbl);
            lbl.Text = lblText;
            lbl.Location = new Point(x, y);//
            lbl.Name = "lbl_tenMH";
            lbl.ForeColor = Color.White;
            lbl.BackColor = colorBG[idxColor];
            lbl.Font = new Font("Lato", 10, FontStyle.Bold);
            lbl.BringToFront();
            pBox.Image = new Bitmap(Application.StartupPath + "\\Resources\\" + imgName + ".png");
            pBox.SendToBack();

        }
        //
        private DataTable creaDataTable(DataTable dt)
        {
            DataTable dtINFO = new DataTable();
            dtINFO = hsDao.Lay_MSSV(Login.userName);
            string hvID = dtINFO.Rows[0]["ID"].ToString().Trim();
            dt.Columns.Add("TenMon");
            dt.Columns.Add("Thu");
            dt.Columns.Add("Ca");
            dt.Columns.Add("GioBD", typeof(DateTime));
            dt.Columns.Add("GioKT", typeof(DateTime));
            dt.Columns.Add("Phong");
            dt.Columns.Add("MaLop");

            dt = tkbDao.LayTKB(hvID);
            return dt;
        }


        //load combobox
        private void loadCombobox(ComboBox cbb, DataTable dt, string displayMember, string valueMember)
        {
            cbb.DataSource = dt;
            cbb.DisplayMember = displayMember;
            cbb.ValueMember = displayMember;
        }
        //load cbb khoa hoc
        private void loadCbb_KhoaHoc()
        {
            dtKhoaHoc.Rows.Clear();
            dtKhoaHoc = lopDao.LayDanhSachLop();

            //duyet lui chứ mỗi lần xóa bị lỗi
            int rows = dtKhoaHoc.Rows.Count;
            for (int r = rows - 1; r >= 0; r--)
            {
                DataRow row = dtKhoaHoc.Rows[r];
                //loai bỏ những hàng không hoạt động và không phải do giáo viên đó dạy:
                if (Convert.ToInt32(row["TrangThaiKH"]) == 0 || row["GiangVien"].ToString().Trim() != ID)
                    dtKhoaHoc.Rows.Remove(row);
            }
            //lọc bỏ khá học trùng
            DataTable distinctMaKH = dtKhoaHoc.DefaultView.ToTable(true, new string[] { "MaKH", "TenKH" });
            loadCombobox(cbb_KhoaHoc, distinctMaKH, "TenKH", "MaKH");
        }
        //load cbb lop hoc
        private void loadCbb_LopHoc(string maKH)
        {
            //tạo DT mới có số cột = số cột cũ qua .Clone()
            DataTable dtLopHoc = dtKhoaHoc.Clone();

            for (int r = 0; r < dtKhoaHoc.Rows.Count; r++)
            {
                //tìm những dòng có MãKH đã được chọn
                if (dtKhoaHoc.Rows[r]["MaKH"].ToString() == maKH)
                {
                    //tạo dataRow lưu hàng đó lại
                    DataRow newRow = dtLopHoc.NewRow();
                    newRow.ItemArray = dtKhoaHoc.Rows[r].ItemArray; // sao chép dữ liệu từ dòng r của dt vào newRow
                    dtLopHoc.Rows.Add(newRow);
                }
            }
            //load những lớp thuộc MãKH đó lên thôi
            loadCombobox(cbb_LopHoc, dtLopHoc, "TenMon", "MaLop");
        }
        //xuli chon khoa hoc
        private void cbb_KhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;
            if (cbb.SelectedIndex >= 0)
            {
                string khoaHoc = ((DataRowView)cbb.SelectedItem)["MaKH"].ToString();
                loadCbb_LopHoc(khoaHoc);
            }
            //lblKhoaHoc.Visible = false;
        }
        //xu li tim kiem chon lop hoc
        private void cbb_LopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;
            if (cbb.SelectedIndex >= 0)
            {
                string maLop = ((DataRowView)cbb_LopHoc.SelectedItem)["maLop"].ToString();
                taiBangDiemGV(dataGrView_CapNhatDiem, maLop);
            }
        }


        //load datagrview
        private void LoadForm(DataGridView dtg, DataTable dt)
        {
            dtg.DataSource = dt;
        }


        //danh STT
        private void dataGrView_CapNhatDiem_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGrView_CapNhatDiem.Rows[e.RowIndex];
            row.Cells[0].Value = (e.RowIndex + 1).ToString();
        }
        private void dataGrView_BangDiem_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGrView_BangDiem.Rows[e.RowIndex];
            row.Cells[0].Value = (e.RowIndex + 1).ToString();
        }


        //load diem bi thay doi
        private void dataGrView_CapNhatDiem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = sender as DataGridViewCell;
            cell = dataGrView_CapNhatDiem.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (String.IsNullOrEmpty(cell.Value.ToString()))
                cell.Value = 0.0;
        }

        //cap nhat diem
        private void btn_CapNhatDiem_Click(object sender, EventArgs e)
        {
            string maLop = ((DataRowView)cbb_LopHoc.SelectedItem)["MaLop"].ToString();
            for (int r = 0; r < dataGrView_CapNhatDiem.Rows.Count; r++)
            {
                DataGridViewRow row = dataGrView_CapNhatDiem.Rows[r];
                string HvID = row.Cells["HvID"].Value.ToString();
                double diemGK = Convert.ToDouble(row.Cells["DiemGiuaKy"].Value.ToString());
                double diemCK = Convert.ToDouble(row.Cells["DiemCuoiKy"].Value.ToString());
                bangDiemDao.capNhatDiem(maLop, HvID, diemGK, diemCK);
            }
            taiBangDiemGV(dataGrView_BangDiem, maLop);
        }
    }
}
