﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Common.Models
{
    public class User : BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
