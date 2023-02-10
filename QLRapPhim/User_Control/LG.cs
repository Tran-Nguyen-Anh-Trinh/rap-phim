using Microsoft.VisualBasic;
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
    public partial class LG : UserControl
    {
        public LG()
        {
            InitializeComponent();
        }
        public string Phone
        {
            get
            {
                return bunifuTextBox1.Text;
            }
            set
            {
                bunifuTextBox1.Text = value;
            }
        }
        public string Password
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
       public void Pass()
        {

            bunifuTextBox2.PasswordChar = '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string srt = "";
            if (bunifuTextBox1.Text != "Phone")
            {
                srt = bunifuTextBox1.Text;
            }
            string input = Interaction.InputBox("Nhập số diện thoại", "Quên mật khẩu", srt, 500, 300);

            QuanLyRapChieuPhimDB db = new QuanLyRapChieuPhimDB();
            var l = db.TaiKhoans.Select(p => p);

            List<TaiKhoan> taiKhoans = l.ToList<TaiKhoan>();
            foreach (TaiKhoan i in taiKhoans)
            {
                if (i.Phone == input)
                {
                    string check1 = Interaction.InputBox("Nhập vào tên của bạn", "Quên mật khẩu", "", 500, 300);
                    string check2 = Interaction.InputBox("Nhập vào ngày-tháng-năm sinh của bạn \n(Định dạng: dd-mm-yy)", "Quên mật khẩu", "", 500, 300);
                    var l1 = db.KhachHangs.Where(p => p.SDT == i.Phone).Select(p => p);
                    List<KhachHang> khachhangs = l1.ToList<KhachHang>();
                    foreach (KhachHang j in khachhangs)
                    {

                        if (check1 == j.HoTen && check2 == (j.NgaySinh.Day.ToString() + "-" + j.NgaySinh.Month.ToString() + "-" + j.NgaySinh.Year.ToString()))
                        {
                            MessageBox.Show("Mật khẩu của bạn là : " + i.Pass);
                            bunifuTextBox1.Text = i.Phone;
                            bunifuTextBox2.Text = i.Pass;
                            return;
                        }
                        MessageBox.Show("Thông tin không chính xác");
                    }
                    return;
                }
            }
            if (input != "")
            {
                MessageBox.Show("Không tồn tại số điện thoại: " + input);
            }

        }

        private void bunifuTextBox2_Enter(object sender, EventArgs e)
        {
            if(bunifuTextBox2.Text != "Password")
            {
                bunifuTextBox2.PlaceholderText = "";
                bunifuTextBox2.PasswordChar = '*';
            }    
        }

        private void bunifuTextBox2_Leave(object sender, EventArgs e)
        {
            if (bunifuTextBox2.Text == "")
            {
                bunifuTextBox2.PlaceholderText = "Mật khẩu";
                bunifuTextBox2.PasswordChar = '\0';
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng chưa phát triển");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng chưa phát triển");
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text.Length > 0)
            {
                char a = bunifuTextBox1.Text[bunifuTextBox1.Text.Length - 1];
                if (bunifuTextBox1.Text.Length > 11)
                {
                    bunifuTextBox1.Text = bunifuTextBox1.Text.Remove(bunifuTextBox1.Text.Length - 1, 1);
                    MessageBox.Show("SDT chỉ bao gồm 11 chữ số");
                    return;
                }
                if (a < '0' || a > '9')
                {
                    bunifuTextBox1.Text = bunifuTextBox1.Text.Remove(bunifuTextBox1.Text.Length - 1, 1);
                    MessageBox.Show("SDT bao gồm các chữ số");
                }
            }
        }
    }
}
