using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InstructionsController : MonoBehaviour
{
    [SerializeField]
    public Button btnMenu;
    void Start()
    {
        btnMenu.onClick.AddListener(() => goMenu());
    }

    void goMenu()
    {
        btnMenu.onClick.RemoveAllListeners();
        SceneManager.LoadScene("Menu");
    }
}
