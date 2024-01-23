using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Users
{
    public class UserDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TC { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateTime { get; set; }
        public int CreateUserID { get; set; }
        public int UpdateUserID { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public IFormFile PhotoFile { get; set; }
    }
}
