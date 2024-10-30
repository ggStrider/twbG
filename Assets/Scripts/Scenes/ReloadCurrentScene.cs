using UnityEngine;
using UnityEngine.SceneManagement;

using Player;
using DataModel;

namespace Scenes
{
    public class ReloadCurrentScene : MonoBehaviour
    {
        public void OnReloadScene()
        {
            var session = FindObjectOfType<GameSession>();
            session.Save();

            var playerInputReader = FindObjectOfType<PlayerInputReader>();
            playerInputReader.enabled = false;

            playerInputReader.gameObject.GetComponent<PlayerSystem>().enabled = false;

            var canvas = FindObjectOfType<Canvas>();
            canvas.enabled = false;

            var currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}