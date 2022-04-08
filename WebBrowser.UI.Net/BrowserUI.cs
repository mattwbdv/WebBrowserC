using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser.UI.Net
{
    public partial class BrowserUI : Form
    {
        public BrowserUI()
        {
            InitializeComponent();
            NewTab newTab = new NewTab();
            tabPage1.Controls.Add(newTab);



        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void exitWebBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage newPage = new TabPage("New Tab");
            NewTab newTab = new NewTab();
            newTab.Dock = DockStyle.Fill;
            newPage.Controls.Add(newTab);
            tabControl1.TabPages.Add(newPage);

        }

        private void closeCurrentTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(this.tabControl1.SelectedTab);
        }

        private void manageHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var HistoryManagerForm = new HistoryManagerForm();
            HistoryManagerForm.ShowDialog();
        }

        private void manageBookmarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var BookmarkManagerForm = new BookmarkManagerForm();
            BookmarkManagerForm.ShowDialog();
        }
    }
}
