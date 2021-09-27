using System;
using System.Collections.Generic;
using System.IO;

namespace DataProc
{

    public class TerrainData
    {
        public UInt32 nXSize; //地图尺寸（格子数）
        public UInt32 nYSize;
        public UInt32 nLayer; // Texture层数

        // 第一块，地形透明度,由多块地形构成，8bit
        // The first piece, terrain transparency, is composed of multiple pieces of terrain, 8bit
        public List<TerrainLayerBlock> nTextureList = new List<TerrainLayerBlock>();

        // 第二块，视觉高度，32bit浮点
        // The second block, visual height, 32bit floating point
        public TerrainDataBlock<Single> nHeight = new TerrainDataBlock<float>(bBlockTag[1], new IHeightToColor(), new IHeightToHexView());

        // 第三块，平台位置,8bit
        // The third block, platform position, 8bit
        public TerrainDataBlock<Byte> nPlateau = new TerrainDataBlock<byte>(bBlockTag[2],new IPlateauToColor(), new INumberToHexView<byte>());

        // 未知U1，8bit，一般全0
        //Unknown U1, 8bit, generally all 0
        public TerrainDataBlock<Byte> nRamp = new TerrainDataBlock<byte>(bBlockTag[3], new IPassibleToColor(), new INumberToHexView<byte>());

        // 未知U2，8bit，一般全0，为(size*2-1)^2
        // Unknown U2, 8bit, generally all 0, which is (size*2-1)^2
        public TerrainDataBlock<Byte> nWater = new TerrainDataBlock<byte>(bBlockTag[4],new IByteToColor(), new INumberToHexView<byte>());

        // Unknow2和Pass之间多出来的0D打头的一段
        // The extra 0D beginning section between Unknow2 and Pass
        static public byte[] n0DBlock;

        // 同上，不过0E打头
        // Same as above, but starts with 0E
        static public byte[] n0EBlock;

        // 可通过性，8bit
        // Passability, 8bit
        public TerrainDataBlock<Byte> nPassible = new TerrainDataBlock<byte>(bBlockTag[5],new IPassibleToColor(), new INumberToHexView<byte>());

        // 未知U4，8bit
        // Unknown U4, 8bit
        public TerrainDataBlock<UInt64> nUnknown4 = new TerrainDataBlock<UInt64>(bBlockTag[6],new IUInt64ToColor(), new IUInt64ToHexView());

        public bool nUnknown4Exist = true;
        static public List<Byte[]> bBlockTag;
        static public byte[] nStartBlock;
        static public byte[] nXSizeTag;
        static public byte[] nYSizeTag;
        static public byte[] nEndBlock;
        static public byte[] nLayerTag;
        static TerrainData()
        {
            bBlockTag = new List<Byte[]> { 
                new byte[1] { 0x04 }, 
                new byte[1] { 0x05 }, 
                new byte[1] { 0x07 }, 
                new byte[1] { 0x08 }, 
                new byte[1] { 0x0A },
                new byte[1] { 0x0F },
                new byte[1] { 0x10 }
            };
            n0DBlock = new byte[] { 0x0D, 0x18, 0x01, 0x08, 0x00, 0x00, 0x00, 0x00, 0x02, 0x08, 0x00, 0x00, 0x00, 0x00 };
            n0EBlock = new byte[] { 0x0E, 0x02, 0x01 };
            nStartBlock = new byte[] { 0x04, 0x08, 0x04, 0x0, 0x0, 0x0 };
            nXSizeTag = new byte[] { 0x02, 0x08 };
            nYSizeTag = new byte[] { 0x03, 0x08 };
            nLayerTag = new byte[] { 0x02, 0x08 };
            nEndBlock = new byte[] { 0x00, 0x00, 0x02, 0x00, 0x05, 0x00 };
        }

        public int nTextureLength
        {
            get
            {
                int nLength = 6; //层数+层数标记
                foreach (TerrainLayerBlock mlbTemp in nTextureList)
                {
                    nLength += mlbTemp.nLayerLength + 5; //块长度5
                }
                return nLength;
            }
        }
        public int nTotalLength
        {
            get
            {
                return nTextureLength + 5
                    + nHeight.nTotalLength + 5
                    + nPlateau.nTotalLength + 5
                    + nRamp.nTotalLength + 5
                    + nWater.nTotalLength + 5
                    + nPassible.nTotalLength + 5
                    + nUnknown4.nTotalLength + 5
                    + n0DBlock.Length
                    + n0EBlock.Length
                    + 6*2; //地图长宽格子数
            }
        }

        public TerrainData(string stFileName)
        {
            int i;
            FileStream binData = new FileStream(stFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            BinaryReader brData = new BinaryReader(binData);
            brData.ReadBytes(16);//跳过开头16个
            brData.ReadBytes(2);
            nXSize = brData.ReadUInt32();
            brData.ReadBytes(2);
            nYSize = brData.ReadUInt32();//读取格子数
            //Texture部分
            brData.ReadBytes(7);
            nLayer = brData.ReadUInt32();//读取层数
            for (i = 0; i < nLayer; i++)
            {
                TerrainLayerBlock aMLB = new TerrainLayerBlock();
                aMLB.LoadLayer(brData);
                nTextureList.Add(aMLB);
            }
            //逐部分读取
            ///Read part by part
            for (i = 1; i <= 5; i++)
            {
                ((IExportGridInfo)this[i]).Load(brData,bBlockTag[i],true);
                if (i == 4)
                {
                    brData.ReadBytes(n0DBlock.Length + n0EBlock.Length);
                }
            }
            if (nUnknown4.Load(brData, bBlockTag[6], false) == TerrainDataError.TagZero)
            {
                nUnknown4Exist = false;
            }
            U4Generate(nXSize);

            brData.Close();
            binData.Close();
        }
        public TerrainData(UInt32 nBaseLength) // 新建一个指定尺寸的GroundTerrain.bin
        {
            //全局尺寸格子数
            // Global size grid number
            nXSize = nBaseLength;
            nYSize = nBaseLength;
            //Texture部分
            nLayer = 1;
            TerrainLayerBlock aMLB = new TerrainLayerBlock();
            aMLB.stTexturePath = "/MapObjects/_(AdvMapTile)/Grass/Grass.xdb#xpointer(/AdvMapTile)";
            aMLB.CreateContentWithInitValue(nBaseLength + 1, 0xFF);
            nTextureList.Add(aMLB);
            //其他部分
            nHeight.CreateContentWithInitValue(nBaseLength + 1,(float)2.00);
            nPlateau.CreateContentWithInitValue(nBaseLength + 1,0x10);
            nRamp.CreateContentWithInitValue(nBaseLength + 1, 0x0);
            nWater.CreateContentWithInitValue(nBaseLength * 2 + 1, 0x0);
            nPassible.CreateContentWithInitValue(nBaseLength + 1,0x01);
            //nUnknown4生成，尺寸在函数内计算
            U4Generate(nBaseLength);
        }

        private void U4Generate(UInt32 nBaseLength)
        {
            nUnknown4.CreateContent((UInt32)Math.Ceiling((double)(nBaseLength + 2) / 3));
            nUnknown4.bExistTag = false;
            UInt32 U4GeneratorRow = 0;
            UInt32 U4GeneratorColumn = 0;
            for (int i = 0; i < nUnknown4.tContent.GetLength(0); i++)
            {
                for (int j = 0; j < nUnknown4.tContent.GetLength(1); j++)
                {
                    nUnknown4.tContent[i, j] = BitConverter.ToUInt64(new byte[8] { 0x03, 0x0C, 0x02, 0x02, 0x00, 0x03, 0x02, BitConverter.GetBytes(U4GeneratorRow + U4GeneratorColumn)[0] }, 0);
                    U4GeneratorColumn += 0x43;
                }
                U4GeneratorRow += 0x7B;
                U4GeneratorColumn = 0x0;
            }
        }

        //public void Save(string stFileName)
        //{
        //    int i = 0;
        //    FileStream binData = new FileStream(stFileName, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
        //    BinaryWriter brData = new BinaryWriter(binData);
        //    brData.Write(nStartBlock);
        //    brData.Write((byte)0x01);
        //    brData.Write((UInt32)(nTotalLength + 5) * 2 + 1);
        //    brData.Write((byte)0x01);
        //    brData.Write((UInt32)nTotalLength * 2 + 1);
        //    brData.Write(nXSizeTag);
        //    brData.Write(nXSize);
        //    brData.Write(nYSizeTag);
        //    brData.Write(nYSize);
        //    brData.Write(bBlockTag[0]);
        //    brData.Write((UInt32)(nTextureLength * 2 + 1));
        //    brData.Write(nLayerTag);
        //    brData.Write((UInt32)nLayer);
        //    for (i = 0; i < nLayer; i++)
        //    {
        //        nTextureList[i].SaveLayer(brData);
        //    }
        //    for (i = 1; i <= 6; i++)
        //    {
        //        ((IExportGridInfo)this[i]).Save(brData);
        //        if (i == 4)
        //        {
        //            brData.Write(n0DBlock);
        //            brData.Write(n0EBlock);
        //        }
        //    }
        //    brData.Write(nEndBlock);
        //    brData.Close();
        //    binData.Close();
        //}

        public object this[int nIndex]
        {
            get
            {
                switch (nIndex)
                {
                    case 1:
                        return nHeight;
                    case 2:
                        return nPlateau;
                    case 3:
                        return nRamp;
                    case 4:
                        return nWater;
                    case 5:
                        return nPassible;
                    case 6:
                        return nUnknown4;
                    default:
                        return null;
                }
            }
        }
    }
}
