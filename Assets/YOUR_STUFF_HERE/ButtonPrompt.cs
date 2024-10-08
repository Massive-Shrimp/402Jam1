using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPrompt : MonoBehaviour
{
    [SerializeField] SushiMakeMainScrpt sushiMake;
    [SerializeField] PlayerSushiChef sushiChef;

    public int curPrompt;

    // Start is called before the first frame update
    void Start()
    {
        //Invoke("AssignVariables", 0.5f);   
        AssignVariables();
    }

    public void AssignVariables()
    {
        curPrompt = 0;
        int i = 0;
        foreach (Sprite s in sushiMake.buttonPromptSprites)
        {
            if (s == gameObject.GetComponent<SpriteRenderer>().sprite)
            {
                curPrompt = i;
            }
            else
            {
                i++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (sushiChef.done)
        {
            AssignVariables();
        }
    }
}
