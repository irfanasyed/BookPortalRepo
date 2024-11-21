using AutoMapper;
using Boo_Store_Portal_Api.Dto;
using Boo_Store_Portal_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Boo_Store_Portal_Api.IServices.Services
{
    public class StoreService : IStoreService
    {
        private readonly BookStorePortalDbContext _context;
        private readonly IMapper _mapper;
        public StoreService(BookStorePortalDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // Create a new store
        public async Task<string> CreateStore(CreateStoreDto createStoreDto)
        {
            var store = _mapper.Map<Store>(createStoreDto);
            _context.Stores.AddAsync(store);
            await _context.SaveChangesAsync();
            return "Record Created Successfully";

        }
        // Get all stores
        public async Task<IEnumerable<ResponseStoreDto>> GetAllStore()
        {
            var stores = await _context.Stores.ToListAsync();
            return _mapper.Map<IEnumerable<ResponseStoreDto>>(stores);
        }
        // Retrieve stores by Id
        public async Task<ResponseStoreDto> GetStoreById(int StorId)
        {
            var store = await _context.Stores.FindAsync(StorId);
            if (store != null)
            {
                return _mapper.Map<ResponseStoreDto>(store);
            }
            throw new Exception($"Id {StorId} is not found");
        }
        // Retrieve stores by city
        public async Task<IEnumerable<ResponseStoreDto>> GetStoresByCity(string City)
        {
            var stores = await _context.Stores
           .Where(p => p.City.Contains(City))
           .ToListAsync();
            return _mapper.Map<IEnumerable<ResponseStoreDto>>(stores);

        }
        // Retrieve stores by name
        public async Task<IEnumerable<ResponseStoreDto>> GetStoresByName(string StorName)
        {
            var stores = await _context.Stores
           .Where(p => p.StorName.Contains(StorName))
           .ToListAsync();
            return _mapper.Map<IEnumerable<ResponseStoreDto>>(stores);
        }
        // Retrieve stores by zip code
        public async Task<IEnumerable<ResponseStoreDto>> GetStoresByZip(string Zip)
        {
            var stores = await _context.Stores
           .Where(p => p.Zip.Contains(Zip))
           .ToListAsync();
            return _mapper.Map<IEnumerable<ResponseStoreDto>>(stores);

        }
        // Partially update a store (PATCH)
        public async Task<ResponseStoreDto> PatchStore(int StorId, PatchStoreDto patchStoreDto)
        {
            var store = await _context.Stores.FindAsync(StorId);
            if (store != null)
            {
                store.StorName = patchStoreDto.StorName;
                store.StorAddress = patchStoreDto.StorAddress;
                store.Zip = patchStoreDto.Zip;
                store.City = patchStoreDto.City;
                store.State = patchStoreDto.State;

                _context.Stores.Update(store);
                await _context.SaveChangesAsync();
                return _mapper.Map<ResponseStoreDto>(store);

            }
            throw new Exception($"Id {StorId} is not found");

        }
        // Fully update a store (PUT)
        public async Task<ResponseStoreDto> UpdateStore(int StorId, UpdateStoreDto updateStoreDto)
        {
            var store = await _context.Stores.FindAsync(StorId);
            if (store != null)
            {
                store.StorName = updateStoreDto.StorName;
                store.StorAddress = updateStoreDto.StorAddress;
                store.Zip = updateStoreDto.Zip;
                store.City = updateStoreDto.City;
                store.State = updateStoreDto.State;

                _context.Stores.Update(store);
                await _context.SaveChangesAsync();
                return _mapper.Map<ResponseStoreDto>(store);
            }
            throw new Exception($"Id {StorId} is not found");


        }
    }
}
