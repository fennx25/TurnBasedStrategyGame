using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;

//https://xmltocsharp.azurewebsites.net
namespace Adv
{

    [XmlRoot(ElementName = "Texture")]
    public class Texture
    {
        [XmlAttribute(AttributeName = "href")]
        public string Href { get; set; }



        public UnityEngine.Texture2D Texture2D()
        {
            string path = "Assets/Resources/data/";

            var textureHref = Href.Remove(Href.IndexOf("#"));

            TextureFile textureFile;
            XmlSerializer serializer = new XmlSerializer(typeof(TextureFile));
            using (StreamReader streamReader = new StreamReader(path + textureHref))
            {
                textureFile = (TextureFile)serializer.Deserialize(streamReader);
            }

            string textureImageFileHref = textureHref.Remove(textureHref.LastIndexOf("/")) + "/" + textureFile.DestName.Href;


            //if (File.Exists(path + textureImageFileHref))
            //{

            var bytes = File.ReadAllBytes(path + textureImageFileHref);
            if (textureFile.Format == "TF_DXT3")
            {
                var tex = LoadTextureDXT(bytes, UnityEngine.TextureFormat.DXT5);

                tex.LoadRawTextureData(bytes);
                tex.Apply();

                return tex;
            }
            else if (textureFile.Format == "TF_8888")
            {
                var temp = new UnityEngine.Texture2D(textureFile.Width, textureFile.Height, UnityEngine.TextureFormat.ARGB32, false);
                temp.LoadRawTextureData(bytes);
                temp.Apply();
                return temp;
            }
            else
            {
                var tex = LoadTextureDXT(bytes, UnityEngine.TextureFormat.DXT1);

                tex.LoadRawTextureData(bytes);
                tex.Apply();

                return tex;
            }
        }

        public static UnityEngine.Texture2D LoadTextureDXT(byte[] ddsBytes, UnityEngine.TextureFormat textureFormat)
        {
            if (textureFormat != UnityEngine.TextureFormat.DXT1 && textureFormat != UnityEngine.TextureFormat.DXT5)
                throw new Exception("Invalid TextureFormat. Only DXT1 and DXT5 formats are supported by this method.");

            byte ddsSizeCheck = ddsBytes[4];
            if (ddsSizeCheck != 124)
                throw new Exception("Invalid DDS DXTn texture. Unable to read");  //this header byte should be 124 for DDS image files

            int height = ddsBytes[13] * 256 + ddsBytes[12];
            int width = ddsBytes[17] * 256 + ddsBytes[16];

            int DDS_HEADER_SIZE = 128;
            byte[] dxtBytes = new byte[ddsBytes.Length - DDS_HEADER_SIZE];
            Buffer.BlockCopy(ddsBytes, DDS_HEADER_SIZE, dxtBytes, 0, ddsBytes.Length - DDS_HEADER_SIZE);

            UnityEngine.Texture2D texture = new UnityEngine.Texture2D(width, height, textureFormat, false);
            texture.LoadRawTextureData(dxtBytes);
            texture.Apply();

            return (texture);
        }


    }

    [XmlRoot(ElementName = "SpecColor")]
    public class SpecColor
    {
        [XmlElement(ElementName = "x")]
        public string X { get; set; }
        [XmlElement(ElementName = "y")]
        public string Y { get; set; }
        [XmlElement(ElementName = "z")]
        public string Z { get; set; }
    }

    [XmlRoot(ElementName = "TranslucentColor")]
    public class TranslucentColor
    {
        [XmlElement(ElementName = "x")]
        public string X { get; set; }
        [XmlElement(ElementName = "y")]
        public string Y { get; set; }
        [XmlElement(ElementName = "z")]
        public string Z { get; set; }
    }

    [XmlRoot(ElementName = "Material")]
    public class Material
    {
        [XmlElement(ElementName = "Texture")]
        public Texture Texture { get; set; }
        [XmlElement(ElementName = "Bump")]
        public string Bump { get; set; }
        [XmlElement(ElementName = "SpecFactor")]
        public string SpecFactor { get; set; }
        [XmlElement(ElementName = "SpecColor")]
        public SpecColor SpecColor { get; set; }
        [XmlElement(ElementName = "Gloss")]
        public string Gloss { get; set; }
        [XmlElement(ElementName = "MetalMirror")]
        public string MetalMirror { get; set; }
        [XmlElement(ElementName = "DielMirror")]
        public string DielMirror { get; set; }
        [XmlElement(ElementName = "Mirror")]
        public string Mirror { get; set; }
        [XmlElement(ElementName = "CastShadow")]
        public string CastShadow { get; set; }
        [XmlElement(ElementName = "ReceiveShadow")]
        public string ReceiveShadow { get; set; }
        [XmlElement(ElementName = "Priority")]
        public string Priority { get; set; }
        [XmlElement(ElementName = "TranslucentColor")]
        public TranslucentColor TranslucentColor { get; set; }
        [XmlElement(ElementName = "FloatParam")]
        public string FloatParam { get; set; }
        [XmlElement(ElementName = "DetailTexture")]
        public string DetailTexture { get; set; }
        [XmlElement(ElementName = "DetailScale")]
        public string DetailScale { get; set; }
        [XmlElement(ElementName = "ProjectOnTerrain")]
        public string ProjectOnTerrain { get; set; }
        [XmlElement(ElementName = "LightingMode")]
        public string LightingMode { get; set; }
        [XmlElement(ElementName = "DynamicMode")]
        public string DynamicMode { get; set; }
        [XmlElement(ElementName = "Is2Sided")]
        public string Is2Sided { get; set; }
        [XmlElement(ElementName = "Effect")]
        public string Effect { get; set; }
        [XmlElement(ElementName = "AlphaMode")]
        public string AlphaMode { get; set; }
        [XmlElement(ElementName = "AffectedByFog")]
        public string AffectedByFog { get; set; }
        [XmlElement(ElementName = "AddPlaced")]
        public string AddPlaced { get; set; }
        [XmlElement(ElementName = "IgnoreZBuffer")]
        public string IgnoreZBuffer { get; set; }
        [XmlElement(ElementName = "BackFaceCastShadow")]
        public string BackFaceCastShadow { get; set; }
        [XmlAttribute(AttributeName = "ObjectRecordID")]
        public string ObjectRecordID { get; set; }
    }

    [XmlRoot(ElementName = "Item")]
    public class Item
    {
        [XmlElement(ElementName = "Material")]
        public Material Material { get; set; }
        [XmlAttribute(AttributeName = "href")]
        public string Href { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "Materials")]
    public class Materials
    {
        [XmlElement(ElementName = "Item")]
        public List<Item> Item { get; set; }
    }

    [XmlRoot(ElementName = "Skeleton")]
    public class Skeleton
    {
        [XmlElement(ElementName = "SrcName")]
        public SrcName SrcName { get; set; }
        [XmlElement(ElementName = "RootJoint")]
        public string RootJoint { get; set; }
        [XmlElement(ElementName = "MSRFormat")]
        public string MSRFormat { get; set; }
        [XmlElement(ElementName = "Animations")]
        public string Animations { get; set; }
        [XmlElement(ElementName = "uid")]
        public string Uid { get; set; }
        [XmlAttribute(AttributeName = "ObjectRecordID")]
        public string ObjectRecordID { get; set; }
    }

    [XmlRoot(ElementName = "Size")]
    public class Size
    {
        [XmlElement(ElementName = "x")]
        public string X { get; set; }
        [XmlElement(ElementName = "y")]
        public string Y { get; set; }
        [XmlElement(ElementName = "z")]
        public string Z { get; set; }
    }

    [XmlRoot(ElementName = "Center")]
    public class Center
    {
        [XmlElement(ElementName = "x")]
        public string X { get; set; }
        [XmlElement(ElementName = "y")]
        public string Y { get; set; }
        [XmlElement(ElementName = "z")]
        public string Z { get; set; }
    }

    [XmlRoot(ElementName = "BestFitPoint")]
    public class BestFitPoint
    {
        [XmlElement(ElementName = "x")]
        public string X { get; set; }
        [XmlElement(ElementName = "y")]
        public string Y { get; set; }
        [XmlElement(ElementName = "z")]
        public string Z { get; set; }
    }

    [XmlRoot(ElementName = "Dir")]
    public class Dir
    {
        [XmlElement(ElementName = "x")]
        public string X { get; set; }
        [XmlElement(ElementName = "y")]
        public string Y { get; set; }
        [XmlElement(ElementName = "z")]
        public string Z { get; set; }
        [XmlElement(ElementName = "w")]
        public string W { get; set; }
    }

    [XmlRoot(ElementName = "MaterialQuantities")]
    public class MaterialQuantities
    {
        [XmlElement(ElementName = "Item")]
        public List<string> Item { get; set; }
    }

    [XmlRoot(ElementName = "MeshNames")]
    public class MeshNames
    {
        [XmlElement(ElementName = "Item")]
        public List<string> Item { get; set; }
    }

    [XmlRoot(ElementName = "Geometry")]
    public class Geometry
    {
        [XmlElement(ElementName = "SrcName")]
        public SrcName SrcName { get; set; }
        [XmlElement(ElementName = "uid")]
        public string Uid { get; set; }
        [XmlElement(ElementName = "RootMesh")]
        public string RootMesh { get; set; }
        [XmlElement(ElementName = "RootJoint")]
        public string RootJoint { get; set; }
        [XmlElement(ElementName = "Size")]
        public Size Size { get; set; }
        [XmlElement(ElementName = "Center")]
        public Center Center { get; set; }
        [XmlElement(ElementName = "BestFitPoint")]
        public BestFitPoint BestFitPoint { get; set; }
        [XmlElement(ElementName = "Dir")]
        public Dir Dir { get; set; }
        [XmlElement(ElementName = "AIGeometry")]
        public string AIGeometry { get; set; }
        [XmlElement(ElementName = "NumMeshes")]
        public string NumMeshes { get; set; }
        [XmlElement(ElementName = "MaterialQuantities")]
        public MaterialQuantities MaterialQuantities { get; set; }
        [XmlElement(ElementName = "MeshNames")]
        public MeshNames MeshNames { get; set; }
        [XmlElement(ElementName = "MeshAnimated")]
        public string MeshAnimated { get; set; }
        [XmlElement(ElementName = "MeshWindAffected")]
        public string MeshWindAffected { get; set; }
        [XmlAttribute(AttributeName = "ObjectRecordID")]
        public string ObjectRecordID { get; set; }
    }

    [XmlRoot(ElementName = "Model")]
    public class Model
    {
        [XmlElement(ElementName = "Materials")]
        public Materials Materials { get; set; }
        [XmlElement(ElementName = "Skeleton")]
        public Skeleton Skeleton { get; set; }
        [XmlElement(ElementName = "Geometry")]
        public Geometry Geometry { get; set; }
        [XmlElement(ElementName = "Animations")]
        public string Animations { get; set; }
        [XmlElement(ElementName = "WindPower")]
        public string WindPower { get; set; }
        [XmlAttribute(AttributeName = "ObjectRecordID")]
        public string ObjectRecordID { get; set; }
    }

}