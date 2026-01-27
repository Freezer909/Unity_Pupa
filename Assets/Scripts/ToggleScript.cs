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

    public void RotateRight()
    {
        Pupa.transform.Rotate(0, 0, 0);
    }
    public void RotateLeft()
    {
        Pupa.transform.Rotate(0, 180, 0);
    }
}
