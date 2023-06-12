using DemoDoAn.ChildPage.General_Management.UC_GM_CLASS;
using DemoDoAn.ChildPage.General_Management.UC_GM_ROOM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDoAn.ChildPage
{
    public partial class UC_GM_ROOM : UserControl
    {
        PhongHocDao phongHocDao = new PhongHocDao();
        DataTable dtPhong = new DataTable();

        enum nameCol_DSPhong
        {
            STT,
            Phong
        }

        public UC_GM_ROOM()
        {
            InitializeComponent();
        }

        #region XuLiDoHoa
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

        private void LoadForm(DataTable dt)
        {
            this.dataGrView_DSPhongHoc.DataSource = dt;
        }
        private void UC_GM_ROOM_Load(object sender, EventArgs e)
        {
            taiDSPhong(dataGrView_DSPhongHoc);

        }

        //tai DSL
        private void taiDSPhong(DataGridView dtg)
        {
            dtPhong.Rows.Clear();
            dtPhong = phongHocDao.LayDanhSachPhong();
            dtPhong = dtPhong.AsEnumerable().OrderByDescending(row => row.Field<int>("TrangThai")).CopyToDataTable();
            LoadForm(dataGrView_DSPhongHoc, dtPhong);

            //ẩn full các cột     
            for (int i = 0; i < dtg.Columns.Count; i++)
            {
                DataGridViewColumn colDtg = dtg.Columns[i];
                colDtg.Visible = false;
            }
            //hiện những cột cần, name của các cột được lưu trong Enum
            foreach (nameCol_DSPhong day in Enum.GetValues(typeof(nameCol_DSPhong)))
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

        //thêm
        private void btnTaoPhongMoi_Click(object sender, EventArgs e)
        {
            General_Management.UC_GM_ROOM.F_GM_ROOM_ADDNEWROOM frm = new General_Management.UC_GM_ROOM.F_GM_ROOM_ADDNEWROOM();
            frm.ShowDialog();
            resetDataGrView();
            taiDSPhong(dataGrView_DSPhongHoc);
        }

        //reset
        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadForm(phongHocDao.LayDanhSachPhong());
            txt_Search.Text = "Search...";
            txt_Search.ForeColor = Color.Silver;
            txt_Search.Font = new Font("SFU Futura", 10F, FontStyle.Italic);
            isEmpty_Search = true;

        }

        //timkiem
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadForm(phongHocDao.TimKiem(txt_Search.Text));
            dataGrView_DSPhongHoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        //Xóa, sua
        private void dataGrView_DSPhongHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dtg = sender as DataGridView;
            DataGridViewRow row = new DataGridViewRow();

            if (dtg.Columns[e.ColumnIndex].HeaderText == "Xóa")
            {
                row = dataGrView_DSPhongHoc.Rows[e.RowIndex];
                if (MessageBox.Show("Bạn muốn xóa phòng học?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PhongHoc phong = new PhongHoc(Convert.ToString(row.Cells["Phong"].Value), Convert.ToString(row.Cells["TrangThai"].Value));
                    phongHocDao.Xoa(phong);
                    resetDataGrView();
                    taiDSPhong(dataGrView_DSPhongHoc);
                }
            }
            else if (dtg.Columns[e.ColumnIndex].Name == "TrangThaiIcon")
            {
                row = dataGrView_DSPhongHoc.Rows[e.RowIndex];
                if (MessageBox.Show("Bạn muốn cập nhật phòng học?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //cap nhat trang thai dong mo lop
                    capNhatTTPhongDtg(e.RowIndex, "TrangThai", dataGrView_DSPhongHoc);
                    PhongHoc phong = new PhongHoc(row.Cells["Phong"].Value.ToString().Trim(), row.Cells["TrangThai"].Value.ToString().Trim());
                    phongHocDao.capNhat(phong);
                    resetDataGrView();
                    taiDSPhong(dataGrView_DSPhongHoc);
                }
            }

        }
        //capnhat trang thai tren datagridview
        private void capNhatTTPhongDtg(int r, string colUpdate, DataGridView dtg)
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
            dataGrView_DSPhongHoc.Columns.Remove("XoaIcon");
            dataGrView_DSPhongHoc.Columns.Remove("TrangThaiIcon");
            for (int i = dataGrView_DSPhongHoc.Rows.Count - 1; i >= 0; i--)
            {
                dataGrView_DSPhongHoc.Rows.RemoveAt(i);
            }
        }

        //danh STT, gan icon
        private void dataGrView_DSPhongHoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGrView_DSPhongHoc.Rows[e.RowIndex];

            row.Cells[0].Value = (e.RowIndex + 1).ToString();
            //img for TrangThai
            if (row.Cells["TrangThaiIcon"].Value == null)
                    if (Convert.ToInt32(row.Cells["TrangThai"].Value) == 0)
                        row.Cells["TrangThaiIcon"].Value = new Bitmap(Application.StartupPath + "\\Resources\\Offline.png");
                    else row.Cells["TrangThaiIcon"].Value = new Bitmap(Application.StartupPath + "\\Resources\\OnlineTT_1.png");
            //img for Xoa
            if (row.Cells["XoaIcon"].Value == null)
                row.Cells["XoaIcon"].Value = new Bitmap(Application.StartupPath + "\\Resources\\delete.png");
            
        }
    }
}
