using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace activitycenter.Models
{
public class User
{
    [Key]
    public int UserId {get;set;}
    [Required]
    [MinLength(2, ErrorMessage="Name must be at least 2 characters!")]
    public string Name {get;set;}
    [EmailAddress]
    [Required]
    public string Email {get;set;}
    [DataType(DataType.Password)]
    [Required]
    [MinLength(8, ErrorMessage="Password must be 8 characters or longer!")]
    public string Password {get;set;}
    public List<UserActivity> Activities {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    [NotMapped]
    [Compare("Password", ErrorMessage="Passwords Don't Match!")]
    [DataType(DataType.Password)]
    public string Confirm {get;set;}
}    
}