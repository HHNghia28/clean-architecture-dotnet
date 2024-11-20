﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Product.Application.Commands
{
    public class DeleteCategoryCommand : IRequest
    {
        [JsonIgnore]
        public int Id { get; set; }
        public Guid UserId { get; set; }
    }
}
