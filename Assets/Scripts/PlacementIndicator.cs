using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{
    [SerializeField] private Settings settings;
    [SerializeField] private GameObject indicatorVisuals;
    [SerializeField] private GameObject previewModel;
    [SerializeField] private GameObject[] previewModelPrefabs;
    [SerializeField] private List<GameObject> previewObjectPool = new List<GameObject>();
    private int previewModelIndex;
    [SerializeField] private ARRaycastManager raycastManager;

    private void Start()
    {
        settings.rotation = 220.0f;
        settings.scale = 0.1f;

        for(int i = 0; i < previewModelPrefabs.Length; i++)
        {
            GameObject previewInit = Instantiate(previewModelPrefabs[i]);
            previewInit.SetActive(false);
            previewObjectPool.Add(previewInit);
        }

        previewModelIndex = 0;
        previewModel = previewObjectPool[previewModelIndex];
        
        indicatorVisuals.SetActive(false);
        previewModel.SetActive(false);
    }

    private void Update()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        raycastManager.Raycast(new Vector2(Screen.width * 0.5f, Screen.height * 0.5f), hits, TrackableType.Planes);

        if(hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            if (!indicatorVisuals.activeInHierarchy) indicatorVisuals.SetActive(true);

            //set position of preview model
            previewModel.transform.position = hits[0].pose.position;

            //set rotaion of preview model
            previewModel.transform.rotation = hits[0].pose.rotation;
            previewModel.transform.Rotate(Vector3.up, settings.rotation);


            //set preview model scale
            previewModel.transform.localScale = new Vector3(settings.scale, settings.scale, settings.scale);

            //enable preview model
            if (!previewModel.activeInHierarchy) previewModel.SetActive(true);
            
        }
    }

    public void OnRightArrowClick()
    {
        previewModel.SetActive(false);
        previewModelIndex--;
        if (previewModelIndex < 0) previewModelIndex = 4;
        previewModel = previewObjectPool[previewModelIndex];
    }

    public void OnLeftArrowClick()
    {
        previewModel.SetActive(false);
        previewModelIndex++;
        if (previewModelIndex > 4) previewModelIndex = 0;
        previewModel = previewObjectPool[previewModelIndex];

    }

}
