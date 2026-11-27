using System;
class Program
{
    static double Calculator(double alpha)
    {
        double sinF, tanF, sqrtOfA, result;
        const double Pi = Math.PI, E = Math.E;
        alpha *= 180 / Pi;
        sinF = Math.Sin(alpha);
        tanF = Math.Tan(2 * alpha);
        sqrtOfA = Math.Sqrt(Math.Log(Math.Pow(E, 2), 3));
        result = Math.Round(((sinF + tanF) / sqrtOfA), 2);
        return result;
    }
    static void Introduce()
    {
        Console.WriteLine("Акуличев Алексей 6101-09.03.01");
    }
    static string GiveMeText()
    {
        string exitConfirm = Console.ReadLine();
        while (exitConfirm != "н" && exitConfirm != "д")
        {
            Console.WriteLine($"Это не д(да) или н(нет), введи заново: ");
            exitConfirm = Console.ReadLine();
        }
        return exitConfirm;
    }
    static double GiveMeDouble()
    {
        double usersInput;
        while (!double.TryParse(Console.ReadLine(), out usersInput)) Console.Write("Неверный тип данных, введите заново: ");
        return usersInput;
    }
    static int GiveMeArrayLength()
    {
        Console.Write("Введите длину массива, который будет отсортирован: ");
        int usersInput = GiveMeInt();
        while (usersInput < 0)
        { 
            Console.Write("Длина массива не может быть отрицательной или равной нулю! Введи заново: ");
            usersInput = GiveMeInt();
        }
        return usersInput;
    }
    static int GiveMeInt()
    {
        int usersInput;
        while (!int.TryParse(Console.ReadLine(), out usersInput)) Console.Write("Неверный тип данных, введите заново: ");
        return usersInput;
    }
    static void SawGame(double result)
    {
        const int MaxTries = 2;
        int guessCount = 0;
        int countOfTries;
        bool resultCheck = false;
        double userGuess;
        do
        {
            userGuess = GiveMeDouble();
            string ending = "";
            string endingOfEnd = "";
            countOfTries = MaxTries - guessCount;
            if (userGuess == result) resultCheck = true;
            else
            {
                Console.WriteLine("Не правильно!");
                if (countOfTries > 1)
                {
                    ending = "ось";
                    endingOfEnd = "ки";
                }
                else if (countOfTries == 1)
                {
                    ending = "ась";
                    endingOfEnd = "ка";
                }
                if (countOfTries > 0) Console.Write($"У тебя остал{ending} {countOfTries} попыт{endingOfEnd}, попробуй заново: ");
            }
            guessCount++;
        }
        while (guessCount < 3 && !resultCheck && countOfTries > 0);
        if (resultCheck) Console.WriteLine("Вы победили!");
        else Console.WriteLine("Вы проиграли!");
        Console.WriteLine("Результатом вычислений становится число " + result);
        guessCount = 0;
    }
    static int[] ArraySummoning()
    {
        int length = GiveMeArrayLength();
        int[] arr = new int[length];
        for (int i = 0; i < length; i++)
        {
            Random rnd = new Random();
            arr[i] = rnd.Next(100);
        };
        return arr;
    }
    static int[] ArrayCopycat(int[] arr)
    {
        int length = arr.Length;
        int[] arrCopycat = new int[length];
        for (int i = 0; i < length; i++) arrCopycat[i] = arr[i];
        return arrCopycat;
    }
    static void ShowMeYourArray(int[] arr)
    {
        int length = arr.Length;
        for (int i = 0; i < length; i++)
        {
            Console.Write($"{arr[i]} ");
        }
        Console.WriteLine("");
    }
    static bool DoYouWantToExit()
    {
        string userInput = GiveMeText();
        if (userInput == "д") return false;
        else return true;
    }
    static int BubbleSort(int[] arr)
    {
        int servSpace, count = 0;
        int length = arr.Length;
        for (int i = 0; i < length - 1; i++)
        {
            for (int j = 0; j < length - 1; j++)
            {
                if (arr[j] >= arr[j + 1])
                {
                    servSpace = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = servSpace;
                    count += 3;
                }
                count++;
            }
        }
        return count;
    }
    static int InsertionSort(int[] arr)
    {
        int length = arr.Length, count = 0;
        for (int i = 1; i < length; i++)
        {
            if (arr[i] < arr[i - 1])
            {
                int j = i;
                int savedElem = arr[j];
                while (j > 0 && savedElem < arr[j - 1])
                {
                    arr[j] = arr[j - 1];
                    j--;
                    count += 1;
                }
                arr[j] = savedElem;
            }
        }
        return count;
    }
    static void MenuText()

    {
        Console.WriteLine("1. Игра 'Угадай ответ'");
        Console.WriteLine("2. ФИО Автора");
        Console.WriteLine("3. Сортировка массива");
        Console.WriteLine("4. Выход из системы");
    }
    static void Main(string[] args)
    {
        //Лаба 3 по основам по программированию
        int userAnsw;
        bool flag = true;
        while (flag)
        {
            MenuText();
            Console.Write("Выберите одно из действий: ");
            while (!int.TryParse(Console.ReadLine(), out userAnsw) && !(0 < userAnsw && userAnsw < 5)) Console.WriteLine("Ввод не равен 1, 2, 3 или 4. Попробуйте еще раз");
            switch (userAnsw)
            {
                case (1):                                                   //Кейс 1
                    {
                        double userInput;
                        Console.Write("Введите значение переменной а в формуле в виде целого числа: ");
                        userInput = GiveMeDouble();
                        Console.Write("Попробуй угадать ответ! У тебя 3 попытки! Введи свой ответ: ");
                        double results = Calculator(userInput);
                        SawGame(results);
                        break;
                    }
                case (2):                                                   //Кейс 2
                    Introduce();
                    continue;
                case (3):                                                   //Кейс 3
                    int counterOfBubble, counterOfInsert;
                    int[] arr = ArraySummoning(), arrCopy = ArrayCopycat(arr);
                    if (arr.Length == 1)
                    {
                        Console.WriteLine("Массив состоит из одного элемента, что ты в нем сортировать-то будешь?");
                        ShowMeYourArray(arr);
                    }
                    else if (arr.Length > 9)
                    {
                        counterOfBubble = BubbleSort(arr);
                        counterOfInsert = InsertionSort(arrCopy);
                        Console.WriteLine($"Количесво опреаций в сортировке пузырьком равно {counterOfBubble}, а в сортировке вставками - {counterOfInsert}.");
                        if (counterOfBubble > counterOfInsert) Console.WriteLine("Сортировка вставками эффективнее сортировки пузырьком в данном случае.");
                        else if (counterOfBubble < counterOfInsert) Console.WriteLine("Сортировка пузырьком эффективнее сортировки вставками в данном случае.");
                        if (counterOfBubble == counterOfInsert) Console.WriteLine("Сортировка слиянием унижает сортировки пузырьком и вставками одинаково сильно в данном случае.");
                        Console.WriteLine("Массив длиннее, чем 10 элементов, невозможно вывести на экран.");
                    }
                    else
                    {
                        Console.Write("Изначальный массив: ");
                        ShowMeYourArray(arr);
                        counterOfBubble = BubbleSort(arr);
                        counterOfInsert = InsertionSort(arrCopy);
                        Console.Write("После сортировки пузырьком: ");
                        ShowMeYourArray(arr);
                        Console.Write("После сортировки вставками: ");
                        ShowMeYourArray(arrCopy);
                        Console.WriteLine($"Количесво опреаций в сортировке пузырьком равно {counterOfBubble}, а в сортировке вставками - {counterOfInsert}.");
                        if (counterOfBubble > counterOfInsert) Console.WriteLine("Сортировка вставками эффективнее сортировки пузырьком в данном случае.");
                        else if (counterOfBubble < counterOfInsert) Console.WriteLine("Сортировка пузырьком эффективнее сортировки вставками в данном случае.");
                        if (counterOfBubble == counterOfInsert) Console.WriteLine("Сортировка слиянием унижает сортировки пузырьком и вставками одинаково сильно в данном случае.");
                    }
                    break;
                case (4):                                                   //Кейс 4
                    Console.Write("Вы уверены, что хотите выйти из программы?(д/н)  ");
                    flag = DoYouWantToExit();
                    break;
                default:
                    {
                        Console.WriteLine("Ввод не равен 1, 2, 3 или 4.");
                        break;
                    }
            }
        }
    }
}