using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StadiumButtonHandler : MonoBehaviour
{

    public GameObject BattlePanel;
    public GameObject MonsPanel;
    public GameObject RunPanel;

    public GameObject playModePanel;
    public GameObject playMode2Panel;
    public GameObject player1SelectPanel;
    public GameObject player2SelectPanel;
    public GameObject readyPanel;
    public GameObject preGameCanvas;

    public GameObject stadiumGameController;
    private StadiumGame sg;
    private StadiumCameraIdleSwitcher scis;

    public GameObject monPreview;

    public void toggleBattlePanel()
    {
        MonsPanel.active = false;
        RunPanel.active = false;
        BattlePanel.active = !BattlePanel.active;
    }
    public void toggleMonsPanel()
    {
        BattlePanel.active = false;
        RunPanel.active = false;
        MonsPanel.active = !MonsPanel.active;
    }
    public void toggleRunPanel()
    {
        BattlePanel.active = false;
        MonsPanel.active = false;
        RunPanel.active = !RunPanel.active;
    }

    public void hidePanels()
    {
        BattlePanel.active = false;
        MonsPanel.active = false;
        RunPanel.active = false;
    }

    /// <summary>
    /// Steps here:
    /// </summary>

    private void hideStepPanels()
    {
        playModePanel.active = false;
        playMode2Panel.active = false;
        player1SelectPanel.active = false;
        player2SelectPanel.active = false;
        readyPanel.active = false;
    }

    public void goBackMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    public void step1()
    {
        hideStepPanels();
        playModePanel.active = true;
    }
    public void step2()
    {
        hideStepPanels();
        playMode2Panel.active = true;
    }
    public void step3()
    {
        hideStepPanels();
        player1SelectPanel.active = true;
    }
    public void step4()
    {
        hideStepPanels();
        player2SelectPanel.active = true;
    }
    public void step5()
    {
        hideStepPanels();
        readyPanel.active = true;
    }

    public void startGame()
    {
        //clean up
        hideStepPanels();
        monPreview.active = false;
        preGameCanvas.active = false;

        sg = stadiumGameController.GetComponent(typeof(StadiumGame)) as StadiumGame;
        //scis = sg.StadiumCameraController.GetComponent(typeof(StadiumCameraIdleSwitcher)) as StadiumCameraIdleSwitcher;
        //scis.idle = true;

        sg.startGame();
    }
}
