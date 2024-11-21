using Boo_Store_Portal_Api.Dto;

namespace Boo_Store_Portal_Api.IServices
{
    public interface IEmployeeSevice
    {
        Task<IEnumerable<ResponseEmployeeDto>> GetAllEmployeesAsync();
        Task<ResponseEmployeeDto> GetEmployeeByIdAsync(int id);
        Task<IEnumerable<ResponseEmployeeDto>> GetEmployeeByPubIdAsync(int pubId);
        Task<IEnumerable<ResponseEmployeeDto>> GetEmployeeByFnameAsync(string fname);
        Task<IEnumerable<ResponseEmployeeDto>> GetEmployeeByLnameAsync(string lname);
        Task<IEnumerable<ResponseEmployeeDto>> GetEmployeeByHireDateAsync(DateTime hiredate);
        Task<string> CreateEmployeeAsync(CreateEmployeeDto employeeDto);
        Task<bool> UpdateEmployeeAsync(int id, UpdateEmployeeDto employeeDto);
        Task<bool> PatchEmployeeAsync(int id, PatchEmployeeDto employeeDto);
    }
}
