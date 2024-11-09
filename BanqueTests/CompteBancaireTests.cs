using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CompteBanqueNS;

[TestClass]
public class CompteBancaireTests
{
	[TestMethod]
	public void VérifierDébitCompteCorrect()
	{
		// Ouvrir un compte
		double soldeInitial = 500000;
		double montantDébit = 400000;
		double soldeAttendu = 100000;
		var compte = new CompteBancaire("Pr. Abdoulaye Diankha", soldeInitial);

		// Débiter
		compte.Débiter(montantDébit);

		// Tester
		double soldeObtenu = compte.Balance;
		Assert.AreEqual(soldeAttendu, soldeObtenu, 0.001, "Compte débité incorrectement");
	}

	[TestMethod]
	[ExpectedException(typeof(ArgumentOutOfRangeException))]
	public void Débiter_MontantSupérieurAuSolde_LèveArgumentOutOfRange()
	{
		// Arrange
		CompteBancaire compte = new CompteBancaire("Client Test", 500.0);
		double montantDébit = 600.0; // Montant supérieur au solde

		// Act
		compte.Débiter(montantDébit);

		// Assert est géré par ExpectedException
	}

	[TestMethod]
	[ExpectedException(typeof(ArgumentOutOfRangeException))]
	public void Débiter_MontantNégatif_LèveArgumentOutOfRange()
	{
		// Arrange
		CompteBancaire compte = new CompteBancaire("Client Test", 500.0);
		double montantDébit = -50.0; // Montant négatif

		// Act
		compte.Débiter(montantDébit);

		// Assert est géré par ExpectedException
	}
	
}