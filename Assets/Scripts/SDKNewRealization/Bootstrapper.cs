using UnityEngine;
using UnityEngine.SceneManagement;

namespace SDKNewRealization
{
    // public class Bootstrapper : MonoBehaviour {
    //     private const string BootstrapperSceneName = "Bootstrapper";
    //
    //     [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    //     private static void Init() {
    //         Debug.Log("Init bootstrapper");
    //
    //         var currentScene = SceneManager.GetActiveScene();
    //
    //         if (!SceneManager.GetSceneByName(BootstrapperSceneName).isLoaded) {
    //             SceneManager.LoadScene(BootstrapperSceneName);
    //         }
    //
    //         SceneManager.LoadSceneAsync(currentScene.name, LoadSceneMode.Additive);
    //     }
    // }
}
