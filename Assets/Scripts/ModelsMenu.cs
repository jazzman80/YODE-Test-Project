using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelsMenu : MonoBehaviour
{
    public int modelNumber = 0;
    private RectTransform rectTransform;
    [SerializeField] private GameObject[] model;

    private void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
    }

    public void RotateLeft()
    {
        modelNumber++;
        if (modelNumber > 4) modelNumber = 0;

        DisableAllModels();
        model[modelNumber].SetActive(true);
    }

    public void RotateRight()
    {
        modelNumber--;
        if (modelNumber < 0) modelNumber = 4;

        DisableAllModels();
        model[modelNumber].SetActive(true);
    }

    private void DisableAllModels()
    {
        for (int i = 0; i < 5; i++) model[i].SetActive(false);
    }
}
