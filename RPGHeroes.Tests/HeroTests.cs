using RPGHeroes.Enums;
using RPGHeroes.Exceptions;
using RPGHeroes.Heroes;
using RPGHeroes.Items;
using static RPGHeroes.Enums.ArmorsEnum;
using static RPGHeroes.Enums.SlotsEnum;
using static RPGHeroes.Enums.WeaponsEnum;

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

        #region Equipping Hero with Weapon
        #region Mage
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

        #region Ranger
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

        #region Rogue
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

        #region Warrior
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

        #endregion

        #region Equipping Hero with Armor
        #region Mage
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

        #region Ranger
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

        #region Rogue
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

        #region Warrior
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

        #endregion

    }
}