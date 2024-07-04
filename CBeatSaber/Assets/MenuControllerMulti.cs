using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControllerMulti : MonoBehaviour
{
    public void SelectBtn(int digits){
        PlayerPrefs.SetInt("Digits", digits);
        SceneManager.LoadScene("CustomBeatSaberMultiplicacion");
    }
}
