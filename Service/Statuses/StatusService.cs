using DAL;
using Data.Model;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Results;

namespace Service.Statuses
{
    public interface IStatusService
    {
        Task<IDataResult<Status>> Create(Status status);
        Task<IDataResult<Status>> Update(Status status);
        Task<IDataResult<Status>> Delete(int id);
        Task<IDataResult<Status>> Get(int id);
        Task<IDataResult<List<Status>>> GetAll();
    }
    public class StatusService : IStatusService
    {
        private readonly IStatusDal _statusDal;

        public StatusService(IStatusDal statusDal)
        {
            _statusDal = statusDal;
        }

        public async Task<IDataResult<Status>> Create(Status status)
        {
            try
            {
                var res = await _statusDal.Create(status);
                if (res != null)
                {
                    return new SuccessDataResult<Status>(res);
                }
                return new ErrorDataResult<Status>("Status create failed.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Status>(ex.Message);
            }
        }

        public async Task<IDataResult<Status>> Delete(int id)
        {
            try
            {
                var res = await _statusDal.Delete(id);
                if (res != null)
                {
                    return new SuccessDataResult<Status>(res);
                }
                return new ErrorDataResult<Status>("Status delete failed.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Status>(ex.Message);
            }
        }

        public async Task<IDataResult<Status>> Get(int id)
        {
            try
            {
                var res = await _statusDal.Get(id);
                return new SuccessDataResult<Status>(res);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Status>(ex.Message);
            }
        }

        public async Task<IDataResult<List<Status>>> GetAll()
        {
            try
            {
                var res = await _statusDal.GetAll();
                return new SuccessDataResult<List<Status>>(res);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Status>>(ex.Message);
            }
        }

        public async Task<IDataResult<Status>> Update(Status status)
        {
            try
            {
                var res = await _statusDal.Update(status);
                if (res != null)
                {
                    return new SuccessDataResult<Status>(res);
                }
                return new ErrorDataResult<Status>("Status update failed.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Status>(ex.Message);
            }
        }
    }
}
