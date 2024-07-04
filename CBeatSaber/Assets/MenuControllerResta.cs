using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControllerResta : MonoBehaviour
{
    public void SelectBtnRest(int digits){
        PlayerPrefs.SetInt("Digits", digits);
        SceneManager.LoadScene("CustomBeatSaberResta");
    }
    public void SelectBtnDiv(int digits){
        PlayerPrefs.SetInt("Digits", digits);
        SceneManager.LoadScene("CustomBeatSaberDivision");
    }

}
