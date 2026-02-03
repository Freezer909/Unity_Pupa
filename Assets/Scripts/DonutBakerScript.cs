using System.Collections;
using UnityEngine;

public class DonutBakerScript : MonoBehaviour
{
   
    public GameObject[] donutPrefab;
    public float spawnInterval = 2f;
    float minPoz, maxPoz;
    Transform ovenTransform;

    private void Start()
    {
        ovenTransform = GetComponent<Transform>();
    }

    public void BakeDonut(bool state)
    {
        if (state)
        {
            StartCoroutine(Bake());
        }
        else
        {
            StopAllCoroutines();
        }

        IEnumerator Bake()
        {
            while (true)
            {
                minPoz = ovenTransform.position.x - 40f;
                maxPoz = ovenTransform.position.x + 40f;
                float randPoz = Random.Range(minPoz, maxPoz);
                Vector2 spawnPosition = new Vector2(randPoz, ovenTransform.position.y);
                int randomIndex = Random.Range(0, donutPrefab.Length);
                Instantiate(donutPrefab[randomIndex], spawnPosition, Quaternion.identity, ovenTransform);
                yield return new WaitForSeconds(spawnInterval);
            }
        }

    }

}
