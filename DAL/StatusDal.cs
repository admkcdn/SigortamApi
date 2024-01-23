using Data.Context;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IStatusDal
    {
        Task<Status> Create(Status status);
        Task<Status> Update(Status status);
        Task<Status> Delete(int id);
        Task<Status> Get(int id);
        Task<List<Status>> GetAll();
    }
    public class StatusDal : IStatusDal
    {
        private readonly ApplicationContext _applicationContext;

        public StatusDal(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<Status> Create(Status status)
        {
            try
            {
                var result = await _applicationContext.Statuses.AddAsync(status);
                var res = await _applicationContext.SaveChangesAsync();
                if (res != 0)
                {
                    return status;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Status> Delete(int id)
        {
            try
            {
                var status = await _applicationContext.Statuses.Where(x => x.ID == id).FirstOrDefaultAsync();
                if (status != null)
                {
                    _applicationContext.Statuses.Remove(status);
                    var result = await _applicationContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        return status;
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

        public async Task<Status> Get(int id)
        {
            try
            {
                var status = await _applicationContext.Statuses.Where(x => x.ID == id).FirstAsync();
                return status;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<Status>> GetAll()
        {
            try
            {
                return await _applicationContext.Statuses.ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Status> Update(Status status)
        {
            try
            {
                var res = _applicationContext.Statuses.Update(status);
                var result = await _applicationContext.SaveChangesAsync();
                if (result > 0)
                {
                    return status;
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
