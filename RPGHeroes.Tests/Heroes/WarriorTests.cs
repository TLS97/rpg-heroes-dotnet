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

namespace RPGHeroes.Tests.Heroes
{
    public class WarriorTests
    {
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

        #region Level Up Warrior
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

        #region Equipping Warrior with Weapon
        [Fact]
        public void Equip_EquippingWarriorWithValidWeapon_ShouldEquipValidWeaponType()
        {
            // Assert
            string heroName = "Tine";
            Warrior warrior = new(heroName);

            string weaponName = "Sword";
            int requiredLevel = 1;
            int damage = 1;
            WeaponTypes weaponType = WeaponTypes.Sword;
            Weapon sword = new(weaponName, requiredLevel, damage, weaponType);
            Weapon expected = sword;

            // Act
            warrior.Equip(sword);
            Weapon actual = (Weapon)warrior.Equipment[Slots.Weapon];

            // Assert
            Assert.Equivalent(expected, actual, true);

        }

        [Fact]
        public void Equip_EquippingWarriorWithInvalidWeapon_ShouldThrowInvalidWeaponException()
        {
            // Assert
            string heroName = "Tine";
            Warrior warrior = new(heroName);

            string weaponName = "Bow";
            int requiredLevel = 1;
            int damage = 1;
            WeaponTypes weaponType = WeaponTypes.Bow;
            Weapon bow = new(weaponName, requiredLevel, damage, weaponType);

            // Act and Assert
            Assert.Throws<InvalidWeaponException>(() => warrior.Equip(bow));
        }

        [Fact]
        public void Equip_EquippingWarriorWithWeaponWithTooHighLevelRequirement_ShouldThrowInsufficientLevelException()
        {
            // Arrange
            string heroName = "Tine";
            Warrior warrior = new(heroName);

            string weaponName = "Axe";
            int requiredLevel = 4;
            int damage = 1;
            WeaponTypes weaponType = WeaponTypes.Axe;
            Weapon axe = new(weaponName, requiredLevel, damage, weaponType);

            // Act and Assert
            Assert.Throws<InsufficientLevelException>(() => warrior.Equip(axe));

        }
        #endregion

        #region Equipping Warrior with Armor
        [Fact]
        public void Equip_EquippingWarriorWithValidArmor_ShouldEquipValidArmorType()
        {
            // Arrange
            string heroName = "Tine";
            Warrior warrior = new(heroName);

            string armorName = "Plate";
            int requiredLevel = 1;
            Slots slot = Slots.Body;
            ArmorTypes armorType = ArmorTypes.Plate;

            Armor plate = new(armorName, requiredLevel, slot, armorType);

            Armor expected = plate;

            // Act
            warrior.Equip(plate, slot);
            Armor actual = (Armor)warrior.Equipment[slot];

            // Assert
            Assert.Equivalent(expected, actual, true);

        }

        [Fact]
        public void Equip_EquippingWarriorWithInvalidArmor_ShouldThrowInvalidArmorException()
        {
            // Arrange
            string heroName = "Tine";
            Warrior warrior = new(heroName);

            string armorName = "Cloth";
            int requiredLevel = 2;
            Slots slot = Slots.Body;
            ArmorTypes armorType = ArmorTypes.Cloth;
            Armor cloth = new(armorName, requiredLevel, slot, armorType);

            // Act
            Assert.Throws<InvalidArmorException>(() => warrior.Equip(cloth, slot));
        }

        [Fact]
        public void Equip_EquippingWarriorWithArmorWithTooHighLevelRequirement_ShouldThrowInsufficientLevelException()
        {
            // Arrange
            string heroName = "Tine";
            Warrior warrior = new(heroName);

            string armorName = "Mail";
            int requiredLevel = 2;
            Slots slot = Slots.Body;
            ArmorTypes armorType = ArmorTypes.Mail;
            Armor mail = new(armorName, requiredLevel, slot, armorType);

            // Act and Assert
            Assert.Throws<InsufficientLevelException>(() => warrior.Equip(mail, slot));
        }
        #endregion

        #region Calculating Warrior's Total Attributes
        [Fact]
        public void CalculateTotalAttributes_TotalAttributesOfWarriorWithNoEquipment_ShouldCorrectlyCalculateTotal()
        {
            // Arrange
            string heroName = "Tine";
            Warrior warrior = new(heroName);

            HeroAttributes warriorAttributes = new(5, 1, 2);
            HeroAttributes armorAttributes = new(0, 0, 0); // No armor equipped
            HeroAttributes totalAttribues = warriorAttributes + armorAttributes;

            HeroAttributes expected = totalAttribues;

            // Act
            HeroAttributes actual = warrior.CalculateTotalAttributes();

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Fact]
        public void CalculateTotalAttributes_TotalAttributesOfWarriorWithOnePieceOfArmor_ShouldCorrectlyCalculateTotal()
        {
            // Arrange
            string heroName = "Tine";
            Warrior warrior = new(heroName);

            HeroAttributes warriorAttributes = new(5, 1, 2);

            string armorName = "Mail";
            int requiredLevel = 1;
            Slots slot = Slots.Body;
            ArmorTypes armorType = ArmorTypes.Mail;
            Armor mail = new(armorName, requiredLevel, slot, armorType);
            mail.ArmorAttributes = new(1, 2, 3);

            warrior.Equip(mail, slot);

            HeroAttributes armorAttributes = new(1, 2, 3);
            HeroAttributes totalAttributes = warriorAttributes + armorAttributes;

            HeroAttributes expected = totalAttributes;

            // Act
            HeroAttributes actual = warrior.CalculateTotalAttributes();

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Fact]
        public void CalculateTotalAttributes_TotalAttributesOfWarriorWithTwoPiecesOfArmor_ShouldCorrectlyCalculateTotal()
        {
            // Arrange
            string heroName = "Tine";
            Warrior warrior = new(heroName);

            string armorName = "Mail";
            int requiredLevel = 1;
            Slots slot = Slots.Body;
            ArmorTypes armorType = ArmorTypes.Mail;
            Armor mail = new(armorName, requiredLevel, slot, armorType);
            mail.ArmorAttributes = new(1, 2, 3);

            string armorName2 = "Plate";
            int requiredLevel2 = 1;
            Slots slot2 = Slots.Legs;
            ArmorTypes armorType2 = ArmorTypes.Plate;
            Armor plate = new(armorName2, requiredLevel2, slot2, armorType2);
            plate.ArmorAttributes = new(3, 2, 1);

            warrior.Equip(mail, slot);
            warrior.Equip(plate, slot2);

            HeroAttributes warriorAttributes = new(5, 1, 2);
            HeroAttributes mailAttributes = new(1, 2, 3);
            HeroAttributes plateAttributes = new(3, 2, 1);
            HeroAttributes totalAttributes = warriorAttributes + mailAttributes + plateAttributes;

            HeroAttributes expected = totalAttributes;

            // Act
            HeroAttributes actual = warrior.CalculateTotalAttributes();

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Fact]
        public void CalculateTotalAttributes_TotalAttributesOfWarriorWithReplacedPieceOfArmor_ShouldCorrectlyCalculateTotal()
        {
            // Arrange
            string heroName = "Tine";
            Warrior warrior = new(heroName);

            string armorName = "Mail";
            int requiredLevel = 1;
            Slots slot = Slots.Body;
            ArmorTypes armorType = ArmorTypes.Mail;
            Armor mail = new(armorName, requiredLevel, slot, armorType);
            mail.ArmorAttributes = new(1, 2, 3);

            string armorName2 = "Plate";
            int requiredLevel2 = 1;
            Slots slot2 = Slots.Body;
            ArmorTypes armorType2 = ArmorTypes.Plate;
            Armor plate = new(armorName2, requiredLevel2, slot2, armorType2);
            plate.ArmorAttributes = new(3, 2, 1);

            warrior.Equip(mail, slot);
            warrior.Equip(plate, slot);

            HeroAttributes warriorAttributes = new(5, 1, 2);
            HeroAttributes plateAttributes = new(3, 2, 1);
            HeroAttributes totalAttributes = warriorAttributes + plateAttributes;

            HeroAttributes expected = totalAttributes;

            // Act
            HeroAttributes actual = warrior.CalculateTotalAttributes();

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
        #endregion

        #region Calculating Warrior's Hero Damage
        [Fact]
        public void CalculateDamage_CalculateWarriorDamageWithNoWeaponEquipped_ShouldCorrectlyCalculateDamage()
        {
            string heroName = "Tine";
            Warrior warrior = new(heroName);

            int weaponDamage = 1; // No weapon equipped
            int damagingAttribute = 5;
            int heroDamage = weaponDamage * (1 + damagingAttribute / 100);

            double expected = heroDamage;

            // Act
            double actual = warrior.CalculateDamage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateDamage_CalculateWarriorDamageWithWeaponEquipped_ShouldCorrectlyCalculateDamage()
        {
            string heroName = "Tine";
            Warrior warrior = new(heroName);

            string weaponName = "Axe";
            int requiredLevel = 1;
            int damage = 3;
            WeaponTypes weaponType = WeaponTypes.Axe;
            Weapon axe = new(weaponName, requiredLevel, damage, weaponType);

            warrior.Equip(axe);

            int weaponDamage = 3; // Weapon equipped
            int damagingAttribute = 5;
            int heroDamage = weaponDamage * (1 + damagingAttribute / 100);

            double expected = heroDamage;

            // Act
            double actual = warrior.CalculateDamage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateDamage_CalculateWarriorDamageWithReplacedWeapon_ShouldCorrectlyCalculateDamage()
        {
            string heroName = "Tine";
            Warrior warrior = new(heroName);

            string weaponName = "Axe";
            int requiredLevel = 1;
            int damage = 3;
            WeaponTypes weaponType = WeaponTypes.Axe;
            Weapon axe = new(weaponName, requiredLevel, damage, weaponType);

            warrior.Equip(axe);

            string weaponName2 = "Sword";
            int requiredLevel2 = 1;
            int damage2 = 6;
            WeaponTypes weaponType2 = WeaponTypes.Sword;
            Weapon sword = new(weaponName2, requiredLevel2, damage2, weaponType2);

            warrior.Equip(sword);

            int weaponDamage = 6; // Weapon equipped
            int damagingAttribute = 5;
            int heroDamage = weaponDamage * (1 + damagingAttribute / 100);

            double expected = heroDamage;

            // Act
            double actual = warrior.CalculateDamage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateDamage_CalculateWarriorDamageWithWeaponAndArmorEquipped_ShouldCorrectlyCalculateDamage()
        {
            string heroName = "Tine";
            Warrior warrior = new(heroName);

            string weaponName = "Sword";
            int requiredLevel = 1;
            int damage = 6;
            WeaponTypes weaponType = WeaponTypes.Sword;
            Weapon sword = new(weaponName, requiredLevel, damage, weaponType);

            warrior.Equip(sword);

            string armorName = "Mail";
            int requiredLevelMail = 1;
            Slots slot = Slots.Body;
            ArmorTypes armorType = ArmorTypes.Mail;
            Armor mail = new(armorName, requiredLevelMail, slot, armorType);
            HeroAttributes mailAttributes = new(4, 0, 0);
            mail.ArmorAttributes = mailAttributes;

            warrior.Equip(mail, slot);

            int weaponDamage = 6; // Weapon equipped
            int initialIntelligence = 5;
            int increasedDamageWithMail = 4;
            int damagingAttribute = initialIntelligence + increasedDamageWithMail;
            int heroDamage = weaponDamage * (1 + damagingAttribute / 100);

            double expected = heroDamage;

            // Act
            double actual = warrior.CalculateDamage();

            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region Displaying Warrior's State
        [Fact]
        public void Display_DisplayingWarriorState_ShouldDisplayCorrectProperties()
        {
            // Arrange
            string heroName = "Tine";
            Warrior warrior = new(heroName);


            string name = heroName;
            string heroClass = "RPGHeroes.Heroes.Warrior";
            string level = "1";
            string totalStrength = "5";
            string totalIntelligence = "1";
            string totalDexterity = "2";
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
            string actual = warrior.Display();

            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion
    }
}
