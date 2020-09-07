using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject HUD_SelectStage = default;

    public void OpenSelectStage()
    {
        HUD_SelectStage.SetActive(!HUD_SelectStage.activeSelf);
    }
}
