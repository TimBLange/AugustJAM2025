using UnityEngine;
using UnityEngine.SceneManagement;
using System;

[Serializable]
public enum SceneEnum
{
    NONE=0,
    SUBSCENE,
    A1,
    A2,
    LOADINGHALLS,
}
public class PersitentLoader : MonoBehaviour
{
    public static PersitentLoader instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else
        {
            Debug.LogError("WARNING, THERE ARE 2 PERSITENTLOADERS");
        }
    }

    public void LoadToUnload(SceneEnum sceneToCheck)
    {
        Scene checkedScene = SceneManager.GetSceneByName(sceneToCheck.ToString());
        if (checkedScene.isLoaded)
        {
            SceneManager.UnloadSceneAsync(checkedScene);
        }
    }

    public void UnLoadToLoad(SceneEnum sceneToCheck)
    {
        Scene checkedScene = SceneManager.GetSceneByName(sceneToCheck.ToString());
        if (!checkedScene.isLoaded)
        {
            SceneManager.LoadSceneAsync(sceneToCheck.ToString(),LoadSceneMode.Additive);
        }
    }
}
