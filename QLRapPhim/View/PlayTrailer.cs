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
    public partial class PlayTrailer : Form
    {
        public string idPhim = "";
        public PlayTrailer(string id)
        {
            idPhim = id;
            InitializeComponent();
        }

        private void PlayTrailer_Load(object sender, EventArgs e)
        {
            this.SetDesktopLocation(130, 40);
            if (BLL_QLRCP.Instance.BLL_GetPhim(idPhim).Trailer != null)
                axWindowsMediaPlayer1.URL = BLL_QLRCP.Instance.BLL_GetPhim(idPhim).Trailer;
        }

        private void CCRegis_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "";
            this.Dispose();
        }

        private void CCRegis_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
