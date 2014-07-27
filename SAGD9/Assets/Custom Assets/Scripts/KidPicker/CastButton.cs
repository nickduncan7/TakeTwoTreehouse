using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Custom_Assets.Scripts.KidPicker
{
    class CastButton : MonoBehaviour
    {

        void OnPress(bool pressed)
        {
            if (pressed)
            {
                if (GameObject.Find("CastKidLabel").GetComponent<UILabel>().text == "Cast Kid")
                {
                    if (GameObject.Find("Kid1").GetComponent<KidButton>().IsSelected())
                        GameObject.Find("Kid1").GetComponent<KidButton>().Cast();
                    if (GameObject.Find("Kid2").GetComponent<KidButton>().IsSelected())
                        GameObject.Find("Kid2").GetComponent<KidButton>().Cast();
                    if (GameObject.Find("Kid3").GetComponent<KidButton>().IsSelected())
                        GameObject.Find("Kid3").GetComponent<KidButton>().Cast();
                    if (GameObject.Find("Kid4").GetComponent<KidButton>().IsSelected())
                        GameObject.Find("Kid4").GetComponent<KidButton>().Cast();
                    if (GameObject.Find("Kid5").GetComponent<KidButton>().IsSelected())
                        GameObject.Find("Kid5").GetComponent<KidButton>().Cast();
                    if (GameObject.Find("Brother").GetComponent<KidButton>().IsSelected())
                        GameObject.Find("Brother").GetComponent<KidButton>().Cast();
                }
                else
                {
                    if (GameObject.Find("Kid1").GetComponent<KidButton>().IsSelected())
                        GameObject.Find("Kid1").GetComponent<KidButton>().Uncast();
                    if (GameObject.Find("Kid2").GetComponent<KidButton>().IsSelected())
                        GameObject.Find("Kid2").GetComponent<KidButton>().Uncast();
                    if (GameObject.Find("Kid3").GetComponent<KidButton>().IsSelected())
                        GameObject.Find("Kid3").GetComponent<KidButton>().Uncast();
                    if (GameObject.Find("Kid4").GetComponent<KidButton>().IsSelected())
                        GameObject.Find("Kid4").GetComponent<KidButton>().Uncast();
                    if (GameObject.Find("Kid5").GetComponent<KidButton>().IsSelected())
                        GameObject.Find("Kid5").GetComponent<KidButton>().Uncast();
                    if (GameObject.Find("Brother").GetComponent<KidButton>().IsSelected())
                        GameObject.Find("Brother").GetComponent<KidButton>().Uncast();
                }
            }
        }
    }
}
