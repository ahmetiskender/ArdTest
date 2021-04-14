using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Resource
{
    public class UserResource
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string ImgPath { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }
    }
}
