using Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Repsitories
{
    public interface IResutaurantRepository
    {
        Task<IEnumerable<Resturant>> GetAllAsync();
        Task<Resturant?> GetByIdAsync(int id);
    }
}
