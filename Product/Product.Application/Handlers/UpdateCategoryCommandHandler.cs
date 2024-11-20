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
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.Category.GetByIdAsync(request.Id);

            if (category == null) throw new Exception("Category not found");

            category.UpdatedBy = request.UserId;
            category.Name = request.Name;

            await _unitOfWork.Category.UpdateAsync(category);
            await _unitOfWork.SaveAsync();
        }
    }
}
