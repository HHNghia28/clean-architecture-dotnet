using Dapper;
using MediatR;
using Product.Application.DTO;
using Product.Application.Exceptions;
using Product.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.Product.Queries.GetProduct
{
    public class GetProductQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductQuery, ProductResponse>
    {
        public async Task<ProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetProduct(request.Id);

            return product ?? throw new NotFoundException("Product not found");
        }
    }
}
