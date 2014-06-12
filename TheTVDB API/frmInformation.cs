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
using TagLib;
using System.IO;
using System.Net;
using TagLib.Id3v2;

//Ryan Guarasia
//June, 01, 2014
//Pulls data from TMDB 

namespace TheTVDB_API
{
    public partial class frmInformation : Form
    {
        WatTmdb.V3.Tmdb API = new Tmdb("Nope", "en");
        int movieID;
        TmdbMovie myMovie;
        WatTmdb.V3.TmdbMovieImages myPoster;
        frmTrailer playTrailer;
        public frmInformation(int TitleId)
        {
            InitializeComponent();
            movieID = TitleId;
        }

        private void frmInformation_Load(object sender, EventArgs e)
        {
            //Gets well, the info
            List<String> countries = new List<String>();
            myPoster = API.GetMovieImages(movieID, "en");
            myMovie = API.GetMovieInfo(movieID);
            txtTitle.Text = myMovie.title;
            txtYear.Text = myMovie.release_date.ToString();

            //Don't know if there works for all movies......
            try
            {
                picPoster.ImageLocation = "http://image.tmdb.org/t/p/w185" + myPoster.posters[0].file_path;
            }
            catch (ArgumentException)
            {
                picPoster.ImageLocation = "noposter.jpg";
            }

            richTextBox1.Text = myMovie.overview;
            lstActors.DataSource = API.GetMovieCast(movieID).cast;

            //Craziness to just get the rating but makes sense
            foreach (ReleaseCountry elements in API.GetMovieReleases(movieID).countries)
            {
                countries.Add(elements.certification);
                txtRating.Text = countries[0];
            }
            //Crew members, really I only wanted director but this works, the more info the better I guess ^_^
            foreach (Crew members in API.GetMovieCast(movieID).crew)
            {
                lstCrew.Items.Add(members.job + ": " + members.name);
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            //Doesn't work so don't use it ... yet :3
            OpenFileDialog getFile = new OpenFileDialog();
            if (getFile.ShowDialog() == DialogResult.OK)
            {
                TagLib.File myVideo = TagLib.File.Create(getFile.FileName);
                myVideo.Tag.Title = "Test";
                myVideo.Tag.Year = 2014;
                myVideo.Save();
                myVideo.Dispose();
            }
        }

        private void savePosterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PosterSizer();
        }

        private void frmInformation_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnPlayTrailer_Click(object sender, EventArgs e)
        {
            playTrailer = new frmTrailer(movieID);
            playTrailer.Show();

        }

        private void gtnBack_Click(object sender, EventArgs e)
        {
            //Debugging does not like this.
            Application.Restart();
        }

        private void PosterSizer()
        {
            SaveFileDialog posterPath = new SaveFileDialog();
            posterPath.Filter = "PNG(*.png)|*.png";
            //Gets the real size from URL
            try
            {
                //Weird stuff because pulling from URL.
                WebRequest request = WebRequest.Create("https://image.tmdb.org/t/p/original/" + myPoster.posters[0].file_path);
                WebResponse response = request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                Bitmap posterFile = new Bitmap(responseStream);
                if (posterPath.ShowDialog() == DialogResult.OK)
                    posterFile.Save(posterPath.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception)
            {
                MessageBox.Show("Poster not found");
            }

        }
    }
}
