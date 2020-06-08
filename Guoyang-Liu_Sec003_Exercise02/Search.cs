using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guoyang_Liu_Sec003_Exercise02
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        ClassLibrary2.BaseballEntities dbcontext =
            new ClassLibrary2.BaseballEntities();

        private void Search_Load(object sender, EventArgs e)
        {
            dbcontext.Players
               .OrderBy(Player => Player.PlayerID)
               .Load();
            playerBindingSource.DataSource = dbcontext.Players.Local;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            var Lastnamequery =
                from players in dbcontext.Players
                where players.LastName.StartsWith(LastnametextBox.Text)
                orderby players.LastName
                select players;

            playerBindingSource.DataSource = Lastnamequery.ToList();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            dbcontext.Players
               .OrderBy(Player => Player.PlayerID)
               .Load();
            playerBindingSource.DataSource = dbcontext.Players.Local;
        }
    }
}
