using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAdjustment : MonoBehaviour
{
    Animator fadeSprite;

    public void FadeToBlack()
    {
        fadeSprite.SetTrigger("FadeOut");
    }

    public void TriggerFading(int criteria)
    {
        switch(criteria)
        {
            case 0:
                fadeSprite.SetTrigger("Fade1");
                break;
            case 1:
                fadeSprite.SetTrigger("Fade2");
                break;
            case 2:
                fadeSprite.SetTrigger("Fade3");
                break;
            case 3:
                fadeSprite.SetTrigger("Fade4");
                break;
            case 4:
                fadeSprite.SetTrigger("Fade5");
                break;
            case 5:
                fadeSprite.SetTrigger("Fade6");
                break;
            default:
                break;
        }
    }
}
