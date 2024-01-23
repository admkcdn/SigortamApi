using DAL;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Results;

namespace Service.File
{
    public interface IFileTypeService
    {
        Task<IDataResult<FileType>> Create(FileType fileType);
        Task<IDataResult<FileType>> Update(FileType fileType);
        Task<IDataResult<FileType>> Delete(int id);
        Task<IDataResult<FileType>> Get(int id);
        Task<IDataResult<List<FileType>>> GetAll();
    }
    public class FileTypeService : IFileTypeService
    {
        private readonly IFileTypeDal _fileTypeDal;

        public FileTypeService(IFileTypeDal fileTypeDal)
        {
            _fileTypeDal = fileTypeDal;
        }

        public async Task<IDataResult<FileType>> Create(FileType fileType)
        {
            try
            {
                var res = await _fileTypeDal.Create(fileType);
                if (res != null)
                {
                    return new SuccessDataResult<FileType>(res);
                }
                return new ErrorDataResult<FileType>("File Type create failed.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<FileType>(ex.Message);
            }
        }

        public async Task<IDataResult<FileType>> Delete(int id)
        {
            try
            {
                var res = await _fileTypeDal.Delete(id);
                if (res != null)
                {
                    return new SuccessDataResult<FileType>(res);
                }
                return new ErrorDataResult<FileType>("File Type delete failed.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<FileType>(ex.Message);
            }
        }

        public async Task<IDataResult<FileType>> Get(int id)
        {
            try
            {
                var res = await _fileTypeDal.Get(id);
                return new SuccessDataResult<FileType>(res);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<FileType>(ex.Message);
            }
        }

        public async Task<IDataResult<List<FileType>>> GetAll()
        {
            try
            {
                var res = await _fileTypeDal.GetAll();
                return new SuccessDataResult<List<FileType>>(res);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<FileType>>(ex.Message);
            }
        }

        public async Task<IDataResult<FileType>> Update(FileType fileType)
        {
            try
            {
                var res = await _fileTypeDal.Update(fileType);
                if (res != null)
                {
                    return new SuccessDataResult<FileType>(res);
                }
                return new ErrorDataResult<FileType>("File Type update failed.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<FileType>(ex.Message);
            }
        }
    }
}
