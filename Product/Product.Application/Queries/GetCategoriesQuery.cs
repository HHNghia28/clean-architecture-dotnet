﻿using MediatR;
using Product.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Queries
{
    public class GetCategoriesQuery : IRequest<List<CategoryResponse>>
    {
    }
}
