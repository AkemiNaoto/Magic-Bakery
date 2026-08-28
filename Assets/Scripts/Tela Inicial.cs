using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TelaInicial : MonoBehaviour
{
    
    public void NewGame()
    {
        
        SceneManager.LoadScene("Gameplay");

    }

    public void Credits()
    {
        
        SceneManager.LoadScene("Credits");
        
    }

}
