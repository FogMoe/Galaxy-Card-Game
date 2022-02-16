using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCardPackage : MonoBehaviour
{
    public GameObject earthCardPack;
    public GameObject cardPool;
    CardStore CardStore;
    List<GameObject> cards = new List<GameObject>();

    public PlayerData PlayerData;
    // Start is called before the first frame update
    void Start()
    {
        CardStore = GetComponent<CardStore>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void earthCardPackOnClickOpen()
    {
        if (PlayerData.playerCoins < 9600)
        {
            //提示钱不够无法抽卡
            return;
        }
        else
        {
            PlayerData.playerCoins -= 9600;
        }

        ClearPool();
        //全卡包抽卡按钮被点击
        for (int i = 0; i < 2; i++)
        {
            GameObject newCard = GameObject.Instantiate(earthCardPack,cardPool.transform);

            newCard.GetComponent<CardDisplay>().card = CardStore.RandomCard();
            cards.Add(newCard);
        }
        SaveCardData();
        PlayerData.SavePlayerData();
    }

    public void ClearPool()
    {
        foreach (var card in cards)
        {
            Destroy(card);
        }
        cards.Clear();
    }

    public void SaveCardData()
    {
        foreach (var card in cards)
        {
            int id = card.GetComponent<CardDisplay>().card.id;
            PlayerData.playerCards[id-10000] += 1;
        }
    }
}
