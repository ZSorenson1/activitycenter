using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace activitycenter.Models
{
public class UserActivity
{
    [Key]
    public int UserActivityID {get;set;}
    public int UserID {get;set;}
    public int AnActivityID{get;set;}
    public User user {get; set;}
    public AnActivity anActivity {get; set;}
}    
}