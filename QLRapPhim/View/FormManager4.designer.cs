namespace QLRapPhim
{
    partial class FormManager4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewVe = new System.Windows.Forms.DataGridView();
            this.textBoxGia = new System.Windows.Forms.TextBox();
            this.buttonGia = new System.Windows.Forms.Button();
            this.labelLoaiVe = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVe)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewVe
            // 
            this.dataGridViewVe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVe.Location = new System.Drawing.Point(287, 79);
            this.dataGridViewVe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewVe.Name = "dataGridViewVe";
            this.dataGridViewVe.ReadOnly = true;
            this.dataGridViewVe.RowHeadersWidth = 51;
            this.dataGridViewVe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewVe.Size = new System.Drawing.Size(588, 242);
            this.dataGridViewVe.TabIndex = 0;
            this.dataGridViewVe.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewVe_CellDoubleClick);
            // 
            // textBoxGia
            // 
            this.textBoxGia.Location = new System.Drawing.Point(388, 385);
            this.textBoxGia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxGia.Name = "textBoxGia";
            this.textBoxGia.Size = new System.Drawing.Size(231, 22);
            this.textBoxGia.TabIndex = 5;
            this.textBoxGia.TextChanged += new System.EventHandler(this.textBoxGia_TextChanged);
            this.textBoxGia.Enter += new System.EventHandler(this.textBoxGia_Enter);
            this.textBoxGia.Leave += new System.EventHandler(this.textBoxGia_Leave);
            // 
            // buttonGia
            // 
            this.buttonGia.Location = new System.Drawing.Point(645, 382);
            this.buttonGia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonGia.Name = "buttonGia";
            this.buttonGia.Size = new System.Drawing.Size(100, 28);
            this.buttonGia.TabIndex = 6;
            this.buttonGia.Text = "Cập Nhật";
            this.buttonGia.UseVisualStyleBackColor = true;
            this.buttonGia.Click += new System.EventHandler(this.buttonGia_Click);
            // 
            // labelLoaiVe
            // 
            this.labelLoaiVe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoaiVe.Location = new System.Drawing.Point(472, 336);
            this.labelLoaiVe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLoaiVe.Name = "labelLoaiVe";
            this.labelLoaiVe.Size = new System.Drawing.Size(223, 28);
            this.labelLoaiVe.TabIndex = 7;
            this.labelLoaiVe.Text = "Vé học sinh-sinh viên";
            this.labelLoaiVe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(455, 20);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(240, 36);
            this.label21.TabIndex = 26;
            this.label21.Text = "Quản Lý Giá Vé";
            // 
            // FormManager4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 460);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.labelLoaiVe);
            this.Controls.Add(this.buttonGia);
            this.Controls.Add(this.textBoxGia);
            this.Controls.Add(this.dataGridViewVe);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormManager4";
            this.Text = "FormManager4";
            this.Load += new System.EventHandler(this.FormManager4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewVe;
        private System.Windows.Forms.TextBox textBoxGia;
        private System.Windows.Forms.Button buttonGia;
        private System.Windows.Forms.Label labelLoaiVe;
        private System.Windows.Forms.Label label21;
    }
}