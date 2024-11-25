﻿using Dapper;
using Identity.Application.DTO;
using Identity.Application.Interfaces;
using Identity.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Features.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, PagedResponse<List<UserListResponse>>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<PagedResponse<List<UserListResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUsers(new PagingRequest
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
            });
        }
    }
}