using DemoDoAn.ChildPage.General_Management.UC_GM_CLASS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDoAn.ChildPage.General_Management
{

    public partial class UC_GM_COURSE : UserControl
    {
        KhoaHocDao khoaHocDAO = new KhoaHocDao();
        LopHocDao LopHocDao = new LopHocDao();
        DataTable dtKhoaHoc = new DataTable();
        DataTable dtDSL = new DataTable();
        KhoaHoc khoahoc = new KhoaHoc();       

        enum nameCol_KH
        {
            STT,
            MaKH,
            TenKH
        }

        public UC_GM_COURSE()
        {
            InitializeComponent();
        }

        #region XuLiDoHoc
        bool isEmpty_Search = true;
        private void txt_Search_Click(object sender, EventArgs e)
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
        #region hàm dùng chung 
        private void SelectBtn(FlowLayoutPanel fLPnl, Button btnFLPnl, Button btn, bool select)
        {
            fLPnl.Height = fLPnl.MinimumSize.Height;
            select_TrangThai = false;
            btnFLPnl.Text = btn.Text;
        }
        // show/hide list lựa chọn 
        bool select_TrangThai = false;
        private void ShowListChoss(FlowLayoutPanel fLPnl, Timer t, ref bool select)
        {
            if (select == false)
            {
                fLPnl.Height += 15;
                if (fLPnl.Height >= fLPnl.MaximumSize.Height)
                {
                    t.Stop();
                    select = true;
                }
            }
            else
            {
                fLPnl.Height -= 15;
                if (fLPnl.Height <= fLPnl.MinimumSize.Height)
                {
                    t.Stop();
                    select = false;
                }
            }
        }
        #endregion

        private void timer_LoadTrangThai_Tick(object sender, EventArgs e)
        {
            ShowListChoss(fLPnl_TrangThai, timer_LoadTrangThai, ref select_TrangThai);
        }
        private void btn_TrangThai_Click(object sender, EventArgs e)
        {
            timer_LoadTrangThai.Start();
        }

        private void btn_TT_DaDay_Click(object sender, EventArgs e)
        {
            SelectBtn(fLPnl_TrangThai, btn_TrangThai, btn_TT_DaDay, select_TrangThai);
        }

        private void btn_TT_HoatDong_Click(object sender, EventArgs e)
        {
            SelectBtn(fLPnl_TrangThai, btn_TrangThai, btn_TT_HoatDong, select_TrangThai);
        }


        #endregion

        private void UC_GM_COURSE_Load(object sender, EventArgs e)
        {
            taiDSKH(dataGrView_DSKhoaHoc);
            taiDSL();
            //addCollums(dataGrView_DSKhoaHoc, "Trạng thái", "TrangThaiIcon");
            //addCollums(dataGrView_DSKhoaHoc, "Cập nhật", "CapNhatIcon");
            //addCollums(dataGrView_DSKhoaHoc, "Xóa", "XoaIcon");
            dataGrView_DSKhoaHoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        //tai DSL de cap nhat trang thai theo KH
        private void taiDSL()
        {
            dtDSL = LopHocDao.LayDanhSachLop();
        }

        //tai DSKhoaHoc
        private void taiDSKH(DataGridView dtg)
        {

            dtKhoaHoc.Rows.Clear();
            dtKhoaHoc = khoaHocDAO.LayKhoaHoc();
            dtKhoaHoc = dtKhoaHoc.AsEnumerable().OrderByDescending(row => row.Field<int>("TrangThaiKH")).CopyToDataTable();
            LoadForm(dtg, dtKhoaHoc);

            //ẩn full các cột     
            for (int i = 0; i < dtg.Columns.Count; i++)
            {
                DataGridViewColumn colDtg = dtg.Columns[i];
                colDtg.Visible = false;
            }
            //hiện những cột cần, name của các cột được lưu trong Enum
            foreach (nameCol_KH day in Enum.GetValues(typeof(nameCol_KH)))
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

            //them cojt trang thai, xoa
            addCollums(dtg, "Trạng thái", "TrangThaiIcon");
            addCollums(dtg, "Xóa", "XoaIcon");
            dtg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGrView_DSL.Sort(dataGrView_DSL.Columns["TrangThaiIcon"], ListSortDirection.Descending);
        }
        //load dtg
        private void LoadForm(DataGridView dtg, DataTable dt)
        {
            dtg.DataSource = dt;
        }
        //add columns 
        private void addCollums(DataGridView dtg, string headerCol, string nameCol)
        {
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            dtg.Columns.Add(img);
            img.HeaderText = headerCol;
            img.Name = nameCol;
            img.Image = null;
        }
        

        //them khoa hoc moi
        private void btnTaoKhoaHoc_Click(object sender, EventArgs e)
        {
            F_UC_GM_COURSE_ThemKhoaHoc uc_ThemKhoaHoc = new F_UC_GM_COURSE_ThemKhoaHoc();
            uc_ThemKhoaHoc.ShowDialog();
            resetDataGrView();
            taiDSKH(dataGrView_DSKhoaHoc);
        }

        //tim kiem
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
        }

        //xoa, cap nhat
        private void dataGrView_DSKhoaHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dtg = sender as DataGridView;
            DataGridViewRow row = dataGrView_DSKhoaHoc.Rows[e.RowIndex];

            if (dtg.Columns[e.ColumnIndex].HeaderText == "Xóa")
            {
                if (MessageBox.Show("Bạn muốn xóa khóa học?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    KhoaHoc phong = new KhoaHoc(Convert.ToString(row.Cells["MaKH"].Value), Convert.ToString(row.Cells["TenKH"].Value), Convert.ToString(row.Cells["TrangThaiKH"].Value));
                    khoaHocDAO.Xoa(phong);
                    resetDataGrView();
                    taiDSKH(dataGrView_DSKhoaHoc);
                }
            }
            else if (dtg.Columns[e.ColumnIndex].Name == "TrangThaiIcon")
            {
                if (MessageBox.Show("Bạn muốn cập nhật khóa học?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //cap nhat trang thai khoa hoc
                    capNhatTTDtg(e.RowIndex, "TrangThaiKH", dataGrView_DSKhoaHoc);
                    KhoaHoc khoa = new KhoaHoc(row.Cells["MaKH"].Value.ToString().Trim(),
                                                row.Cells["TenKH"].Value.ToString().Trim(),
                                                row.Cells["TrangThaiKH"].Value.ToString().Trim());
                    khoaHocDAO.CapNhat(khoa);

                    //cap nhat trang thai lop hoc cua khoa do
                    for(int i = 0; i < dtDSL.Rows.Count; i++)
                    {
                        DataRow dtrow = dtDSL.Rows[i];
                        if (dtrow["MaKH"].ToString() == row.Cells["MaKH"].Value.ToString())
                        {
                            LopHocDao.capNhatTrangThai(dtrow["MaLop"].ToString(), Convert.ToInt32(row.Cells["TrangThaiKH"].Value));
                        }
                    }
                    resetDataGrView();
                    taiDSKH(dataGrView_DSKhoaHoc);
                }
            }

        }
        //capnhat trang thai tren datagridview
        private void capNhatTTDtg(int r, string colUpdate, DataGridView dtg)
        {
            if (Convert.ToInt32(dtg.Rows[r].Cells[colUpdate].Value) == 0)
            {
                dtg.Rows[r].Cells[colUpdate].Value = 1;
            }
            else
            {
                dtg.Rows[r].Cells[colUpdate].Value = 0;
            }
        }

        //reset datagridview
        private void resetDataGrView()
        {
            dataGrView_DSKhoaHoc.Columns.Remove("XoaIcon");
            dataGrView_DSKhoaHoc.Columns.Remove("TrangThaiIcon");
            for (int i = dataGrView_DSKhoaHoc.Rows.Count - 1; i >= 0; i--)
            {
                dataGrView_DSKhoaHoc.Rows.RemoveAt(i);
            }
        }


        //danh STT
        private void dataGrView_DSKhoaHoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGrView_DSKhoaHoc.Rows[e.RowIndex];

            row.Cells[0].Value = (e.RowIndex + 1).ToString();
            //img for TrangThai
            if (row.Cells["TrangThaiIcon"].Value == null)
                if (Convert.ToInt32(row.Cells["TrangThaiKH"].Value) == 0)
                    row.Cells["TrangThaiIcon"].Value = new Bitmap(Application.StartupPath + "\\Resources\\Offline.png");
                else row.Cells["TrangThaiIcon"].Value = new Bitmap(Application.StartupPath + "\\Resources\\OnlineTT_1.png");
            //img for Xoa
            if (row.Cells["XoaIcon"].Value == null)
                row.Cells["XoaIcon"].Value = new Bitmap(Application.StartupPath + "\\Resources\\delete.png");
        }

        //reset
        private void btnReset_Click(object sender, EventArgs e)
        {

            hien_SearchText(txt_Search, ref isEmpty_Search);
        }
    }
}
