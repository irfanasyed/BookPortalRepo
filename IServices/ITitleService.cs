using Boo_Store_Portal_Api.Dto;

namespace Boo_Store_Portal_Api.IServices
{
    public interface ITitleService
    {
        Task<ResponseTitleDto> AddTitleAsync(CreateTitleDto createTitleDto);
        Task<List<ResponseTitleDto>> GetAllTitlesAsync();
        Task<ResponseTitleDto> GetTitleByIdAsync(int id);
        Task<ResponseTitleDto> UpdateTitleAsync(int id, UpdateTitleDto updateTitleDto);
        Task<bool> DeleteTitleAsync(int id);
        Task<List<ResponseTitleDto>> SearchTitlesByNameAsync(string name);
        
        Task<ResponseTitleDto> PatchTitleAsync(int id, PatchTitleDto patchTitleDto);
        //Task<string> AddTitleAsync(CreateTitleDto createTitleDto);
    }
}
