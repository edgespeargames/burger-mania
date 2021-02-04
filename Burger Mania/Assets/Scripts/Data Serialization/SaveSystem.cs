using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class SaveSystem
{
    public static void SaveMute()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playermute.bm";

        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerMute data = new PlayerMute()
        {
            mute = AudioManager.instance.mute
        };

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static bool LoadMute()
    {
        string path = Application.persistentDataPath + "/playermute.bm";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerMute data = formatter.Deserialize(stream) as PlayerMute;

            stream.Close();

            AudioManager.instance.mute = data.mute;

            return true;
        }
        else
        {
            AudioManager.instance.mute = false;
            Debug.LogWarning("No mute prefs found");
            return false;
        }
    }

    public static void DeleteMute()
    {
        string path = Application.persistentDataPath + "/playermute.bm";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }


    public static void SaveUI()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerUI.bm";

        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerMute data = new PlayerMute()
        {
            displayUI = ToggleInfoUI.Instance.displayUI
        };

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static bool LoadUI()
    {
        string path = Application.persistentDataPath + "/playerUI.bm";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerMute data = formatter.Deserialize(stream) as PlayerMute;

            stream.Close();

            ToggleInfoUI.Instance.displayUI = data.displayUI;

            return true;
        }
        else
        {
            ToggleInfoUI.Instance.displayUI = true;
            Debug.LogWarning("No UI prefs found");
            return false;
        }
    }
    public static void DeleteUI()
    {
        string path = Application.persistentDataPath + "/playerUI.bm";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }


    public static void SaveHighScores()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/highscores.bm";

        FileStream stream = new FileStream(path, FileMode.Create);

        Debug.Log("Name: " + HighScore.highScoreList[HighScore.highScoreList.Count - 1].name + " Score: " + HighScore.highScoreList[HighScore.highScoreList.Count - 1].finalScore);
        formatter.Serialize(stream, HighScore.highScoreList);
        stream.Close();

        Debug.Log("High Scores saved");
    }

    public static bool LoadHighScores()
    {
        string path = Application.persistentDataPath + "/highscores.bm";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            List<PlayerScore> scoreList = formatter.Deserialize(stream) as List<PlayerScore>;

            stream.Close();

            HighScore.highScoreList = scoreList;

            Debug.Log("HighScores Loaded, " + scoreList.Count + " entries found.");
            return true;
        }
        else
        {
            Debug.Log("No HighScore data found");
            return false;
        }
    }

    public static void DeleteHighScores()
    {
        string path = Application.persistentDataPath + "/highscores.bm";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}
