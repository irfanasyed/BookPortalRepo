using Boo_Store_Portal_Api.Dto;
using Boo_Store_Portal_Api.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Boo_Store_Portal_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateSale([FromBody] CreateSaleDto createSaleDto)
        {
            if (createSaleDto == null)
            {
                return BadRequest("Sale data is required.");
            }

            var result = await _saleService.CreateSale(createSaleDto);
            return Ok(result);  // Return 200 OK with success message
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSales()
        {
            var sales = await _saleService.GetAllSales();
            return Ok(sales);  // Return 200 OK with the list of sales
        }
        [HttpGet("id/{OrdNum}")]
        public async Task<IActionResult> GetSaleById(int OrdNum)
        {
            try
            {
                var sale = await _saleService.GetSaleByOrderNumber(OrdNum);
                return Ok(sale);  // Return 200 OK with the sale details
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });  // Return 404 if sale is not found
            }
        }
        [HttpGet("orderdate/{OrdDate}")]
        public async Task<IActionResult> GetSalesByOrderDate(DateTime OrdDate)
        {
            try
            {
                var sale = await _saleService.GetSalesByOrderDate(OrdDate);
                return Ok(sale);  // Return 200 OK with the sale details
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });  // Return 404 if sale is not found
            }
        }
        [HttpGet("store/{StorId}")]
        public async Task<IActionResult> GetSalesByStoreId(int StorId)
        {
            try
            {
                var sale = await _saleService.GetSalesByStoreId(StorId);
                return Ok(sale);  // Return 200 OK with the sale details
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });  // Return 404 if sale is not found
            }
        }
        [HttpGet("title/{TitleId}")]
        public async Task<IActionResult> GetSalesByTitleId(int TitleId)
        {
            try
            {
                var sale = await _saleService.GetSalesByTitleId(TitleId);
                return Ok(sale);  // Return 200 OK with the sale details
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });  // Return 404 if sale is not found
            }
        }

    }
}
