using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Titlename : MonoBehaviour
{
    [SerializeField] private TMP_Text titleText;

    public void SetText(string str)
    {
        titleText.text = str;
    }
}
