
# Temperature Statistics – Weekly Analyzer

A C# program that allows you to input temperatures for 7 days, calculates weekly statistics, and saves the results into CSV and text files.

## Features

Input of 7 daily temperatures

Calculation of:

average temperature

minimum and maximum

the day of the minimum and maximum

weather trend (warming / cooling / stable)

Display of statistics in the console

Saving data to:

week_temps_*.csv

week_summary_*.txt

## Example

=== Temperature Statistics (1 week) ===

Введите 7 ежедневных температур в °C.

День 1 (°C): 15

День 2 (°C): 14

...

День 7 (°C): 17

--- Итоги недели ---

Средняя: 15.42 °C

Мин.:    13.00 °C (день 3)

Макс.:   18.00 °C (день 5)

Тренд:   потепление (наклон +0.073 °C/день)

Файлы сохранены:
- CSV: /home/user/project/week_temps_20250117_195845.csv
- TXT: /home/user/project/week_summary_20250117_195845.txt
