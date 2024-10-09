using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSushiChef : MonoBehaviour
{
    public int directionInput = -1;

    [SerializeField] ButtonPrompt[] prompts;
    [SerializeField] public int playerIndex;
    public int[] curPromptSequence;
    public int j = 0;
    Vector2 lastFrame = Vector2.zero;
    Vector2 thisFrame;
    public int nextPrompt;
    public bool done = false;

    public int sushisMade;

    [SerializeField] SushiMakeMainScrpt sushiMakeScprt;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("updatePromptSequence", 0.1f);
        //updatePromptSequence();
        sushisMade--;
        nextPrompt = curPromptSequence[0];
        //curPromptSequence = new int[prompts.Length];
        //int count = 0;
        //foreach(int num in curPromptSequence)
        //{
        //    curPromptSequence[count] = prompts[count].curPrompt;
        //    count++;
        //}
        //nextPrompt = curPromptSequence[0];
    }

    private void Awake()
    {
        sushiMakeScprt.generatePromptSequence(playerIndex);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void updatePromptSequence()
    {
        curPromptSequence = new int[prompts.Length];
        int count = 0;
        foreach (int num in curPromptSequence)
        {
            curPromptSequence[count] = prompts[count].curPrompt;
            count++;
        }
        nextPrompt = curPromptSequence[0];
        sushisMade++;
        done = false;
    }

    //ARRAY POSITIONS OF REQUIRED INPUTS -> DIRECTION INPUTS
    //0 = LEFT, 1 = RIGHT, 2 = UP, 3 = DOWN
    public void handleDirectionalInput(Vector2 direction)
    {

        thisFrame = new Vector2(direction.x, direction.y);

        if (lastFrame.x == 0 && thisFrame.x < 0)
        {
            print("left key down");
            directionInput = 0;
            if(directionInput == nextPrompt)
            {
                j++;
                print("yipee!");
                if (nextPrompt == curPromptSequence[2] && j == 3)
                {
                    print("done :)");
                    sushiMakeScprt.generatePromptSequence(playerIndex);
                    j = 0;
                    done = true;
                    Invoke("updatePromptSequence", 0.1f);
                }
                else
                {
                    nextPrompt = curPromptSequence[j];
                }
                lastFrame = thisFrame;
            }
            else
            {
                print(":(");
                j = 0;
                nextPrompt = curPromptSequence[0];
            }
            lastFrame = thisFrame;
            //Left button Pressed
        }
        if (lastFrame.x < 0 && thisFrame.x == 0)
        {
            print("left key released");
            lastFrame = thisFrame;
            //Left button Released
        }
        if (lastFrame.x == 0 && thisFrame.x > 0)
        {
            print("right key pressed");
            directionInput = 1;
            if (directionInput == nextPrompt)
            {
                j++;
                print("yipee!");
                if (nextPrompt == curPromptSequence[2] && j == 3)
                {
                    print("done :)");
                    sushiMakeScprt.generatePromptSequence(playerIndex);
                    j = 0;
                    done = true;
                    Invoke("updatePromptSequence", 0.5f);
                }
                else
                {
                    nextPrompt = curPromptSequence[j];
                }
                lastFrame = thisFrame;
            }
            else
            {
                print(":(");
                j = 0;
                nextPrompt = curPromptSequence[0];
            }
            lastFrame = thisFrame;
            //Right button Pressed
        }
        if (lastFrame.x > 0 && thisFrame.x == 0)
        {
            print("right key released");
            lastFrame = thisFrame;
            //Right button Released
        }
        if (lastFrame.y == 0 && thisFrame.y > 0)
        {
            print("up key down");
            directionInput = 2;
            if (directionInput == nextPrompt)
            {
                j++;
                print("yipee!");
                if (nextPrompt == curPromptSequence[2] && j == 3)
                {
                    print("done :)");
                    sushiMakeScprt.generatePromptSequence(playerIndex);
                    j = 0;
                    done = true;
                    Invoke("updatePromptSequence", 0.5f);
                }
                else
                {
                    nextPrompt = curPromptSequence[j];
                }
                lastFrame = thisFrame;
            }
            else
            {
                print(":(");
                j = 0;
                nextPrompt = curPromptSequence[0];
            }
            lastFrame = thisFrame;
            //Up button Pressed
        }
        if (lastFrame.y > 0 && thisFrame.y == 0)
        {
            print("up key released");
            lastFrame = thisFrame;
            //Up button Released
        }
        if (lastFrame.y == 0 && thisFrame.y < 0)
        {
            print("down key down");
            directionInput = 3;
            if (directionInput == nextPrompt)
            {
                j++;
                print("yipee!");
                if (nextPrompt == curPromptSequence[2] && j == 3)
                {
                    print("done :)");
                    sushiMakeScprt.generatePromptSequence(playerIndex);
                    j = 0;
                    done = true;
                    Invoke("updatePromptSequence", 0.5f);
                }
                else
                {
                    nextPrompt = curPromptSequence[j];
                }
                lastFrame = thisFrame;
            }
            else
            {
                print(":(");
                j = 0;
                nextPrompt = curPromptSequence[0];
            }
            lastFrame = thisFrame;
            //Down button Pressed
        }
        if (lastFrame.y < 0 && thisFrame.y == 0)
        {
            print("down key released");
            lastFrame = thisFrame;
            //Down button Released
        }
    }
}
