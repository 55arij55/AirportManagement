using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AM.ApplicationCore.Domain
{
    [Owned]
    public class FullName
    {
        [StringLength(25, MinimumLength = 3, ErrorMessage = "First Name must be between 3 and 25 characters.")]
        public string? FirstName { get; set; }

        [StringLength(25, MinimumLength = 3, ErrorMessage = "First Name must be between 3 and 25 characters.")]
        public string? LastName { get; set; }
    }
}
