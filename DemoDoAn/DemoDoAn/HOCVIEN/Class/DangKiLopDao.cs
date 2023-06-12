using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDoAn.HOCVIEN.Class
{
    internal class DangKiLopDao
    {
        DBConnection dbConn = new DBConnection();



        //load danh sach cac lop HV da dang ki
        public DataTable LayDanhSachLopDaDangKi( string hvID)
        {
            string sqlStr = string.Format("Select DISTINCT LOPHOCDADANGKI.MaLop, TenMon, NgayBatDau, NgayKetThuc, HOTEN, TrangThai , Thu, Ca\r\nFrom LOPHOCDADANGKI join LICHHOC on LOPHOCDADANGKI.MaLop = LICHHOC.MaLop\r\nWhere HVID = '{0}'", hvID);
            return dbConn.LayDanhSach( sqlStr);        
        }

        //lấy thông tin chi tiết về lớp học
        public DataTable LayThongTinLop(string maLop)
        {
            string sqlStr = string.Format("SELECT Thu, GioBatDau, GioKetThuc, Phong, NgayBatDau, NgayKetThuc FROM LOPDANGKI inner join GIOHOC on LOPDANGKI.Ca = GIOHOC.Ca WHERE MaLop = '{0}'", maLop);
            return dbConn.LayDanhSach(sqlStr);
        }

        //
        public DataTable LayDanhSachLop()
        {
            string sqlStr = string.Format("SELECT DISTINCT MaLop, TenMon, TenKH, HocPhi, HOTEN, TrangThai \r\nFROM LOPDANGKI");
            return dbConn.LayDanhSach(sqlStr);
        }

        //DANG KI LOP HOC MOI
        public void DangKiLop(string hvID, string maLop, string trangThai)
        {
            string sqlStr = string.Format("INSERT INTO DANHSACHLOP (MaLop, HVID, TrangThai) VALUES ('{0}', '{1}', N'Chưa hoàn thành')", maLop, hvID);
            if (trangThai == "Hoạt động")
            {
                dbConn.ThucThi(sqlStr);
                CapNhatSiSoLop();
            }
                
            else MessageBox.Show("Không thể đăng kí");
        }

        //update sĩ số lớp
        public void CapNhatSiSoLop()
        {
            string sqlStr = string.Format("update LOPHOC Set TrangThai = N'Đã đầy' " +
                                        "Where LOPHOC.MaLop not in (Select SiSoLop.MaLop From " +
                                                "(Select DANHSACHLOP.MaLop, LOPHOC.SoHocVien, Count(*) as SiSo " +
                                                "From DANHSACHLOP inner join LOPHOC on DANHSACHLOP.MaLop = LOPHOC.MaLop " +
                                                "Group by  DANHSACHLOP.MaLop, LOPHOC.SoHocVien Having Count(*) < LOPHOC.SoHocVien) as SiSoLop)");
            
            string sqlStr2 = string.Format("update LOPHOC Set TrangThai = N'Hoạt động' " +
                                       "Where LOPHOC.MaLop IN (Select SiSoLop.MaLop From " +
                                               "(Select DANHSACHLOP.MaLop, LOPHOC.SoHocVien, Count(*) as SiSo " +
                                               "From DANHSACHLOP inner join LOPHOC on DANHSACHLOP.MaLop = LOPHOC.MaLop " +
                                               "Group by  DANHSACHLOP.MaLop, LOPHOC.SoHocVien Having Count(*) < LOPHOC.SoHocVien) as SiSoLop)");
            dbConn.ThucThi(sqlStr2);
            dbConn.ThucThi(sqlStr);
        }

        //xoa lop hoc
        public void XoaLop(string hvID, string maLop)
        {
            string sqlStr = string.Format("Delete From DANHSACHLOP Where HVID = '{0}' and MaLop = '{1}'", hvID, maLop);
            dbConn.ThucThi(sqlStr);
        }
    }
}
