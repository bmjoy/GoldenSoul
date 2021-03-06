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

    public static int[] SpellsList = new int[] {0,0,0,0,0};

    public GameObject[] SpellObj;

    private Spells Spells1;

    private void Start()
    {
        Spells1 = gameObject.GetComponent<Spells>();
        ManaSlider = GameObject.Find("HeroMana").GetComponent<Slider>();
        Regen = true;
        if (!(SpellsList[0] == 0 && SpellsList[1] == 0 && SpellsList[2] == 0 && SpellsList[3] == 0 && SpellsList[4] == 0))
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
        if (SpellsList[0] == 0 && SpellsList[1] == 0 && SpellsList[2] == 0 && SpellsList[3] == 0 && SpellsList[4] == 0)
        {
            return;
        }
        Pointer += (Pointer == 4) ? -4 : 1;
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
        if (moveScript.moveyes == false) return;
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
            case 4:
                StartCoroutine(AncientSword());
                break;
        }
        

    }




    IEnumerator Fireblast()
    {
        while (true)
        {
            if (ManaSlider.value <= 33 || Aim.PLEE) { break; }
            GameObject blast = Instantiate(Spells1.SpellObj[0], new Vector2(gameObject.transform.position.x + Random.Range(-0.3f, 0.3f), gameObject.transform.position.y + Random.Range(-0.5f, 0.5f)), Quaternion.identity, gameObject.transform);
            ManaSlider.value -= 33;
            yield return new WaitForSeconds(0.6f);
        }
        
    }
    IEnumerator MagicSword()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (ManaSlider.value <= 11 || Aim.PLEE) { break; }
            ManaSlider.value -= 15;
            Instantiate(gameObject.GetComponent<Spells>().SpellObj[1], new Vector2(gameObject.transform.position.x + Random.Range(-0.6f, 0.6f), gameObject.transform.position.y + Random.Range(-0.6f, 0.6f)),Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
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
    IEnumerator AncientSword()
    {
        if (ManaSlider.value > 10)
            Instantiate(gameObject.GetComponent<Spells>().SpellObj[3], new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity,gameObject.transform);

        while (true)
        {
            if (ManaSlider.value <= 5 || Aim.PLEE) {  Aim.PLEE = true; break; }           
            ManaSlider.value -= 5;
            yield return new WaitForSeconds(0.1f);
        }

    }
}
