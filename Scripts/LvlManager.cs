using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlManager : MonoBehaviour
{
    public static LvlManager instance;

    public List<GameObject> layerMenu0 = new List<GameObject>();
    public List<GameObject> layerOptions1 = new List<GameObject>();

    private List<List<GameObject>> arrayLayers = new List<List<GameObject>>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        arrayLayers.Add(layerMenu0);
        arrayLayers.Add(layerOptions1);

        ToggleLayers(false, 1);
    }

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OptionButton()
    {
        ToggleLayers(true, 1);
        ToggleLayers(false, 0);
    }

    public void BackButton()
    {
        ToggleLayers(false, 1);
        ToggleLayers(true, 0);
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void UpdateScore(int points)
    {
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.AddScore(points);
        }
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    private void ToggleLayers(bool active, int index)
    {
        foreach (GameObject button in arrayLayers[index])
        {
            if (button != null)
            {
                button.SetActive(active);
            }
        }
    }
}
