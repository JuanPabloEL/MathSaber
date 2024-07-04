using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void SelectBtn(int digits){
        PlayerPrefs.SetInt("Digits", digits);
        SceneManager.LoadScene("CustomBeatSaber");
    }
}
