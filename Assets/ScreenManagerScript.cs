using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManagerScript : MonoBehaviour
{
    public RectTransform screenContainer;
    private int screenWidth;
    public float transitionTime = 1f;

    public void Start(){
        screenWidth = Screen.width;
    }

    private void ChangeScreen(ScreenType screenType){
        Vector3 newPos;
        if (screenType == ScreenType.DescriptionScreen){
            newPos = new Vector3(-screenWidth, 0f, 0f);
        }
        else{
            newPos = Vector3.zero;
        }

        StopAllCoroutines();
        StartCoroutine(ChangeScreenAnimation(newPos));

    }

    private IEnumerator ChangeScreenAnimation(Vector3 newPos){
        float elapsed = 0f;
        Vector3 oldPos = screenContainer.anchoredPosition3D;

        while(elapsed <= transitionTime){
            elapsed += Time.deltaTime;
            Vector3 currentPos = Vector3.Lerp(oldPos, newPos, elapsed / transitionTime);
            screenContainer.anchoredPosition3D = currentPos;
            yield return null;
        }
    }

    public void OnStartButtonClicked(){
        Debug.Log("Start Button Clicked");
        ChangeScreen(ScreenType.DescriptionScreen);
    }

    public void OnQuitButtonClicked(){
        Debug.Log("Quit Button Clicked");
    }

    public void OnJailbreakButtonClicked(){
        Debug.Log("Play Button Clicked");
    }

    private enum ScreenType{
        StartScreen,
        DescriptionScreen
    }
}
