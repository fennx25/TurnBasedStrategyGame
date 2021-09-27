
using System;
using System.Xml.Serialization;
using System.Collections.Generic;

//https://xmltocsharp.azurewebsites.net
namespace Adv
{
    [XmlRoot(ElementName = "Pos")]
    public class Pos
    {
        [XmlElement(ElementName = "x")]
        public float X { get; set; }
        [XmlElement(ElementName = "y")]
        public float Y { get; set; }
        [XmlElement(ElementName = "z")]
        public float Z { get; set; }
    }

    [XmlRoot(ElementName = "Shared")]
    public class Shared
    {
        [XmlAttribute(AttributeName = "href")]
        public string Href { get; set; }
    }

    [XmlRoot(ElementName = "Action")]
    public class Action
    {
        [XmlElement(ElementName = "FunctionName")]
        public string FunctionName { get; set; }
    }

    [XmlRoot(ElementName = "CaptureTrigger")]
    public class CaptureTrigger
    {
        [XmlElement(ElementName = "Action")]
        public Action Action { get; set; }
    }

    [XmlRoot(ElementName = "AdvMapBuilding")]
    public class AdvMapBuilding
    {
        [XmlElement(ElementName = "Pos")]
        public Pos Pos { get; set; }
        [XmlElement(ElementName = "Rot")]
        public string Rot { get; set; }
        [XmlElement(ElementName = "Floor")]
        public string Floor { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "CombatScript")]
        public string CombatScript { get; set; }
        [XmlElement(ElementName = "Shared")]
        public Shared Shared { get; set; }
        [XmlElement(ElementName = "PlayerID")]
        public string PlayerID { get; set; }
        [XmlElement(ElementName = "CaptureTrigger")]
        public CaptureTrigger CaptureTrigger { get; set; }
        [XmlElement(ElementName = "GroupID")]
        public string GroupID { get; set; }
        [XmlAttribute(AttributeName = "ObjectRecordID")]
        public string ObjectRecordID { get; set; }
        [XmlElement(ElementName = "pointLights")]
        public PointLights PointLights { get; set; }
    }



    [XmlRoot(ElementName = "MessageFileRef")]
    public class MessageFileRef
    {
        [XmlAttribute(AttributeName = "href")]
        public string Href { get; set; }
    }

    [XmlRoot(ElementName = "AdvMapTreasure")]
    public class AdvMapTreasure
    {
        [XmlElement(ElementName = "Pos")]
        public Pos Pos { get; set; }
        [XmlElement(ElementName = "Rot")]
        public string Rot { get; set; }
        [XmlElement(ElementName = "Floor")]
        public string Floor { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "CombatScript")]
        public string CombatScript { get; set; }
        [XmlElement(ElementName = "Shared")]
        public Shared Shared { get; set; }
        [XmlElement(ElementName = "IsCustom")]
        public string IsCustom { get; set; }
        [XmlElement(ElementName = "Amount")]
        public string Amount { get; set; }
        [XmlElement(ElementName = "MessageFileRef")]
        public MessageFileRef MessageFileRef { get; set; }
        [XmlAttribute(AttributeName = "ObjectRecordID")]
        public string ObjectRecordID { get; set; }
        [XmlElement(ElementName = "pointLights")]
        public PointLights PointLights { get; set; }
    }

    [XmlRoot(ElementName = "HeroDeployTrigger")]
    public class HeroDeployTrigger
    {
        [XmlElement(ElementName = "Action")]
        public Action Action { get; set; }
    }

    [XmlRoot(ElementName = "ShipTile")]
    public class ShipTile
    {
        [XmlElement(ElementName = "x")]
        public string X { get; set; }
        [XmlElement(ElementName = "y")]
        public string Y { get; set; }
    }

    [XmlRoot(ElementName = "Specialization")]
    public class Specialization
    {
        [XmlAttribute(AttributeName = "href")]
        public string Href { get; set; }
    }

    [XmlRoot(ElementName = "NameFileRef")]
    public class NameFileRef
    {
        [XmlAttribute(AttributeName = "href")]
        public string Href { get; set; }
    }

    [XmlRoot(ElementName = "BiographyFileRef")]
    public class BiographyFileRef
    {
        [XmlAttribute(AttributeName = "href")]
        public string Href { get; set; }
    }

    [XmlRoot(ElementName = "Editable")]
    public class Editable
    {
        [XmlElement(ElementName = "NameFileRef")]
        public NameFileRef NameFileRef { get; set; }
        [XmlElement(ElementName = "BiographyFileRef")]
        public BiographyFileRef BiographyFileRef { get; set; }
        [XmlElement(ElementName = "Offence")]
        public string Offence { get; set; }
        [XmlElement(ElementName = "Defence")]
        public string Defence { get; set; }
        [XmlElement(ElementName = "Spellpower")]
        public string Spellpower { get; set; }
        [XmlElement(ElementName = "Knowledge")]
        public string Knowledge { get; set; }
        [XmlElement(ElementName = "skills")]
        public string Skills { get; set; }
        [XmlElement(ElementName = "spellIDs")]
        public string SpellIDs { get; set; }
        [XmlElement(ElementName = "Ballista")]
        public string Ballista { get; set; }
        [XmlElement(ElementName = "FirstAidTent")]
        public string FirstAidTent { get; set; }
        [XmlElement(ElementName = "AmmoCart")]
        public string AmmoCart { get; set; }
        [XmlElement(ElementName = "FavoriteEnemies")]
        public string FavoriteEnemies { get; set; }
        [XmlElement(ElementName = "perkIDs")]
        public PerkIDs PerkIDs { get; set; }
    }

    [XmlRoot(ElementName = "armySlots")]
    public class ArmySlots
    {
        [XmlElement(ElementName = "Item")]
        public List<ArmySlot> Item { get; set; }
    }

    [XmlRoot(ElementName = "CaptionFileRef")]
    public class CaptionFileRef
    {
        [XmlAttribute(AttributeName = "href")]
        public string Href { get; set; }
    }

    [XmlRoot(ElementName = "AdvMapTown")]
    public class AdvMapTown
    {
       
        public Pos Pos { get; set; }
        public float Rot { get; set; }
        public int Floor { get; set; }
        public string Name { get; set; }
        public string CombatScript { get; set; }

        [XmlElement(ElementName = "pointLights")]
        public string PointLights { get; set; }
        [XmlElement(ElementName = "Shared")]
        public Shared Shared { get; set; }
        [XmlElement(ElementName = "PlayerID")]
        public string PlayerID { get; set; }
        [XmlElement(ElementName = "CaptureTrigger")]
        public CaptureTrigger CaptureTrigger { get; set; }
        [XmlElement(ElementName = "HeroDeployTrigger")]
        public HeroDeployTrigger HeroDeployTrigger { get; set; }
        [XmlElement(ElementName = "ShipTile")]
        public ShipTile ShipTile { get; set; }
        [XmlElement(ElementName = "Specialization")]
        public Specialization Specialization { get; set; }
        [XmlElement(ElementName = "Editable")]
        public Editable Editable { get; set; }
        [XmlElement(ElementName = "armySlots")]
        public ArmySlots ArmySlots { get; set; }
        [XmlElement(ElementName = "spellIDs")]
        public string SpellIDs { get; set; }
        [XmlElement(ElementName = "CaptionFileRef")]
        public CaptionFileRef CaptionFileRef { get; set; }
        [XmlElement(ElementName = "GarrisonHero")]
        public string GarrisonHero { get; set; }
        [XmlElement(ElementName = "Script")]
        public string Script { get; set; }
        [XmlElement(ElementName = "RndSource")]
        public string RndSource { get; set; }
        [XmlElement(ElementName = "LinkToPlayer")]
        public string LinkToPlayer { get; set; }
        [XmlElement(ElementName = "LinkToTown")]
        public string LinkToTown { get; set; }
        [XmlElement(ElementName = "CanCaptureOnlyNotVisit")]
        public string CanCaptureOnlyNotVisit { get; set; }
        [XmlElement(ElementName = "AllowQuickCombat")]
        public string AllowQuickCombat { get; set; }
        [XmlAttribute(AttributeName = "ObjectRecordID")]
        public string ObjectRecordID { get; set; }
        [XmlElement(ElementName = "buildings")]
        public Buildings Buildings { get; set; }
    }

    [XmlRoot(ElementName = "AdvMapMine")]
    public class AdvMapMine
    {
        [XmlElement(ElementName = "Pos")]
        public Pos Pos { get; set; }
        [XmlElement(ElementName = "Rot")]
        public string Rot { get; set; }
        [XmlElement(ElementName = "Floor")]
        public string Floor { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "CombatScript")]
        public string CombatScript { get; set; }
        [XmlElement(ElementName = "Shared")]
        public Shared Shared { get; set; }
        [XmlElement(ElementName = "PlayerID")]
        public string PlayerID { get; set; }
        [XmlElement(ElementName = "CaptureTrigger")]
        public CaptureTrigger CaptureTrigger { get; set; }
        [XmlElement(ElementName = "armySlots")]
        public string ArmySlots { get; set; }
        [XmlAttribute(AttributeName = "ObjectRecordID")]
        public string ObjectRecordID { get; set; }
        [XmlElement(ElementName = "pointLights")]
        public PointLights PointLights { get; set; }
    }

    [XmlRoot(ElementName = "AdvMapGarrison")]
    public class AdvMapGarrison
    {
        [XmlElement(ElementName = "Pos")]
        public Pos Pos { get; set; }
        [XmlElement(ElementName = "Rot")]
        public string Rot { get; set; }
        [XmlElement(ElementName = "Floor")]
        public string Floor { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "CombatScript")]
        public string CombatScript { get; set; }
        [XmlElement(ElementName = "Shared")]
        public Shared Shared { get; set; }
        [XmlElement(ElementName = "PlayerID")]
        public string PlayerID { get; set; }
        [XmlElement(ElementName = "CaptureTrigger")]
        public CaptureTrigger CaptureTrigger { get; set; }
        [XmlElement(ElementName = "armySlots")]
        public ArmySlots ArmySlots { get; set; }
        [XmlElement(ElementName = "CollectableArmy")]
        public string CollectableArmy { get; set; }
        [XmlElement(ElementName = "AllowQuickCombat")]
        public string AllowQuickCombat { get; set; }
        [XmlAttribute(AttributeName = "ObjectRecordID")]
        public string ObjectRecordID { get; set; }
        [XmlElement(ElementName = "pointLights")]
        public PointLights PointLights { get; set; }
    }

    public class Resources
    {
        public int Wood { get; set; }
        public int Ore { get; set; }
        public int Mercury { get; set; }
        public int Crystal { get; set; }
        public int Sulfur { get; set; }    
        public int Gem { get; set; }
        public int Gold { get; set; }

    }

    [XmlRoot(ElementName = "AdvMapMonster")]
    public class AdvMapMonster
    {
        [XmlElement(ElementName = "Pos")]
        public Pos Pos { get; set; }
        [XmlElement(ElementName = "Rot")]
        public string Rot { get; set; }
        [XmlElement(ElementName = "Floor")]
        public string Floor { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "CombatScript")]
        public string CombatScript { get; set; }
        [XmlElement(ElementName = "pointLights")]
        public string PointLights { get; set; }
        [XmlElement(ElementName = "Shared")]
        public Shared Shared { get; set; }
        [XmlElement(ElementName = "Custom")]
        public string Custom { get; set; }
        [XmlElement(ElementName = "Amount")]
        public string Amount { get; set; }
        [XmlElement(ElementName = "Amount2")]
        public string Amount2 { get; set; }
        [XmlElement(ElementName = "AttackType")]
        public string AttackType { get; set; }
        [XmlElement(ElementName = "MoveType")]
        public string MoveType { get; set; }
        [XmlElement(ElementName = "DoesNotGrow")]
        public string DoesNotGrow { get; set; }
        [XmlElement(ElementName = "MessageFileRef")]
        public MessageFileRef MessageFileRef { get; set; }
        [XmlElement(ElementName = "Script")]
        public string Script { get; set; }
        [XmlElement(ElementName = "Resources")]
        public Resources Resources { get; set; }
        [XmlElement(ElementName = "ArtifactID")]
        public string ArtifactID { get; set; }
        [XmlElement(ElementName = "Mood")]
        public string Mood { get; set; }
        [XmlElement(ElementName = "Courage")]
        public string Courage { get; set; }
        [XmlElement(ElementName = "AllowQuickCombat")]
        public string AllowQuickCombat { get; set; }
        [XmlAttribute(AttributeName = "ObjectRecordID")]
        public string ObjectRecordID { get; set; }
    }

    [XmlRoot(ElementName = "AdvMapShrine")]
    public class AdvMapShrine
    {
        [XmlElement(ElementName = "Pos")]
        public Pos Pos { get; set; }
        [XmlElement(ElementName = "Rot")]
        public string Rot { get; set; }
        [XmlElement(ElementName = "Floor")]
        public string Floor { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "CombatScript")]
        public string CombatScript { get; set; }
        [XmlElement(ElementName = "Shared")]
        public Shared Shared { get; set; }
        [XmlElement(ElementName = "SpellID")]
        public string SpellID { get; set; }
        [XmlAttribute(AttributeName = "ObjectRecordID")]
        public string ObjectRecordID { get; set; }
        [XmlElement(ElementName = "pointLights")]
        public PointLights PointLights { get; set; }
    }

    [XmlRoot(ElementName = "AdvMapDwelling")]
    public class AdvMapDwelling
    {
        [XmlElement(ElementName = "Pos")]
        public Pos Pos { get; set; }
        [XmlElement(ElementName = "Rot")]
        public string Rot { get; set; }
        [XmlElement(ElementName = "Floor")]
        public string Floor { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "CombatScript")]
        public string CombatScript { get; set; }
        [XmlElement(ElementName = "Shared")]
        public Shared Shared { get; set; }
        [XmlElement(ElementName = "PlayerID")]
        public string PlayerID { get; set; }
        [XmlElement(ElementName = "CaptureTrigger")]
        public CaptureTrigger CaptureTrigger { get; set; }
        [XmlElement(ElementName = "RandomCreatures")]
        public string RandomCreatures { get; set; }
        [XmlElement(ElementName = "RndSource")]
        public string RndSource { get; set; }
        [XmlElement(ElementName = "LinkToPlayer")]
        public string LinkToPlayer { get; set; }
        [XmlElement(ElementName = "LinkToTown")]
        public string LinkToTown { get; set; }
        [XmlAttribute(AttributeName = "ObjectRecordID")]
        public string ObjectRecordID { get; set; }
        [XmlElement(ElementName = "pointLights")]
        public PointLights PointLights { get; set; }
        [XmlElement(ElementName = "creaturesEnabled")]
        public CreaturesEnabled CreaturesEnabled { get; set; }
    }

    [XmlRoot(ElementName = "Color")]
    public class Color
    {
        [XmlElement(ElementName = "x")]
        public string X { get; set; }
        [XmlElement(ElementName = "y")]
        public string Y { get; set; }
        [XmlElement(ElementName = "z")]
        public string Z { get; set; }
    }

    public class PointLightItem
    {
       
        public Pos Pos { get; set; }
        
        public Color Color { get; set; }
       
        public float Radius { get; set; }
    }

    [XmlRoot(ElementName = "pointLights")]
    public class PointLights
    {
        [XmlElement(ElementName = "Item")]
        public PointLightItem Item { get; set; }
    }

    [XmlRoot(ElementName = "AdvMapStatic")]
    public class AdvMapStatic
    {
        [XmlElement(ElementName = "Pos")]
        public Pos Pos { get; set; }
        [XmlElement(ElementName = "Rot")]
        public string Rot { get; set; }
        [XmlElement(ElementName = "Floor")]
        public string Floor { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "CombatScript")]
        public string CombatScript { get; set; }
        [XmlElement(ElementName = "Shared")]
        public Shared Shared { get; set; }
        [XmlElement(ElementName = "IsRemovable")]
        public string IsRemovable { get; set; }
        [XmlAttribute(AttributeName = "ObjectRecordID")]
        public string ObjectRecordID { get; set; }
        [XmlElement(ElementName = "pointLights")]
        public PointLights PointLights { get; set; }
    }

    [XmlRoot(ElementName = "AdvMapArtifact")]
    public class AdvMapArtifact
    {
        [XmlElement(ElementName = "Pos")]
        public Pos Pos { get; set; }
        [XmlElement(ElementName = "Rot")]
        public string Rot { get; set; }
        [XmlElement(ElementName = "Floor")]
        public string Floor { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "CombatScript")]
        public string CombatScript { get; set; }
        [XmlElement(ElementName = "Shared")]
        public Shared Shared { get; set; }
        [XmlElement(ElementName = "armySlots")]
        public string ArmySlots { get; set; }
        [XmlElement(ElementName = "MessageFileRef")]
        public MessageFileRef MessageFileRef { get; set; }
        [XmlElement(ElementName = "spellID")]
        public string SpellID { get; set; }
        [XmlElement(ElementName = "RandomShiftRadius")]
        public string RandomShiftRadius { get; set; }
        [XmlElement(ElementName = "untransferable")]
        public string Untransferable { get; set; }
        [XmlAttribute(AttributeName = "ObjectRecordID")]
        public string ObjectRecordID { get; set; }
        [XmlElement(ElementName = "pointLights")]
        public PointLights PointLights { get; set; }
    }

    [XmlRoot(ElementName = "AdvMapTent")]
    public class AdvMapTent
    {
        [XmlElement(ElementName = "Pos")]
        public Pos Pos { get; set; }
        [XmlElement(ElementName = "Rot")]
        public string Rot { get; set; }
        [XmlElement(ElementName = "Floor")]
        public string Floor { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "CombatScript")]
        public string CombatScript { get; set; }
        [XmlElement(ElementName = "pointLights")]
        public string PointLights { get; set; }
        [XmlElement(ElementName = "Shared")]
        public Shared Shared { get; set; }
        [XmlAttribute(AttributeName = "ObjectRecordID")]
        public string ObjectRecordID { get; set; }
    }

    [XmlRoot(ElementName = "LossTrigger")]
    public class LossTrigger
    {
        [XmlElement(ElementName = "Action")]
        public Action Action { get; set; }
    }

    [XmlRoot(ElementName = "AdvMapHero")]
    public class AdvMapHero
    {
        [XmlElement(ElementName = "Pos")]
        public Pos Pos { get; set; }
        [XmlElement(ElementName = "Rot")]
        public string Rot { get; set; }
        [XmlElement(ElementName = "Floor")]
        public string Floor { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "CombatScript")]
        public string CombatScript { get; set; }
        [XmlElement(ElementName = "pointLights")]
        public string PointLights { get; set; }
        [XmlElement(ElementName = "Shared")]
        public Shared Shared { get; set; }
        [XmlElement(ElementName = "PlayerID")]
        public string PlayerID { get; set; }
        [XmlElement(ElementName = "Experience")]
        public string Experience { get; set; }
        [XmlElement(ElementName = "armySlots")]
        public ArmySlots ArmySlots { get; set; }
        [XmlElement(ElementName = "Editable")]
        public Editable Editable { get; set; }
        [XmlElement(ElementName = "OverrideMask")]
        public string OverrideMask { get; set; }
        [XmlElement(ElementName = "PrimarySkillMastery")]
        public string PrimarySkillMastery { get; set; }
        [XmlElement(ElementName = "LossTrigger")]
        public LossTrigger LossTrigger { get; set; }
        [XmlElement(ElementName = "AllowQuickCombat")]
        public string AllowQuickCombat { get; set; }
        [XmlAttribute(AttributeName = "ObjectRecordID")]
        public string ObjectRecordID { get; set; }
        [XmlElement(ElementName = "artifactIDs")]
        public ArtifactIDs ArtifactIDs { get; set; }
        [XmlElement(ElementName = "isUntransferable")]
        public IsUntransferable IsUntransferable { get; set; }
    }

    public class BuildingItem
    {
        public string Type { get; set; }
        public string InitialUpgrade { get; set; }
        public string MaxUpgrade { get; set; }
    }

    [XmlRoot(ElementName = "buildings")]
    public class Buildings
    {
        [XmlElement(ElementName = "Item")]
        public List<BuildingItem> Item { get; set; }
    }

    [XmlRoot(ElementName = "artifactIDs")]
    public class ArtifactIDs
    {
        [XmlElement(ElementName = "Item")]
        public List<string> Item { get; set; }
    }

    [XmlRoot(ElementName = "isUntransferable")]
    public class IsUntransferable
    {
        [XmlElement(ElementName = "Item")]
        public List<string> Item { get; set; }
    }

    [XmlRoot(ElementName = "perkIDs")]
    public class PerkIDs
    {
        [XmlElement(ElementName = "Item")]
        public List<string> Item { get; set; }
    }

    [XmlRoot(ElementName = "AvailableResources")]
    public class AvailableResources
    {
        [XmlElement(ElementName = "Item")]
        public List<string> Item { get; set; }
    }

    [XmlRoot(ElementName = "AdvMapAbanMine")]
    public class AdvMapAbanMine
    {
        [XmlElement(ElementName = "Pos")]
        public Pos Pos { get; set; }
        [XmlElement(ElementName = "Rot")]
        public string Rot { get; set; }
        [XmlElement(ElementName = "Floor")]
        public string Floor { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "CombatScript")]
        public string CombatScript { get; set; }
        [XmlElement(ElementName = "pointLights")]
        public string PointLights { get; set; }
        [XmlElement(ElementName = "Shared")]
        public Shared Shared { get; set; }
        [XmlElement(ElementName = "AvailableResources")]
        public AvailableResources AvailableResources { get; set; }
        [XmlElement(ElementName = "CaptureTrigger")]
        public CaptureTrigger CaptureTrigger { get; set; }
        [XmlAttribute(AttributeName = "ObjectRecordID")]
        public string ObjectRecordID { get; set; }
    }

    [XmlRoot(ElementName = "AdvMapSphinx")]
    public class AdvMapSphinx
    {
        [XmlElement(ElementName = "Pos")]
        public Pos Pos { get; set; }
        [XmlElement(ElementName = "Rot")]
        public string Rot { get; set; }
        [XmlElement(ElementName = "Floor")]
        public string Floor { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "CombatScript")]
        public string CombatScript { get; set; }
        [XmlElement(ElementName = "pointLights")]
        public string PointLights { get; set; }
        [XmlElement(ElementName = "Shared")]
        public Shared Shared { get; set; }
        [XmlElement(ElementName = "Riddle")]
        public string Riddle { get; set; }
        [XmlElement(ElementName = "RandomRiddle")]
        public string RandomRiddle { get; set; }
        [XmlAttribute(AttributeName = "ObjectRecordID")]
        public string ObjectRecordID { get; set; }
    }

    [XmlRoot(ElementName = "creaturesEnabled")]
    public class CreaturesEnabled
    {
        [XmlElement(ElementName = "Item")]
        public List<string> Item { get; set; }
    }

    [XmlRoot(ElementName = "AdvMapCartographer")]
    public class AdvMapCartographer
    {
        [XmlElement(ElementName = "Pos")]
        public Pos Pos { get; set; }
        [XmlElement(ElementName = "Rot")]
        public string Rot { get; set; }
        [XmlElement(ElementName = "Floor")]
        public string Floor { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "CombatScript")]
        public string CombatScript { get; set; }
        [XmlElement(ElementName = "pointLights")]
        public string PointLights { get; set; }
        [XmlElement(ElementName = "Shared")]
        public Shared Shared { get; set; }
        [XmlElement(ElementName = "CaptureTrigger")]
        public CaptureTrigger CaptureTrigger { get; set; }
        [XmlElement(ElementName = "Cost")]
        public string Cost { get; set; }
    }

    [XmlRoot(ElementName = "Rect")]
    public class Rect
    {
        [XmlElement(ElementName = "x1")]
        public int X1 { get; set; }
        [XmlElement(ElementName = "y1")]
        public int Y1 { get; set; }
        [XmlElement(ElementName = "x2")]
        public int X2 { get; set; }
        [XmlElement(ElementName = "y2")]
        public int Y2 { get; set; }
    }

    [XmlRoot(ElementName = "EnterAndStopTrigger")]
    public class EnterAndStopTrigger
    {
        [XmlElement(ElementName = "Action")]
        public Action Action { get; set; }
    }

    [XmlRoot(ElementName = "EnterWithoutStopTrigger")]
    public class EnterWithoutStopTrigger
    {
        [XmlElement(ElementName = "Action")]
        public Action Action { get; set; }
    }

    public class RegionItem
    {        
        public string Floor { get; set; }
        public Rect Rect { get; set; }      
        public string Name { get; set; }       
        public Color Color { get; set; }      
        public EnterAndStopTrigger EnterAndStopTrigger { get; set; }    
        public EnterWithoutStopTrigger EnterWithoutStopTrigger { get; set; }
    }

    


    public class LightItem
    {
        [XmlAttribute(AttributeName = "href")]
        public string Href { get; set; }

    }

    public class GroundAmbientLights
    {
        public LightItem Item { get; set; }
    }

    public class UndergroundAmbientLights
    {
        public LightItem Item { get; set; }
    }

    public class MoonItem
    {
        public int State { get; set; }
        public int RotationRate { get; set; }
    }

    public class PlayerItem {
   
        public string MainTown { get; set; }

        public string MainHero { get; set; }
 
        public bool ActivePlayer { get; set; }
       
        public int Team { get; set; }
  
        public bool CanBeHumanPlayer { get; set; }
      
        public bool CanBeComputerPlayer { get; set; }
 
        public string Behaviour { get; set; }
   
        public int CaptureAbility { get; set; }
     
        public string StartHero { get; set; }
   
        public bool HeroInTown { get; set; }
      
        public string ReserveHeroes { get; set; }
   
        public AddHeroTrigger AddHeroTrigger { get; set; }
     
        public RemoveHeroTrigger RemoveHeroTrigger { get; set; }
   
        public VictoryMessageRef VictoryMessageRef { get; set; }
    
        public DefeatMessageRef DefeatMessageRef { get; set; }
     
        public string Race { get; set; }

        public string Colour { get; set; }
    }

    

    public class GroundTerrainFileName
    {
        [XmlAttribute(AttributeName = "href")]
        public string Href { get; set; }
    }

    public class UndergroundTerrainFileName
    {
        [XmlAttribute(AttributeName = "href")]
        public string Href { get; set; }
    }

    public class DescriptionFileRef
    {
        [XmlAttribute(AttributeName = "href")]
        public string Href { get; set; }
    }

    [XmlRoot(ElementName = "AddHeroTrigger")]
    public class AddHeroTrigger
    {
        [XmlElement(ElementName = "Action")]
        public Action Action { get; set; }
    }

    [XmlRoot(ElementName = "RemoveHeroTrigger")]
    public class RemoveHeroTrigger
    {
        [XmlElement(ElementName = "Action")]
        public Action Action { get; set; }
    }

    [XmlRoot(ElementName = "VictoryMessageRef")]
    public class VictoryMessageRef
    {
        [XmlAttribute(AttributeName = "href")]
        public string Href { get; set; }
    }

    [XmlRoot(ElementName = "DefeatMessageRef")]
    public class DefeatMessageRef
    {
        [XmlAttribute(AttributeName = "href")]
        public string Href { get; set; }
    }

    [XmlRoot(ElementName = "players")]
    public class Players
    {
        [XmlElement(ElementName = "Item")]
        public List<PlayerItem> Item { get; set; }
    }

    [XmlRoot(ElementName = "ObscureCaptionFileRef")]
    public class ObscureCaptionFileRef
    {
        [XmlAttribute(AttributeName = "href")]
        public string Href { get; set; }
    }

    [XmlRoot(ElementName = "cell")]
    public class Cell
    {
        [XmlElement(ElementName = "x")]
        public string X { get; set; }
        [XmlElement(ElementName = "y")]
        public string Y { get; set; }
    }

    [XmlRoot(ElementName = "Coords")]
    public class Coords
    {
        [XmlElement(ElementName = "FloorID")]
        public string FloorID { get; set; }
        [XmlElement(ElementName = "cell")]
        public Cell Cell { get; set; }
    }

    [XmlRoot(ElementName = "Target")]
    public class Target
    {
        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Coords")]
        public Coords Coords { get; set; }
    }

    [XmlRoot(ElementName = "TargetGlance")]
    public class TargetGlance
    {
        [XmlElement(ElementName = "Target")]
        public Target Target { get; set; }
        [XmlElement(ElementName = "Radius")]
        public string Radius { get; set; }
        [XmlElement(ElementName = "Duration")]
        public string Duration { get; set; }
    }

    [XmlRoot(ElementName = "ArmySlot")]
    public class ArmySlot
    {
        [XmlElement(ElementName = "Creature")]
        public string Creature { get; set; }
        [XmlElement(ElementName = "Count")]
        public string Count { get; set; }
    }

    [XmlRoot(ElementName = "SkillWithMastery")]
    public class SkillWithMastery
    {
        [XmlElement(ElementName = "Mastery")]
        public string Mastery { get; set; }
        [XmlElement(ElementName = "SkillID")]
        public string SkillID { get; set; }
    }

    [XmlRoot(ElementName = "Award")]
    public class Award
    {
        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "Experience")]
        public string Experience { get; set; }
        [XmlElement(ElementName = "Resources")]
        public Resources Resources { get; set; }
        [XmlElement(ElementName = "Attribute")]
        public string Attribute { get; set; }
        [XmlElement(ElementName = "AttributeAmount")]
        public string AttributeAmount { get; set; }
        [XmlElement(ElementName = "ArtifactID")]
        public string ArtifactID { get; set; }
        [XmlElement(ElementName = "SpellID")]
        public string SpellID { get; set; }
        [XmlElement(ElementName = "ArmySlot")]
        public ArmySlot ArmySlot { get; set; }
        [XmlElement(ElementName = "SpellPoints")]
        public string SpellPoints { get; set; }
        [XmlElement(ElementName = "Morale")]
        public string Morale { get; set; }
        [XmlElement(ElementName = "Luck")]
        public string Luck { get; set; }
        [XmlElement(ElementName = "SkillWithMastery")]
        public SkillWithMastery SkillWithMastery { get; set; }
    }

    [XmlRoot(ElementName = "StateChangeTrigger")]
    public class StateChangeTrigger
    {
        [XmlElement(ElementName = "Action")]
        public Action Action { get; set; }
    }

    public class ScenarioInformation
    {
        public ConcereteObjectiveItem Item { get; set; }
    }

    public class Objectives
    {
        public ObjectiveType Primary { get; set; }
        public ObjectiveType Secondary { get; set; }
        
    }

    public class ObjectiveType //pimary, secondary
    {
        public Common Common { get; set; }
        public PlayerSpecific PlayerSpecific { get; set; }
    }


    public class Common
    {
        public ConcreteObjectives Objectives { get; set; }
        public bool DieInWeekWithoutTowns { get; set; }
    }

    public class PlayerSpecific
    {
        [XmlElement(ElementName = "Item")]
        public List<Common> Item { get; set; }
    }

    public class MapScript
    {
        [XmlAttribute(AttributeName = "href")]
        public string Href { get; set; }
    }

    public class ThumbnailImage
    {
        [XmlAttribute(AttributeName = "href")]
        public string Href { get; set; }
    }

    [XmlRoot(ElementName = "NewDayTrigger")]
    public class NewDayTrigger
    {
        [XmlElement(ElementName = "Action")]
        public Action Action { get; set; }
    }

    [XmlRoot(ElementName = "WarFogEnterTrigger")]
    public class WarFogEnterTrigger
    {
        [XmlElement(ElementName = "Action")]
        public Action Action { get; set; }
    }

    [XmlRoot(ElementName = "MoonCalendarModifications")]
    public class MoonCalendarModifications
    {
        [XmlElement(ElementName = "BlockMonstersWeeks")]
        public string BlockMonstersWeeks { get; set; }
    }

    [XmlRoot(ElementName = "thumbnailImages")]
    public class ThumbnailImages
    {
        [XmlElement(ElementName = "Item")]
        public List<ThumbnailImage> Item { get; set; }
    }



}
