Algorithms C#
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

EMMS Core contains a Tape and Series classes:

- 

-----

<p>Copyright (C) 2022 The EMMS Project</p>
