﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Api.DTOs
{
    public class BrandDto
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public bool IsDeleted { get; set; }
    }
}
