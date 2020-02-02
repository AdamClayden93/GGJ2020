using UnityEngine;

public class FadeAdjustment : MotherSingleton<FadeAdjustment>
{
    Animator fadeSprite;
    private readonly string fade1 = "Fade1";
    private readonly string fade2 = "Fade2";
    private readonly string fade3 = "Fade3";
    private readonly string fade4 = "Fade4";
    private readonly string fade5 = "Fade5";
    private readonly string fade6 = "Fade6";
    public void FadeToBlack()
    {
        fadeSprite.SetTrigger("FadeOut");
    }

    public void TriggerFading(int criteria)
    {
        switch(criteria)
        {
            case 0:
                fadeSprite.SetTrigger(fade1);
                break;
            case 1:
                fadeSprite.SetTrigger(fade2);
                break;
            case 2:
                fadeSprite.SetTrigger(fade3);
                break;
            case 3:
                fadeSprite.SetTrigger(fade4);
                break;
            case 4:
                fadeSprite.SetTrigger(fade5);
                break;
            case 5:
                fadeSprite.SetTrigger(fade6);
                break;
            default:
                GameManager.Instance.fadePoint = -1;
                break;
        }
        GameManager.Instance.fadePoint += 1;
    }
}
