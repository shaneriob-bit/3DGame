using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenScript : MonoBehaviour
{
    [SerializeField] private GameObject PlayButtonObject;

    void Start()
    {
        Application.targetFrameRate = 60;

        Button button = PlayButtonObject.GetComponent<Button>();
        button.onClick.AddListener(OnPlayClicked);
        Physics.gravity = new Vector3(0, -0.5f, 0);
    }

    void OnPlayClicked()
    {
        Physics.gravity = new Vector3(0, -9.81f, 0);
        SceneManager.LoadScene("GameplayScene");
    }
}
