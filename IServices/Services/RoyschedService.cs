using AutoMapper;
using Boo_Store_Portal_Api.Dto;
using Boo_Store_Portal_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Boo_Store_Portal_Api.IServices.Services
{
    public class RoyschedService:IRoyschedService
    {
        private readonly BookStorePortalDbContext _context;
        private readonly IMapper _mapper;

        public RoyschedService(BookStorePortalDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //public async Task<ResponseRoyschedDto> CreateRoysched(CreateRoyschedDto createRoyschedDto)
        //{
        //    Roysched roysched = _mapper.Map<Roysched>(createRoyschedDto);


        //    _context.Royscheds.Add(roysched);
        //    await _context.SaveChangesAsync();

        //    return _mapper.Map<ResponseRoyschedDto>(roysched);
        //}

        //public async Task<ResponseRoyschedDto> CreateRoysched(CreateRoyschedDto createRoyschedDto)
        //{
        //    var existingRoysched = await _context.Royscheds
        //        .FirstOrDefaultAsync(r => r.Lorange == createRoyschedDto.LowRange && r.Hirange == createRoyschedDto.HighRange);

        //    if (existingRoysched != null)
        //        throw new InvalidOperationException("A roysched with the same range already exists.");

        //    Roysched roysched = _mapper.Map<Roysched>(createRoyschedDto);
        //    _context.Royscheds.Add(roysched);
        //    await _context.SaveChangesAsync();

        //    return _mapper.Map<ResponseRoyschedDto>(roysched);
        //}
        public async Task<ResponseRoyschedDto> CreateRoysched(CreateRoyschedDto createRoyschedDto)
        {
            // Ensure TitleId exists in the Title table before creating the Roysched
            var title = await _context.Titles.FindAsync(createRoyschedDto.TitleId);
            if (title == null)
            {
                throw new Exception("Title not found.");
            }

            // Map the CreateRoyschedDto to the Roysched entity
            var roysched = _mapper.Map<Roysched>(createRoyschedDto);

            // Add the entity to the context and save
            _context.Royscheds.Add(roysched);
            await _context.SaveChangesAsync();

            // Return the mapped response DTO
            return _mapper.Map<ResponseRoyschedDto>(roysched);
        }

        public async Task<List<ResponseRoyschedDto>> GetAllRoyscheds()
        {
            var royscheds = await _context.Royscheds.ToListAsync();
            return _mapper.Map<List<ResponseRoyschedDto>>(royscheds);
        }

        public async Task<ResponseRoyschedDto> GetRoyschedById(int id)
        {
            var roysched = await _context.Royscheds.FindAsync(id);
            if (roysched == null)
                throw new KeyNotFoundException($"Roysched with ID {id} not found.");

            return _mapper.Map<ResponseRoyschedDto>(roysched);
        }

        public async Task<ResponseRoyschedDto> UpdateRoysched(int id, UpdateRoyschedDto updateRoyschedDto)
        {
            var roysched = await _context.Royscheds.FindAsync(id);
            if (roysched == null)
                throw new KeyNotFoundException($"Roysched with ID {id} not found.");

            //if (updateRoyschedDto.TitleId.HasValue)
            //    roysched.TitleId = updateRoyschedDto.TitleId;

            if (updateRoyschedDto.LowRange.HasValue)
                roysched.Lorange = updateRoyschedDto.LowRange;

            if (updateRoyschedDto.HighRange.HasValue)
                roysched.Hirange = updateRoyschedDto.HighRange;

            if (updateRoyschedDto.Royalty.HasValue)
                roysched.Royalty = updateRoyschedDto.Royalty;

            await _context.SaveChangesAsync();

            return _mapper.Map<ResponseRoyschedDto>(roysched);
        }

        //public async Task<bool> DeleteRoysched(int id)
        //{
        //    var roysched = await _context.Royscheds.FindAsync(id);
        //    if (roysched == null)
        //        throw new KeyNotFoundException($"Roysched with ID {id} not found.");

        //    _context.Royscheds.Remove(roysched);
        //    await _context.SaveChangesAsync();

        //    return true;
        //}
    }
}

