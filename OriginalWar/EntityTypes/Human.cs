using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginalWar
{
    public class Human : Unit
    {
        string Name;
        int Importance;
        int Strength;
        int Speed;
        Sex Sex;
        Class ClassType;

        int[] Skills = new int[Enum.GetNames(typeof(Skill)).Length];
        int[] Attributes = new int[Enum.GetNames(typeof(Attribute)).Length];

        public Human()
        {

        }

        public Human(int side, Nation nation, Class classType, Sex sex) : base(side, nation, UnitType.unit_human)
        {
            ClassType = classType;
            Sex = sex;
        }
        public Human(int side, Nation nation, Class classType, Sex sex, string name) : this(side, nation, classType, sex)
        {
            Name = name;
        }

        public void SetSkill(Skill skill, int level) { }
        public int[] GetSkill() { return Skills; }

        public int[] GetAttr() { return Attributes; }

        public Class GetClass() { return ClassType; }

        public Sex GetSex() { return Sex; }

    }

    public enum Class : int
    {
        class_soldier = 1,
        class_engineer = 2,
        class_mechanic = 3,
        class_scientistic = 4,
        class_sniper = 5,
        class_mortar = 8,
        class_bazooker = 9,
        class_desert_warior = 11,
        class_apeman = 12,
        class_baggie = 13,
        class_tiger = 14,
        class_apeman_soldier = 15,
        class_apeman_engineer = 16,
        class_apeman_kamikaze = 17,
        class_phororhacos = 18
    }

    public enum Sex : int
    {
        sex_male = 1,
        sex_female = 2

    }

    public enum Skill : int
    {
        skill_combat = 1,
        skill_engineering = 2,
        skill_mechanical = 3,
        skill_scientistic = 4
    }

    public enum Attribute : int
    {
        attr_stamina = 1,
        attr_speed = 2
    }
}
