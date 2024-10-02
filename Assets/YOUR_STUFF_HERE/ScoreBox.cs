using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBox : MonoBehaviour
{
    public int scoreToEarn = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.GetComponentInParent<PlayerPlate>().plateScreenID == collision.GetComponent<PlayerSushi>().screenID)
        {
            if(gameObject.name == "goodScoreBox")
            {
                scoreToEarn = 50;
                print("good :)");
            }
            else if(gameObject.name == "badScoreBox")
            {
                scoreToEarn = 10;
                print("bad :(");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        scoreToEarn = 0;
    }
}
