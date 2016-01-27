using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Movie_Management
{
    public partial class IMDBGenres : Form
    {
        public IMDBGenres()
        {
            InitializeComponent();
            checkedListBox1.CheckOnClick = true;
        }
  
        public List<string> sGenre { get; set; }

        private void IMDBGenres_Load(object sender, EventArgs e)
        {
            sGenre = new List<string>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Object item in checkedListBox1.CheckedItems)
            {
                string ItemName = item.ToString();
                sGenre.Add(ItemName);
            }
            this.Close();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            
        }

        private void checkedListBox1_MouseClick(object sender, MouseEventArgs e)
        {
        }
    }
}
