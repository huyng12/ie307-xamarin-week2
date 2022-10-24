using System;

using IE307Week2.Models;

namespace IE307Week2.ViewModels
{
    public class DetailViewViewModel
    {
        public string Title { get; set; }

        public DetailItem Item { get; set; }

        public DetailViewViewModel(DetailItem item)
        {
            Item = item;
            Title = item.Title;
        }
    }
}
