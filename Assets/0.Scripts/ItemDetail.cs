using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemDetail : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text priceText;

    [SerializeField] private Transform parent;
    [SerializeField] private ItemBtmDetail Itembd;
    private ItemBtmController ibCont;
    private KioskData kioskData;

    public ItemDetail SetnameText(string name)
    {
        nameText.text = name;
        return this;
    }
    public ItemDetail SetPriceText(int price)
    {
        //priceText.text = price.ToString();
        priceText.text = string.Format("{0:#,###}¿ø", price);
        return this;
    }

    public ItemDetail SetIBCont(ItemBtmController cont)
    {
        ibCont = cont;
        return this;

    }

    public ItemDetail SetParent(Transform parent)
    {
        this.parent = parent;
        return this;
    }

    public ItemDetail SetItemBD(ItemBtmDetail itembd)
    {
        this.Itembd = itembd;
        return this;
    }

    
    public ItemDetail SetKioskData(KioskData data)
    {
        kioskData = data;
        SetnameText(data.name);
        SetPriceText(data.price);
        return this;
    }
    public void OnClick()
    {
        if (ibCont.IsCheck(kioskData.name, kioskData))
        {
            Instantiate(Itembd, parent);
        }
    }
}
