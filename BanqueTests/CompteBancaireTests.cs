using NUnit.Framework;
using System;
using CompteBanqueNS;

namespace BanqueTests
{
	[TestFixture]
	public class CompteBancaireTests
	{
		[Test]
		public void Débiter_MontantSupérieurAuSolde_LèveArgumentOutOfRange()
		{
			// Arrange
			CompteBancaire compte = new CompteBancaire("Client Test", 500.0);
			double montantDébit = 600.0; // Montant supérieur au solde

			// Act & Assert
			Assert.Throws<ArgumentOutOfRangeException>(() => compte.Débiter(montantDébit));
		}

		[Test]
		public void Débiter_MontantNégatif_LèveArgumentOutOfRange()
		{
			// Arrange
			CompteBancaire compte = new CompteBancaire("Client Test", 500.0);
			double montantDébit = -50.0; // Montant négatif

			// Act & Assert
			Assert.Throws<ArgumentOutOfRangeException>(() => compte.Débiter(montantDébit));
		}

		[Test]
		public void Débiter_MontantValide_DiminueLeSolde()
		{
			// Arrange
			CompteBancaire compte = new CompteBancaire("Client Test", 500.0);
			double montantDébit = 200.0; // Montant valide
			double soldeAttendu = 300.0; // Solde après débit

			// Act
			compte.Débiter(montantDébit);

			// Assert
			Assert.AreEqual(soldeAttendu, compte.Balance, "Le solde final est incorrect après le débit.");
		}
	}
}