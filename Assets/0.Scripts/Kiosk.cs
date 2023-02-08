using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MainMenuType
{
    FastFood,
    pizza,
    China,
    Coffee,
    Korea,
    Chicken
}
public struct KioskData
{
    public string name;
    public int price;
    public string dec;
}

public class Kiosk : MonoBehaviour
{
    [SerializeField] private GameObject menuObj;
    [SerializeField] private GameObject detaillMenuObj;
    [SerializeField] private GameObject titleObj;

    [SerializeField] private Transform titleParent;
    [SerializeField] private Titlename titlePrefab;
    [SerializeField] private Transform detailParent;
    [SerializeField] private ItemDetail detailPrefab;

    [SerializeField] private ItemBtmController ibCont;
    [SerializeField] private ItemBtmDetail itembd;

    List<string> titleList = new List<string>();
    Dictionary<string, KioskData> menuDic = new Dictionary<string, KioskData>();
    private MainMenuType selectType = MainMenuType.FastFood;

    List<ItemDetail> ItemDetails = new List<ItemDetail>();

    // Start is called before the first frame update
    void Start()
    {
        titleList.Clear();
        // �޴� ���� 
        switch (selectType)
        {
            case MainMenuType.FastFood:
                {
                    string[] strs = { "�ܹ���", "����", "������", "�ҽ�", "���̽�ũ��" };
                    foreach (var item in strs)
                    {
                        titleList.Add(item);
                    }

                }
                break;
            case MainMenuType.pizza:
                break;
            case MainMenuType.China:
                break;
        }

        OnShowMain();
    }
    public void OnShowMain()
    {
        ShowMain(true);


        // Ÿ��Ʋ ����
        for (int i = 0; i < titleList.Count; i++)
        {
            Titlename title = Instantiate(titlePrefab, titleParent);
            title.SetText(titleList[i]);
            title.name = titleList[i];

            Toggle toggle = title.GetComponent<Toggle>();
            toggle.group = titleParent.GetComponent<ToggleGroup>();
            toggle.onValueChanged.AddListener(delegate { OnToggle(toggle); });
            if (i == 0)
            {
                toggle.isOn = true;
            }
        }


    }
    public void OnShowDetail()
    {
        ShowMain(false);
    }
    public void ShowMain(bool isShow)
    {
        menuObj.SetActive(isShow);
        detaillMenuObj.SetActive(!isShow);
        titleObj.SetActive(!isShow);
    }

    public void OnToggle(Toggle toggle)
    {
        SubMenuSetting(toggle);
        if (toggle.isOn)
        {
            Debug.Log(toggle.name);
            
        }
    }
    void SubMenuSetting(Toggle toggle)
    {
        if (toggle.isOn)
        {
            menuDic.Clear();

            switch (toggle.name)
            {
                case "�ܹ���":
                    {
                        string[] keys = { "�Ұ�� ����", "�������", "���������δ�����", "ġ�����", "ġŲ����" };
                        int[] price = { 3000, 5000, 8000, 4500, 6000 };
                        DataSetCrateMenu(keys, price);
                    }
                    break;
                case "����":
                    {
                        string[] keys = { "��ī�ݶ�", "���̴�", "�����ݶ�", "���λ��̴�", "ȯŸ", "���" };
                        int[] price = { 2000, 2000, 3000, 3300, 3500, 3600 };
                        DataSetCrateMenu(keys, price);
                    }
                    break;
                case "������":
                    {
                        string[] keys = { "����Ƣ��", "��Ͼ�", "��¡��", "�ʰ�", "ġ�ƽ" };
                        int[] price = { 2000, 2000, 3000, 3300, 3500 };
                        DataSetCrateMenu(keys, price);
                    }
                    break;

                case "�ҽ�":
                    {
                        string[] keys = { "����", "ĥ��", "�ӽ�Ÿ��", "ġ��" };
                        int[] price = { 500, 700, 300, 330 };
                        DataSetCrateMenu(keys, price);
                    }
                    break;
                case "���̽�ũ��":
                    {
                        string[] keys = { "����", "�ٴҶ�", "����", "������", "����", "��Ʈ����" };
                        int[] price = { 1000, 1500, 2000, 5000, 100, 7777 };
                        DataSetCrateMenu(keys, price);
                    }
                    break;

            }
        }
        

        
        }
    void DataSetCrateMenu(string[] keys, int[] price)
    {
        for (int i = 0; i < keys.Length; i++)
        {
            KioskData data = new KioskData();
            data.price = price[i];
            data.name = keys[i];

            menuDic.Add(keys[i], data);
        }

        // ������Ʈ ����
        if (detailParent.childCount < keys.Length)
        {
            int gap = System.Math.Abs(detailParent.childCount - keys.Length);
            for (int i = 0; i < gap; i++)
            {
                ItemDetails.Add(Instantiate(detailPrefab, detailParent));
            }
        }

        int index = 0;
        foreach (var item in menuDic)
        {
            ItemDetails[index].gameObject.SetActive(true);
            ItemDetails[index]              
                .SetParent(ibCont.transform)
                .SetItemBD(itembd)
                .SetIBCont(ibCont)
                .SetKioskData(item.Value);

            index++;
        }

        int close = menuDic.Count - (detailParent.childCount);
        if (close < 0)
        {
            int c = detailParent.childCount - 1;
            for (int i = 0; i < System.Math.Abs(close); i++)
            {
                ItemDetails[c].gameObject.SetActive(false);
                c--;
            }
        }




    }
}
    
    


