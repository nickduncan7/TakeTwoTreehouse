using UnityEngine;

namespace Assets.Custom_Assets.Scripts
{
    class ClickSoundScript : MonoBehaviour
    {
        public AudioClip ClickSound;

        public void OnPress(bool pressed)
        {
            if (pressed) AudioSource.PlayClipAtPoint(ClickSound, transform.position);
        }

    }
}
