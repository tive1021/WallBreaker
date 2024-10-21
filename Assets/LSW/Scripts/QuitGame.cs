using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void OnQuitButtonClicked()
    {
        Debug.Log("게임 종료"); 
        Application.Quit(); 
    }
}
