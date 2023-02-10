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
   
    public partial class ChooseTheFilm : Form
    {
        public string SDT = "";
        bool isMouseDown;
        int xLast;
        int yLast;
        public ChooseTheFilm(string SDTs)
        {
            SDT = SDTs;
            InitializeComponent();
            SetCBBFilm();
        }
        public void SetCBBFilm()
        {
            cbbFilm.Items.Add(new CBBItem { Value = "0", Text = "ALL" });
            foreach (TheLoai i in BLL_QLRCP.Instance.BLL_GetListGenre())
            {
                cbbFilm.Items.Add(new CBBItem
                {
                    Value = i.id,
                    Text = i.TenTheLoai
                });
            }
            cbbFilm.SelectedIndex = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
            Environment.Exit(1);
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

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {
            individual1.SetDB(SDT);
            if (individual1.Visible == false && lbDangXuat.Visible == false)
            {
                lbDangXuat.BringToFront();
                individual1.BringToFront();
                bunifuTransition1.Show(individual1);
                bunifuTransition1.Show(lbDangXuat);
            }
            else
            {
                bunifuTransition1.Hide(lbDangXuat);
                bunifuTransition1.Hide(individual1);
            }
        }
        private void label1_MouseHover(object sender, EventArgs e)
        {
            lbDangXuat.BackColor = Color.Yellow;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            lbDangXuat.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Dispose();
        }

        private void individual1_Load(object sender, EventArgs e)
        {

        }
        public void Show(string TheLoai, string Ten)
        {
            DateTime dateTime = new DateTime();
            if (comboBoxNgayChieu.Text == "Hôm nay")
            {

                dateTime = DateTime.Now.Date;
            }
            else
            {
                dateTime = Convert.ToDateTime(comboBoxNgayChieu.SelectedItem).Date;
            }
            if (TheLoai == "ALL")
            {

                DataGridViewFilm.DataSource = BLL_QLRCP.Instance.BLL_GetAllFilm(1, dateTime.Date);
            }
            else
            {
                DataGridViewFilm.DataSource = BLL_QLRCP.Instance.BLL_GetListFilm(TheLoai, Ten, 1, dateTime.Date);
            }

        }
        private void ChooseTheFilm_Load(object sender, EventArgs e)
        {
            this.SetDesktopLocation(130, 40);
            bunifuTransition2.Show(label1);
            if (BLL_QLRCP.Instance.BLL_GetTaiKhoan(SDT).LoaiTK == 1)
            {
                textBox1.Visible = true;
                textBox2.Visible = true;
                label3.Text = "DANH SÁCH VÉ HÔM NAY";

            }
            List<DateTime> lichChieus = BLL_QLRCP.Instance.BLL_GetLichChieuTheoNgays();
            foreach (DateTime i in lichChieus)
            {
                if (i.Date == DateTime.Now.Date)
                {
                    comboBoxNgayChieu.Items.Add("Hôm nay");
                }
                else
                {
                    comboBoxNgayChieu.Items.Add(i.Month + "-" + i.Day + "-" + i.Year);
                }
                comboBoxNgayChieu.SelectedIndex = 0;
            }
            this.SetDesktopLocation(130, 40);
            Show("ALL", "");
            dataGridViewLichSuMua.DataSource = BLL_QLRCP.Instance.BLL_GetVes(BLL_QLRCP.Instance.BLL_getInforUse(SDT).id);
        }

        private void bunifuDataGridView1_DataSourceChanged(object sender, EventArgs e)
        {

            DataGridViewFilm.Columns[0].Visible = false;
            DataGridViewFilm.Columns[1].Visible = false;
            DataGridViewFilm.Columns[3].Visible = false;
            DataGridViewFilm.Columns[5].Visible = false;
            DataGridViewFilm.Columns[7].Visible = false;
            DataGridViewFilm.Columns[9].Visible = false;
            DataGridViewFilm.Columns[10].Visible = false;
            DataGridViewFilm.Columns[11].Visible = false;
            DataGridViewFilm.Columns[12].Visible = false;
            DataGridViewFilm.Columns["ThoiLuong"].Width = 100;
            DataGridViewFilm.Columns["TenPhim"].Width = 135;
            DataGridViewFilm.Columns["Daodien"].Width = 80;
            DataGridViewFilm.Columns["NgayCongChieu"].Width = 110;
            DataGridViewFilm.Columns[2].HeaderText = "Tên phim";
            DataGridViewFilm.Columns[4].HeaderText = "Thời lượng";
            DataGridViewFilm.Columns[6].HeaderText = "Đạo diễn";
            DataGridViewFilm.Columns[8].HeaderText = "Ngày khởi chiếu";
        }


        private void cbbFilm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string check = cbbFilm.SelectedItem.ToString();
            Show(check, "");
        }

        private void lbDangXuat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

            string check = bunifuTextBox1.Text;
            Show("", check);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void dataGridViewLichSuMua_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewLichSuMua.CurrentRow != null)
            {
                FormVe formVe = new FormVe(dataGridViewLichSuMua.CurrentRow.Cells["id"].Value.ToString());
                formVe.ShowDialog();
            }
        }

        private void cbbFilm_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string check = cbbFilm.SelectedItem.ToString();
            Show(check, "");
        }

        private void comboBoxNgayChieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            Show(cbbFilm.Text, "");
        }

        private void DataGridViewFilm_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DateTime dateTime = new DateTime();
            if (comboBoxNgayChieu.Text == "Hôm nay")
            {

                dateTime = DateTime.Now.Date;
            }
            else
            {
                dateTime = Convert.ToDateTime(comboBoxNgayChieu.SelectedItem).Date;
            }
            string idPhim = DataGridViewFilm.CurrentRow.Cells["id"].Value.ToString();
            this.Hide();
            DetailTheFilm dtf = new DetailTheFilm(idPhim, dateTime.Date, BLL_QLRCP.Instance.BLL_getInforUse(SDT).id);
            dtf.ShowDialog();
            dataGridViewLichSuMua.DataSource = BLL_QLRCP.Instance.BLL_GetVes(BLL_QLRCP.Instance.BLL_getInforUse(SDT).id);
            this.Show();
        }


        private void dataGridViewLichSuMua_DataSourceChanged(object sender, EventArgs e)
        {
            dataGridViewLichSuMua.Columns[0].HeaderText = "ID";
            dataGridViewLichSuMua.Columns[1].Width = 140;
            dataGridViewLichSuMua.Columns[1].HeaderText = "Tên khách hàng";
            dataGridViewLichSuMua.Columns[2].HeaderText = "Số điện thoại";
            dataGridViewLichSuMua.Columns[3].HeaderText = "Tên phim";
            dataGridViewLichSuMua.Columns[4].HeaderText = "Ghế đã mua";
            dataGridViewLichSuMua.Columns[5].HeaderText = "Tổng tiền";
            dataGridViewLichSuMua.Columns[6].HeaderText = "Ngày chiếu";
            dataGridViewLichSuMua.Columns[7].HeaderText = "Giờ chiếu";
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(1);
        }
 
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            List<ViewVe> viewVes = new List<ViewVe>();
            foreach (ViewVe i in BLL_QLRCP.Instance.BLL_GetVes(BLL_QLRCP.Instance.BLL_getInforUse(SDT).id))
            {
                if (i.SDT.ToString().ToLower().Contains(textBox1.Text.ToLower()))
                {
                    viewVes.Add(i);
                }
            }
            dataGridViewLichSuMua.DataSource = viewVes;
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            List<ViewVe> viewVes = new List<ViewVe>();
            foreach (ViewVe i in BLL_QLRCP.Instance.BLL_GetVes(BLL_QLRCP.Instance.BLL_getInforUse(SDT).id))
            {
                if (i.id.ToString().ToLower().Contains(textBox2.Text.ToLower()))
                {
                    viewVes.Add(i);
                }
            }
            dataGridViewLichSuMua.DataSource = viewVes;
        }


    }
}

