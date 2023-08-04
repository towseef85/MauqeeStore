﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.Dtos.AppUsersDtos
{
    public class GetUserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string Gender { get; set; }
    }
}
