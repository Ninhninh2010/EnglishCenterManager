﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoDoAn.FORM;

namespace DemoDoAn
{
    internal class DBConnection
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnStr);
        
        //lấy danh sách của các bảng có sẵn
        public DataTable LayDanhSach(string sqlStr)
        {
            DataTable dtds = new DataTable();
            try
            {
                conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                adapter.Fill(dtds);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
            return dtds;
        }

        //
        public void ThucThi(string sqlStr)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlStr, conn);

                if (cmd.ExecuteNonQuery() > 0)
                    MessageBox.Show("thanh cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show("that bai");
            }
            finally
            {
                conn.Close();
            }
        }



        #region
        //lấy 1 giá trị
        public string LayDuLieu(string sqlStr, string thuocTinh)
        {
            string s = "";
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    s = sdr[thuocTinh].ToString().Trim();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
            return s;
        }

        #endregion

    }
}
