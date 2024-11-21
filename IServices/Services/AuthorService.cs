using AutoMapper;
using Boo_Store_Portal_Api.Dto;
using Boo_Store_Portal_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Boo_Store_Portal_Api.IServices.Services
{
    public class AuthorService:IAuthorService
    {
        private BookStorePortalDbContext _context;
        public IMapper _mapper;
        public AuthorService(BookStorePortalDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<string> CreateAuthor(CreateAuthorDto createAuthorDto)
        {
            Author author = _mapper.Map<Author>(createAuthorDto);
            _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            //_mapper.Map<ResponseAuthorDto>(author);
            return "Record Created Successfully";

            //throw new NotImplementedException();
        }

        public async Task<List<ResponseAuthorDto>> GetAllAuthor()
        {
            var author = await _context.Authors.ToListAsync();

            return _mapper.Map<List<ResponseAuthorDto>>(author);
            //throw new NotImplementedException();
        }

        public async Task<List<ResponseAuthorDto>> GetAuthorByCity(string city)
        {
            var author = await _context.Authors.Where(a => a.City == city).ToListAsync();
            if (author != null)
            {
                return _mapper.Map<List<ResponseAuthorDto>>(author);
            }
            throw new Exception($"city {city} is not found Exception");
            //throw new NotImplementedException();
        }

        public async Task<List<ResponseAuthorDto>> GetAuthorByFirstName(string firstName)
        {
            var author = await _context.Authors.Where(a => a.AuFname == firstName).ToListAsync();
            if (author != null)
            {
                return _mapper.Map<List<ResponseAuthorDto>>(author);
            }
            throw new Exception($"firstName {firstName} is not found Exception");
            //throw new NotImplementedException();
        }

        public async Task<List<ResponseAuthorDto>> GetAuthorByLastName(string lastName)
        {
            var author = await _context.Authors.Where(a => a.AuLname == lastName).ToListAsync();
            if (author != null)
            {
                return _mapper.Map<List<ResponseAuthorDto>>(author);
            }
            throw new Exception($"LastName {lastName} is not found Exception");
            //throw new NotImplementedException();
        }

        public async Task<List<ResponseAuthorDto>> GetAuthorByPhone(string phone)
        {
            var author = await _context.Authors.Where(a => a.Phone == phone).ToListAsync();
            if (author != null)
            {
                return _mapper.Map<List<ResponseAuthorDto>>(author);
            }
            throw new Exception($"Phone {phone} is not found Exception");
            //throw new NotImplementedException();
        }

        public async Task<List<ResponseAuthorDto>> GetAuthorByState(string state)
        {
            var author = await _context.Authors.Where(a => a.State == state).ToListAsync();
            if (author != null)
            {
                return _mapper.Map<List<ResponseAuthorDto>>(author);
            }
            throw new Exception($"state {state} is not found Exception");
            //throw new NotImplementedException();
        }

        public async Task<List<ResponseAuthorDto>> GetAuthorByZip(string zip)
        {
            var author = await _context.Authors.Where(a => a.Zip == zip).ToListAsync();
            if (author != null)
            {
                return _mapper.Map<List<ResponseAuthorDto>>(author);
            }
            throw new Exception($"zip {zip} is not found Exception");
            //throw new NotImplementedException();
        }

        public async Task<ResponseAuthorDto> PatchAuthorById(int id, PatchAuthorDto patchAuthorDto)
        {
            Author? author = await _context.Authors.FindAsync(id);
            if (author != null)
            {
                author.AuLname = patchAuthorDto.AuLname;
                author.AuFname = patchAuthorDto.AuFname;
                author.Phone = patchAuthorDto.Phone;
                author.City = patchAuthorDto.City;
                author.State = patchAuthorDto.State;
                author.Zip = patchAuthorDto.Zip;
                return _mapper.Map<ResponseAuthorDto>(author);

            }
            throw new Exception($"No Content 204");
            //throw new NotImplementedException();
        }

        public async Task<ResponseAuthorDto> UpdateAuthorById(int id, UpdateAuthorDto updateAuthorDto)
        {
            Author? author = await _context.Authors.FindAsync(id);
            if (author != null)
            {
                author.AuLname = updateAuthorDto.AuLname;
                author.AuFname = updateAuthorDto.AuFname;
                author.Phone = updateAuthorDto.Phone;
                author.City = updateAuthorDto.City;
                author.State = updateAuthorDto.State;
                author.Zip = updateAuthorDto.Zip;
                return _mapper.Map<ResponseAuthorDto>(author);

            }
            throw new Exception($"No Content 204");
            //throw new NotImplementedException();
        }
    }
}
