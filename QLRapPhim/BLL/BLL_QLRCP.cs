using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLRapPhim.DAL;
using QLRapPhim.DTO;

namespace QLRapPhim.BLL
{
    class BLL_QLRCP
    {
        private QuanLyRapChieuPhimDB db = new QuanLyRapChieuPhimDB();


        private static BLL_QLRCP _Instance;

        public static BLL_QLRCP Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_QLRCP();
                }
                return _Instance;
            }
            private set
            {

            }
        }



        private BLL_QLRCP()
        {

        }

        public List<TheLoai> BLL_GetListGenre()
        {
            return DAL_QLRCP.Instance.DAL_GetListGenre();
        }

        

        public List<CaChieu> BLL_GetCaChieus()
        {
            return DAL_QLRCP.Instance.DAL_GetCaChieus();
        }
        public List<LoaiVe> BLL_GetLaoiVes()
        {
            return DAL_QLRCP.Instance.DAL_GetLaoiVes();
        }
        public List<PhongChieu> BLL_GetPhongChieus(int check)
        {
            return DAL_QLRCP.Instance.DAL_GetPhongChieus(check);
        }
        public TaiKhoan BLL_GetTaiKhoan(string sdt)
        {
            return DAL_QLRCP.Instance.DAL_GetTaiKhoan(sdt);
        }
        public List<LichChieu> BLL_GetLichChieus()
        {
            return DAL_QLRCP.Instance.DAL_GetLichChieus();
        }
        public List<ViewThongKe> BLL_GetAllVes()
        {
            return DAL_QLRCP.Instance.DAL_GetAllVes();
        }
        public List<ViewThongKe> BLL_GetVes(string idPhim, DateTime s, DateTime e)
        {

            return DAL_QLRCP.Instance.DAL_GetVes(idPhim, s, e);

        }

        public List<ViewVe> BLL_GetVes(string id)
        {
            return DAL_QLRCP.Instance.DAL_GetVes(id);
        }
        public List<ViewPhongcs> BLL_GetGheNgois(string idphim, DateTime NgayChieu, string CaChieu)
        {
            return DAL_QLRCP.Instance.DAL_GetGheNgois(idphim, NgayChieu, CaChieu);

        }
        public List<DateTime> BLL_GetLichChieuTheoNgays()
        {
            return DAL_QLRCP.Instance.DAL_GetLichChieuTheoNgays();
        }
        public KhachHang BLL_getInforUse(string Phone)
        {
            return DAL_QLRCP.Instance.DAL_getInforUse(Phone);
        }


        public List<Phim> BLL_GetAllFilm(int check, DateTime dateTime)
        {
            return DAL_QLRCP.Instance.DAL_GetAllFilm(check, dateTime);
        }

        public List<Phim> BLL_GetListFilm(string theLoai, string ten, int check, DateTime dateTime)
        {
            return DAL_QLRCP.Instance.DAL_GetListFilm(theLoai, ten, check, dateTime);
        }
        public Phim BLL_GetPhim(string id)
        {
            return DAL_QLRCP.Instance.DAL_GetPhim(id);
        }
        public Ve BLL_GetVe(string id)
        {
            return DAL_QLRCP.Instance.DAL_GetVe(id);
        }
        public KhachHang BLL_getKhachHang(string id)
        {
            return DAL_QLRCP.Instance.DAL_getKhachHang(id);

        }
        public GheNgoi BLL_GetGheNgoi(string id)
        {
            return DAL_QLRCP.Instance.DAL_GetGheNgoi(id);
        }
        public PhongChieu BLL_GetPhong(string id)
        {
            return DAL_QLRCP.Instance.DAL_GetPhong(id);
        }

        public LichChieu BLL_GetLichChieu(string id)
        {
            return DAL_QLRCP.Instance.DAL_GetLichChieu(id);
        }
        public int BLL_GetTienVe(int id)
        {
            return DAL_QLRCP.Instance.DAL_GetTienVe(id);
        }

        public CaChieu BLL_GetCaChieu(string id)
        {
            return DAL_QLRCP.Instance.DAL_GetCaChieu(id);
        }

        public byte[] BLL_ConvertFilltoByte(string str)
        {
            return DAL_QLRCP.Instance.DAL_ConvertFilltoByte(str);
        }

        public List<KhachHang> BLL_DanhSachKhachHang()
        {
            return DAL_QLRCP.Instance.DAL_DanhSachKhachHang();
        }

        public Image BLL_ConvertByteyoImage(byte[] photo)
        {
            return DAL_QLRCP.Instance.DAL_ConvertByteyoImage(photo);
        }

        public bool BLL_DeleteNhanVien(int v)
        {
            return DAL_QLRCP.Instance.DAL_DeleteNhanVien(v);
        }

        public int BLL_GetIdPhim()
        {
            return DAL_QLRCP.Instance.DAL_GetIdPhim();
        }
        public int BLL_GetIdTheLoai()
        {
            return DAL_QLRCP.Instance.DAL_GetIdTheLoai();
        }
        public int BLL_GetIdGheNgoi()
        {
            return DAL_QLRCP.Instance.DAL_GetIdGheNgoi();
        }
        public int BLL_GetIdPhong()
        {
            return DAL_QLRCP.Instance.DAL_GetIdPhong();
        }

        public int BLL_GetIdNhanVien()
        {
            return DAL_QLRCP.Instance.DAL_GetIdNhanVien() + 1;
        }

        public int BLL_GetIdLichChieu()
        {
            return DAL_QLRCP.Instance.DAL_GetIdLichChieu();
        }
        public int BLL_GetIdVe()
        {
            return DAL_QLRCP.Instance.DAL_GetIdVe();
        }

        public bool BLL_AddNhanVien(NhanVien nhanVien)
        {
            return DAL_QLRCP.Instance.DAL_AddNhanVien(nhanVien);
        }

        public bool BLL_CheckPhim(Phim phim)
        {
            return DAL_QLRCP.Instance.DAL_CheckPhim(phim);
        }
        public bool BLL_CheckLichChieu(LichChieu lichChieu)
        {
            return DAL_QLRCP.Instance.DAL_CheckLichChieu(lichChieu);
        }
        public void BLL_AddPhim(Phim phim)
        {
            DAL_QLRCP.Instance.DAL_AddPhim(phim);
        }
        public void BLL_AddPhong(PhongChieu phongChieu)
        {
            DAL_QLRCP.Instance.DAL_AddPhong(phongChieu);
        }

        public bool BLL_EditNhanVien(NhanVien nhanVien)
        {
            return DAL.DAL_QLRCP.Instance.DAL_EditNhanVien(nhanVien);
        }
        public List<NhanVien> BLL_DanhSachNhanVien()
        {
            return DAL_QLRCP.Instance.DAL_DanhSachNhanVien();
        }
        public List<NhanVien> BLL_DanhSachNhanVienWithName(string name)
        {
            List<NhanVien> nhanViens = new List<NhanVien>();

            foreach(NhanVien i in DAL_QLRCP.Instance.DAL_DanhSachNhanVien())
            {
                if (i.HoTen.ToString().ToLower().Contains(name.ToLower()))
                {
                    nhanViens.Add(i);
                }
            }
            return nhanViens;
        }

        public void BLL_AddTheLoai(TheLoai theLoai)
        {
            DAL_QLRCP.Instance.DAL_AddTheLoai(theLoai);
        }
        public void BLL_AddVe(Ve ve)
        {
            DAL_QLRCP.Instance.DAL_AddVe(ve);
        }
        public void BLL_AddLichChieu(LichChieu lichChieu)
        {
            DAL_QLRCP.Instance.DAL_AddLichChieu(lichChieu);
        }
        public void BLL_UpdateKhachHang(string id, int DiemTichLuy)
        {
            DAL_QLRCP.Instance.DAL_UpdateKhachHang(id, DiemTichLuy);
        }
        public void BLL_UpdatePhim(Phim phim)
        {
            DAL_QLRCP.Instance.DAL_UpdatePhim(phim);
        }
        public void BLL_UpdateLichChieu(LichChieu lich)
        {
            DAL_QLRCP.Instance.DAL_UpdateLichChieu(lich);
        }
        public void BLL_UpdateTheLoai(TheLoai theLoai)
        {
            DAL_QLRCP.Instance.DAL_UpdateTheLoai(theLoai);
        }
        public void BLL_UpdateGiaVe(LoaiVe loaiVe)
        {
            DAL_QLRCP.Instance.DAL_UpdateGiaVe(loaiVe);
        }
        public void BLL_UpdatePhong(PhongChieu phongChieu)
        {
            DAL_QLRCP.Instance.DAL_UpdatePhong(phongChieu);
        }
        public void BLL_DeletePhim(string idPhim)
        {
            DAL_QLRCP.Instance.DAL_DeletePhim(idPhim);


        }
        public void BLL_DeletePhong(string id)
        {
            DAL_QLRCP.Instance.DAL_DeletePhong(id);
        }
        public void BLL_DeleteLichChieu(string id)
        {
            DAL_QLRCP.Instance.DAL_DeleteLichChieu(id);
        }
        public void BLL_DeleteTheLoai(string id)
        {
            DAL_QLRCP.Instance.DAL_DeleteTheLoai(id);
        }
        public void BLL_SetTrangThaiGheNgoi(GheNgoi gheNgoi)
        {
            DAL_QLRCP.Instance.DAL_SetTrangThaiGheNgoi(gheNgoi);
        }
        public string[] TachChuoi(string str)
        {
            if (str == null)
            {
                return null;
            }
            string[] arrListStr = str.Split(' ');
            return arrListStr;
        }
    }
}
