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
        //TestLoad();  //�������п��ļ���״̬
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
            if (rowArray[0] == "Type(����)")
            {
                continue;
            }
            else if (rowArray[0] == "FleetCard")
            {
                //�½����ӿ�
                int id = int.Parse(rowArray[1]);
                string cardName = rowArray[2];
                int rarity = int.Parse(rowArray[3]);
                int cost = int.Parse(rowArray[4]);
                string effect = rowArray[5];
                int constantCost = int.Parse(rowArray[6]);
                int health = int.Parse(rowArray[7]);
                int attack = int.Parse(rowArray[8]);
                int weapon = int.Parse(rowArray[9]);
                string type = "���ӿ�";
                FleetCard fleetCard = new FleetCard(effect,constantCost,health,attack,weapon,id,cardName,cost,rarity,type);
                cardList.Add(fleetCard);
                
            }
            else if (rowArray[0] == "BasicCard")
            {
                //�½�������
                int id = int.Parse(rowArray[1]);
                string cardName = rowArray[2];
                int rarity = int.Parse(rowArray[3]);
                int cost = int.Parse(rowArray[4]);
                string effect = rowArray[5];
                int constantGain = int.Parse(rowArray[6]);
                int health = int.Parse(rowArray[7]);
                string type = "������";
                BasicCard basicCard = new BasicCard(constantGain, health, effect, id, cardName, cost, rarity, type);
                cardList.Add(basicCard);
            }
            else if (rowArray[0] == "BuffCard")
            {
                //�½����濨
                int id = int.Parse(rowArray[1]);
                string cardName = rowArray[2];
                int rarity = int.Parse(rowArray[3]);
                int cost = int.Parse(rowArray[4]);
                string effect = rowArray[5];
                string type = "���濨";
                BuffCard buffCard = new BuffCard(effect, id, cardName, cost, rarity, type);
                cardList.Add(buffCard);

            }
            else if (rowArray[0] == "BattleCard")
            {
                //�½�ս����
                int id = int.Parse(rowArray[1]);
                string cardName = rowArray[2];
                int rarity = int.Parse(rowArray[3]);
                int cost = int.Parse(rowArray[4]);
                string effect = rowArray[5];
                string type = "ս����";
                BattleCard battleCard = new BattleCard(effect, id, cardName, cost, rarity, type);
                cardList.Add(battleCard);

            }
        }
    }
    /*public void TestLoad() //Debug
    {
        foreach (var item in cardList)
        {
            Debug.Log("�Ѽ��ؿ��ƣ�" + item.id.ToString() + item.cardName);
        }
    }*/

    public Card RandomCard()
    {
        //��ϡ�жȸ������һ�ſ�[0=Normal(��ɫ45%) ,1=Rare(��ɫ30%) ��2=Epic(��ɫ18%) ��3=Legendary(��ɫ6%) ��4=Unique(��ɫ1%)]
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
            Debug.Log("�鿨���ʼ��㷢������" );
            card = null;
        }
        return card;
    } 
}
