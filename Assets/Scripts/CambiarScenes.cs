using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CambiarScenes : MonoBehaviour
{
    public Button button;
    public string SceneName;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ChangeScene);
    }
    void ChangeScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
