using System.Collections.Generic;
using System.Threading.Tasks;
using CodingTest.Global.Models;

namespace AGLCodingTest.Data
{
    public interface IRepository
    {
        IEnumerable<Owner> GetOwnerList();

        IEnumerable<OwnerViewModel> SortCatsInAscOrder(IEnumerable<Owner> owners);

    }
}