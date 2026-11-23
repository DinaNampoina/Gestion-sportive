using MiniABL.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MiniABL.Domain.Entities
{
    public class License
    {
        public Guid LicenseId { get; private set; }
        public string Numero { get; private set; } = "";
        public DateOnly DateCreat { get; private set; }
        public StatutLicense Statut { get; private set; }
        //clés étrangère
        public Guid CategoryId;
        public Guid ClubId;
        public Guid PlayerId;
        public Guid SeasonId;
        //relation
        public Player? Player { get; private set; } = null!;
        public Season? Season { get; private set; } = null!;
        public Category? Category { get; private set; } = null!;
        public Club? Club { get; private set; } = null!;
        private License() { }
        public License(string Numero, Guid PlayerId,Guid ClubId,Guid CategoryId, Guid SeasonId)
        {
            if (string.IsNullOrWhiteSpace(Numero))
                throw new ArgumentException("Numero obligatoire");
            if (PlayerId == Guid.Empty || ClubId == Guid.Empty || CategoryId == Guid.Empty || SeasonId == Guid.Empty)
                throw new ArgumentException("L'identifiant est obligatoire");

            LicenseId = Guid.NewGuid();
            this.Numero = Numero;
            this.DateCreat = DateOnly.FromDateTime(DateTime.Today);
            this.Statut = StatutLicense.enAttente;
        }
        public void Validate()
        {
            if (Statut != StatutLicense.enAttente)
                throw new ArgumentException("seule un statut en attente peut etre  validée");
            this.Statut = StatutLicense.validee;
        }
        public void Suspend()
        {
            if (Statut != StatutLicense.validee)
                throw new ArgumentException("seule un statut validé peut etre suspendre");
            Statut = StatutLicense.suspendue;
        }
        public void Plaster()
        {
            if (Statut == StatutLicense.revoquee)
                throw new ArgumentException("cette licence est deja révoquer");
        }
        public bool IsExpired(DateOnly DateNow)
        {
            return DateNow > Season.EndDate;
        }
    }
}
