using Data.Context;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace DAL
{
    public interface IUserDal
    {
        Task<User> Create(User user);
        Task<User> Update(User user);
        Task<User> Delete(int id);
        Task<User> Get(int id);
        Task<List<User>> GetAll();
        Task<User> Login(string email, string password);
        Task<int> GetUserRole(int userId);
    }
    public class UserDal : IUserDal
    {
        private readonly ApplicationContext _applicationContext;

        public UserDal(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<User> Create(User user)
        {
            try
            {
                var result = await _applicationContext.Users.AddAsync(user);
                var res = await _applicationContext.SaveChangesAsync();
                if (res > 0)
                {
                    return user;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<User> Delete(int id)
        {
            try
            {
                var user = await _applicationContext.Users.Where(x => x.ID == id).FirstOrDefaultAsync();
                if (user != null)
                {
                    user.Status = false;
                    var result = await _applicationContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        return user;
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

        public async Task<int> GetUserRole(int userId)
        {
            try
            {
                var res = await _applicationContext.UserRoles.Where(x => x.UserID == userId).Select(x => x.RoleID).FirstOrDefaultAsync();
                return res;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<User> Get(int id)
        {
            try
            {
                var user = await _applicationContext.Users.Where(x => x.ID == id).FirstAsync();
                return user;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<User>> GetAll()
        {
            try
            {
                return await _applicationContext.Users.ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<User> Login(string email, string password)
        {
            try
            {
                var res = await _applicationContext.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefaultAsync();
                return res;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<User> Update(User user)
        {
            try
            {
                var res = _applicationContext.Users.Update(user);
                var result = await _applicationContext.SaveChangesAsync();
                if (result > 0)
                {
                    return user;
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
