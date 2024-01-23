using Data.Context;
using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public interface ICompanyDal
    {
        Task<Company> Create(Company company);
        Task<Company> Update(Company company);
        Task<Company> Delete(int id);
        Task<Company> Get(int id);
        Task<List<Company>> GetAll();
    }
    public class CompanyDal : ICompanyDal
    {
        private readonly ApplicationContext _applicationContext;

        public CompanyDal(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<Company> Create(Company company)
        {
            try
            {
                var result = await _applicationContext.Companies.AddAsync(company);
                var res = await _applicationContext.SaveChangesAsync();
                if (res > 0)
                {
                    return company;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Company> Delete(int id)
        {
            try
            {
                var company = await _applicationContext.Companies.Where(x => x.ID == id).FirstOrDefaultAsync();
                if (company != null)
                {
                    company.IsActive = false;
                    var result = await _applicationContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        return company;
                    }
                    return null;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Company> Get(int id)
        {
            try
            {
                var company = await _applicationContext.Companies.Where(x => x.ID == id).FirstAsync();
                return company;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<Company>> GetAll()
        {
            try
            {
                return await _applicationContext.Companies.ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Company> Update(Company company)
        {
            try
            {
                var res = _applicationContext.Companies.Update(company);
                var result = await _applicationContext.SaveChangesAsync();
                if (result > 0)
                {
                    return company;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
