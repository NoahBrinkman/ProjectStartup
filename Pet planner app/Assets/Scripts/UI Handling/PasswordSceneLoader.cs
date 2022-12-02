using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PasswordSceneLoader : MonoBehaviour
{
    [SerializeField] private InputField inField;
    [SerializeField] private int password = 1234;
    [SerializeField] private int sceneIndex = 1;
    public void CheckPassword()
    {
        if (int.Parse(inField.text) == password)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
