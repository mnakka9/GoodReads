﻿using MyShelf.API.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShelf.API.Services
{
    public interface IShelfService
    {
        Task<List<UserShelf>> GetShelvesList();
    }
}
