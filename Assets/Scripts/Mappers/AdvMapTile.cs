using System;
using System.Xml.Serialization;
using System.Collections.Generic;

//https://xmltocsharp.azurewebsites.net
namespace Adv
{

	[XmlRoot(ElementName = "Texture")]
	public class TextureHref
	{
		[XmlAttribute(AttributeName = "href")]
		public string Href { get; set; }
	}

	[XmlRoot(ElementName = "MinimapColor")]
	public class MinimapColor
	{
		[XmlElement(ElementName = "x")]
		public string X { get; set; }
		[XmlElement(ElementName = "y")]
		public string Y { get; set; }
		[XmlElement(ElementName = "z")]
		public string Z { get; set; }
	}

	[XmlRoot(ElementName = "AdvMapTile")]
	public class AdvMapTile
	{
		[XmlElement(ElementName = "Texture")]
		public TextureHref Texture { get; set; }
		[XmlElement(ElementName = "SecondTexture")]
		public string SecondTexture { get; set; }
		[XmlElement(ElementName = "Material")]
		public string Material { get; set; }
		[XmlElement(ElementName = "Priority")]
		public string Priority { get; set; }
		[XmlElement(ElementName = "Type")]
		public string Type { get; set; }
		[XmlElement(ElementName = "MinimapColor")]
		public MinimapColor MinimapColor { get; set; }
		[XmlElement(ElementName = "IconFile")]
		public string IconFile { get; set; }
		[XmlElement(ElementName = "AmbientSoundSet")]
		public string AmbientSoundSet { get; set; }
		[XmlElement(ElementName = "AdventureMusic")]
		public string AdventureMusic { get; set; }
		[XmlAttribute(AttributeName = "ObjectRecordID")]
		public string ObjectRecordID { get; set; }
	}

}
