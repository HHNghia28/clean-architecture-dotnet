using MediatR;
using Product.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler(ICategoryRepository categoryRepository) : IRequestHandler<CreateCategoryCommand>
    {
        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await categoryRepository.AddAsync(new Domain.Entities.Category
            {
                Name = request.Name,
                CreatedBy = request.CreatedBy,
                LastModifiedBy = request.CreatedBy,
            });

            await categoryRepository.SaveAsync();
        }
    }
}
