using Carter;
using Identity.Application.Features.Users.Commands.UpdateAccount;
using Identity.Application.Features.Users.Queries.GetUser;
using Identity.Application.Features.Users.Queries.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Endpoints.V1.Users
{
    public class UserCarterApiV1 : ICarterModule
    {
        private const string BaseUrl = "api/v{version:apiVersion}/users";

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group1 = app.NewVersionedApi("user-carter-name-show-on-swagger")
                .MapGroup(BaseUrl)
                .HasApiVersion(1);

            group1.MapGet(string.Empty, GetAll);
            group1.MapGet("{id:guid}", Get);
            group1.MapPut(string.Empty, Update);
        }

        public async Task<IResult> GetAll(ISender sender, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var request = new GetUsersQuery { PageNumber = pageNumber, PageSize = pageSize };
            return Results.Ok(await sender.Send(request));
        }

        public async Task<IResult> Get(ISender sender, Guid id)
        {
            return Results.Ok(await sender.Send(new GetUserQuery { Id = id }));
        }

        public async Task<IResult> Update(ISender sender, [FromBody] UpdateUserCommand request)
        {
            await sender.Send(request);
            return Results.Ok("Update user successful");
        }
    }
}
