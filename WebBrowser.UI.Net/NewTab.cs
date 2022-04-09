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
    public partial class NewTab : UserControl
    {
        public NewTab()
        {
            InitializeComponent();
        }

        // Navigates to the given URL if it is valid.
        private void Navigate(String address)
        {
            if (String.IsNullOrEmpty(address)) return;
            if (address.Equals("about:blank")) return;
            if (!address.StartsWith("http://") &&
                !address.StartsWith("https://"))
            {
                address = "http://" + address;
            }
            try
            {
                webBrowser1.Navigate(new Uri(address));
            }
            catch (System.UriFormatException)
            {
                return;
            }
        }

        // Navigates to the URL in the address box when 
        // the ENTER key is pressed while the ToolStripTextBox has focus.
        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                Navigate(toolStripTextBox1.Text);
                
            }

        }


        // Updates the URL in TextBoxAddress upon navigation.


        private void goButton_Click(object sender, EventArgs e)
        {
            Navigate(toolStripTextBox1.Text);


        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
            toolStripTextBox1.Text = webBrowser1.Url.ToString();

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
            toolStripTextBox1.Text = webBrowser1.Url.ToString();

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            var item = new BookmarkItem();
            item.Title = webBrowser1.DocumentTitle.ToString();
            item.URL = webBrowser1.Url.ToString();

            BookmarkManager.AddItem(item);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            toolStripTextBox1.Text = webBrowser1.Url.ToString();
            var item = new HistoryItem();
            item.Title = webBrowser1.DocumentTitle.ToString();
            item.Date = DateTime.Now;
            item.URL = webBrowser1.Url.ToString();

            HistoryManager.AddItem(item);

        }
    }
}
