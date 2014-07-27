using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Custom_Assets.Scripts.Classes;
using UnityEngine;

namespace Assets.Custom_Assets.Scripts.KidPicker
{
    internal class KidButton : MonoBehaviour
    {
        private bool isSelected;
        private bool isCasted;

        // Use this for initialization
        private void Start()
        {

        }

        // Update is called once per frame
        private void Update()
        {

        }

        public bool IsSelected()
        {
            return isSelected;
        }

        public void Deselect()
        {
            isSelected = false;
        }

        public void Cast()
        {
            if (GameObject.Find("KidManager").GetComponent<KidManager>().CastKid(AssociatedKid))
            {
                GameObject.Find("KidManager").GetComponent<KidManager>().HighlightCast(gameObject.name);
                isCasted = true;
                SelectMe();
            }

            ;
        }

        public void Uncast()
        {
            if (GameObject.Find("KidManager").GetComponent<KidManager>().UncastKid(AssociatedKid))
            {
                GameObject.Find("KidManager").GetComponent<KidManager>().UnhighlightCast(gameObject.name);
                isCasted = false;
                SelectMe();
            }
        }

    public Kid AssociatedKid;

        public void SelectMe()
        {
            GameObject.Find("Kid1").GetComponent<KidButton>().Deselect();
            GameObject.Find("Kid2").GetComponent<KidButton>().Deselect();
            GameObject.Find("Kid3").GetComponent<KidButton>().Deselect();
            GameObject.Find("Kid4").GetComponent<KidButton>().Deselect();
            GameObject.Find("Kid5").GetComponent<KidButton>().Deselect();
            GameObject.Find("Brother").GetComponent<KidButton>().Deselect();
            this.isSelected = true;
            var SelectionArrow = GameObject.Find("SelectionArrow");
            SelectionArrow.GetComponent<UI2DSprite>().SetAnchor(gameObject);
            SelectionArrow.GetComponent<UI2DSprite>().UpdateAnchors();
            GameObject.Find("KidManager").GetComponent<KidManager>().UpdateTextLabels(AssociatedKid);
            GameObject.Find("KidManager").GetComponent<KidManager>().SelectedKid = AssociatedKid;

            if (isCasted)
            {
                GameObject.Find("CastKidLabel").GetComponent<UILabel>().text = "Uncast Kid";
            }
            else
            {
                GameObject.Find("CastKidLabel").GetComponent<UILabel>().text = "Cast Kid";
            }

        }

        private void OnPress(bool pressed)
        {
            if (pressed) SelectMe();
        }

        private void OnHover(bool hovering)
        {
            if (hovering)
            {
                var HoverArrow = GameObject.Find("HoverArrow");
                HoverArrow.GetComponent<UI2DSprite>().color = new Color(1f, 1f, 1f, 0.5f);
                HoverArrow.GetComponent<UI2DSprite>().SetAnchor(gameObject);
                HoverArrow.GetComponent<UI2DSprite>().UpdateAnchors();
                GameObject.Find("KidManager").GetComponent<KidManager>().UpdateTextLabels(AssociatedKid);
            }
            else
            {
                var HoverArrow = GameObject.Find("HoverArrow");
                HoverArrow.GetComponent<UI2DSprite>().color = new Color(1f, 1f, 1f, 0f);

                if (GameObject.Find("Kid1").GetComponent<KidButton>().IsSelected())
                    GameObject.Find("KidManager").GetComponent<KidManager>().UpdateTextLabels(
                        GameObject.Find("Kid1").GetComponent<KidButton>().AssociatedKid);
                if (GameObject.Find("Kid2").GetComponent<KidButton>().IsSelected())
                    GameObject.Find("KidManager").GetComponent<KidManager>().UpdateTextLabels(
                        GameObject.Find("Kid2").GetComponent<KidButton>().AssociatedKid);
                if (GameObject.Find("Kid3").GetComponent<KidButton>().IsSelected())
                    GameObject.Find("KidManager").GetComponent<KidManager>().UpdateTextLabels(
                        GameObject.Find("Kid3").GetComponent<KidButton>().AssociatedKid);
                if (GameObject.Find("Kid4").GetComponent<KidButton>().IsSelected())
                    GameObject.Find("KidManager").GetComponent<KidManager>().UpdateTextLabels(
                        GameObject.Find("Kid4").GetComponent<KidButton>().AssociatedKid);
                if (GameObject.Find("Kid5").GetComponent<KidButton>().IsSelected())
                    GameObject.Find("KidManager").GetComponent<KidManager>().UpdateTextLabels(
                        GameObject.Find("Kid5").GetComponent<KidButton>().AssociatedKid);
                if (GameObject.Find("Brother").GetComponent<KidButton>().IsSelected())
                    GameObject.Find("KidManager").GetComponent<KidManager>().UpdateTextLabels(
                        GameObject.Find("Brother").GetComponent<KidButton>().AssociatedKid);
            }
        }
    }
}
