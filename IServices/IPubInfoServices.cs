using Boo_Store_Portal_Api.Dto;

namespace Boo_Store_Portal_Api.IServices
{
    public interface IPubInfoServices
    {
        Task<ResponsePubInfoDto> UpdatePubInfoAsync(int id, UpdatePubInfoDto updatePubInfoDto);
        Task<ResponsePubInfoDto> PatchPubInfoAsync(int id, PatchPubInfoDto patchPubInfoDto);
    }
}
