using UnityEngine;
using UnityEngine.UI;

public class TurnOnOffTV : MonoBehaviour
{

    public Image tvScreen;     
    public Sprite staticSprite; 
    public Sprite blackSprite;  

    private bool isOn = false;

    public void ToggleTV()
    {
        isOn = !isOn;

        if (isOn)
        {
            tvScreen.sprite = staticSprite;
        }
        else
        {
            tvScreen.sprite = blackSprite;
        }
    }
}
