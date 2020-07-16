using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoURL : MonoBehaviour
{
    // Start is called before the first frame update
    public string url;
    public void GoToUrl()
    {
        Application.OpenURL(url);
    }
}
