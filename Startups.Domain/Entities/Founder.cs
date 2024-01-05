using System.ComponentModel.DataAnnotations;

namespace Startups.Domain.Entities
{
    public class Founder : BaseEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public ICollection<Startup> Startups { get; set; } = null!;


        public Founder() { }

        public Founder(string name, string email, byte[] passwordHash, byte[] passwordSalt)
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }
    }
}

