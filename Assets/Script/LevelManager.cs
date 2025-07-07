using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private string sceneToLoad = "LOBBY"; 
    [SerializeField] private GameObject GameOver;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameOver.SetActive(true);
            StartCoroutine(WaitAndLoad());

        }
    }

    private IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(sceneToLoad);
    }
    
}


