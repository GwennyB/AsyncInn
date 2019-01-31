using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenity
    {

        // create
        Task CreateAmenity(Amenity amenity);

        // read
        List<Amenity> GetAmenities();

        // update
        Task UpdateAmenity(Amenity amenity);

        // delete
        Task DeleteAmenity(Amenity amenity);
    }
}
