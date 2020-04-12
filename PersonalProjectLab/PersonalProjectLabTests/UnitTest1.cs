using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonalProjectLab;

namespace PersonalProjectLabTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PlayerDies()
        {
            // Arrange
            Player test = new Player(5, 12, 5);

            // Act
            test.PlayerTakesDamage(5);

            // Assert
            Assert.AreEqual(false, test.IsPlayerAlive());
        }

        [TestMethod]
        public void EnemyAttack()
        {
            Enemy test = new Enemy(10, 5, "zombie");

            Assert.IsTrue(test.EnemyAttack() >= 3);
        }
    }
}
