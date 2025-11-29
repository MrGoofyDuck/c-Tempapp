using System;
using System.Globalization;
using System.IO;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Температура за неделю");
        Console.WriteLine("Введите 7 значений в градусах Цельсиях.\n");

        double[] temps = new double[7];

        // ввод
        for (int i = 0; i < temps.Length; i++)
        {
            temps[i] = ReadTemp($"День {i + 1}: ");
        }

        // аналитика
        double sum = 0;
        double tMin = temps[0];
        double tMax = temps[0];
        int dayMin = 0;
        int dayMax = 0;

        for (int i = 0; i < temps.Length; i++)
        {
            double t = temps[i];
            sum += t;

            if (t < tMin)
            {
                tMin = t;
                dayMin = i;
            }

            if (t > tMax)
            {
                tMax = t;
                dayMax = i;
            }
        }

        double avg = sum / temps.Length;

        // простой тренд: сравниваем начало и конец
        double diff = temps[temps.Length - 1] - temps[0];
        string trendText;
        if (diff > 0.5)
            trendText = "потеплело";
        else if (diff < -0.5)
            trendText = "похолодало";
        else
            trendText = "без изменений";

        // вывод
        Console.WriteLine("\nИтоги:");
        Console.WriteLine($"Средняя температура: {avg:F2} °C");
        Console.WriteLine($"Минимум: {tMin:F2} °C (день {dayMin + 1})");
        Console.WriteLine($"Максимум: {tMax:F2} °C (день {dayMax + 1})");
        Console.WriteLine($"Тренд: {trendText} (разница между 1 и 7 днём: {diff:F2} °C)");

        // сохранение
        string csvName = "week_temps.csv";
        string txtName = "week_summary.txt";

        SaveCsv(temps, csvName);
        SaveSummary(avg, tMin, dayMin, tMax, dayMax, diff, trendText, txtName);

        Console.WriteLine("\nДанные сохранены в файлы:");
        Console.WriteLine(Path.GetFullPath(csvName));
        Console.WriteLine(Path.GetFullPath(txtName));
    }

    static double ReadTemp(string msg)
    {
        while (true)
        {
            Console.Write(msg);
            string? s = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(s))
                continue;

            s = s.Replace(',', '.');

            if (double.TryParse(s, NumberStyles.Float,
                                CultureInfo.InvariantCulture, out double value))
                return value;

            Console.WriteLine("Нужно ввести число, попробуйте ещё раз.");
        }
    }

    static void SaveCsv(double[] temps, string fileName)
    {
        using (var sw = new StreamWriter(fileName))
        {
            sw.WriteLine("day,temperature");
            for (int i = 0; i < temps.Length; i++)
            {
                sw.WriteLine($"{i + 1},{temps[i].ToString(CultureInfo.InvariantCulture)}");
            }
        }
    }

    static void SaveSummary(double avg, double tMin, int dayMin,
                            double tMax, int dayMax,
                            double diff, string trendText,
                            string fileName)
    {
        using (var sw = new StreamWriter(fileName))
        {
            sw.WriteLine("Weekly temperature summary");
            sw.WriteLine("-------------------------");
            sw.WriteLine($"Average: {avg:F2} °C");
            sw.WriteLine($"Min: {tMin:F2} °C (day {dayMin + 1})");
            sw.WriteLine($"Max: {tMax:F2} °C (day {dayMax + 1})");
            sw.WriteLine($"Trend: {trendText}, diff = {diff:F2} °C");
        }
    }

    static void SaveTempListTxt(double[] temps, string fileName)
    {
    using (var sw = new StreamWriter(fileName))
        {
        sw.WriteLine("Температуры за неделю:");
        sw.WriteLine("----------------------");
        for (int i = 0; i < temps.Length; i++)
            {
            sw.WriteLine($"День {i + 1}: {temps[i]} °C");
            }
        }
    }

}
