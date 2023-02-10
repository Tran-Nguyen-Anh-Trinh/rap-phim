using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLRapPhim.View
{
    public partial class FormManager5 : Form
    {
        public FormManager5()
        {
            InitializeComponent();
        }

        private void FormManager5_Load(object sender, EventArgs e)
        {
            panelDanhSachNhanVien.Visible = true;
            panelKhachHang.Visible = false;
            panelChinhSua.Visible = false;
            panelAddNhanVien.Visible = false;
            buttonDanhSachNhanVien.BackColor = SystemColors.ButtonHighlight;
            DataGridViewNhanVien.DataSource = BLL.BLL_QLRCP.Instance.BLL_DanhSachNhanVien();
        }

        private void buttonDanhSachNhanVien_Click(object sender, EventArgs e)
        {
            if (panelDanhSachNhanVien.Visible == false)
            {                
                panelDanhSachNhanVien.Visible = true;
                panelChinhSua.Visible = false;
                panelAddNhanVien.Visible = false;
                panelKhachHang.Visible = false;
                buttonDanhSachNhanVien.BackColor = SystemColors.ButtonHighlight;
                buttonKhachHang.BackColor = SystemColors.ControlLight;
                buttonThemMoi.BackColor = SystemColors.ControlLight;
                buttonChinhSua.BackColor = SystemColors.ControlLight;
                DataGridViewNhanVien.DataSource = BLL.BLL_QLRCP.Instance.BLL_DanhSachNhanVien();
                textBox2.Text = "";
            }
        }

        private void buttonThemMoi_Click(object sender, EventArgs e)
        {
            if (panelAddNhanVien.Visible == false)
            {
                panelDanhSachNhanVien.Visible = false;
                panelChinhSua.Visible = false;
                panelAddNhanVien.Visible = true;
                panelKhachHang.Visible = false;
                buttonDanhSachNhanVien.BackColor = SystemColors.ControlLight;
                buttonKhachHang.BackColor = SystemColors.ControlLight;
                buttonThemMoi.BackColor = SystemColors.ButtonHighlight;
                buttonChinhSua.BackColor = SystemColors.ControlLight;
            }
        }

        private void buttonChinhSua_Click(object sender, EventArgs e)
        {         
            if (panelChinhSua.Visible == true) return;
            if (DataGridViewNhanVien.CurrentRow != null && panelDanhSachNhanVien.Visible == true)
            {
                if (panelChinhSua.Visible == false)
                {
                    panelDanhSachNhanVien.Visible = false;
                    panelChinhSua.Visible = true;
                    panelAddNhanVien.Visible = false;
                    panelKhachHang.Visible = false;
                    buttonDanhSachNhanVien.BackColor = SystemColors.ControlLight;
                    buttonKhachHang.BackColor = SystemColors.ControlLight;
                    buttonThemMoi.BackColor = SystemColors.ControlLight;
                    buttonChinhSua.BackColor = SystemColors.ButtonHighlight;
                    txtNameEdit.Text =  DataGridViewNhanVien.CurrentRow.Cells["HoTen"].Value.ToString();
                    QQEdit.Text = DataGridViewNhanVien.CurrentRow.Cells["QueQuan"].Value.ToString();
                    CVEdit.Text = DataGridViewNhanVien.CurrentRow.Cells["ChucVu"].Value.ToString();
                    dateEdit.Value = (DateTime)DataGridViewNhanVien.CurrentRow.Cells["NgaySinh"].Value;
                    if(DataGridViewNhanVien.CurrentRow.Cells["GioiTinh"].Value.ToString() == "True")
                    {
                        btnNamEdit.Checked = true;
                    }else
                    {
                        btnNuEdit.Checked = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên muốn chỉnh sửa");
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (DataGridViewNhanVien.CurrentRow != null && panelDanhSachNhanVien.Visible == true)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn xóa nhân viên trên!", "DELETE", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (BLL.BLL_QLRCP.Instance.BLL_DeleteNhanVien(int.Parse(DataGridViewNhanVien.CurrentRow.Cells["id"].Value.ToString())))
                    {
                        MessageBox.Show("Xóa thành công!");
                        DataGridViewNhanVien.DataSource = BLL.BLL_QLRCP.Instance.BLL_DanhSachNhanVien();
                        textBox2.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công!");
                    } 
                }
            }
        }

        private void buttonKhachHang_Click(object sender, EventArgs e)
        {
            if (panelKhachHang.Visible == false)
            {
                panelDanhSachNhanVien.Visible = false;
                panelChinhSua.Visible = false;
                panelAddNhanVien.Visible = false;
                panelKhachHang.Visible = true;
                buttonDanhSachNhanVien.BackColor = SystemColors.ControlLight;
                buttonKhachHang.BackColor = SystemColors.ButtonHighlight;
                buttonThemMoi.BackColor = SystemColors.ControlLight;
                buttonChinhSua.BackColor = SystemColors.ControlLight;
                dataGridViewKhachHang.DataSource = BLL.BLL_QLRCP.Instance.BLL_DanhSachKhachHang();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string tenNV = textBox2.Text.Trim();
            if (tenNV.Equals(""))
            {
                DataGridViewNhanVien.DataSource = BLL.BLL_QLRCP.Instance.BLL_DanhSachNhanVien();
            }else
            {
                DataGridViewNhanVien.DataSource = BLL.BLL_QLRCP.Instance.BLL_DanhSachNhanVienWithName(tenNV);
            }
            
        }

        private void dataGridViewKhachHang_DataSourceChanged(object sender, EventArgs e)
        {
            dataGridViewKhachHang.Columns["TaiKhoan"].Visible = false;
            dataGridViewKhachHang.Columns["Ves"].Visible = false;
        }

        private void buttonADD_Click(object sender, EventArgs e)
        {
            if (textBoxTenNV.Text.Trim() == "" || richtxtQQ.Text.Trim() == "" || richtxtCV.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống các mục");
                return;
            }
            NhanVien nhanVien = new NhanVien();
            nhanVien.id = BLL.BLL_QLRCP.Instance.BLL_GetIdNhanVien();
            nhanVien.HoTen = textBoxTenNV.Text.Trim();
            nhanVien.NgaySinh = dateSinh.Value;
            nhanVien.QueQuan = richtxtQQ.Text.Trim();
            nhanVien.ChucVu = richtxtCV.Text.Trim();
            nhanVien.GioiTinh = btnNam.Checked;
            if (BLL.BLL_QLRCP.Instance.BLL_AddNhanVien(nhanVien))
            {
                MessageBox.Show("Thêm Thành Công!");
                textBoxTenNV.Text = "";
                richtxtQQ.Text = "";
                richtxtCV.Text = "";
                btnNam.Checked = true;
            } else
            {
                MessageBox.Show("Thêm Không Thành Công!");
            }
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            if(txtNameEdit.Text.Trim() == "" || QQEdit.Text.Trim() == "" || CVEdit.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống các mục");
                return;
            }
            NhanVien nhanVien = new NhanVien();
            nhanVien.id = int.Parse(DataGridViewNhanVien.CurrentRow.Cells["id"].Value.ToString());
            nhanVien.HoTen = txtNameEdit.Text.Trim();
            nhanVien.NgaySinh = dateEdit.Value;
            nhanVien.QueQuan = QQEdit.Text.Trim();
            nhanVien.ChucVu = CVEdit.Text.Trim();
            nhanVien.GioiTinh = btnNamEdit.Checked;
            if (BLL.BLL_QLRCP.Instance.BLL_EditNhanVien(nhanVien))
            {
                MessageBox.Show("Chỉnh Sửa Thành Công!");
                panelDanhSachNhanVien.Visible = true;
                panelChinhSua.Visible = false;
                panelAddNhanVien.Visible = false;
                panelKhachHang.Visible = false;
                buttonDanhSachNhanVien.BackColor = SystemColors.ButtonHighlight;
                buttonKhachHang.BackColor = SystemColors.ControlLight;
                buttonThemMoi.BackColor = SystemColors.ControlLight;
                buttonChinhSua.BackColor = SystemColors.ControlLight;
                DataGridViewNhanVien.DataSource = BLL.BLL_QLRCP.Instance.BLL_DanhSachNhanVien();
                textBox2.Text = "";
            }
            else
            {
                MessageBox.Show("Chỉnh Sửa Không Thành Công!");
            }
        }
    }
}
