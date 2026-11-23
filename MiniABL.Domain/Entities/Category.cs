using System;
using System.Collections.Generic;
using System.Text;

namespace MiniABL.Domain.Entities
{
    public class Category
    {
        public Guid CategoryId { get; private set; }
        public string Description { get; private set; } = "";
        public int MinAge { get; private set; }
        public int MaxAge { get; private set; }
        public ICollection<License> Licenses { get; private set; } = [];

        private Category() { }

        public Category(string Description , int MinAge, int MaxAge)
        {
            if (string.IsNullOrWhiteSpace(Description))
                throw new ArgumentException("Description Obligatoire");
            if (MinAge >= MaxAge || MinAge <= 0 || MaxAge <= 0)
                throw new ArgumentException("Limite d'age invalide");
            CategoryId = Guid.NewGuid();
            this.Description = Description;
            this.MinAge = MinAge;
            this.MaxAge = MaxAge;
        }
        public bool VerifyPlayer(Player Player , DateOnly ReferenceDate)
        {
            if (Player == null)
                throw new ArgumentException("Joueur introuvable");
            int Age = ReferenceDate.Year - Player.DateOfBirth.Year;
            if (Player.DateOfBirth > ReferenceDate.AddYears(-Age))
                Age--;
            return Age <= this.MinAge && Age >= this.MaxAge;
        }
        public void UpdateCategory(string Description , int MinAge, int MaxAge)
        {
            if (string.IsNullOrWhiteSpace(Description))
                throw new ArgumentException("Decription obligatoire");
            if (MinAge >= MaxAge || MinAge <= 0 || MaxAge <= 0)
                throw new ArgumentException("Limite d'age invalide");
            this.Description = Description;
            this.MinAge = MinAge;
            this.MaxAge = MaxAge;
        }
    }
}
