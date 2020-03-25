using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spells : MonoBehaviour
{
    public bool Regen = true;
    public int Mana = 100;
    Slider ManaSlider;

    public static int Pointer = -1;

    public static int[] SpellsList = new int[] {0,0,0,0};

    public GameObject[] SpellObj;

    private void Start()
    {
        ManaSlider = GameObject.Find("HeroMana").GetComponent<Slider>();
        Regen = true;
        if (!(SpellsList[0] == 0 && SpellsList[1] == 0 && SpellsList[2] == 0 && SpellsList[3] == 0))
        {
            ChangePointer();
        }
        StartCoroutine(ManaRegen());
    }

    public void ChangePointer()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("PlayerBullet2"))
        {
            Destroy(item);
        }
        if (SpellsList[0] == 0 && SpellsList[1] == 0 && SpellsList[2] == 0 && SpellsList[3] == 0)
        {
            return;
        }
        Pointer += (Pointer == 3) ? -3 : 1;
        if (SpellsList[Pointer] == 0) ChangePointer();
        GameObject.Find("Spell").GetComponent<Animator>().SetInteger("Spell", SpellsList[Pointer]);
        //GameObject.Find("SpellText").GetComponent<Text>().text = (Pointer+1).ToString();
        GameObject.Find("MagicIcon").GetComponent<Animator>().SetInteger("Type", (Pointer));
    }


    IEnumerator ManaRegen() // Регеним ману
    {
        while (true)
        {
            ManaSlider.value += (ManaSlider.value < 100 && Regen ) ? 6 : 0;
            Character1.MP = (int)ManaSlider.value;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void Spawn() // Спавним заклинание
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("PlayerBullet2"))
        {
            Destroy(item);
        }

        switch (SpellsList[Pointer])
        {
            case 1:
                StartCoroutine(Fireblast());
                break;
            case 2:
                StartCoroutine(MagicSword());
                break;
            case 3:
                StartCoroutine(MagicWand());
                break;
        }
        

    }






    IEnumerator Fireblast()
    {
        while (true)
        {
            if (ManaSlider.value <= 33 || Aim.PLEE) { break; }
            Instantiate(gameObject.GetComponent<Spells>().SpellObj[0], new Vector2(gameObject.transform.position.x + Random.Range(-0.5f, 0.5f), gameObject.transform.position.y + Random.Range(-0.5f, 0.5f)), Quaternion.identity);
            ManaSlider.value -= 33;
            yield return new WaitForSeconds(0.6f);
        }
        
    }
    IEnumerator MagicSword()
    {
        while (true)
        {
            if (ManaSlider.value <= 33 || Aim.PLEE) { break; }
            ManaSlider.value -= 33;
            Instantiate(gameObject.GetComponent<Spells>().SpellObj[1], new Vector2(gameObject.transform.position.x + Random.Range(-1f, 1f), gameObject.transform.position.y + Random.Range(-1f, 1f)), Quaternion.identity);
            Instantiate(gameObject.GetComponent<Spells>().SpellObj[1], new Vector2(gameObject.transform.position.x + Random.Range(-1f, 1f), gameObject.transform.position.y + Random.Range(-1f, 1f)), Quaternion.identity);
            Instantiate(gameObject.GetComponent<Spells>().SpellObj[1], new Vector2(gameObject.transform.position.x + Random.Range(-1f, 1f), gameObject.transform.position.y + Random.Range(-1f, 1f)), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }

    }
    IEnumerator MagicWand()
    {

        if (ManaSlider.value > 15)
        {
        Instantiate(gameObject.GetComponent<Spells>().SpellObj[2], new Vector2(gameObject.transform.position.x + Random.Range(-0.3f, 0.3f), gameObject.transform.position.y + Random.Range(-0.5f, 0.5f)), Quaternion.identity);
        ManaSlider.value -= 15;
        }

        while (true)
        {
            if (ManaSlider.value <= 15 || Aim.PLEE) { break; }
            ManaSlider.value -= 7;
            yield return new WaitForSeconds(0.6f);
        }

    }
}
