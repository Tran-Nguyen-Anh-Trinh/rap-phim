using QLRapPhim.BLL;
using QLRapPhim.DTO;
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
    public partial class ChooseSeat : Form
    {
        bool isMouseDown;
        int xLast;
        int yLast;

        public string idKhachHang = "";
        public string idPhim = "";
        public DateTime NgayChieu = DateTime.Now.Date;
        public string idGheNgoi = "";
        public int SoVe = 0;
        public int VeFree = 0;
        public ChooseSeat(string id, DateTime dateTime, string idUse)
        {
            idKhachHang = idUse;
            idPhim = id;
            NgayChieu = dateTime.Date;
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
        private void button1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
            
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void G1_Click(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor == Color.Gold)
            {
                ((Button)sender).BackColor = SystemColors.Control;
                VeTEXT.Text = VeTEXT.Text.Replace(((Button)sender).Text + " ", "");
                SoVe--;
                textBoxDiemCongThem.Text = SoVe.ToString();
                if (LoaiVe1.Checked == true)
                {
                    textBoxGiaVe.Text = (SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(1)).ToString() + " VND";
                    textBoxTongGiaVe.Text = (SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(1)).ToString() + " VND";
                    textBoxMoney.Text = (-VeFree * BLL_QLRCP.Instance.BLL_GetTienVe(1) + SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(1)).ToString() + " VND";
                }
                else if (LoaiVe2.Checked == true)
                {
                    textBoxGiaVe.Text = (SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(2)).ToString() + " VND";
                    textBoxTongGiaVe.Text = (SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(2)).ToString() + " VND";
                    textBoxMoney.Text = (-VeFree * BLL_QLRCP.Instance.BLL_GetTienVe(1) + SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(2)).ToString() + " VND";
                }
                else
                {
                    textBoxGiaVe.Text = (SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(3)).ToString() + " VND";
                    textBoxTongGiaVe.Text = (SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(3)).ToString() + " VND";
                    textBoxMoney.Text = (-VeFree * BLL_QLRCP.Instance.BLL_GetTienVe(1) + SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(3)).ToString() + " VND";
                }
            }
            else
            {
                ((Button)sender).BackColor = Color.Gold;
                VeTEXT.Text += ((Button)sender).Text + " ";
                SoVe++;
                textBoxDiemCongThem.Text = SoVe.ToString();
                if (LoaiVe1.Checked == true)
                {
                    textBoxGiaVe.Text = (SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(1)).ToString() + " VND";
                    textBoxTongGiaVe.Text = (SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(1)).ToString() + " VND";
                    textBoxMoney.Text = (-VeFree * BLL_QLRCP.Instance.BLL_GetTienVe(1) + SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(1)).ToString() + " VND";
                }
                else if (LoaiVe2.Checked == true)
                {
                    textBoxGiaVe.Text = (SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(2)).ToString() + " VND";
                    textBoxTongGiaVe.Text = (SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(2)).ToString() + " VND";
                    textBoxMoney.Text = (-VeFree * BLL_QLRCP.Instance.BLL_GetTienVe(1) + SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(2)).ToString() + " VND";
                }
                else
                {
                    textBoxGiaVe.Text = (SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(3)).ToString() + " VND";
                    textBoxTongGiaVe.Text = (SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(3)).ToString() + " VND";
                    textBoxMoney.Text = (-VeFree * BLL_QLRCP.Instance.BLL_GetTienVe(1) + SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(3)).ToString() + " VND";
                }

            }
        }


        private void LoaiVe3_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                if (((RadioButton)sender).Name == "LoaiVe1")
                {
                    textBoxGiaVe.Text = (SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(1)).ToString() + " VND";
                    textBoxTongGiaVe.Text = (SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(1)).ToString() + " VND";
                    textBoxMoney.Text = (-VeFree * BLL_QLRCP.Instance.BLL_GetTienVe(1) + SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(1)).ToString() + " VND";
                }
                else if (((RadioButton)sender).Name == "LoaiVe2")
                {
                    textBoxGiaVe.Text = (SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(2)).ToString() + " VND";
                    textBoxTongGiaVe.Text = (SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(2)).ToString() + " VND";
                    textBoxMoney.Text = (-VeFree * BLL_QLRCP.Instance.BLL_GetTienVe(1) + SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(2)).ToString() + " VND";
                }
                else
                {
                    textBoxGiaVe.Text = (SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(3)).ToString() + " VND";
                    textBoxTongGiaVe.Text = (SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(3)).ToString() + " VND";
                    textBoxMoney.Text = (-VeFree * BLL_QLRCP.Instance.BLL_GetTienVe(1) + SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(3)).ToString() + " VND";
                }

            }
        }

        private void textBoxFreeVe_TextChanged(object sender, EventArgs e)
        {
            if (textBoxFreeVe.Text.Length > 0)
            {
                char a = textBoxFreeVe.Text[textBoxFreeVe.Text.Length - 1];

                if (a < '0' || a > '9')
                {
                    textBoxFreeVe.Text = textBoxFreeVe.Text.Remove(textBoxFreeVe.Text.Length - 1, 1);
                    MessageBox.Show("Yêu cầu nhập số");
                    return;
                }
                if (Convert.ToInt32(textBoxFreeVe.Text) > ((BLL_QLRCP.Instance.BLL_getKhachHang(idKhachHang).DiemTichLuy + Convert.ToInt32(textBoxDiemCongThem.Text)) / 20))
                {
                    MessageBox.Show("Số điểm tích lũy không đủ");
                    textBoxFreeVe.Text = "0";
                }

            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            VeFree = Convert.ToInt32(textBoxFreeVe.Text);
            if (LoaiVe1.Checked == true)
            {
                textBoxDiscount.Text = (VeFree * BLL_QLRCP.Instance.BLL_GetTienVe(1)).ToString() + " VND";
                textBoxMoney.Text = (-VeFree * BLL_QLRCP.Instance.BLL_GetTienVe(1) + SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(1)).ToString() + " VND";
            }
            else if (LoaiVe2.Checked == true)
            {

                textBoxDiscount.Text = (VeFree * BLL_QLRCP.Instance.BLL_GetTienVe(1)).ToString() + " VND";
                textBoxMoney.Text = (-VeFree * BLL_QLRCP.Instance.BLL_GetTienVe(1) + SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(2)).ToString() + " VND";
            }
            else
            {
                textBoxDiscount.Text = (VeFree * BLL_QLRCP.Instance.BLL_GetTienVe(1)).ToString() + " VND";
                textBoxMoney.Text = (-VeFree * BLL_QLRCP.Instance.BLL_GetTienVe(1) + SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(3)).ToString() + " VND";
            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            if (textBoxTongGiaVe.Text == "" || textBoxTongGiaVe.Text == "0 VND")
            {
                MessageBox.Show("Vui lọng chọn chỗ ngồi trước khi thanh toán");

            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn đặt vé!", "Đặt Vé", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    GheNgoi gheNgoi = new GheNgoi();
                    gheNgoi = BLL_QLRCP.Instance.BLL_GetGheNgoi(idGheNgoi);
                    gheNgoi.TrangThai += VeTEXT.Text;
                    BLL_QLRCP.Instance.BLL_SetTrangThaiGheNgoi(gheNgoi);
                    string[] arrGheNgoi = BLL_QLRCP.Instance.TachChuoi(gheNgoi.TrangThai);
                    foreach (string i in arrGheNgoi)
                    {
                        if (i == "")
                        {
                            continue;
                        }
                        var button = Controls.OfType<Button>().FirstOrDefault(b => b.Text == i);
                        button.BackColor = Color.Red;
                        button.Enabled = false;
                    }
                    Ve ve = new Ve();
                    ve.id = BLL_QLRCP.Instance.BLL_GetIdVe().ToString();
                    ve.idGheNgoi = idGheNgoi;
                    ve.idKhachHang = idKhachHang;
                    if (LoaiVe1.Checked == true)
                    {
                        ve.LoaiVe = 1;
                        ve.TienBanVe = SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(1) - VeFree * BLL_QLRCP.Instance.BLL_GetTienVe(1);
                    }
                    else if (LoaiVe2.Checked == true)
                    {
                        ve.LoaiVe = 2;
                        ve.TienBanVe = SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(2) - VeFree * BLL_QLRCP.Instance.BLL_GetTienVe(1);
                    }
                    else
                    {
                        ve.LoaiVe = 3;
                        ve.TienBanVe = SoVe * BLL_QLRCP.Instance.BLL_GetTienVe(3) - VeFree * BLL_QLRCP.Instance.BLL_GetTienVe(1);
                    }

                    ve.Ghe = VeTEXT.Text;
                    BLL_QLRCP.Instance.BLL_AddVe(ve);

                    FormVe formVe = new FormVe(ve.id);
                    formVe.ShowDialog();

                    if (BLL_QLRCP.Instance.BLL_getKhachHang(idKhachHang).TaiKhoan.LoaiTK == 1)
                    {

                    }
                    else
                    {
                        BLL_QLRCP.Instance.BLL_UpdateKhachHang(idKhachHang, (Convert.ToInt32(textBoxDiemTichLuy.Text) + Convert.ToInt32(textBoxDiemCongThem.Text) - VeFree * 20));
                    }
                    SoVe = 0;
                    VeFree = 0;
                    textBoxDiemTichLuy.Text = BLL_QLRCP.Instance.BLL_getKhachHang(idKhachHang).DiemTichLuy.ToString();
                    textBoxDiemCongThem.Text = "0";
                    textBoxFreeVe.Text = "0";
                    textBoxDiscount.Text = "0 VND";
                    textBoxGiaVe.Text = "0 VND";
                    textBoxTongGiaVe.Text = "0 VND";
                    textBoxMoney.Text = "0 VND";
                    VeTEXT.Text = "";
                }
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                cbbPhong.Items.Add(1111111);
                SoVe = 0;
                VeFree = 0;
                textBoxDiemCongThem.Text = "0";
                textBoxFreeVe.Text = "0";
                textBoxDiscount.Text = "0 VND";
                textBoxGiaVe.Text = "0 VND";
                textBoxTongGiaVe.Text = "0 VND";
                textBoxMoney.Text = "0 VND";
                VeTEXT.Text = "";
                cbbPhong.Items.Clear();
                foreach(ViewPhongcs cs in BLL_QLRCP.Instance.BLL_GetGheNgois(idPhim, NgayChieu, ((RadioButton)sender).Name.ToString()))
                {
                    cbbPhong.Items.Add(new CBBPhong
                    {
                        idGheNgoi = cs.idGheNgoi,
                        TenPhong = cs.TenPhong,
                        TrangThai = cs.TrangThai
                    });
                    cbbPhong.SelectedIndex = 0;
                }
                for (int i = 1; i <= 10; i++)
                {
                    var button = Controls.OfType<Button>().FirstOrDefault(b => b.Text == ("A" + i.ToString()));
                    if (button.Visible == false)
                    {
                        button.Visible = true;
                    }
                    button.BackColor = SystemColors.Control;
                    button.Enabled = false;
                }
                for (int i = 1; i <= 10; i++)
                {
                    var button = Controls.OfType<Button>().FirstOrDefault(b => b.Text == ("B" + i.ToString()));
                    if (button.Visible == false)
                    {
                        button.Visible = true;
                    }
                    button.BackColor = SystemColors.Control;
                    button.Enabled = false;
                }
                for (int i = 1; i <= 10; i++)
                {
                    var button = Controls.OfType<Button>().FirstOrDefault(b => b.Text == ("C" + i.ToString()));
                    if (button.Visible == false)
                    {
                        button.Visible = true;
                    }
                    button.BackColor = SystemColors.Control;
                    button.Enabled = false;
                }
                for (int i = 1; i <= 10; i++)
                {
                    var button = Controls.OfType<Button>().FirstOrDefault(b => b.Text == ("E" + i.ToString()));
                    if (button.Visible == false)
                    {
                        button.Visible = true;
                    }
                    button.BackColor = SystemColors.Control;
                    button.Enabled = false;
                }
                for (int i = 1; i <= 10; i++)
                {
                    var button = Controls.OfType<Button>().FirstOrDefault(b => b.Text == ("D" + i.ToString()));
                    if (button.Visible == false)
                    {
                        button.Visible = true;
                    }
                    button.BackColor = SystemColors.Control;
                    button.Enabled = false;
                }
                for (int i = 1; i <= 10; i++)
                {
                    var button = Controls.OfType<Button>().FirstOrDefault(b => b.Text == ("F" + i.ToString()));
                    if (button.Visible == false)
                    {
                        button.Visible = true;
                    }
                    button.BackColor = SystemColors.Control;
                    button.Enabled = false;

                }
                for (int i = 1; i <= 10; i++)
                {
                    var button = Controls.OfType<Button>().FirstOrDefault(b => b.Text == ("G" + i.ToString()));
                    if (button.Visible == false)
                    {
                        button.Visible = true;
                    }
                    button.BackColor = SystemColors.Control;
                    button.Enabled = false;
                }
            }
        }
        private void ChooseSeat_Load(object sender, EventArgs e)
        {
            this.SetDesktopLocation(130, 40);
            if (BLL_QLRCP.Instance.BLL_getKhachHang(idKhachHang).TaiKhoan.LoaiTK == 1)
            {
                groupBoxUse.Enabled = false;
            }
            label14.Text ="Ngày chiếu: " + NgayChieu.Day.ToString() 
                + "/" + NgayChieu.Month.ToString() 
                + "/" + NgayChieu.Year.ToString();
            NameKhachhang.Text = BLL_QLRCP.Instance.BLL_getKhachHang(idKhachHang).HoTen;
            textBoxDiemCongThem.Text = "0";
            textBoxDiemTichLuy.Text = BLL_QLRCP.Instance.BLL_getKhachHang(idKhachHang).DiemTichLuy.ToString();
            textBoxFreeVe.Text = (BLL_QLRCP.Instance.BLL_getKhachHang(idKhachHang).DiemTichLuy / 20).ToString();
            Phim phim = BLL_QLRCP.Instance.BLL_GetPhim(idPhim);
            pictureBox2.Image = BLL_QLRCP.Instance.BLL_ConvertByteyoImage(phim.ApPhich);
            for (int i = 1; i <= 10; i++)
            {
                var button = Controls.OfType<Button>().FirstOrDefault(b => b.Text == ("A" + i.ToString()));
                button.Enabled = false;
            }
            for (int i = 1; i <= 10; i++)
            {
                var button = Controls.OfType<Button>().FirstOrDefault(b => b.Text == ("B" + i.ToString()));
                button.Enabled = false;
            }
            for (int i = 1; i <= 10; i++)
            {
                var button = Controls.OfType<Button>().FirstOrDefault(b => b.Text == ("C" + i.ToString()));
                button.Enabled = false;
            }
            for (int i = 1; i <= 10; i++)
            {
                var button = Controls.OfType<Button>().FirstOrDefault(b => b.Text == ("E" + i.ToString()));
                button.Enabled = false;
            }
            for (int i = 1; i <= 10; i++)
            {
                var button = Controls.OfType<Button>().FirstOrDefault(b => b.Text == ("D" + i.ToString()));
                button.Enabled = false;
            }
            for (int i = 1; i <= 10; i++)
            {
                var button = Controls.OfType<Button>().FirstOrDefault(b => b.Text == ("F" + i.ToString()));
                button.Enabled = false;

            }
            for (int i = 1; i <= 10; i++)
            {
                var button = Controls.OfType<Button>().FirstOrDefault(b => b.Text == ("G" + i.ToString()));
                button.Enabled = false;
            }
        }


        private void cbbPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                var button = Controls.OfType<Button>().FirstOrDefault(b => b.Text == ("A" + i.ToString()));
                button.Enabled = true;
            }
            for (int i = 1; i <= 10; i++)
            {
                var button = Controls.OfType<Button>().FirstOrDefault(b => b.Text == ("B" + i.ToString()));
                button.Enabled = true;
            }
            for (int i = 1; i <= 10; i++)
            {
                var button = Controls.OfType<Button>().FirstOrDefault(b => b.Text == ("C" + i.ToString()));
                button.Enabled = true;
            }
            for (int i = 1; i <= 10; i++)
            {
                var button = Controls.OfType<Button>().FirstOrDefault(b => b.Text == ("E" + i.ToString()));
                button.Enabled = true;
            }
            for (int i = 1; i <= 10; i++)
            {
                var button = Controls.OfType<Button>().FirstOrDefault(b => b.Text == ("D" + i.ToString()));
                button.Enabled = true;
            }
            for (int i = 1; i <= 10; i++)
            {
                var button = Controls.OfType<Button>().FirstOrDefault(b => b.Text == ("F" + i.ToString()));
                button.Enabled = true;

            }
            for (int i = 1; i <= 10; i++)
            {
                var button = Controls.OfType<Button>().FirstOrDefault(b => b.Text == ("G" + i.ToString()));
                button.Enabled = true;
            }
            idGheNgoi = ((CBBPhong)cbbPhong.SelectedItem).idGheNgoi;
            GheNgoi gheNgoi = new GheNgoi();
            gheNgoi = BLL_QLRCP.Instance.BLL_GetGheNgoi(idGheNgoi);
            int sochongoi = 70 - gheNgoi.LichChieu.PhongChieu.SoChoNgoi;
            if (sochongoi != 0)
            {
                if (sochongoi < 11)
                {
                    for (int i = sochongoi; i >= 1; i--)
                    {
                        var button = Controls.OfType<Button>().FirstOrDefault(b => b.Text == ("G" + i.ToString()));
                        button.Visible = false;
                    }
                }
                else
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        var button = Controls.OfType<Button>().FirstOrDefault(b => b.Text == ("G" + i.ToString()));
                        button.Visible = false;
                    }
                    for (int j = sochongoi - 10; j >= 1; j--)
                    {
                        var button1 = Controls.OfType<Button>().FirstOrDefault(p => p.Text == ("F" + j.ToString()));
                        button1.Visible = false;
                    }
                }

            }
            if (gheNgoi.TrangThai != null)
            {
                string[] arrGheNgoi = BLL_QLRCP.Instance.TachChuoi(gheNgoi.TrangThai);

                foreach (string i in arrGheNgoi)
                {
                    if (i == "")
                    {
                        continue;
                    }
                    var button = Controls.OfType<Button>().FirstOrDefault(b => b.Text == i);
                    button.BackColor = Color.Red;
                    button.Enabled = false;
                }
            }
        }


    }
}
