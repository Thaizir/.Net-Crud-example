namespace BEERCRUD.Services
{
    public interface ICommonService<T, TI, TU>
    {
        public Task<IEnumerable<T>> Get();
        public Task<T> Get(int id);
        public Task<T> Add(TI TI);
        public Task<T> Update(int id, TU beerUpdateDto);
        public Task<T> Delete(int id);

    }
}
