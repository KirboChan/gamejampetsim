using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject shop;
    [SerializeField] GameObject food;
    private AudioManager audioManager;

    void ToggleGameObject(GameObject go)
    {
       go.SetActive(!go.activeSelf);
    }
    public void ToggleFood()
    {
        ToggleGameObject(food);
        audioManager.PlaySFX(audioManager.audioSource, audioManager.randomAudioClips, 2);
    }
    public void ToggleShop()
    {
        ToggleGameObject(shop);
        audioManager.PlaySFX(audioManager.audioSource, audioManager.randomAudioClips, 2);

    }
    public void RestartLevel()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Start()
    {
        audioManager = GameObject.Find("_Scripts").GetComponent<AudioManager>();
    }
}
