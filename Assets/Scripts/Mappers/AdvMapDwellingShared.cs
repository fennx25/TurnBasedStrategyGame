using System;
using System.Xml.Serialization;
using System.Collections.Generic;

//https://xmltocsharp.azurewebsites.net
namespace Adv
{
	

	[XmlRoot(ElementName = "AnimSet")]
	public class AnimSet
	{
		[XmlAttribute(AttributeName = "href")]
		public string Href { get; set; }
	}

	[XmlRoot(ElementName = "activeTiles")]
	public class ActiveTiles
	{
		[XmlElement(ElementName = "Item")]
		public Item Item { get; set; }
	}

	[XmlRoot(ElementName = "PossessionMarkerTile")]
	public class PossessionMarkerTile
	{
		[XmlElement(ElementName = "x")]
		public string X { get; set; }
		[XmlElement(ElementName = "y")]
		public string Y { get; set; }
	}

	[XmlRoot(ElementName = "messagesFileRef")]
	public class MessagesFileRef
	{
		[XmlElement(ElementName = "Item")]
		public List<Item> Item { get; set; }
	}

	[XmlRoot(ElementName = "creatures")]
	public class Creatures
	{
		[XmlElement(ElementName = "Item")]
		public string Item { get; set; }
	}

	[XmlRoot(ElementName = "AdvMapDwellingShared")]
	public class AdvMapDwellingShared
	{
		[XmlElement(ElementName = "Model")]
		public ModelLink Model { get; set; }
		[XmlElement(ElementName = "AnimSet")]
		public AnimSet AnimSet { get; set; }
		[XmlElement(ElementName = "blockedTiles")]
		public BlockedTiles BlockedTiles { get; set; }
		[XmlElement(ElementName = "holeTiles")]
		public HoleTiles HoleTiles { get; set; }
		[XmlElement(ElementName = "activeTiles")]
		public ActiveTiles ActiveTiles { get; set; }
		[XmlElement(ElementName = "passableTiles")]
		public string PassableTiles { get; set; }
		[XmlElement(ElementName = "PossessionMarkerTile")]
		public PossessionMarkerTile PossessionMarkerTile { get; set; }
		[XmlElement(ElementName = "Effect")]
		public string Effect { get; set; }
		[XmlElement(ElementName = "EffectWhenOwned")]
		public string EffectWhenOwned { get; set; }
		[XmlElement(ElementName = "messagesFileRef")]
		public MessagesFileRef MessagesFileRef { get; set; }
		[XmlElement(ElementName = "WaterBased")]
		public string WaterBased { get; set; }
		[XmlElement(ElementName = "ApplyHeroTrace")]
		public string ApplyHeroTrace { get; set; }
		[XmlElement(ElementName = "SoundEffect")]
		public string SoundEffect { get; set; }
		[XmlElement(ElementName = "flybyMessageFileRef")]
		public FlybyMessageFileRef FlybyMessageFileRef { get; set; }
		[XmlElement(ElementName = "ObjectTypeFileRef")]
		public ObjectTypeFileRef ObjectTypeFileRef { get; set; }
		[XmlElement(ElementName = "TerrainAligned")]
		public string TerrainAligned { get; set; }
		[XmlElement(ElementName = "FlyPassable")]
		public string FlyPassable { get; set; }
		[XmlElement(ElementName = "AdventureSoundEffect")]
		public string AdventureSoundEffect { get; set; }
		[XmlElement(ElementName = "Type")]
		public string Type { get; set; }
		[XmlElement(ElementName = "guards")]
		public string Guards { get; set; }
		[XmlElement(ElementName = "creatures")]
		public Creatures Creatures { get; set; }
		[XmlElement(ElementName = "RandomType")]
		public string RandomType { get; set; }
		[XmlAttribute(AttributeName = "ObjectRecordID")]
		public string ObjectRecordID { get; set; }
	}
}
