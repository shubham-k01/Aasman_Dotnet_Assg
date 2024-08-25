using System;
using System.ComponentModel.DataAnnotations;

namespace Insurance_customer_api.Models;

public class Customer
{
    
    public int Id {get;set;}

    [Required]
    public string Name { get; set; }  

    [DataType(DataType.Text)]
    public string Address { get; set; }

    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
}
