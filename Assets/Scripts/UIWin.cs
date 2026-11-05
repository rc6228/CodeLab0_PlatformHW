using UnityEngine;
using UnityEngine.SceneManagement;

public class UIWin : MonoBehaviour

{
    public GameObject winUI; 

  
    public void TriggerWin()
    {
        winUI.SetActive(true);
    
    }
    
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}