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
    public interface IFileDal
    {
        Task<Data.Model.File> Create(Data.Model.File file);
        Task<Data.Model.File> Update(Data.Model.File file);
        Task<Data.Model.File> Delete(int id);
        Task<Data.Model.File> Get(int id);
        Task<List<Data.Model.File>> GetAll();
    }
    public class FileDal : IFileDal
    {
        private readonly ApplicationContext _applicationContext;

        public FileDal(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<Data.Model.File> Create(Data.Model.File file)
        {
            try
            {
                var result = await _applicationContext.Files.AddAsync(file);
                var res = await _applicationContext.SaveChangesAsync();
                if (res > 0)
                {
                    var addedFile = await _applicationContext.Files.FindAsync(file);
                    return addedFile;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Data.Model.File> Delete(int id)
        {
            try
            {
                var file = await _applicationContext.Files.Where(x => x.ID == id).FirstOrDefaultAsync();
                if (file != null)
                {
                    _applicationContext.Files.Remove(file);
                    var result = await _applicationContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        return file;
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

        public async Task<Data.Model.File> Get(int id)
        {
            try
            {
                var file = await _applicationContext.Files.Where(x => x.ID == id).FirstOrDefaultAsync();
                return file;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<Data.Model.File>> GetAll()
        {
            try
            {
                return await _applicationContext.Files.ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Data.Model.File> Update(Data.Model.File file)
        {
            try
            {
                var res = _applicationContext.Files.Update(file);
                var result = await _applicationContext.SaveChangesAsync();
                if (result > 0)
                {
                    return file;
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
