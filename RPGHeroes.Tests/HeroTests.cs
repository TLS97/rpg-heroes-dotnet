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

        #region Levelling up Hero
        #region Mage
        [Fact]
        public void LevelUp_LevellingUpMage_ShouldIncreaseLevelByOne()
        {
            // Arrange
            string name = "Tine";
            int level = 2;
            int expected = level;
            Mage mage = new(name);

            // Act
            mage.LevelUp();
            int actual = mage.Level;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUp_LevellingUpMage_ShouldCorrectlyIncreaseLevelAttributes()
        {
            // Arrange
            string name = "Tine";
            int initialStrength = 1;
            int initialIntelligence = 8;
            int initialDexterity = 1;

            int strengthGain = 1;
            int intelligenceGain = 5;
            int dexterityGain = 1;

            int expectedStrength = initialStrength + strengthGain;
            int expectedIntelligence = initialIntelligence + intelligenceGain;
            int expectedDexterity = initialDexterity + dexterityGain;

            HeroAttributes expectedAttributes = new(expectedStrength, expectedIntelligence, expectedDexterity);

            Mage mage = new(name);

            // Act
            mage.LevelUp();
            HeroAttributes actualAttributes = mage.LevelAttributes;

            // Assert
            Assert.Equivalent(expectedAttributes, actualAttributes);
        }
        #endregion

        #region Ranger
        [Fact]
        public void LevelUp_LevellingUpRanger_ShouldIncreaseLevelByOne()
        {
            // Arrange
            string name = "Tine";
            int level = 2;
            int expected = level;
            Ranger ranger = new(name);

            // Act
            ranger.LevelUp();
            int actual = ranger.Level;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUp_LevellingUpRanger_ShouldCorrectlyIncreaseLevelAttributes()
        {
            // Arrange
            string name = "Tine";
            int initialStrength = 1;
            int initialIntelligence = 1;
            int initialDexterity = 7;

            int strengthGain = 1;
            int intelligenceGain = 1;
            int dexterityGain = 5;

            int expectedStrength = initialStrength + strengthGain;
            int expectedIntelligence = initialIntelligence + intelligenceGain;
            int expectedDexterity = initialDexterity + dexterityGain;

            HeroAttributes expectedAttributes = new(expectedStrength, expectedIntelligence, expectedDexterity);

            Ranger ranger = new(name);

            // Act
            ranger.LevelUp();
            HeroAttributes actualAttributes = ranger.LevelAttributes;

            // Assert
            Assert.Equivalent(expectedAttributes, actualAttributes);
        }
        #endregion

        #region Rogue
        [Fact]
        public void LevelUp_LevellingUpRogue_ShouldIncreaseLevelByOne()
        {
            // Arrange
            string name = "Tine";
            int level = 2;
            int expected = level;
            Rogue rogue = new(name);

            // Act
            rogue.LevelUp();
            int actual = rogue.Level;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUp_LevellingUpRogue_ShouldCorrectlyIncreaseLevelAttributes()
        {
            // Arrange
            string name = "Tine";
            int initialStrength = 2;
            int initialIntelligence = 1;
            int initialDexterity = 6;

            int strengthGain = 1;
            int intelligenceGain = 1;
            int dexterityGain = 4;

            int expectedStrength = initialStrength + strengthGain;
            int expectedIntelligence = initialIntelligence + intelligenceGain;
            int expectedDexterity = initialDexterity + dexterityGain;

            HeroAttributes expectedAttributes = new(expectedStrength, expectedIntelligence, expectedDexterity);

            Rogue rogue = new(name);

            // Act
            rogue.LevelUp();
            HeroAttributes actualAttributes = rogue.LevelAttributes;

            // Assert
            Assert.Equivalent(expectedAttributes, actualAttributes);
        }
        #endregion

        #region Warrior
        [Fact]
        public void LevelUp_LevellingUpWarrior_ShouldIncreaseLevelByOne()
        {
            // Arrange
            string name = "Tine";
            int level = 2;
            int expected = level;
            Warrior warrior = new(name);

            // Act
            warrior.LevelUp();
            int actual = warrior.Level;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUp_LevellingUpWarrior_ShouldCorrectlyIncreaseLevelAttributes()
        {
            // Arrange
            string name = "Tine";
            int initialStrength = 5;
            int initialIntelligence = 1;
            int initialDexterity = 2;

            int strengthGain = 3;
            int intelligenceGain = 1;
            int dexterityGain = 2;

            int expectedStrength = initialStrength + strengthGain;
            int expectedIntelligence = initialIntelligence + intelligenceGain;
            int expectedDexterity = initialDexterity + dexterityGain;

            HeroAttributes expectedAttributes = new(expectedStrength, expectedIntelligence, expectedDexterity);

            Warrior warrior = new(name);

            // Act
            warrior.LevelUp();
            HeroAttributes actualAttributes = warrior.LevelAttributes;

            // Assert
            Assert.Equivalent(expectedAttributes, actualAttributes);
        }
        #endregion

        #endregion
    }
}