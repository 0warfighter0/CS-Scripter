using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginalWar
{
    public class Vehicle : Unit
    {
        EngineType EngineType;
        ControlType ControlType;
        ChassisType ChassisType;
        WeaponType WeaponType;

        int Fuel;

        public int GetFuel() { return Fuel; }
        public EngineType GetEngine() { return EngineType; }
        public ControlType GetControl() { return ControlType; }
        public WeaponType GetWeapon() { return WeaponType; }
        public ChassisType GetChassis() { return ChassisType; }

    }

    public enum EngineType : int
    {
        engine_combustion = 1,
        engine_solar = 2,
        engine_siberite = 3
    }

    public enum ControlType : int
    {
        control_manual = 1,
        control_remote = 2,
        control_computer = 3,
        control_rider = 4,
        control_apeman = 5
    }

    public enum ChassisType : int
    {
        US_light_wheeled = 1,
        US_medium_wheeled = 2,
        US_medium_tracked = 3,
        US_heavy_tracked = 4,
        US_morphling = 5,
        AR_hovercraft = 11,
        AR_light_trike = 12,
        AR_medium_trike = 13,
        AR_half_tracked = 14,
        RU_medium_wheeled = 21,
        RU_medium_tracked = 22,
        RU_heavy_wheeled = 23,
        RU_heavy_tracked = 24
    }

    public enum WeaponType : int
    {
        US_machine_gun = 2,
        US_light_gun = 3,
        US_gatling_gun = 4,
        US_double_gun = 5,
        US_heavy_gun = 6,
        US_rocket_launcher = 7,
        US_siberium_rocket = 8,
        US_siberium_rocket_remainder = 15,
        US_laser = 9,
        US_double_laser = 10,
        US_radar = 11,
        US_cargo_bay = 12,
        US_crane = 13,
        US_bulldozer = 14,
        AR_multimissile_ballista = 22,
        AR_light_gun = 23,
        AR_double_machine_gun = 24,
        AR_gatling_gun = 25,
        AR_flame_thrower = 26,
        AR_gun = 27,
        AR_rocket_launcher = 28,
        AR_selfpropelled_bomb = 29,
        AR_radar = 30,
        AR_control_tower = 31,
        AR_cargo_bay = 32,
        RU_heavy_machine_gun = 42,
        RU_gatling_gun = 43,
        RU_gun = 44,
        RU_rocket_launcher = 45,
        RU_heavy_gun = 46,
        RU_rocket = 47,
        RU_siberium_rocket = 48,
        RU_siberium_rocket_remainder = 55,
        RU_time_lapser = 49,
        RU_cargo_bay = 51,
        RU_crane = 52,
        RU_bulldozer = 53
    }
}
