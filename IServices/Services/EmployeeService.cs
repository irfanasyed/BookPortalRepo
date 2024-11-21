using AutoMapper;
using Boo_Store_Portal_Api.Dto;
using Boo_Store_Portal_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Boo_Store_Portal_Api.IServices.Services
{
    public class EmployeeService : IEmployeeSevice
    {
        private readonly BookStorePortalDbContext _context;
        private readonly IMapper _mapper;
        public EmployeeService(BookStorePortalDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ResponseEmployeeDto>> GetAllEmployeesAsync()
        {
            var employees = await _context.Employees.ToListAsync();
            return _mapper.Map<IEnumerable<ResponseEmployeeDto>>(employees);
            //throw new NotImplementedException();
        }
        public async Task<ResponseEmployeeDto> GetEmployeeByIdAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return _mapper.Map<ResponseEmployeeDto>(employee);
            // throw new NotImplementedException();
        }
        public async Task<IEnumerable<ResponseEmployeeDto>> GetEmployeeByPubIdAsync(int pubId)
        {
            var employees = await _context.Employees.Where(e => e.PubId == pubId).ToListAsync();
            return _mapper.Map<IEnumerable<ResponseEmployeeDto>>(employees);
            // throw new NotImplementedException();
        }
        public async Task<IEnumerable<ResponseEmployeeDto>> GetEmployeeByFnameAsync(string fname)
        {
            var employees = await _context.Employees.Where(e => e.Fname.Contains(fname)).ToListAsync();
            return _mapper.Map<IEnumerable<ResponseEmployeeDto>>(employees);
            //throw new NotImplementedException();
        }
        public async Task<IEnumerable<ResponseEmployeeDto>> GetEmployeeByLnameAsync(string lname)
        {
            var employees = await _context.Employees.Where(e => e.Lname.Contains(lname)).ToListAsync();
            return _mapper.Map<IEnumerable<ResponseEmployeeDto>>(employees);
            //throw new NotImplementedException();
        }
        public async Task<IEnumerable<ResponseEmployeeDto>> GetEmployeeByHireDateAsync(DateTime hiredate)
        {
            var employee = await _context.Employees.Where(e => e.HireDate == hiredate).ToListAsync();
            return _mapper.Map<IEnumerable<ResponseEmployeeDto>>(employee);
            //throw new NotImplementedException();
        }

        public async Task<string> CreateEmployeeAsync(CreateEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return "Record Created Succesfully";
            //throw new NotImplementedException();
        }

        public async Task<bool> UpdateEmployeeAsync(int id, UpdateEmployeeDto employeeDto)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return false;
            _mapper.Map(employeeDto, employee);
            await _context.SaveChangesAsync();
            return true;
            // throw new NotImplementedException();
        }
        public async Task<bool> PatchEmployeeAsync(int id, PatchEmployeeDto employeeDto)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return false;
            _mapper.Map(employeeDto, employee);
            await _context.SaveChangesAsync();
            return true;
            //throw new NotImplementedException();
        }
    }
}
