using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{
    public void SaveCatName()
    {
        MeowManager.Instance.CatName = GameObject.FindObjectOfType<TMP_InputField>().text;
    }
}
