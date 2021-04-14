using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Domain
{
    public partial class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ImgPath { get; set; }
        public string Email { get; set; }
        public int Gender { get; set; }
    }
}
