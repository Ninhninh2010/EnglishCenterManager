using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDoAn.ChildPage.HocTap
{
    public partial class UC_HOCTAP_QLDiem : UserControl
    {
        LopHocDao LopHocDao = new LopHocDao();
        BangDiemDAO bangDiemDao = new BangDiemDAO();
        DataTable dtBangDiem = new DataTable();
        DataTable dtKhoaHoc = new DataTable();

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

        public UC_HOCTAP_QLDiem()
        {
            InitializeComponent();
        }

        private void UC_HOCTAP_QLDiem_Load(object sender, EventArgs e)
        {
            loadCbb_KhoaHoc();
        }

        //tai DSL
        private void taiBangDiem(DataGridView dtg, string maLop)
        {

            dtBangDiem.Rows.Clear();
            dtBangDiem = bangDiemDao.taiBangDiem(maLop);
            LoadForm(dtg, dtBangDiem);

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
            dataGrView_BangDiem.Sort(dataGrView_BangDiem.Columns["XepHang"], ListSortDirection.Descending);
            xepThuHang();
            dtg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        //load dtg
        private void LoadForm(DataGridView dtg, DataTable dt)
        {
            dtg.DataSource = dt;
        }

        //cap nhat diem
        private void btn_CapNhatDiem_Click(object sender, EventArgs e)
        {
            string maLop = ((DataRowView)cbb_LopHoc.SelectedItem)["MaLop"].ToString();
            for (int r = 0; r < dataGrView_BangDiem.Rows.Count; r++)
            {
                DataGridViewRow row = dataGrView_BangDiem.Rows[r];
                string HvID = row.Cells["HvID"].Value.ToString();
                double diemGK = Convert.ToDouble(row.Cells["DiemGiuaKy"].Value.ToString());
                double diemCK = Convert.ToDouble(row.Cells["DiemCuoiKy"].Value.ToString());
                bangDiemDao.capNhatDiem(maLop, HvID, diemGK, diemCK);
            }
            taiBangDiem(dataGrView_BangDiem, maLop);
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

        //xu li chon lop hoc
        private void cbb_LopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;
            if (cbb.SelectedIndex >= 0)
            {
                string maLop = ((DataRowView)cbb_LopHoc.SelectedItem)["maLop"].ToString();
                taiBangDiem(dataGrView_BangDiem, maLop);

                string soHVHienTai = (dataGrView_BangDiem.Rows.Count).ToString();
                hienThongTinLop(maLop, soHVHienTai);
            }
        }

        //hiện thông tin lớp
        private void hienThongTinLop(string maLop, string soHVHienTai)
        {
            DataTable dtTTLop = new DataTable();
            dtTTLop = bangDiemDao.layThongTinLop(maLop);
            //
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

        //tim kiem
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maLop = ((DataRowView)cbb_LopHoc.SelectedItem)["maLop"].ToString();
            taiBangDiem(dataGrView_BangDiem, maLop);

            string soHVHienTai = (dataGrView_BangDiem.Rows.Count).ToString();
            hienThongTinLop(maLop, soHVHienTai);

        }

        //xep thu hang
        private void xepThuHang()
        {
            double diem = 11;
            int idxRank = 0;
            for (int r = 0; r < dataGrView_BangDiem.Rows.Count; r++)
            {
                DataGridViewRow row = dataGrView_BangDiem.Rows[r];

                if (Convert.ToDouble(row.Cells["DiemTB"].Value) < diem)
                {
                    row.Cells["ThuHang"].Value = (++idxRank).ToString();
                    diem = Convert.ToDouble(row.Cells["DiemTB"].Value);
                }
                else row.Cells["ThuHang"].Value = (idxRank).ToString();


            }
        }

        //danh STT
        private void dataGrView_BangDiem_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGrView_BangDiem.Rows[e.RowIndex];

            row.Cells[0].Value = (e.RowIndex + 1).ToString();

        }

        //load diem bi thay doi
        private void dataGrView_BangDiem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = sender as DataGridViewCell;
            cell = dataGrView_BangDiem.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (String.IsNullOrEmpty(cell.Value.ToString()))
                cell.Value = 0.0;
        }

        //reset
        private void btnReset_Click(object sender, EventArgs e)
        {
            lblKhoaHoc.Visible = true;
            lblLopHoc.Visible = true;
            lbl_TT_TenKhoaHoc.Text = String.Empty;
            lbl_TT_TenLopHoc.Text = String.Empty;
            lbl_TT_NgayBatDau.Text = String.Empty;
            lbl_TT_NgayKetThuc.Text = String.Empty;
            lbl_TT_TongSoHV.Text = String.Empty;
            lbl_TT_HocVienHienTai.Text = String.Empty;
            lbl_TT_TenGiangVien.Text = String.Empty;
            lbl_TT_SoTienHocPhi.Text = String.Empty;
        }

        private void cbb_KhoaHoc_Click(object sender, EventArgs e)
        {
            lblKhoaHoc.Visible = false;
            lblLopHoc.Visible = false;
        }

        private void dataGrView_BangDiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_TTLopHoc_Click(object sender, EventArgs e)
        {

        }
    }
}
