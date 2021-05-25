using SharedConfig.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid();
            IsDeleted = false;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public AppRole Role { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
