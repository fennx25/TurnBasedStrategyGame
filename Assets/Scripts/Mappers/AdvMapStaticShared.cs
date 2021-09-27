using System;
using System.Xml.Serialization;
using System.Collections.Generic;

//https://xmltocsharp.azurewebsites.net
namespace Adv
{

	[XmlRoot(ElementName = "Model")]
	public class ModelLink
	{
		[XmlAttribute(AttributeName = "href")]
		public string Href { get; set; }
	}

	[XmlRoot(ElementName = "Item")]
	public class Pos2d
	{
		[XmlElement(ElementName = "x")]
		public float X { get; set; }
		[XmlElement(ElementName = "y")]
		public float Y { get; set; }
	}

	[XmlRoot(ElementName = "blockedTiles")]
	public class BlockedTiles
	{
		[XmlElement(ElementName = "Item")]
		public List<Pos2d> Item { get; set; }
	}

	[XmlRoot(ElementName = "holeTiles")]
	public class HoleTiles
	{
		[XmlElement(ElementName = "Item")]
		public List<Pos2d> Item { get; set; }
	}

	//[XmlRoot(ElementName = "PossessionMarkerTile")]
	//public class PossessionMarkerTile
	//{
	//	[XmlElement(ElementName = "x")]
	//	public string X { get; set; }
	//	[XmlElement(ElementName = "y")]
	//	public string Y { get; set; }
	//}

	[XmlRoot(ElementName = "flybyMessageFileRef")]
	public class FlybyMessageFileRef
	{
		[XmlAttribute(AttributeName = "href")]
		public string Href { get; set; }
	}

	[XmlRoot(ElementName = "ObjectTypeFileRef")]
	public class ObjectTypeFileRef
	{
		[XmlAttribute(AttributeName = "href")]
		public string Href { get; set; }
	}

	[XmlRoot(ElementName = "AdvMapStaticShared")]
	public class AdvMapStaticShared
	{
		[XmlElement(ElementName = "Model")]
		public ModelLink Model { get; set; }
		[XmlElement(ElementName = "AnimSet")]
		public string AnimSet { get; set; }
		[XmlElement(ElementName = "blockedTiles")]
		public BlockedTiles BlockedTiles { get; set; }
		[XmlElement(ElementName = "holeTiles")]
		public HoleTiles HoleTiles { get; set; }
		[XmlElement(ElementName = "activeTiles")]
		public string ActiveTiles { get; set; }
		[XmlElement(ElementName = "passableTiles")]
		public string PassableTiles { get; set; }
		[XmlElement(ElementName = "PossessionMarkerTile")]
		public Pos2d PossessionMarkerTile { get; set; }
		[XmlElement(ElementName = "Effect")]
		public string Effect { get; set; }
		[XmlElement(ElementName = "EffectWhenOwned")]
		public string EffectWhenOwned { get; set; }
		[XmlElement(ElementName = "messagesFileRef")]
		public string MessagesFileRef { get; set; }
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
		[XmlAttribute(AttributeName = "ObjectRecordID")]
		public string ObjectRecordID { get; set; }
	}



}
