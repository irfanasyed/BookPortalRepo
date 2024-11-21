using AutoMapper;
using Boo_Store_Portal_Api.Dto;
using Boo_Store_Portal_Api.Models;

namespace Boo_Store_Portal_Api.IServices.Services
{
    public class PubInfoServices : IPubInfoServices
    {
        private readonly BookStorePortalDbContext _context;
        private IMapper _mapper;

        public PubInfoServices(BookStorePortalDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponsePubInfoDto> UpdatePubInfoAsync(int id, UpdatePubInfoDto updatePubInfoDto)
        {
            var pubInfo = await _context.PubInfos.FindAsync(id);
            if (pubInfo == null)
                throw new KeyNotFoundException("Pub info not found");

            _mapper.Map(updatePubInfoDto, pubInfo);
            _context.PubInfos.Update(pubInfo);
            await _context.SaveChangesAsync();

            return _mapper.Map<ResponsePubInfoDto>(pubInfo);
        }
        public async Task<ResponsePubInfoDto> PatchPubInfoAsync(int id, PatchPubInfoDto patchPubInfoDto)
        {
            var pubInfo = await _context.PubInfos.FindAsync(id);
            if (pubInfo == null)
                throw new KeyNotFoundException("Pub info not found");

            _mapper.Map(patchPubInfoDto, pubInfo);
            _context.PubInfos.Update(pubInfo);
            await _context.SaveChangesAsync();

            return _mapper.Map<ResponsePubInfoDto>(pubInfo);
        }
    }
}
