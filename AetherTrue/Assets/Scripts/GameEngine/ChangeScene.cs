using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    private int sceneNum;

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(sceneNum);
    }
}
