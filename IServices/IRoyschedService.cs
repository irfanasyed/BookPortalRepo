using Boo_Store_Portal_Api.Dto;

namespace Boo_Store_Portal_Api.IServices
{
    public interface IRoyschedService
    {
        Task<ResponseRoyschedDto> CreateRoysched(CreateRoyschedDto createRoyschedDto);
        Task<List<ResponseRoyschedDto>> GetAllRoyscheds();
        Task<ResponseRoyschedDto> GetRoyschedById(int id);
        Task<ResponseRoyschedDto> UpdateRoysched(int id, UpdateRoyschedDto updateRoyschedDto);
        //Task<bool> DeleteRoysched(int id);
    }
}

