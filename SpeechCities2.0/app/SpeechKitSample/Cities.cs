﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.SpeechKit.Demo
{
    class Cities
    {
        public Cities()
        {
            citiesSet = new SortedSet<string>();
            prevCity = "null";
        }        

        public void InitializeCitiesSet()
        {
            
            foreach (string city in citiesArray)
            {
                citiesSet.Add(city);
            }
        }

        public void ReleaseCitiesSet()
        {
            citiesSet.Clear();
        }

        public bool PullCityByName(string cityName)
        {
            string[] words = cityName.Split(new char[] {' '});
            int countWords = words.Length;
            bool found = false;
            string newCityName;
            switch(countWords)
            {
                case 1:
                    // If deleted - true, otherwise - false
                    newCityName = cityName;
                    found = citiesSet.Remove(cityName);
                    break;
                case 2:
                    newCityName = words[0] + "-" + words[1];
                    found = citiesSet.Remove(newCityName);
                    break;
                case 3:
                    newCityName = words[0] + "-" + words[1] + "-" + words[2];
                    found = citiesSet.Remove(newCityName);
                    break;
                default:
                    found = false;
                    break;
            }
            if (found)
            {
                prevCity = cityName;
            }
            return found;
        }

        public string previousCity
        {
            get { return prevCity; }
        }

        private string prevCity;
        private SortedSet<string> citiesSet;
        private string[] citiesArray = { 
            "Абакан", "Абдулино", "Абинск", "Агрыз", 
            "Адыгейск", "Азнакаево", "Азов", "Ак-Довурак", "Алагир", "Алапаевск", "Алатырь", "Алейск", 
            "Александровск-Сахалинский", "Алзамай", "Алупка", "Алушта", "Альметьевск", 
            "Амурск", "Анадырь", "Анапа", "Ангарск", 
            "Андреаполь", "Анжеро-Судженск", "Апатиты", "Апрелевка", "Апшеронск", "Арамиль", 
            "Арзамас", "Аркадак", "Армянск", "Арск", 
            "Архангельск", "Асино", "Астрахань", "Аткарск", 
            "Ахтубинск", "Ачинск", "Аша", "Бабаево", 
            "Бавлы", "Багратионовск", "Байкальск", "Баймак", 
            "Бакал", "Балабаново", "Балаково", "Балахна", 
            "Балашиха", "Балей", "Балтийск", "Барабинск", 
            "Барнаул", "Батайск", "Бахчисарай", "Бежецк", 
            "Белая Калитва", "Белая Холуница", "Белгород", "Белебей", 
            "Белово", "Белозерск", "Белокуриха", "Беломорск", 
            "Белорецк", "Белореченск", "Бердск", "Березники", 
            "Беслан", "Бийск", "Билибино", "Биробиджан", 
            "Бирск", "Бирюсинск", "Благовещенск", "Благодарный", 
            "Богородицк", "Богородск", "Богучар", "Бокситогорск", 
            "Болгар", "Бологое", "Болотное", "Болохово", 
            "Болхов", "Большой Камень", "Борзя", "Борисоглебск", 
            "Боровичи", "Боровск", "Братск", "Бронницы", 
            "Брянск", "Бугульма", "Бугуруслан", "Бузулук", 
            "Буйнакск", "Бутурлиновка", "Валдай", "Валуйки", 
            "Велиж", "Великие Луки", "Великий Новгород", "Великий Устюг", 
            "Вельск", "Верещагино", "Верея", "Верхнеуральск", 
            "Верхний Тагил", "Верхний Уфалей", "Верхняя Пышма", "Верхняя Салда", 
            "Верхняя Тура", "Верхотурье", "Верхоянск", "Весьегонск", 
            "Видное", "Вилюйск", "Вилючинск", "Вихоревка", 
            "Вичуга", "Владивосток", "Владикавказ", "Волгоград", 
            "Волгодонск", "Волгореченск", "Волжск", "Волжский", 
            "Вологда", "Володарск", "Волоколамск", "Волосово", 
            "Вольск", "Воркута", "Воронеж", "Ворсма", 
            "Воскресенск", "Воткинск", "Всеволожск", "Вуктыл", 
            "Выборг", "Выкса", "Высоковск", "Высоцк", 
            "Вытегра", "Вязники", "Вязьма", "Вятские Поляны", 
            "Гаврилов Посад", "Гаврилов-Ям", "Гаджиево", "Гатчина", "Гвардейск", "Гдов", 
            "Геленджик", "Георгиевск", "Глазов", "Голицыно", 
            "Горно-Алтайск", "Городец", "Городовиковск", "Гороховец", "Горячий Ключ", 
            "Грайворон", "Гремячинск", "Грозный", "Грязи", 
            "Грязовец", "Губаха", "Губкинский", "Гудермес", 
            "Гулькевичи", "Гусь-Хрустальный", "Давлеканово", "Дагестанские Огни", "Далматово", "Дальнегорск", 
            "Дальнереченск", "Данков", "Дегтярск", "Дедовск", 
            "Дербент", "Десногорск", "Джанкой", "Дивногорск", 
            "Дигора", "Дмитров", "Дмитровск", "Добрянка", 
            "Долгопрудный", "Долинск", "Дорогобуж", "Дрезна", 
            "Дубна", "Дубовка", "Дудинка", "Духовщина", 
            "Дюртюли", "Дятьково", "Евпатория", "Егорьевск", 
            "Ейск", "Екатеринбург", "Елабуга", "Елец", 
            "Елизово", "Ельня", "Еманжелинск", "Емва", 
            "Енисейск", "Ессентуки", "Железноводск", "Железногорск-Илимский", "Жердевка", "Жирновск", "Завитинск", "Заводоуковск", 
            "Заволжск", "Задонск", "Заинск", "Закаменск", 
            "Заполярный", "Зарайск", "Заринск", "Звенигово", 
            "Звенигород", "Зверево", "Зеленоградск", "Зеленокумск", 
            "Зерноград", "Златоуст", "Злынка", "Змеиногорск", 
            "Зубцов", "Зуевка", "Ивангород", "Иваново", 
            "Ивантеевка", "Ивдель", "Игарка", "Ижевск", 
            "Избербаш", "Изобильный", "Иланский", "Инза", 
            "Инкерман", "Инта", "Ипатово", "Ирбит", 
            "Иркутск", "Исилькуль", "Искитим", "Ишим", 
            "Ишимбай", "Йошкар-Ола", "Кадников", "Казань", "Калач-на-Дону", "Калачинск", "Калининград", "Калининск", "Калуга", 
            "Калязин", "Камбарка", "Каменногорск", "Каменск-Уральский", "Каменск-Шахтинский", "Камень-на-Оби", "Камешково", "Камызяк", "Камышин", "Камышлов", 
            "Канаш", "Кандалакша", "Канск", "Карабаново", 
            "Карабаш", "Карачаевск", "Карачев", "Каргополь", 
            "Карпинск", "Карталы", "Касимов", "Касли", 
            "Каспийск", "Катав-Ивановск", "Катайск", "Качканар", "Кашин", "Кашира", 
            "Кемерово", "Керчь", "Кизел", "Кизилюрт", 
            "Кизляр", "Кимовск", "Кимры", "Кингисепп", 
            "Кинель", "Кинешма", "Киренск", "Киржач", 
            "Кириши", "Кировград", "Кирово-Чепецк", "Кирс", "Кирсанов", "Кисловодск", "Климовск", 
            "Клинцы", "Княгинино", "Ковдор", "Ковров", 
            "Ковылкино", "Когалым", "Кодинск", "Козельск", 
            "Козьмодемьянск", "Кологрив", "Коломна", "Колпашево", 
            "Колпино", "Кольчугино", "Комсомольск-на-Амуре", "Конаково", "Кондопога", "Кондрово", "Константиновск", 
            "Копейск", "Кораблино", "Кореновск", "Коркино", 
            "Короча", "Коряжма", "Костомукша", "Кострома", 
            "Котельники", "Котельниково", "Котельнич", "Котлас", 
            "Котово", "Кохма", "Красавино", "Красновишерск", 
            "Красногорск", "Краснодар", "Красное Село", "Краснозаводск", 
            "Краснокаменск", "Краснокамск", "Красноперекопск", "Краснотурьинск", 
            "Красноуральск", "Красноуфимск", "Красноярск", "Красный Кут", 
            "Красный Сулин", "Красный Холм", "Кронштадт", "Крымск", 
            "Крымский кризис", "Кстово", "Кубинка", "Кувандык", 
            "Кувшиново", "Кудымкар", "Кулебаки", "Кумертау", 
            "Кунгур", "Курганинск", "Курильск", "Курлово", 
            "Куровское", "Курск", "Куртамыш", "Куса", 
            "Кушва", "Кызыл", "Кыштым", "Кяхта", 
            "Лабинск", "Лабытнанги", "Лагань", "Ладушкин", 
            "Лаишево", "Лакинск", "Лангепас", "Лахденпохья", 
            "Лебедянь", "Ленинск-Кузнецкий", "Ленск", "Лесной", "Лесозаводск", "Лесосибирск", 
            "Ливны", "Липецк", "Липки", "Лиски", 
            "Лихославль", "Лобня", "Лодейное Поле", "Лосино-Петровский", "Луга", "Лукоянов", "Луховицы", "Лысково", 
            "Лысьва", "Лыткарино", "Льгов", "Люберцы", 
            "Любим", "Людиново", "Лянтор", "Магадан", 
            "Магас", "Магнитогорск", "Майкоп", "Макарьев", 
            "Макушино", "Малая Вишера", "Малгобек", "Малмыж", 
            "Малоярославец", "Мамадыш", "Мамоново", "Мантурово", 
            "Мариинск", "Мариинский Посад", "Махачкала", "Мглин", 
            "Мегион", "Медвежьегорск", "Медногорск", "Медынь", 
            "Междуреченск", "Меленки", "Мелеуз", "Менделеевск", 
            "Мензелинск", "Мещовск", "Миасс", "Микунь", 
            "Миллерово", "Минеральные Воды", "Минусинск", "Миньяр", 
            "Мичуринск", "Могоча", "Можайск", "Можга", 
            "Моздок", "Мончегорск", "Морозовск", "Моршанск", 
            "Мосальск", "Москва", "Муравленко", "Мураши", 
            "Мурманск", "Муром", "Мценск", "Мыски", 
            "Мытищи", "Мышкин", "Набережные Челны", "Навашино", 
            "Наволоки", "Надым", "Назрань", "Называевск", 
            "Нальчик", "Наро-Фоминск", "Нарткала", "Нарьян-Мар", "Невель", "Невельск", "Невинномысск", "Невьянск", 
            "Нелидово", "Нерчинск", "Нерюнгри", "Нефтекамск", 
            "Нефтекумск", "Нефтеюганск", "Нижневартовск", "Нижнекамск", 
            "Нижнеудинск", "Нижние Серги", "Нижний Ломов", "Нижний Новгород", 
            "Нижний Тагил", "Нижняя Салда", "Нижняя Тура", "Николаевск-на-Амуре", "Новая Ладога", "Новая Ляля", "Новоалександровск", "Новоалтайск", 
            "Новоаннинский", "Нововоронеж", "Новодвинск", "Новозыбков", 
            "Новокубанск", "Новокузнецк", "Новокуйбышевск", "Новомичуринск", 
            "Новопавловск", "Новоржев", "Новороссийск", "Новосибирск", 
            "Новосиль", "Новосокольники", "Новотроицк", "Новоузенск", 
            "Новоульяновск", "Новоуральск", "Новочебоксарск", "Новочеркасск", 
            "Новошахтинск", "Новый Оскол", "Новый Уренгой", "Ногинск", 
            "Нолинск", "Норильск", "Ноябрьск", "Нурлат", 
            "Нытва", "Нюрба", "Нягань", "Нязепетровск", 
            "Няндома", "Обнинск", "Обоянь", "Одинцово", 
            "Окуловка", "Оленегорск", "Олонец", "Омск", 
            "Омутнинск", "Опочка", "Оренбург", "Орехово-Зуево", "Орск", "Осинники", "Осташков", "Островной", 
            "Острогожск", "Отрадный", "Оха", "Оханск", 
            "Павловский Посад", "Палласовка", "Партизанск", "Певек", 
            "Пенза", "Первоуральск", "Переславль-Залесский", "Пермь", "Пестово", "Петергоф", "Петров Вал", 
            "Петровск-Забайкальский", "Петрозаводск", "Петропавловск-Камчатский", "Печоры", "Питкяранта", "Плавск", "Поворино", 
            "Подольск", "Подпорожье", "Покачи", "Полевской", 
            "Полесск", "Полысаево", "Полярные Зори", "Полярный", 
            "Поронайск", "Порхов", "Похвистнево", "Почеп", 
            "Правдинск", "Приволжск", "Приморско-Ахтарск", "Приозерск", "Прокопьевск", "Протвино", "Прохладный", 
            "Псков", "Пудож", "Пустошка", "Пучеж", 
            "Пушкино", "Пущино", "Пыталово", "Пыть-Ях", "Пятигорск", "Райчихинск", "Раменское", "Рассказово", 
            "Реж", "Реутов", "Ржев", "Рославль", 
            "Россошь", "Ростов", "Ростов-на-Дону", "Ртищево", "Рубцовск", "Руза", "Рузаевка", 
            "Рыбинск", "Рыбное", "Рыльск", "Ряжск", 
            "Рязань", "Салават", "Салаир", "Салехард", 
            "Сальск", "Самара", "Санкт-Петербург", "Саранск", "Сарапул", "Саратов", "Саров", 
            "Сасово", "Сатка", "Саяногорск", "Саянск", 
            "Светлоград", "Светогорск", "Свирск", "Себеж", 
            "Севастополь", "Северо-Курильск", "Северобайкальск", "Северодвинск", "Североморск", "Североуральск", 
            "Севск", "Сегежа", "Семикаракорск", "Семилуки", 
            "Сенгилей", "Сергач", "Сергиев Посад", "Сердобск", 
            "Серпухов", "Сестрорецк", "Сибай", "Симферополь", 
            "Сковородино", "Скопин", "Славск", "Славянск-на-Кубани", "Слободской", "Смоленск", "Снежинск", "Собинка", 
            "Советская Гавань", "Солигалич", "Соликамск", "Солнечногорск", 
            "Соль-Илецк", "Сольвычегодск", "Сольцы", "Сорочинск", "Сорск", 
            "Сортавала", "Сосенский", "Сосногорск", "Сочи", 
            "Спас-Деменск", "Спас-Клепики", "Спасск-Дальний", "Спасск-Рязанский", "Среднеколымск", "Среднеуральск", "Сретенск", "Ставрополь", 
            "Старая Купавна", "Старая Русса", "Стародуб", "Старый Крым", 
            "Старый Оскол", "Стерлитамак", "Стрежевой", "Струнино", 
            "Ступино", "Суджа", "Судогда", "Суздаль", 
            "Суоярви", "Сураж", "Сургут", "Суровикино", 
            "Сурск", "Сусуман", "Сухиничи", "Сызрань", 
            "Сыктывкар", "Сясьстрой", "Таганрог", "Тайшет", 
            "Талдом", "Тамбов", "Тарко-Сале", "Татарск", "Таштагол", "Тверь", "Теберда", 
            "Тейково", "Темников", "Темрюк", "Тетюши", 
            "Тихвин", "Тихорецк", "Тобольск", "Тогучин", 
            "Тольятти", "Томмот", "Томск", "Торжок", 
            "Торопец", "Тосно", "Тотьма", "Трубчевск", 
            "Туапсе", "Туймазы", "Тула", "Тулун", 
            "Туринск", "Тутаев", "Тында", "Тырныауз", 
            "Тюкалинск", "Тюмень", "Углич", "Удачный", 
            "Удомля", "Ужур", "Узловая", "Улан-Удэ", "Ульяновск", "Унеча", "Урай", "Урень", 
            "Уржум", "Урус-Мартан", "Урюпинск", "Усинск", "Усмань", "Усолье", 
            "Усолье-Сибирское", "Уссурийск", "Усть-Джегута", "Усть-Илимск", "Усть-Катав", "Усть-Кут", "Усть-Лабинск", "Устюжна", "Уфа", "Ухта", "Учалы", 
            "Уяр", "Фатеж", "Феодосия", "Фролово", 
            "Фрязино", "Хабаровск", "Хадыженск", "Ханты-Мансийск", "Харабали", "Харовск", "Хасавюрт", "Хвалынск", 
            "Химки", "Холмск", "Хотьково", "Цивильск", 
            "Цимлянск", "Чадан", "Чапаевск", "Чебоксары", 
            "Челябинск", "Чердынь", "Черепаново", "Череповец", 
            "Черкесск", "Черноголовка", "Черногорск", "Черняховск", 
            "Чистополь", "Чита", "Чудово", "Чусовой", 
            "Чухлома", "Шагонар", "Шадринск", "Шали", 
            "Шарыпово", "Шарья", "Шатура", "Шахунья", 
            "Шебекино", "Шенкурск", "Шимановск", "Шиханы", 
            "Шлиссельбург", "Шумерля", "Шуя", "Щербинка", 
            "Щигры", "Электрогорск", "Электросталь", "Электроугли", 
            "Элиста", "Эртиль", "Югорск", "Южа", 
            "Южно-Сахалинск", "Южно-Сухокумск", "Южноуральск", "Юрга", "Юрьев-Польский", "Юрьевец", "Юхнов", "Ядрин", "Якутск", 
            "Ялта", "Ялуторовск", "Янаул", "Яранск", 
            "Яровое", "Ярославль", "Ярцево", "Ясный", 
            "Яхрома" };

    }
}