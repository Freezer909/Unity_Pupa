using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{

    public GameObject Pupa;
    public GameObject Masina;
    public GameObject Lacitis;
    public GameObject Tante;

    public GameObject ToggleLeft;
    public GameObject ToggleRight;

    public GameObject CharacterImage;
    public Sprite[] CharacterSprites;

    public Slider RotationSlider;
    public Slider SizeSlider;

    public void ToggleBean(bool value)
    {
        Pupa.SetActive(value);
        ToggleLeft.GetComponent<Toggle>().interactable = value;
        ToggleRight.GetComponent<Toggle>().interactable = value;
    }
    public void ToggleMasina(bool value)
    {
        Masina.SetActive(value);
    }
    public void ToggleLacitis(bool value)
    {
        Lacitis.SetActive(value);
    }
    public void ToggleTante(bool value)
    {
        Tante.SetActive(value);
    }

    public void Rotate()
    {
        if (ToggleLeft.GetComponent<Toggle>().isOn)
        {
            Pupa.transform.localScale = new Vector2(1, 1);
            return;
        }

        if (ToggleRight.GetComponent<Toggle>().isOn)
        {
            Pupa.transform.localScale = new Vector2(-1, 1);
            return;
        }
    }

    public void ChangeCharacterImage(int index)
    {
        CharacterImage.GetComponent<Image>().sprite = CharacterSprites[index];
    }

    public void ChangeRotation()
    {
        float rotationsValue = RotationSlider.GetComponent<Slider>().value;
        CharacterImage.transform.localRotation = Quaternion.Euler(0, 0, 360*rotationsValue);
    }

    public void ChangeSize()
    {
        float sizeValue = SizeSlider.GetComponent<Slider>().value;
        CharacterImage.transform.localScale = new Vector2(1f * sizeValue, 1f * sizeValue);
    }

}
