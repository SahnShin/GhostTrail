using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public int sceneNumber;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindFirstObjectByType<LoadingScreen>().LoadScene(sceneNumber);
        }
    }
}
