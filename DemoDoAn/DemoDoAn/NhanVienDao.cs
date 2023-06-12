using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDoAn
{
    internal class NhanVienDao
    {
        DBConnection dbConn = new DBConnection();

        //lay ACCID
        public DataTable LayAccID(string userName)
        {
            string thuocTinh = "AccID_NV";
            string sqlStr = string.Format("SELECT {0} FROM ACCOUNTS_NHANVIEN WHERE username = '{1}'", thuocTinh, userName);
            return dbConn.LayDanhSach(sqlStr);
        }

        public DataTable TimKiem(string tengv)
        {

            string sqlStr = string.Format("select GvID ,HOTEN ,GIOITINH from NHANVIEN where HOTEN like '%" + tengv + "%' ");
            return dbConn.LayDanhSach(sqlStr);
        }
        
        //load ds nhan vien
        public DataTable LayDanhSachNhanVien()
        {
            //để sau này có đổi tên bảng dưới SQL thì chuyển cho nhanh
            string bangTaiKhoan = "ACCOUNTS_NHANVIEN";
            string sqlStr = string.Format("SELECT *FROM NHANVIEN left join {0} on NHANVIEN.AccID = {1}.AccID_NV", bangTaiKhoan,bangTaiKhoan );
            return dbConn.LayDanhSach(sqlStr);
        }

        //them nhan vien
        public void themTaiKhoan(string username, string password)
        {
            string sqlStr = string.Format("INSERT INTO ACCOUNTS_NHANVIEN (username ,pass, NgayDK) VALUES ('{0}','{1}', '{2}')", username, password, DateTime.Now);
            dbConn.ThucThi(sqlStr);
        }
        public void themLuongNhanVien(NhanVien nv)
        {
            string sqlStr = string.Format("go DECLARE @i INT = 1; WHILE @i <= 12 BEGIN  INSERT INTO BANGLUONG (ID, HOTEN, CHUCVU, LuongDay, PhuCap, TienThuong, TienBaoHiem, THANG)   SELECT NHANVIEN.{0}, NHANVIEN.{1},N'Nhân viên', 0, 0, 0, 0,@i   FROM NHANVIEN  WHERE NOT EXISTS (SELECT 1 FROM BANGLUONG     WHERE BANGLUONG.ID = NHANVIEN.{0}     AND BANGLUONG.THANG = @i    AND BANGLUONG.ID + CAST(BANGLUONG.THANG AS NVARCHAR(2)) NOT IN ( SELECT ID + CAST(THANG AS NVARCHAR(2)) FROM BANGLUONG  WHERE THANG < @i ) ) AND NOT EXISTS (  SELECT 1 FROM BANGLUONG  WHERE BANGLUONG.ID = NHANVIEN.{0}    AND BANGLUONG.THANG = @i) GROUP BY NHANVIEN.{0}, NHANVIEN.{1};   SET @i = @i + 1; END",nv.NVID,nv.HOTEN);
            dbConn.ThucThi(sqlStr);
        }

        //them tai khoan
        public void themNhanVien(NhanVien nv)
        {
            string sqlStr = string.Format("INSERT INTO NHANVIEN(ACCID, HOTEN, GIOITINH, NGAYSINH, DIACHI, SDT, CMND, EMAIL) VALUES ('{0}', N'{1}', N'{2}', '{3}', N'{4}', '{5}','{6}', '{7}')",
                                        nv.ACCID, nv.HOTEN, nv.GIOITINH, nv.NGAYSINH, nv.DIACHI, nv.SDT, nv.CMND, nv.EMAIL);
            dbConn.ThucThi(sqlStr);
        }

        //xoa thong tin
        public void Xoa(string magv)
        {
            string sqlStr = string.Format("delete from GIAOVIEN where GvID ={0}", magv);
            dbConn.ThucThi(sqlStr);
        }

        //xoa tai khoan
        public void xoaTaiKhoan(string accID)
        {
            string sqlStr = string.Format("delete ACCOUNTS_NHANVIEN where AccID_NV = '{0}'", accID);
            dbConn.ThucThi(sqlStr);
        }

        //cap nhat tai khoan
        public void capNhatTaiKhoan(NhanVien nv)
        {
            string sqlStr = string.Format("Update ACCOUNTS_NHANVIEN Set pass = '{0}' Where username ='{1}'", nv.PASSWORD, nv.USERNAME);
            dbConn.ThucThi(sqlStr);
        }

        //cap nhat thong tin
        public void capNhatThongTin(NhanVien nv)
        {
            string sqlStr = string.Format("UPDATE NHANVIEN SET HOTEN = N'{0}', GIOITINH =N'{1}', NGAYSINH = '{2}', DIACHI = N'{3}', SDT = '{4}', CMND = '{5}', EMAIL = '{6}' WHERE NHANVIEN.NVID = '{7}'",
                                nv.HOTEN, nv.GIOITINH, nv.NGAYSINH, nv.DIACHI, nv.SDT, nv.CMND, nv.EMAIL, nv.NVID);
            dbConn.ThucThi(sqlStr);
        }
    }
}
