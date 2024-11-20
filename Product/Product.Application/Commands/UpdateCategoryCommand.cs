﻿using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Product.Application.Commands
{
    public class UpdateCategoryCommand : IRequest
    {
        [JsonIgnore]
        public int Id { get; set; }
        public Guid UserId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
