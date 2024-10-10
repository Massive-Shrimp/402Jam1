using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSushi : MonoBehaviour
{
    [SerializeField] SpringJoint2D joint;
    [SerializeField] Rigidbody2D rb;

    MyWhaleMinigame myWhaleMinigame;

    public int screenID = -1;

    public Vector2 connectedAnchorStartPos;
    public Vector2 anchorStartPos;
    public Vector2 spawnPoint;

    [Header("Graphics stuffs")]
    [SerializeField] private GameObject hand;

    // Start is called before the first frame update
    void Start()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        //rb.bodyType = RigidbodyType2D.Static;

        anchorStartPos = new Vector2(joint.anchor.x, joint.anchor.y);
        connectedAnchorStartPos = new Vector2(joint.connectedAnchor.x, joint.connectedAnchor.y);
        spawnPoint = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (!ScreenUtility.IsOnScreen(transform.position, -1)) //respawns player if they out of the screens boundaries
        {
            Debug.Log("Player is off screen!");
            ResetPosition();
        }
    }

    public void HandleButtonInput(int buttonID)
    {
        if(buttonID == 0 && rb.bodyType == RigidbodyType2D.Dynamic)
        {
            gameObject.GetComponent<SpringJoint2D>().enabled = false;
            hand.transform.parent = null;
        }
        if(buttonID == 1)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    public void ResetPosition()
    {
        gameObject.transform.position = spawnPoint;
        hand.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.144f, gameObject.transform.position.z - 0.13f);
        hand.transform.parent = gameObject.transform;

        if (gameObject.GetComponent<SpringJoint2D>().enabled == false)
        {
            //rb.bodyType = RigidbodyType2D.Static;

            rb.velocity = Vector2.zero;
            gameObject.GetComponent<SpringJoint2D>().enabled = true;
        }
    } 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.GetComponent<PlayerPlate>().plateScreenID);
        print(screenID);
        if(collision.gameObject.GetComponent<PlayerPlate>().plateScreenID != screenID) //ignoring any other objects other than the player's own plate
        {
            Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<BoxCollider2D>());
        }
        if(collision.gameObject.tag == "Fish")
        {
            Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<BoxCollider2D>());
        }
    }
}
