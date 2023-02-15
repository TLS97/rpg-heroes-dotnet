using RPGHeroes.Enums;
using RPGHeroes.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Enum slot = SlotsEnum.Slots.Weapon;
            Enum expected = slot;

            // Act
            Weapon axe = new(name, requiredLevel, damage);
            Enum actual = axe.Slot;

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

    }
}
