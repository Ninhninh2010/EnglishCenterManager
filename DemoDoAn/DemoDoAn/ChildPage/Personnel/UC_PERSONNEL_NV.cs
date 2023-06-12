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
    public partial class UC_PERSONNEL_NV : UserControl
    {
        NhanVienDao nvDao=new NhanVienDao();
        NhanVien nv = new NhanVien();
        enum nameCol_DSNV
        {
            STT,
            NVID,
            HOTEN,
            GIOITINH,
            Xoa
        }

        public UC_PERSONNEL_NV()
        {
            InitializeComponent();
        }

        #region DOHOA
        bool isEmpty_Search = true;
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
        private void txt_Search_Click(object sender, EventArgs e)
        {
            an_SearchText(txt_Search, ref isEmpty_Search);
        }
        #endregion

        private void UC_PERSONNEL_NV_Load(object sender, EventArgs e)
        {
            taiDSNV();

        }

        //tai DSNV
        private void taiDSNV()
        {
            loadForm(dataGrView_DSNV, nvDao.LayDanhSachNhanVien());
            //ẩn full các cột     
            for (int i = 0; i < dataGrView_DSNV.Columns.Count; i++)
            {
                DataGridViewColumn colDtg = dataGrView_DSNV.Columns[i];
                colDtg.Visible = false;
            }
            //hiện những cột cần, name của các cột được lưu trong Enum
            foreach (nameCol_DSNV day in Enum.GetValues(typeof(nameCol_DSNV)))
            {
                for (int i = 0; i < dataGrView_DSNV.Columns.Count; i++)
                {
                    DataGridViewColumn colDtg = dataGrView_DSNV.Columns[i];
                    if (colDtg.Name.ToString() == day.ToString())
                    {
                        colDtg.Visible = true;
                        break;
                    }
                }
            }
            dataGrView_DSNV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        //load dtg
        private void loadForm(DataGridView dtg, DataTable dt)
        {
            dtg.DataSource = dt;
        }

        //xu li dtg + XOA nhan vien
        private void dataGrView_DSNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dtg = sender as DataGridView;
            //cập nhật giáo viên đang được chọn
            string nvID = dataGrView_DSNV.Rows[e.RowIndex].Cells["NVID"].Value.ToString().Trim();
            string ten = dataGrView_DSNV.Rows[e.RowIndex].Cells["HOTEN"].Value.ToString().Trim();
            string cmnd = dataGrView_DSNV.Rows[e.RowIndex].Cells["CMND"].Value.ToString().Trim();
            DateTime ngaySinh = Convert.ToDateTime(dataGrView_DSNV.Rows[e.RowIndex].Cells["NGAYSINH"].Value.ToString().Trim());
            string gioiTinh = dataGrView_DSNV.Rows[e.RowIndex].Cells["GIOITINH"].Value.ToString().Trim();
            string SDT = dataGrView_DSNV.Rows[e.RowIndex].Cells["SDT"].Value.ToString().Trim();
            string diaChi = dataGrView_DSNV.Rows[e.RowIndex].Cells["DIACHI"].Value.ToString().Trim();
            string email = dataGrView_DSNV.Rows[e.RowIndex].Cells["EMAIL"].Value.ToString().Trim();
            string accID = dataGrView_DSNV.Rows[e.RowIndex].Cells["AccID_NV"].Value.ToString().Trim();
            string username = dataGrView_DSNV.Rows[e.RowIndex].Cells["username"].Value.ToString().Trim();
            string password =   dataGrView_DSNV.Rows[e.RowIndex].Cells["pass"].Value.ToString().Trim();
            nv = capNhatGV(ref nv, nvID, ten, cmnd, ngaySinh, gioiTinh, SDT, diaChi, email, accID, username, password);

            //hiển thông tin
            hienThongTinGV();

            //xóa GV
            if (dtg.Columns[e.ColumnIndex].HeaderText == "Xóa")
            {
                //xoa acc -> tự động xóa thông tin -> set ON DELETE CASCADE
                
                nvDao.xoaTaiKhoan(nv.ACCID);
                taiDSNV();
            }
        }
        
        //hien thong tin NV
        private void hienThongTinGV()
        {
            lbl_GioiTinh.DataBindings.Clear();
            lbl_GioiTinh.DataBindings.Add("Text", dataGrView_DSNV.DataSource, "GIOITINH");
            lbl_MaNV.DataBindings.Clear();
            lbl_MaNV.DataBindings.Add("Text", dataGrView_DSNV.DataSource, "NVID");
            lbl_TenNV.DataBindings.Clear();
            lbl_TenNV.DataBindings.Add("Text", dataGrView_DSNV.DataSource, "HOTEN");
            lbl_DiaChi.DataBindings.Clear();
            lbl_DiaChi.DataBindings.Add("Text", dataGrView_DSNV.DataSource, "DIACHI");
            lbl_NgaySinh.DataBindings.Clear();
            lbl_NgaySinh.DataBindings.Add("Text", dataGrView_DSNV.DataSource, "NGAYSINH", true, DataSourceUpdateMode.Never, "", "dd/MM/yyyy");
            btn_SDT.DataBindings.Clear();
            btn_SDT.DataBindings.Add("Text", dataGrView_DSNV.DataSource, "SDT");
            btn_Email.DataBindings.Clear();
            btn_Email.DataBindings.Add("Text", dataGrView_DSNV.DataSource, "EMAIL");
            lbl_CCCD.DataBindings.Clear();
            lbl_CCCD.DataBindings.Add("Text", dataGrView_DSNV.DataSource, "CMND");
        }        

        //them NV moi
        private void pBox_Them_Click(object sender, EventArgs e)
        {
            F_NV_THEMNHANVIEN themNV = new F_NV_THEMNHANVIEN();
            themNV.ShowDialog();
            taiDSNV();
        }

        //cap nhat thong tin
        private void pBox_CapNhat_Click(object sender, EventArgs e)
        {
            F_NV_CAPNHAT capNhatNV = new F_NV_CAPNHAT(nv);
            capNhatNV.ShowDialog();
            taiDSNV();
        }
        //cap nhat NV dc chon trong datagrview
        private NhanVien capNhatGV(ref NhanVien nv, string nvid, string hoten, string cmnd, DateTime ngaysinh, string gioitinh, string sdt, string diachi, string email, string accid, string username, string password)
        {
            nv.NVID = nvid;
            nv.HOTEN = hoten;
            nv.CMND = cmnd;
            nv.NGAYSINH = ngaysinh;
            nv.GIOITINH = gioitinh;
            nv.SDT = sdt;
            nv.DIACHI = diachi;
            nv.EMAIL = email;
            nv.ACCID = accid;
            nv.USERNAME = username;
            nv.PASSWORD = password;
            return nv;
        }


        //click tim kiem
        private void btn_Search_Click(object sender, EventArgs e)
        {
            string duLieu = txt_Search.Text.ToString().Trim();
            thucHienTimKiem(dataGrView_DSNV, duLieu);
           colorCells(dataGrView_DSNV,txt_Search.Text);

        }
        //thuc hien tim kiem
        private void thucHienTimKiem(DataGridView dtg, string duLieu)
        {
            locDuLieuTimKiem(dtg, duLieu);
        }
        //lọc dữ liệu để tìm kiếm trong DataGridView
        private void locDuLieuTimKiem(DataGridView dtg, string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                // Nếu không có dữ liệu nhập vào, hiển thị tất cả các dòng
                dtg.Rows.Cast<DataGridViewRow>().ToList().ForEach(r => r.Visible = true);
            }
            else
            {
                for (int r = 0; r < dtg.Rows.Count - 1; r++)
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
                        //hiện những cột cần, name của các cột được lưu trong Enum
                        foreach (nameCol_DSNV day in Enum.GetValues(typeof(nameCol_DSNV)))
                        {
                            //chỉ tìm trên các ô thuộc cột có trong enum:
                            if (dtg.Columns[cell.ColumnIndex].Name == day.ToString())
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
        }
        public void colorRows(DataGridView dtg, string value)
        {
            // Duyệt qua từng dòng trong DataGridView
            foreach (DataGridViewRow row in dtg.Rows)
            {
                // Kiểm tra giá trị trong mỗi ô trong dòng
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString() == value)
                    {
                        // Nếu giá trị trong ô trùng khớp với giá trị tìm kiếm,
                        // tô màu nền của dòng đó thành màu vàng)
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                        break;
                    }
                }
            }
        }
        public void colorColumns(DataGridView dtg, string value)
        {
            // Duyệt qua từng cột trong DataGridView
            foreach (DataGridViewColumn column in dtg.Columns)
            {
                // Kiểm tra giá trị trong mỗi ô của cột
                foreach (DataGridViewRow row in dtg.Rows)
                {
                    DataGridViewCell cell = row.Cells[column.Index];
                    if (cell.Value != null && cell.Value.ToString() == value)
                    {
                        // Nếu giá trị trong ô trùng khớp với giá trị tìm kiếm,
                        // tô màu nền của cột đó thành màu xanh dương)
                        column.DefaultCellStyle.BackColor = Color.Blue;
                        break;
                    }
                }
            }
        }
        public void colorCells(DataGridView dtg, string value)
        {
            // Duyệt qua từng ô trong DataGridView
            foreach (DataGridViewRow row in dtg.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString() == value)
                    {
                        // Nếu giá trị trong ô trùng khớp với giá trị tìm kiếm,
                        // tô màu nền của ô đó thành màu hồng
                        cell.Style.BackColor = Color.Pink;
                    }
                }
            }
        }

        //click reset
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            thucHienReset(dataGrView_DSNV, txt_Search);
        }
        //thuc hien reset
        private void thucHienReset(DataGridView dtg, TextBox txt_Search)
        {
            // hiển thị tất cả các dòng
            dtg.Rows.Cast<DataGridViewRow>().ToList().ForEach(r => r.Visible = true);
            hien_SearchText(txt_Search, ref isEmpty_Search);
        }


        //danh STT
        private void dataGrView_DSNV_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGrView_DSNV.Rows[e.RowIndex];
            if (row != dataGrView_DSNV.Rows[dataGrView_DSNV.Rows.Count - 1])
            {
                row.Cells[0].Value = (e.RowIndex + 1).ToString();
            }
        }

        private void dataGrView_DSNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
