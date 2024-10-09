using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiMakeMainScrpt : MinigameBase
{
    [Header("Game Specific Variables")]

    [SerializeField] SpriteRenderer[] buttonPromptsRenderers;
    [SerializeField] public Sprite[] buttonPromptSprites;

    [SerializeField] private PlayerSushiChef[] m_Players;

    [SerializeField] GameManager gm;

    /// <summary>
    /// This function is called at the end of the game so that it knows what to display on the score screen.
    /// You give it information about what each players score was, how much time they earned individually, and also how much time they've earned together
    /// </summary>
    /// <returns>A class that contains all the necessary information to display the score page</returns>
    public override GameScoreData GetScoreData()
    {
        //Here's an example of how you might generate scores
        int teamTime = 0;
        GameScoreData gsd = new GameScoreData();
        for (int i = 0; i < 4; i++)
        {
            if (PlayerUtilities.GetPlayerState(i) == Player.PlayerState.ACTIVE)
            {
                gsd.PlayerScores[i] = m_Players[i].sushisMade;      //each player gets points based on how many sushis they made :)
                gsd.PlayerTimes[i] = 0;       //Each player gets two seconds per point scored
                teamTime = 0;                 //Keep a running total of the total time scored by all players
            }
        }
        gsd.ScoreSuffix = " sushi made";    //This lets you write something after the player's score.
        gsd.TeamTime = teamTime;
        return gsd;
    }

    private void Awake()
    {
        //generatePromptSequence();
    }

    public void generatePromptSequence(int playerIndex)
    {
        if(playerIndex == 0)
        {
            //foreach (SpriteRenderer r in buttonPromptsRenderers)
            //{
            //    r.sprite = buttonPromptSprites[Random.Range(0, buttonPromptSprites.Length)];
            //}
            buttonPromptsRenderers[0].sprite = buttonPromptSprites[Random.Range(0, buttonPromptSprites.Length)];
            buttonPromptsRenderers[1].sprite = buttonPromptSprites[Random.Range(0, buttonPromptSprites.Length)];
            buttonPromptsRenderers[2].sprite = buttonPromptSprites[Random.Range(0, buttonPromptSprites.Length)];
        }
        if (playerIndex == 1)
        {
            buttonPromptsRenderers[3].sprite = buttonPromptSprites[Random.Range(0, buttonPromptSprites.Length)];
            buttonPromptsRenderers[4].sprite = buttonPromptSprites[Random.Range(0, buttonPromptSprites.Length)];
            buttonPromptsRenderers[5].sprite = buttonPromptSprites[Random.Range(0, buttonPromptSprites.Length)];
        }
        if (playerIndex == 2)
        {
            buttonPromptsRenderers[6].sprite = buttonPromptSprites[Random.Range(0, buttonPromptSprites.Length)];
            buttonPromptsRenderers[7].sprite = buttonPromptSprites[Random.Range(0, buttonPromptSprites.Length)];
            buttonPromptsRenderers[8].sprite = buttonPromptSprites[Random.Range(0, buttonPromptSprites.Length)];
        }
        if (playerIndex == 3)
        {
            buttonPromptsRenderers[9].sprite = buttonPromptSprites[Random.Range(0, buttonPromptSprites.Length)];
            buttonPromptsRenderers[10].sprite = buttonPromptSprites[Random.Range(0, buttonPromptSprites.Length)];
            buttonPromptsRenderers[11].sprite = buttonPromptSprites[Random.Range(0, buttonPromptSprites.Length)];
        }
        
    }

    /// <summary>
    /// How do you want to handle input from the four directional buttons?
    /// </summary>
    /// <param name="playerIndex">Which player (0-3) pressed the button</param>
    /// <param name="direction">Which direction(s) are they pressing</param>

    public override void OnDirectionalInput(int playerIndex, Vector2 direction)
    {
        m_Players[playerIndex].handleDirectionalInput(direction);
    }
    /// <summary>
    /// What should happen when the player presses the left hand button?
    /// </summary>
    /// <param name="playerIndex">Which player (0-3) pressed the button</param>
    public override void OnPrimaryFire(int playerIndex)
    {

    }

    /// <summary>
    /// What should happen when the player presses the right hand button?
    /// </summary>
    /// <param name="playerIndex">Which player (0-3) pressed the button</param>
    public override void OnSecondaryFire(int playerIndex)
    {
        //also drop the sushi?
    }

    public override void TimeUp()
    {
        OnGameComplete(true);
        //Do you want to do something when the minigame timer runs out?
        //This is where you do that!
    }

    protected override void OnResetGame()
    {
        //Is there any cleanup you have to do when the game gets totally reset?
        //This might just be empty!
    }

}
