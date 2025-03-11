
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SaveGame();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            LoadGame();
        }
    }

    public void SaveGame()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/save.dat");

        GameData data = new GameData();
        data.level = SceneManager.GetActiveScene().buildIndex;
        data.score = ScoreManager.instance.GetScore();

        formatter.Serialize(file, data);
        file.Close();

        Debug.Log("Game saved successfully");
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/save.dat"))
        {
            Debug.Log("Archivo de guardado encontrado");

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);
            GameData data = (GameData)formatter.Deserialize(file);
            file.Close();

            Debug.Log("Datos deserializados correctamente");
            Debug.Log("Nivel: " + data.level);
            Debug.Log("Puntaje: " + data.score);

            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(data.level));
            ScoreManager.instance.SetScore(data.score);

            Debug.Log("Juego cargado correctamente");
        }
        else
        {
            Debug.Log("No se encontró archivo de guardado");
        }
    }

}

[System.Serializable]
class GameData
{
    public int level;
    public int score;
}

