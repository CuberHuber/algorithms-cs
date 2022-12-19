﻿Algorithms C#
=============


Overview
--------

This project is designed to learning **computer science** by [a roadmap](https://roadmap.sh/computer-science).


Use
---

For start sorting file create `MultiwaySort()` with 2 parameters such `number of ways` and (`filename` or path file).
Then call `Start()` method.

After sorting is completed, a new file will be created with the same name and postscript `-sorted`.


Example use
-----------
```csharp
using algorithms_cs.Algorithm.Sort.External.Merge;

const int numberWays = 4;
const string pathFile = @"someDirectory\\resource\\1.test";

var sort = new MultiwaySort(NumberWays, PathFile);
sort.Start();
```

```
/1.test            12 4 1 2 -6 12 645 12 54 -2,0001
/1.test-sorted     -6 -2,0001 1 2 4 12 12 12 54 645 
```


External Multiway Merge Sort
----------------------------


_**Внешняя многопутевая естественная сортировка**_ отличается от _**обычной внешней сортировки**_ концепцией серий чисел.
**_Серия_** - это последовательность чисел, каждый следующий элемент которой больше предыдущего.

Tape - последовательность чисел, описывает файл с числами.
Количество Series в Tape не ограниченно. Первая серия предшествует второй, и т.д.

```
TAPE <= FILE    12 4 1 2 -6 12 645 12 54 -2,0001
```

| _index_    | 0      | 1    | 2      | 3             | 4        | 5         |
|------------|--------|------|--------|---------------|----------|-----------|
| **Series** | `12`   | `4`  | `1, 2` | `-6, 12, 645` | `12, 54` | `-2.0001` |

 
Еще одно отличие **_ВМЕС_** от **_ОВС_** - это потоки или пути (от этого и слово многопутевая в названии).

Например, при `N = 3`, создаются 6 (3 + 3) файлов, 2 набора для записи и для чтения.

| Read     | Write    |
|----------|----------|
| `Tape 1` | `Tape 4` |
| `Tape 2` | `Tape 5` |
| `Tape 3` | `Tape 6` |

Алгоритм состоит из:

1. **Инициализации**. Подготовка к основному раунду алгоритма
2. **Тело**. Циклическое повторение основного раунда.

**Основной раунд** - слияние N Серий из каждой Полосы в Полосы другой группы.

Задачу слияния N серий берет на себя Коллектор. Он создает новую серию, которая записывается в Tape
```
        _____
             \
Series 1      \
               \
Series 2            new Series
               /
Series 3      /
        _____/
     
```

1.
| slot  | Series   |
|-------|----------|
| [ _ ] | `12`     |
| [ _ ] | `4`      |
| [ _ ] | `1`, `2` |

2.
| slot   | Series     |
|--------|------------|
| [ 12 ] | ~~12~~     |
| [ 4 ]  | ~~4~~      |
| [ 1 ]  | ~~1~~, `2` |

return `1`

3.

| slot   | Series       |
|--------|--------------|
| [ 12 ] | ~~12~~       |
| [ 4 ]  | ~~4~~        |
| [ 2 ]  | ~~1~~, ~~2~~ |

return `2`

4.

| slot   | Series       |
|--------|--------------|
| [ 12 ] | ~~12~~       |
| [ 4 ]  | ~~4~~        |
| [ _ ]  | ~~1~~, ~~2~~ |

return `4`

5.

| slot   | Series       |
|--------|--------------|
| [ 12 ] | ~~12~~       |
| [ _ ]  | ~~4~~        |
| [ _ ]  | ~~1~~, ~~2~~ |

return `12`

6.

| slot  | Series       |
|-------|--------------|
| [ _ ] | ~~12~~       |
| [ _ ] | ~~4~~        |
| [ _ ] | ~~1~~, ~~2~~ |

Серии закончились. Коллектор осталовился.

_____

### Example

| _index_    | 0      | 1    | 2      | 3             | 4        | 5         |
|------------|--------|------|--------|---------------|----------|-----------|
| **Series** | `12`   | `4`  | `1, 2` | `-6, 12, 645` | `12, 54` | `-2.0001` |

1. Инициализация

| Write                | Read   |
|---------------------|--------|
| `12`, `-6, 12, 645` | `____` |
| `4`, `12, 54`       | `____` |
| `1, 2`, `-2.0001`   | `____` |

2. Тело

2.1.

| Read                  | Write         |
|-----------------------|---------------|
| ~~12~~, `-6, 12, 645` | `1, 2, 4, 12` |
| ~~4~~, `12, 54`           | `____`        |
| ~~1, 2~~, `-2.0001`       | `____`        |

| Read                    | Write                          |
|-------------------------|--------------------------------|
| ~~12~~, ~~-6, 12, 645~~ | `1, 2, 4, 12`                  |
| ~~4~~, ~~12, 54~~       | `-6, -2.0001, 12, 12, 54, 645` |
| ~~1, 2~~, ~~-2.0001~~   | `____`                         |

2.2.

| Write                               | Read                             |
|------------------------------------|----------------------------------|
| `-6 -2,0001 1 2 4 12 12 12 54 645` | ~~1, 2, 4, 12~~                  |
| `____`                             | ~~-6, -2.0001, 12, 12, 54, 645~~ |
| `____`                             | `____`                           |


Алгоритм завершаетс, в результате получась полоска с одной серией

-----

<p>Copyright (C) 2022 The EMMS Project</p>
