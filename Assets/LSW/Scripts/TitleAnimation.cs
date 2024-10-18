using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TitleAnimation : MonoBehaviour
{
    public Text title;  
    public string fullText = "BRICK\nBREAKER";
    public float delay = 0.5f;

    private string currentText = "";

    private void Start()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            title.text = currentText;
            yield return new WaitForSeconds(delay);  
        }
    }
}
