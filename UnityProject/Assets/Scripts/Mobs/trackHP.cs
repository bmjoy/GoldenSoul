using UnityEngine;
using UnityEngine.UI;

public class trackHP : MonoBehaviour
{
    public Slider sld;
    // Update is called once per frame
    void Update()
    {
        Vector2 sldT = Camera.main.WorldToScreenPoint(transform.position);
        sld.transform.position = sldT;
    }
}
