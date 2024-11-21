using Boo_Store_Portal_Api.Dto;

namespace Boo_Store_Portal_Api.IServices
{
    public interface ISaleService
    {
        // Create a new sale
        Task<string> CreateSale(CreateSaleDto createSaleDto);
        // Retrieve all sales
        Task<IEnumerable<ResponseSaleDto>> GetAllSales();
        //Retrieve Sale by ordernumber
        Task<ResponseSaleDto?> GetSaleByOrderNumber(int OrdNum);
        //Retrieve sale by Titleid 
        Task<IEnumerable<ResponseSaleDto?>> GetSalesByTitleId(int TitleId);
        //Retrieve sale by orderdate
        Task<IEnumerable<ResponseSaleDto?>> GetSalesByOrderDate(DateTime OrdDate);
        //Retrieve sale by storeid
        Task<IEnumerable<ResponseSaleDto?>> GetSalesByStoreId(int StorId);
    }
}
