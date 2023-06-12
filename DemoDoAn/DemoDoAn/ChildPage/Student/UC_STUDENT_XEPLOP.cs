using DemoDoAn.ChildPage.HocTap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Controls;
using System.Windows.Forms;

namespace DemoDoAn.ChildPage
{
    public partial class UC_STUDENT_XEPLOP : UserControl
    {
        LopHocDao LopHocDao = new LopHocDao();
        BangDiemDAO bangDiemDao = new BangDiemDAO();
        HocSinhDao hvDao = new HocSinhDao();
        DanhSachLopDao dslDao = new DanhSachLopDao();

        DataTable dtKhoaHoc = new DataTable();
        DataTable dsHV = new DataTable();
        DataTable dsLop = new DataTable();

        public UC_STUDENT_XEPLOP()
        {
            InitializeComponent();
        }

        #region DoHoa
        //ẩn text Search
        bool isEmpty_Search_DSHV = true;
        bool isEmpty_Search_DSL = true;
        private void txt_SearchHVChuaCoLop_Click(object sender, EventArgs e)
        {
            an_SearchText(txt_SearchHVChuaCoLop, ref isEmpty_Search_DSHV);
        }
        private void txt_SearchDSLopHoc_Click(object sender, EventArgs e)
        {
            an_SearchText(txt_SearchDSLopHoc, ref isEmpty_Search_DSL);
        }
        private void an_SearchText(TextBox txt_Search, ref bool isEmpty_Search)
        {
            if (isEmpty_Search == true)
            {
                txt_Search.Text = String.Empty;
                txt_Search.Font = new Font(txt_Search.Font, FontStyle.Regular);
                txt_Search.ForeColor = Color.DimGray;
                isEmpty_Search = false;
            }
        }
        private void hien_SearchText(TextBox txt_Search, ref bool isEmpty_Search)
        {
            txt_Search.Text = "Search...";
            txt_Search.Font = new Font("SFU Futura", 10F, FontStyle.Italic);
            txt_Search.ForeColor = Color.Silver;
            isEmpty_Search = true;
        }
        #endregion

        private void UC_STUDENT_XEPLOP_Load(object sender, EventArgs e)
        {
            loadCbb_KhoaHoc();

        }

        //load form
        private void loadForm(DataGridView dtg, DataTable dt)
        {
            dtg.DataSource = dt;
        }

        //load ds hoc vien chua co lop
        private void taiDSHV_KhongLop()
        {
            dsHV = hvDao.LayDanhSachSinhVien();
            //loại bỏ những hv đã có trong lớp
            for (int i = dsLop.Rows.Count - 1; i >= 0; i--)
            {
                DataRow row = dsLop.Rows[i];
                for (int r = 0; r < dsHV.Rows.Count; r++)
                {
                    if (row["HVID"].ToString() == dsHV.Rows[r]["HVID"].ToString())
                    {
                        dsHV.Rows.Remove(dsHV.Rows[r]);
                        break;
                    }

                }
            }
            loadForm(dataGrView_DSHocVien, dsHV);
            for (int c = 0; c < dataGrView_DSHocVien.Columns.Count; c++)
            {
                DataGridViewColumn col = dataGrView_DSHocVien.Columns[c];
                if (col.HeaderText != "STT" && col.HeaderText != "Mã học viên" && col.HeaderText != "Tên học viên" && col.HeaderText != "Thêm")
                {
                    col.Visible = false;
                }
            }
            dataGrView_DSHocVien.Sort(dataGrView_DSHocVien.Columns["HVID_DSHV"], ListSortDirection.Ascending);
        }

        //load ds lop
        private void taiDSLop(string maLop)
        {
            dsLop = bangDiemDao.taiBangDiem(maLop);
            loadForm(dataGrView_DSLop, dsLop);
            for (int c = 0; c < dataGrView_DSLop.Columns.Count; c++)
            {
                DataGridViewColumn col = dataGrView_DSLop.Columns[c];
                if (col.HeaderText != "STT" && col.HeaderText != "Mã học viên" && col.HeaderText != "Tên học viên" && col.HeaderText != "Xóa")
                {
                    col.Visible = false;
                }
            }
            dataGrView_DSLop.Sort(dataGrView_DSLop.Columns["HVID_DSL"], ListSortDirection.Ascending);
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
            dtKhoaHoc = LopHocDao.LayDanhSachLop();
            //duyet lui chứ mỗi lần xóa bị lỗi
            int rows = dtKhoaHoc.Rows.Count;
            for (int r = rows - 1; r >= 0; r--)
            {
                DataRow row = dtKhoaHoc.Rows[r];
                if (Convert.ToInt32(row["TrangThaiKH"]) == 0)
                    dtKhoaHoc.Rows.Remove(row);
            }
            DataTable distinctMaKH = dtKhoaHoc.DefaultView.ToTable(true, new string[] { "MaKH", "TenKH" });
            loadCombobox(cbb_ChonKhoaHoc, distinctMaKH, "TenKH", "MaKH");
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
            loadCombobox(cbb_ChonLopHoc, dtLopHoc, "TenMon", "MaLop");
        }

        //xu li chon khoa hoc
        private void cbb_ChonKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;
            if (cbb.SelectedIndex >= 0)
            {
                string khoaHoc = ((DataRowView)cbb.SelectedItem)["MaKH"].ToString();
                loadCbb_LopHoc(khoaHoc);
            }
        }

        //hien thong tin lop
        private void hienThongTinLop(string maLop, string soHVHienTai)
        {
            //lấy thông tin lớp
            DataTable dtTTLop = new DataTable();
            dtTTLop = bangDiemDao.layThongTinLop(maLop);

            DataRow row = dtTTLop.Rows[0];
            lbl_TT_TenKhoaHoc.Text = row["TenKH"].ToString();
            lbl_TT_TenLopHoc.Text = row["TenMon"].ToString();
            string ngayBD = ((DateTime)row["NgayBatDau"]).ToString("dd/MM/yyyy");
            lbl_TT_NgayBatDau.Text = ngayBD;
            string ngayKT = ((DateTime)row["NgayKetThuc"]).ToString("dd/MM/yyyy");
            lbl_TT_NgayKetThuc.Text = ngayKT;
            lbl_TT_TongSoHV.Text = row["SoHocVien"].ToString();
            lbl_TT_HocVienHienTai.Text = soHVHienTai;
            lbl_TT_TenGiangVien.Text = row["HOTEN"].ToString();
            lbl_TT_SoTienHocPhi.Text = row["HocPhi"].ToString();
        }

        //them hoc vien vao lop
        private void dataGrView_DSHocVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            try
            {
                row = dataGrView_DSHocVien.Rows[e.RowIndex];
                if (dataGrView_DSHocVien.Columns[e.ColumnIndex].HeaderText == "Thêm")
                {

                    string maLop = ((DataRowView)cbb_ChonLopHoc.SelectedItem)["MaLop"].ToString();
                    string hvID = row.Cells["HVID_DSHV"].Value.ToString();
                    dslDao.themHocVienVaoLop(maLop, hvID);
                    taiDSLop(maLop);
                    taiDSHV_KhongLop();
                    hienThongTinLop(maLop, (dataGrView_DSLop.Rows.Count).ToString());
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }

        //xoa hoc vien khoi lop
        private void dataGrView_DSLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dtg = sender as DataGridView;
            //MessageBox.Show(dtg.SelectedRows.Count.ToString() + "eeee" + dtg.SelectedRows[e.RowIndex].Index.ToString());

            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dtg.Rows[e.RowIndex];
                if (dtg.Columns[e.ColumnIndex].HeaderText == "Xóa")
                {
                    if (MessageBox.Show("Bạn muốn xóa học viên?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string maLop = ((DataRowView)cbb_ChonLopHoc.SelectedItem)["MaLop"].ToString();
                        string hvID = row.Cells["HVID_DSL"].Value.ToString();
                        dslDao.xoaHocVien(maLop, hvID);
                        taiDSLop(maLop);
                        taiDSHV_KhongLop();
                        hienThongTinLop(maLop, (dtg.Rows.Count).ToString());
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }

        //tim kiem
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maLop = ((DataRowView)cbb_ChonLopHoc.SelectedItem)["maLop"].ToString();
            taiDSLop(maLop);
            taiDSHV_KhongLop();

            string soHVHienTai = (dataGrView_DSLop.Rows.Count).ToString();
            hienThongTinLop(maLop, soHVHienTai);
        }
        private void btn_SearchHVChuaCoLop_Click(object sender, EventArgs e)
        {
            locDuLieuTImKiem(dataGrView_DSHocVien, txt_SearchHVChuaCoLop.Text.ToString(), "HVID_DSHV", "HOTEN_DSHV");
        }
        private void btn_SearchDSLopHoc_Click(object sender, EventArgs e)
        {
            locDuLieuTImKiem(dataGrView_DSLop, txt_SearchDSLopHoc.Text.ToString(), "HVID_DSL", "HOTEN_DSL");
        }
        //lọc dữ liệu để tìm kiếm trong DataGridView
        private void locDuLieuTImKiem(DataGridView dtg, string searchText, string name_cotMaHV, string name_cotTenHV)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                // Nếu không có dữ liệu nhập vào, hiển thị tất cả các dòng
                dtg.Rows.Cast<DataGridViewRow>().ToList().ForEach(r => r.Visible = true);
            }
            else
            {

                for (int r = 0; r < dtg.Rows.Count; r++)
                {
                    DataGridViewRow row = dtg.Rows[r];

                    //4 dòng fix lỗi : 'Row associated with the currency manager's position cannot be made invisible.'
                    CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dtg.DataSource];
                    currencyManager1.SuspendBinding();
                    row.Visible = false;
                    currencyManager1.ResumeBinding();

                    //tim kiem dữ liệu có chứa trong các ô của row không
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        //chỉ tìm trên các ô thuộc cột HVID và Tên:
                        if (dtg.Columns[cell.ColumnIndex].Name == name_cotMaHV || dtg.Columns[cell.ColumnIndex].Name == name_cotTenHV)
                        {
                            if (cell.Value != null && cell.Value.ToString().Contains(searchText))
                            {

                                row.Visible = true;
                                break;
                            }
                        }

                    }
                }


            }
        }

        //reset
        private void btnReset_Click(object sender, EventArgs e)
        {
            lbl_TT_TenKhoaHoc.Text = String.Empty;
            lbl_TT_TenLopHoc.Text = String.Empty;
            lbl_TT_NgayBatDau.Text = String.Empty;
            lbl_TT_NgayKetThuc.Text = String.Empty;
            lbl_TT_TongSoHV.Text = String.Empty;
            lbl_TT_HocVienHienTai.Text = String.Empty;
            lbl_TT_TenGiangVien.Text = String.Empty;
            lbl_TT_SoTienHocPhi.Text = String.Empty;

            loadCbb_KhoaHoc();
            //xoa du lieu o cac DataTable
            dsHV.Clear();
            loadForm(dataGrView_DSHocVien, dsHV);
            dsLop.Clear();
            loadForm(dataGrView_DSLop, dsLop);

        }
        private void btn_ResetHVChuaCoLop_Click(object sender, EventArgs e)
        {
            //hiển thị tất cả các dòng
            dataGrView_DSHocVien.Rows.Cast<DataGridViewRow>().ToList().ForEach(r => r.Visible = true);
            hien_SearchText(txt_SearchHVChuaCoLop, ref isEmpty_Search_DSHV);
        }
        private void btn_ResetDSLopHoc_Click(object sender, EventArgs e)
        {
            //hiển thị tất cả các dòng 
            dataGrView_DSLop.Rows.Cast<DataGridViewRow>().ToList().ForEach(r => r.Visible = true);
            hien_SearchText(txt_SearchDSLopHoc, ref isEmpty_Search_DSL);
        }

        //danh STT
        private void dataGrView_DSLop_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGrView_DSLop.Rows[e.RowIndex];
            row.Cells[0].Value = (e.RowIndex + 1).ToString();
        }
        private void dataGrView_DSHocVien_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGrView_DSHocVien.Rows[e.RowIndex];
            row.Cells[0].Value = (e.RowIndex + 1).ToString();
        }


    }
}
