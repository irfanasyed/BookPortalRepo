using AutoMapper;
using Boo_Store_Portal_Api.Dto;
using Boo_Store_Portal_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Boo_Store_Portal_Api.IServices.Services
{
    public class SaleService : ISaleService
    {
        private readonly BookStorePortalDbContext _context;
        private readonly IMapper _mapper;
        public SaleService(BookStorePortalDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<string> CreateSale(CreateSaleDto createSaleDto)
        {
            Sale sale = _mapper.Map<Sale>(createSaleDto);
            _context.Sales.AddAsync(sale);
            await _context.SaveChangesAsync();
            return "Record Created Successfully";
        }

        public async Task<IEnumerable<ResponseSaleDto>> GetAllSales()
        {
            var sales = await _context.Stores.ToListAsync();
            return _mapper.Map<IEnumerable<ResponseSaleDto>>(sales);
        }

        public async Task<ResponseSaleDto?> GetSaleByOrderNumber(int OrdNum)
        {
            var sale = await _context.Sales.FirstOrDefaultAsync(s => s.OrdNum == OrdNum);
            if (sale != null)
            {
                return _mapper.Map<ResponseSaleDto>(sale);
            }
            throw new Exception($"OrderNumber {OrdNum} is not found");

        }

        public async Task<IEnumerable<ResponseSaleDto?>> GetSalesByOrderDate(DateTime OrdDate)
        {
            var sales = await _context.Sales.Where(p => EF.Functions.DateDiffDay(p.OrdDate, OrdDate) == 0).ToListAsync();

            return _mapper.Map<IEnumerable<ResponseSaleDto>>(sales);
        }

        public async Task<IEnumerable<ResponseSaleDto?>> GetSalesByStoreId(int StorId)
        {
            var sales = await _context.Sales.Where(p => p.StorId == StorId).ToListAsync();
            return _mapper.Map<IEnumerable<ResponseSaleDto>>(sales);
        }

        public async Task<IEnumerable<ResponseSaleDto?>> GetSalesByTitleId(int TitleId)
        {
            var sales = await _context.Sales.Where(p => p.TitleId == TitleId).ToListAsync();
            return _mapper.Map<IEnumerable<ResponseSaleDto>>(sales);
        }
    }
}
