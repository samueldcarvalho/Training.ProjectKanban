using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Core.Domain.Models
{
    public abstract class Entity
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }
        [Column(Order = 100)]
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        [Column(Order = 101)]
        public DateTime AlteredAt { get; private set; } = DateTime.MinValue;
        [Column(Order = 102)]
        public bool Removed { get; private set; } = false;

        public void ChangeRemoved(bool isRemoved) =>
            Removed = isRemoved;
    }
}
