using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LOBBY : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButto;
    [SerializeField] private string levelToLoad = "Level -1";

    private void Awake()
    {
        startButton.onClick.AddListener(ShowLevels);
        exitButto.onClick.AddListener(ExitGame);
    }

    private void ShowLevels()
    {
        SoundManager.Instance.PlaySound(Sound.ButtonClick);
        SceneManager.LoadScene(levelToLoad);
    }

    private void ExitGame()
    {
        SoundManager.Instance.PlaySound(Sound.ButtonClick);
        StartCoroutine(DelayedExit());
    }

    private IEnumerator DelayedExit()
    {
        yield return new WaitForSeconds(1f);

        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
