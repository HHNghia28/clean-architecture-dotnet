using MediatR;
using Product.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Product.Application.Commands
{
    public class CreateProductCommand : IRequest
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public int Price { get; set; } = 0;
        public int Discount { get; set; } = 0;
        [StringLength(500)]
        public string Photo { get; set; }

        public Guid CreatedBy { get; set; }
        public int CategoryId { get; set; }
    }
}
