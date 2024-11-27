using MediatR;
using Product.Application.Exceptions;
using Product.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.Product.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler(IProductRepository productRepository) : IRequestHandler<DeleteProductCommand>
    {
        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException("Product not found");

            product.LastModifiedBy = request.UpdatedBy;
            product.IsDeleted = true;

            await productRepository.UpdateAsync(product);
            await productRepository.SaveAsync();
        }
    }
}
