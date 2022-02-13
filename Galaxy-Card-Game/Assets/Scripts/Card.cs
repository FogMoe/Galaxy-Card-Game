public class Card //卡
{
    public string type;
    public int id;
    public string cardName;
    public int cost;
    public int rarity; //0=Normal(白色45%) ,1=Rare(蓝色30%) ，2=Epic(紫色18%) ，3=Legendary(橙色6%) ，4=Unique(红色1%)
    public Card(int _id, string _cardName,int _cost, int _rarity, string _type)
    {
        this.id = _id;
        this.cardName = _cardName;
        this.cost = _cost;
        this.rarity = _rarity;
        this.type = _type;
    }
}
public class FleetCard: Card //舰队卡
{
    public int constantCost;
    public int health;
    public int attack;
    public int weapon; // 0=能量武器 ,1=动能武器 ,2=导弹武器
    public string effect;
    public FleetCard(string _effect, int _constantCost, int _health, int _attack, int _weapon, int _id, string _cardName, int _cost, int _rarity, string _type) : base(_id, _cardName, _cost, _rarity, _type)
    {
        this.constantCost = _constantCost;
        this.health = _health;
        this.attack = _attack;
        this.weapon = _weapon;
        this.effect = _effect;
    }
}
public class BasicCard: Card //基础卡
{
    public int constantGain;
    public int health;
    public string effect;
    public BasicCard(int _consconstantGain, int _health, string _effect, int _id, string _cardName, int _cost, int _rarity, string _type) : base(_id, _cardName, _cost, _rarity, _type)
    {
        this.constantGain = _consconstantGain;
        this.health = _health;
        this.effect = _effect;
    }
}

public class BuffCard : Card //增益卡
{
    public string effect;
    public BuffCard(string _effect, int _id, string _cardName, int _cost, int _rarity, string _type) : base(_id, _cardName, _cost, _rarity, _type)
    {
        this.effect = _effect;
    }
}

public class BattleCard : Card //战斗卡
{
    public string effect;
    public BattleCard(string _effect, int _id, string _cardName, int _cost, int _rarity, string _type) : base(_id, _cardName, _cost, _rarity, _type)
    {
        this.effect = _effect;
    }
}
