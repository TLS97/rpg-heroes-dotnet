using RPGHeroes.Heroes;
using RPGHeroes.Items;
using static RPGHeroes.Enums.ArmorsEnum;

namespace RPGHeroes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "Tine";
            Mage mage = new(name);

            Armor armor = new(name, 1, Enums.SlotsEnum.Slots.Body, ArmorTypes.Cloth);
            mage.Equip(armor, Enums.SlotsEnum.Slots.Body);
            mage.Equip(armor, Enums.SlotsEnum.Slots.Legs);
            mage.CalculateTotalAttributes();


        }
    }
}