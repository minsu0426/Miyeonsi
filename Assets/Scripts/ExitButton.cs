using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void OnPressButton()
    {
        if (Application.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
}
