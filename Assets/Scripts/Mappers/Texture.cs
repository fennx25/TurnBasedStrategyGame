using System;
using System.Xml.Serialization;
using System.Collections.Generic;

//https://xmltocsharp.azurewebsites.net
namespace Adv
{

	[XmlRoot(ElementName = "SrcName")]
	public class SrcName
	{
		[XmlAttribute(AttributeName = "href")]
		public string Href { get; set; }
	}

	[XmlRoot(ElementName = "DestName")]
	public class DestName
	{
		[XmlAttribute(AttributeName = "href")]
		public string Href { get; set; }
	}

	[XmlRoot(ElementName = "Texture")]
	public class TextureFile
	{
		[XmlElement(ElementName = "SrcName")]
		public SrcName SrcName { get; set; }
		[XmlElement(ElementName = "DestName")]
		public DestName DestName { get; set; }
		[XmlElement(ElementName = "Type")]
		public string Type { get; set; }
		[XmlElement(ElementName = "ConversionType")]
		public string ConversionType { get; set; }
		[XmlElement(ElementName = "AddrType")]
		public string AddrType { get; set; }
		[XmlElement(ElementName = "Format")]
		public string Format { get; set; }

		[XmlElement(ElementName = "Width")]
		public int Width { get; set; }
		[XmlElement(ElementName = "Height")]
		public int Height { get; set; }

		[XmlElement(ElementName = "MappingSize")]
		public string MappingSize { get; set; }
		[XmlElement(ElementName = "NMips")]
		public string NMips { get; set; }
		[XmlElement(ElementName = "Gain")]
		public string Gain { get; set; }
		[XmlElement(ElementName = "AverageColor")]
		public string AverageColor { get; set; }
		[XmlElement(ElementName = "InstantLoad")]
		public string InstantLoad { get; set; }
		[XmlElement(ElementName = "IsDXT")]
		public string IsDXT { get; set; }
		[XmlElement(ElementName = "FlipY")]
		public string FlipY { get; set; }
		[XmlElement(ElementName = "StandardExport")]
		public string StandardExport { get; set; }
		[XmlElement(ElementName = "UseS3TC")]
		public string UseS3TC { get; set; }
		[XmlAttribute(AttributeName = "ObjectRecordID")]
		public string ObjectRecordID { get; set; }
	}

}