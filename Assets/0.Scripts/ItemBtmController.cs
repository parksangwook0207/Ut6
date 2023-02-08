using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBtmController : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text totalPricetext;


    private List<KioskData> kioskDatas = new List<KioskData>();
    [HideInInspector]
    public List<ItemBtmDetail> ItemDetails = new List<ItemBtmDetail>();

    public bool IsCheck(string name, KioskData data)
    {
        if (kioskDatas.Count == 0)
        {
            kioskDatas.Add(data);
            return true;
        }
        else
        {
            bool check = true;
            foreach (var item in kioskDatas)
            {
                if (item.name == name)
                {
                    check = false;
                }
                if (check)
                {
                    kioskDatas.Add(data);
                }
                return check;
            }
        }



        return false;
    }
    public void AddCount(string name)
    {
        foreach (var item in ItemDetails)
        {
            if (item.kioskData.name == name)
            {
                item.Count += 1;
                item.ChageSum();

                break;
            }
        }


    }

    private void Start()
    {
        TotalPrice();
    }

    public void TotalPrice()
    {
        if (ItemDetails.Count == 0)
        {
            totalPricetext.text = "0¿ø";
            return;
        }
        int sum = 0;
        foreach (var item in ItemDetails)
        {
            sum += item.Count * item.kioskData.price;
        }
        totalPricetext.text = string.Format("{0:#,###}¿ø", sum);
    }

    public void DeleteData(KioskData data)
    {
        foreach (var item in ItemDetails)
        {
            if (data.name == item.kioskData.name)
            {
                ItemDetails.Remove(item);
                kioskDatas.Remove(item.kioskData);
                TotalPrice();
                break;
            }
        }
    }
}
