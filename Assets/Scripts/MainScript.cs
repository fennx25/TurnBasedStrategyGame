using System.IO;
using System.Xml.Serialization;
using UnityEngine;

//http://heroescommunity.com/viewthread.php3?TID=31210&pagenumber=9
//archangel
//https://onedrive.live.com/?id=C74367DE5EF781A2%21141&cid=C74367DE5EF781A2

//http://heroescommunity.com/viewthread.php3?TID=31210&pagenumber=3

//https://sites.google.com/site/gr2archive/downloads

//https://forum.xentax.com/viewtopic.php?t=4644

public class MainScript : MonoBehaviour
{
    public Transform cube;
    public Transform cube2;
    public Transform cube3;
    public Transform passable;

    public Adv.AdvMapDesc res;

    string dataPath = "Assets/Resources/data";
    
    void Start()
    {
        string path = "Assets/Resources/data/Maps/Scenario/C1M1/";

        XmlSerializer serializer = new XmlSerializer(typeof(Adv.AdvMapDesc));
        using (StreamReader streamReader = new StreamReader(path + "C1M1.xdb"))
        {
            res = (Adv.AdvMapDesc)serializer.Deserialize(streamReader);

            DataProc.TerrainData t = new DataProc.TerrainData(path + res.GroundTerrainFileName.Href);

            //t.nPassible.Draw1(transform, passable, 0, t.nXSize, t.nYSize);
            //t.nPlateau.Draw1(transform, passable, 6, t.nXSize, t.nYSize);
            //t.nHeight.Draw1(transform, cube, 2, t.nXSize, t.nYSize);
            //t.nWater.Draw1(transform, cube3, 3, t.nXSize, t.nYSize);
            //t.nRamp.Draw1(transform, cube, 4, t.nXSize, t.nYSize);

            GetComponent<MeshBuilderScript>().Build(t.nHeight, t.nXSize, t.nYSize);
            GetComponent<MeshBuilderScript>().ApplyTextures(t);
            GetComponent<MeshBuilderScript>().LoadOpacityMapsForPreview(t);

            var water = GameObject.Find("Water");
            water.GetComponent<WaterMeshBuilder>().Build(t.nWater, t.nXSize, t.nYSize);

            for (int i = 0; i < res.Objects.Item.Count; i++) {

                var obj = res.Objects.Item[i].AdvMapStatic;

                if (obj != null) {

                    var tr = Instantiate(cube);
                    tr.name = obj.Shared.Href;
                    tr.position = new Vector3(
                        obj.Pos.X,
                        GetComponent<MeshBuilderScript>().height(t.nHeight, t.nXSize, t.nYSize, obj.Pos.X, obj.Pos.Y) / 2 + 0.1f,
                        obj.Pos.Y);

                    Material mat = tr.GetComponent<Renderer>().material;
                    mat.mainTexture = LoadSome(obj.Shared.Href);
                }

                var mapDwelling = res.Objects.Item[i].AdvMapDwelling;

                if (mapDwelling != null)
                {

                    var tr = Instantiate(cube);
                    tr.name = mapDwelling.Shared.Href;
                    tr.position = new Vector3(mapDwelling.Pos.X, 5, mapDwelling.Pos.Y);
                    tr.localScale = new Vector3(1, 2, 1);

                    Material mat = tr.GetComponent<Renderer>().material;
                    mat.mainTexture = LoadDweling(mapDwelling.Shared.Href);
                }

                var mapMonster = res.Objects.Item[i].AdvMapMonster;

                if (mapMonster != null)
                {

                    var tr = Instantiate(cube2);
                    tr.position = new Vector3(mapMonster.Pos.X, 5, mapMonster.Pos.Y);
                    tr.localScale = new Vector3(1, 1, 1);
                }

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Texture2D LoadSome(string href) 
    {
        Adv.AdvMapStaticShared mapElement;
        XmlSerializer serializer = new XmlSerializer(typeof(Adv.AdvMapStaticShared));
        string mapElementHref = href;
        mapElementHref = mapElementHref.Remove(mapElementHref.IndexOf("#"));

        string res = dataPath + mapElementHref;

        Debug.Log(res);

        using (StreamReader streamReader = new StreamReader(res))
        {
            mapElement = (Adv.AdvMapStaticShared)serializer.Deserialize(streamReader);
        }

        if (mapElement.Model.Href == null) {
            return null;
        }

        string modelHref = mapElement.Model.Href.Remove(mapElement.Model.Href.IndexOf("#"));

        //--

        Adv.Model model;
        XmlSerializer serializer2 = new XmlSerializer(typeof(Adv.Model));
        
        string res2 = dataPath + modelHref;

        using (StreamReader streamReader2 = new StreamReader(res2))
        {
            model = (Adv.Model)serializer2.Deserialize(streamReader2);
        }

        for (int i = 0; i < model.Materials.Item.Count; i++)
        {
            var item = model.Materials.Item[i];
            if (item.Material == null) {
                continue;
            }
            var tex = item.Material.Texture.Texture2D();
            Debug.Log("");
            return tex;
        }

        return null;
    }

    Texture2D LoadDweling(string href)
    {
        Adv.AdvMapDwellingShared mapElement;
        XmlSerializer serializer = new XmlSerializer(typeof(Adv.AdvMapDwellingShared));
        string mapElementHref = href;
        mapElementHref = mapElementHref.Remove(mapElementHref.IndexOf("#"));

        string res = dataPath + mapElementHref;

        Debug.Log(res);

        using (StreamReader streamReader = new StreamReader(res))
        {
            mapElement = (Adv.AdvMapDwellingShared)serializer.Deserialize(streamReader);
        }
        
        if (mapElement.Model.Href == null)
        {
            return null;
        }

        string modelHref = mapElement.Model.Href.Remove(mapElement.Model.Href.IndexOf("#"));

        //--

        Adv.Model model;
        XmlSerializer serializer2 = new XmlSerializer(typeof(Adv.Model));

        string res2 = dataPath + modelHref;

        using (StreamReader streamReader2 = new StreamReader(res2))
        {
            model = (Adv.Model)serializer2.Deserialize(streamReader2);
        }

        for (int i = 0; i < model.Materials.Item.Count; i++)
        {
            var item = model.Materials.Item[i];
            if (item.Material == null)
            {
                continue;
            }
            var tex = item.Material.Texture.Texture2D();
            Debug.Log("");
            return tex;
        }

        return null;
    }

}
