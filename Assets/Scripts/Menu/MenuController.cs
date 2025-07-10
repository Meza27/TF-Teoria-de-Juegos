using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    public Button btnPlay;
    [SerializeField]
    public Button btnInstructions;
    [SerializeField]
    public Button btnCredits;
    void Start()
    {
        btnPlay.onClick.AddListener(() => goGame());
        btnInstructions.onClick.AddListener(() => goInstructions());
        btnCredits.onClick.AddListener(() => goCredits());
    }

    void goGame()
    {
        btnPlay.onClick.RemoveAllListeners();
        SceneManager.LoadScene("Game");
    }
    void goInstructions()
    {
        btnInstructions.onClick.RemoveAllListeners();
        SceneManager.LoadScene("Instructions");
    }
    void goCredits()
    {
        btnCredits.onClick.RemoveAllListeners();
        SceneManager.LoadScene("Credits");
    }
}
