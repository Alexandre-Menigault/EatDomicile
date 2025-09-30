using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatDomicile.Web.Services.Dtos;

public class OrdersDto
{
    public int Id { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public string Status { get; set; } = string.Empty;

    public int UserId { get; set; }

    public int DeliveryAddressId { get; set; }

    public List<string> Products { get; set; } = new();
}
