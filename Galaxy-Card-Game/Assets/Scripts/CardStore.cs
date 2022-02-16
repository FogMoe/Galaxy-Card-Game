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
        //LoadCardData();
        //TestLoad();  //测试所有卡的加载状态
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
                
            }
            else if (rowArray[0] == "BasicCard")
            {
                //新建基础卡
                int id = int.Parse(rowArray[1]);
                string cardName = rowArray[2];
                int rarity = int.Parse(rowArray[3]);
                int cost = int.Parse(rowArray[4]);
                string effect = rowArray[5];
                int constantGain = int.Parse(rowArray[6]);
                int health = int.Parse(rowArray[7]);
                string type = "基础卡";
                BasicCard basicCard = new BasicCard(constantGain, health, effect, id, cardName, cost, rarity, type);
                cardList.Add(basicCard);
            }
            else if (rowArray[0] == "BuffCard")
            {
                //新建增益卡
                int id = int.Parse(rowArray[1]);
                string cardName = rowArray[2];
                int rarity = int.Parse(rowArray[3]);
                int cost = int.Parse(rowArray[4]);
                string effect = rowArray[5];
                string type = "增益卡";
                BuffCard buffCard = new BuffCard(effect, id, cardName, cost, rarity, type);
                cardList.Add(buffCard);

            }
            else if (rowArray[0] == "BattleCard")
            {
                //新建战斗卡
                int id = int.Parse(rowArray[1]);
                string cardName = rowArray[2];
                int rarity = int.Parse(rowArray[3]);
                int cost = int.Parse(rowArray[4]);
                string effect = rowArray[5];
                string type = "战斗卡";
                BattleCard battleCard = new BattleCard(effect, id, cardName, cost, rarity, type);
                cardList.Add(battleCard);

            }
        }
    }
    /*public void TestLoad() //Debug
    {
        foreach (var item in cardList)
        {
            Debug.Log("已加载卡牌：" + item.id.ToString() + item.cardName);
        }
    }*/

    public Card RandomCard()
    {
        //按稀有度概率随机一张卡[0=Normal(白色45%) ,1=Rare(蓝色30%) ，2=Epic(紫色18%) ，3=Legendary(橙色6%) ，4=Unique(红色1%)]
        int randomNumber = Random.Range(0, 99);

        List<Card> normalCard = new List<Card>();
        List<Card> rareCard = new List<Card>();
        List<Card> epicCard = new List<Card>();
        List<Card> legendaryCard = new List<Card>();
        List<Card> uniqueCard = new List<Card>();
        Card card;
        foreach (var item in cardList)
        {
            if (item.rarity == 0)
            {
                normalCard.Add(item);
            }
            else if (item.rarity == 1)
            {
                rareCard.Add(item);
            }
            else if (item.rarity == 2)
            {
                epicCard.Add(item);
            }
            else if (item.rarity == 3)
            {
                legendaryCard.Add(item);
            }
            else if (item.rarity == 4)
            {
                uniqueCard.Add(item);
            }
        }
        if (randomNumber != -1) //randomNumber < 45 
        {
            card = normalCard[Random.Range(0, normalCard.Count)];
        }
        /*else if (randomNumber >=45 && randomNumber < 75)
        {
            card = rareCard[Random.Range(0, rareCard.Count)];            
        }
        else if (randomNumber >= 75 && randomNumber < 93)
        {
            card = epicCard[Random.Range(0, epicCard.Count)];
        }
        else if (randomNumber >= 93 && randomNumber < 99)
        {
            card = legendaryCard[Random.Range(0, legendaryCard.Count)];
        }
        else if (randomNumber == 99)
        {
            card = uniqueCard[Random.Range(0, uniqueCard.Count)];
        }*/
        else
        {
            Debug.Log("抽卡概率计算发生错误！" );
            card = null;
        }
        return card;
    } 
}
