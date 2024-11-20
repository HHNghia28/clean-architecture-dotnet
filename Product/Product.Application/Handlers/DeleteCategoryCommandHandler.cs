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
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.Category.GetByIdAsync(request.Id);

            if (category == null) throw new Exception("Category not found");

            category.UpdatedBy = request.UserId;
            category.IsDeleted = true;

            await _unitOfWork.Category.UpdateAsync(category);
            await _unitOfWork.SaveAsync();
        }
    }
}
