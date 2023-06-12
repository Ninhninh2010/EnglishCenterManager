using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDoAn.ChildPage.ThongKe
{
    public partial class UC_THONGKE_CHAMCONG : UserControl
    {
        DataTable dtKhoaHoc = new DataTable();
        BangLuongDao bangluong = new BangLuongDao();
        public UC_THONGKE_CHAMCONG()
        {
            InitializeComponent();
        }
        private void LoadForm(DataTable dt)
        {
            this.dataGrView_BangLuong.DataSource = dt;
        }
        private void dataGrView_BangHocPhi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void colorRows(DataGridView dtg, string value)
        {
            // Duyệt qua tất cả các hàng của DataGridView
            foreach (DataGridViewRow row in dtg.Rows)
            {
                // Nếu giá trị của hàng chứa chuỗi tìm kiếm
                if (row.Cells[0].Value.ToString().Contains(value))
                {
                    // Thay đổi màu sắc của hàng
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
                else
                {
                    // Nếu không chứa chuỗi tìm kiếm, thì trả lại màu sắc mặc định của hàng
                    row.DefaultCellStyle.BackColor = dtg.DefaultCellStyle.BackColor;
                }
            }
        }
        private void loadCbb_LuongDao()
        {
            string selectedText = cbb_thangnam.SelectedItem.ToString();
            dtKhoaHoc = bangluong.LayThongTinLuong(selectedText);
            DataTable distinctMaKH = dtKhoaHoc.DefaultView.ToTable(true, new string[] { "ID", "NgayTao" });
            loadCombobox(cbb_thangnam, distinctMaKH, "NgayTao", "ID");
            //if(distinctMaKH ="")
        }
        private void loadCombobox(ComboBox cbb, DataTable dt, string displayMember, string valueMember)
        {
            cbb.DataSource = dt;
            cbb.DisplayMember = displayMember;
            cbb.ValueMember = displayMember;
        }


        private void UC_THONGKE_CHAMCONG_Load(object sender, EventArgs e)
        {
            // gán giá trị ban đầu để loadbang
            string selectedText = "5";
            dataGrView_BangLuong.DataSource = bangluong.LayThongTinLuong(selectedText);
            dataGrView_BangLuong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGrView_BangLuong_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGrView_BangLuong.Rows[e.RowIndex];
            row.Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void dataGrView_BangLuong_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = sender as DataGridViewCell;
            cell = dataGrView_BangLuong.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (String.IsNullOrEmpty(cell.Value.ToString()))
                cell.Value = 0.0;
        }

        private void cbb_thangnam_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedText = cbb_thangnam.SelectedItem.ToString();

            // Thực hiện truy vấn dữ liệu tương ứng với giá trị được chọn trong ComboBox
            DataTable dtBangLuong = bangluong.LayThongTinLuong(selectedText);

            // Gán kết quả truy vấn cho DataSource của DataGridView để hiển thị dữ liệu
            dataGrView_BangLuong.DataSource = dtBangLuong;
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            //update bang
            for (int r = 0; r < dataGrView_BangLuong.Rows.Count - 1; r++)
            {
                DataGridViewRow row = dataGrView_BangLuong.Rows[r];
                string ID = row.Cells["ID"].Value.ToString();
                string HOTEN = row.Cells["HOTEN"].Value.ToString();
                double Luong = Convert.ToDouble(row.Cells["Luong"].Value.ToString());
                double PhuCap = Convert.ToDouble(row.Cells["PhuCap"].Value.ToString());
                double TienThuong = Convert.ToDouble(row.Cells["TienThuong"].Value.ToString());
                double TienBaoHiem = Convert.ToDouble(row.Cells["TienBaoHiem"].Value.ToString());
                double THANG = Convert.ToDouble(row.Cells["THANG"].Value.ToString());
                BangLuong a = new BangLuong(ID, HOTEN, Luong, PhuCap, TienThuong, TienBaoHiem, THANG);
                bangluong.LUULUONG(a);
            }
            string selectedText = cbb_thangnam.SelectedItem.ToString();

            LoadForm(bangluong.LayThongTinLuong(selectedText));
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {

        }
    }
}
