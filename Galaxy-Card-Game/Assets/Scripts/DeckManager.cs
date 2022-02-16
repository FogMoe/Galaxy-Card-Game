using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public Transform deckPanel;
    public Transform libraryPanel;

    public GameObject deckPrefab;
    public GameObject cardPrefab;

    public GameObject DataManager;

    private PlayerData PlayerData;
    private CardStore CardStore;

    private Dictionary<int, GameObject> libraryDic = new Dictionary<int, GameObject>();
    private Dictionary<int, GameObject> deckDic = new Dictionary<int, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        PlayerData = DataManager.GetComponent<PlayerData>();
        CardStore = DataManager.GetComponent<CardStore>();

        UpdateLibrary();
        UpdateDeck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLibrary()
    {
        for (int i = 0; i < PlayerData.playerCards.Length; i++)
        {
            if (PlayerData.playerCards[i] > 0)
            {
                GameObject newCard = Instantiate(cardPrefab,libraryPanel);
                newCard.GetComponent<CardCounter>().counter.text = PlayerData.playerCards[i].ToString();
                newCard.GetComponent<CardDisplay>().card = CardStore.cardList[i];
                libraryDic.Add(i + 10000, newCard);
            }
        }
    }

    public void UpdateDeck()
    {
        for (int i = 0; i < PlayerData.playerDeck.Length; i++)
        {
            if (PlayerData.playerDeck[i] > 0)
            {
                GameObject newCard = Instantiate(deckPrefab,deckPanel);
                newCard.GetComponent<CardCounter>().counter.text = PlayerData.playerDeck[i].ToString();
                newCard.GetComponent<CardDisplay>().card = CardStore.cardList[i];
                deckDic.Add(i + 10000, newCard);
                
            }
        }
    }

    public void UpdateCard(CardState _state, int _id)
    {
        if (_state == CardState.Deck)
        {

        }
        else if (_state == CardState.Library)
        {

        }
    }
}
