using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatTmdb.V3;
namespace TheTVDB_API
{
    public partial class frmTrailer : Form
    {
        WatTmdb.V3.Tmdb API = new Tmdb("Nope", "en");
        int trailerLink;
        public frmTrailer(int link)
        {
            InitializeComponent();
            trailerLink = link;
        }

        private void frmTrailer_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = API.GetMovieTrailers(trailerLink).youtube;
            axShockwaveFlash1.AllowFullScreen = "true";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Need to add the prefix for video...
            axShockwaveFlash1.Movie = "http://www.youtube.com/v/" + API.GetMovieTrailers(trailerLink).youtube[comboBox1.SelectedIndex].source;
        }

        private void frmTailer_resized(object sender, EventArgs e)
        {
            //Some resizing issue that caused the frame to be greater than the form...
            axShockwaveFlash1.Width = ClientSize.Width - comboBox1.Width - 20;
            axShockwaveFlash1.Height = ClientSize.Height - 20;
        }
    }
}
