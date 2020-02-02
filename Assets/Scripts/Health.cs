using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxLives = 3;
    public int currentLives;
    public float gapBetweenHearts = 1.2f;
    private Vector2 lastHeartPosition;
    public GameObject HeartsContaniner;
    public GameObject heart;


    // Start is called before the first frame update
    void Start()
    {
        HeartsContaniner = new GameObject();
        HeartsContaniner.transform.position = new Vector2(2.24f, 8.86f);
        currentLives = maxLives;

        for (int i = 0; i < maxLives; i++)
        {
            GameObject currentHeart = Instantiate(heart,
                new Vector2(HeartsContaniner.transform.position.x + (gapBetweenHearts * i), transform.position.y),
                transform.rotation);
            currentHeart.gameObject.name = "heart" + (i + 1);
            currentHeart.transform.parent = HeartsContaniner.transform;
            lastHeartPosition = currentHeart.transform.position;
        }
    }


    public void RemoveLive()
    {
        Debug.Log("RemoveLive ---- currentLives = " + currentLives);
        if (currentLives > 0)
        {
            GameObject currentHeart = GameObject.Find("heart" + currentLives);
            lastHeartPosition = new Vector2(currentHeart.transform.position.x - gapBetweenHearts,
                currentHeart.transform.position.y);
            Destroy(currentHeart);
            currentLives--;
        }
    }

    public void AddLive()
    {
        Debug.Log("AddLive  ----  currentLives = " + currentLives);
        if (currentLives < maxLives)
        {
            currentLives++;
            GameObject currentHeart = Instantiate(heart,
                new Vector2(lastHeartPosition.x + gapBetweenHearts, transform.position.y), transform.rotation);
            currentHeart.gameObject.name = "heart" + currentLives;
            currentHeart.transform.parent = HeartsContaniner.transform;
            lastHeartPosition = currentHeart.transform.position;
        }
    }
}