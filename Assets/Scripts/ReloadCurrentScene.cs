using DataModel;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace twbG.Scenes
{
    public class ReloadCurrentScene : MonoBehaviour
    {
        public void OnReloadScene()
        {
            var session = FindObjectOfType<GameSession>();
            session.Save();

            var currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}