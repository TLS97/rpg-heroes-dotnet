using RPGHeroes.Heroes;

namespace RPGHeroes.Tests
{
    public class HeroTests
    {
        #region Hero Creation
        #region Mage Creation
        [Fact]
        public void Constructor_InitializeMage_ShouldInitializeWithCorrectName()
        {
            // Arrange
            string name = "Tine";
            string expected = name;
            // Act
            Mage mage = new(name);
            string actual = mage.Name;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_InitializeMage_ShouldInitializeWithCorrectLevel()
        {
            // Arrange
            string name = "Tine";
            int level = 1;
            int expected = level;
            // Act
            Mage mage = new(name);
            int actual = mage.Level;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_InitializeMage_ShouldInitializeWithCorrectAttributes()
        {
            // Arrange
            string name = "Tine";

            int strength = 1;
            int intelligence = 8;
            int dexterity = 1;

            HeroAttributes heroAttributes = new(strength, intelligence, dexterity);
            HeroAttributes expected = heroAttributes;

            // Act
            Mage mage = new(name);
            HeroAttributes actual = mage.LevelAttributes;

            // Assert
            Assert.Equivalent(expected, actual, true);
            //Assert.Equal(expected, actual);
        }
        #endregion
        #region Ranger Creation
        [Fact]
        public void Constructor_InitializeRanger_ShouldInitializeWithCorrectName()
        {
            // Arrange
            string name = "Tine";
            string expected = name;
            // Act
            Ranger ranger = new(name);
            string actual = ranger.Name;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_InitializeRanger_ShouldInitializeWithCorrectLevel()
        {
            // Arrange
            string name = "Tine";
            int level = 1;
            int expected = level;
            // Act
            Ranger ranger = new(name);
            int actual = ranger.Level;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_InitializeRanger_ShouldInitializeWithCorrectAttributes()
        {
            // Arrange
            string name = "Tine";

            int strength = 1;
            int intelligence = 1;
            int dexterity = 7;

            HeroAttributes heroAttributes = new(strength, intelligence, dexterity);
            HeroAttributes expected = heroAttributes;

            // Act
            Ranger ranger = new(name);
            HeroAttributes actual = ranger.LevelAttributes;

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
        #endregion
        #region Rogue Creation
        [Fact]
        public void Constructor_InitializeRogue_ShouldInitializeWithCorrectName()
        {
            // Arrange
            string name = "Tine";
            string expected = name;
            // Act
            Rogue rogue = new(name);
            string actual = rogue.Name;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_InitializeRogue_ShouldInitializeWithCorrectLevel()
        {
            // Arrange
            string name = "Tine";
            int level = 1;
            int expected = level;
            // Act
            Rogue rogue = new(name);
            int actual = rogue.Level;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_InitializeRogue_ShouldInitializeWithCorrectAttributes()
        {
            // Arrange
            string name = "Tine";

            int strength = 2;
            int intelligence = 1;
            int dexterity = 6;

            HeroAttributes heroAttributes = new(strength, intelligence, dexterity);
            HeroAttributes expected = heroAttributes;

            // Act
            Rogue rogue = new(name);
            HeroAttributes actual = rogue.LevelAttributes;

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
        #endregion
        #region Warrior Creation
        [Fact]
        public void Constructor_InitializeWarrior_ShouldInitializeWithCorrectName()
        {
            // Arrange
            string name = "Tine";
            string expected = name;
            // Act
            Warrior warrior = new(name);
            string actual = warrior.Name;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_InitializeWarrior_ShouldInitializeWithCorrectLevel()
        {
            // Arrange
            string name = "Tine";
            int level = 1;
            int expected = level;
            // Act
            Warrior warrior = new(name);
            int actual = warrior.Level;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_InitializeWarrior_ShouldInitializeWithCorrectAttributes()
        {
            // Arrange
            string name = "Tine";

            int strength = 5;
            int intelligence = 1;
            int dexterity = 2;

            HeroAttributes heroAttributes = new(strength, intelligence, dexterity);
            HeroAttributes expected = heroAttributes;

            // Act
            Warrior warrior = new(name);
            HeroAttributes actual = warrior.LevelAttributes;

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
        #endregion
        #endregion
    }
}