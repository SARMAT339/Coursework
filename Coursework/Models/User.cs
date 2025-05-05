﻿namespace Coursework.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(string name, int age, string email, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
            Email = email;
            Password = password;
        }
    }
}
