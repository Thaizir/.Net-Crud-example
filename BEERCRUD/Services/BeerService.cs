using BEERCRUD.DTOs;
using BEERCRUD.Models;
using BEERCRUD.Repository;

namespace BEERCRUD.Services
{
    public class BeerService : ICommonService<BeerDto, BeertInsertDto, BeerUpdateDto>
    {
        private StoreContext _storeContext;
        private IRepository<Beer> _beerRepository;
        public BeerService(
            StoreContext storeContext,
            IRepository<Beer> beerRepository)
        {
            _storeContext = storeContext;
            _beerRepository = beerRepository;
        }
        public async Task<IEnumerable<BeerDto>> Get()
        {
            var beers = await _beerRepository.Get();
            return beers.Select(b => new BeerDto
            {
                Id = b.Id,
                Name = b.Name,
                BrandId = b.BrandId,
                Alcohol = b.Alcohol,
            });
        }

        public Task<BeerDto> Add(BeertInsertDto beertInsertDto)
        {
            throw new NotImplementedException();
        }

        public Task<BeerDto> Delete(int id)
        {
            throw new NotImplementedException();
        }
        public Task<BeerDto> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BeerDto> Update(int id, BeerUpdateDto beerUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
