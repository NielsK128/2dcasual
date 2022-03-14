using UnityEngine;

public class OpenLink : MonoBehaviour
{
    [SerializeField] private string link;
    //[SerializeField] private GameObject caution;

    public void OpenChannel()
    {
        Application.OpenURL(link);
    }
}
