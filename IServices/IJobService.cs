using Boo_Store_Portal_Api.Dto;

namespace Boo_Store_Portal_Api.IServices
{
    public interface IJobService
    {
        Task<IEnumerable<ResponseJobDto>> GetAllJobsAsync();
        Task<ResponseJobDto> GetJobsByIdAsync(int id);
        Task<IEnumerable<ResponseJobDto>> GetJobsByMinLvlAsync(string minLvl);
        Task<IEnumerable<ResponseJobDto>> GetJobsByMaxLvlAsync(string maxLvl);
        Task<string> CreateJobAsync(CreateJobDto createJobDto);
    }
}
