using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReloadMainScene : MonoBehaviour {

    public void onClick()
    {
        SceneManager.LoadScene("Main");
    }
}
