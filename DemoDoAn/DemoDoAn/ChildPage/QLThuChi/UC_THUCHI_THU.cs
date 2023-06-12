using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDoAn.ChildPage.QLThuChi
{
    public partial class UC_THUCHI_THU : UserControl
    {
        PhieuThuDao ptDao = new PhieuThuDao();
        PhieuThu pt = new PhieuThu();
        enum nameCol_PT
        {
            STT, 
            MaPT,
            LoaiTien,
            HOTEN,
            Ngay,
            SoTienDong,
            zXoa
        }

        public UC_THUCHI_THU()
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

        private void UC_THUCHI_THU_Load_1(object sender, EventArgs e)
        {
            taiDSPT();
            tinhThuNhap();
        }

        //xu li dtg
        private void dataGrView_PT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGrView_PT.Rows[e.RowIndex];
            lbl_TenHV.Text = dataGrView_PT.Rows[e.RowIndex].Cells["HOTEN"].Value.ToString().Trim();
            lbl_DiaChi.Text = dataGrView_PT.Rows[e.RowIndex].Cells["DIACHI"].Value.ToString().Trim();
            btn_SDT.Text = dataGrView_PT.Rows[e.RowIndex].Cells["SDT"].Value.ToString().Trim();
            btn_Email.Text = dataGrView_PT.Rows[e.RowIndex].Cells["EMAIL"].Value.ToString().Trim();

            string hvID = row.Cells["HVID"].Value.ToString();
            taiLSDongTien(hvID);

            //cap nhat phieu thu duoc chon
            PhieuThu ptTemp = new PhieuThu(row.Cells["MaPT"].Value.ToString(), row.Cells["LoaiTien"].Value.ToString(),
                                        Convert.ToDateTime(row.Cells["Ngay"].Value), Convert.ToInt32(row.Cells["SoTienDong"].Value.ToString()),
                                        row.Cells["HVID"].Value.ToString(), row.Cells["MaLop"].Value.ToString());
            pt = ptTemp;

        }

        private void btn_TaoPhieuThu_Click(object sender, EventArgs e)
        {
           
        }

        //tai ds PhieuThu
        private void taiDSPT()
        {
            loadForm(dataGrView_PT, ptDao.LayDanhSachPhieuThu());
            //ẩn full các cột     
            for (int i = 0; i < dataGrView_PT.Columns.Count; i++)
            {
                DataGridViewColumn colDtg = dataGrView_PT.Columns[i];
                colDtg.Visible = false;
            }
            int j = 0;
            //hiện những cột cần, name của các cột được lưu trong Enum
            foreach (nameCol_PT day in Enum.GetValues(typeof(nameCol_PT)))
            {
                for (int i = 0; i < dataGrView_PT.Columns.Count; i++)
                {
                    DataGridViewColumn colDtg = dataGrView_PT.Columns[i];
                    if (colDtg.Name.ToString() == day.ToString())
                    {
                        colDtg.DisplayIndex = j++;
                        colDtg.Visible = true;
                        break;
                    }
                }
            }
            dataGrView_PT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        //load dtg
        private void loadForm(DataGridView dtg, DataTable dt)
        {
            dtg.DataSource = dt;
            //sapXepThuocTinh(dtg);
        }
        //sap xep thu tu cac columns
        private void sapXepThuocTinh(DataGridView dtg)
        {
            int i = 0;
            foreach (nameCol_PT day in Enum.GetValues(typeof(nameCol_PT)))
            {
                dtg.Columns[day.ToString()].DisplayIndex = i++;
            }

        }


        //click tim kiem
        private void btn_Search_Click(object sender, EventArgs e)
        {
            string duLieu = txt_Search.Text.ToString().Trim();
            thucHienTimKiem(dataGrView_PT, duLieu);
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
                        foreach (nameCol_PT day in Enum.GetValues(typeof(nameCol_PT)))
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


        //click reset
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            thucHienReset(dataGrView_PT, txt_Search);
        }
        //thuc hien reset
        private void thucHienReset(DataGridView dtg, TextBox txt_Search)
        {
            // hiển thị tất cả các dòng
            dtg.Rows.Cast<DataGridViewRow>().ToList().ForEach(r => r.Visible = true);
            hien_SearchText(txt_Search, ref isEmpty_Search);
        }


        //tinh thu nhap hom nay
        private void tinhThuNhap()
        {
            DataTable dt = new DataTable();
            dt = ptDao.LayDanhSachPhieuThu();
            int tienTrongNgay = 0;
            int tienTrongThang = 0;
            for (int r= 0; r<dt.Rows.Count - 1; r++)
            {
                DataRow dr = dt.Rows[r];
                //tinh thu nhap trong ngay
                DateTime ngay = (DateTime)dr["Ngay"];
                if (ngay.ToString("dd/MM/yyyy") == DateTime.Today.ToString("dd/MM/yyyy"))
                {
                    int tien = Convert.ToInt32(dr["SoTienDong"]);
                    tienTrongNgay += tien;
                }

                //tinh thu nhap trong thang
                DateTime thang = (DateTime)dr["Ngay"];
                if (thang.Month.ToString() == DateTime.Today.Month.ToString())
                {
                    int tien = Convert.ToInt32(dr["SoTienDong"]);
                    tienTrongThang += tien;
                }
            }

            lbl_thuNhapTrongNgay.Text = tienTrongNgay.ToString();
            lbl_thuNhapTrongThang.Text = tienTrongThang.ToString();
        }

        //tai lich su dong tien
        private void taiLSDongTien(string hvID)
        {
            fLPnl_QLLichSu.Controls.Clear();
            for (int r = 0; r < dataGrView_PT.Rows.Count - 1; r++)
            {
                DataGridViewRow dRow = dataGrView_PT.Rows[r];
                if (dRow.Cells["HVID"].Value.ToString() == hvID)
                {
                    UC_THUCHI_THU_FormAVT lsTien = new UC_THUCHI_THU_FormAVT(dRow);
                    fLPnl_QLLichSu.Controls.Add(lsTien);
                }
            }
            
        }

        //them phieu thu moi
        private void btn_ThemPhieuThu_Click(object sender, EventArgs e)
        {
            F_THUCHI_TAOPHIEUTHU taoPT = new F_THUCHI_TAOPHIEUTHU();
            taoPT.ShowDialog();
            taiDSPT();
        }

        //danh STT
        private void dataGrView_PT_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGrView_PT.Rows[e.RowIndex];
            if (row != dataGrView_PT.Rows[dataGrView_PT.Rows.Count - 1])
            {
                row.Cells[0].Value = (e.RowIndex + 1).ToString();
            }
        }

        //xoa phieu thu
        private void pBox_XoaPC_Click(object sender, EventArgs e)
        {
            ptDao.xoaPhieuThu(pt.MAPT);
            taiDSPT();
        }
    }
}
