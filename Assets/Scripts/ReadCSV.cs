using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using UnityEditor;


public class ReadCSV : MonoBehaviour
{
    public TextAsset textAssetData;
   
    public string[] Data;
    // public string[] Data => _data;


    [System.Serializable]
    public class Properties {
        public int trait1;
        public int trait2;
        public int trait3;
        public int trait4;
        public int trait5;
        public int trait6;
        public int trait7;
       // public int trait8;

    }

    [System.Serializable]
    public class NFT
    {
        public string name;
        public int typeHunter;
        public string id;
        public string videoName;
        public int rarity;
        public Properties properties = new Properties();
    }

    
    [System.Serializable]
    public class NFTList  {
        public List<NFT> NFTs = new List<NFT>();
    }
    public NFTList myNFTList = new NFTList();

    // Start is called before the first frame update
    private void Awake()
    {
        ReadCSVs();
    }
    private void Start()
    {
      
    }
    private void ExportJsonFile(){
         for ( int i = 0; i < Data.Length; i++) {
            string[] bodyPart = Data[i].Split(",");
            Properties propertiesTemp  = new Properties() {
                 trait1 = int.Parse(bodyPart[0][1].ToString()),
                 trait2 = int.Parse(bodyPart[1][1].ToString()),
                 trait3 = int.Parse(bodyPart[2][1].ToString()),
                 trait4 = int.Parse(bodyPart[3][1].ToString()),
                 trait5 = int.Parse(bodyPart[4][1].ToString()),
                 trait6 = int.Parse(bodyPart[5][1].ToString()),
                 trait7 = int.Parse(bodyPart[6][1].ToString()),
                // trait8 = int.Parse(bodyPart[7][1].ToString()),
            };
              int rarityTemp = 0;
            for (int j = 0; j < bodyPart.Length; j++) {
                rarityTemp += int.Parse(bodyPart[j][1].ToString());
            }
          
            string targetId = "01"+string.Join("", Data[i].Split(","));
            targetId = targetId.Replace("\r", "");

            NFT nft = new NFT(){ 
                name = "Disry",
                typeHunter = 1,
                id = targetId,
                videoName = $"{targetId}.mp4",
                rarity = rarityTemp,
                properties = propertiesTemp
            };
            myNFTList.NFTs.Add(nft);
        }
        WriteJson();
    }
    
    private void Update() {
        //if(Input.GetKeyDown(KeyCode.T)) WriteJson();
    }

    void ReadCSVs()
    {
        Data = textAssetData.text.Split(new string[] { "\n" }, StringSplitOptions.None);
        // System.Random rnd=new System.Random();
        // string[] MyRandomArray = Data.OrderBy(x => rnd.Next()).ToArray();  
        // Data = MyRandomArray;
        ExportJsonFile();
        File.WriteAllText(Application.dataPath + "/JsonFile/disry-export-data.csv", string.Join("", Data));

    }
    public void WriteJson()
    {
        Debug.Log("write");
        string outputList = JsonUtility.ToJson(myNFTList);
        File.WriteAllText(Application.dataPath + "/JsonFile/disry-nftlist.json",outputList);
    }

}


