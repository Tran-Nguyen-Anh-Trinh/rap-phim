using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLRapPhim.BLL;

namespace QLRapPhim
{
    public partial class FormVe : Form
    {
        public string idVe = "";
        public FormVe(string id)
        {
            idVe = id;
            InitializeComponent();
        }

        private void FormVe_Load(object sender, EventArgs e)
        {
            this.SetDesktopLocation(850, 250);
            Ve ve = BLL_QLRCP.Instance.BLL_GetVe(idVe);
            if(ve.KhachHang.SDT == "0")
            {
                labelSDT.Visible = false;
                label2.Visible = false;
                label1.Text = "Người bán: ";
            }
            labelid.Text ="ID: " + ve.id.ToString();
            lbGio.Text = ve.GheNgoi.LichChieu.CaChieu.ThoigianBatDau.ToString() + " đến " + ve.GheNgoi.LichChieu.CaChieu.ThoiGianKetThuc.ToString();
            labelTen.Text = ve.KhachHang.HoTen;
            labelSDT.Text = ve.KhachHang.SDT;
            labelPhim.Text = ve.GheNgoi.LichChieu.Phim.TenPhim;
            labelghe.Text = ve.Ghe;
            labeltongtien.Text = ve.TienBanVe.ToString() + " VND";
            lbngay.Text = ve.GheNgoi.LichChieu.NgayChieu.Day.ToString() + "-" + ve.GheNgoi.LichChieu.NgayChieu.Month.ToString() + "-" + ve.GheNgoi.LichChieu.NgayChieu.Year.ToString();
            pictureBoxphim.Image = BLL_QLRCP.Instance.BLL_ConvertByteyoImage(ve.GheNgoi.LichChieu.Phim.ApPhich);
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
