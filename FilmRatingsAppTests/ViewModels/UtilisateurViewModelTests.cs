using Microsoft.VisualStudio.TestTools.UnitTesting;
using FilmRatingsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmRatingsApp.Models;

namespace FilmRatingsApp.ViewModels.Tests
{
    [TestClass()]
    public class UtilisateurViewModelTests
    {
        /// <summary>
        /// Test constructeur.
        /// </summary>
        [TestMethod()]
        public void UtilisateurViewModelTest()
        {
            // Arrange.
            UtilisateurViewModel viewModel = new UtilisateurViewModel();
            // Act.
            // Assert.
            Assert.IsNotNull(viewModel);
        }
    }
}