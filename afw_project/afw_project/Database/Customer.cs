﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace afw_project
{
    class Customer
    {
        /// <summary>
        /// Gets or sets the ID of the customer.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the customer's password in SHA256.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the customer's e-mail.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the customer's phone number.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the customer's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the customer's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the customer's street from the address.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the customer's building number from the address.
        /// </summary>
        public string Building { get; set; }

        /// <summary>
        /// Gets or sets the customer's city from the address.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the customer's postal code from the address.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the customer's country from the address.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the customer's orders.
        /// </summary>
        public List<Order> Orders { get; set; }

        /// <summary>
        /// Creates a new instance for a new customer.
        /// </summary>
        /// <param name="email">E-mail input.</param>
        /// <param name="password">Plain password input.</param>
        /// <param name="firstName">First name input.</param>
        /// <param name="lastName">Last name input.</param>
        /// <param name="phone">Phone number input.</param>
        /// <param name="street">Street adress input.</param>
        /// <param name="building">Building number input.</param>
        /// <param name="city">City input.</param>
        /// <param name="code">Postal code input.</param>
        /// <param name="country">Country input.</param>
        public Customer(string email, string password, string firstName, string lastName, string phone, string street, string building, string city, string code, string country)
        {
            Email = email;
            Password = GetHash(password);
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Street = street;
            Building = building;
            City = city;
            Code = code;
            Country = country;
        }

        /// <summary>
        /// Encrypt the customer's password.
        /// </summary>
        /// <param name="source">Plain password of the customer.</param>
        /// <returns>Password value in SHA256.</returns>
        private static string GetHash(string source)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
                byte[] hashBytes = sha256Hash.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
                return hash;
            }
        }

        /// <summary>
        /// Finds the user identified by login in the database.
        /// </summary>
        /// <param name="email">Input e-mail value.</param>
        /// <param name="password">Input password value.</param>
        /// <returns>Customer instance or null if no account was found.</returns>
        public static Customer GetCustomer(string email, string password)
        {
            Context db = new Context();
            try
            {
                Customer user = db.Customers.Where(u => u.Email == email && GetHash(password) == u.Password).Single();
                return user;
            }
            catch
            {
                return null;
            }

        }

        /// <summary>
        /// Entries the instance into the database.
        /// </summary>
        /// <returns>True if successful, false if a mistake occured.</returns>
        public bool CreateNewCustomer()
        {
            try
            {
                Context db = new Context();
                db.Customers.Add(this);
                if (db.SaveChanges() != 1)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
