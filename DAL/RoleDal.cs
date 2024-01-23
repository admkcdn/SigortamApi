using Data.Context;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRoleDal
    {
        Task<Role> Create(Role role);
        Task<Role> Update(Role role);
        Task<Role> Delete(int id);
        Task<Role> Get(int id);
        Task<List<Role>> GetAll();
    }
    public class RoleDal : IRoleDal
    {
        private readonly ApplicationContext _applicationContext;

        public RoleDal(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<Role> Create(Role role)
        {
            try
            {
                var result = await _applicationContext.Roles.AddAsync(role);
                var res = await _applicationContext.SaveChangesAsync();
                if (res != 0)
                {
                    return role;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Role> Delete(int id)
        {
            try
            {
                var role = await _applicationContext.Roles.Where(x => x.ID == id).FirstOrDefaultAsync();
                if (role != null)
                {
                    _applicationContext.Roles.Remove(role);
                    var result = await _applicationContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        return role;
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

        public async Task<Role> Get(int id)
        {
            try
            {
                var role = await _applicationContext.Roles.Where(x => x.ID == id).FirstAsync();
                return role;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<Role>> GetAll()
        {
            try
            {
                return await _applicationContext.Roles.ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Role> Update(Role role)
        {
            try
            {
                var res = _applicationContext.Roles.Update(role);
                var result = await _applicationContext.SaveChangesAsync();
                if (result > 0)
                {
                    return role;
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
