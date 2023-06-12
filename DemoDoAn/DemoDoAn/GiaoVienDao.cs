using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDoAn
{
    internal class GiaoVienDao
    {
        DBConnection dbConn = new DBConnection();

        //lay ACCID
        public DataTable LayAccID(string userName)
        {
            string thuocTinh = "AccID_Tea";
            string sqlStr = string.Format("SELECT {0} FROM ACCOUNTS_TEACHER WHERE username = '{1}'", thuocTinh, userName);
            return dbConn.LayDanhSach(sqlStr);
        }
       
        

        public DataTable LayThongTinGiaoVienVaLop(GiaoVien gv)
        {
            string sqlStr = string.Format("SELECT GIANGVIEN.GvID, LOPHOC.MaLop, LOPHOC.TenMon, LOPHOC.MaKH, KHOAHOC.TenKH, LOPHOC.SoHocVien, LOPHOC.HocPhi, LOPHOC.TrangThai \r\nFROM GIANGVIEN join LOPHOC on  GiangVien.GvID = LOPHOC.GiangVien join KHOAHOC on KHOAHOC.MaKH = LOPHOC.MaKH\r\nWHERE  GvID='{0}'", gv.GVID);
            return dbConn.LayDanhSach(sqlStr);
        }
        public DataTable LayDanhSachGiaoVien()
        {
            //để sau này có đổi tên bảng dưới SQL thì chuyển cho nhanh
            string bangTKGV = "ACCOUNTS_TEACHER";
            string sqlStr = string.Format("SELECT *FROM GIANGVIEN left join {0} on GIANGVIEN.AccID = {1}.AccID_Tea", bangTKGV, bangTKGV);
            return dbConn.LayDanhSach(sqlStr);
        }
        public void Them(GiaoVien gv)
        {
            string sqlStr = string.Format("INSERT INTO GIANGVIEN(AccID, HOTEN, GIOITINH, NGAYSINH, DIACHI, SDT, CMND, EMAIL) VALUES ('{0}', N'{1}', N'{2}', '{3}', N'{4}', '{5}', '{6}','{7}')",
                                           gv.ACCID, gv.HOTEN, gv.GIOITINH, gv.NGAYSINH, gv.DIACHI, gv.SDT, gv.CMND, gv.EMAIL);
            dbConn.ThucThi(sqlStr);
        }
        public void ThemBangLuong(GiaoVien gv)
        {
            string sqlStr = string.Format("DECLARE @i INT = 1; WHILE @i <= 12 BEGIN    INSERT INTO BANGLUONG (ID, HOTEN, CHUCVU, LuongDay, PhuCap, TienThuong, TienBaoHiem, THANG)   SELECT GIAOVIEN.{0}, GIAOVIEN.{1}, N'Giáo viên' ,0, 0, 0, 0,@i  FROM GIAOVIEN  WHERE NOT EXISTS ( SELECT 1 FROM BANGLUONG   WHERE BANGLUONG.ID = GIAOVIEN.{0}     AND BANGLUONG.THANG = @i    AND BANGLUONG.ID + CAST(BANGLUONG.THANG AS NVARCHAR(2)) NOT IN (     SELECT ID + CAST(THANG AS NVARCHAR(2)) FROM BANGLUONG   WHERE THANG < @i) AND NOT EXISTS ( SELECT 1 FROM BANGLUONG    WHERE BANGLUONG.ID = GIAOVIEN.{0}      AND BANGLUONG.THANG = @i)   GROUP BY GIAOVIEN.{0}, GIAOVIEN.{1};   SET @i = @i + 1; END GO", gv.GVID, gv.HOTEN);
            dbConn.ThucThi(sqlStr);
        }
        //them acc
        public void ThemAccout(string username, string password)
        {
            string sqlStr = string.Format("INSERT INTO ACCOUNTS_TEACHER(username, pass, NgayDK) VALUES ('{0}','{1}', '{2}')", username, password, DateTime.Now);
            dbConn.ThucThi(sqlStr);
        }

        //xoa tai khoan
        public void xoaTaiKhoan(string accID)
        {
            string sqlStr = string.Format("delete ACCOUNTS_TEACHER where AccID_Tea = '{0}'", accID);
            dbConn.ThucThi(sqlStr);
        }
        //xoa GV
        public void xoaThongTin(string GvID)
        {
            string sqlStr = string.Format("delete from GIANGVIEN where GvID ='{0}'", GvID);
            dbConn.ThucThi(sqlStr);
        }

        //cap nhat thong tin Giang Vien
        public void CapNhat(GiaoVien gv)
        {
            //cap nhat thong tin ca nhan
            string sqlStr = string.Format("UPDATE GIANGVIEN SET HOTEN = N'{0}', GIOITINH = N'{1}', NGAYSINH = '{2}', DIACHI = N'{3}', SDT = '{4}', CMND = '{5}', EMAIL = '{6}' WHERE GvID = '{7}'",
                                        gv.HOTEN, gv.GIOITINH, gv.NGAYSINH, gv.DIACHI, gv.SDT, gv.CMND, gv.EMAIL, gv.GVID);
            //cap nhat thong tin acc
            string sqlStr1 = string.Format("Update ACCOUNTS_TEACHER Set pass = '{0}' Where username = '{1}'", gv.PASSWORD, gv.USERNAME);
            dbConn.ThucThi(sqlStr);
            dbConn.ThucThi(sqlStr1);
        }
    }
}
