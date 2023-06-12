using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDoAn
{
    internal class BangLuongDao
    {
        DBConnection dbConn = new DBConnection();
        public DataTable LayThongTinLuong(string s)
        {
            string sqlStr = string.Format("SELECT * FROM [BANGLUONG] where THANG={0}", s);
            return dbConn.LayDanhSach(sqlStr);


        }
        public void LUULUONG(BangLuong a)
        {
            string sqlStr = string.Format("UPDATE BANGLUONG SET  Luong = {1}, PhuCap = {2}, TienThuong = {3}, TienBaoHiem = {4} ,  TONGLUONG = {1} + {2} + {3} - {4} + LuongDay WHERE ID = '{0}' AND THANG={5}  ", a.ID, a.LUONG, a.PHUCAP, a.TIENTHUONG, a.TIENBAOHIEM, a.THANGLUONG);
            dbConn.ThucThi(sqlStr);
        }

        public DataTable NhapLuong()
        {
            string sqlStr = string.Format("go INSERT INTO BANGLUONG (ID, HOTEN, LuongDay, PhuCap, TienThuong, TienBaoHiem) SELECT GIAOVIEN.GVID, GIAOVIEN.HOTEN, 0, 0, 0, 0 FROM GIAOVIEN, LOPHOC GROUP BY GIAOVIEN.GVID, GIAOVIEN.HOTEN" +
                " go UPDATE BANGLUONG SET LuongDay=LOPHOC.LUONG FROM BANGLUONG INNER JOIN LOPHOC ON BANGLUONG.ID = LOPHOC.GiaoVien go" +
                " go INSERT INTO BANGLUONG (ID,HOTEN, Luong, PhuCap, TienThuong, TienBaoHiem)SELECT NVID,HOTEN, 5000000, 0, 0, 0 FROM NHANVIEN");
            return dbConn.LayDanhSach(sqlStr);
        }
        public DataTable TimKiem(string tengv)
        {

            string sqlStr = string.Format("select GvID ,HOTEN ,GIOITINH from GIAOVIEN where HOTEN like '%" + tengv + "%' ");
            //string sqlStr1 = string.Format("select GvID ,HOTEN ,GIOITINH from GIAOVIEN where HOTEN like '%" +  + "%' ");
            return dbConn.LayDanhSach(sqlStr);
        }




    }
}
