using System;
using System.Collections.Generic;

using IE307Week2.Models;
using IE307Week2.Models.Hotel;

namespace IE307Week2.Services.Hotel
{
    public class MockHotelService : IHotelService
    {
        private readonly List<CityItem> cities = new List<CityItem>
        {
            new CityItem{ Id = 1, Name = "Ha Noi City", Thumbnail = "ha_noi.jpeg" },
            new CityItem{ Id = 2, Name = "Ho Chi Minh City", Thumbnail = "ho_chi_minh.jpeg" },
            new CityItem{ Id = 3, Name = "Nha Trang City", Thumbnail = "nha_trang.jpeg" },
            new CityItem{ Id = 4, Name = "Hue City", Thumbnail = "hue.jpeg" },
        };

        private readonly List<HotelItem> hotels = new List<HotelItem>
        {
            // Nha Trang
            new HotelItem{
                Id = 1,
                CityId = 3,
                Name = "Mia Resort Nha Trang",
                Address = "Cam Hai Dong, Nha Trang",
                Price = 2_986_258,
                Thumbnail = "nt_mia.jpeg",
                Description = "The car parking and the Wi-Fi are always free, so you can stay in touch and come and go as you please. Conveniently situated in the Cam Hải Đông part of Nha Trang, this property puts you close to attractions and interesting dining options. Don't leave before paying a visit to the famous Vinpearl Land Nha Trang. Rated with 5 stars, this high-quality property provides guests with access to massage, restaurant and hot tub on-site.",
            },
            new HotelItem{
                Id = 2,
                CityId = 3,
                Name = "Amiana Resort Nha Trang",
                Address = "Vinh Hoa, Nha Trang",
                Price = 2_761_460,
                Thumbnail = "nt_amiana.jpeg",
                Description = "The car parking and the Wi-Fi are always free, so you can stay in touch and come and go as you please. Conveniently situated in the Vĩnh Hòa part of Nha Trang, this property puts you close to attractions and interesting dining options. Don't leave before paying a visit to the famous Vinpearl Land Nha Trang. Rated with 5 stars, this high-quality property provides guests with access to massage, restaurant and fitness center on-site.",
            },

            // Ha Noi
            new HotelItem{
                Id = 3,
                CityId = 1,
                Name = "Lotte Hotel Hanoi",
                Address = "Ba Dinh, Ha Noi",
                Price = 4_524_373,
                Thumbnail = "hn_lotte.jpeg",
                Description = "The car parking and the Wi-Fi are always free, so you can stay in touch and come and go as you please. Conveniently situated in the Ba Đình part of Hanoi, this property puts you close to attractions and interesting dining options. Don't leave before paying a visit to the famous Old Quarter. Rated with 5 stars, this high-quality property provides guests with access to massage, restaurant and hot tub on-site.",
            },
            new HotelItem{
                Id = 4,
                CityId = 1,
                Name = "La Passion Hanoi Hotel and Spa",
                Address = "Old Quarter, Ha Noi",
                Price = 1_503_044,
                Thumbnail = "hn_la_passion.jpeg",
                Description = "Get your trip off to a great start with a stay at this property, which offers free Wi-Fi in all rooms. Strategically situated in Old Quarter, allowing you access and proximity to local attractions and sights. Don't leave before paying a visit to the famous Old Quarter. Rated with 4 stars, this high-quality property provides guests with access to massage, restaurant and spa on-site.",
            },

            // Ho Chi Minh
            new HotelItem{
                Id = 5,
                CityId = 2,
                Name = "Rex Hotel Saigon",
                Address = "District 1, Ho Chi Minh",
                Price = 2_823_310,
                Thumbnail = "hcm_rex.jpeg",
                Description = "Get your trip off to a great start with a stay at this property, which offers free Wi-Fi in all rooms. Strategically situated in District 1, allowing you access and proximity to local attractions and sights. Don't leave before paying a visit to the famous War Remnants Museum. Rated with 5 stars, this high-quality property provides guests with access to massage, restaurant and hot tub on-site.",
            },
            new HotelItem{
                Id = 6,
                CityId = 2,
                Name = "La Vela Saigon Hotel",
                Address = "District 3, Ho Chi Minh",
                Price = 3_575_823,
                Thumbnail = "hcm_la_vela.jpeg",
                Description = "The car parking and the Wi-Fi are always free, so you can stay in touch and come and go as you please. Conveniently situated in the District 3 part of Ho Chi Minh City, this property puts you close to attractions and interesting dining options. Don't leave before paying a visit to the famous War Remnants Museum. Rated with 5 stars, this high-quality property provides guests with access to restaurant, fitness center and steamroom on-site.",
            },

            // Hue
            new HotelItem{
                Id = 7,
                CityId = 4,
                Name = "Senna Hue Hotel",
                Address = "Hue",
                Price = 1_181_966,
                Thumbnail = "hue_senna.jpeg",
                Description = "The car parking and the Wi-Fi are always free, so you can stay in touch and come and go as you please. Strategically situated in Hue City, allowing you access and proximity to local attractions and sights. Don't leave before paying a visit to the famous Hue Imperial Citadel. Rated with 5 stars, this high-quality property provides guests with access to massage, restaurant and hot tub on-site.",
            },
            new HotelItem{
                Id = 8,
                CityId = 4,
                Name = "Melia Vinpearl Hue",
                Address = "Hue",
                Price = 1_545_953,
                Thumbnail = "hue_melia.jpeg",
                Description = "Get your trip off to a great start with a stay at this property, which offers free Wi-Fi in all rooms. Strategically situated in Hue City, allowing you access and proximity to local attractions and sights. Don't leave before paying a visit to the famous Hue Imperial Citadel. Rated with 5 stars, this high-quality property provides guests with access to massage, restaurant and hot tub on-site.",
            },
        };

        private static ListViewItem CityItemToListViewItem(CityItem item)
        {
            return new ListViewItem
            {
                Id = item.Id,
                Text = item.Name,
                Detail = String.Empty,
                Thumbnail = item.Thumbnail,
                IsLeaf = false,
            };
        }

        private static ListViewItem HotelItemToListViewItem(HotelItem item)
        {
            var formattedPrice = String.Format("{0:C0}", new decimal(item.Price));
            return new ListViewItem
            {
                Id = item.Id,
                Text = item.Name,
                Detail = $"₫{formattedPrice} | {item.Address}",
                Thumbnail = item.Thumbnail,
                IsLeaf = true,
            };
        }

        private static DetailItem HotelItemToDetailItem(HotelItem item)
        {
            return new DetailItem
            {
                Thumbnail = item.Thumbnail,
                Title = item.Name,
                Description = item.Description,
            };
        }

        public List<ListViewItem> GetCities()
        {
            return cities
                .ConvertAll(new Converter<CityItem, ListViewItem>(CityItemToListViewItem));
        }

        public List<ListViewItem> GetHotelsByCityId(int id)
        {
            return hotels
                .FindAll(hotel => hotel.CityId == id)
                .ConvertAll(new Converter<HotelItem, ListViewItem>(HotelItemToListViewItem));
        }

        public DetailItem GetHotelDetailById(int id)
        {
            return HotelItemToDetailItem(hotels.Find(hotel => hotel.Id == id));
        }
    }
}
