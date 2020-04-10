using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Beatrix : MonoBehaviour
{
    public int StageCount = 0; // Накапливание комбинаций чтоыб открыть сердце
    public int Stage = 0; //Стадия Босса
    public float DistanceX = 1; //Дистанция от игрока
    public float DistanceY = 1;
    public float Position = 0; // ноль - центр, 1 и 2 это столбы
    public int TypeAttack = 1; //Тип атаки
    public int Lifes = 15; //Число жизней
    public bool CanDoDamage = false; //Чтобы запрещать атаковать
    public Slider slider;
    private Animator Anim;
    private Rigidbody2D Rigi;
    public MonsterLife Heart;
    private GameObject Player;
    public GameObject HpHeal;
    public StepTrigger AreaTrigger; //Для активации босса в области
    //private Collider2D Col;
    public bool Active = false; //если активен вызывает атаку
    public bool LastStady = false;
    public Tilemap TC1;
    public Tilemap TC2;
    public Tilemap TC3;
    public Tilemap TC4;
    public Tilemap[] Tiles;
    public float[] posX;
    public float[] posY;
    public GameObject[] Phrases;
    public GameObject[] Bullets;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Knifes1(Bullets[13]));
        Player = GameObject.FindGameObjectWithTag("Player");
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AreaTrigger.Step && Stage == 0)
        {
            Stage = 1;
            slider.gameObject.SetActive(true);
            CanDoDamage = true;
            Character1.Alert();
            StartCoroutine(TileDissapear());
            TC2.gameObject.SetActive(false);
            TC3.gameObject.SetActive(false);
        }
        if (Heart.Damaged)
        {
            StartCoroutine(Bushed());
            Heart.Damaged = false;
            Heart.gameObject.SetActive(false);
            Lifes--;
            slider.value = Lifes;
            if(Lifes < 11 && Lifes > 7 && Stage == 1)
            {
                Stage = 2;
                StageCount = 0;
            }
            if (Lifes < 7 && Lifes > 1 && Stage == 2)
            {
                Stage = 3;
                StageCount = 0;
            }
            if (Lifes < 2 && Stage == 3)
            {
                Stage = 4;
                StageCount = 0;
            }
        }
        if (CanDoDamage)
        {
            CanDoDamage = false;
            switch (Stage)
            {
                case 0:
                    break;
                case 1:
                    ChooseAttack1();
                    break;
                case 2:
                    ChooseAttack2();
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }
    }

    void ChooseAttack1() //Первая фаза
    {
        int[] MassPos;
        if (StageCount == 0)
        {
            MassPos = new int[] { 0, 1, 0, 1, 0, 0, 0, 0 };
            StartCoroutine(CrossSpawn(Bullets[2], MassPos, 1));
        }
        else if (StageCount == 1)
        {
            MassPos = new int[] { 0, 0, 0, 0, 0, 1, 0, 1 };
            StartCoroutine(CrossSpawn(Bullets[2], MassPos, 1));
        }
        else if (StageCount == 2)
        {
            MassPos = new int[] { 1, 0, 1, 0, 1, 0, 1, 0 };
            StartCoroutine(CrossSpawn(Bullets[2], MassPos, 1.5f));
        }
        else if (StageCount == 3)
        {
            MassPos = new int[] { 0, 1, 0, 1, 0, 1, 0, 1 };
            StartCoroutine(CrossSpawn(Bullets[2], MassPos, 1.5f));
        }
        else if (StageCount == 4)
        {
            MassPos = new int[] { 0, 1, 0, 1, 0, 1, 0, 1 };
            StartCoroutine(LineObjectSpawn(Bullets[11], 0.2f, 2f, -1f));
        }
        else if (StageCount == 5)
        {
            Phrases[0].SetActive(true);
            Heart.gameObject.SetActive(true);
            StageCount++;
            return;
        }
        else if (StageCount == 6)
        {
            MassPos = new int[] { 1, 0, 0, 0, 1, 0, 0, 0 };
            StartCoroutine(CrossSpawn(Bullets[10], MassPos, 1.5f));
            StageCount++;
            return;
        }
        else if (StageCount == 7)
        {
            Heart.gameObject.SetActive(true);
            StageCount++;
            return;
        }
        else
        {
            switch ((int)Random.Range(0, 7))
            {
                case 0:
                    MassPos = new int[] { 1, 0, 0, 0, 1, 0, 0, 0 };
                    StartCoroutine(CrossSpawn(Bullets[0], MassPos, 2f));
                    break;
                case 1:
                    MassPos = new int[] { 0, 0, 1, 0, 0, 0, 1, 0 };
                    StartCoroutine(CrossSpawn(Bullets[0], MassPos, 2f));
                    break;
                case 2:
                    MassPos = new int[] { 0, 0, 1, 0, 0, 0, 0, 0 };
                    StartCoroutine(CrossSpawn(Bullets[1], MassPos, 2f));
                    break;
                case 3:
                    MassPos = new int[] { 0, 0, 1, 0, 0, 0, 0, 0 };
                    StartCoroutine(LineObjectSpawn(Bullets[4], 0.2f, 2.5f, -0.5f, 3f));
                    break;
                case 4:
                    MassPos = new int[] { 0, 1, 0, 1, 0, 1, 0, 1 };
                    StartCoroutine(CrossSpawn(Bullets[11], MassPos, 2.3f, 7f));
                    break;
                case 5:
                    MassPos = new int[] { 1, 1, 0, 1, 1, 1, 0, 1 };
                    StartCoroutine(CrossSpawn(Bullets[2], MassPos, 2.3f));
                    break;
                case 6:
                    MassPos = new int[] { 1, 0, 1, 0, 1, 0, 1, 0 };
                    StartCoroutine(CrossSpawn(Bullets[11], MassPos, 2.3f, 7f));
                    break;
                case 7:
                    MassPos = new int[] { 0, 0, 1, 0, 0, 0, 0, 0 };
                    StartCoroutine(CrossSpawn(Bullets[10], MassPos, 1.5f));
                    break;
                default:
                    break;
            }
        }
        StageCount++;
        if (StageCount % 8 == 3 && StageCount > 5)
        {
            Heart.gameObject.SetActive(true);
            StopAllCoroutines();
            CanDoDamage = false;
        }
    }
    void ChooseAttack2() //Вторая фаза
    {
        int[] MassPos;
        if (StageCount == 0)
        {
            Anim.SetInteger("Stage", 3);
            StartCoroutine(StarAttack(posX[0],posY[0]));
        }
        else if (StageCount == 1)
        {
            Phrases[1].SetActive(true);
            Anim.SetInteger("Stage", 0);
            MassPos = new int[] { 0, 1, 0, 1, 0, 0, 0, 0 };
            StartCoroutine(CrossSpawn(Bullets[9], MassPos, 2, 10.8f));
        }
        else if (StageCount == 2)
        {

        }
        else if (StageCount == 3)
        {
        }
        else if (StageCount == 4)
        {
        }
        else if (StageCount == 5)
        {
        }
        else if (StageCount == 6)
        {
        }
        else if (StageCount == 7)
        {
        }
        else
        {
            switch ((int)Random.Range(0, 7))
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                default:
                    break;
            }
        }
        StageCount++;
        if (StageCount % 8 == 3 && StageCount > 5)
        {
            Heart.gameObject.SetActive(true);
            StopAllCoroutines();
            CanDoDamage = false;
        }
    }
    void ChooseAttack3()
    {

    }
    void ChooseAttack4()
    {

    }

    IEnumerator CrossSpawn(GameObject Obj, int[] type, float Distance = 0, float timeWait = 1f) // Вгоняем пулю, Массив с точкой появления по часовой стрелки(начало слева) и дистанцию.
    {
        Heart.gameObject.SetActive(false);
        Anim.SetInteger("Stage", 0);
        //Anim.SetBool("Attack", true);
        yield return new WaitForSeconds(1f);
        Anim.SetInteger("Stage", 2);
        if (type[0] == 1)
        {
            Instantiate(Obj, new Vector2(Player.transform.position.x - Distance, Player.transform.position.y), Quaternion.identity);
        }
        if (type[1] == 1)
        {
            Instantiate(Obj, new Vector2(Player.transform.position.x - Distance, Player.transform.position.y + Distance), Quaternion.identity);
        }
        if (type[2] == 1)
        {
            Instantiate(Obj, new Vector2(Player.transform.position.x, Player.transform.position.y + Distance), Quaternion.identity);
        }
        if (type[3] == 1)
        {
            Instantiate(Obj, new Vector2(Player.transform.position.x + Distance, Player.transform.position.y + Distance), Quaternion.identity);
        }
        if (type[4] == 1)
        {
            Instantiate(Obj, new Vector2(Player.transform.position.x + Distance, Player.transform.position.y), Quaternion.identity);
        }
        if (type[5] == 1)
        {
            Instantiate(Obj, new Vector2(Player.transform.position.x + Distance, Player.transform.position.y - Distance), Quaternion.identity);
        }
        if (type[6] == 1)
        {
            Instantiate(Obj, new Vector2(Player.transform.position.x, Player.transform.position.y - Distance), Quaternion.identity);
        }
        if (type[7] == 1)
        {
            Instantiate(Obj, new Vector2(Player.transform.position.x - Distance, Player.transform.position.y - Distance), Quaternion.identity);
        }
        yield return new WaitForSeconds(timeWait);
        CanDoDamage = true;
    }

    IEnumerator LineObjectSpawn(GameObject Obj, float time = 0f, float step = 0f, float plusY = 0f, float wait = 7f)
    {
        yield return new WaitForSeconds(1f);
        Anim.SetInteger("Stage", 3);
        for (float i = gameObject.transform.position.x - 5; i < gameObject.transform.position.x + 5; i += 0.5f + step)
        {
            Instantiate(Obj, new Vector2(i, gameObject.transform.position.y + 1 + plusY), Quaternion.identity);
            yield return new WaitForSeconds(time);
        }
        Anim.SetInteger("Stage", 0);
        yield return new WaitForSeconds(wait);
        CanDoDamage = true;
    }

    IEnumerator StarAttack(float x = 0f, float y = 0f)
    {
        TC4.gameObject.SetActive(true);
        for (float bright = 0; bright < 1; bright += 0.01f)
        {
            TC4.color = new Color(1, 1, 1,bright);
            yield return new WaitForSeconds(0.001f);
        }
        gameObject.transform.position = new Vector2(x, y);
        for(int i = 0; i < 5; i++)
        {
            
            yield return new WaitForSeconds(3f);
            Instantiate(Bullets[12], new Vector2(Player.transform.position.x - 2, Player.transform.position.y + 2), Quaternion.identity);
            Instantiate(Bullets[12], new Vector2(Player.transform.position.x + 2, Player.transform.position.y + 2), Quaternion.identity);
            Instantiate(Bullets[12], new Vector2(Player.transform.position.x + 2, Player.transform.position.y - 2), Quaternion.identity);
            Instantiate(Bullets[12], new Vector2(Player.transform.position.x - 2, Player.transform.position.y - 2), Quaternion.identity);
            Instantiate(HpHeal, new Vector2(Random.Range(Player.transform.position.x - 2 , Player.transform.position.x + 2) , Random.Range(Player.transform.position.y - 2, Player.transform.position.y + 2)), Quaternion.identity);
            yield return new WaitForSeconds(3f);
            Instantiate(Bullets[12], new Vector2(Player.transform.position.x + 2, Player.transform.position.y), Quaternion.identity);
            Instantiate(Bullets[12], new Vector2(Player.transform.position.x - 2, Player.transform.position.y), Quaternion.identity);
            Instantiate(Bullets[12], new Vector2(Player.transform.position.x, Player.transform.position.y + 2), Quaternion.identity);
            Instantiate(Bullets[12], new Vector2(Player.transform.position.x, Player.transform.position.y - 2), Quaternion.identity);

        }
        yield return new WaitForSeconds(4f);
        for (float bright = 1; bright > 0; bright -= 0.01f)
        {
            TC4.color = new Color(1, 1, 1, bright);
            yield return new WaitForSeconds(0.001f);
        }
        TC4.gameObject.SetActive(false);

        CanDoDamage = true;
    }

    IEnumerator TileDissapear() //Клинки по диагонали сверху
    {
        yield return new WaitForSeconds(1f);
        for (float bright = 1; bright > 0.5; bright -= 0.01f)
        {
            Tiles[0].color = new Color(bright, bright, bright);
            Tiles[1].color = new Color(bright, bright, bright);
            Tiles[2].color = new Color(bright, bright, bright);
            Tiles[3].color = new Color(bright, bright, bright);
            Tiles[4].color = new Color(bright, bright, bright);
            Tiles[5].color = new Color(bright, bright, bright);
            Tiles[6].color = new Color(bright, bright, bright);
            Tiles[7].color = new Color(bright, bright, bright);
            Tiles[8].color = new Color(bright, bright, bright);
            Tiles[9].color = new Color(bright, bright, bright);
            yield return new WaitForSeconds(0.001f);
        }
        TC1.gameObject.SetActive(true);
    }

    IEnumerator Bushed() //Клинки по диагонали сверху
    {
        Anim.SetInteger("Stage", 4);
        yield return new WaitForSeconds(1f);
        Anim.SetInteger("Stage", 0);
        CanDoDamage = true;
    }
}
