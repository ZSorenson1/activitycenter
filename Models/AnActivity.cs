using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace activitycenter.Models
{
public class AnActivity
{
    [Key]
    public int AnActivityId {get;set;}
    [Required]
    public string Title {get;set;}
    public int UserID {get;set;}
    public User Coordinator {get;set;}
    public DateTime Date {get;set;}
    [Required]
    public DateTime Time {get;set;}
    [Required]
    public int Duration {get;set;}
    [Required]
    public string DurMeasurment {get;set;}
    [Required]
    public string Desc {get;set;}
    public List<UserActivity> Participants {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
}    
}