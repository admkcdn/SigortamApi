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
    public interface IFileTypeDal
    {
        Task<FileType> Create(FileType fileType);
        Task<FileType> Update(FileType fileType);
        Task<FileType> Delete(int id);
        Task<FileType> Get(int id);
        Task<List<FileType>> GetAll();
    }
    public class FileTypeDal : IFileTypeDal
    {
        private readonly ApplicationContext _applicationContext;

        public FileTypeDal(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<FileType> Create(FileType fileType)
        {
            try
            {
                var result = await _applicationContext.FileTypes.AddAsync(fileType);
                var res = await _applicationContext.SaveChangesAsync();
                if (res != 0)
                {
                    return fileType;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<FileType> Delete(int id)
        {
            try
            {
                var fileType = await _applicationContext.FileTypes.Where(x => x.ID == id).FirstOrDefaultAsync();
                if (fileType != null)
                {
                    _applicationContext.FileTypes.Remove(fileType);
                    var result = await _applicationContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        return fileType;
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

        public async Task<FileType> Get(int id)
        {
            try
            {
                var fileType = await _applicationContext.FileTypes.Where(x => x.ID == id).FirstAsync();
                return fileType;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<FileType>> GetAll()
        {
            try
            {
                return await _applicationContext.FileTypes.ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<FileType> Update(FileType fileType)
        {
            try
            {
                var res = _applicationContext.FileTypes.Update(fileType);
                var result = await _applicationContext.SaveChangesAsync();
                if (result > 0)
                {
                    return fileType;
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
