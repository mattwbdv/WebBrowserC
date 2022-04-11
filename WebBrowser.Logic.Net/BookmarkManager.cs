using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBrowser.Data.Net.BookmarksDataSetTableAdapters;

namespace WebBrowser.Logic.Net
{
    public class BookmarkManager
    {
        public static void AddItem(BookmarkItem item)
        {
            var adapter = new BookmarksTableAdapter();
            adapter.Insert(item.Title, item.URL);
        }
        public static void RemoveItem(BookmarkItem item)
        {
            var adapter = new BookmarksTableAdapter();
            adapter.Delete(item.Id, item.Title, item.URL);
        }

        public static List<BookmarkItem> GetItems()
        {
            var adapter = new BookmarksTableAdapter();
            var results = new List<BookmarkItem>();
            var rows = adapter.GetData();

            foreach (var row in rows)
            {
                var item = new BookmarkItem();
                item.Title = row.Title;
                item.URL = row.URL;
                item.Id = row.Id;

                results.Add(item);
            }
            return results; 
        }
    }
}
