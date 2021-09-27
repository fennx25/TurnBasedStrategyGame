using System;
using System.Xml.Serialization;
using System.Collections.Generic;

//https://xmltocsharp.azurewebsites.net
namespace Adv
{
    [XmlRoot(ElementName = "objects")]
    public class Objects
    {
        [XmlElement(ElementName = "Item")]
        public List<ObjectItem> Item { get; set; }
    }

    [XmlRoot(ElementName = "moons")]
    public class Moons
    {
        [XmlElement(ElementName = "Item")]
        public List<MoonItem> Item { get; set; }
    }

    [XmlRoot(ElementName = "Item")]
    public class ObjectItem
    {
        [XmlAttribute(AttributeName = "href")]
        public string Href { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        public AdvMapBuilding AdvMapBuilding { get; set; }        
        public AdvMapTreasure AdvMapTreasure { get; set; }    
        public AdvMapTown AdvMapTown { get; set; }   
        public AdvMapMine AdvMapMine { get; set; }
        public AdvMapGarrison AdvMapGarrison { get; set; }    
        public AdvMapMonster AdvMapMonster { get; set; }    
        public AdvMapShrine AdvMapShrine { get; set; }  
        public AdvMapDwelling AdvMapDwelling { get; set; }
        public AdvMapStatic AdvMapStatic { get; set; }      
        public AdvMapArtifact AdvMapArtifact { get; set; }    
        public AdvMapTent AdvMapTent { get; set; }
        public AdvMapHero AdvMapHero { get; set; }   
        public AdvMapAbanMine AdvMapAbanMine { get; set; }    
        public AdvMapSphinx AdvMapSphinx { get; set; }    
        public AdvMapCartographer AdvMapCartographer { get; set; }


        
        //[XmlElement(ElementName = "Objectives")]
        //public Objectives Objectives { get; set; }
        //[XmlElement(ElementName = "DieInWeekWithoutTowns")]
        //public string DieInWeekWithoutTowns { get; set; }
    }

    public class ConcreteObjectives
    {
        [XmlElement(ElementName = "Item")]
        public List<ConcereteObjectiveItem> Item { get; set; }
    }

    public class ConcereteObjectiveItem
    {
        public string Name { get; set; }
        public CaptionFileRef CaptionFileRef { get; set; }
        public ObscureCaptionFileRef ObscureCaptionFileRef { get; set; }
        public DescriptionFileRef DescriptionFileRef { get; set; }
        public string ProgressCommentsFileRef { get; set; }
        public string Kind { get; set; }
        //public string Parameters { get; set; } //Item zastava
        public float Timeout { get; set; }
        public float Holdout { get; set; }
        public string Dependencies { get; set; }
        public bool InstantVictory { get; set; }
        public TargetGlance TargetGlance { get; set; }
        public Award Award { get; set; }
        public string TakeContribution { get; set; }
        public bool CanUncomplete { get; set; }
        public bool IsInitialyActive { get; set; }
        public bool IsInitialyVisible { get; set; }
        public bool IsHidden { get; set; }
        public bool Ignore { get; set; }
        public bool ShowCompleted { get; set; }
        public bool NeedComplete { get; set; }
        public StateChangeTrigger StateChangeTrigger { get; set; }
    }

   
 }