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
using RestSharp;

//Ryan Guarasia
//June, 01, 2014
//Pulls data from TMDB 

namespace TheTVDB_API
{
    public partial class frmMain : Form
    {
        string MovieTitle;
        WatTmdb.V3.Tmdb API = new Tmdb("2d1945d4baade9251047015f58d86230", "en");
        public static List<MovieResult> queryMovie;
        public frmMain()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MovieTitle = txtMovieTitle.Text;
            try
            {
                queryMovie = API.SearchMovie(MovieTitle, 1).results;
            }
            catch (ArgumentException) { }
            listBox1.DataSource = queryMovie;

        }

        private void txtMovieTitle_TextChanged(object sender, EventArgs e)
        {
            if (radDynamic.Checked)
                button1_Click(null, null);
        }

        private void btnTop_Click(object sender, EventArgs e)
        {
            //This is messy
            if (listBox1.SelectedIndex != -1)
            {
                MovieResult Title;
                string selected = listBox1.SelectedItem.ToString();
                int senderID;
                Title = API.SearchMovie(selected, 1).results[0];
                senderID = Title.id;
                frmInformation dataForm = new frmInformation(senderID);
                dataForm.Show();
                this.Hide();
            }
        }
    }
}
