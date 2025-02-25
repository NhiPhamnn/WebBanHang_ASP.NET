﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace API.Query
{
    public class KhachHangQuery
    {
        public void ThemKhachHang(string tenkh,string diaChi,int sdt,string email,string taiKhoan,string matKhau)
        {
            string query = "insert into KhachHang(tenKH,DiaChi,SDT,email,taiKhoan,matKhau) values('"+tenkh+"', '"+diaChi+"', '"+sdt+"', '"+email+"', '"+taiKhoan+"', '"+matKhau+"')";
            Execute.ExcuteNonquery(query);
        }
        public void ThemKhachHangkUser(string tenkh, string diaChi, int sdt, string email)
        {
            string query = "insert into KhachHang(tenKH,DiaChi,SDT,email,tongMua) values('" + tenkh + "', '" + diaChi + "', '" + sdt + "', '" + email + "',0)";
            Execute.ExcuteNonquery(query);
        }
        public string TimKhachHang(string ten)
        {
            string query="select * from KhachHang where tenKh like'"+ten+"'";
            return Execute.ExcuteQuery(query);
        }
        public string TimKhachHangSDt(string sdt)
        {
            string query = "select * from KhachHang where tenKh like'" + sdt + "'";
            return Execute.ExcuteQuery(query);
        }
        public string getAll()
        {
            string query = "select * from KhachHang";
            return Execute.ExcuteQuery(query);
        }
        public string GetKhachHang(string sodt)
        {
            string que = "select * from KhachHang where sodt = '" + sodt + "'";
            return Execute.ExcuteQuery(que);


        }
    }
}
