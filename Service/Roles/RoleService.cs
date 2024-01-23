using DAL;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Results;

namespace Service.Roles
{
    public interface IRoleService
    {
        Task<IDataResult<Role>> Create(Role role);
        Task<IDataResult<Role>> Update(Role role);
        Task<IDataResult<Role>> Delete(int id);
        Task<IDataResult<Role>> Get(int id);
        Task<IDataResult<List<Role>>> GetAll();
    }
    public class RoleService : IRoleService
    {
        private readonly IRoleDal _roleDal;

        public RoleService(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public async Task<IDataResult<Role>> Create(Role role)
        {
            try
            {
                var res = await _roleDal.Create(role);
                if (res != null)
                {
                    return new SuccessDataResult<Role>(res);
                }
                return new ErrorDataResult<Role>("Role create failed.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Role>(ex.Message);
            }
        }

        public async Task<IDataResult<Role>> Delete(int id)
        {
            try
            {
                var res = await _roleDal.Delete(id);
                if (res != null)
                {
                    return new SuccessDataResult<Role>(res);
                }
                return new ErrorDataResult<Role>("Role delete failed.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Role>(ex.Message);
            }
        }

        public async Task<IDataResult<Role>> Get(int id)
        {
            try
            {
                var res = await _roleDal.Get(id);
                return new SuccessDataResult<Role>(res);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Role>(ex.Message);
            }
        }

        public async Task<IDataResult<List<Role>>> GetAll()
        {
            try
            {
                var res = await _roleDal.GetAll();
                return new SuccessDataResult<List<Role>>(res);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Role>>(ex.Message);
            }
        }

        public async Task<IDataResult<Role>> Update(Role role)
        {
            try
            {
                var res = await _roleDal.Update(role);
                if (res != null)
                {
                    return new SuccessDataResult<Role>(res);
                }
                return new ErrorDataResult<Role>("Role update failed.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Role>(ex.Message);
            }
        }
    }
}
