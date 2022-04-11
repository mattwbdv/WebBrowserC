using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebBrowser.Logic.Net;


namespace WebBrowser.UI.Net
{
    public partial class BookmarkManagerForm : Form
    {
        public BookmarkManagerForm()
        {
            InitializeComponent();
        }

        private void BookmarkManagerForm_Load(object sender, EventArgs e)
        {
            var items = BookmarkManager.GetItems();
            listBox1.Items.Clear();

            foreach (var item in items)
            {
                listBox1.Items.Add(string.Format("{0} - {1}", item.Title, item.URL));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var items = BookmarkManager.GetItems();
            listBox1.Items.Clear();

            foreach (var item in items)
            {
                string title = item.Title.ToUpper();
                string searchQuery = textBox1.Text.ToUpper();
                if (title.Contains(searchQuery))
                {
                    listBox1.Items.Add(string.Format("{0} - {1}", item.Title, item.URL));

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string curItem = listBox1.SelectedItem.ToString();
            var firstSpaceIndex = curItem.IndexOf(" ");
            var titleToFind = curItem.Substring(0, firstSpaceIndex);

            titleToFind = titleToFind.ToUpper();

            var items = BookmarkManager.GetItems();
            foreach (var item in items)
            {
                string title = item.Title.ToUpper();
                if (title.Contains(titleToFind))
                {
                    BookmarkManager.RemoveItem(item);

                }
            }

            var newItems = BookmarkManager.GetItems();
            listBox1.Items.Clear();

            foreach (var item in newItems)
            {
                string title = item.Title.ToUpper();
                string searchQuery = textBox1.Text.ToUpper();
                if (title.Contains(searchQuery))
                {
                    listBox1.Items.Add(string.Format("{0} - {1}", item.Title, item.URL));

                }
            }
        }
    }
}
