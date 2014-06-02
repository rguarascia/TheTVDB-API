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

//Ryan Guarasia
//June, 01, 2014
//Pulls data from TMDB 

namespace TheTVDB_API
{
    public partial class frmInformation : Form
    {
        WatTmdb.V3.Tmdb API = new Tmdb("2d1945d4baade9251047015f58d86230", "en");
        int movieID;
        TmdbMovie myMovie;
        public frmInformation(int TitleId)
        {
            InitializeComponent();
            movieID = TitleId;
        }

        private void frmInformation_Load(object sender, EventArgs e)
        {

            myMovie = API.GetMovieInfo(movieID);

            txtTitle.Text = myMovie.title;

            txtYear.Text = myMovie.release_date.ToString();

           WatTmdb.V3.TmdbMovieImages myPoster = API.GetMovieImages(movieID, "en");

           try
           {
               picPoster.ImageLocation = "http://image.tmdb.org/t/p/w185" + myPoster.posters[0].file_path;
           }
           catch (ArgumentException)
           {
               picPoster.ImageLocation = "";
           }

           richTextBox1.Text = myMovie.overview;

           txtBudget.Text = String.Format("{0:C}", myMovie.budget);

           txtRating.Text = String.Format("{0:0}", myMovie.popularity);
        }
    }
}
