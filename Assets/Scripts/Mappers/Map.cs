using System;
using System.Xml.Serialization;
using System.Collections.Generic;

//https://xmltocsharp.azurewebsites.net
namespace Adv
{
    [XmlRoot(ElementName = "regions")]
    public class Regions
    {
        public List<RegionItem> Item { get; set; }
    }

    [XmlRoot(ElementName = "tiles")]
    public class Tiles
    {
        public List<LightItem> Item { get; set; }
    }

    public class AdvMapDesc
    {

        [XmlAttribute(AttributeName = "ObjectRecordID")]
        public string ObjectRecordID { get; set; }

        public bool CustomGameMap { get; set; }   
        public int TileX { get; set; }    
        public int TileY { get; set; }     
        public bool HasUnderground { get; set; }     
        public int InitialFloor { get; set; }

        [XmlElement(ElementName = "objects")]
        public Objects Objects { get; set; }

        public Resources Resources { get; set; }   
        public string AmbientLight { get; set; } 
        public string UndergroundAmbientLight { get; set; }    
        public GroundAmbientLights GroundAmbientLights { get; set; } 
        public UndergroundAmbientLights UndergroundAmbientLights { get; set; }  
        public bool ReflectiveWater { get; set; }

        [XmlElement(ElementName = "tiles")]
        public Tiles Tiles { get; set; }

        [XmlElement(ElementName = "regions")]
        public Regions Regions { get; set; }

        public GroundTerrainFileName GroundTerrainFileName { get; set; }

        public UndergroundTerrainFileName UndergroundTerrainFileName { get; set; }

        public NameFileRef NameFileRef { get; set; }
  
        public DescriptionFileRef DescriptionFileRef { get; set; }

        [XmlElement(ElementName = "moons")]
        public Moons Moons { get; set; }

        public bool RandomMoons { get; set; }
        public int HeroMaxLevel { get; set; }
        public bool CustomTeams { get; set; }

        [XmlElement(ElementName = "players")]
        public Players Players { get; set; }

   
        public ScenarioInformation ScenarioInformation { get; set; }
   
        public Objectives Objectives { get; set; }
    
        public string Birds { get; set; }
        public int BirdsAmount { get; set; }
        //public string Weather { get; set; }
        //public string Wind { get; set; }

        public string PreLight { get; set; }
        public MapScript MapScript { get; set; }
        public NewDayTrigger NewDayTrigger { get; set; }   
        public WarFogEnterTrigger WarFogEnterTrigger { get; set; }
        public string PWLTutorialHintTrigger { get; set; }
    
        public int BorderSize { get; set; }
        
        [XmlElement(ElementName = "artifactIDs")]
        public ArtifactIDs ArtifactIDs { get; set; }
        [XmlElement(ElementName = "isUntransferable")]
        public IsUntransferable IsUntransferable { get; set; }

        public string AvailableHeroes { get; set; }
        
        public string MapRumours { get; set; }
     
        public string Music { get; set; }
        
        public MoonCalendarModifications MoonCalendarModifications { get; set; }
        [XmlElement(ElementName = "thumbnailImages")]
        public ThumbnailImages ThumbnailImages { get; set; }

        public string PWLPicture { get; set; }
        [XmlElement(ElementName = "weekIDs")]
        public string WeekIDs { get; set; }

        public bool BanTransparency { get; set; }

        public string MoonCalendar { get; set; }
        public string StartScene { get; set; }
        
    }

    
}