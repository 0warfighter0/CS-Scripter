using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginalWar
{
    public class Unit
    {
        private string ID;
        private UnitType Type;
        private Nation Nation;
        private int Side;
        private int Lives;

        public Unit() { }
        public Unit(int side, Nation nation, UnitType unitType)
        {
            Side = side;
            Nation = nation;
            Type = unitType;
        }

        public void KillUnit() { }
        public void PlaceUnitXY(int x, int y, bool materialisation) { }
        public void PlaceUnitArea(Area area, bool materialisation) { }
        public void PlaceUnitXYR(int x, int y, int r, bool materialisation) { }
        public void PlaceUnitAnywhere(bool materialisation) { }

        public Unit NearestUnitToUnit() { return null; }

        public void SetSide(int side) { }
        public int GetSide() { return Side; }

        public void SetLives(int lives) { }
        public int GetLives() { return Lives; }

        public void SetDir(int dir) { }

        public Nation GetNation() { return Nation; }
        public string GetIdent() { return ID; }

        public int GetBType() { return -1; }
        public int GetBLevel() { return -1; }
        public int GetBase() { return 0; }

        // Commands
        //set of units receives move command to specified coordinates
        public void ComMoveXY(int x, int y) { }
        public static void ComMoveXY(List<Unit> units, int x, int y)
        { }

        public void ComMoveUnit(Unit unit) { }
        public void ComMoveToArea(Area area) { }
        public void ComAgressiveMove(int x, int y) { }
        public void ComAttackUnit(Unit unit) { }
        public void ComAttackPlace(int x, int y) { }
        public void ComCollect(int x, int y) { }
        public void ComTurnXY(int x, int y) { }
        public void ComTurnUnit(Unit unit) { }
        public void ComEnterUnit(Unit unit) { }
        public void ComExitVehicle() { }
        public void ComExitBuilding() { }
        public void ComChangeProfession(Class profession) { }
        public void ComResearch(Technology tech) { }
        public void ComConstruct(ChassisType chassis, EngineType engine, ControlType control, WeaponType weapon) { }
        public void ComPause() { }
        public void ComCancel() { }
        public void ComHeal(Human human) { }
        public void ComRepairVehicle(Vehicle vehicle) { }
        public void ComRepairBuilding(Building buiding) { }
        public void ComTameXY(int x, int y) { }
        public void ComPlaceDelayedCharge(int x, int y, Unit unit) { }
        public void ComPlaceRemoteCharge(int x, int y, Unit unit) { }
        public void ComFireExplosives() { }
        public void ComLinkTo(Human human) { }
        public void ComUnlink() { }
        public void ComCrawl() { }
        public void ComWalk() { }
        public void ComFree() { }
        public void ComHold() { }
        public void ComStop() { }
        public void ComWait(int time) { }
        public void ComRemember() { }
        public void ComReturn() { }
        public void ComBuild(BuildingType buildingType, int x, int y, int dir) { }
        public void ComUpgrade() { }
        public void ComUpgradeLab(BuildingType labType) { }
        public void ComPlaceWeapon(WeaponType weaponType) { }
        public void ComAnim(int aType) { }
        public void ComRefuel(Unit unit) { }
        public void ComTransport(Unit unit, Material material) { }
        public void ComInvisible() { }
        public void ComSpaceShift(int x, int y) { }
        public void ComTimeShift(int x, int y) { }
        public void ComHack(Unit unit) { }
        public void ComTeleportExit(int x, int y, Unit unit) { }
        public void ComHiddenCamera(int x, int y) { }
        public void ComContaminate(int x, int y) { }
        public void ComUnload() { }
        public void ComGet(int x, int y) { }
        public void ComGive(Unit unit) { }
        public void ComCarabine() { }
        public void ComSabre() { }
        public void ComSailEvent(int num) { }
        public void ComStand() { }
        public void ComAttackSoporific(Unit unit) { }
        public void ComDismantle(Unit unit) { }
        public void ComRecycle(Unit unit) { }
        public void ComLinkToBase(Unit unit) { }
        public void ComBuildBehemoth(BuildingType building, int x, int y, int dir) { }

        public void AddComMoveUnit(Unit unit) { }
        public void AddComMoveToArea(Area area) { }
        public void AddComAgressiveMove(int x, int y) { }
        public void AddComAttackUnit(Unit unit) { }
        public void AddComAttackPlace(int x, int y) { }
        public void AddComCollect(int x, int y) { }
        public void AddComTurnXY(int x, int y) { }
        public void AddComTurnUnit(Unit unit) { }
        public void AddComEnterUnit(Unit unit) { }
        public void AddComExitVehicle() { }
        public void AddComExitBuilding() { }
        public void AddComChangeProfession(Class profession) { }
        public void AddComResearch(Technology tech) { }
        public void AddComConstruct(ChassisType chassis, EngineType engine, ControlType control, WeaponType weapon) { }
        public void AddComPause() { }
        public void AddComCancel() { }
        public void AddComHeal(Human human) { }
        public void AddComRepairVehicle(Vehicle vehicle) { }
        public void AddComRepairBuilding(Building buiding) { }
        public void AddComTameXY(int x, int y) { }
        public void AddComPlaceDelayedCharge(int x, int y, Unit unit) { }
        public void AddComPlaceRemoteCharge(int x, int y, Unit unit) { }
        public void AddComFireExplosives() { }
        public void AddComLinkTo(Human human) { }
        public void AddComUnlink() { }
        public void AddComCrawl() { }
        public void AddComWalk() { }
        public void AddComFree() { }
        public void AddComHold() { }
        public void AddComStop() { }
        public void AddComWait(int time) { }
        public void AddComRemember() { }
        public void AddComReturn() { }
        public void AddComBuild(BuildingType buildingType, int x, int y, int dir) { }
        public void AddComUpgrade() { }
        public void AddComUpgradeLab(BuildingType labType) { }
        public void AddComPlaceWeapon(WeaponType weaponType) { }
        public void AddComAnim(int aType) { }
        public void AddComRefuel(Unit unit) { }
        public void AddComTransport(Unit unit, Material material) { }
        public void AddComInvisible() { }
        public void AddComSpaceShift(int x, int y) { }
        public void AddComTimeShift(int x, int y) { }
        public void AddComHack(Unit unit) { }
        public void AddComTeleportExit(int x, int y, Unit unit) { }
        public void AddComHiddenCamera(int x, int y) { }
        public void AddComContaminate(int x, int y) { }
        public void AddComUnload() { }
        public void AddComGet(int x, int y) { }
        public void AddComGive(Unit unit) { }
        public void AddComCarabine() { }
        public void AddComSabre() { }
        public void AddComSailEvent(int num) { }
        public void AddComStand() { }
        public void AddComAttackSoporific(Unit unit) { }
        public void AddComDismantle(Unit unit) { }
        public void AddComRecycle(Unit unit) { }
        public void AddComLinkToBase(Unit unit) { }
        public void AddComBuildBehemoth(BuildingType building, int x, int y, int dir) { }
    }

    public enum UnitType : int
    {
        unit_human = 1,
        unit_vehicle = 2,
        unit_building = 3,
        unit_crate = 4
    }

    public enum Nation : int
    {
        nation_nature = 0,
        nation_american = 1,
        nation_arabian = 2,
        nation_russian = 3
    }

    public enum Attitude : int
    {
        att_neutral = 0,
        att_friend = 1,
        att_enemy = 2
    }
}
