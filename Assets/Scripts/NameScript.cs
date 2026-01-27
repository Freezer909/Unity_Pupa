using TMPro;
using UnityEngine;

public class NameScript : MonoBehaviour
{

    private string text;
    private string[] input = {"Sveiks", "Jauku dienu", "Prieks tevi redzēt", "Uzredzēšanos", "Jauki ka atnāci", "Tiksimies rit"};

    private int rand;
    public GameObject inputField;
    public GameObject textField;

    public void getText ()
    {
        rand = Random.Range(0, input.Length);
        text = inputField.GetComponent<TMP_InputField>().text;
        textField.GetComponent<TMP_Text>().text = input[rand] + " " + text + "!";
    }

}
