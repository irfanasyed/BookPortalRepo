using AutoMapper;
using Boo_Store_Portal_Api.Dto;
using Boo_Store_Portal_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Boo_Store_Portal_Api.IServices.Services
{
    public class TitleService : ITitleService
    {
        private readonly BookStorePortalDbContext _context;
        private readonly IMapper _mapper;

        public TitleService(BookStorePortalDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // AddTitleAsync that returns ResponseTitleDto
        public async Task<ResponseTitleDto> AddTitleAsync(CreateTitleDto createTitleDto)
        {
            if (createTitleDto == null) throw new ArgumentNullException(nameof(createTitleDto));

            var title = _mapper.Map<Title>(createTitleDto);
            await _context.Titles.AddAsync(title);
            await _context.SaveChangesAsync();

            return _mapper.Map<ResponseTitleDto>(title);
        }

        // AddTitleAndReturnIdAsync that returns the Title ID as a string
        public async Task<string> AddTitleAndReturnIdAsync(CreateTitleDto createTitleDto)
        {
            if (createTitleDto == null) throw new ArgumentNullException(nameof(createTitleDto));

            var title = _mapper.Map<Title>(createTitleDto);
            await _context.Titles.AddAsync(title);
            await _context.SaveChangesAsync();

            return title.TitleId.ToString();  // Return the title ID or a success message
        }

        public async Task<List<ResponseTitleDto>> GetAllTitlesAsync()
        {
            var titles = await _context.Titles.ToListAsync();
            return _mapper.Map<List<ResponseTitleDto>>(titles);
        }

        public async Task<ResponseTitleDto> GetTitleByIdAsync(int id)
        {
            var title = await _context.Titles.FindAsync(id);
            if (title == null)
                throw new KeyNotFoundException($"Title with ID {id} not found.");

            return _mapper.Map<ResponseTitleDto>(title);
        }

        public async Task<List<ResponseTitleDto>> SearchTitlesByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Search name cannot be null or empty.", nameof(name));

            var titles = await _context.Titles
                .Where(t => EF.Functions.Like(t.Title1.ToLower(), $"%{name.ToLower()}%"))
                .ToListAsync();

            return _mapper.Map<List<ResponseTitleDto>>(titles);
        }

        public async Task<ResponseTitleDto> UpdateTitleAsync(int id, UpdateTitleDto updateTitleDto)
        {
            var title = await _context.Titles.FindAsync(id);
            if (title == null)
                throw new KeyNotFoundException($"Title with ID {id} not found.");

            _mapper.Map(updateTitleDto, title);
            _context.Titles.Update(title);
            await _context.SaveChangesAsync();

            return _mapper.Map<ResponseTitleDto>(title);
        }

        public async Task<bool> DeleteTitleAsync(int id)
        {
            var title = await _context.Titles.FindAsync(id);
            if (title == null)
                throw new KeyNotFoundException($"Title with ID {id} not found.");

            _context.Titles.Remove(title);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<ResponseTitleDto>> GetTitlesByTypeAsync(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentException("Type cannot be null or empty.", nameof(type));

            var titles = await _context.Titles
                .Where(t => t.Type.Equals(type, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();

            return _mapper.Map<List<ResponseTitleDto>>(titles);
        }

        public async Task<ResponseTitleDto> PatchTitleAsync(int id, PatchTitleDto patchTitleDto)
        {
            var title = await _context.Titles.FindAsync(id);
            if (title == null)
                throw new KeyNotFoundException($"Title with ID {id} not found.");

            if (!string.IsNullOrEmpty(patchTitleDto.Title1))
                title.Title1 = patchTitleDto.Title1;

            if (!string.IsNullOrEmpty(patchTitleDto.Notes))
                title.Notes = patchTitleDto.Notes;

            _context.Titles.Update(title);
            await _context.SaveChangesAsync();

            return _mapper.Map<ResponseTitleDto>(title);
        }
    }
}
