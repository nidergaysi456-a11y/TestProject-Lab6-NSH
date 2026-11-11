using System;

public class MathFunctions
{
    public double InchesToCentimeters(double inches)
    {
        if (inches < 0)
            throw new ArgumentException("Дюймы не могут быть отрицательными");
        return inches * 2.54;
    }

    public bool IsEven(int n)
    {
        return n % 2 == 0;
    }

    public int Max(int[] array)
    {
        if (array == null)
            throw new ArgumentException("Массив не может быть null");
        if (array.Length == 0)
            throw new ArgumentException("Массив не может быть пустым");

        int max = array[0];
        foreach (int x in array)
            if (x > max) max = x;
        return max;
    }

    public int Mod(int a, int b)
    {
        if (b <= 0)
            throw new ArgumentException("Делитель должен быть положительным числом");
        return a % b;
    }
}