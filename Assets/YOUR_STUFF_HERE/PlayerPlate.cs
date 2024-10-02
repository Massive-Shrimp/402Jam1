using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class PlayerPlate : MonoBehaviour
{
    public bool landed = false;

    public int plateScreenID;
    public int scoreToEarn = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Fish" && collision.collider.gameObject.GetComponent<PlayerSushi>().screenID == plateScreenID)
        {
            landed = true;
            foreach(ScoreBox s in GetComponentsInChildren<ScoreBox>())
            {
                if(s.scoreToEarn > scoreToEarn)
                {
                    scoreToEarn = s.scoreToEarn;
                }
            }     
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        scoreToEarn = 0;
    }
}
