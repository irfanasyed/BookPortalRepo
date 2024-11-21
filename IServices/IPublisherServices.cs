using Boo_Store_Portal_Api.Dto;
using Boo_Store_Portal_Api.Models;

namespace Boo_Store_Portal_Api.IServices
{
    public interface IPublisherServices
    {
        Task<string> AddPublisherAsync(CreatePublisherDto createPublisherDto);
        Task<IEnumerable<ResponsePublisherDto>> GetAllPublisherAsync();
        Task<IEnumerable<ResponsePublisherDto>> GetPublisherByNameAsync(string name);
        Task<IEnumerable<ResponsePublisherDto>> GetPublisherByCityAsync(string city);
        Task<IEnumerable<ResponsePublisherDto>> GetPublisherByStateAsync(string state);
        Task<IEnumerable<ResponsePublisherDto>> GetPublisherByCountryAsync(string country);
        Task<Publisher> UpdatePublisherAsync(int id, UpdatePublisherDto updatePublisherDto);
        Task<Publisher> PatchPublisherAsync(int id, PatchPublisherDto patchPublisherDto);
    }
}
