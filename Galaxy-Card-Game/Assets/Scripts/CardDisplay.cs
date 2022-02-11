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
        rarityColor.color = new Color(255, 255, 255, 255); //�ݶ���ϡ�ж�
        idText.text = card.id.ToString();
        costResourceText.text = "���ģ�" + card.cost.ToString() + "����ֵ";
        if(card is FleetCard)
        {
            var fleet = card as FleetCard;
            attackText.text = fleet.attack.ToString();
            healthText.text = fleet.health.ToString();
            constantText.text = "ά���ѣ�" + fleet.constantCost.ToString() + "����ֵ/�غ�";
            effectDescriptionText.text = fleet.effect;
            switch (fleet.weapon)
            {
                case 0:
                    weaponText.text = "��������";
                    break;
                case 1:
                    weaponText.text = "��������";
                    break;
                case 2:
                    weaponText.text = "��������";
                    break;
            }
        }
        else if(card is BasicCard)
        {
            var basic = card as BasicCard;
            effectDescriptionText.text = basic.effect;
            healthText.text = basic.health.ToString();
            constantText.text = "�ṩ��" + basic.constantGain.ToString() + "����ֵ/�غ�";
            attackText.gameObject.SetActive(false);
            weaponText.gameObject.SetActive(false);
        }
        
    }
}
