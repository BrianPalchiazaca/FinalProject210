using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextManage : MonoBehaviour
{
    public GameObject GOText;
    // Start is called before the first frame update
    public void Start()
    {
        HideText();
    }


    public void HideText()
    {
        GOText.SetActive(false);
    }

    public void AppearText()
    {
        GOText.SetActive(true);
    }
}
