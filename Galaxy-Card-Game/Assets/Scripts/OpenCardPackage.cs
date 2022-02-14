using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCardPackage : MonoBehaviour
{
    public GameObject earthCardPack;
    public GameObject cardPool;
    CardStore CardStore;
    List<GameObject> cards = new List<GameObject>();
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
        ClearPool();
        //全卡包抽卡按钮被点击
        for (int i = 0; i < 2; i++)
        {
            GameObject newCard = GameObject.Instantiate(earthCardPack,cardPool.transform);

            newCard.GetComponent<CardDisplay>().card = CardStore.RandomCard();
            cards.Add(newCard);
        }
    }

    public void ClearPool()
    {
        foreach (var card in cards)
        {
            Destroy(card);
        }
        cards.Clear();
    }
}
