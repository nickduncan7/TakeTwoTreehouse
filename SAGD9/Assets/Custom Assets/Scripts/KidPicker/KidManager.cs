using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Custom_Assets.Scripts.Classes;
using UnityEngine;

namespace Assets.Custom_Assets.Scripts.KidPicker
{
    public class KidManager : MonoBehaviour
    {
        void Start()
        {
            var SelectionArrow = GameObject.Find("SelectionArrow");

            var SceneButton = GameObject.Find("Shoot Scene Button").GetComponent<ActionsButton>();
            var MowButton = GameObject.Find("Mow Lawn Button").GetComponent<ActionsButton>();
            var PostProcessButton = GameObject.Find("Post Process Button").GetComponent<ActionsButton>();
            var ShootRetakeButton = GameObject.Find("Shoot Retake Button").GetComponent<ActionsButton>();

            SceneButton.AssociatedAction = new GameAction
            {
                Name = "Shoot a Scene",
                Description = "Shoots a scene for your movie."
            };
            MowButton.AssociatedAction = new GameAction
            {
                Name = "Do Chores",
                Description = "Mow the lawn to earn you money, and please your parents. If you don't do this regularly, you might get grounded!",
                LevelToLoad = "MowLawn"
            };
            PostProcessButton.AssociatedAction = new GameAction
            {
                Name = "Post Process a Scene",
                Description = "Do some editing to your existing scenes in order to improve the movies' Effects or Action score."
            };
            ShootRetakeButton.AssociatedAction = new GameAction
            {
                Name = "Shoot a Retake",
                Description = "Do a Retake on a scene to max out the scene's benefits towards the movie."
            };

        }

        public Kid SelectedKid;


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
                    Acting = 1,
                    Production = 1,
                    Expertise = "Arthur's movie posters earn 25% more new patrons."
                }
            };
        }

        public void UpdateTextLabels(GameAction associatedAction)
        {
            GameObject.Find("Action Name").GetComponent<UILabel>().text = associatedAction.Name;
            if (associatedAction.Allowed)
                GameObject.Find("Action Description").GetComponent<UILabel>().text = associatedAction.Description;
            else
                GameObject.Find("Action Description").GetComponent<UILabel>().text = associatedAction.Description
                    + System.Environment.NewLine + System.Environment.NewLine +
                    "You are currently [i]not allowed[/i] to do this action!";
        }
    }
}
