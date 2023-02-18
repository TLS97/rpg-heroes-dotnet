﻿using RPGHeroes.Exceptions;
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
    public class MageTests
    {
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

        #region Level Up Mage
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

        #region Equipping Mage with Weapon
        [Fact]
        public void Equip_EquippingMageWithValidWeapon_ShouldEquipValidWeaponType()
        {
            // Assert
            string heroName = "Tine";
            Mage mage = new(heroName);

            string weaponName = "Staff";
            int requiredLevel = 1;
            int damage = 1;
            WeaponTypes weaponType = WeaponTypes.Staff;
            Weapon staff = new(weaponName, requiredLevel, damage, weaponType);
            Weapon expected = staff;

            // Act
            mage.Equip(staff);
            Weapon actual = (Weapon)mage.Equipment[Slots.Weapon];

            // Assert
            Assert.Equivalent(expected, actual, true);

        }

        [Fact]
        public void Equip_EquippingMageWithInvalidWeaponType_ShouldThrowInvalidWeaponException()
        {
            // Assert
            string heroName = "Tine";
            Mage mage = new(heroName);

            string weaponName = "Bow";
            int requiredLevel = 1;
            int damage = 1;
            WeaponTypes weaponType = WeaponTypes.Bow;
            Weapon bow = new(weaponName, requiredLevel, damage, weaponType);

            // Act and Assert
            Assert.Throws<InvalidWeaponException>(() => mage.Equip(bow));
        }

        [Fact]
        public void Equip_EquippingMageWithWeaponWithTooHighLevelRequirement_ShouldThrowInsufficientLevelException()
        {
            // Arrange
            string heroName = "Tine";
            Mage mage = new(heroName);

            string weaponName = "Wand";
            int requiredLevel = 2;
            int damage = 1;
            WeaponTypes weaponType = WeaponTypes.Wand;
            Weapon wand = new(weaponName, requiredLevel, damage, weaponType);

            // Act and Assert
            Assert.Throws<InsufficientLevelException>(() => mage.Equip(wand));
        }
        #endregion

        #region Equipping Mage with Armor
        [Fact]
        public void Equip_EquippingMageWithValidArmor_ShouldEquipValidArmorType()
        {
            // Arrange
            string heroName = "Tine";
            Mage mage = new(heroName);

            string armorName = "Cloth";
            int requiredLevel = 1;
            Slots slot = Slots.Body;
            ArmorTypes armorType = ArmorTypes.Cloth;

            Armor cloth = new(armorName, requiredLevel, slot, armorType);

            Armor expected = cloth;

            // Act
            mage.Equip(cloth, slot);
            Armor actual = (Armor)mage.Equipment[slot];

            // Assert
            Assert.Equivalent(expected, actual, true);

        }

        [Fact]
        public void Equip_EquippingMageWithInvalidArmorType_ShouldThrowInvalidArmorException()
        {
            // Arrange
            string heroName = "Tine";
            Mage mage = new(heroName);

            string armorName = "Leather";
            int requiredLevel = 1;
            Slots slot = Slots.Body;
            ArmorTypes armorType = ArmorTypes.Leather;
            Armor leather = new(armorName, requiredLevel, slot, armorType);

            // Act
            Assert.Throws<InvalidArmorException>(() => mage.Equip(leather, slot));
        }

        [Fact]
        public void Equip_EquippingMageWithArmorWithTooHighLevelRequirement_ShouldThrowInsufficientLevelException()
        {
            // Arrange
            string heroName = "Tine";
            Mage mage = new(heroName);

            string armorName = "Cloth";
            int requiredLevel = 5;
            Slots slot = Slots.Body;
            ArmorTypes armorType = ArmorTypes.Cloth;
            Armor cloth = new(armorName, requiredLevel, slot, armorType);

            // Act and Assert
            Assert.Throws<InsufficientLevelException>(() => mage.Equip(cloth, slot));

        }
        #endregion

        #region Calculating Mage's Total Attributes
        [Fact]
        public void CalculateTotalAttributes_TotalAttributesOfMageWithNoEquipment_ShouldCorrectlyCalculateTotal()
        {
            // Arrange
            string heroName = "Tine";
            Mage mage = new(heroName);

            HeroAttributes mageAttributes = new(1, 8, 1);
            HeroAttributes armorAttributes = new(0, 0, 0); // No armor equipped
            HeroAttributes totalAttribues = mageAttributes + armorAttributes;

            HeroAttributes expected = totalAttribues;

            // Act
            HeroAttributes actual = mage.CalculateTotalAttributes();

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Fact]
        public void CalculateTotalAttributes_TotalAttributesOfMageWithOnePieceOfArmor_ShouldCorrectlyCalculateTotal()
        {
            // Arrange
            string heroName = "Tine";
            Mage mage = new(heroName);

            HeroAttributes mageAttributes = new(1, 8, 1);

            string armorName = "Cloth";
            int requiredLevel = 1;
            Slots slot = Slots.Body;
            ArmorTypes armorType = ArmorTypes.Cloth;
            Armor cloth = new(armorName, requiredLevel, slot, armorType);
            cloth.ArmorAttributes = new(1, 2, 3);

            mage.Equip(cloth, slot);

            HeroAttributes armorAttributes = new(1, 2, 3);
            HeroAttributes totalAttributes = mageAttributes + armorAttributes;

            HeroAttributes expected = totalAttributes;

            // Act
            HeroAttributes actual = mage.CalculateTotalAttributes();

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Fact]
        public void CalculateTotalAttributes_TotalAttributesOfMageWithTwoPiecesOfArmor_ShouldCorrectlyCalculateTotal()
        {
            // Arrange
            string heroName = "Tine";
            Mage mage = new(heroName);

            string armorName = "Cloth";
            int requiredLevel = 1;
            Slots slot = Slots.Body;
            ArmorTypes armorType = ArmorTypes.Cloth;
            Armor cloth = new(armorName, requiredLevel, slot, armorType);
            cloth.ArmorAttributes = new(1, 2, 3);

            Slots slot2 = Slots.Legs;
            Armor cloth2 = new(armorName, requiredLevel, slot, armorType);
            cloth2.ArmorAttributes = new(3, 2, 1);

            mage.Equip(cloth, slot);
            mage.Equip(cloth2, slot2);

            HeroAttributes mageAttributes = new(1, 8, 1);
            HeroAttributes armorAttributesFromCloth = new(1, 2, 3);
            HeroAttributes armorAttributesFromCloth2 = new(3, 2, 1);
            HeroAttributes totalAttributes = mageAttributes + armorAttributesFromCloth + armorAttributesFromCloth2;

            HeroAttributes expected = totalAttributes;

            // Act
            HeroAttributes actual = mage.CalculateTotalAttributes();

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Fact]
        public void CalculateTotalAttributes_TotalAttributesOfMageWithReplacedPieceOfArmor_ShouldCorrectlyCalculateTotal()
        {
            // Arrange
            string heroName = "Tine";
            Mage mage = new(heroName);

            string armorName = "Cloth";
            int requiredLevel = 1;
            Slots slot = Slots.Body;
            ArmorTypes armorType = ArmorTypes.Cloth;
            Armor cloth = new(armorName, requiredLevel, slot, armorType);
            cloth.ArmorAttributes = new(1, 2, 3);

            Armor cloth2 = new(armorName, requiredLevel, slot, armorType);
            cloth2.ArmorAttributes = new(3, 2, 1);

            mage.Equip(cloth, slot);
            mage.Equip(cloth2, slot);

            HeroAttributes mageAttributes = new(1, 8, 1);
            HeroAttributes armorAttributesFromCloth2 = new(3, 2, 1);
            HeroAttributes totalAttributes = mageAttributes + armorAttributesFromCloth2;

            HeroAttributes expected = totalAttributes;

            // Act
            HeroAttributes actual = mage.CalculateTotalAttributes();

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
        #endregion
    }
}
