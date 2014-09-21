using System;
using System.Text;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class PostProductionManager : MonoBehaviour
{

    private UILabel actionLabel;
    private UILabel effectsLabel;
    private GameDataScript gdo;
    private UILabel selectedLabel;

    private StringBuilder labelBuilder;


    // Use this for initialization
	void Start ()
	{
        labelBuilder = new StringBuilder();

	    actionLabel = GameObject.Find("ActionLabel").GetComponent<UILabel>();
        effectsLabel = GameObject.Find("EffectsLabel").GetComponent<UILabel>();
	    gdo = GameDataObjectHelper.GetGameData();
	    selectedLabel = GameObject.Find("SelectedLabel").GetComponent<UILabel>();

	    actionLabel.alpha = 0.5f;
	    effectsLabel.alpha = 0.5f;

	    labelBuilder.AppendLine("[i][ccff55]Movie Stats[-][/i]");
	    labelBuilder.AppendLine();

	}

    public void DoStuff()
    {
        StartCoroutine(Spin());        
    }

    private IEnumerator Spin()
    {
        yield return new WaitForSeconds(0.2f);
        ActionUp();
        yield return new WaitForSeconds(0.2f);
        EffectsUp();
        yield return new WaitForSeconds(0.2f);
        ActionUp();
        yield return new WaitForSeconds(0.2f);
        EffectsUp();
        yield return new WaitForSeconds(0.2f);
        ActionUp();
        yield return new WaitForSeconds(0.2f);
        EffectsUp();
        yield return new WaitForSeconds(0.2f);
        ActionUp();
        yield return new WaitForSeconds(0.2f);
        EffectsUp();

        yield return new WaitForSeconds(0.4f);
        ActionUp();
        yield return new WaitForSeconds(0.4f);
        EffectsUp();
        yield return new WaitForSeconds(0.4f);
        ActionUp();
        yield return new WaitForSeconds(0.4f);
        EffectsUp();
        yield return new WaitForSeconds(0.4f);
        ActionUp();
        yield return new WaitForSeconds(0.4f);
        EffectsUp();


        yield return new WaitForSeconds(0.8f);
        ActionUp();
        yield return new WaitForSeconds(0.8f);
        EffectsUp();

        Random.seed = (int) DateTime.Now.Ticks;
        var rnd = Random.Range(0, 2);

        if (rnd == 1)
        {
            ActionUp();
            gdo.SelectedScript.GainedAction++;
            yield return new WaitForSeconds(0.5f);
            actionLabel.alpha = 0.5f;
            yield return new WaitForSeconds(0.5f);
            actionLabel.alpha = 1f;
            yield return new WaitForSeconds(0.5f);
            actionLabel.alpha = 0.5f;
            yield return new WaitForSeconds(0.5f);
            actionLabel.alpha = 1f;

            labelBuilder.AppendLine(String.Format("Action: [ccff55]{0}[-]/{1}", gdo.SelectedScript.GainedAction,
                gdo.SelectedScript.Action));
            labelBuilder.AppendLine(String.Format("Effects: {0}/{1}", gdo.SelectedScript.GainedEffects,
                gdo.SelectedScript.Effects));
            labelBuilder.AppendLine(String.Format("Plot: {0}/{1}", gdo.SelectedScript.GainedPlot,
                gdo.SelectedScript.Plot));
        }
        else
        {
            EffectsUp();
            gdo.SelectedScript.GainedEffects++;
            yield return new WaitForSeconds(0.5f);
            effectsLabel.alpha = 0.5f;
            yield return new WaitForSeconds(0.5f);
            effectsLabel.alpha = 1f;
            yield return new WaitForSeconds(0.5f);
            effectsLabel.alpha = 0.5f;
            yield return new WaitForSeconds(0.5f);
            effectsLabel.alpha = 1f;

            labelBuilder.AppendLine(String.Format("Action: {0}/{1}", gdo.SelectedScript.GainedAction,
                gdo.SelectedScript.Action));
            labelBuilder.AppendLine(String.Format("Effects: [ccff55]{0}[-]/{1}", gdo.SelectedScript.GainedEffects,
                gdo.SelectedScript.Effects));
            labelBuilder.AppendLine(String.Format("Plot: {0}/{1}", gdo.SelectedScript.GainedPlot,
                gdo.SelectedScript.Plot));
        }

        yield return new WaitForSeconds(2);
        StartCoroutine(FadeTheResults());

        selectedLabel.text = labelBuilder.ToString();
    }

    private IEnumerator FadeTheResults()
    {
        var fadein = TweenAlpha.Begin(GameObject.Find("DoneContainer"), 0.4f, 1.1f);
        fadein.PlayForward();
        var fadein2 = TweenAlpha.Begin(GameObject.Find("SpinnerContainer"), 0.4f, -0.1f);
        fadein2.PlayForward();

        yield return new WaitForSeconds(5);

        FaderHelper.FadeToBlack();
        yield return new WaitForSeconds(1);

        GameDataObjectHelper.GetGameData().NextDay();
        Application.LoadLevel("DayTitleCard");
    }

    void ActionUp()
    {
        actionLabel.alpha = 1f;
        effectsLabel.alpha = 0.5f;
    }

    void EffectsUp()
    {
        actionLabel.alpha = 0.5f;
        effectsLabel.alpha = 1f;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
