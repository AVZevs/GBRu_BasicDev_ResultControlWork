﻿/*

---=== Итоговая контрольная работа по основному блоку ===---

Данная работа необходима для проверки ваших знаний и навыков по итогу прохождения первого блока обучения на программе Разработчик.
Мы должны убедится, что базовое знакомство с IT прошло успешно.

Задача алгоритмически не самая сложная, однако для полноценного выполнения проверочной работы необходимо:

1. Создать репозиторий на GitHub
2. Нарисовать блок-схему алгоритма (можно обойтись блок-схемой основной содержательной части, если вы выделяете её в отдельный метод)
3. Снабдить репозиторий оформленным текстовым описанием решения (файл README.md)
4. Написать программу, решающую поставленную задачу
5. Использовать контроль версий в работе над этим небольшим проектом (не должно быть так, что всё залито одним коммитом,
   как минимум этапы 2, 3, и 4 должны быть расположены в разных коммитах)

ЗАДАЧА: Написать программу, которая из имеющегося массива строк формирует новый массив из строк, длина которых меньше,
        либо равна 3 символам. Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения алгоритма.
        При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.

Примеры:

[“Hello”, “2”, “world”, “:-)”] → [“2”, “:-)”]
[“1234”, “1567”, “-2”, “computer science”] → [“-2”]
[“Russia”, “Denmark”, “Kazan”] → []
*/

int maxLengthSourceString = 3;  // Маскимальная длина строки согласно условию задачи.


// -------------------------------------------------------------------------------------------------------------------
// Метод выводит одномерный массив на экран.
// Массив выводится в квадратных скобках через запятую, элементы выводятся в чистом виде, без какого-либо обрамления.
// Переменная printNullElement отвечает за вывод пустых элементов массива. Если printNullElement = TRUE, то пустые элементы
// будут выводиться на экран также через запятую, что просто некрасиво выглядит. Если же printNullElement = FALSE, то
// пустые элементы выводиться на экран не будут.
// -------------------------------------------------------------------------------------------------------------------
void PrintArray(string[] array, bool printNullElement)
{
    Console.Write("[");
    for (int i = 0; i < array.Length; i++)
    {
        if (i < array.Length - 1)
        {
            if (printNullElement)
            {
                Console.Write($"{array[i]}, ");
            }
            else
            {
                if (array[i] != null && array[i] != "")
                    Console.Write($"{array[i]}, ");
            }
        }
        else
        {
            if (printNullElement)
            {
                Console.Write($"{array[i]}");
            }
            else
            {
                if (array[i] != null && array[i] != "")
                    Console.Write($"{array[i]}");
            }
        }
    }
    Console.Write("]");
}


// -------------------------------------------------------------------------------------------------------------------
// Метод создает новый массив согласно условию задачи. В этот новый массив попадут только строки из массива array[],
// которые имеют длину до 3-х символов включительно (согласно условию задачи).
// При этом размер нового массива будет вычисляться динамически, чтобы его размер совпадал с количеством строк,
// которые удовлетворяют условию задачи.
// -------------------------------------------------------------------------------------------------------------------
string[] CreateNewArray(string[] array)
{
    string[] arrayNew = new string[0]; // Изначально зададим нулевой размер нового массива.

    // Проходим по всем елементам массива...
    foreach (var item in array)
    {
        // ... и проверяем условие задачи
        if (item.Length <= maxLengthSourceString)
        {
            Array.Resize(ref arrayNew, arrayNew.Length + 1); // Увеличим размер (длину) массива на единицу.
            arrayNew[arrayNew.Length - 1] = item;
        }
    }
    return arrayNew;
}


// ----------------------------------------------------------------------------------
// Вывод шапки программы вместе с меню и обеспечение функциональности меню.
// Здесь мы даем пользователю возможность выбора пункта меню.
// ----------------------------------------------------------------------------------
char printMenuAndSelectItem()
{
    Console.WriteLine();
    Console.WriteLine("=======================================================================================================================");
    Console.WriteLine("Программа из заданного массива строк формирует новый массив из строк, длина которых меньше или равно 3 (трем) символам.");
    Console.WriteLine("=======================================================================================================================");
    Console.WriteLine();
    Console.WriteLine("===================== ОСНОВНОЕ МЕНЮ ====================");
    Console.WriteLine("[1] - Задать исходный массив с клавиатуры.");
    Console.WriteLine("[2] - Использовать заданный в программе исходный массив.");
    Console.WriteLine("--------------------------------------------------------");
    Console.WriteLine("[0] - Выход из программы.");
    Console.WriteLine("========================================================");
    while (true)
    {
        Console.Write("Выберите пункт меню: ");
        var key = Console.ReadKey();
        if (key.KeyChar == '1' || key.KeyChar == '2' || key.KeyChar == '0')
        {
            Console.WriteLine();
            Console.WriteLine();
            return key.KeyChar;
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Некорректный выбор.");
        }
    }
}

// Исходный массив строк. Массив задан жетско на старте выполнения программы.
string[] sourceStringArray = { "Hello", "2", "world", ":-)", "1234", "1567", "-2", "computer science", "Russia", "Denmark", "Kazan" };


// ----------------------------------------------------------------------------------
// Метод вывода на экран исходного и результирующего массивов.
// ----------------------------------------------------------------------------------
void basicApplicationCode()
{
    Console.WriteLine("Исходный массив из строк:");
    Console.WriteLine();
    PrintArray(sourceStringArray, true);
    Console.WriteLine();
    Console.WriteLine();

    Console.WriteLine("Новый массив, полученный из исходного, согласно условию задачи:");
    Console.WriteLine();
    string[] destinationStringArray = CreateNewArray(sourceStringArray);
    PrintArray(destinationStringArray, false);
    Console.WriteLine();
}

// ----------------------------------------------------------------------------------
// Основной код (Main).
// ----------------------------------------------------------------------------------
switch (printMenuAndSelectItem())
{
    case '1':
        // Исходный массив задается пользователем путем ввода значений с клавиатуры.
        // Ввод завершается при введении пользователем ДВА РАЗА ПОДРЯД пустых значений (null).
        Console.WriteLine("Задайте исходный массив. Подверждайте ввод каждого элемента нажатием клавиши <Enter>.");
        Console.WriteLine("Для завершения ввода нажмите клавишу <Enter> два раза.");
        Array.Resize(ref sourceStringArray, 0);
        Array.Clear(sourceStringArray);
        bool firstEnter = false;
        bool secondEnter = false;
        string userInputString;
        while (firstEnter == false || secondEnter == false)
        {
            userInputString = Console.ReadLine();
            if (userInputString == "" && firstEnter == false)
            {
                firstEnter = true;
                continue;
            } 
            else if (userInputString == "" && firstEnter)
            {
                secondEnter = true;
                continue;
            } 
            else
            {
                Array.Resize(ref sourceStringArray, sourceStringArray.Length + 1);
                sourceStringArray[sourceStringArray.Length - 1] = userInputString;
                firstEnter = false;
                secondEnter = false;
            }            
        }
        basicApplicationCode();
        break;
    case '2':
        // Используем массив строк, заданный жестко в программе.
        basicApplicationCode();
        break;
    case '0':
        break;
}

