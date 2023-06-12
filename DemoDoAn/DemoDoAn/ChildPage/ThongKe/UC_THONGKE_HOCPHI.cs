using DemoDoAn.HOCVIEN.Class;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDoAn.ChildPage.ThongKe
{
    public partial class UC_THONGKE_HOCPHI : UserControl
    {
        ThongKeDao tkDao = new ThongKeDao();   
        DataTable dtHP = new DataTable();

        enum nameCol_HP
        {
            STT,
            HVID,
            HOTEN,
            TenMon,
            HocPhi,
            TrangThai
        }

        public UC_THONGKE_HOCPHI()
        {
            InitializeComponent();
            chart_BieuDo.BackColor = Color.White;
            chart_BieuDo.Series = new LiveCharts.SeriesCollection
            {
                new LineSeries
                {
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0,10),
                        new ObservablePoint(4,7),
                        new ObservablePoint(5,3),
                        new ObservablePoint(7,6),
                        new ObservablePoint(8,10),
                    },
                    PointGeometrySize = 15
                }
            };

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

        private void UC_THONGKE_HOCPHI_Load(object sender, EventArgs e)
        {
            taiBangHP();
            thongKeHocPhi();
        }

        //load dtg
        private void loadForm(DataGridView dtg, DataTable dt)
        {
            dtg.DataSource = dt;
        }
        //tai bang hoc phi
        private void taiBangHP()
        {
            dtHP.Rows.Clear();
            dtHP = tkDao.layBangHocPhi();
            loadForm(dataGrView_BangHocPhi, dtHP);
            //ẩn full các cột     
            for (int i = 0; i < dataGrView_BangHocPhi.Columns.Count; i++)
            {
                DataGridViewColumn colDtg = dataGrView_BangHocPhi.Columns[i];
                colDtg.Visible = false;
            }
            //hiện những cột cần, name của các cột được lưu trong Enum
            foreach (nameCol_HP day in Enum.GetValues(typeof(nameCol_HP)))
            {
                for (int i = 0; i < dataGrView_BangHocPhi.Columns.Count; i++)
                {
                    DataGridViewColumn colDtg = dataGrView_BangHocPhi.Columns[i];
                    if (colDtg.Name.ToString() == day.ToString())
                    {
                        colDtg.Visible = true;
                        break;
                    }
                }
            }
            dataGrView_BangHocPhi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        //click tim kiem
        private void btn_Search_Click(object sender, EventArgs e)
        {
            locDuLieuTimKiem(dataGrView_BangHocPhi, txt_Search.Text.ToString().Trim());
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
                        foreach (nameCol_HP day in Enum.GetValues(typeof(nameCol_HP)))
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
            thucHienReset(dataGrView_BangHocPhi, txt_Search);
        }
        //thuc hien reset
        private void thucHienReset(DataGridView dtg, TextBox txt_Search)
        {
            // hiển thị tất cả các dòng
            dtg.Rows.Cast<DataGridViewRow>().ToList().ForEach(r => r.Visible = true);
            hien_SearchText(txt_Search, ref isEmpty_Search);
        }


        //load thong ke
        private void thongKeHocPhi()
        {
            //tong so luong dang ky mon
            lbl_TongSoLuong.Text = dtHP.Rows.Count.ToString();
            //sl hoan thanh
            lbl_HoanThanh.Text = (dtHP.AsEnumerable().Count(r => r.Field<string>("TrangThai") == "Hoàn thành")).ToString();
            //chua hoan thanh
            lbl_ChuaHoanThanh.Text = (Convert.ToInt32(lbl_TongSoLuong.Text) - Convert.ToInt32(lbl_HoanThanh.Text)).ToString();
            //ti le hoan thanh
            double tile = ((Convert.ToDouble(lbl_HoanThanh.Text) / Convert.ToDouble(lbl_TongSoLuong.Text)) * 100);
            lbl_TiLeHoanThanh.Text = string.Format("{0:00.00}", tile).ToString();

            int tongHocPhi = 0;
            int tongThu = 0;
            for (int i = 0; i < dtHP.Rows.Count - 1; i++)
            {
                DataRow row = dtHP.Rows[i];
                tongHocPhi += Convert.ToInt32(row["HocPhi"].ToString());
                tongThu += Convert.ToInt32(row["DaDong"].ToString());
            }
            lbl_TongTienHP.Text = tongHocPhi.ToString("#,##0", CultureInfo.GetCultureInfo("vi-VN")).Replace(",", ".");
            lbl_TongHPDaThu.Text = tongThu.ToString();
        }

        //danh STT
        private void dataGrView_BangHocPhi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGrView_BangHocPhi.Rows[e.RowIndex];
            if (row != dataGrView_BangHocPhi.Rows[dataGrView_BangHocPhi.Rows.Count - 1])
            {
                row.Cells[0].Value = (e.RowIndex + 1).ToString();
            }
        }

        private void dataGrView_BangHocPhi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
