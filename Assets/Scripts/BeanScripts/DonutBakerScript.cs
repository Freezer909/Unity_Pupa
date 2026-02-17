using System.Collections;
using UnityEngine;

public class DonutBakerScript : MonoBehaviour
{
    public GameObject[] donutPrefabs;
    public float bakeInterval = 1.0f;
    Transform ovenTransform;
    public float offset = 0.7f;

    void Start()
    {
        ovenTransform = GetComponent<Transform>();
    }

    public void BakeDonut(bool state)
    {
        if (state)
            StartCoroutine(Bake());
        else
            StopAllCoroutines();
    }

    IEnumerator Bake()
    {
        while (true)
        {
            float minPoz = ovenTransform.position.x - offset;
            float maxPoz = ovenTransform.position.x + offset;
            float randPoz = Random.Range(minPoz, maxPoz);
            Vector2 spawnPoz = new Vector2(randPoz, ovenTransform.position.y);

            int donutIndex = Random.Range(0, donutPrefabs.Length);
            Instantiate(donutPrefabs[donutIndex], spawnPoz, Quaternion.identity, ovenTransform);
            yield return new WaitForSeconds(bakeInterval);
        }
    }

    public void CleanUp()
    {
        StopAllCoroutines();
        foreach (Transform child in ovenTransform)
        {
            Destroy(child.gameObject);
        }
    }
}