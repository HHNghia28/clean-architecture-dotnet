using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Product.Application.Commands
{
    public class DeleteProductCommand : IRequest
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        public Guid UpdatedBy { get; set; }
    }
}
