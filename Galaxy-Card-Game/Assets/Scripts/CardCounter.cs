using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardCounter : MonoBehaviour
{
    public Text counter;
    private int counterValue = 0;

    public void SetCounterValue(int _value)
    {
        counterValue += _value;
        CounterTextChange();
    }
    private void CounterTextChange()
    {
        counter.text = counterValue.ToString();
    }
}
