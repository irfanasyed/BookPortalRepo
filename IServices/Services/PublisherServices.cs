using AutoMapper;
using Boo_Store_Portal_Api.Dto;
using Boo_Store_Portal_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Boo_Store_Portal_Api.IServices.Services
{
    public class PublisherServices : IPublisherServices
    {
        private readonly BookStorePortalDbContext _context;
        private readonly IMapper _mapper;

        public PublisherServices(BookStorePortalDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddPublisherAsync(CreatePublisherDto createPublisherDto)
        {
            var publisher = _mapper.Map<Publisher>(createPublisherDto);
            _context.Publishers.Add(publisher);
            await _context.SaveChangesAsync();
            return "Publisher created successfully";
        }

        public async Task<IEnumerable<ResponsePublisherDto>> GetAllPublisherAsync()
        {
            var publishers = await _context.Publishers.ToListAsync();
            return _mapper.Map<IEnumerable<ResponsePublisherDto>>(publishers);
        }

        public async Task<IEnumerable<ResponsePublisherDto>> GetPublisherByNameAsync(string name)
        {
            var publishers = await _context.Publishers
                .Where(p => p.PubName.Contains(name))
                .ToListAsync();
            return _mapper.Map<IEnumerable<ResponsePublisherDto>>(publishers);
        }

        public async Task<IEnumerable<ResponsePublisherDto>> GetPublisherByCityAsync(string city)
        {
            var publishers = await _context.Publishers
                .Where(p => p.City.Contains(city))
                .ToListAsync();
            return _mapper.Map<IEnumerable<ResponsePublisherDto>>(publishers);
        }

        public async Task<IEnumerable<ResponsePublisherDto>> GetPublisherByStateAsync(string state)
        {
            var publishers = await _context.Publishers
                .Where(p => p.State.Contains(state))
                .ToListAsync();
            return _mapper.Map<IEnumerable<ResponsePublisherDto>>(publishers);
        }

        public async Task<IEnumerable<ResponsePublisherDto>> GetPublisherByCountryAsync(string country)
        {
            var publishers = await _context.Publishers
                .Where(p => p.Country.Contains(country))
                .ToListAsync();
            return _mapper.Map<IEnumerable<ResponsePublisherDto>>(publishers);
        }

        public async Task<Publisher> UpdatePublisherAsync(int id, UpdatePublisherDto updatePublisherDto)
        {
            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher == null) throw new KeyNotFoundException("Publisher not found");

            _mapper.Map(updatePublisherDto, publisher);
            _context.Publishers.Update(publisher);
            await _context.SaveChangesAsync();

            return publisher;
        }

        public async Task<Publisher> PatchPublisherAsync(int id, PatchPublisherDto patchPublisherDto)
        {
            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher == null) throw new KeyNotFoundException("Publisher not found");

            _mapper.Map(patchPublisherDto, publisher);
            _context.Publishers.Update(publisher);
            await _context.SaveChangesAsync();

            return publisher;
        }
    }
}

