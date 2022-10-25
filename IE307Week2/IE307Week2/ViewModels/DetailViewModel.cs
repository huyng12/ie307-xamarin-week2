using System;

using IE307Week2.Models;

namespace IE307Week2.ViewModels
{
    public class DetailViewModel
    {
        public string Title { get; set; }

        public DetailItem Item { get; set; }

        public DetailViewModel(DetailItem item)
        {
            Item = item;
            Title = item.Title;
        }
    }
}
