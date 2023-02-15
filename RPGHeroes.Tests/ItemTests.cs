using RPGHeroes.Enums;
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

namespace RPGHeroes.Tests
{
    public class ItemTests
    {
        #region Weapon Creation
        [Fact]
        public void Constructor_InitializeWeapon_ShouldInitializeWithCorrectName()
        {
            // Arrange
            string name = "Axe";
            int requiredLevel = 1;
            int damage = 1;
            string expected = name;

            // Act
            Weapon axe = new(name, requiredLevel, damage);
            string actual = axe.Name;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_InitializeWeapon_ShouldInitializeWithCorrectRequiredLevel()
        {
            // Arrange
            string name = "Axe";
            int requiredLevel = 1;
            int damage = 1;
            int expected = requiredLevel;

            // Act
            Weapon axe = new(name, requiredLevel, damage);
            int actual = axe.RequiredLevel;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_InitializeWeapon_ShouldInitializeWithCorrectSlot()
        {
            // Arrange
            string name = "Axe";
            int requiredLevel = 1;
            int damage = 1;
            Slots slot = SlotsEnum.Slots.Weapon;
            Slots expected = slot;

            // Act
            Weapon axe = new(name, requiredLevel, damage);
            Slots actual = axe.Slot;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_InitializeWeapon_ShouldInitializeWithCorrectWeaponType()
        {
            // Arrange
            string name = "Axe";
            int requiredLevel = 1;
            int damage = 1;
            WeaponTypes weaponType = WeaponsEnum.WeaponTypes.Axe;
            WeaponTypes expected = weaponType;

            // Act
            Weapon axe = new(name, requiredLevel, damage);
            WeaponTypes actual = axe.WeaponType;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_InitializeWeapon_ShouldInitializeWithCorrectDamage()
        {
            // Arrange
            string name = "Axe";
            int requiredLevel = 1;
            int damage = 1;
            int expected = damage;
            
            // Act
            Weapon axe = new(name, requiredLevel, damage);
            int actual = axe.Damage;

            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region Armor Creation
        [Fact]
        public void Constructor_InitializeArmor_ShouldInitializeWithCorrectName()
        {
            // Arrange
            string name = "Cloth";
            int requiredLevel = 1;
            Slots slot = SlotsEnum.Slots.Body;
            ArmorTypes armorType = ArmorsEnum.ArmorTypes.Cloth;
            string expected = name;

            // Act
            Armor cloth = new(name, requiredLevel, slot, armorType);
            string actual = cloth.Name;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_InitializeArmor_ShouldInitializeWithCorrectRequiredLevel()
        {
            // Arrange
            string name = "Cloth";
            int requiredLevel = 1;
            Slots slot = SlotsEnum.Slots.Body;
            ArmorTypes armorType = ArmorsEnum.ArmorTypes.Cloth;
            int expected = requiredLevel;

            // Act
            Armor cloth = new(name, requiredLevel, slot, armorType);
            int actual = cloth.RequiredLevel;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_InitializeArmor_ShouldInitializeWithCorrectSlot()
        {
            // Arrange
            string name = "Cloth";
            int requiredLevel = 1;
            Slots slot = SlotsEnum.Slots.Body;
            ArmorTypes armorType = ArmorsEnum.ArmorTypes.Cloth;
            Slots expected = slot;

            // Act
            Armor cloth = new(name, requiredLevel, slot, armorType);
            Slots actual = cloth.Slot;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_InitializeArmor_ShouldInitializeWithCorrectArmorType()
        {
            // Arrange            
            string name = "Cloth";
            int requiredLevel = 1;
            Slots slot = SlotsEnum.Slots.Body;
            ArmorTypes armorType = ArmorsEnum.ArmorTypes.Cloth;
            ArmorTypes expected = armorType;

            // Act
            Armor cloth = new(name, requiredLevel, slot, armorType);
            ArmorTypes actual = cloth.ArmorType;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_InitializeArmor_ShouldInitializeWithCorrectArmorAttributes()
        {
            // Arrange
            string name = "Cloth";
            int requiredLevel = 1;
            Slots slot = SlotsEnum.Slots.Body;
            ArmorTypes armorType = ArmorsEnum.ArmorTypes.Cloth;
            HeroAttributes armorAttributes = new(0, 0, 0);
            HeroAttributes expected = armorAttributes;

            // Act
            Armor cloth = new(name, requiredLevel, slot, armorType);
            HeroAttributes actual = cloth.ArmorAttributes;

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
        #endregion
    }
}
