using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void OnExitPressButton()
    {
        /*if (Application.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {*/
            Application.Quit();
        //}
    }
}
