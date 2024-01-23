using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Composition.Scenes;

namespace QLNV_LIB
{
    public class QuanLyNhanVien
    {
        public int maNV { get; set; }
        public string tenNV { get; set; }
        public DateTime ngaysinh { get; set; }
        public string gioitinh { get; set; }
        public string diachi { get; set; }
        public DateTime ngayvaolam { get; set; }
        public string bangcap { get; set; }
        public string hinhthucNV { get; set; }

        public QuanLyNhanVien(int maNV, string tenNV, DateTime ngaysinh, string gioitinh,
            string diachi, DateTime ngayvaolam, string bangcap, string hinhthucNV)
        {
            this.maNV = maNV;
            this.tenNV = tenNV;
            this.ngaysinh = ngaysinh;
            this.gioitinh = gioitinh;
            this.diachi = diachi;
            this.ngayvaolam = ngayvaolam;
            this.bangcap = bangcap;
            this.hinhthucNV = hinhthucNV;
        }

        public QuanLyNhanVien()
        {
        }

        double ngayLam = 0;
        int gioTre = 0;
        int gioTangCa = 0;

        public double timeworking(double start, double end)
        {
            double time = (end - start);        
            if (time < 8 && time > 0)
            {
                gioTre = ((int)(8 - time));
                if (gioTre <= 1.5) ngayLam += 0.5;
                else if (gioTre > 1.5) ngayLam -= 1;
                return ngayLam;
            }
            else if (time == 8)
            {
                ngayLam += 1;
                return ngayLam;
            }
            else if (time < 0)
            {
                return ngayLam = 0;
            }
            else  
            {
                gioTangCa = ((int)(time - 8));
                if (gioTangCa >= 1) ngayLam += 1.25;
                else if (gioTangCa == 3) ngayLam += 1.5;
                return ngayLam;
            }
        }

        int thamNien;
        int ngayPhep = 0;
        double luongNghiPhep;
        double phat = 0;
        public double Tinhphep(int thamNien, string dieuKien, int ngayNghi)
        {
            if (thamNien >= 12)
            {
                if (dieuKien == "Binhthuong")
                {
                    ngayPhep = 12;
                }
                else if (dieuKien == "Dacbiet")
                {
                    ngayPhep = 14;
                }
                else if (dieuKien == "Nangnhoc")
                {
                    ngayPhep = 16;
                }
            }
            else
            {
                ngayPhep = thamNien;
            }
            if (ngayNghi > ngayPhep)
            {
                phat = ngayLam - (ngayLam * 20 / 100);
                return phat;
            }
            else if (ngayNghi < 0)
            {
                luongNghiPhep = ngayPhep - ngayNghi;
                return luongNghiPhep;
            }
            else
            {
                luongNghiPhep = ngayPhep;
                return luongNghiPhep;
            }
        }
        //Tính lương
        double luong = 0;
        double gioLam;
        double luongThang = 0;
        double luongParttime, luongGio;
        double Phucap = 300000;
        double thue;
        double tongThuNhap;

        //Luongthang = LCB + Thamnien + Hocvi + Chucdanh + Phongban
        double LCB = 15000;
        double luongThamNien, luongHocVi, luongChucDanh, luongPhongBan;
        double BHXH, BHYT, BHTN, TNCN;

        public double Tinhluong()
        {
            gioLam = (ngayLam + luongNghiPhep + phat) * 24;
            luong = luongGio * gioLam + Phucap - thue;
            return luong;
        }

        public double Tinhtongthunhap()
        {
            tongThuNhap = luong * 12;
            return tongThuNhap;
        }

        public double Tinhluongthang(int thamNien, string hocVi, string chucDanh, string phongBan)
        {

            if (thamNien >= 12) luongThamNien = 5000;
            else luongThamNien = 0;

            switch (hocVi)
            {
                case "THPT":
                    luongHocVi = 0;
                    break;
                case "Trung cap":
                    luongHocVi = 2000;
                    break;
                case "Cao dang":
                    luongHocVi = 4000;
                    break;
                case "Dai hoc":
                    luongHocVi = 6000;
                    break;
                case "Thac si":
                    luongHocVi = 8000;
                    break;
                case "Tien si":
                    luongHocVi = 10000;
                    break;
            }

            switch (chucDanh)
            {
                case "Nhan vien":
                    luongChucDanh = 2000;
                    break;
                case "Pho truong phong":
                    luongChucDanh = 5000;
                    break;
                case "Truong phong":
                    luongChucDanh = 10000;
                    break;
            }

            switch (phongBan)
            {
                case "Kinh doanh":
                    luongPhongBan = 5000;
                    break;
                case "Ke toan":
                    luongPhongBan = 5000;
                    break;
                case "Ban giam doc":
                    luongPhongBan = 20000;
                    break;
                case "Hanh chanh":
                    luongPhongBan = 10000;
                    break;
                case "Bao ve":
                    luongPhongBan = 1000;
                    break;
            }

            luongThang = 15000 + luongThamNien + luongHocVi + luongChucDanh + luongPhongBan;
            return luongThang;
        }

        public double TinhluongParttime(string loaiCV)
        {
            switch (loaiCV)
            {
                case "Van phong":
                    luongParttime = 19000;
                    break;
                case "San xuat":
                    luongParttime = 20000;
                    break;
            }
            return luongParttime;
        }

        public double Tinhluonggio(string hinhThucCV)
        {
            if (hinhThucCV == "Part time")
            {
                luongGio = luongParttime;
            }
            else luongGio = luongThang;
            return luongGio;
        }

        public double TinhThue()
        {

            BHXH = luongThang * 8 / 100;
            BHYT = luongThang * 1.5 / 100;
            BHTN = luongThang * 1 / 100;
            TNCN = luongThang * 10 / 100;
            thue = BHXH + BHYT + BHTN + TNCN;
            return thue;
        }
    }
}
