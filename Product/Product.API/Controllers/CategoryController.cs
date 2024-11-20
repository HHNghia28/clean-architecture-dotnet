using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Commands;
using Product.Application.Queries;
using Product.Domain.Interfaces.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;

        public CategoryController(IMediator mediator, IAuthenticatedUserService authenticatedUserService)
        {
            _mediator = mediator;
            _authenticatedUserService = authenticatedUserService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var category = await _mediator.Send(new GetCategoriesQuery());

                if (category.Count <= 0)
                {
                    return NotFound();
                }

                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = "An error occurred while processing your request.",
                    Details = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return Ok("Create category successful");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = "An error occurred while processing your request.",
                    Details = ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryCommand command)
        {
            try
            {
                command.Id = id;
                await _mediator.Send(command);
                return Ok("Update category successful");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = "An error occurred while processing your request.",
                    Details = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromBody] DeleteCategoryCommand command)
        {
            try
            {
                command.Id = id;
                await _mediator.Send(command);
                return Ok("Delete category successful");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = "An error occurred while processing your request.",
                    Details = ex.Message
                });
            }
        }
    }
}
