
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
    public partial class Main : Form
    {
        bool isMouseDown;
        int xLast;
        int yLast;
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void labelRegis_Click(object sender, EventArgs e)
        {
            labelNoAcc.Visible = false;
            labelRegis.Visible = false;
            
            bunifuTransition2.HideSync(btLogin);
            bunifuTransition1.HideSync(lg1);
            bunifuTransition1.ShowSync(register1);
            CCRegis.Visible = true;
        }
        private void CCRegis_Click(object sender, EventArgs e)
        {
            CCRegis.Visible = false;
            lg1.Visible = false;
            bunifuTransition1.HideSync(register1);
            CCRegis.Visible = false;
            bunifuTransition1.ShowSync(lg1);
            bunifuTransition2.ShowSync(btLogin);
            bunifuTransition2.ShowSync(labelNoAcc);
            bunifuTransition2.ShowSync(labelRegis);
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

        private void lg1_BackColorChanged(object sender, EventArgs e)
        {
            if (lg1.BackColor == SystemColors.ButtonHighlight)
                this.Hide();
        }

        private void btLG_Click(object sender, EventArgs e)
        {
            if (lg1.Phone == "" || lg1.Password == "")
            {
                MessageBox.Show("Không được để trống các mục");
                return;
            }
            QuanLyRapChieuPhimDB db = new QuanLyRapChieuPhimDB();
            var l = db.TaiKhoans.Where(p => p.Phone == lg1.Phone && p.Pass == lg1.Password).Select(p => p);
            if (l.Count() == 0)
            {
                MessageBox.Show("Mật khẩu hoặc Số điện thoại không chính xác");
            }
            else
            {
                List<TaiKhoan> taiKhoans = l.ToList<TaiKhoan>();
                if (taiKhoans[0].LoaiTK == 0)
                {
                    ChooseTheFilm c = new ChooseTheFilm(taiKhoans[0].Phone);
                    this.Hide();
                    c.ShowDialog();
                    this.Show();

                }
                if (taiKhoans[0].LoaiTK == 1)
                {
                    ChooseTheFilm c = new ChooseTheFilm(taiKhoans[0].Phone);
                    this.Hide();
                    c.ShowDialog();
                    this.Show();
                }
                if (taiKhoans[0].LoaiTK == 2)
                {
                    FormManager formManager = new FormManager();
                    this.Hide();
                    formManager.ShowDialog();
                    this.Show();
                }
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.SetDesktopLocation(130, 40);
            register1.Visible = false;
            CCRegis.Visible = false;
            label5.Visible = false;
            bunifuTransition3.Show(label5);
        }

        private void register1_VisibleChanged(object sender, EventArgs e)
        {
            if(CCRegis.Visible == true)
            {
                lg1.Visible = false;
                bunifuTransition1.HideSync(register1);
                CCRegis.Visible = false;
                bunifuTransition1.ShowSync(lg1);
                bunifuTransition2.ShowSync(btLogin);
                bunifuTransition2.ShowSync(labelNoAcc);
                bunifuTransition2.ShowSync(labelRegis);
                lg1.Phone = register1.Phone;
                if (register1.Password != "")
                {
                    lg1.Pass();
                    lg1.Password = register1.Password;
                }

            }
            
        }
    }
}
