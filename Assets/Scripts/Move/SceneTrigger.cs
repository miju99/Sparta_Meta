using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    [SerializeField] private string GameScene;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("¿Ãµø ¡ﬂ");
        SceneManager.LoadScene(GameScene);
    }

}
