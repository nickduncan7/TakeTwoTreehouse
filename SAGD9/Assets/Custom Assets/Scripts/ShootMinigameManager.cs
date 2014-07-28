using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Custom_Assets.Scripts.Classes;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class ShootMinigameManager : MonoBehaviour
{
    public Sprite Arthur;
    public Sprite Tomika;
    public Sprite Jacques;
    public Sprite Paula;
    public Sprite Chris;
    public Sprite Richy;
    public Sprite Ali;
    public Sprite Jill;
    public Sprite Kevin;
    public Sprite Ralph;
    public Sprite Daniel;
    public Sprite May;
    public Sprite Brother;

    private int kidIdx = 0;

    private float countdownTimer = 3.2f;
    private float timer = 0f;

    public bool AnswerSelected;

    private List<String> wordList;
    public List<Kid> Cast;
    public Kid CurrentKid;
    public string CurrentWord;
    private bool fadeOut;
    private bool fadeIn;
    private bool fadeComplete;
    private bool countingDown;

    private bool finished = false;
    private bool intro = true;

    private bool success;

    private short gainedAction;
    private short gainedPlot;
    private short gainedEffects;

    public Sprite GetSpriteForKid(Kid kid)
    {
        switch (kid.Name)
        {
            case "Arthur":
                return Arthur;
            case "Tomika":
                return Tomika;
            case "Jacques":
                return Jacques;
            case "Paula":
                return Paula;
            case "Chris":
                return Chris;
            case "Richy":
                return Richy;
            case "Ali":
                return Ali;
            case "Jill":
                return Jill;
            case "Kevin":
                return Kevin;
            case "Ralph":
                return Ralph;
            case "Daniel":
                return Daniel;
            case "May":
                return May;
            case "Your Little Brother":
                return Brother;
        }
        return null;
    }

    void Update()
    {


        if (intro)
        {
            timer += Time.deltaTime;
            if (timer >= 2.8f)
            {
                intro = false;
            }
        }
        else
        {
            if (!finished)
            {
                GameObject.Find("TimerLabel").GetComponent<UILabel>().text = countdownTimer.ToString("N0");

                if (countdownTimer <= 0.05f)
                {
                    countingDown = false;
                    if (!success)
                    {
                        UpdateInstructions("You weren't fast enough, kid!");
                        RecordFailure(CurrentKid);
                    }
                    NextKid();
                }


                if (fadeComplete && countingDown)
                {
                    countdownTimer -= Time.deltaTime;
                }

                if (fadeOut)
                {
                    fadeIn = false;
                    fadeComplete = false;
                    var fadeout = TweenAlpha.Begin(GameObject.Find("Container"), 1, -0.1f);
                    fadeout.ignoreTimeScale = false;
                    fadeout.PlayForward();

                    if (GameObject.Find("Container").GetComponent<UIWidget>().alpha <= -0.01)
                    {
                        countdownTimer = 3.2f;
                        NextKidFinish();
                        fadeOut = false;
                        fadeComplete = true;
                        fadeIn = true;
                    }
                }


                if (fadeIn && !finished)
                {
                    Debug.Log(GameObject.Find("Container").GetComponent<UIWidget>().alpha);

                    fadeOut = false;
                    fadeComplete = false;
                    var fadein = TweenAlpha.Begin(GameObject.Find("Container"), 1, 1.1f);
                    fadein.ignoreTimeScale = false;
                    fadein.PlayForward();

                    if (GameObject.Find("Container").GetComponent<UIWidget>().alpha >= 1.01)
                    {
                        countingDown = true;
                        fadeIn = false;
                        fadeComplete = true;
                    }
                }
            }
            else
            {
                GameObject.Find("Container").GetComponent<UIWidget>().alpha = 0;
                if (FaderHelper.BlackTransitionComplete())
                    Application.LoadLevel("DayTitleCard");
            }
        }
    }

	// Use this for initialization
	void Start ()
	{
        Cast = new List<Kid>();
        //var gameDataObject = GameDataObjectHelper.GetGameData();

        //Debug.Log(gameDataObject.Cast.Count);

        //gameDataObject.Cast.ForEach(cast =>
        //{
        //    if (cast.Availability.Contains(gameDataObject.GetCurrentDay()))
        //        Cast.Add(cast);
        //});

        if (Cast == null || !Cast.Any())
            Cast = new List<Kid> { new Kid { Name = "Arthur" }, new Kid { Name = "Daniel" } };

	    CurrentKid = Cast[kidIdx];
	    GameObject.Find("KidSprite").GetComponent<UI2DSprite>().sprite2D = GetSpriteForKid(CurrentKid);

	    fadeIn = true;
        wordList = new List<string>
	    {
	        "Shoot",
            "Take",
            "Cut",
            "Tape",
            "Camera",
            "Prop",
            "Record",
            "Cast",
            "Movie",
            "Audio"
	    };
        Random.seed = (int)DateTime.Now.Ticks;

        SelectNewWord();
	}

    public void SelectNewWord()
    {
        AnswerSelected = false;

        GameObject.Find("LeftButton").transform.FindChild("Background").GetComponent<UI2DSprite>().color = new Color(1, 1, 1, 0);
        GameObject.Find("CenterButton").transform.FindChild("Background").GetComponent<UI2DSprite>().color = new Color(1, 1, 1, 0);
        GameObject.Find("RightButton").transform.FindChild("Background").GetComponent<UI2DSprite>().color = new Color(1, 1, 1, 0);
        

        CurrentWord = wordList[Random.Range(0, wordList.Count)];

        UpdateInstructions();
        UpdateButtons();
    }

    private void UpdateButtons()
    {
        var leftButton = GameObject.Find("LeftButton");
        var centerButton = GameObject.Find("CenterButton");
        var rightButton = GameObject.Find("RightButton");

        rightButton.GetComponent<ShootMinigameButton>().clicked = false;
        leftButton.GetComponent<ShootMinigameButton>().clicked = false;
        centerButton.GetComponent<ShootMinigameButton>().clicked = false;

        switch (Random.Range(1, 4))
        {
            case 1:
                leftButton.transform.FindChild("Label").GetComponent<UILabel>().text = CurrentWord;

                rightButton.transform.FindChild("Label").GetComponent<UILabel>().text = Scramble(CurrentWord);
                centerButton.transform.FindChild("Label").GetComponent<UILabel>().text = Scramble(CurrentWord);
                break;
            case 2:
                centerButton.transform.FindChild("Label").GetComponent<UILabel>().text = CurrentWord;

                leftButton.transform.FindChild("Label").GetComponent<UILabel>().text = Scramble(CurrentWord);
                rightButton.transform.FindChild("Label").GetComponent<UILabel>().text = Scramble(CurrentWord);

                break;
            case 3:
                rightButton.transform.FindChild("Label").GetComponent<UILabel>().text = CurrentWord;

                leftButton.transform.FindChild("Label").GetComponent<UILabel>().text = Scramble(CurrentWord);
                centerButton.transform.FindChild("Label").GetComponent<UILabel>().text = Scramble(CurrentWord);
                break;
        }
        
    }

    string Scramble(string old)
    {
        old = old.ToUpper();
        var original = old;

        var posToReplace = Random.Range(0, old.Length);

        var letters = new List<char>
        {
            'A',
            'B',
            'C',
            'D',
            'E',
            'F',
            'G',
            'H',
            'I',
            'J',
            'K',
            'L',
            'M',
            'N',
            'O',
            'P',
            'R',
            'S',
            'T',
            'U',
            'V',
            'W',
            'X',
            'Y',
            'Z'
        };

        letters.Remove(old[posToReplace]);

        while (old == original)
            old = old.Replace(old[posToReplace].ToString(), letters[Random.Range(0, letters.Count)].ToString());

        return old;
    }

    public void UpdateInstructions()
    {
        
        GameObject.Find("InstructionLabel").GetComponent<UILabel>().text = String.Format(
            "Okay, {0}. Choose [i]{1}![/i]", CurrentKid.Name, CurrentWord.ToUpper());
    }

    public void UpdateInstructions(string param)
    {
        GameObject.Find("InstructionLabel").GetComponent<UILabel>().text = param;
    }

    public void RecordSuccess(Kid currentKid)
    {
        success = true;
        UpdateInstructions("Congrats! You got it!");
    }

    public void RecordFailure(Kid currentKid)
    {
        success = false;
        UpdateInstructions("You picked the wrong one, dummy!");

    }

    public void NextKid()
    {
        fadeOut = true;
    }

    public void NextKidFinish()
    {
        kidIdx++;
        if (kidIdx != Cast.Count)
        {
            CurrentKid = Cast[kidIdx];
            GameObject.Find("KidSprite").GetComponent<UI2DSprite>().sprite2D = GetSpriteForKid(CurrentKid);
            SelectNewWord();
            UpdateInstructions();
        }
        else
        {
            countdownTimer = 0f;
            GameObject.Find("Container").GetComponent<UIWidget>().alpha = 0;
            finished = true;
            FaderHelper.FadeToBlack();
            
        }
    }
}
