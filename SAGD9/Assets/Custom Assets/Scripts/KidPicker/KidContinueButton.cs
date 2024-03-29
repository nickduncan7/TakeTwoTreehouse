﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Custom_Assets.Scripts.KidPicker
{
    class KidContinueButton : MonoBehaviour
    {
        public Sprite EnabledSprite;
        public Sprite DisabledSprite;
        public bool Enabled;
        private bool transitionStarted;
        private float timer;

        void Start()
        {
            if (Enabled)
                this.GetComponent<UI2DSprite>().sprite2D = EnabledSprite;
            else
            {
                this.GetComponent<UI2DSprite>().sprite2D = DisabledSprite;
            }
        }

        void Update()
        {
            if (transitionStarted)
            {
                timer += Time.deltaTime;
                if (timer >= 0.8)
                {
                    FaderHelper.FadeToBlack();
                }
                if (timer >= 4 && FaderHelper.BlackTransitionComplete())
                {
                    Application.LoadLevel("DayTitleCard");
                }
            }
        }

        public void Enable()
        {
            Enabled = true;
            GetComponent<UI2DSprite>().sprite2D = EnabledSprite;
        }

        public void Disable()
        {
            Enabled = false;
            GetComponent<UI2DSprite>().sprite2D = DisabledSprite;
        }

        private IEnumerator Done()
        {
            var fadein = TweenAlpha.Begin(GameObject.Find("DoneContainer"), 0.4f, 1.1f);
            fadein.PlayForward();

            yield return new WaitForSeconds(3.5f);

            transitionStarted = true;
        }

        void OnPress(bool pressed)
        {
            if (pressed && Enabled)
            {

                if (GameDataObjectHelper.GetGameData().CastContains("Ali"))
                {
                    GameDataObjectHelper.GetGameData().SelectedScript.Plot--;
                }

                StartCoroutine(Done());
            }
        }
    }
}
