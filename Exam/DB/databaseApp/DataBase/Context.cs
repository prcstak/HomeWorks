using databaseApp.Models;
using Microsoft.EntityFrameworkCore;

namespace databaseApp.DataBase
{
    public class Context : DbContext
    {
        public DbSet<Creature> Creature { get; set; }
        public Context(DbContextOptions options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Creature>().HasData(
                new Creature()
                {
                    Id = 1,
                    UserName = "Griffon",
                    HitPoints = 59,
                    AttackModifier = 5,
                    AttackPerRound = 1,
                    Dice = 8,
                    Damage = 12,
                    Weapon = 6,
                    DamageModifier = 6,
                    AC = 12,
                },
                new Creature()
                {
                    Id = 2,
                    UserName = "Djinni",
                    HitPoints = 161,
                    AttackModifier = 5,
                    AttackPerRound = 2,
                    Dice = 6,
                    Damage = 12,
                    Weapon = 9,
                    DamageModifier = 2,
                    AC = 17,
                },
                new Creature()
                {
                    Id = 3,
                    UserName = "Baboon",
                    HitPoints = 3,
                    AttackModifier = 0,
                    AttackPerRound = 1,
                    Dice = 6,
                    Damage = 1,
                    Weapon = 1,
                    DamageModifier = 0,
                    AC = 12,
                });
        }
    }
}