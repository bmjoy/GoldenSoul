using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueMass
{
    public static string[] Rus =
    {
            "LexusLight", //0
            "а", //1
            "GoldenSoul.",//2
            "~ Вера. Надежда. Судьба. \n Всё тщетно..",//3 Вступление
            "~ Каждый, кто попадает в зачарованный лес, остаётся здесь навсегда.",//4
            "Может это просто плохой сон?",//5
            "Нет, ведь ты не спал буд-то целую вечность.",//6
            "Всё, что осталось − это твоё имя. \n Потеря имени равносильна потере всего, что у тебя есть.",//7
            "Тебя зовут Каспиан. И ты заблудился.",//8
            "Пожалуйста, запомни cвоё имя.",//9
            "Человек, что должен был исчезнуть давным-давно.....",//10
            "Твоя душа давно умерла, а тело обречено целую вечность скитаться в этой петле..",//11
            "Тебе повезло, ведь я СОВЕРШЕННО СЛУЧАЙНО на тебя наткнулся...",//12
            "Подойди ближе, если в тебе осталось хоть что-то от человеческих чувств.......",//13
            "Ха-Ха! Посмотри на своё лицо! Ты словно призрака увидел......",//14
            "У тебя мало времени, но я знаю, как можно помочь",//15
            "Я подарю тебе ЗОЛОТУЮ ДУШУ.",//16
            "С ней ты сможешь продлить себе жизнь и выйти из этого странного места.",//17
            "Подойди ко мне!",//18
            "После поглощения души, ты отключишься. Я буду ждать впереди.",//19
            "Удачи!",//20
            "",//21
            "Огромный блестящий отполированный меч.",//22 Меч в камне
            "Он торчит в огромном блестящем отполированном камне. ",//23
            "Вы пытаетесь отделить этот прекрасный камень от груды металлолома. Потрачено.",//24
            "На что ты вообще надеялся? Тут же написано:'Только для героев.'",//25
            "Ты же не герой))))1)",//26
            "Посмотри на этот устрашающий пень. Представь что он хочет тебя убить.",//27 Пень
            "Вот-таких магических существ тут пруд - пруди, будь осторожен!",//28
            "Это весёлый пенёк с привязанным к нему ножом. Он совсем не страшный.",//29
            "Вам нравится этот пенёк.",//30
            "Тот плод в лианах, что сверкает золотым цветом, называется СЕРДЦЕ НОЧИ.",//31 Сердце ночи
            "Такие сердца обычно содержат в себе жизненную энергию. Это очень редкое растение.",//32
            "Оно может подкрепить твою НОВУЮ ДУШУ энергией. Для его активации нажми 'A'.",//33
            "Для того, чтобы ударить, НАЖМИ кнопку удара.",//34
            "",//35
            "",//36
            "Это старинная газета. Вы можете разобрать только заголовок.\n На нём написано:",//37------Газета
            "Студент Разорвал ткань пространства и остался жи..",//38
            "Ну Надо-же! \nПолучилось! \nКак самочувствие?",//39
            "Ты не против присесть и поговорить? Теперь ты в безопасности.",//40
            "Давай знакомиться. Меня зовут Кэндл.\n Я маг из факультета огня Блэрского университета магии.",//41
            "Люблю проводить своё свободное время во всяких странных местах... Типа этого леса.",//42
            "У тебя наверное много вопросов: \n'кто ты и что это за место?'",//43
            "Начнём с места.",//44
            "Это Лес Небытия. Аномальное место, в котором пропадают люди.",//45
            "Ходят легенды, что этот лес служил магической тюрьмой для опасных существ и монстров.",//46
            "Что касается тебя...............",//47
            "Чувак, поздравляю! Ты Умер!",//48
            "Ну формально, твоё тело не мертво. Ты дышишь, можешь слышать и видеть.",//49
            "Но ты потерял главную часть себя - СВОЮ ДУШУ.",//50
            "Что такое ДУША? ДУША олицетворяет то, кем ты являешься.",//51
            "Это твоя энергия, твои воспоминания, чувства и эмоции.",//52
            "Знаешь, когда я нашёл тебя... Тебе оставалось не долго.",//53
            "Но ЗОЛОТАЯ ДУША - спасла тебя, наполнив тебя МАГИЧЕСКОЙ ЭНЕРГИЕЙ.",//54
            "Это всего лишь ПОДДЕЛКА. Ведь ты не чувствуешь боли, не можешь заплакать. У тебя не течёт кровь.",//55
            "Но, я кажется знаю, как можно вернуть твою душу назад. /n Сначала нам нужно выбраться отсюда.",//56
            "К сожалению, я не могу телепортировать нас обоих. Тебе придётся выбираться своими ногами.",//57
            "Тут поблизости есть старый парк. Он является выходом из этого места.",//58
            "Пошли!",//59
 /*cat1*/   
    };
    public static string[] Eng =
{
            "LexusLight", //0
            "a",//1
            "GoldenSoul.",//2
            "~ Hope. Faith. Fate. \nAll in vain.",//3
            "~ Everyone, who enters the enchanted forest will stay here forever.",//4
            "Maybee Is all of this just a bad dream?",//5
            "It couldn't be, because you haven't slept for what seems like eternity.",//6
            "All you have left is your name.",//7
            "The loss of your name equals the loss of everything you have ever had.",//8
            "Your name is Caspian.\n And you're lost. \n Please, remember this name.",//9
            "Human, who should've ceased existance long-long time ago...",//10
            "Your soul is gone, and your body is doomed to roam in this time loop for all eternity.",//11
            "You're lucky, because I happened to stumble upon you COMPLETELY BY CHANCE.",//12
            "Come closer, if you still have any emotions or feelings!",//13
            "Ha-Ha! I wish you could see youself right now. It's as if you have just seen a ghost... ",//14
            "We have little time to keep you sane, but I know how to help you.",//15
            "I will make you a Soul out of Gold.",//16
            "With a Golden Soul you can lengthen your life, so I could guide you out of this place.",//17
            "Come over here.",//18
            "Once the merger happens, you'll pass out. I will wait for you near ahead.",//19
            "Good luck.",//20
            "",//21
            "A shiny, polished greatsword.",//22
            "It is fixed into a shiny, polished stone",//23
            "You attempt to separate this wonderful stone from the worthless hunk of metal. You failed.",//24
            "What were you hoping for? It's inscribed right here: 'Only for heroes' ",//25
            "You are no hero))))1)",//26
            "Look at that menacing tree stump. Act as if it's trying to kill you.",//27
            "There's lots of them around. Beware of them!",//28
            "This is a cheerful tree stump with a knife strapped to it. It doesn't seem scary at all.",//29
            "You like this tree stump.",//30
            "That fruit concealed within vines, that glisters like gold is called THE HEART OF THE NIGHT.",//31
            "These fruit usually contain life energy within themselves. A very rare plant.",//32
            "This can enrich your NEW SOUL with energy. To activate it, press 'A'",//33
            "To hit, HOLD the hit button." ,//34
            "",//35
            "",//36
            "This is an old paper. You can make out only the headline. \n It says:", // 37 ------ Newspaper
            "The student tore apart the spatial tissue and remained ali..", // 38
    };
}
