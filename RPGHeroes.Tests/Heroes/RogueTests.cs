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
    public class RogueTests
    {
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

        #region Level Up Rogue
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

        #region Equipping Rogue with Weapon
        [Fact]
        public void Equip_EquippingRogueWithValidWeapon_ShouldEquipValidWeaponType()
        {
            // Assert
            string heroName = "Tine";
            Rogue rogue = new(heroName);

            string weaponName = "Dagger";
            int requiredLevel = 1;
            int damage = 1;
            WeaponTypes weaponType = WeaponTypes.Dagger;
            Weapon dagger = new(weaponName, requiredLevel, damage, weaponType);
            Weapon expected = dagger;

            // Act
            rogue.Equip(dagger);
            Weapon actual = (Weapon)rogue.Equipment[Slots.Weapon];

            // Assert
            Assert.Equivalent(expected, actual, true);

        }

        [Fact]
        public void Equip_EquippingRogueWithInvalidWeapon_ShouldThrowInvalidWeaponException()
        {
            // Assert
            string heroName = "Tine";
            Rogue rogue = new(heroName);

            string weaponName = "Bow";
            int requiredLevel = 1;
            int damage = 1;
            WeaponTypes weaponType = WeaponTypes.Bow;
            Weapon bow = new(weaponName, requiredLevel, damage, weaponType);

            // Act and Assert
            Assert.Throws<InvalidWeaponException>(() => rogue.Equip(bow));
        }

        [Fact]
        public void Equip_EquippingRogueWithWeaponWithTooHighLevelRequirement_ShouldThrowInsufficientLevelException()
        {
            // Arrange
            string heroName = "Tine";
            Rogue rogue = new(heroName);

            string weaponName = "Dagger";
            int requiredLevel = 3;
            int damage = 1;
            WeaponTypes weaponType = WeaponTypes.Dagger;
            Weapon dagger = new(weaponName, requiredLevel, damage, weaponType);

            // Act and Assert
            Assert.Throws<InsufficientLevelException>(() => rogue.Equip(dagger));
        }
        #endregion

        #region Equipping Ranger with Armor
        [Fact]
        public void Equip_EquippingRogueWithValidArmor_ShouldEquipValidArmorType()
        {
            // Arrange
            string heroName = "Tine";
            Rogue rogue = new(heroName);

            string armorName = "Mail";
            int requiredLevel = 1;
            Slots slot = Slots.Body;
            ArmorTypes armorType = ArmorTypes.Mail;

            Armor mail = new(armorName, requiredLevel, slot, armorType);

            Armor expected = mail;

            // Act
            rogue.Equip(mail, slot);
            Armor actual = (Armor)rogue.Equipment[slot];

            // Assert
            Assert.Equivalent(expected, actual, true);

        }

        [Fact]
        public void Equip_EquippingRogueWithInvalidArmor_ShouldThrowInvalidArmorException()
        {
            // Arrange
            string heroName = "Tine";
            Rogue rogue = new(heroName);

            string armorName = "Plate";
            int requiredLevel = 1;
            Slots slot = Slots.Body;
            ArmorTypes armorType = ArmorTypes.Plate;
            Armor plate = new(armorName, requiredLevel, slot, armorType);

            // Act and Assert
            Assert.Throws<InvalidArmorException>(() => rogue.Equip(plate, slot));
        }

        [Fact]
        public void Equip_EquippingArmorWithTooHighLevelRequirement_ShouldThrowInsufficientLevelException()
        {
            string heroName = "Tine";
            Rogue rogue = new(heroName);

            string armorName = "Mail";
            int requiredLevel = 2;
            Slots slot = Slots.Body;
            ArmorTypes armorType = ArmorTypes.Mail;
            Armor mail = new(armorName, requiredLevel, slot, armorType);

            // Act and Assert
            Assert.Throws<InsufficientLevelException>(() => rogue.Equip(mail, slot));
        }
        #endregion

        #region Calculating Rogue's Total Attributes
        [Fact]
        public void CalculateTotalAttributes_TotalAttributesOfRogueWithNoEquipment_ShouldCorrectlyCalculateTotal()
        {
            // Arrange
            string heroName = "Tine";
            Rogue rogue = new(heroName);

            HeroAttributes rogueAttributes = new(2, 1, 6);
            HeroAttributes armorAttributes = new(0, 0, 0); // No armor equipped
            HeroAttributes totalAttributes = rogueAttributes + armorAttributes;

            HeroAttributes expected = totalAttributes;

            // Act
            HeroAttributes actual = rogue.CalculateTotalAttributes();

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Fact]
        public void CalculateTotalAttributes_TotalAttributesOfRogueWithOnePieceOfArmor_ShouldCorrectlyCalculateTotal()
        {
            // Arrange
            string heroName = "Tine";
            Rogue rogue = new(heroName);

            HeroAttributes rogueAttributes = new(2, 1, 6);

            string armorName = "Leather";
            int requiredLevel = 1;
            Slots slot = Slots.Body;
            ArmorTypes armorType = ArmorTypes.Leather;
            Armor leather = new(armorName, requiredLevel, slot, armorType);
            leather.ArmorAttributes = new(1, 0, 1);

            rogue.Equip(leather, slot);

            HeroAttributes leatherAttributes = new(1, 0, 1);
            HeroAttributes totalAttributes = rogueAttributes + leatherAttributes;

            HeroAttributes expected = totalAttributes;

            // Act
            HeroAttributes actual = rogue.CalculateTotalAttributes();

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Fact]
        public void CalculateTotalAttributes_TotalAttributesOfRogueWithTwoPiecesOfArmor_ShouldCorrectlyCalculateTotal()
        {
            // Arrange
            string heroName = "Tine";
            Rogue rogue = new(heroName);

            string armorName = "Leather";
            int requiredLevel = 1;
            Slots slot = Slots.Body;
            ArmorTypes armorType = ArmorTypes.Leather;
            Armor leather = new(armorName, requiredLevel, slot, armorType);
            leather.ArmorAttributes = new(0, 0, 1);

            string armorName2 = "Mail";
            int requiredLevel2 = 1;
            Slots slot2 = Slots.Legs;
            ArmorTypes armorType2 = ArmorTypes.Mail;
            Armor mail = new(armorName2, requiredLevel2, slot2, armorType2);
            mail.ArmorAttributes = new(1, 0, 1);

            rogue.Equip(leather, slot);
            rogue.Equip(mail, slot2);

            HeroAttributes rogueAttributes = new(2, 1, 6);
            HeroAttributes leatherAttributes = new(0, 0, 1);
            HeroAttributes mailAttributes = new(1, 0, 1);
            HeroAttributes totalAttributes = rogueAttributes + leatherAttributes + mailAttributes;

            HeroAttributes expected = totalAttributes;

            // Act
            HeroAttributes actual = rogue.CalculateTotalAttributes();

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Fact]
        public void CalculateTotalAttributes_TotalAttributesOfRogueWithReplacedPieceOfArmor_ShouldCorrectlyCalculateTotal()
        {
            // Arrange
            string heroName = "Tine";
            Rogue rogue = new(heroName);

            string armorName = "Leather";
            int requiredLevel = 1;
            Slots slot = Slots.Body;
            ArmorTypes armorType = ArmorTypes.Leather;
            Armor leather = new(armorName, requiredLevel, slot, armorType);
            leather.ArmorAttributes = new(1, 0,0);

            string armorName2 = "Mail";
            int requiredLevel2 = 1;
            Slots slot2 = Slots.Body;
            ArmorTypes armorType2 = ArmorTypes.Mail;
            Armor mail = new(armorName2, requiredLevel2, slot2, armorType2);
            mail.ArmorAttributes = new(0, 1, 0);

            rogue.Equip(leather, slot);
            rogue.Equip(mail, slot); // Replaces leather

            HeroAttributes rogueAttributes = new(2, 1, 6);
            HeroAttributes mailAttributes = new(0, 1, 0);
            HeroAttributes totalAttributes = rogueAttributes + mailAttributes;

            HeroAttributes expected = totalAttributes;

            // Act
            HeroAttributes actual = rogue.CalculateTotalAttributes();

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
        #endregion

        #region Calculating Rogue's Hero Damage
        [Fact]
        public void CalculateDamage_CalculateRogueDamageWithNoWeaponEquipped_ShouldCorrectlyCalculateDamage()
        {
            string heroName = "Tine";
            Rogue rogue = new(heroName);

            int weaponDamage = 1; // No weapon equipped
            int damagingAttribute = 6;
            int heroDamage = weaponDamage * (1 + damagingAttribute / 100);

            double expected = heroDamage;

            // Act
            double actual = rogue.CalculateDamage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateDamage_CalculateRogueDamageWithWeaponEquipped_ShouldCorrectlyCalculateDamage()
        {
            string heroName = "Tine";
            Rogue rogue = new(heroName);

            string weaponName = "Sword";
            int requiredLevel = 1;
            int damage = 6;
            WeaponTypes weaponType = WeaponTypes.Sword;
            Weapon sword = new(weaponName, requiredLevel, damage, weaponType);

            rogue.Equip(sword);

            int weaponDamage = 6; // Weapon equipped
            int damagingAttribute = 6;
            int heroDamage = weaponDamage * (1 + damagingAttribute / 100);

            double expected = heroDamage;

            // Act
            double actual = rogue.CalculateDamage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateDamage_CalculateMageDamageWithReplacedWeapon_ShouldCorrectlyCalculateDamage()
        {
            string heroName = "Tine";
            Rogue rogue = new(heroName);

            string weaponName = "Sword";
            int requiredLevel = 1;
            int damage = 6;
            WeaponTypes weaponType = WeaponTypes.Sword;
            Weapon sword = new(weaponName, requiredLevel, damage, weaponType);

            rogue.Equip(sword);

            string weaponName2 = "Dagger";
            int requiredLevel2 = 1;
            int damage2 = 3;
            WeaponTypes weaponType2 = WeaponTypes.Dagger;
            Weapon dagger = new(weaponName2, requiredLevel2, damage2, weaponType2);

            rogue.Equip(dagger);

            int weaponDamage = 3; // Weapon equipped
            int damagingAttribute = 7;
            int heroDamage = weaponDamage * (1 + damagingAttribute / 100);

            double expected = heroDamage;

            // Act
            double actual = rogue.CalculateDamage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateDamage_CalculateMageDamageWithWeaponAndArmorEquipped_ShouldCorrectlyCalculateDamage()
        {
            string heroName = "Tine";
            Rogue rogue = new(heroName);

            string weaponName = "Sword";
            int requiredLevel = 1;
            int damage = 6;
            WeaponTypes weaponType = WeaponTypes.Sword;
            Weapon sword = new(weaponName, requiredLevel, damage, weaponType);

            rogue.Equip(sword);

            string armorName = "Mail";
            int requiredLevelCloth = 1;
            Slots slot = Slots.Body;
            ArmorTypes armorType = ArmorTypes.Mail;
            Armor mail = new(armorName, requiredLevelCloth, slot, armorType);
            HeroAttributes mailAttributes = new(0, 0, 3);
            mail.ArmorAttributes = mailAttributes;

            rogue.Equip(mail, slot);

            int weaponDamage = 6; // Weapon equipped
            int initialIntelligence = 7;
            int increasedDamageWithMail = 3;
            int damagingAttribute = initialIntelligence + increasedDamageWithMail;
            int heroDamage = weaponDamage * (1 + damagingAttribute / 100);

            double expected = heroDamage;

            // Act
            double actual = rogue.CalculateDamage();

            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion
    }
}
