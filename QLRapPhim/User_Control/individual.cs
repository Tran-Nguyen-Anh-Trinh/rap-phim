using Microsoft.VisualBasic;
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
    public partial class individual : UserControl
    {
        QuanLyRapChieuPhimDB db = new QuanLyRapChieuPhimDB();
        public string phone = "";
        public individual()
        {
            InitializeComponent();
        }
        public void SetDB(string SDT)
        {

            phone = SDT;
            label1.Text = BLL_QLRCP.Instance.BLL_getInforUse(SDT).HoTen;
            label2.Text = BLL_QLRCP.Instance.BLL_getInforUse(SDT).SDT;
            label3.Text = BLL_QLRCP.Instance.BLL_getInforUse(SDT).NgaySinh.Month.ToString() + "-" + BLL_QLRCP.Instance.BLL_getInforUse(SDT).NgaySinh.Day.ToString() + "-" + BLL_QLRCP.Instance.BLL_getInforUse(SDT).NgaySinh.Year.ToString();
            label4.Text = "Thay đổi mật khẩu";
            label5.Text = "Điểm tích lũy: " + BLL_QLRCP.Instance.BLL_getInforUse(SDT).DiemTichLuy;

        }
        private void label1_Hover(object sender, EventArgs e)
        {
            label1.BackColor = Color.Yellow;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            label2.BackColor = Color.Yellow;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            label3.BackColor = Color.Yellow;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            label4.BackColor = Color.Yellow;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            label5.BackColor = Color.Yellow;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Nhập tên bạn muốn thay dổi", "Thay đổi họ tên", label1.Text, 500, 300);
            if (input == "" || input == label1.Text)
            {
                return;
            }
            else
            {
                var result = db.KhachHangs.Where(b => b.SDT == phone).FirstOrDefault();
                if (result != null)
                {
                    result.HoTen = input;
                    db.SaveChanges();
                    label1.Text = input;
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Không thể thay đổi thông tin số điện thoại");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DateTime date = new DateTime();
            string input = Interaction.InputBox("Nhập vào tháng-ngày-năm sinh của bạn \n(Định dạng: mm-dd-yy)", "Thay đổi ngày sinh", label3.Text, 500, 300);
            if (input == "") return;
            try
            {
                date = Convert.ToDateTime(input);
            }
            catch (Exception erorr)
            {
                MessageBox.Show("Nhập sai kiểu định dạng");
                return;
            }

            var result = db.KhachHangs.Where(b => b.SDT == phone).FirstOrDefault();
            if (result != null)
            {
                result.NgaySinh = date;
                db.SaveChanges();
                label3.Text = input;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Nhập mật khẩu cũ", "Thay đổi mật khẩu", "", 500, 300);
            if (input == "") return;
            int count = db.TaiKhoans.Where(p => p.Phone == phone && p.Pass == input).Count();
            if (count == 0)
            {
                MessageBox.Show("Mật khẩu không chính xác");
            }
            else
            {
                string inputMK = Interaction.InputBox("Nhập mật khẩu mới", "Thay đổi mật khẩu", "", 500, 300);
                if (inputMK == "" || inputMK == label4.Text)
                {
                    return;
                }
                else
                {
                    var result = db.TaiKhoans.SingleOrDefault(b => b.Phone == phone);
                    if (result != null)
                    {
                        result.Pass = inputMK;
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
