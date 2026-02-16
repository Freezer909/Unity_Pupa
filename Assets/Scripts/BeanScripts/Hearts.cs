using UnityEngine;
using System.Collections.Generic;

public class Hearts : MonoBehaviour
{
    public List<GameObject> hearts;

    public void TakeDamage()
    {
        if (hearts.Count > 0)
        {
            int lastIndex = hearts.Count - 1;
            GameObject heartToRemove = hearts[lastIndex];

            hearts.RemoveAt(lastIndex);
            Destroy(heartToRemove);

            if (hearts.Count <= 0)
            {
                Debug.Log("Game Over!");
                Application.Quit();
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false; 
                #endif
            }
        }
    }
}