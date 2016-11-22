using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginalWar
{
    public class Building : Unit
    {
        BuildingType BuildingType;
        WeaponType WeaponType;

        public int GetLabKind() { return 1; }
        public WeaponType GetBWeapon() { return WeaponType; }
        public int[][] GetExtPositions() { return new int[][] { new int[] { 0, 0 }, new int[] { 0, 0 }, new int[] { 0, 0 }, new int[] { 0, 0 }, new int[] { 0, 0 }, }; }

    }

    public enum BuildingType : int
    {
        b_depot = 0,
        b_warehouse = 1,
        b_workshop = 2,
        b_factory = 3,
        b_armoury = 4,
        b_barracks = 5,
        b_lab = 6,
        b_lab_half = 7,
        b_lab_full = 8,
        b_lab_basic = 9,
        b_lab_weapon = 10,
        b_lab_siberium = 11,
        b_lab_computer = 12,
        b_lab_biological = 13,
        b_lab_spacetime = 14,
        b_lab_opto = 15,
        b_ext_track = 16,
        b_ext_gun = 17,
        b_ext_rocket = 18,
        b_ext_noncombat = 19,
        b_ext_radar = 20,
        b_ext_siberium = 21,
        b_ext_radio = 22,
        b_ext_stitch = 23,
        b_ext_computer = 24,
        b_ext_laser = 25,
        b_oil_power = 26,
        b_solar_power = 27,
        b_siberite_power = 28,
        b_oil_mine = 29,
        b_siberite_mine = 30,
        b_breastwork = 31,
        b_bunker = 32,
        b_turret = 33,
        b_teleport = 34,
        b_fort = 35,
        b_control_tower = 36,
        b_eon = 38,
        b_behemoth = 37,
        b_alien_tower = 39
    }
}
