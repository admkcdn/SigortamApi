using DAL;
using Data.Model;
using DTOs.Files;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Results;

namespace Service.File
{
    public interface IFileService
    {
        Task<IDataResult<Data.Model.File>> CreateFile(FileDto file);
        Task<IDataResult<Data.Model.File>> UpdateFile(Data.Model.File file);
        Task<IDataResult<Data.Model.File>> DeleteFile(int id);
        Task<IDataResult<Data.Model.File>> GetFile(int id);
        Task<IDataResult<List<Data.Model.File>>> GetAllFiles();
    }

    public class FileService : IFileService
    {
        private readonly IFileDal _fileDal;

        public FileService(IFileDal fileDal)
        {
            _fileDal = fileDal;
        }

        public async Task<IDataResult<Data.Model.File>> CreateFile(FileDto file)
        {
            try
            {
                var mappedFile = new Data.Model.File()
                {
                    ID = (int)file.ID,
                    CreateDate = DateTime.Now,
                    CreateUserID = file.CreateUserID,
                    Description = file.Description,
                    FilePath = file.FilePath,
                    FileStatusID = file.FileStatusID,
                    FileTypeID = file.FileTypeID,
                    Name = file.Name,
                    Number = Guid.NewGuid().ToString(),
                    PaymentDetailID = (int)file.PaymentDetailID,
                    UpdateDate = file.UpdateDate,
                    UpdateUserID = file.UpdateUserID
                };
                var addedFile = await _fileDal.Create(mappedFile);

                if (addedFile != null)
                {
                    return new SuccessDataResult<Data.Model.File>(addedFile);
                }
                else
                {
                    return new ErrorDataResult<Data.Model.File>("File creation failed.");
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Data.Model.File>(ex.Message);
            }
        }

        public async Task<IDataResult<Data.Model.File>> UpdateFile(Data.Model.File file)
        {
            try
            {
                var updatedFile = await _fileDal.Update(file);

                if (updatedFile != null)
                {
                    return new SuccessDataResult<Data.Model.File>(updatedFile);
                }
                else
                {
                    return new ErrorDataResult<Data.Model.File>("File update failed.");
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Data.Model.File>(ex.Message);
            }
        }

        public async Task<IDataResult<Data.Model.File>> DeleteFile(int id)
        {
            try
            {
                var deletedFile = await _fileDal.Delete(id);

                if (deletedFile != null)
                {
                    return new SuccessDataResult<Data.Model.File>(deletedFile);
                }
                else
                {
                    return new ErrorDataResult<Data.Model.File>("File delete failed.");
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Data.Model.File>(ex.Message);
            }
        }

        public async Task<IDataResult<Data.Model.File>> GetFile(int id)
        {
            try
            {
                var file = await _fileDal.Get(id);

                if (file != null)
                {
                    return new SuccessDataResult<Data.Model.File>(file);
                }
                else
                {
                    return new SuccessDataResult<Data.Model.File>(file, "File not found.");
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Data.Model.File>(ex.Message);
            }
        }

        public async Task<IDataResult<List<Data.Model.File>>> GetAllFiles()
        {
            try
            {
                var files = await _fileDal.GetAll();

                return new SuccessDataResult<List<Data.Model.File>>(files);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Data.Model.File>>(ex.Message);
            }
        }
    }
}
