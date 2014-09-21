using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Assets.Custom_Assets.Scripts.Classes;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class GameDataScript : MonoBehaviour {

    public float Money = 5.00f;
    public int Week = 1;

    private int lastWeek = 5;

    public Days DayOfWeek;

    public float InternalPatronModifier = 1;

    public int Fans = 0;

    public List<Kid> Cast;

    public List<Scene> WeekScenes; 

	// Use this for initialization
	void Start () {
        WeekScenes = new List<Scene>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public int ConsecutiveDaysNotMowed = 0;

    public bool IsGrounded;

    public void GroundPlayer()
    {
        IsGrounded = true;
    }

    public Days GetCurrentDay()
    {
        return DayOfWeek;
    }

    public bool CastContains(string Name)
    {
        var ret = false;
        for (int i = 0; i < Cast.Count; i++)
        {
            if (Cast[i].Name == Name)
                ret = true;
        }
        return ret;
    }

    public void NextDay()
    {
        if (Week == lastWeek && DayOfWeek == Days.Saturday)
        {
            Application.LoadLevel("GameOver");
        }

        if (ConsecutiveDaysNotMowed == 4)
            GroundPlayer();

        if (DayOfWeek == Days.Saturday)
        {
            DayOfWeek = Days.Sunday;
            InternalPatronModifier += 0.8f;
            WeekScenes = new List<Scene>();
            Week++;
            Application.LoadLevel("DayTitleCard");
            return;
        }

        DayOfWeek++;
       
        Application.LoadLevel("DayTitleCard");
    }

    public List<Script> GetScripts()
    {
        #region Week 1 Scripts
        if (Week == 1)
        {
            return new List<Script>
            {
                new Script
                {
                    Name = "Jerks",
                    Budget = 5,
                    Plot = 6,
                    Action = 4,
                    Effects = 3,
                    Dilemma = (() =>
                    {
                        GroundPlayer();
                    }),
                    DilemmaDescription =
                        "Your parents read through some of the movie script, and are not very happy to read a few choice words. You have been [i]GROUNDED![/i]"

                },
                new Script
                {
                    Name = "Socky",
                    Budget = 10,
                    Plot = 5,
                    Action = 5,
                    Effects = 5,
                    Dilemma = (() =>
                    {
                        if (Money < 3)
                            Money = 0;
                        else
                            Money -= 3;

                    }),
                    DilemmaDescription =
                        "A few cast members forgot socks today! You use some of your money to buy more. (You lose up to $3.)"
                },
                new Script
                {
                    Name = "Weakday",
                    Budget = 5,
                    Plot = 5,
                    Action = 4,
                    Effects = 5,
                    DilemmaDescription =
                        "The scene you had hoped to record today is extremely graphic, and your entire cast does not want to participate. You will not be able to record a scene today.",
                    Dilemma = () => Cast.ForEach(kid =>
                        kid.Availability.Remove(Days.Wednesday)
                        )
                },
                new Script
                {
                    Budget = 0,
                    Name = "Little Brother's Script",
                    Plot = 2,
                    Action = 4,
                    Effects = 3
                }
            };
        }
        #endregion

        #region Week 2 Scripts
        if (Week == 2)
        {
            return new List<Script>
            {
                new Script
                {
                    Name = "Texas Whifflebat Massacre",
                    Budget = 10,
                    Plot = 5,
                    Action = 6,
                    Effects = 4,
                    DilemmaDescription =
                        "Due to the movie's violence, the MPAA rates your film PG-13, reducing the number of kids who can watch the movie. (66% patrons)"

                },
                new Script
                {
                    Name = "Noir Bat",
                    Budget = 20,
                    Plot = 5,
                    Action = 6,
                    Effects = 4,
                    Dilemma = (() =>
                    {
                        GroundPlayer();
                    }),
                    DilemmaDescription =
                        "Your parents find out you have been filming on the roof. What are you doing up there!? You'll hurt yourself! You're [i]GROUNDED[/i]!"
                },
                new Script
                {
                    Name = "Moon Martians",
                    Budget = 15,
                    Plot = 4,
                    Action = 6,
                    Effects = 6,
                    DilemmaDescription =
                        "Some of your scenes go missing in the middle of the night! Your Plot, Effects and Action scores are reduced by 2 each.",
                    Dilemma = () =>
                    {
                        if (SelectedScript.GainedPlot >= 2)
                            SelectedScript.GainedPlot -= 2;
                        else
                            SelectedScript.GainedPlot = 0;

                        if (SelectedScript.GainedAction >= 2)
                            SelectedScript.GainedAction -= 2;
                        else
                            SelectedScript.GainedAction = 0;

                        if (SelectedScript.GainedEffects >= 2)
                            SelectedScript.GainedEffects -= 2;
                        else
                            SelectedScript.GainedEffects = 0;
                    }
                },
                new Script
                {
                    Budget = 0,
                    Name = "Little Brother's Script 2.0",
                    Plot = 3,
                    Action = 4,
                    Effects = 5
                }
            };
        }
        #endregion

        #region Week 3 Scripts
        if (Week == 3)
        {
            return new List<Script>
            {
                new Script
                {
                    Name = "Spaghetti Sheriff",
                    Budget = 20,
                    Plot = 6,
                    Action = 6,
                    Effects = 4,
                    DilemmaDescription =
                        "Your parents inform you they will host a spaghetti dinner at your house if your movie does well, provided you aren't grounded. (+$0.50 per patron on Saturday)"

                },
                new Script
                {
                    Name = "Dangzilla",
                    Budget = 30,
                    Plot = 5,
                    Action = 5,
                    Effects = 6,
                    Dilemma = (() =>
                    {
                        if (Money < 10)
                            Money = 0;
                        else
                            Money -= 10;
                    }),
                    DilemmaDescription =
                        "The monster suit suffers an accident and is damaged. It costs $10 to repair. Dang!"
                },
                new Script
                {
                    Name = "Shrewdude Starts",
                    Budget = 25,
                    Plot = 6,
                    Action = 5,
                    Effects = 5,
                    DilemmaDescription =
                        "You have a curfew, young man! Your parents find you filming past midnight, and ground you.",
                    Dilemma = () =>
                    {
                        GroundPlayer();
                    }
                },
                new Script
                {
                    Budget = 0,
                    Name = "Little Brother's Script 3.0",
                    Plot = 4,
                    Action = 5,
                    Effects = 5
                }
            };
        }
        #endregion

        #region Week 4 Scripts
        if (Week == 4)
        {
            return new List<Script>
            {
                new Script
                {
                    Name = "Camp of the Dead",
                    Budget = 40,
                    Plot = 5,
                    Action = 7,
                    Effects = 6,
                    DilemmaDescription =
                        "You need extras. You earn 1 star in Effects and 1 star in Action for every Fan you have, since they are happy to volunteer.",
                        Dilemma = () =>
                        {
                            SelectedScript.GainedAction += (1*Fans);
                            SelectedScript.GainedEffects += (1 * Fans);
                        }
                        

                },
                new Script
                {
                    Name = "Romeo and Juliet 2: The Revenge",
                    Budget = 35,
                    Plot = 6,
                    Action = 6,
                    Effects = 3,
                    Dilemma = (() =>
                    {
                        GroundPlayer();
                    }),
                    DilemmaDescription =
                        "Your parents read the script, and there are quite a few saucy scenes for someone of your age. You're [i]GROUNDED![/i]"
                },
                new Script
                {
                    Name = "Inception 2: Outception",
                    Budget = 40,
                    Plot = 4,
                    Action = 6,
                    Effects = 6,
                    DilemmaDescription =
                        "The script is quite confusing. You realize the last scene you shot isn't useful. -2 to Plot, Action and Effects.",
                    Dilemma = () =>
                    {
                        if (SelectedScript.GainedPlot >= 2)
                            SelectedScript.GainedPlot -= 2;
                        else
                            SelectedScript.GainedPlot = 0;

                        if (SelectedScript.GainedAction >= 2)
                            SelectedScript.GainedAction -= 2;
                        else
                            SelectedScript.GainedAction = 0;

                        if (SelectedScript.GainedEffects >= 2)
                            SelectedScript.GainedEffects -= 2;
                        else
                            SelectedScript.GainedEffects = 0;
                    }
                },
                new Script
                {
                    Budget = 0,
                    Name = "Little Brother's Script 3.5",
                    Plot = 5,
                    Action = 6,
                    Effects = 5
                }
            };
        }
        #endregion

        #region Week 5 Scripts
        if (Week == 5)
        {
            return new List<Script>
            {
                new Script
                {
                    Name = "Ace Spaceman, Intergalactic Private Eye",
                    Budget = 45,
                    Plot = 5,
                    Action = 6,
                    Effects = 6,
                    DilemmaDescription =
                        "There is a Sci-Fi convention in town. Your patron count will triple on the Saturday showcase, if the movie is good.",
                        

                },
                new Script
                {
                    Name = "Bullet Time Dino Island",
                    Budget = 50,
                    Plot = 6,
                    Action = 7,
                    Effects = 7,
                    Dilemma = (() =>
                    {
                        Cast[0].Availability.Remove(Days.Wednesday);
                        Cast[0].Availability.Remove(Days.Thursday);
                        Cast[0].Availability.Remove(Days.Friday);
                    }),
                    DilemmaDescription =
                        "Your first cast member gets sick, and will be unable to contribute anything for the rest of the week."
                },
                new Script
                {
                    Name = "Dr. Hatwhip and the Forest Temple",
                    Budget = 45,
                    Plot = 6,
                    Action = 8,
                    Effects = 6,
                    DilemmaDescription =  "You break the camera during a very intense scene. Your dad is not all too happy. You're [i]GROUNDED![/i]",
                    Dilemma = () =>
                    {
                       GroundPlayer();
                    }
                },
                new Script
                {
                    Budget = 0,
                    Name = "Little Brother's Script 4.0",
                    Plot = 6,
                    Action = 6,
                    Effects = 6
                }
            };
        }
        #endregion
        return null;
    }

    public Script SelectedScript;

    public void UngroundPlayer()
    {
        IsGrounded = false;
    }
}

public enum Days
{
    Sunday,
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday
}
