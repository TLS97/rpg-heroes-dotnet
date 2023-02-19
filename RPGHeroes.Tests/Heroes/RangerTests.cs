using RPGHeroes.Exceptions;
using RPGHeroes.Heroes;
using RPGHeroes.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RPGHeroes.Enums.ArmorsEnum;
using static RPGHeroes.Enums.SlotsEnum;
using static RPGHeroes.Enums.WeaponsEnum;
using static System.Net.Mime.MediaTypeNames;

namespace RPGHeroes.Tests.Heroes
{
    public class RangerTests
    {
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

        #region Level Up Ranger
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

        #region Equipping Ranger with Weapon
        [Fact]
        public void Equip_EquippingRangerWithValidWeapon_ShouldEquipValidWeaponType()
        {
            // Assert
            string heroName = "Tine";
            Ranger ranger = new(heroName);

            string weaponName = "Bow";
            int requiredLevel = 1;
            int damage = 1;
            WeaponTypes weaponType = WeaponTypes.Bow;
            Weapon bow = new(weaponName, requiredLevel, damage, weaponType);
            Weapon expected = bow;

            // Act
            ranger.Equip(bow);
            Weapon actual = (Weapon)ranger.Equipment[Slots.Weapon];

            // Assert
            Assert.Equivalent(expected, actual, true);

        }

        [Fact]
        public void Equip_EquippingRangerWithInvalidWeapon_ShouldThrowInvalidWeaponException()
        {
            // Assert
            string heroName = "Tine";
            Ranger ranger = new(heroName);

            string weaponName = "Staff";
            int requiredLevel = 1;
            int damage = 1;
            WeaponTypes weaponType = WeaponTypes.Staff;
            Weapon staff = new(weaponName, requiredLevel, damage, weaponType);

            // Act and Assert
            Assert.Throws<InvalidWeaponException>(() => ranger.Equip(staff));
        }

        [Fact]
        public void Equip_EquippingRangerWithWeaponWithTooHighLevelRequirement_ShouldThrowInsufficientLevelException()
        {
            // Arrange
            string heroName = "Tine";
            Ranger ranger = new(heroName);

            string weaponName = "Bow";
            int requiredLevel = 2;
            int damage = 2;
            WeaponTypes weaponType = WeaponTypes.Bow;
            Weapon bow = new(weaponName, requiredLevel, damage, weaponType);

            // Act and Assert
            Assert.Throws<InsufficientLevelException>(() => ranger.Equip(bow));

        }
        #endregion

        #region Equipping Ranger with Armor
        [Fact]
        public void Equip_EquippingRangerWithValidArmor_ShouldEquipValidArmorType()
        {
            // Arrange
            string heroName = "Tine";
            Ranger ranger = new(heroName);

            string armorName = "Leather";
            int requiredLevel = 1;
            Slots slot = Slots.Body;
            ArmorTypes armorType = ArmorTypes.Leather;

            Armor leather = new(armorName, requiredLevel, slot, armorType);

            Armor expected = leather;

            // Act
            ranger.Equip(leather, slot);
            Armor actual = (Armor)ranger.Equipment[slot];

            // Assert
            Assert.Equivalent(expected, actual, true);

        }

        [Fact]
        public void Equip_EquippingRangerWithInvalidArmor_ShouldThrowInvalidArmorException()
        {
            // Arrange
            string heroName = "Tine";
            Ranger ranger = new(heroName);

            string armorName = "Cloth";
            int requiredLevel = 1;
            Slots slot = Slots.Body;
            ArmorTypes armorType = ArmorTypes.Cloth;
            Armor cloth = new(armorName, requiredLevel, slot, armorType);

            // Act and Assert
            Assert.Throws<InvalidArmorException>(() => ranger.Equip(cloth, slot));
        }

        [Fact]
        public void Equip_EquippingRangerWithArmorWithTooHighLevelRequirement_ShouldThrowInsufficientLevelException()
        {
            // Arrange
            string heroName = "Tine";
            Ranger ranger = new(heroName);

            string armorName = "Leather";
            int requiredLevel = 3;
            Slots slot = Slots.Body;
            ArmorTypes armorType = ArmorTypes.Leather;
            Armor leather = new(armorName, requiredLevel, slot, armorType);

            // Act and Assert
            Assert.Throws<InsufficientLevelException>(() => ranger.Equip(leather, slot));
        }
        #endregion

        #region Calculating Ranger's Total Attributes
        [Fact]
        public void CalculateTotalAttributes_TotalAttributesOfRangerWithNoEquipment_ShouldCorrectlyCalculateTotal()
        {
            // Arrange
            string heroName = "Tine";
            Ranger ranger = new(heroName);

            HeroAttributes rangerAttributes = new(1, 1, 7);
            HeroAttributes armorAttributes = new(0, 0, 0); // No armor equipped
            HeroAttributes totalAttribues = rangerAttributes + armorAttributes;

            HeroAttributes expected = totalAttribues;

            // Act
            HeroAttributes actual = ranger.CalculateTotalAttributes();

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Fact]
        public void CalculateTotalAttributes_TotalAttributesOfRangerWithOnePieceOfArmor_ShouldCorrectlyCalculateTotal()
        {
            // Arrange
            string heroName = "Tine";
            Ranger ranger = new(heroName);

            string armorName = "Mail";
            int requiredLevel = 1;
            Slots slot = Slots.Body;
            ArmorTypes armorType = ArmorTypes.Mail;
            Armor mail = new(armorName, requiredLevel, slot, armorType);
            mail.ArmorAttributes = new(1, 1, 1);

            ranger.Equip(mail, slot);

            HeroAttributes rangerAttributes = new(1, 1, 7);
            HeroAttributes armorAttributes = new(1, 1, 1);
            HeroAttributes totalAttribues = rangerAttributes + armorAttributes;

            HeroAttributes expected = totalAttribues;

            // Act
            HeroAttributes actual = ranger.CalculateTotalAttributes();

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Fact]
        public void CalculateTotalAttributes_TotalAttributesOfRangerWithTwoPiecesOfArmor_ShouldCorrectlyCalculateTotal()
        {
            // Arrange
            string heroName = "Tine";
            Ranger ranger = new(heroName);

            string armorName = "Mail";
            int requiredLevel = 1;
            Slots slot = Slots.Body;
            ArmorTypes armorType = ArmorTypes.Mail;
            Armor mail = new(armorName, requiredLevel, slot, armorType);
            mail.ArmorAttributes = new(1, 2, 3);

            string armorName2 = "Leather";
            int requiredLevel2 = 1;
            Slots slot2 = Slots.Legs;
            ArmorTypes armorType2 = ArmorTypes.Leather;
            Armor leather = new(armorName2, requiredLevel2, slot2, armorType2);
            leather.ArmorAttributes = new(2, 2, 1);

            ranger.Equip(mail, slot);
            ranger.Equip(leather, slot2);

            HeroAttributes rangerAttributes = new(1, 1, 7);
            HeroAttributes armorAttributesFromMail = new(1, 2, 3);
            HeroAttributes armorAttributesFromLeather = new(2, 2, 1);
            HeroAttributes totalAttributes = rangerAttributes + armorAttributesFromMail + armorAttributesFromLeather;

            HeroAttributes expected = totalAttributes;

            // Act
            HeroAttributes actual = ranger.CalculateTotalAttributes();

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Fact]
        public void CalculateTotalAttributes_TotalAttributesOfRangerWithReplacedPieceOfArmor_ShouldCorrectlyCalculateTotal()
        {
            // Arrange
            string heroName = "Tine";
            Ranger ranger = new(heroName);

            string armorName = "Leather";
            int requiredLevel = 1;
            Slots slot = Slots.Body;
            ArmorTypes armorType = ArmorTypes.Leather;
            Armor leather = new(armorName, requiredLevel, slot, armorType);
            leather.ArmorAttributes = new(1, 1, 1);

            ArmorTypes armorType2 = ArmorTypes.Mail;
            Armor mail = new(armorName, requiredLevel, slot, armorType2);
            mail.ArmorAttributes = new(2, 2, 2);

            ranger.Equip(leather, slot);
            ranger.Equip(mail, slot);

            HeroAttributes rangerAttributes = new(1, 1, 7);
            HeroAttributes mailAttributes = new(2, 2, 2);
            HeroAttributes totalAttributes = rangerAttributes + mailAttributes;

            HeroAttributes expected = totalAttributes;

            // Act
            HeroAttributes actual = ranger.CalculateTotalAttributes();

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
        #endregion

        #region Calculating Ranger's Hero Damage
        [Fact]
        public void CalculateDamage_CalculateRangerDamageWithNoWeaponEquipped_ShouldCorrectlyCalculateDamage()
        {
            string heroName = "Tine";
            Ranger ranger = new(heroName);

            int weaponDamage = 1; // No weapon equipped
            int damagingAttribute = 7;
            int heroDamage = weaponDamage * (1 + damagingAttribute / 100);

            double expected = heroDamage;

            // Act
            double actual = ranger.CalculateDamage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateDamage_CalculateRangerDamageWithWeaponEquipped_ShouldCorrectlyCalculateDamage()
        {
            string heroName = "Tine";
            Ranger ranger = new(heroName);

            string weaponName = "Bow";
            int requiredLevel = 1;
            int damage = 2;
            WeaponTypes weaponType = WeaponTypes.Bow;
            Weapon bow = new(weaponName, requiredLevel, damage, weaponType);

            ranger.Equip(bow);

            int weaponDamage = 2; // Weapon equipped
            int damagingAttribute = 7;
            int heroDamage = weaponDamage * (1 + damagingAttribute / 100);

            double expected = heroDamage;

            // Act
            double actual = ranger.CalculateDamage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateDamage_CalculateRangerDamageWithReplacedWeapon_ShouldCorrectlyCalculateDamage()
        {
            string heroName = "Tine";
            Ranger ranger = new(heroName);

            string weaponName = "Bow";
            int requiredLevel = 1;
            int damage = 2;
            WeaponTypes weaponType = WeaponTypes.Bow;
            Weapon bow1 = new(weaponName, requiredLevel, damage, weaponType);

            ranger.Equip(bow1);

            string weaponName2 = "Exclusive Bow";
            int requiredLevel2 = 1;
            int damage2 = 5;
            WeaponTypes weaponType2 = WeaponTypes.Bow;
            Weapon bow2 = new(weaponName2, requiredLevel2, damage2, weaponType2);

            ranger.Equip(bow2);

            int weaponDamage = 5; // Weapon equipped
            int damagingAttribute = 7;
            int heroDamage = weaponDamage * (1 + damagingAttribute / 100);

            double expected = heroDamage;

            // Act
            double actual = ranger.CalculateDamage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateDamage_CalculateRangerDamageWithWeaponAndArmorEquipped_ShouldCorrectlyCalculateDamage()
        {
            string heroName = "Tine";
            Ranger ranger = new(heroName);

            string weaponName = "Bow";
            int requiredLevel = 1;
            int damage = 2;
            WeaponTypes weaponType = WeaponTypes.Bow;
            Weapon bow = new(weaponName, requiredLevel, damage, weaponType);

            ranger.Equip(bow);

            string armorName = "Leather";
            int requiredLevelLeather = 1;
            Slots slot = Slots.Body;
            ArmorTypes armorType = ArmorTypes.Leather;
            Armor leather = new(armorName, requiredLevelLeather, slot, armorType);
            HeroAttributes leatherAttributes = new(1, 1, 1);
            leather.ArmorAttributes = leatherAttributes;

            ranger.Equip(leather, slot);

            int weaponDamage = 2; // Weapon equipped
            int initialDexterity = 7;
            int increasedDamageWithLeather = 1;
            int damagingAttribute = initialDexterity + increasedDamageWithLeather;
            int heroDamage = weaponDamage * (1 + damagingAttribute / 100);

            double expected = heroDamage;

            // Act
            double actual = ranger.CalculateDamage();

            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region Displaying Ranger's State
        [Fact]
        public void Display_DisplayingRangerState_ShouldDisplayCorrectProperties()
        {
            // Arrange
            string heroName = "Tine";
            Ranger ranger = new(heroName);


            string name = heroName;
            string heroClass = "RPGHeroes.Heroes.Ranger";
            string level = "1";
            string totalStrength = "1";
            string totalIntelligence = "1";
            string totalDexterity = "7";
            string damage = "1";

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{name}'s Current State:");
            stringBuilder.AppendLine("Class: " + heroClass);
            stringBuilder.AppendLine("Level: " + level);
            stringBuilder.AppendLine("Total Strength: " + totalStrength);
            stringBuilder.AppendLine("Total Intelligence: " + totalIntelligence);
            stringBuilder.AppendLine("Total Dexterity: " + totalDexterity);
            stringBuilder.AppendLine("Damage: " + damage);

            string expected = stringBuilder.ToString();

            // Act
            string actual = ranger.Display();

            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion
    }
}
