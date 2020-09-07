using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI anyKeyToStartTEXT = default;
    [SerializeField] TextMeshProUGUI newGameTEXT = default;
    [SerializeField] TextMeshProUGUI selectGameTEXT = default;
    [SerializeField] TextMeshProUGUI exitGameTEXT = default;
    FadeFont fadeFont;
    [SerializeField] Button buttonNew = default;
    [SerializeField] Button buttonSelect = default;
    [SerializeField] Button buttonExit = default;

    private bool playerStillTop = true;

    float alpha;

    void Start()
    {
        fadeFont = GetComponent<FadeFont>();
    }

    void Update()
    {
        // // // // // // //
        // メインメニュー操作
        // // // // // // //

        if (Input.anyKeyDown && playerStillTop == true)
        {
            playerStillTop = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerStillTop = true;
        }

        // // // //
        // 遷移処理
        // // // //

        if (playerStillTop == false)
        {
            anyKeyToStartTEXT.color = new Color(0, 0, 0, 0);
            newGameTEXT.color = new Color(0, 0, 0, 1);
            selectGameTEXT.color = new Color(0, 0, 0, 1);
            exitGameTEXT.color = new Color(0, 0, 0, 1);

            StartCoroutine(MenuDelay(0.2f));
        }

        else
        {
            fadeFont.TMPFadeinFadeout(anyKeyToStartTEXT);
            newGameTEXT.color = new Color(0, 0, 0, 0);
            selectGameTEXT.color = new Color(0, 0, 0, 0);
            exitGameTEXT.color = new Color(0, 0, 0, 0);

            buttonNew.interactable = false;
            buttonSelect.interactable = false;
            buttonExit.interactable = false;
        } 
    }

    public bool IsStillTop
    {
        get { return playerStillTop; }
    }

    private IEnumerator MenuDelay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        buttonNew.interactable = true;
        buttonSelect.interactable = true;
        buttonExit.interactable = true;
    }
}
