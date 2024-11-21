using AutoMapper;
using Boo_Store_Portal_Api.Dto;
using Boo_Store_Portal_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Boo_Store_Portal_Api.IServices.Services
{

    public class JobService : IJobService
    {
        private readonly BookStorePortalDbContext _context;
        private readonly IMapper _mapper;
        public JobService(BookStorePortalDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResponseJobDto>> GetAllJobsAsync()
        {
            var jobs = await _context.Jobs.ToListAsync();
            return _mapper.Map<IEnumerable<ResponseJobDto>>(jobs);
            //throw new NotImplementedException();
        }

        public async Task<ResponseJobDto> GetJobsByIdAsync(int id)
        {
            var job = await _context.Jobs.FindAsync(id);
            return _mapper.Map<ResponseJobDto>(job);
            //throw new NotImplementedException();
        }
        public async Task<IEnumerable<ResponseJobDto>> GetJobsByMinLvlAsync(string minLvl)
        {
            var job = await _context.Jobs.Where(e => e.MinLvl == minLvl).ToListAsync();
            return _mapper.Map<IEnumerable<ResponseJobDto>>(job);
            //throw new NotImplementedException();
        }
        public async Task<IEnumerable<ResponseJobDto>> GetJobsByMaxLvlAsync(string maxLvl)
        {
            var job = await _context.Jobs.Where(e => e.MaxLvl == maxLvl).ToListAsync();
            return _mapper.Map<IEnumerable<ResponseJobDto>>(job);
            //throw new NotImplementedException();
        }
        public async Task<string> CreateJobAsync(CreateJobDto createJobDto)
        {
            var jobs = _mapper.Map<Job>(createJobDto);
            _context.Jobs.Add(jobs);
            await _context.SaveChangesAsync();
            return "Record Created Succesfully";
            //throw new NotImplementedException();
        }

    }
}
