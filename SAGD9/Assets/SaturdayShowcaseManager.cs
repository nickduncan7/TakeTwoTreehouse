using System;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class SaturdayShowcaseManager : MonoBehaviour
{
    private float timer;

    // Use this for initialization
    void Start()
    {
        var gdo = GameDataObjectHelper.GetGameData();

        var oldNumFans = gdo.Fans;
        double moneyEarned = 0;
        var labelBuilder = new StringBuilder();

        labelBuilder.AppendLine(gdo.SelectedScript.Name + " Saturday Showcase");
        labelBuilder.AppendLine();

        double multiplier;

        int patrons = 0;

        gdo.Cast.ForEach(kid => patrons++);


        if (gdo.CastContains("Jacques"))
            patrons += 10;

        if (gdo.CastContains("Arthur"))
            patrons = (int)Math.Ceiling(patrons * 1.25);

        patrons = (int)(patrons * gdo.InternalPatronModifier);

        if (gdo.SelectedScript.Name == "Texas Whifflebat Massacre")
        {
            patrons = (int)(patrons * 0.66);
        }

        if (gdo.SelectedScript.Name == "Ace Spaceman, Intergalactic Private Eye")
        {
            patrons = (patrons*3);
        }


        if ((gdo.SelectedScript.GainedAction >= gdo.SelectedScript.Action)
            && (gdo.SelectedScript.GainedPlot >= gdo.SelectedScript.Plot)
            && (gdo.SelectedScript.GainedEffects >= gdo.SelectedScript.Effects))
        {
            multiplier = 1;
            labelBuilder.AppendLine("The movie was well received!");

            for (int i = 0; i < patrons; i++)
            {
                if (Random.Range(1, 7) >= 5)
                {
                    patrons--;
                    gdo.Fans++;
                }

            }

            if (oldNumFans != gdo.Fans)
                labelBuilder.AppendLine(gdo.Fans - oldNumFans + " patrons became fans.");
        }
        else
        {
            multiplier = 0.66;
            labelBuilder.AppendLine("The movie was poorly received.");

        }

        labelBuilder.AppendLine("Total:");
        labelBuilder.AppendLine("Plot: " + gdo.SelectedScript.GainedPlot + "/" + gdo.SelectedScript.Plot);
        labelBuilder.AppendLine("Action: " + gdo.SelectedScript.GainedAction + "/" + gdo.SelectedScript.Action);
        labelBuilder.AppendLine("Effects: " + gdo.SelectedScript.GainedEffects + "/" + gdo.SelectedScript.Effects);
        labelBuilder.AppendLine();


        if (gdo.Fans > 0)
        {
            moneyEarned += 0.75 * gdo.Fans * multiplier;
            moneyEarned = Math.Ceiling(moneyEarned);
            labelBuilder.AppendLine(gdo.Fans + " fans give you " + moneyEarned.ToString("C0") + " dollars total in tips.");
            labelBuilder.AppendLine();

        }


        if (!gdo.IsGrounded)
        {
            moneyEarned += 5;
            labelBuilder.AppendLine("Your parents give you $5 dollars in tips.");
        }


        var oldMoneyEarned = moneyEarned;

        moneyEarned += 0.25 * patrons * multiplier;

        moneyEarned = Math.Ceiling(moneyEarned);

        labelBuilder.AppendLine(patrons + " patrons give you " + (moneyEarned - oldMoneyEarned).ToString("C0") + " dollars total in tips.");


        if (gdo.SelectedScript.Name == "Spaghetti Sheriff")
        {
            if ((gdo.SelectedScript.GainedAction >= gdo.SelectedScript.Action)
            && (gdo.SelectedScript.GainedPlot >= gdo.SelectedScript.Plot)
            && (gdo.SelectedScript.GainedEffects >= gdo.SelectedScript.Effects))
            {
                oldMoneyEarned = moneyEarned;
                moneyEarned = 0.25*patrons;
        moneyEarned = Math.Ceiling(moneyEarned);

                labelBuilder.AppendLine("The movie is good, and your parents host a spaghetti dinner. " + patrons +
                                        " patrons give you " + (moneyEarned - oldMoneyEarned).ToString("C0") +
                                        " extra dollars.");
            }
        }


        



        if (gdo.CastContains("Jill"))
        {
            oldMoneyEarned = moneyEarned;
            moneyEarned += 0.25 * patrons;
            moneyEarned = Math.Ceiling(moneyEarned);

            labelBuilder.AppendLine("Jill sells " + patrons + " cookies at the showcase, giving you " + (moneyEarned - oldMoneyEarned).ToString("C0") + " dollars total in tips.");
        }

        labelBuilder.AppendLine();

        gdo.Money += (float)moneyEarned;

        labelBuilder.AppendLine("You now have " + gdo.Money.ToString("C0") + " dollars.");

        if (gdo.CastContains("Kevin"))
        {
            gdo.Fans += patrons;
        }

        if (gdo.CastContains("Paula"))
        {
            gdo.Fans += 2;
        }

        GameObject.Find("Label").GetComponent<UILabel>().text = labelBuilder.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 10)
        {
            FaderHelper.FadeToBlack();
            if (FaderHelper.BlackTransitionComplete())
            {
                GameDataObjectHelper.GetGameData().NextDay();
                Application.LoadLevel("DayTitleCard");
            }
        }
    }
}
