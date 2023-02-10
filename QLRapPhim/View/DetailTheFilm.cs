using QLRapPhim.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLRapPhim
{
    public partial class DetailTheFilm : Form
    {
        bool isMouseDown;
        int xLast;
        int yLast;
        public string idKhachhang = "";
        public string idPhim = "";
        public DateTime NgayChieu = DateTime.Now;
        public DetailTheFilm(string id, DateTime dateTime, string idKhachHang)
        {
            idKhachhang = idKhachHang;
            idPhim = id;
            NgayChieu = dateTime;
            InitializeComponent();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            isMouseDown = true;
            xLast = e.X;
            yLast = e.Y;
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (isMouseDown)
            {
                int newY = this.Top + (e.Y - yLast);
                int newX = this.Left + (e.X - xLast);

                this.Location = new Point(newX, newY);
            }

            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            isMouseDown = false;

            base.OnMouseUp(e);
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void DetailTheFilm_Load(object sender, EventArgs e)
        {
            this.SetDesktopLocation(130, 40);
            Phim phim = BLL_QLRCP.Instance.BLL_GetPhim(idPhim);
            pictureBox1.Image = BLL_QLRCP.Instance.BLL_ConvertByteyoImage(phim.ApPhich);
            pictureBox3.Visible = false;
            pictureBox3.Image = BLL_QLRCP.Instance.BLL_ConvertByteyoImage(phim.ApPhich);
            bunifuLabelName.Text = phim.TenPhim;
            bunifuTransition2.Show(bunifuLabelName);
            LableCongChieu.Text = phim.NgayCongChieu.Day.ToString() + "-" + phim.NgayCongChieu.Month.ToString() + "-" + phim.NgayCongChieu.Year.ToString();
            LableDienVien.Text = phim.DienVien;
            lableDaoDien.Text = phim.DaoDien;
            lableHangPhim.Text = phim.HangPhim;
            LableTheLoai.Text = phim.TheLoai.TenTheLoai;
            LableThoiLuong.Text = phim.ThoiLuong.ToString() + " phút";
            TextMoTa.Text = phim.MoTa;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.BringToFront();
            pictureBox3.Visible = true;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {

            pictureBox3.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            PlayTrailer p = new PlayTrailer(idPhim);
            p.ShowDialog();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            ChooseSeat cs = new ChooseSeat(idPhim, NgayChieu, idKhachhang);
            this.Hide();
            cs.ShowDialog();
            this.Show();
        }
    }
}
