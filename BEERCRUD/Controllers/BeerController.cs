using BEERCRUD.DTOs;
using BEERCRUD.Models;
using BEERCRUD.Services;
using Microsoft.AspNetCore.Mvc;

namespace BEERCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        // Inyectar dependencias
        private StoreContext _storeContext;
        private ICommonService<BeerDto, BeertInsertDto, BeerUpdateDto> _beerService;
        public BeerController(
            StoreContext storeContext,
            [FromKeyedServices("beerService")] ICommonService<BeerDto, BeertInsertDto, BeerUpdateDto> beerService)
        {
            _storeContext = storeContext;
            _beerService = beerService;
        }

        [HttpGet]
        public async Task<IEnumerable<BeerDto>> Get()
        {
            return await _beerService.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BeerDto>> GetById(int number)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult<BeertInsertDto>> Add(BeertInsertDto beertInsertDto)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BeerUpdateDto>> Update(int Id, BeerUpdateDto beerUpdateDto)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
