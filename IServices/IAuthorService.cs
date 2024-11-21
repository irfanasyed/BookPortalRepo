using Boo_Store_Portal_Api.Dto;

namespace Boo_Store_Portal_Api.IServices
{
    public interface IAuthorService
    {
        Task<string> CreateAuthor(CreateAuthorDto createAuthorDto);
        Task<List<ResponseAuthorDto>> GetAllAuthor();
        Task<List<ResponseAuthorDto>> GetAuthorByLastName(string lastName);
        Task<List<ResponseAuthorDto>> GetAuthorByFirstName(string firstName);
        Task<List<ResponseAuthorDto>> GetAuthorByPhone(string phone);
        Task<List<ResponseAuthorDto>> GetAuthorByZip(string zip);
        Task<List<ResponseAuthorDto>> GetAuthorByState(string state);
        Task<List<ResponseAuthorDto>> GetAuthorByCity(string city);


        Task<ResponseAuthorDto> PatchAuthorById(int id, PatchAuthorDto patchAuthorDto);
        Task<ResponseAuthorDto> UpdateAuthorById(int id, UpdateAuthorDto updateAuthorDto);
    }
}
