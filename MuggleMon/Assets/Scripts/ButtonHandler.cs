using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{

    public void setText(string text)
    {
        Text txt = transform.Find("Text").GetComponent<Text>();
        txt.text = text;
    }

    public GameObject mainMenuPanel;
    public void panelToggleVisibility()
    {
        //stop earth scrolling
        GameObject.Find("Earth").GetComponent<EarthScroll>().inputEnabled = mainMenuPanel.gameObject.active;

        //open / close main menu
        mainMenuPanel.gameObject.SetActive(!mainMenuPanel.gameObject.active);
    }

    //public Camera MonPageCamera;// = GameObject.Find("MonPageCamera").GetComponent<Camera>();
    //public Camera PlayerCamera;// = GameObject.Find("PlayerCamera").GetComponent<Camera>();
    //public Camera StorageCamera;// = GameObject.Find("StorageCamera").GetComponent<Camera>();
    //public Camera ItemsCamera;
    //public Camera IndexCamera;

    public Camera cameraToSwitchTo;
    public Canvas canvasToSwitchTo;
    public void switchToCamera()
    {
        //disable all canvases
        foreach (Canvas c in GameObject.FindObjectsOfType<Canvas>())
        {
            c.enabled = false;
        }
        //disable all cameras
        foreach (Camera c in Camera.allCameras)
        {
            c.enabled = false;
        }

        canvasToSwitchTo.enabled = true;
        cameraToSwitchTo.enabled = true;
        
        if (cameraToSwitchTo.tag == "PlayerCamera")
        {
            GameObject.Find("pnlButtonUI").active = false;
        }
    }

    public void gotoStadium()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Stadium");
        //fadeOutUIImage.enabled = true;
        fadeOutUIImage.gameObject.active = true;
        StartCoroutine(FadeAndLoadScene(FadeDirection.In));
    }

    /// <summary>
    /// /////////////////////////////////////////////////////////
    /// </summary>
    /// 
    #region FIELDS
    public Image fadeOutUIImage;
    public float fadeSpeed = 0.8f;
    public enum FadeDirection
    {
        In, //Alpha = 1
        Out // Alpha = 0
    }
    #endregion
    #region MONOBHEAVIOR
    void OnEnable()
    {
        
    }
    #endregion
    #region FADE
    private IEnumerator Fade(FadeDirection fadeDirection)
    {
        float alpha = (fadeDirection == FadeDirection.Out) ? 1 : 0;
        float fadeEndValue = (fadeDirection == FadeDirection.Out) ? 0 : 1;
        if (fadeDirection == FadeDirection.Out)
        {
            while (alpha >= fadeEndValue)
            {
                SetColorImage(ref alpha, fadeDirection);
                yield return null;
            }
            fadeOutUIImage.enabled = false;
        }
        else
        {
            fadeOutUIImage.enabled = true;
            while (alpha <= fadeEndValue)
            {
                SetColorImage(ref alpha, fadeDirection);
                yield return null;
            }
        }
    }
    #endregion
    #region HELPERS
    public IEnumerator FadeAndLoadScene(FadeDirection fadeDirection)
    {
        yield return Fade(fadeDirection);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Stadium");
    }
    private void SetColorImage(ref float alpha, FadeDirection fadeDirection)
    {
        fadeOutUIImage.color = new Color(fadeOutUIImage.color.r, fadeOutUIImage.color.g, fadeOutUIImage.color.b, alpha);
        alpha += Time.deltaTime * (1.0f / fadeSpeed) * ((fadeDirection == FadeDirection.Out) ? -1 : 1);
    }
    #endregion
}
