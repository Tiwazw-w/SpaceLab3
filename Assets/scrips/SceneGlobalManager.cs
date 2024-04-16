using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGlobalManager : MonoBehaviour
{
        private static SceneGlobalManager instance;
        public static SceneGlobalManager Instance
        {
            get
            {
                if (instance == null)
                {
                    // Busca una instancia existente en la escena
                    instance = FindObjectOfType<SceneGlobalManager>();

                    // Si no existe, crea una nueva
                    if (instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = "SceneGlobalManager";
                        instance = obj.AddComponent<SceneGlobalManager>();
                        DontDestroyOnLoad(obj); // Para mantenerlo en todas las escenas
                    }
                }
                return instance;
            }
        }

        private void Start()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            // Lógica específica de cada escena
            if (scene.name == "Menu")
            {
                // Liberar objetos de las escenas Game y Results
                UnloadScene("Game");
                UnloadScene("Results");
            }
            else 
            //if (scene.name == "Menu")
            //{
            //    // Liberar objetos de las escenas Game y Results
            //    UnloadScene("Game");
            //    UnloadScene("Results");
            //}
            //else 
            if (scene.name == "Game")
            {
                // Cargar la escena Results de manera asincrónica y aditiva
                LoadSceneAsyncAdditive("Results");
            }
        }

        public void LoadSceneAsyncAdditive(string sceneName)
        {
            StartCoroutine(LoadSceneAsyncAdditiveCoroutine(sceneName));
        }

        private IEnumerator LoadSceneAsyncAdditiveCoroutine(string sceneName)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
        public void UnloadScene(string sceneName)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }
}
