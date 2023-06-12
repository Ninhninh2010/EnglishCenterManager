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

namespace DemoDoAn.ChildPage.ThongKe
{
    public partial class UC_THONGKE_HOCTAP : UserControl
    {
        ThongKeDao tkDao = new ThongKeDao();
        DataTable dtHT = new DataTable();

        enum nameCol_TKHT
        {
            STT,
            HVID,
            HOTEN,
            TenMon,
            DiemTB,
            TrangThai
        }

        public UC_THONGKE_HOCTAP()
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

        private void UC_THONGKE_HOCTAP_Load(object sender, EventArgs e)
        {
            taiBangHocTap();
            thongKeHocTap();
        }

        //load dtg
        private void loadForm(DataGridView dtg, DataTable dt)
        {
            dtg.DataSource = dt;
        }
        //tai bang hoc phi
        private void taiBangHocTap()
        {
            dtHT.Rows.Clear();
            dtHT = tkDao.layBangHocTap();
            loadForm(dataGrView_TKHT, dtHT);
            
            //them cot trang thai qua mon

            //ẩn full các cột     
            for (int i = 0; i < dataGrView_TKHT.Columns.Count; i++)
            {
                DataGridViewColumn colDtg = dataGrView_TKHT.Columns[i];
                colDtg.Visible = false;
            }
            //hiện những cột cần, name của các cột được lưu trong Enum
            foreach (nameCol_TKHT day in Enum.GetValues(typeof(nameCol_TKHT)))
            {
                for (int i = 0; i < dataGrView_TKHT.Columns.Count; i++)
                {
                    DataGridViewColumn colDtg = dataGrView_TKHT.Columns[i];
                    if (colDtg.Name.ToString() == day.ToString())
                    {
                        colDtg.Visible = true;
                        break;
                    }
                }
            }
            //dataGrView_TKHT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
        }

        //thong ke hoc tap
        private void thongKeHocTap()
        {
            lbl_SLTongHocVien.Text = dtHT.Rows.Count.ToString();
            lbl_SLQuaMon.Text = (dtHT.AsEnumerable().Count(r => r.Field<double>("DiemTB") >= 8.0)).ToString();
            lbl_SLRotMon.Text = (dtHT.AsEnumerable().Count(r => r.Field<double>("DiemTB") < 8.0)).ToString();
            
        }

        //danh STT
        private void dataGrView_TKHT_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGrView_TKHT.Rows[e.RowIndex];
            if (row != dataGrView_TKHT.Rows[dataGrView_TKHT.Rows.Count - 1])
            {
                row.Cells[0].Value = (e.RowIndex + 1).ToString();
            }
        }

        //tim kiem
        private void btn_Search_Click(object sender, EventArgs e)
        {
            thucHienTimKiem(dataGrView_TKHT, txt_Search.Text.ToString());
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
                        foreach (nameCol_TKHT day in Enum.GetValues(typeof(nameCol_TKHT)))
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


        //reset
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            thucHienReset(dataGrView_TKHT, txt_Search);
        }
        //thuc hien reset
        private void thucHienReset(DataGridView dtg, TextBox txt_Search)
        {
            // hiển thị tất cả các dòng
            dtg.Rows.Cast<DataGridViewRow>().ToList().ForEach(r => r.Visible = true);
            hien_SearchText(txt_Search, ref isEmpty_Search);
        }

    }
}
