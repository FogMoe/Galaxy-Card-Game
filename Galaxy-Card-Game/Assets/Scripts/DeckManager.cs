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
                CreateCard(i, CardState.Library);
            }
        }
    }

    public void UpdateDeck()
    {
        for (int i = 0; i < PlayerData.playerDeck.Length; i++)
        {
            if (PlayerData.playerDeck[i] > 0)
            {
                CreateCard(i, CardState.Deck);


            }
        }
    }

    public void UpdateCard(CardState _state, int _id)
    {
        if (_state == CardState.Deck)
        {
            PlayerData.playerDeck[_id]--;
            PlayerData.playerCards[_id]++;

            deckDic[_id].GetComponent<CardCounter>().SetCounterValue(-1);
            if (libraryDic.ContainsKey(_id))
            {
                libraryDic[_id].GetComponent<CardCounter>().SetCounterValue(1);
            }
            else
            {
                CreateCard(_id, CardState.Library);
            }

        }
        else if (_state == CardState.Library)
        {
            PlayerData.playerDeck[_id]++;
            PlayerData.playerCards[_id]--;


            if (deckDic.ContainsKey(_id))
            {
                deckDic[_id].GetComponent<CardCounter>().SetCounterValue(1);
            }
            else
            {
                CreateCard(_id, CardState.Deck);
            }
            libraryDic[_id].GetComponent<CardCounter>().SetCounterValue(-1);
        }
    }

    public void CreateCard(int _id, CardState _cardState)
    {
        Transform targetPanel;
        GameObject targetPrefab;
        var refData = PlayerData.playerCards;
        Dictionary<int, GameObject> targetDic = libraryDic;
        if (_cardState == CardState.Library)
        {
            targetPanel = libraryPanel;

            targetPrefab = cardPrefab;
        }
        else 
        {
            targetPanel = deckPanel;
            targetPrefab = deckPrefab;
            refData = PlayerData.playerDeck;
            targetDic = deckDic;
        }   

        GameObject newCard = Instantiate(targetPrefab, targetPanel);
        newCard.GetComponent<CardCounter>().SetCounterValue(refData[_id]);
        newCard.GetComponent<CardDisplay>().card = CardStore.cardList[_id];
        targetDic.Add(_id, newCard);
    }
}
