using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotel
    {

        // create
        Task CreateHotel(Hotel hotel);

        // read
        List<Hotel> GetHotels();

        // update
        Task UpdateHotel(Hotel hotel);

        // delete
        Task DeleteHotel(Hotel hotel);

    }

}
