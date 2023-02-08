using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemBtmDetail : MonoBehaviour
{
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text countText;
    [SerializeField] private TMP_Text sunText;

    private ItemBtmController ibCont;

    public KioskData kioskData;

    int count = 0;
    public int Count
    {
        get { return count; }
        set
        {
            count = value;
            countText.text = string.Format("{0}°³", count);
        }
    }
    int sum = 0;

    public int Sum
    {
        get { return sum; }
        set
        {
            sum = value;
            sunText.text = string.Format("{0:#,###}¿ø", sum);
        }
    }

    public void DataSetting(KioskData data, ItemBtmController cont)
    {
        ibCont = cont;
        kioskData = data;
        Count += 1;
        

        ChageSum();
        titleText.text = data.name;
    }

    public void OnMinus()
    {
        if (Count <= 1)
        {
            return;
        }
        Count -= 1;
        ChageSum();
        ibCont.TotalPrice();
    }
    public void OnPlus()
    {
        if (Count >= 98)
        {
            return;
        }
        Count += 1;
        ChageSum();
        ibCont.TotalPrice();
    }

    public void ChageSum()
    {
        Sum = Count * kioskData.price;
    }

    public void OnDelete()
    {
        ibCont.DeleteData(kioskData);
        Destroy(gameObject);
    }
}
