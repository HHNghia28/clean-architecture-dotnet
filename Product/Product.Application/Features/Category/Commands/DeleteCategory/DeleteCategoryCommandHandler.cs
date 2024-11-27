using MediatR;
using Product.Application.Exceptions;
using Product.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler(ICategoryRepository categoryRepository) : IRequestHandler<DeleteCategoryCommand>
    {
        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException("Category not found");

            category.LastModifiedBy = request.UserId;
            category.IsDeleted = true;

            await categoryRepository.UpdateAsync(category);
            await categoryRepository.SaveAsync();
        }
    }
}
