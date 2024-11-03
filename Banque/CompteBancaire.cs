using System;

namespace CompteBanqueNS
{
    /// <summary>
    /// Classe démo compte bancaire.
    /// </summary>
    public class CompteBancaire
    {
        private string m_nomClient;
        private double m_solde;
        private bool m_bloqué = false;

        private CompteBancaire() {}

        public CompteBancaire(string nomClient, double solde)
        {
            m_nomClient = nomClient;
            m_solde = solde;
        }

        public string nomClient
        {
            get { return m_nomClient; }
        }

        public double Balance
        {
            get { return m_solde; }
        }

        public void Débiter(double montant)
        {
            if (m_bloqué)
            {
                throw new Exception("Compte bloqué");
            }

            if (montant > m_solde)
            {
                throw new ArgumentOutOfRangeException("Montant débité doit être supérieur ou égal au solde disponible");
            }
            if (montant < 0)
            {
                throw new ArgumentOutOfRangeException("Montant doit être positif");
            }

            m_solde += montant; // code intentionnellement faux
        }

        public void Créditer(double montant)
        {
            if (m_bloqué)
            {
                throw new Exception("Compte bloqué");
            }

            if (montant < 0)
            {
                throw new ArgumentOutOfRangeException("Montant crédité doit être supérieur à zéro");
            }

            m_solde += montant;
        }

        public void BloquerCompte()
        {
            m_bloqué = true;
        }

        public void DébloquerCompte()
        {
            m_bloqué = false;
        }

        public static void Main()
        {
            CompteBancaire cb = new CompteBancaire("Pr. Abdoulaye Diankha", 500000);

            cb.Créditer(500000);
            cb.Débiter(40000);
            Console.WriteLine("Solde disponible égal à F{0}", cb.Balance);
        }
    }
}
