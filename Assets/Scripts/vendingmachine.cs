using UnityEngine;

public class vendingmachine : MonoBehaviour
{
    public UIWin winManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.CompareTag("Player"))
        {
            winManager.TriggerWin();
        }
    }
}