using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    public Text idText;
    public Text nameText;
    public Text attackText;
    public Text healthText;
    public Text weaponText;
    public Text costResourceText;
    public Text effectDescriptionText;
    public Text typeText;
    public Text constantText;
    public Image rarityColor;
    public Image backgroundImage;


    // Start is called before the first frame update
    void Start()
    {
        ShowCard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowCard()
    {     
        nameText.text = card.cardName;
        rarityColor.color = new Color(255, 255, 255, 255); //暂定单稀有度
        idText.text = card.id.ToString();
        costResourceText.text = "消耗：" + card.cost.ToString() + "能量值";
        if(card is FleetCard)
        {
            var fleet = card as FleetCard;
            attackText.text = fleet.attack.ToString();
            healthText.text = fleet.health.ToString();
            constantText.text = "维护费：" + fleet.constantCost.ToString() + "能量值/回合";
            effectDescriptionText.text = fleet.effect;
            switch (fleet.weapon)
            {
                case 0:
                    weaponText.text = "能量武器";
                    break;
                case 1:
                    weaponText.text = "动能武器";
                    break;
                case 2:
                    weaponText.text = "导弹武器";
                    break;
            }
        }
        else if(card is BasicCard)
        {
            var basic = card as BasicCard;
            effectDescriptionText.text = basic.effect;
            healthText.text = basic.health.ToString();
            constantText.text = "提供：" + basic.constantGain.ToString() + "能量值/回合";
            attackText.gameObject.SetActive(false);
            weaponText.gameObject.SetActive(false);
        }
        
    }
}
