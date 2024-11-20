using MediatR;
using Product.Application.DTO;
using Product.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Queries
{
    public class GetProductQuery : IRequest<ProductResponse>
    {
        public Guid Id { get; set; }
    }
}
