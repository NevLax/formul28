PrintYellow("Программа для анализа функции!\n\n" +
    " /   y = 3 * (1 + x^2)^(1/2), где x < 0\n" +
    "<    y = sin(2x) * 3e^(-x), где х принадлежит отерзку [0, 1]\n" +
    " \\   y = sin(x) * cos(x) , где х > 1\n");

while (true)        // безконченый цикл  - что  бы не перезапускать  программу каждый раз 
{
    MyProgramm();   // сам алгоритм 
}
void MyProgramm()
{
    PrintGreen("Введите x минимальный");    // все диалги будем делать зелеными - чтоб красиво

    double xMin = GetDouble();              // получит  число - сложная  задача - вынесем  в  отдельный  метод 

    PrintGreen("Введите x максимальный");

    double xMax = GetDouble();

    PrintGreen("Введите шаг функции");

    double xStep = GetDouble();

    Myfunc(xMin, xMax, xStep); // когда  у  нас  есть  все данные  дадим их отдельному методу 
}

void Myfunc(double min, double max, double step)
{
    if (ValidVar(min, max, step))
    { FuncPrint(min, max, step); }
}

void FuncPrint(double min, double max, double step)
{
    PrintYellow("_____Ответ____");
    /// переберем функцию 
    for (double x = min; x <= max; x += step)
    {
        double y = GetYByX(x);
        PrintYellow($"x={x}: y={y}"); // Ответ 
    }
    PrintYellow($"Пересечение функции с осью X В точке: {GetValueBetweenZeroAndOne(0)}");
}

double GetYByX(double x)
{
    if (x > 1) { return GetValueLessZero(x); }
    else if (x < 0) { return GetValueGreaterOne(x); }
    else { return GetValueBetweenZeroAndOne(x); }
}

double GetValueLessZero(double x)
{
    return 3 * Math.Sqrt(1 + Math.Pow(x, 2));
}

double GetValueGreaterOne(double x)
{
    return Math.Cos(x)*Math.Sin(x);
}

double GetValueBetweenZeroAndOne(double x)
{
    return Math.Sin(2*x) * 3 * Math.Exp(-x);
}

bool ValidVar(double min, double max, double step)
{
    if (min > max)
    {
        PrintRed("x минимальная больше чем x максимальная");
        return false; // выход из функции  дострочно
    }

    if (step == 0)
    {
        PrintRed("Шаг равен нулю");
        return false;
    }

    if (step < 0)
    {
        PrintRed("Шаг меньше нуля");
        return false;
    }

    return true;
}
void PrintGreen(string message)
{
    ConsoleColor color = Console.ForegroundColor;   // запомнит текущий цвет
    Console.ForegroundColor = ConsoleColor.Green;   // поменяем  на  зеленый цвет
    Console.WriteLine(message);                     // выведем  сообщение 
    Console.ForegroundColor = color;                // вернем  базовый цвет
}

void PrintYellow(string message)
{
    ConsoleColor color = Console.ForegroundColor;   // запомнит текущий цвет
    Console.ForegroundColor = ConsoleColor.Yellow;  // поменяем  на  зеленый цвет
    Console.WriteLine(message);                     // выведем  сообщение 
    Console.ForegroundColor = color;                // вернем  базовый цвет
}


void PrintRed(string message)
{
    ConsoleColor color = Console.ForegroundColor;   // запомнит текущий цвет
    Console.ForegroundColor = ConsoleColor.Red;     // поменяем  на  зеленый цвет
    Console.WriteLine(message);                     // выведем  сообщение 
    Console.ForegroundColor = color;                // вернем  базовый цвет
}

double GetDouble()
{
    try
    {
        string temp = Console.ReadLine();
        return Convert.ToDouble(temp);
    }
    catch
    {
        PrintRed("Не верный ввод, введите число");
        return GetDouble();
    }
}