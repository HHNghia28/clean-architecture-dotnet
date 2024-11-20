using MediatR;
using Product.Application.Commands;
using Product.Domain.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Product.GetByIdAsync<Guid>(request.Id);

            if (product == null) throw new Exception("Product not found");

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Discount = request.Discount;
            product.Photo = request.Photo;
            product.CategoryId = request.CategoryId;
            product.UpdatedBy = request.UpdatedBy;

            await _unitOfWork.Product.UpdateAsync(product);
            await _unitOfWork.SaveAsync();
        }
    }
}
