using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuUI : MonoBehaviour
{
    public string heallth;
    public int fontss = 90;
    public int font2 = 20;
    void Update()
    {
        heallth = "HEALTH: " + HMove.health;
        //countn += nomnomnom.count;
        //text.text = Accorns;
    }
    void OnGUI()
    {
        GUIStyle healthh = new GUIStyle(GUI.skin.box);
        healthh.normal.textColor = Color.white;
        if (HMove.health < 25)
        {
            healthh.normal.textColor = Color.red;
        }
        healthh.alignment = TextAnchor.MiddleCenter;
        healthh.fontSize = font2;
        GUI.Box(new Rect(960, 0, 150, 75), heallth, healthh);
        if (HMove.health < 1 || HMove.player == false)
        {
            GUIStyle fonts = new GUIStyle(GUI.skin.box);
            fonts.fontSize = fontss;
            //fonts.font = 
            fonts.alignment = TextAnchor.MiddleCenter;
            GUI.color = Color.red;
            GUI.backgroundColor = Color.black;
            GUI.Box(new Rect(275, 160, 600, 300), "Game Over", fonts);
            StartCoroutine(Example());



        }
    }
    IEnumerator Example()
    {
        if (HMove.health < 1 || HMove.player == false)
        {
            Debug.Log("PANIC");
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
