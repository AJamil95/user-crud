using System;
using System.ComponentModel.DataAnnotations;

namespace user_crud.Server.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string? LastName { get; set; }

        public DateOnly? BirthDate { get; set; }

        public string? Profession { get; set; }

        public string? Nationality { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public decimal? Salary { get; set; }
    }
}
