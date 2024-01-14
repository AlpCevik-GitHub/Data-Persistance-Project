using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{

    
    public TextMeshProUGUI inputField;
    public static string playerName;
    

    public void StartNew()
    {
        
        playerName = inputField.text;
       
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
    UnityEngine.Application.Quit();
#endif

        DataHolder.Instance.ToSaveData();

    }

    public void SaveName(string name)
    {
        DataHolder.Instance.playerName = name;
       
    }
    

}
