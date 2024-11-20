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
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Product.AddAsync(new Domain.Models.Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Discount = request.Discount,
                Photo = request.Photo,
                CreatedBy = request.CreatedBy,
                UpdatedBy = request.CreatedBy,
                CategoryId = request.CategoryId,
            });

            await _unitOfWork.SaveAsync();
        }
    }
}
