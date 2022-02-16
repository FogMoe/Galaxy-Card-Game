using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData : MonoBehaviour
{
    public CardStore CardStore;
    public int playerCoins;
    public int[] playerCards;
    public string playerName;
    public int[] playerDeck;

    public TextAsset playerData;
    // Start is called before the first frame update
    void Start()
    {
        CardStore.LoadCardData();
        LoadPlayerData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadPlayerData()
    {
        playerCards = new int[CardStore.cardList.Count];
        playerDeck = new int[CardStore.cardList.Count];
        string[] dataRow = playerData.text.Split('\n');
        foreach (var row in dataRow)
        {
            string[] rowArray = row.Split(',');
            if (rowArray[0] == "PlayerName")
            {
                playerName = rowArray[1];
            }
            else if (rowArray[0] == "GalaxyCoins")
            {
                playerCoins = int.Parse(rowArray[1]);
            }
            else if (rowArray[0] == "OwnCards")
            {
                int id = int.Parse(rowArray[1]) - 10000;
                int amouts = int.Parse(rowArray[2]);
                playerCards[id] = amouts;
            }
            else if (rowArray[0] == "Deck")
            {
                int id = int.Parse(rowArray[1]) - 10000;
                int amouts = int.Parse(rowArray[2]);
                playerDeck[id] = amouts;
            }
        }
    }

    public void SavePlayerData()
    {
        string path = Application.dataPath + "/Data/PlayerData.csv";


        List<string> datas = new List<string>();
        datas.Add("PlayerName," + playerName);
        datas.Add("GalaxyCoins," + playerCoins.ToString());

        for (int i = 0; i < playerCards.Length; i++)
        {
            if (playerCards[i] != 0)
            {
                //存储持有的卡和持有卡的数量
                int ex = i + 10000;
                datas.Add("OwnCards," + ex.ToString() + "," + playerCards[i].ToString());
            }           
        }
        //卡组
        for (int i = 0; i < playerDeck.Length; i++)
        {
            if (playerDeck[i] != 0)
            {
                
                int ex = i + 10000;
                datas.Add("Deck," + ex.ToString() + "," + playerDeck[i].ToString());
            }
        }
        //存储数据
        File.WriteAllLines(path, datas);
    }
}
