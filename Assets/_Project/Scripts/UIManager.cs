using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject shop;
    [SerializeField] GameObject food;

    void ToggleGameObject(GameObject go)
    {
       go.SetActive(!go.activeSelf);
    }
    public void ToggleFood()
    {
        ToggleGameObject(food);
    }
    public void ToggleShop()
    {
        ToggleGameObject(shop);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
