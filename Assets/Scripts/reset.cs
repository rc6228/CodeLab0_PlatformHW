using UnityEngine;
using UnityEngine.SceneManagement;

public class reset : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D collision)
   {
      if (collision.gameObject.CompareTag("Player"))
      {
         RestartLevel();
      }
   }
   
   private void RestartLevel()
   {
 
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }

}
