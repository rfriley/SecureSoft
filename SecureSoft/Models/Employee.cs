using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Assignment4.Models;

[Table("employees")]
[Index("LastName", Name = "last_name")]
[Index("PostalCode", Name = "postal_code")]
public partial class Employee
{
    [Key]
    [Column("employee_id")]
    [Display(Name = "Employee ID")]
    public int EmployeeId { get; set; }

    [Column("last_name")]
    [StringLength(20)]
    [Display(Name = "Last Name")]
    public string LastName { get; set; } = null!;

    [Column("first_name")]
    [StringLength(10)]
    [Display(Name = "First Name")]
    public string FirstName { get; set; } = null!;

    [Column("title")]
    [StringLength(30)]
    [Display(Name = "Title")]
    public string? Title { get; set; }

    [Column("title_of_courtesy")]
    [StringLength(25)]
    [Display(Name = "Title of Courtesy")]
    public string? TitleOfCourtesy { get; set; }

    [Column("birth_date", TypeName = "datetime")]
    [Display(Name = "Birth Date")]
    public DateTime? BirthDate { get; set; }

    [Column("hire_date", TypeName = "datetime")]
    [Display(Name = "Hire Date")]
    public DateTime? HireDate { get; set; }

    [Column("address")]
    [StringLength(60)]
    [Display(Name = "Address")]
    public string? Address { get; set; }

    [Column("city")]
    [StringLength(15)]
    [Display(Name = "City")]
    public string? City { get; set; }

    [Column("region")]
    [StringLength(15)]
    [Display(Name = "Region")]
    public string? Region { get; set; }

    [Column("postal_code")]
    [StringLength(10)]
    [Display(Name = "Postal Code")]
    public string? PostalCode { get; set; }

    [Column("country")]
    [StringLength(15)]
    [Display(Name = "Country")]
    public string? Country { get; set; }

    [Column("home_phone")]
    [StringLength(24)]
    [Display(Name = "Home Phone")]
    public string? HomePhone { get; set; }

    [Column("extension")]
    [StringLength(4)]
    [Display(Name = "Extension")]
    public string? Extension { get; set; }

    [Column("notes")]
    [StringLength(500)]
    [Display(Name = "Notes")]
    public string? Notes { get; set; }

    [Column("reports_to")]
    [Display(Name = "Reports To")]
    public int? ReportsTo { get; set; }

    [Column("photo_path")]
    [StringLength(255)]
    [Display(Name = "Photo Path")]
    public string? PhotoPath { get; set; }

    [InverseProperty("ReportsToNavigation")]
    [Display(Name = "Employees Reporting To")]
    public virtual ICollection<Employee> InverseReportsToNavigation { get; set; } = new List<Employee>();

    [InverseProperty("Employee")]
    [Display(Name = "Orders")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [ForeignKey("ReportsTo")]
    [InverseProperty("InverseReportsToNavigation")]
    [Display(Name = "Manager")]
    public virtual Employee? ReportsToNavigation { get; set; }
}

