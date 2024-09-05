using BEERCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace BEERCRUD.Repository
{
    public class BeerRepository : IRepository<Beer>
    {
        private StoreContext _storeContext;

        public BeerRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task<IEnumerable<Beer>> Get() => await _storeContext.Beers.ToListAsync();

        public void Delete(Beer entity)
        {
            throw new NotImplementedException();
        }
        public Task<Beer> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Beer entity)
        {
            throw new NotImplementedException();
        }
    }
}
