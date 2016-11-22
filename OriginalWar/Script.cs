using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginalWar
{
    public class Script
    {
        // Entry point
        public static void Starting() { }
        public static void Wait(int minutes, int seconds) { }

        public static int Rand(int min, int max) { return 0; }
        public static void Randomize() { }
        public static void RandomizeAll() { }

        public static void CreateCratesXY(int amount, int x, int y, bool materialisation) { }
        public static void CreateCratesArea(int amount, Area area, bool materialisation) { }
        public static List<Unit> FilterAllUnits(Filter[] filters) { return null; }


        public class Filter
        {
            public Filter(FilterType filterType, int filterValue)
            {
                FilterType = filterType;
                FilterValue = filterValue;
            }
            public Filter(FilterType filterType)
            {
                FilterType = filterType;
                FilterValue = 0;
            }
            FilterType FilterType;
            int FilterValue;
        }
        public enum FilterType : int
        {
            f_and = 1,
            f_or = 2,
            f_not = 3,
            f_type = 21,
            f_side = 22,
            f_nation = 23,
            f_lives = 24,
            f_class = 25,
            f_sex = 26,
            f_minskill = 28,
            f_maxskill = 29,
            f_btype = 30,
            f_chassis = 31,
            f_engine = 32,
            f_control = 33,
            f_weapon = 34,
            f_bweapon = 35,
            f_ok = 50,
            f_alive = 51,
            f_placed = 52,
            f_ready = 53,
            f_inside = 54,
            f_driving = 55,
            f_outside = 56,
            f_constructed = 57,
            f_empty = 58,
            f_occupied = 59,
            f_hastask = 60,
            f_linked = 61,
            f_enemy = 81,
            f_ally = 82,
            f_neutral = 83,
            f_dist = 91,
            f_distxy = 92,
            f_inarea = 95,
            f_exceptarea = 96,
            f_see = 101
        }
    }
}
