using System;

namespace Insurance_customer_api.Dtos;

public class CreateCustomerDTO
{
    
    public string Name { get; set; }

    public string Address { get; set; }

    public string  Email { get; set; }
}
