using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entity
{
    public class UserEntity
    {
        internal string password;

        [Key]
             [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
             public int Id { get; set; }
             public string FirstName { get; set; }
             public string LastName { get; set; }
             public string Email { get; set; }
             public string Password { get; set; }
             public DateTime CreatedDate { get; set; }  
             public DateTime LastModifiedDate { get; set; }

    }
}
