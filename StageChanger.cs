using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageChanger : MonoBehaviour
{
    [SerializeField] string nextStage = default;
    void OnTriggerEnter(Collider collider){
        SceneManager.LoadScene(nextStage);
    }
}
