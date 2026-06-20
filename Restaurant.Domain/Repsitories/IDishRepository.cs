using Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Repsitories
{
    public interface IDishRepository
    {
        Task<int> Create(Dish dish);
        Task Delete(IEnumerable<Dish> entities);
    }
}
