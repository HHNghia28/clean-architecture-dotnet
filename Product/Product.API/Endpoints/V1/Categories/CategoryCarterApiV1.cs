﻿using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Features.Category.Commands.CreateCategory;
using Product.Application.Features.Category.Commands.DeleteCategory;
using Product.Application.Features.Category.Commands.UpdateCategory;
using Product.Application.Features.Category.Queries.GetCategories;

namespace Product.API.Endpoints.V1.Categories
{
    public class CategoryCarterApiV1 : ICarterModule
    {
        private const string BaseUrl = "api/v{version:apiVersion}/categories";

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group1 = app.NewVersionedApi("category-carter-name-show-on-swagger")
                .MapGroup(BaseUrl)
                .HasApiVersion(1);

            group1.MapGet(string.Empty, Get);
            group1.MapPost(string.Empty, Create);
            group1.MapPut("{id}", Update);
            group1.MapDelete("{id}", Delete);
        }

        public async Task<IResult> Get(ISender sender)
        {
            var category = await sender.Send(new GetCategoriesQuery());

            if (category.Count <= 0)
            {
                return Results.NotFound();
            }

            return Results.Ok(category);
        }

        public async Task<IResult> Create(ISender sender, [FromBody] CreateCategoryCommand command)
        {
            await sender.Send(command);
            return Results.Ok("Create category successful");
        }

        public async Task<IResult> Update(ISender sender, int id, [FromBody] UpdateCategoryCommand command)
        {
            command.Id = id;
            await sender.Send(command);
            return Results.Ok("Update category successful");
        }

        public async Task<IResult> Delete(ISender sender, int id, [FromBody] DeleteCategoryCommand command)
        {
            command.Id = id;
            await sender.Send(command);
            return Results.Ok("Delete category successful");
        }
    }
}
