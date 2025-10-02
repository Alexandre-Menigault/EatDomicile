using System.ComponentModel.DataAnnotations;
using EatDomicile.Web.Services.Dtos;

namespace EatDomicile.Web.ViewModels;

public class UserViewModel
{
    public int Id { get; set; }

    [Required, StringLength(50)]
    [Display(Name = "Prénom")]
    public string FirstName { get; set; } = string.Empty;

    [Required, StringLength(50)]
    [Display(Name = "Nom")]
    public string LastName { get; set; } = string.Empty;

    [Required, EmailAddress]
    [StringLength(100)]
    public string Email { get; set; } = string.Empty;

    [Required, Phone]
    [StringLength(15)]
    [Display(Name = "Téléphone")]
    public string Phone { get; set; } = string.Empty;

    [Display(Name = "Adresse")]
    public AddressDTO Address { get; set; }

}
