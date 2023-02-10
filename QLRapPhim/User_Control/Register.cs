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
    public partial class Register : UserControl
    {
        public Register()
        {
            InitializeComponent();
        }
        public string Phone
        {
            get
            {
                return bunifuTextBox2.Text;
            }
            set
            {
                bunifuTextBox2.Text = value;
            }
        }
        public string Password
        {
            get
            {
                return bunifuTextBox3.Text;
            }
            set
            {
                bunifuTextBox3.Text = value;
            }
        }

        private void bunifuTextBox3_Enter(object sender, EventArgs e)
        {
            if (bunifuTextBox3.Text != "Password")
            {
                bunifuTextBox3.PlaceholderText = "";
                bunifuTextBox3.PasswordChar = '*';
            }
        }

        private void bunifuTextBox3_Leave(object sender, EventArgs e)
        {
            if (bunifuTextBox3.Text == "")
            {
                bunifuTextBox3.PlaceholderText = "Mật khẩu";
                bunifuTextBox3.PasswordChar = '\0';
            }
        }

        private void bunifuTextBox4_Enter(object sender, EventArgs e)
        {
            if (bunifuTextBox4.Text != "Password")
            {
                bunifuTextBox4.PlaceholderText = "";
                bunifuTextBox4.PasswordChar = '*';
            }
        }

        private void bunifuTextBox4_Leave(object sender, EventArgs e)
        {
            if (bunifuTextBox4.Text == "")
            {
                bunifuTextBox4.PlaceholderText = "Xác nhận mật khẩu";
                bunifuTextBox4.PasswordChar = '\0';
            }
        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (bunifuTextBox2.Text.Length > 0)
            {
                char a = bunifuTextBox2.Text[bunifuTextBox2.Text.Length - 1];
                if (bunifuTextBox2.Text.Length > 11)
                {
                    bunifuTextBox2.Text = bunifuTextBox2.Text.Remove(bunifuTextBox2.Text.Length - 1, 1);
                    MessageBox.Show("SDT chỉ bao gồm 11 chữ số");
                    return;
                }
                if (a < '0' || a > '9')
                {
                    bunifuTextBox2.Text = bunifuTextBox2.Text.Remove(bunifuTextBox2.Text.Length - 1, 1);
                    MessageBox.Show("SDT bao gồm các chữ số");
                }
            }
        }

        public int GetId()
        {
            QuanLyRapChieuPhimDB db = new QuanLyRapChieuPhimDB();
            int count = db.KhachHangs.Select(p => p).Count();
            if (count == 0)
            {
                return 99;
            }
            var l = db.KhachHangs.OrderByDescending(p => p.id).First();
            return Convert.ToInt32(l.id);
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox4.Text == "" || bunifuTextBox1.Text == ""
                || bunifuTextBox2.Text == "" || bunifuTextBox3.Text == "" || label2.Visible == true)
            {
                MessageBox.Show("Không được để trống các mục");
                return;
            }
            if (bunifuTextBox4.Text != bunifuTextBox3.Text)
            {
                MessageBox.Show("Mật khẩu không trùng khớp");
                return;
            }
            QuanLyRapChieuPhimDB db = new QuanLyRapChieuPhimDB();
            int count = db.TaiKhoans.Where(p => p.Phone == bunifuTextBox2.Text).Count();
            if (count != 0)
            {
                MessageBox.Show("Số điện thoại " + bunifuTextBox2.Text + " đã đăng ký sử dụng dịch vụ");
                return;
            }

            KhachHang s = new KhachHang()
            {
                id = (GetId() + 1).ToString(),
                HoTen = bunifuTextBox1.Text,
                NgaySinh = bunifuDatePicker1.Value,
                SDT = bunifuTextBox2.Text,
                DiemTichLuy = 0
            };
            TaiKhoan tk = new TaiKhoan()
            {
                Phone = bunifuTextBox2.Text,
                Pass = bunifuTextBox3.Text,
                LoaiTK = 0
            };
            db.KhachHangs.Add(s);
            db.TaiKhoans.Add(tk);
            db.SaveChanges();
            MessageBox.Show("Đăng ký tài khoản thành công");
            this.Visible = false;
            bunifuTextBox1.Text = "";
            bunifuTextBox2.Text = "";
            bunifuTextBox3.Text = "";
            bunifuTextBox4.Text = "";
            bunifuTextBox3.PlaceholderText = "Mật khẩu";
            bunifuTextBox4.PlaceholderText = "Xác nhận mật khẩu";
            bunifuTextBox3.PasswordChar = '\0';
            bunifuTextBox4.PasswordChar = '\0';
        }

        private void bunifuDatePicker1_MouseEnter(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

        //private void bunifuDatePicker1_MouseLeave(object sender, EventArgs e)
        //{
        //    label2.Visible = true;
        //}
    }
}
