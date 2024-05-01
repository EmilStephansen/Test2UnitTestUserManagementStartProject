using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2UnitTestUserManagementStartProject.services
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [NotNull]
        public string Name { get; set; }
    }
}
