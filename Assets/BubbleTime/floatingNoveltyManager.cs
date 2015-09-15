using UnityEngine;
using System.Collections;

public class floatingNoveltyManager : MonoBehaviour {

    public GameObject novelty1;
    public GameObject novelty2;
    public GameObject novelty3;
    public GameObject novelty4;

	// Use this for initialization
	void Start () {
        InvokeRepeating("spawnNovelity", 0, 10);
	}
	
	// Update is called once per frame
	void Update () {
	   
	}

    void spawnNovelity()
    {
        float random = Random.Range(0, 4);

        if (random < 1)
        {
            Instantiate(novelty1);
        } else if (random < 2)
        {
            Instantiate(novelty2);
        } else if (random < 3)
        {
            Instantiate(novelty3);
        } else if (random < 4)
        {
            Instantiate(novelty4);
        }
    }
}
