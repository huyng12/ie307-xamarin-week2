using System;
using System.Collections.Generic;

using IE307Week2.Models;

namespace IE307Week2.Services.Hotel
{
    public interface IHotelService
    {
        List<ListViewItem> GetCities();
        List<ListViewItem> GetHotelsByCityId(int id);
        DetailItem GetHotelDetailById(int id);
    }
}
