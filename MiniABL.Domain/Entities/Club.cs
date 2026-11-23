using MiniABL.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniABL.Domain.Entities
{
    public class Club
    {
        public Guid ClubId { get; private set; }
        public string ClubName { get; private set; } = "";
        public ICollection<License> Licenses { get; private set; } = [];
        private Club() { }
        public Club(string Name)
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException("Nom du club obligatoire");
            ClubId = Guid.NewGuid();
            this.ClubName = Name;
        }
        public void UpdateClub(string Name)
        {
            if (string.IsNullOrEmpty(Name))
                throw new ArgumentException("Le nom du club est obligatoire");
            this.ClubName = Name;
        }
    }
}
