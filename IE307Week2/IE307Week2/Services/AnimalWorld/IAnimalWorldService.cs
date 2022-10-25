using System;
using System.Collections.Generic;

using IE307Week2.Models;

namespace IE307Week2.Services.AnimalWorld
{
    public interface IAnimalWorldService
    {
        List<ListViewItem> GetGroups();
        List<ListViewItem> GetSpeciesByGroupId(int id);
        DetailItem GetSpeciesDetailById(int id);
    }
}
