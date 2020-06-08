using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guoyang_Liu_Sec003_Exercise01
{
    public partial class GetList : Form
    {
        public GetList()
        {
            InitializeComponent();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            var dbcontext = new ClassLibrary1.BooksEntities();


            var authorsAndTitle =
               from author in dbcontext.Authors
               from book in author.Titles
               orderby book.Title1
               select new { book.Title1, author.FirstName, author.LastName };

            ResultTextBox.AppendText("Get a list of all the titles and the authors who wrote them. Sort the results by title.");


            foreach (var element in authorsAndTitle)
            {
                ResultTextBox.AppendText($"\r\n\t{element.Title1,-10}" +
                   $"{element.LastName,-10} {element.FirstName,-10} ");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var dbcontext = new ClassLibrary1.BooksEntities();


            var authorsAndTitle2 =
               from author in dbcontext.Authors
               from book in author.Titles
               orderby author.LastName, author.FirstName, book.Title1
               select new { book.Title1, author.FirstName, author.LastName };

            ResultTextBox.AppendText("\r\n\r\nGet a list of all the titles and the authors who wrote them. Sort the results by title. Each title sort the authorsalphabetically by last name, then first name.");



            foreach (var element in authorsAndTitle2)
            {
                ResultTextBox.AppendText($"\r\n\t{element.FirstName,-10} " +
                   $"{element.LastName,-10} {element.Title1,-10}");
            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var dbcontext = new ClassLibrary1.BooksEntities();

            var titlesbytitle =
                from title in dbcontext.Titles
                orderby title.Title1
                select new
                {
                    Title = title.Title1 + ".",
                    Name =
                from name in title.Authors
                orderby name.LastName, name.FirstName
                select name.FirstName

                };
            ResultTextBox.AppendText("\r\n\r\nTitles grouped by title:");

            // display titles written by each author, grouped by author
            foreach (var title in titlesbytitle)
            {
                // display author's name
                ResultTextBox.AppendText($"\r\n\t{title.Title}:");

                // display titles written by that author
                foreach (var name in title.Name)
                {
                    ResultTextBox.AppendText($"\r\n\t\t{name}");
                }
            }
        }

        

        private void ResultTextBox_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
