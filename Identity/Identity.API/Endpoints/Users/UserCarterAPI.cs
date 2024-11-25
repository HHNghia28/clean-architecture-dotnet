using Carter;
using Identity.Application.Features.Users.Commands.UpdateAccount;
using Identity.Application.Features.Users.Queries.GetUser;
using Identity.Application.Features.Users.Queries.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Endpoints.Users
{
    public class UserCarterAPI : ICarterModule
    {
        private const string BaseUrl = "api/minimal/v{version:apiVersion}/products";

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group1 = app.NewVersionedApi("user-carter-name-show-on-swagger")
                .MapGroup(BaseUrl) 
                .HasApiVersion(1);

            group1.MapGet(string.Empty, GetAll);
            group1.MapGet("{id:guid}", Get);
            group1.MapPut(string.Empty, Update);
        }

        public async Task<IResult> GetAll(ISender sender, [FromQuery] GetUsersQuery request)
        {
            return Results.Ok(await sender.Send(request));
        }

        public async Task<IResult> Get(ISender sender, Guid id)
        {
            return Results.Ok(await sender.Send(new GetUserQuery
            {
                Id = id
            }));
        }

        public async Task<IResult> Update(ISender sender, [FromBody] UpdateUserCommand request)
        {
            await sender.Send(request);
            return Results.Ok("Update user successful");
        }
    }
}
