using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Files
{
    public class FileDto
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string? Number { get; set; }
        public int FileStatusID { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int CreateUserID { get; set; }
        public int? UpdateUserID { get; set; }
        public int? PaymentDetailID { get; set; }
        public string Description { get; set; }
        public int FileTypeID { get; set; }
        public string? FilePath { get; set; }
        public IFormFile File { get; set; }
    }
}
