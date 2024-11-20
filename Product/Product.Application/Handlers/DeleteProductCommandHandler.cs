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
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Product.GetByIdAsync<Guid>(request.Id);

            if (product == null) throw new Exception("Product not found");

            product.UpdatedBy = request.UpdatedBy;
            product.IsDeleted = true;

            await _unitOfWork.Product.UpdateAsync(product);
            await _unitOfWork.SaveAsync();
        }
    }
}
