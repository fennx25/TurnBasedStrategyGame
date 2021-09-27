using System;
using System.IO;
using System.Xml.Serialization;

namespace DataProc
{
    public class TerrainLayerBlock : TerrainDataBlock<byte> // Texture层的单层对象
    {
        public string stTexturePath;
        public byte[] nPathTag = new byte[4];
        public byte[] nLayerSizeTag = new byte[1] { 0x01 };
        public TerrainLayerBlock()
            : base(new byte[1] { 0x02 }, new IByteToColor(), new INumberToHexView<byte>())
        {
        }
        public TerrainLayerBlock(UInt32 nBaseLength)
            : base(new byte[1] { 0x02 }, nBaseLength, new IByteToColor(), new INumberToHexView<byte>())
        {
        }

        // 比TerrainData类多了读取一个头和一个字符串的任务
        // It has more tasks to read a header and a string than the TerrainData class
        public TerrainDataError LoadLayer(BinaryReader brData)
        {
            brData.ReadBytes(nLayerSizeTag.Length);
            UInt32 nLayerSize = (brData.ReadUInt32() - 1) / 2;
            base.Load(brData, new byte[1] { 0x02 }, true);
            nPathTag = brData.ReadBytes(4);
            stTexturePath = new string(brData.ReadChars((int)(nLayerSize - sizeof(byte) * nPathTag.Length - nSize - 5)));
            return TerrainDataError.None;
        }

        public int nLayerLength
        {
            get
            {
                return nTotalLength + stTexturePath.Length + 4 + 5;//+字符串+字符串长度+普通块自身长度
            }
        }
        public string stLayerName
        {
            get
            {
                return stTexturePath.Substring(26, stTexturePath.Length - 26 - 26);
            }
        }

        public UnityEngine.Texture2D OpacityTexture()
        {
            int nRowsCount = tContent.GetLength(0);
            int nColumnsCount = tContent.GetLength(1);

            var temp = new UnityEngine.Texture2D(nColumnsCount, nRowsCount, UnityEngine.TextureFormat.R8, false);
            temp.LoadRawTextureData(FlattenOpacityBytes());
            temp.Apply();
            return temp;

        }

        public UnityEngine.Texture2D Texture()
        {
            string path = "Assets/Resources/data/";

            Adv.AdvMapTile mapTile;
            XmlSerializer serializer = new XmlSerializer(typeof(Adv.AdvMapTile));
            string path1 = stTexturePath;
            path1 = path1.Remove(path1.IndexOf("#"));
            using (StreamReader streamReader = new StreamReader(path + path1))
            {
                mapTile = (Adv.AdvMapTile)serializer.Deserialize(streamReader);
            }

            Adv.TextureFile textureFile;
            XmlSerializer serializer2 = new XmlSerializer(typeof(Adv.TextureFile));
            string textureHref = mapTile.Texture.Href;
            textureHref = textureHref.Remove(textureHref.IndexOf("#"));

            using (StreamReader streamReader = new StreamReader(path + textureHref))
            {
                textureFile = (Adv.TextureFile)serializer2.Deserialize(streamReader);
            }

            string textureImageFileHref = textureHref.Remove(textureHref.LastIndexOf("/")) + "/" + textureFile.DestName.Href;


            //if (File.Exists(path + textureImageFileHref))
            //{

            var bytes = File.ReadAllBytes(path + textureImageFileHref);
            if (textureFile.Format == "TF_8888") {
                var temp = new UnityEngine.Texture2D(1024, 1024, UnityEngine.TextureFormat.ARGB32, false);
                temp.LoadRawTextureData(bytes);
                temp.Apply();
                return temp;
            } else {
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




        //public void SaveLayer(BinaryWriter brData) // 比TerrainData类多了一个写入头和写入字符串
        //{
        //    brData.Write(nLayerSizeTag);
        //    brData.Write((UInt32)nLayerLength * 2 + 1);
        //    base.Save(brData);
        //    brData.Write((byte)0x03);
        //    brData.Write((byte)(stTexturePath.Length * 2 + 4));
        //    brData.Write((byte)0x03);
        //    brData.Write((byte)(stTexturePath.Length * 2));
        //    brData.Write(System.Text.Encoding.ASCII.GetBytes(stTexturePath));
        //}
    }
}

//"/mapobjects/_(advmaptile)/road/road.xdb#xpointer(/AdvMapTile)"

//-0
//road / road
/// mapobjects / _(advmaptile) / road / road.xdb#xpointer(/AdvMapTile)
//- 1
//dirt / darkground
/// mapobjects / _(advmaptile) / dirt / darkground.xdb#xpointer(/AdvMapTile)
//- 2
//dirt / ground
/// mapobjects / _(advmaptile) / dirt / ground.xdb#xpointer(/AdvMapTile)

//- 3
//grass / dark_grass
/// mapobjects / _(advmaptile) / grass / dark_grass.xdb#xpointer(/AdvMapTile)
//- 4
//grass / grass
/// mapobjects / _(advmaptile) / grass / grass.xdb#xpointer(/AdvMapTile)
//- 5
//grass / flowers
/// mapobjects / _(advmaptile) / grass / flowers.xdb#xpointer(/AdvMapTile)

//- 6
//grass / field
/// mapobjects / _(advmaptile) / grass / field.xdb#xpointer(/AdvMapTile)
//- 7
//grass / used_grass
/// mapobjects / _(advmaptile) / grass / used_grass.xdb#xpointer(/AdvMapTile)
//- 8
//sand / river - bed
/// mapobjects / _(advmaptile) / sand / river - bed.xdb#xpointer(/AdvMapTile)
//- 9
//water / water
/// mapobjects / _(advmaptile) / water / water.xdb#xpointer(/AdvMapTile)
//- 10
//grass / road
/// mapobjects / _(advmaptile) / grass / road.xdb#xpointer(/AdvMapTile)
//- 11
//grass / stoneroad
/// mapobjects / _(advmaptile) / grass / stoneroad.xdb#xpointer(/AdvMapTile)

//UnityEngine.Debug:Log(Object)
//MeshBuilderScript: ApplyTextures(TerrainData)(at Assets / Scripts / MeshBuilderScript.cs:105)
//MainScript: Start()(at Assets / Scripts / MainScript.cs:40)
