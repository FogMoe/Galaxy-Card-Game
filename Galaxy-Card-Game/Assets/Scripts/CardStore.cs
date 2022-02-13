using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStore : MonoBehaviour
{
    public TextAsset cardData;
    public List<Card> cardList = new List<Card>();
    // Start is called before the first frame update
    void Start()
    {
        LoadCardData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadCardData()
    {
        string[] dataRow = cardData.text.Split('\n');
        foreach (var row in dataRow)
        {
            string[] rowArray = row.Split(',');
            if (rowArray[0] == "Type(类型)")
            {
                continue;
            }
            else if (rowArray[0] == "FleetCard")
            {
                //新建舰队卡
                int id = int.Parse(rowArray[1]);
                string cardName = rowArray[2];
                int rarity = int.Parse(rowArray[3]);
                int cost = int.Parse(rowArray[4]);
                string effect = rowArray[5];
                int constantCost = int.Parse(rowArray[6]);
                int health = int.Parse(rowArray[7]);
                int attack = int.Parse(rowArray[8]);
                int weapon = int.Parse(rowArray[9]);
                string type = "舰队卡";
                FleetCard fleetCard = new FleetCard(effect,constantCost,health,attack,weapon,id,cardName,cost,rarity,type);
                cardList.Add(fleetCard);

                Debug.Log("已读取的卡：" + fleetCard.id + fleetCard.cardName);
            }
            else if (rowArray[0] == "BasicCard")
            {
                //新建基础卡
            }
            else if (rowArray[0] == "BuffCard")
            {
                //新建增益卡
            }
            else if (rowArray[0] == "BattleCard")
            {
                //新建战斗卡
            }
        }
    }
}
