using System;

namespace IE307Week2.Models
{
    public class ListViewItem
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Detail { get; set; }
        public string Thumbnail { get; set; }
        public bool IsLeaf { get; set; }
    }
}
