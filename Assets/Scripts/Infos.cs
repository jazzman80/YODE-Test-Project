using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infos : MonoBehaviour
{
    [SerializeField] private GameObject[] info;
    [SerializeField] private ModelsMenu modelsMenu;

    public void ShowInfo()
    {
        if (!info[modelsMenu.modelNumber].activeInHierarchy) info[modelsMenu.modelNumber].SetActive(true);
        else info[modelsMenu.modelNumber].SetActive(false);
    }

    public void DisableAllInfos()
    {
        for (int i = 0; i < info.Length; i++)
        {
            info[i].SetActive(false);
        }
    }
}
