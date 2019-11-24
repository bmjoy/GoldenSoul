using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
public class InvSys : MonoBehaviour
{
    //private static Dictionary<string, int> idsINV;
    //private int slotsINV;
    public static string strings;
    public struct Item
    {
        public int id;
        public string name;
        public byte count;
        public Item(int id,string name,byte count) // Делаем структуру
        {
            this.id = id;
            this.name = name;
            this.count =count;
        }
    }
    public static Item[] Items = new Item[15]; // Рабочие ячейки с 1 и далее
    public static Item[] UImas = new Item[10]; // Рабочие ячейки с 1 и далее

    void Awake() //ПРОСТАВЛЯТЬ ID ОБЯЗАТЕЛЬНО ПО ПОРЯДКУ, ОТ ЭТОГО ЗАВИСИТ КОД
    {
        Items[1] = new Item(1, "heart", 1);
        Items[2] = new Item(2, "goldenkey", 2);
        Items[3] = new Item(3, "bottle", 3);
        Items[4] = new Item(4, "ghosttle", 4);
        Items[5] = new Item(5, "sword", 5);
        Items[6] = new Item(6, "item1",5);
        Items[7] = new Item(7, "item2", 5);
        Items[8] = new Item(8, "item3", 0);
        Items[9] = new Item(9, "item4", 5);
        Items[10] = new Item(10, "item5", 5);
        Items[11] = new Item(11, "item6", 5);
        Items[12] = new Item(12, "item7", 0);
        Items[13] = new Item(13, "item8", 5);
        Items[14] = new Item(14, "item9", 5);
        Uitrace();
        Invupdate(1);
    }
    public static void Invupdate(int x) //В Цикле выводим в окошко инвентарь
    {
        strings = "";
        for (int i = 1; i < UImas.Length; i++) strings += UImas[i].name + "\n"; 
    }
    public static void AddItem(int x) //Инкрементация предмета. Доработать
    {
        Items[x].count++;
    }
    public static void Uitrace(int i = 0, int j = 1) //тут мы забиваем массив из 9 строчек 5 слотами, задаём индекс начала. жесть. да-да.
    {
        UImas = new Item[10]; //Отчищаем выводящий массив
        while (i < 50)//Просто много итерраций
        {
            if (i >= Items.Length - 1) break; //если указатель больше числа айтемов, выходим
            if (Items[i + 1].count != 0) //если хоть одна единица вещи есть в инвентаре - добавляем её в массив для вывода
            {
                if (j == UImas.Length) break; //если указатель массива для вывода больше числа ячеек - выходим
                UImas[j++] = Items[++i];//инкрементаруем указатели
                continue; 
            }
            else
            {
                i++; //Если предметов 0 - переходим указателем инвентаря к следующему предмету
            }

        }
    }
    static void SaveInv()
    {

    }
}
