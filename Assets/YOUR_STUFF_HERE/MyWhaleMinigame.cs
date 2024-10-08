using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyWhaleMinigame : MinigameBase
{
    [Header("Game Specific Variables")]
    [SerializeField] private PlayerSushi[] m_Sushis;
    [SerializeField] private PlayerPlate[] m_Plates;

    [SerializeField] GameManager gm;

    public int[] p_Scores;
    public int[] plate_ID;

    private int scoreToEarn;

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
                if(scoreToEarn != 0)
                {
                    gsd.PlayerScores[i] = (int)((scoreToEarn) + gm.m_GameTimer.CurrentTime);//each player scores x point depending on how close to the centre they land on the plate,
                                                                                            //as well as how much time is left
                }
                else
                {
                    gsd.PlayerScores[i] = 0;
                }
                                                                              
                gsd.PlayerTimes[i] = 0;       //Each player gets two seconds per point scored
                teamTime = 0;                 //Keep a running total of the total time scored by all players
            }
        }
        gsd.ScoreSuffix = " points";    //This lets you write something after the player's score.
        gsd.TeamTime = teamTime;
        return gsd;
    }

    private void Awake()
    {
        MinigameLoaded.AddListener(initialiseSushi);
    }

    public void initialiseSushi()
    {
        p_Scores = new int[4]{0, 0, 0, 0};
        plate_ID = new int[4] {0,0,0,0};

        for (int i = 0; i < m_Sushis.Length; i++)
        {
            m_Sushis[i].screenID = i;
            m_Plates[i].plateScreenID = i;
            plate_ID[i] = i;
        }
    }

    /// <summary>
    /// How do you want to handle input from the four directional buttons?
    /// </summary>
    /// <param name="playerIndex">Which player (0-3) pressed the button</param>
    /// <param name="direction">Which direction(s) are they pressing</param>
    
    /// NO direction inuput for this game, only input player has in game is when sushi is released 
    public override void OnDirectionalInput(int playerIndex, Vector2 direction)
    {

    }
    /// <summary>
    /// What should happen when the player presses the left hand button?
    /// </summary>
    /// <param name="playerIndex">Which player (0-3) pressed the button</param>
    public override void OnPrimaryFire(int playerIndex)
    {
        //drop the sushi - deactivate joint
        m_Sushis[playerIndex].HandleButtonInput(0);
    }

    /// <summary>
    /// What should happen when the player presses the right hand button?
    /// </summary>
    /// <param name="playerIndex">Which player (0-3) pressed the button</param>
    public override void OnSecondaryFire(int playerIndex)
    {
        //also drop the sushi?
        m_Sushis[playerIndex].HandleButtonInput(1);
    }

    public override void TimeUp()
    {
        //check who won the game and reset the minigame :)))
        OnGameComplete(true); //1519 - room gaz is in 
        foreach(PlayerSushi s in m_Sushis)
        {
            s.ResetPosition();
        }
        //Do you want to do something when the minigame timer runs out?
        //This is where you do that!
    }

    protected override void OnResetGame()
    {
        scoreToEarn = 0;
        //Is there any cleanup you have to do when the game gets totally reset?
        //This might just be empty!
    }

    //GIVE POINTS WHEN PLAYER HITS PLATE
    private void FixedUpdate()
    {
        foreach(PlayerPlate p in m_Plates) //when player lands on plate, give player score then finish the game //does it for each player atm :(
        {
            if(p.landed == true)
            {
                Invoke("TimeUp", 2f);
                p.landed = false;
                scoreToEarn = p.scoreToEarn;
            }
        }
    }
}
