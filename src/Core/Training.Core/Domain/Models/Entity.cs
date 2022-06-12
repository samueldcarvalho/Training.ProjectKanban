using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Core.Domain.Models
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public DateTime AlteredAt { get; private set; } = DateTime.MinValue;
        public bool Removed { get; private set; } = false;
    }
}
