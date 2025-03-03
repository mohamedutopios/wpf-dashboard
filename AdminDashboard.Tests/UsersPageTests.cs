using AdminDashboard.Pages;
using AdminDashboard.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminDashboard.Tests
{
    [TestClass]
    public class UsersPageTests
    {
        [TestMethod]
        public void UsersPage_InitialiseBienLesUtilisateurs()
        {
            List<User> users = null;

            
            StaTestHelper.Run(() =>
            {
                var page = new UsersPage();
                users = page.UsersDataGrid.ItemsSource as List<User>;
            });

            Assert.IsNotNull(users, "L'ItemsSource ne doit pas être null");
            Assert.AreEqual(3, users.Count, "Il doit y avoir 3 utilisateurs initialement");

            
            Assert.AreEqual(1, users[0].Id, "L'ID du premier utilisateur doit être 1");
            Assert.AreEqual("Alice", users[0].Name, "Le nom du premier utilisateur doit être 'Alice'");
            Assert.AreEqual("alice@example.com", users[0].Email, "L'email du premier utilisateur doit être 'alice@example.com'");
        }
    }
}
