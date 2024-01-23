using DAL;
using Data.Model;
using Utilities.Results;

namespace Service.Companies
{
    public interface ICompanyService
    {
        Task<IDataResult<Company>> Create(Company company);
        Task<IDataResult<Company>> Update(Company company);
        Task<IDataResult<Company>> Delete(int id);
        Task<IDataResult<Company>> Get(int id);
        Task<IDataResult<List<Company>>> GetAll();
    }
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyDal _companyDal;

        public CompanyService(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        public async Task<IDataResult<Company>> Create(Company company)
        {
            try
            {
                var res = await _companyDal.Create(company);
                if (res != null)
                {
                    return new SuccessDataResult<Company>(res);
                }
                return new ErrorDataResult<Company>("Company create failed.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Company>(ex.Message);
            }
        }

        public async Task<IDataResult<Company>> Delete(int id)
        {
            try
            {
                var res = await _companyDal.Delete(id);
                if (res != null)
                {
                    return new SuccessDataResult<Company>(res);
                }
                return new ErrorDataResult<Company>("Company delete failed.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Company>(ex.Message);
            }
        }

        public async Task<IDataResult<Company>> Get(int id)
        {
            try
            {
                var res = await _companyDal.Get(id);
                if (res != null)
                {
                    return new SuccessDataResult<Company>(res);
                }
                return new SuccessDataResult<Company>(res, "Company not found.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Company>(ex.Message);
            }
        }

        public async Task<IDataResult<List<Company>>> GetAll()
        {
            try
            {
                var res = await _companyDal.GetAll();
                if (res != null)
                {
                    return new SuccessDataResult<List<Company>>(res);
                }
                return new SuccessDataResult<List<Company>>(res, "Companies not found.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Company>>(ex.Message);
            }
        }

        public async Task<IDataResult<Company>> Update(Company company)
        {
            try
            {
                var res = await _companyDal.Update(company);
                if (res != null)
                {
                    return new SuccessDataResult<Company>(res);
                }
                return new ErrorDataResult<Company>("Company update failed.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Company>(ex.Message);
            }
        }
    }
}
