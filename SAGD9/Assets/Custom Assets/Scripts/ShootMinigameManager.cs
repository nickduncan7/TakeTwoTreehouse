﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Assets.Custom_Assets.Scripts.Classes;
using Microsoft.Win32.SafeHandles;
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

    private StringBuilder benefitBuilder;

    private int kidIdx = 0;

    private bool pointsAwarded;

    private static float countdownTime = 3f;

    private float countdownTimer = countdownTime;
    private float timer = 0f;

    public bool AnswerSelected;

    private List<String> wordList;
    public List<Kid> Cast;
    public Kid CurrentKid;
    public string CurrentWord;
    private bool countingDown;

    private bool intro = true;

    private bool success;

    private short gainedAction = 0;
    private short gainedPlot = 0;
    private short gainedEffects = 0;

    private Guid currentSceneGuid;

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

        if (countingDown)
        {
            GameObject.Find("TimerLabel").GetComponent<UILabel>().text = countdownTimer.ToString("0.00");
            countdownTimer -= Time.deltaTime;

            if (countdownTimer <= 0.05f)
            {
                StartCoroutine(NextKid());
            }
        }
        if (intro)
        {
            timer += Time.deltaTime;
            if (timer >= 2.8f)
            {
                intro = false;
            }
        }
        
    }

	// Use this for initialization
	void Start ()
	{


        benefitBuilder = new StringBuilder();
	    Random.seed = (int) DateTime.Now.Ticks;

        Cast = new List<Kid>();
        var gameDataObject = GameDataObjectHelper.GetGameData();

	    var scene = new Scene();
        scene.ID = new Guid();
	    currentSceneGuid = scene.ID;

        gameDataObject.WeekScenes.Add(scene);

        gameDataObject.Cast.ForEach(cast =>
        {
            if (cast.Availability.Contains(gameDataObject.GetCurrentDay()))
                Cast.Add(cast);
        });

        if (Cast == null || !Cast.Any())
            Cast = new List<Kid> { new Kid { Name = "Arthur", Acting = 1, Production = 2}, new Kid { Name = "Daniel", Acting = 2, Production = 1} };

	    CurrentKid = Cast[kidIdx];
	    GameObject.Find("KidSprite").GetComponent<UI2DSprite>().sprite2D = GetSpriteForKid(CurrentKid);

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

        StartCoroutine(Begin());

	}

    private IEnumerator Begin()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(FadeInInstructions());
  
    }

    private IEnumerator FadeInInstructions()
    {
        var fadein = TweenAlpha.Begin(GameObject.Find("InstructionLabel"), 0.4f, 1.1f);
        fadein.PlayForward();
        var fadein2 = TweenAlpha.Begin(GameObject.Find("Container"), 0.4f, 1.1f);
        fadein2.PlayForward();

        yield return new WaitForSeconds(3);
        StartCoroutine(FadeInButtons());
    }

    private IEnumerator FadeInButtons()
    {
        var fadein = TweenAlpha.Begin(GameObject.Find("ButtonsContainer"), 0.4f, 1.1f);
        fadein.PlayForward();

        yield return new WaitForSeconds(0.5f);
        countingDown = true;
    }

    public IEnumerator NextKid()
    {
        countdownTimer = 0f;
        countingDown = false;
        countdownTimer = countdownTime;

        if (!success && !AnswerSelected)
        {
            UpdateInstructions("You weren't fast enough, kid!");
            yield return new WaitForSeconds(3);

            var fadein = TweenAlpha.Begin(GameObject.Find("InstructionLabel"), 0.4f, -0.1f);
            fadein.PlayForward();
            var fadein2 = TweenAlpha.Begin(GameObject.Find("Container"), 0.4f, -0.1f);
            fadein2.PlayForward();
            var fadein3 = TweenAlpha.Begin(GameObject.Find("ButtonsContainer"), 0.4f, -0.1f);
            fadein3.PlayForward();

            yield return new WaitForSeconds(0.5f);
            RecordFailure(CurrentKid);
        }
        else
        {
            yield return new WaitForSeconds(3);

            var fadein = TweenAlpha.Begin(GameObject.Find("InstructionLabel"), 0.4f, -0.1f);
            fadein.PlayForward();
            var fadein2 = TweenAlpha.Begin(GameObject.Find("Container"), 0.4f, -0.1f);
            fadein2.PlayForward();
            var fadein3 = TweenAlpha.Begin(GameObject.Find("ButtonsContainer"), 0.4f, -0.1f);
            fadein3.PlayForward();
        }

        yield return new WaitForSeconds(0.5f);
        kidIdx++;

        success = false;
        AnswerSelected = false;
        pointsAwarded = false;

        if (kidIdx != Cast.Count)
        {
            CurrentKid = Cast[kidIdx];
            SelectNewWord();
            GameObject.Find("KidSprite").GetComponent<UI2DSprite>().sprite2D = GetSpriteForKid(CurrentKid);
            StartCoroutine(Begin());
        }
        else
        {
            StartCoroutine(NextKidFinish()); 
        }

    }

    public IEnumerator NextKidFinish()
    {
        

        pointsAwarded = false;
        var gdo = GameDataObjectHelper.GetGameData();

        var label = GameObject.Find("GameStatsLabel").GetComponent<UILabel>();
        label.text = string.Empty;

        var sbuilder = new StringBuilder();

        sbuilder.AppendLine("Recording this scene contributed the following:");

        if (gainedPlot != 0)
            sbuilder.AppendLine(gainedPlot + " Plot point(s)");

        if (gainedAction != 0)
            sbuilder.AppendLine(gainedAction + " Action point(s)");

        if (gainedEffects != 0)
            sbuilder.AppendLine(gainedEffects + " Effects point(s)");

        sbuilder.AppendLine();

        sbuilder.AppendLine("Total:");
        sbuilder.AppendLine("Plot: " + gdo.SelectedScript.GainedPlot + "/" + gdo.SelectedScript.Plot);
        sbuilder.AppendLine("Action: " + gdo.SelectedScript.GainedAction + "/" + gdo.SelectedScript.Action);
        sbuilder.AppendLine("Effects: " + gdo.SelectedScript.GainedEffects + "/" + gdo.SelectedScript.Effects);

        if (!String.IsNullOrEmpty(benefitBuilder.ToString()))
        {
            sbuilder.AppendLine();
            sbuilder.AppendLine("BONUS: ");
            label.text = sbuilder.ToString() + benefitBuilder.ToString();
        }
        else
        {
            label.text = sbuilder.ToString();

        }

        timer = 0f;
        countdownTimer = 0f;

        yield return new WaitForSeconds(1);

        var fadein = TweenAlpha.Begin(GameObject.Find("InstructionLabel"), 0.4f, -0.1f);
        fadein.PlayForward();
        var fadein2 = TweenAlpha.Begin(GameObject.Find("Container"), 0.4f, -0.1f);
        fadein2.PlayForward();
        var fadein3 = TweenAlpha.Begin(GameObject.Find("ButtonsContainer"), 0.4f, -0.1f);
        fadein3.PlayForward();
        yield return new WaitForSeconds(0.5f);
        var fadein4 = TweenAlpha.Begin(GameObject.Find("GameStatsLabel"), 0.4f, 1.1f);
        fadein4.PlayForward();

        yield return new WaitForSeconds(7f);

        FaderHelper.FadeToBlack();
        yield return new WaitForSeconds(2f);
        GameDataObjectHelper.GetGameData().NextDay();
        Application.LoadLevel("DayTitleCard");
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
        if (!pointsAwarded)
        {

            var gdo = GameDataObjectHelper.GetGameData();
            success = true;
            UpdateInstructions("Congrats! You got it!");

            gainedPlot += currentKid.Acting;
            gdo.SelectedScript.GainedPlot += CurrentKid.Acting;

            if (currentKid.Name == "Tomika")
            {
                gainedAction += 2;
                gdo.SelectedScript.GainedAction += 2;
                benefitBuilder.AppendLine("Tomika's athleticism added +2 bonus Action points.");
            }

            if (currentKid.Name == "Chris")
            {
                gainedEffects += 2;
                gdo.SelectedScript.GainedEffects += 2;
                benefitBuilder.AppendLine("Chris' musical talent added +2 bonus Effects points.");

            }

            if (currentKid.Name == "Richy")
            {
                gdo.Money += 10;
                benefitBuilder.AppendLine("Richy pitched in $10 for this shoot!");
            }


            if (gdo.SelectedScript.GainedAction > gdo.SelectedScript.GainedEffects)
            {
                if (Random.Range(1, 7) == 6)
                {
                    gainedAction += currentKid.Production;
                    gdo.SelectedScript.GainedAction += currentKid.Production;
                }
                else
                {
                    gainedEffects += currentKid.Production;
                    gdo.SelectedScript.GainedEffects += currentKid.Production;                    
                }
            }
            else if (gdo.SelectedScript.GainedAction < gdo.SelectedScript.GainedEffects)
            {
                if (Random.Range(1, 7) == 6)
                {
                    gainedEffects += currentKid.Production;
                    gdo.SelectedScript.GainedEffects += currentKid.Production;
                }
                else
                {
                    gainedAction += currentKid.Production;
                    gdo.SelectedScript.GainedAction += currentKid.Production;
                }
            }
            else
            {
                if (Random.Range(1, 3) == 2)
                {
                    gainedAction += currentKid.Production;
                    gdo.SelectedScript.GainedAction += currentKid.Production;
                }
                else
                {
                    gainedEffects += currentKid.Production;
                    gdo.SelectedScript.GainedEffects += currentKid.Production;
                }
            }
            pointsAwarded = true;
        }

    }

    public void RecordFailure(Kid currentKid)
    {
        if (!pointsAwarded)
        {
            var gdo = GameDataObjectHelper.GetGameData();

            success = false;
            UpdateInstructions("You picked the wrong one, dummy!");

            gainedPlot += 1;
            gdo.SelectedScript.GainedPlot += 1;

            if (gdo.SelectedScript.GainedAction > gdo.SelectedScript.GainedEffects)
            {
                if (Random.Range(1, 7) == 6)
                {
                    gainedAction += currentKid.Production;
                    gdo.SelectedScript.GainedAction += 1;
                }
                else
                {
                    gainedEffects += currentKid.Production;
                    gdo.SelectedScript.GainedEffects += 1;
                }
            }
            else if (gdo.SelectedScript.GainedAction < gdo.SelectedScript.GainedEffects)
            {
                if (Random.Range(1, 7) == 6)
                {
                    gainedEffects += 1;
                    gdo.SelectedScript.GainedEffects += 1;
                }
                else
                {
                    gainedAction += 1;
                    gdo.SelectedScript.GainedAction += 1;
                }
            }
            else
            {
                if (Random.Range(1, 3) == 2)
                {
                    gainedAction += 1;
                    gdo.SelectedScript.GainedAction += 1;
                }
                else
                {
                    gainedEffects += 1;
                    gdo.SelectedScript.GainedEffects += 1;
                }
            }
            pointsAwarded = true;
        }
    }

    
}
