using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UI_Script : MonoBehaviour
{
    float hp = 100;

    public Text hpText;
    public TMP_Text hpTextTMP;

    public Slider healthBar;
    public Toggle testToggle;

    public Button exitBtn;
    void Start()
    {
        exitBtn.onClick.AddListener(ExitGame);
    }
    void Update()
    {
        hp -= 0.01f;

        hp = Mathf.Clamp(hp, 0, 100);

        hpText.text = hp.ToString();
        hpTextTMP.text = hp.ToString();

        healthBar.value = hp;
    }
    public void PrintSomething(string text)
    {
        Debug.Log(text);
    }
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void ExitGame()
    {
        Debug.Log("Oyundan Çýktý");
        Application.Quit(); //Uygulamayý kapatýr
    }
}
