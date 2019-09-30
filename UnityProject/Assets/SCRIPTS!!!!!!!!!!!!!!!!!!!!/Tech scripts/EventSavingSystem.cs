using UnityEngine;
using System;
// NameSpace;name:Event
public class EventSavingSystem : MonoBehaviour
{
    public static int RealHp = 2; //Минимальное ХП с начала 
    public static int ThisLvl = 1; //Язык
    public static int LastLvl = 1;
    public int _Language = 1; //Язык
    //-----------------------------------
    public float[] _LevelCoordsX; 
    public float[] _LevelCoordsY;
    public static float[] LevelCoordsX;  //для возврата на пребедущие локации
    public static float[] LevelCoordsY; //для возврата на пребедущие локации
    public static bool[] HeroWasHere;  //для возврата на пребедущие локации
    public bool[] _HeroWasHere;
    //-----------------------------------
    public static int Language;
    private void Awake()
    {
        Language = _Language;
        LevelCoordsX = _LevelCoordsX;
        LevelCoordsY = _LevelCoordsY;
        HeroWasHere = _HeroWasHere;
        for (int i = 0; i < LastLvl; i++) //Отмечаем где мы были до последнего уровня(помогает соблюсти сюжет и вернуться к прогрессу)
        {
            HeroWasHere[i] = true;
        }
        _HeroWasHere = HeroWasHere;
    }
    


    //Тимофей, это ваше)

    /* static private string[] Event = new string[0]; 
    public string[] _Event; //Debug array

    public string input, output;
    public bool _DAMNS, _DAMwNS, load, save, changeEvent;
    public string nm, na, ev;
    public void DEBUG() // Дебаг
    {
        if (_DAMNS)
            output = DAMNS(input);
        if (_DAMwNS)
            output = DAMwNS(input);
        if (load)
        {
            load = false;
            print(LoadEvent("test", "test"));
        }
        if (save)
        {
            save = false;
            SaveEvent(nm, na, ev);
        }
    }
    private void Awake()
    {
        //Event[0] = "start;doNot:Change";
    }
    private void Start()
    {
        //Event[0] = saving.loadLine(0);
    }
    public void ChangeLNG()//СИСТЕМУ ЯЗЫКА НА ВРЕМЯ ОТКЛЮЧИЛ её надо переделывать
    {
        /* if (Event[0] == "1")
             Event[0] = "0";
         else
             Event[0] = "1";
         //DialogueMas.langflagl = Convert.ToInt32(Event[0]);
         saving.saveLine(0,"lng",Event[0]);
         saving.SaveAllGame();
    }
    void Update()
    {
        _Event = Event; // Тоже дебаг
        DEBUG();
    }

    static private string[] loadnameSpaceEvent(string Namespace) //возвращает массив только с одним NameSpace
                                                                 //NS;N:E < оформление чисто напоминалоска
    {
        string[] ready = new string[0]; // Создаём массив который будем выводить
        int count = 0;//Счётчик
        foreach (string find in Event) //Перебираем весь Евент(очень медленно, еогда было 50 айтемов редактор подлагивал, надо что-то с эти делать)
        {
            if (DAMNS(find) == Namespace) //Ищем подходящий NameSpace
            {//ТОЧКА ВХОДА В ДЕРЬМО
                if (Event.Length > 1) // тут рил говнокод, тип если в массиве 1 объект или меньше, То поступаем по=другому
                    Array.Resize(ref ready, count);//Изменяем массив так
                else
                    Array.Resize(ref ready, count + 1);// А тут сяк
                ready[ready.Length - 1] = Event[count]; //Записываем подходящие значени
            }
            count++;//++
        }
        return ready;//Возвращаем
    }
    static private int FindNumberInArrays(string Namespace, string name) //Тоже жуткий костыль. Ищем номер нужной нам записи
    {
        int count = 0;//С Ч Е Т Ч И К
        string rname; //я умею называть переменные, я тут зашифровал Ready Name или готовое к проверке
        foreach (string result in Event)//ЕЩЁ раз перебираем (-телефоны)
        {
            if (result != "")//К О С Т Ы Л Ь
            {
                rname = DAMwNS(result);//подготавливаем rname
                rname = rname.Remove(rname.IndexOf(":"));//^^
                if (DAMNS(result) == Namespace && rname == name)//Двойная проверка
                    return count;//Возвращаем номер
            }
            count++;//++
        }
        return -1;//возвращаем -1 если нихрена не нашли(круто перебрали пол игры, а в итоге -1)
    }
    public static void SaveEvent(string Namespace, string EventName, string _event) // Сохранение эвента
    {
        string[] AllNameSpace = loadnameSpaceEvent(Namespace); //массив с нужными нам NS
        if (AllNameSpace.Length > 0)//тут начинается боль, на этом моменте можно попрощаться с производительностью.Проверяем есть ли другие записи с таким же NS
        {
            int a = FindNumberInArrays(Namespace, EventName);//Ищем номер нужной нам записи
            print(a);//Д Е Б А Г
            if (a == -1)//ну это если мы обосрались и нифига не нашли
            {
                Array.Resize(ref Event, Event.Length + 1);//тогда просто как тупицы, которые потратили стоооолько производительности делаем, делаем новую запись
                Event[Event.Length - 1] = Namespace + ";" + EventName + ":" + _event;
                return;
            }
            else//Тут нам повезло и мы что-то нашли и записываем D определённой (a) строке массива
                Event[a] = Namespace + ";" + EventName + ":" + _event;//собсна тут я и воплощаю свои угрозы
            return;//ну а почему бы не сказать в конце скрипта Я ЗАКОНЧИЛСЯ?
        }
        else//На самом деле я рил хз зачем там return, но я сча пишу комментарии и мне пофиг я панк
        {
            Array.Resize(ref Event, Event.Length + 1);//тут мы умные и тупа записываем без проверки (a)
            Event[Event.Length - 1] = Namespace + ";" + EventName + ":" + _event;
        }
    }
    public static string LoadEvent(string Namespace, string name)//Загрузка честно я хз эта фигня вроде бы работает, а вроде бы работает, но пару раз не сработала вооооот кароч WIP
    {
        string result;//результ
        int count = 0;//C O U N T E R
        string[] a = loadnameSpaceEvent(Namespace);//ага опять перебираем все евенты 
        foreach (string word in a)//ахахахаха перебераем перебранные строки ахаахахах ржу
        {
            a[count] = DAMwNS(a[count]);//я умею в говнокод, просто убираем лишние символы
            if (a[count].Remove(a[count].IndexOf(":")) == name)//тоже самое, только уже сравниваем
            {
                result = a[count].Substring(a[count].IndexOf(":") + 1);//записываем результат
                //"Работает, не трогай, ебалай" © Конфуций
                return result;//Возвращаем результат
            }
            count++;//С Ч Ё Т Ч И К А Т Ы Н Е В Е Р И Л?
        }
        return "ERROR404";//Ну тут у меня фантазия закончилась
    }
    private static string DAMwNS(string mark) //DAMNS - Delete All Marks without NameSpace
    {
        mark = mark.Replace(" ", ""); //Заменяем пробелы пустотой
        mark = mark.Substring(mark.IndexOf(";") + 1);
        return mark;
    }
    private static string DAMNS(string mark)//DAMNS - Delete All Marks NameSpace
    {
        mark = mark.Replace(" ", ""); //Заменяем пробелы пустотой
        mark = mark.Remove(mark.IndexOf(";")); //Удаляем весь текст до символа
        return mark;
    }*/
}