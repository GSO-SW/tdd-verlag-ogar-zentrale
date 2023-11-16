using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Verlag;

namespace VerlagTests
{
    [TestClass]
    public class BuchTests
    {
        [TestMethod]
        public void Buch_KannErstelltWerden()
        {
            //Arrange
            string autor = "J.K. Rowling";
            string titel = "Harry " +
                "Potter und der Gefangene von Askaban";
            int auflage = 1;

            //Act 
            Buch b = new Buch(autor, titel, auflage);

            //Assert
            Assert.AreEqual(autor, b.Autor);
            Assert.AreEqual(titel, b.Titel);
            Assert.AreEqual(auflage, b.Auflage);
        }

        [TestMethod]
        public void Buch_KeineAuflageEntsprichtErsterAuflage()
        {
            //Arrange

            //Act 
            Buch b = new Buch("autor", "titel");

            //Assert
            Assert.AreEqual(1, b.Auflage);
        }

        [TestMethod]
        public void Autor_DarfVeraendertWerden()
        {
            //Arrange
            string autor = "Abdullah";
            string autorNeu = "Thomas";

            //Act
            Buch b = new Buch(autor, "titel");
            b.Autor = autorNeu;

            //Assert
            Assert.AreEqual(autorNeu, b.Autor);

        }

        [TestMethod]
        public void Auflage_DarfVeraendertWerden()
        {
            //Arrange
            int auflage = 15;
            int auflageNeu = 42;

            //Act
            Buch b = new Buch("autor", "titel", auflage);
            b.Auflage = auflageNeu;

            //Assert
            Assert.AreEqual(auflageNeu, b.Auflage);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Buch_AuflageDarfNichtZuKleinSein()
        {
            //Arrange
            int auflage = 0;

            //Act
            Buch b = new Buch("autor", "titel", auflage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Auflage_DarfNichtZuKleinSein()
        {
            //Arrange
            Buch b = new Buch("autor", "titel");
            int auflageNeu = 0;

            //Act
            b.Auflage = auflageNeu;
        }

        // DataRow: https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest#add-more-features
        [TestMethod]
        [DataRow("")]
        [DataRow("#")]
        [DataRow(";")]
        [DataRow("§")]
        [DataRow("%")]
        [DataRow(null)]
        [ExpectedException(typeof(ArgumentException))]
        public void Autor_NurSinnvolleEingabenErlaubt(string unerlaubtesZeichen)
        {
            //Act
            Buch b = new Buch(unerlaubtesZeichen, "titel");
        }






        //[TestMethod]
        //public void Buch_KannErstelltWerdenMitISBN13()
        //{
        //    //Arrange
        //    string autor = "J.K. Rowling";
        //    string titel = "Harry " +
        //        "Potter und der Gefangene von Askaban";
        //    int auflage = 1;
        //    long ISBN13 = 978377043614;

        //    //Act
        //    Buch b = new Buch(autor, titel, auflage, ISBN13);

        //    //Assert
        //    Assert.AreEqual(autor, b.Autor);
        //    Assert.AreEqual(titel, b.Titel);
        //    Assert.AreEqual(auflage, b.Auflage);
        //    Assert.AreEqual(ISBN13, b.ISBN13);
        //}

        //[TestMethod]
        //public void ISBN13_PruefsummeWirdBerechnet()
        //{
        //    //Arrange
        //    string autor = "J.K. Rowling";
        //    string titel = "Harry " +
        //        "Potter und der Gefangene von Askaban";
        //    int auflage = 1;
        //    long ISBN13 = 978377043614;
        //    long ISBN13MitPruefsumme = 9783770436149;

        //    //Act 
        //    Buch b = new Buch(autor, titel, auflage, ISBN13);

        //    //Assert
        //    Assert.AreEqual(ISBN13MitPruefsumme, b.ISBN13);
        //}

        //[TestMethod]
        //public void ISBN13_KannGesetztWerden()
        //{
        //    //Arrange
        //    string autor = "J.K. Rowling";
        //    string titel = "Harry " +
        //        "Potter und der Gefangene von Askaban";
        //    int auflage = 1;
        //    long ISBN13 = 9783770436149;

        //    //Act 
        //    Buch b = new Buch(autor, titel, auflage);
        //    b.ISBN13 = ISBN13;

        //    //Assert
        //    Assert.AreEqual(ISBN13, b.ISBN13);
        //}

        //[TestMethod]
        //public void ISBN13_KannGesetztWerdenUndPruefsummeBerechnet()
        //{
        //    //Arrange
        //    string autor = "J.K. Rowling";
        //    string titel = "Harry " +
        //        "Potter und der Gefangene von Askaban";
        //    int auflage = 1;
        //    long ISBN13 = 978377043614;
        //    long ISBN13MitPruefsumme = 9783770436149;

        //    //Act 
        //    Buch b = new Buch(autor, titel, auflage);
        //    b.ISBN13 = ISBN13;

        //    //Assert
        //    Assert.AreEqual(ISBN13MitPruefsumme, b.ISBN13);
        //}

        //[TestMethod]
        //public void ISBN13_ZuISBN10()
        //{
        //    //Arrange
        //    string autor = "J.K. Rowling";
        //    string titel = "Harry " +
        //        "Potter und der Gefangene von Askaban";
        //    int auflage = 1;
        //    long ISBN13 = 9783770436064;
        //    long ISBN10 = 3770436067;

        //    //Act 
        //    Buch b = new Buch(autor, titel, auflage, ISBN13);

        //    //Assert
        //    Assert.AreEqual(ISBN10, b.ISBN10);
        //}

        //[TestMethod]
        //public void ISBN13_OhnePruefsummeZuZuISBN10()
        //{
        //    //Arrange
        //    string autor = "J.K. Rowling";
        //    string titel = "Harry " +
        //        "Potter und der Gefangene von Askaban";
        //    int auflage = 1;
        //    long ISBN13 = 978377043606;
        //    long ISBN10 = 3770436067;

        //    //Act 
        //    Buch b = new Buch(autor, titel, auflage, ISBN13);

        //    //Assert
        //    Assert.AreEqual(ISBN10, b.ISBN10);
        //}


        //[TestMethod]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        //public void Buch_KannNichtErstelltWerdenMitZuKurzerISBN13()
        //{
        //    //Arrange
        //    string autor = "J.K. Rowling";
        //    string titel = "Harry " +
        //        "Potter und der Gefangene von Askaban";
        //    int auflage = 1;
        //    long ISBN13 = 9783770436;

        //    //Act 
        //    Buch b = new Buch(autor, titel, auflage, ISBN13);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        //public void Buch_KannNichtErstelltWerdenMitZuLangerISBN13()
        //{
        //    //Arrange
        //    string autor = "J.K. Rowling";
        //    string titel = "Harry " +
        //        "Potter und der Gefangene von Askaban";
        //    int auflage = 1;
        //    long ISBN13 = 9783770436140;

        //    //Act 
        //    Buch b = new Buch(autor, titel, auflage, ISBN13);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        //public void Buch_KannNichtErstelltWerdenMitFalschenISBN13()
        //{
        //    //Arrange
        //    string autor = "J.K. Rowling";
        //    string titel = "Harry " +
        //        "Potter und der Gefangene von Askaban";
        //    int auflage = 1;
        //    long ISBN13 = 978377043616;

        //    //Act 
        //    Buch b = new Buch(autor, titel, auflage, ISBN13);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        //public void ISBN13_KannNichtGesetztWerdenWennZuKurz()
        //{
        //    //Arrange
        //    string autor = "J.K. Rowling";
        //    string titel = "Harry " +
        //        "Potter und der Gefangene von Askaban";
        //    int auflage = 1;
        //    long ISBN13 = 97837704361;

        //    //Act 
        //    Buch b = new Buch(autor, titel, auflage);
        //    b.ISBN13 = ISBN13;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        //public void ISBN13_KannNichtGesetztWerdenWennZuLang()
        //{
        //    //Arrange
        //    string autor = "J.K. Rowling";
        //    string titel = "Harry " +
        //        "Potter und der Gefangene von Askaban";
        //    int auflage = 1;
        //    long ISBN13 = 97837704361490;

        //    //Act 
        //    Buch b = new Buch(autor, titel, auflage);
        //    b.ISBN13 = ISBN13;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        //public void ISBN13_KannNichtGesetztWerdenWennZuFalsch()
        //{
        //    //Arrange
        //    string autor = "J.K. Rowling";
        //    string titel = "Harry " +
        //        "Potter und der Gefangene von Askaban";
        //    int auflage = 1;
        //    long ISBN13 = 9783770436146;

        //    //Act 
        //    Buch b = new Buch(autor, titel, auflage);
        //    b.ISBN13 = ISBN13;
        //}
    }
}
