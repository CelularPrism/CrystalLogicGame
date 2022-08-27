using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonEnabler : MonoBehaviour
{
    [SerializeField] private Transform[] btnArray;
    [SerializeField] private Sprite disableSprite;
    [SerializeField] private Sprite enableSprite;

    private void Start()
    {
        LocalisationSystem.Language lang = LocalisationSystem.GetLanguage();
        foreach (Transform btn in btnArray)
        {
            if (btn.GetComponent<UIButtonLanguage>().language == lang)
            {
                ChangeLanguage(btn);
                break;
            }
        }
    }

    public void ChangeLanguage(Transform button)
    {
        foreach (Transform btn in btnArray)
        {
            Image img = btn.GetComponent<Image>();
            if (btn == button)
                img.sprite = enableSprite;
            else
                img.sprite = disableSprite;
        }
    }
}
