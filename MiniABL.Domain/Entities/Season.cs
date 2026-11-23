using MiniABL.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniABL.Domain.Entities
{
    public class Season
    {
        public Guid SeasonId { get; private set; }
        public DateOnly StartDate { get; private set; }
        public DateOnly EndDate { get; private set; }
        public StatutSeason Statut { get; private set; }
        public ICollection<License> Licenses { get; private set; } = [];
        private Season() { }
        public Season(DateOnly StartDate, DateOnly EndDate)
        {
            if (StartDate >= EndDate)
                throw new ArgumentException("La date de fin doit être apres la date de début");
            SeasonId = Guid.NewGuid();
            this.StartDate = StartDate;
            this.EndDate = EndDate;
        }
        public void Activate()
        {
            if (Statut != StatutSeason.planifie)
                throw new ArgumentException("Seule une saison planifiée peut être activé");
            Statut = StatutSeason.Encours;
        }
        public void Cloture()
        {
            if (Statut != StatutSeason.Encours)
                throw new ArgumentException("Seule une saison en cours peut être cloturée");
            Statut = StatutSeason.cloturee;
        } 
    }
}
