using Boo_Store_Portal_Api.Dto;

namespace Boo_Store_Portal_Api.IServices
{
    public interface IStoreService
    {
        // Create a new store
        Task<string> CreateStore(CreateStoreDto createStoreDto);
        // Retrieve all stores
        Task<IEnumerable<ResponseStoreDto>> GetAllStore();
        // Retrieve stores by name
        Task<IEnumerable<ResponseStoreDto>> GetStoresByName(string StorName);
        // Retrieve stores by city
        Task<IEnumerable<ResponseStoreDto>> GetStoresByCity(string City);
        // Retrieve stores by zip code
        Task<IEnumerable<ResponseStoreDto>> GetStoresByZip(string Zip);
        // Retrieve a store by ID
        Task<ResponseStoreDto> GetStoreById(int StorId);
        // Partially update a store (PATCH)
        Task<ResponseStoreDto> PatchStore(int StorId, PatchStoreDto patchStoreDto);

        // Fully update a store (PUT)
        Task<ResponseStoreDto> UpdateStore(int StorId, UpdateStoreDto updateStoreDto);
    }
}
