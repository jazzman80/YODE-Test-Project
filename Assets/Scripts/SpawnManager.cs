using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Settings settings;
    [SerializeField] private ModelsMenu modelsMenu;
    [SerializeField] private GameObject[] objectPrefab;
    private List<List<GameObject>> objectPoolList = new List<List<GameObject>>();
    [SerializeField] private int objectPoolSize;
    [SerializeField] private GameObject placementIndicator;
    [SerializeField] private StudioEventEmitter placingSound;
    [SerializeField] private GameObject particleConteiner;
    private ParticleSystem puff;

    private void Start()
    {
        puff = particleConteiner.GetComponent<ParticleSystem>();
        
        for(int i = 0; i < objectPrefab.Length; i++)
        {
            List<GameObject> objectPool = new List<GameObject>();
            for(int k = 0; k < objectPoolSize; k++)
            {
                GameObject newObject = Instantiate(objectPrefab[i]);

                newObject.SetActive(false);
                objectPool.Add(newObject);
            }
            objectPoolList.Add(objectPool);
        }
    }

    public void PlaceObject()
    {
        List<GameObject> objectPool = objectPoolList[modelsMenu.modelNumber];

        for (int i = 0; i < objectPoolSize; i++)
        {
            GameObject activatedObject = objectPool[i];
            if (!activatedObject.activeInHierarchy)
            {
                activatedObject.SetActive(true);

                activatedObject.transform.position = placementIndicator.transform.position;

                //Quaternion spawnRotation = new Quaternion(placementIndicator.transform.rotation.x, placementIndicator.transform.rotation.y + settings.rotation, placementIndicator.transform.rotation.z, placementIndicator.transform.rotation.w);
                //activatedObject.transform.rotation = spawnRotation;
                activatedObject.transform.rotation = placementIndicator.transform.rotation;
                activatedObject.transform.Rotate(Vector3.up, settings.rotation);

                activatedObject.transform.localScale = new Vector3(settings.scale, settings.scale, settings.scale);
                activatedObject.GetComponent<StudioEventEmitter>().Play();

                puff.Play();
                placingSound.Play();
                break;
            }
        }

    }
}
