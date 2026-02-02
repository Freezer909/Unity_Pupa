using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameScript : MonoBehaviour
{

    private string text;
    private string[] input = {"Sveiks", "Jauku dienu", "Prieks tevi redzēt", "Uzredzēšanos", "Jauki ka atnāci", "Tiksimies rit"};

    private int rand;
    public GameObject inputField;
    public GameObject textField;
    public GameObject ReverseTextToggle;

    public void getText ()
    {
        rand = Random.Range(0, input.Length);
        text = inputField.GetComponent<TMP_InputField>().text;
        textField.GetComponent<TMP_Text>().text = input[rand] + " " + text + "!";

        ReverseTextToggle.GetComponent<Toggle>().interactable = true;

    }

    public void reverseText()
    {
        char[] charArray = textField.GetComponent<TMP_Text>().text.ToCharArray();
        System.Array.Reverse(charArray);
        textField.GetComponent<TMP_Text>().text = new string(charArray);
    }

}
