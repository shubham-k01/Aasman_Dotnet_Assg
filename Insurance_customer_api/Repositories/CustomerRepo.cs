using System;
using Insurance_customer_api.Dtos;
using Insurance_customer_api.Models;
using Microsoft.Data.SqlClient;

namespace Insurance_customer_api.Repositories;

public class CustomerRepo
{
    private readonly IConfiguration _config;

    public CustomerRepo(IConfiguration configuration)
    {
        _config = configuration;
    }

    public List<Customer> GetCustomers()
    {
        List<Customer> customers = [];
        var connString = _config.GetConnectionString("Default");

        using (SqlConnection conn = new SqlConnection(connString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM customer;", conn);
            using (SqlDataReader dataReader = cmd.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    customers.Add(
                        new Customer()
                        {
                            Id = (int)dataReader["Id"],
                            Name = dataReader["Name"].ToString(),
                            Address = dataReader["Address"].ToString(),
                            Email = dataReader["Email"].ToString()
                        }
                    );
                }
            }
            conn.Close();

        }
        return customers;
    }
    public void AddCustomer(CreateCustomerDTO customer)
    {

        var connString = _config.GetConnectionString("Default");
        using (SqlConnection conn = new SqlConnection(connString))
        {
            var cmdText = "INSERT INTO customer(Name,Address,Email) VALUES(@name,@address,@email)";

            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Parameters.AddWithValue("@name", customer.Name);
            cmd.Parameters.AddWithValue("@address", customer.Address);
            cmd.Parameters.AddWithValue("@email", customer.Email);

            conn.Open();
            var ex = cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
    public void UpdateCustomer(int id, CreateCustomerDTO customer)
    {

        var connString = _config.GetConnectionString("Default");
        using (SqlConnection conn = new SqlConnection(connString))
        {
            var cmdText = "UPDATE customer SET Name=@name,Address=@address,Email=@email WHERE Id=@id";

            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Parameters.AddWithValue("@name", customer.Name);
            cmd.Parameters.AddWithValue("@address", customer.Address);
            cmd.Parameters.AddWithValue("@email", customer.Email);
            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();
            var ex = cmd.ExecuteNonQuery();

            conn.Close();
        }
    }


    public void DeleteCustomer(int id)
    {
        var connString = _config.GetConnectionString("Default");
        using (SqlConnection conn = new SqlConnection(connString))
        {
            var cmdText = "DELETE FROM customer WHERE Id=@id;";

            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();
            var ex = cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}


