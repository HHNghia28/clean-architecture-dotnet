﻿using MediatR;
using Product.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.Product.Commands.CreateProduct
{
    public class CreateProductCommandHandler(IProductRepository productRepository) : IRequestHandler<CreateProductCommand>
    {
        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await productRepository.AddAsync(new Domain.Entities.Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Discount = request.Discount,
                Photo = request.Photo,
                CreatedBy = request.CreatedBy,
                LastModifiedBy = request.CreatedBy,
                CategoryId = request.CategoryId,
            });

            await productRepository.SaveAsync();
        }
    }
}