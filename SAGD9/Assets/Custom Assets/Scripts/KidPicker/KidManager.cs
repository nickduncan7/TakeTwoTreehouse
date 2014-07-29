using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Assets.Custom_Assets.Scripts.Classes;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Custom_Assets.Scripts.KidPicker
{
    public class KidManager : MonoBehaviour
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

        private List<Kid> Cast; 

        void Start()
        {
            Cast = new List<Kid>();
            var kids = new List<Kid>(5);
            var allKids = GetAllKids();

            for (int i = 0; i <= 5; ++i)
            {
                var item = Random.Range(0, allKids.Count);
                kids.Add(allKids[item]);
                allKids.Remove(allKids[item]);
            }

            var Kid1Button = GameObject.Find("Kid1").GetComponent<KidButton>();
            var Kid2Button = GameObject.Find("Kid2").GetComponent<KidButton>();
            var Kid3Button = GameObject.Find("Kid3").GetComponent<KidButton>();
            var Kid4Button = GameObject.Find("Kid4").GetComponent<KidButton>();
            var Kid5Button = GameObject.Find("Kid5").GetComponent<KidButton>();
            var BrotherButton = GameObject.Find("Brother").GetComponent<KidButton>();

            Kid1Button.AssociatedKid = kids[0];
            Kid2Button.AssociatedKid = kids[1];
            Kid3Button.AssociatedKid = kids[2];
            Kid4Button.AssociatedKid = kids[3];
            Kid5Button.AssociatedKid = kids[4];
            BrotherButton.AssociatedKid = new Kid
            {
                Name = "Your Little Brother",
                Acting = 1,
                Production = 1,
                Benefit = "Your little brother helps you do your chores, increasing your income for doing so.",
                Title = "The Kid who's Always Available",
                Availability = new List<Days> { Days.Monday, Days.Tuesday, Days.Wednesday, Days.Thursday, Days.Friday}
            };
            Kid1Button.GetComponent<KidButton>().SelectMe();

            UpdateSprites(kids);
        }

        public Kid SelectedKid;


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
                case "Brother":
                    return Brother;
            }
            return null;
        }

        void UpdateSprites(List<Kid> kids )
        {
            var Kid1Button = GameObject.Find("Kid1").GetComponent<UI2DSprite>();
            var Kid2Button = GameObject.Find("Kid2").GetComponent<UI2DSprite>();
            var Kid3Button = GameObject.Find("Kid3").GetComponent<UI2DSprite>();
            var Kid4Button = GameObject.Find("Kid4").GetComponent<UI2DSprite>();
            var Kid5Button = GameObject.Find("Kid5").GetComponent<UI2DSprite>();
            var BrotherButton = GameObject.Find("Brother").GetComponent<UI2DSprite>();

            Kid1Button.sprite2D = GetSpriteForKid(kids[0]);
            Kid2Button.sprite2D = GetSpriteForKid(kids[1]);
            Kid3Button.sprite2D = GetSpriteForKid(kids[2]);
            Kid4Button.sprite2D = GetSpriteForKid(kids[3]);
            Kid5Button.sprite2D = GetSpriteForKid(kids[4]);
            BrotherButton.sprite2D = GetSpriteForKid(new Kid { Name = "Brother" });

        }

        // Update is called once per frame
        void Update()
        {

        }

        public List<Kid> GetAllKids()
        {
            return new List<Kid>
            {
                new Kid
                {
                    Name = "Arthur",
                    Title = "The Arty Kid",
                    Acting = 1,
                    Production = 1,
                    Benefit = "Arthur's movie posters earn 25% more new patrons.",
                    Availability = new List<Days>{Days.Monday, Days.Thursday, Days.Friday}
                },
                new Kid
                {
                    Name = "Tomika",
                    Title = "The Tomboy",
                    Acting = 2,
                    Production = 1,
                    Benefit = "Tomika's athleticism adds +2 Action to every scene she shoots.",
                    Availability = new List<Days>{ Days.Tuesday, Days.Wednesday, Days.Friday}
                },
                new Kid
                {
                    Name = "Jacques",
                    Title = "The Jock",
                    Acting = 0,
                    Production = 3,
                    Benefit = "Jack brings his team to see every movie he's in. (+10 patrons)",
                    Availability = new List<Days>{Days.Tuesday, Days.Wednesday, Days.Thursday}
                },
                new Kid
                {
                    Name = "Paula",
                    Title = "The Popular Kid",
                    Acting = 1,
                    Production = 1,
                    Benefit = "Paula brings 3 kids to the premiere, 2 of which automatically become fans.",
                    Availability = new List<Days>{Days.Wednesday, Days.Thursday, Days.Friday}
                },
                new Kid
                {
                    Name = "Chris",
                    Title = "The Kid in a Band",
                    Acting = 1,
                    Production = 2,
                    Benefit = "Chris's musical talents add +2 Effects to every scene he shoots.",
                    Availability = new List<Days>{Days.Monday, Days.Tuesday, Days.Thursday}
                },
                new Kid
                {
                    Name = "Richy",
                    Title = "The Rich Kid",
                    Acting = 1,
                    Production = 3,
                    Benefit = "Richy pitches in $10 for every scene he shoots.",
                    Availability = new List<Days>{Days.Monday, Days.Wednesday, Days.Friday}
                },
                new Kid
                {
                    Name = "Ali",
                    Title = "The Bookworm",
                    Acting = 2,
                    Production = 2,
                    Benefit = "Ali's fact-checking lowers the Plot score required by the movie by 1.",
                    Availability = new List<Days>{Days.Tuesday, Days.Wednesday, Days.Friday}
                },
                new Kid
                {
                    Name = "Jill",
                    Title = "The Girl Next Door",
                    Acting = 2,
                    Production = 2,
                    Benefit = "Jill makes really good cookies that she'll sell at the premiere, increasing income. (+$0.25 per patron)",
                    Availability = new List<Days>{Days.Monday, Days.Tuesday, Days.Wednesday}
                },
                new Kid
                {
                    Name = "Kevin",
                    Title = "The Funny Kid",
                    Acting = 2,
                    Production = 2,
                    Benefit = "Every patron who saw a movie with Kevin in it becomes a fan.",
                    Availability = new List<Days>{Days.Monday, Days.Wednesday, Days.Thursday}
                },
                new Kid
                {
                    Name = "Ralph",
                    Title = "The Kid of 1000 Voices",
                    Acting = 3,
                    Production = 0,
                    Benefit = "Ralph doesn't need to do retakes. [i]NOT IMPLEMENTED![/i]",
                    Availability = new List<Days>{Days.Tuesday, Days.Thursday, Days.Friday}
                },
                new Kid
                {
                    Name = "Daniel",
                    Title = "The Kid with the Good Camera",
                    Acting = 1,
                    Production = 2,
                    Benefit = "Each day spent on post-production adds +1 to both Action and Effects instead of at random. [i]NOT IMPLEMENTED![/i]",
                    Availability = new List<Days>{Days.Monday, Days.Wednesday, Days.Friday}
                },
                new Kid
                {
                    Name = "May",
                    Title = "The Girl who Can Sing",
                    Acting = 2,
                    Production = 1,
                    Benefit = "May's soothing singing lowers the ego of all the kids in the movie by 2. [i]EGO NOT IMPLEMENTED![/i]",
                    Availability = new List<Days>{Days.Monday, Days.Tuesday, Days.Friday}
                }
            };
        }

        public void UpdateTextLabels(Kid associatedKid)
        {
            GameObject.Find("Kid Name").GetComponent<UILabel>().text = associatedKid.Name;
            GameObject.Find("Kid Title").GetComponent<UILabel>().text = associatedKid.Title;
            GameObject.Find("DescriptionLabel").GetComponent<UILabel>().text = associatedKid.Benefit;
            GameObject.Find("ActingLabel").GetComponent<UILabel>().text = "Acting: " + associatedKid.Acting;
            GameObject.Find("ProductionLabel").GetComponent<UILabel>().text = "Production: " + associatedKid.Production;

            var availabilityBuilder = String.Empty;
            if (associatedKid.Availability.Contains(Days.Monday))
                availabilityBuilder += "M ";
            if (associatedKid.Availability.Contains(Days.Tuesday))
                availabilityBuilder += "Tu ";
            if (associatedKid.Availability.Contains(Days.Wednesday))
                availabilityBuilder += "W ";
            if (associatedKid.Availability.Contains(Days.Thursday))
                availabilityBuilder += "Th ";
            if (associatedKid.Availability.Contains(Days.Friday))
                availabilityBuilder += "F";

            GameObject.Find("AvailabilityLabel").GetComponent<UILabel>().text = "Availability: " + availabilityBuilder;
        }

        public void HighlightCast(string s)
        {
            if (s == "Kid1")
                GameObject.Find("CastingHighlight1").GetComponent<UI2DSprite>().color = new Color(1,1,1,1);
            if (s == "Kid2")
                GameObject.Find("CastingHighlight2").GetComponent<UI2DSprite>().color = new Color(1, 1, 1, 1);
            if (s == "Kid3")
                GameObject.Find("CastingHighlight3").GetComponent<UI2DSprite>().color = new Color(1, 1, 1, 1);
            if (s == "Kid4")
                GameObject.Find("CastingHighlight4").GetComponent<UI2DSprite>().color = new Color(1, 1, 1, 1);
            if (s == "Kid5")
                GameObject.Find("CastingHighlight5").GetComponent<UI2DSprite>().color = new Color(1, 1, 1, 1);
            if (s == "Brother")
                GameObject.Find("CastingHighlightBrother").GetComponent<UI2DSprite>().color = new Color(1, 1, 1, 1);
        }

        public void UnhighlightCast(string s)
        {
            if (s == "Kid1")
                GameObject.Find("CastingHighlight1").GetComponent<UI2DSprite>().color = new Color(1, 1, 1, 0);
            if (s == "Kid2")
                GameObject.Find("CastingHighlight2").GetComponent<UI2DSprite>().color = new Color(1, 1, 1, 0);
            if (s == "Kid3")
                GameObject.Find("CastingHighlight3").GetComponent<UI2DSprite>().color = new Color(1, 1, 1, 0);
            if (s == "Kid4")
                GameObject.Find("CastingHighlight4").GetComponent<UI2DSprite>().color = new Color(1, 1, 1, 0);
            if (s == "Kid5")
                GameObject.Find("CastingHighlight5").GetComponent<UI2DSprite>().color = new Color(1, 1, 1, 0);
            if (s == "Brother")
                GameObject.Find("CastingHighlightBrother").GetComponent<UI2DSprite>().color = new Color(1, 1, 1, 0);
        }

        public bool UncastKid(Kid associatedKid)
        {
            if (Cast.Count > 0)
            {
                Cast.Remove(associatedKid);
                GameDataObjectHelper.GetGameData().Cast = Cast;

                if (Cast.Count != 3)
                    GameObject.Find("ContinueButton").GetComponent<KidContinueButton>().Disable();

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CastKid(Kid associatedKid)
        {
            if (Cast.Count < 3)
            {
                Cast.Add(associatedKid);
                GameDataObjectHelper.GetGameData().Cast = Cast;

                if (Cast.Count == 3)
                    GameObject.Find("ContinueButton").GetComponent<KidContinueButton>().Enable();

                return true;
            }
            else
            {
                return false;
            }


        }

        public bool AllowContinue()
        {
            if (Cast.Count == 3)
                return true;
            return false;
        }
    }
}
