using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spells : MonoBehaviour
{
    public bool Regen = true;
    public int Mana = 100;
    Slider ManaSlider;

    Dictionary<string, bool> spells = new Dictionary<string, bool>
    {
        {"fireblast" , false },
        {"knifes" , false },
        {"roses" , false },
        {"bubble" , false },

    };

    public GameObject[] SpellObj;

    private void Start()
    {
        ManaSlider = GameObject.Find("HeroMana").GetComponent<Slider>();
        Regen = true;
        StartCoroutine(ManaRegen());
    }


    IEnumerator ManaRegen()
    {
        while (true)
        {
            ManaSlider.value += (ManaSlider.value < 100 && Regen ) ? 3 : 0;
            ManaSlider.value -= (ManaSlider.value > 0 && !Regen) ? 7 : 0;
            Character1.MP = (int)ManaSlider.value;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void Spawn()
    {
        StartCoroutine(Fireblast());
    }


    IEnumerator Fireblast()
    {
        while (true)
        {
            if (ManaSlider.value <= 7 || Aim.PLEE) { break; }
            Instantiate(gameObject.GetComponent<Spells>().SpellObj[0], new Vector2(gameObject.transform.position.x + Random.Range(-0.5f, 0.5f), gameObject.transform.position.y + Random.Range(-0.5f, 0.5f)), Quaternion.identity);
            yield return new WaitForSeconds(0.6f);
        }
        
    }
}
