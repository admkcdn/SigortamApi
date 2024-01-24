using DAL;
using Data.Model;
using DTOs.Users;
using Utilities.Results;

namespace Service.Users
{
    public interface IUserService
    {
        Task<IDataResult<User>> Create(UserDto user);
        Task<IDataResult<User>> Update(User user);
        Task<IDataResult<User>> Delete(int id);
        Task<IDataResult<User>> Get(int id);
        Task<IDataResult<List<User>>> GetAll();
        Task<IDataResult<User>> Login(string username, string password);
        Task<IDataResult<int>> GetUserRole(int userId);

    }
    public class UserService : IUserService
    {
        private readonly IUserDal _userDal;

        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<IDataResult<User>> Create(UserDto user)
        {
            try
            {
                var userMapped = new User()
                {
                    Photo = user.Photo,
                    Address = user.Address,
                    CreateDate = user.CreateDate,
                    CreateUserID = user.CreateUserID,
                    Email = user.Email,
                    ID = user.ID,
                    Name = user.Name,
                    Password = user.Password,
                    Phone = user.Phone,
                    Status = user.Status,
                    Surname = user.Surname,
                    TC = user.TC,
                    UpdateTime = user.UpdateTime,
                    UpdateUserID = user.UpdateUserID,
                    Username = user.Username
                };
                var res = await _userDal.Create(userMapped);
                if (res != null)
                {
                    return new SuccessDataResult<User>(res);
                }
                return new ErrorDataResult<User>("User create failed.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<User>(ex.Message);
            }
        }

        public async Task<IDataResult<User>> Delete(int id)
        {
            try
            {
                var res = await _userDal.Delete(id);
                if (res != null)
                {
                    return new SuccessDataResult<User>(res);
                }
                return new ErrorDataResult<User>("User delete failed.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<User>(ex.Message);
            }
        }

        public async Task<IDataResult<int>> GetUserRole(int userId)
        {
            try
            {
                var res = await _userDal.GetUserRole(userId);
                return new SuccessDataResult<int>(res);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<int>(ex.Message);
            }
        }
        public async Task<IDataResult<User>> Get(int id)
        {
            try
            {
                var res = await _userDal.Get(id);
                return new SuccessDataResult<User>(res);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<User>(ex.Message);
            }
        }

        public async Task<IDataResult<List<User>>> GetAll()
        {
            try
            {
                var res = await _userDal.GetAll();
                return new SuccessDataResult<List<User>>(res);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<User>>(ex.Message);
            }
        }

        public async Task<IDataResult<User>> Login(string username, string password)
        {
            try
            {
                var res = await _userDal.Login(username, password);
                if (res != null)
                {
                    return new SuccessDataResult<User>(res);
                }
                return new ErrorDataResult<User>("Email veya Şifre Hatalı");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<User>(ex.Message);
            }
        }

        public async Task<IDataResult<User>> Update(User user)
        {
            try
            {
                var res = await _userDal.Update(user);
                if (res != null)
                {
                    return new SuccessDataResult<User>(res);
                }
                return new ErrorDataResult<User>("User update failed.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<User>(ex.Message);
            }
        }
    }
}
