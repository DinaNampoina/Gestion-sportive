using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MiniABL.Domain.Entities
{
    public class Player
    {
        public Guid PlayerId { get; private set; } 
        public string FirstName { get; private set; } = "";
        public string LastName { get; private set; } = "";
        public DateOnly DateOfBirth { get; private set; }

        public ICollection<License> Licenses { get; private set; } = [];
        private Player() { }
        public Player(string FirstName, string LastName , DateOnly DateOfBirth)
        {
            if (string.IsNullOrWhiteSpace(FirstName))
                throw new ArgumentException("Le nom est obligatoire");
            if (string.IsNullOrWhiteSpace(LastName))
                throw new ArgumentException("Le prenom est obligatoire");
            if (DateOfBirth >= DateOnly.FromDateTime(DateTime.Today))
                throw new ArgumentException("Date de naissance invalide");  
            this.PlayerId = Guid.NewGuid();
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
        }
        public void UpdatePlayer(string FirstName, string LastName, DateOnly DateOfBirth)
        {
            if (string.IsNullOrWhiteSpace(FirstName))
                throw new ArgumentException("Le nom est obligatoire");
            if (string.IsNullOrWhiteSpace(LastName))
                throw new ArgumentException("Le prenom est obligatoire");
            if (DateOfBirth >= DateOnly.FromDateTime(DateTime.Today))
                throw new ArgumentException("Date de naissance invalide");
            this.PlayerId = Guid.NewGuid();
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
        }
    }
}
