using UnityEngine;
using System; 
using System.IO; //библиотеки

public class saving : MonoBehaviour
{
    /* public static string[] save = new string[1]; // Локальный массив (Л/М), массив где хранятся ВСЕ игровые данные нуждающиеся в постоянной памяти. Находится в ОЗУ. Закрыт для других скриптов. Делать запись через функции.
    private static string savePath; //Путь до файла

    void Awake() //Точка вхождения в дерьмо
    {
        DontDestroyOnLoad(this.gameObject); //Делаем объект статическим для всех сцен
        savePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"GoldenSoul/savefile.svf"); //Путь до %appdata%
        if (!File.Exists(savePath)) //Не существует
        {
            Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"GoldenSoul")); //Создаём папку
            string[] startInfo =
            {
                "lng:1"
            };
            File.WriteAllLines(savePath,startInfo);
            save = File.ReadAllLines(savePath);
            
        }
        else //Если существует
            save = File.ReadAllLines(savePath); //Записываем в локальный массив все данные
        //EventSavingSystem.SaveEvent(0, "lng", save[0]);
        EventSavingSystem.SaveEvent("CORE","lng",save[0]);
    }

    private static string deleteAllmarks(string mark) //Локальная функция, удаляет все ненужные символы, оставляет только переменную
    {
        mark = mark.Replace(" ", ""); //Заменяем пробелы пустотой
        mark = mark.Substring((mark.IndexOf(":") + 1)); //Удаляем весь текст до символа после двооеточия
        if (mark.IndexOf("//") > -1)
            mark = mark.Remove(mark.IndexOf("//")); //Чистим комменты, если они есть
        return mark; //Возвращаем чистенькую переменную
    }

    // ЗАГРУЗКА ФАЙЛА ИЗ Л/М !!!! Для вызова из любого скрипта использовать: saving.loadLine(номер строчки);  !!! Это уже переменная, её не нужно ни к чему приравнивать.                                                         
    public static string loadLine(int lineNumber) //Загрузка одной линии из локального массива
    {
        string _save = save[lineNumber]; //создаём переменную, что-бы не травмировать локальный массив
        _save = deleteAllmarks(_save); // Возвращзаем "чистую" переменную
        return _save; //Возвращаем переменную в любой код
    }
    // СОХРАНЕНИЕ ФАЙЛА В Л/М !!!! Для вызова из любого скрипта использовать: saving.saveLine(номерстрочки,названиеСтрочки,текст строчки, Комментарий(!По желанию!));
    public static void saveLine(int lineNumber,string DescriptionText,string Text,string Comment = "")
    {
        if(save.Length < lineNumber) //Проверряем размер массива
            Array.Resize(ref save, lineNumber + 1); //При необходимости (99%) расширяем массив
        if (Comment != "") //Проверяем есть ли комментарий
            save[lineNumber] = DescriptionText + ":" + Text + " //" + Comment; //Записываем строчку в Л/С с комментом
        else
            save[lineNumber] = DescriptionText + ":" + Text;//Записываем строчку в Л/С без коммента
    }
    public static void LoadAllGame() //Загрузка Файла в Л/М
    {
        save = File.ReadAllLines(savePath); //Собсна читаем файл и записываем
    }
    public static void SaveAllGame() //Сохранение Л/М в файл
    {
        File.WriteAllLines(savePath,save); //Собсна просто записываем
    }

    public static void EraseSave() // Стирание всего прогресса !!! СТИРАЕТ ФАЙЛ И Л/М !!!
    {
       File.Delete(savePath); //Удаляем файл
        if (save != null) //Проверяем есть ли в массиве данные (Без него вызываются ошибки при повторной очистке)
            for (int i = 0; i < save.Length; i++) //Собсна очищаем массив
                save[i] = "";
       File.Create(savePath);//Создаём пустой файл
    }
    public static string FindByName(string lineName) // найти по имени
    {
        string[] find = File.ReadAllLines(savePath); //Массив файла
        string line; // Одная линия для работы с ней
        for (int i = 0 ;i < find.Length ; i++) 
        {
            line = find[i].Replace(" ",""); //Заменяем пробелы 
            line = line.Remove(find[i].IndexOf(":") - 1); //Удаляем все символы после ":"
            if (line == lineName) return deleteAllmarks(find[i]); //Если нашли, выводим
        }
        return "No results"; //Если ничего нашли выводим "No results"
    }*/
}