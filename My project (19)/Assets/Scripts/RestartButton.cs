using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void RestartLevel()
    {
        // Aktif sahneyi yeniden y�kle
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
