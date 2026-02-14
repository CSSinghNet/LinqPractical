# LINQ Operators -- What They Return (C#)

This guide explains what each LINQ method returns and its type, based on
the code snippet used in the project.

---------------------------------------------------------------------
## LINQ: Method Syntax vs Query Syntax — When to Use & Why

LINQ can be written in two styles:

* **Method Syntax** → Uses extension methods (`Where()`, `Select()`, etc.)
* **Query Syntax** → SQL-like syntax (`from`, `where`, `select`, etc.)

---

### 🔹 Method Syntax

**Example**

```csharp
var result = employees
    .Where(e => e.Salary > 50000)
    .Select(e => e.Name)
    .ToList();
```

**When to use**

* Preferred in modern C# development
* Works with **all LINQ operations**
* Required for:

  * `GroupBy`
  * `Join` (complex joins)
  * `SelectMany`
  * Aggregations (`Sum`, `Count`, etc.)
* Better for **method chaining**
* More common in production code

**Why use**

* More flexible
* More powerful
* Industry standard
* Supports IntelliSense better
* Easier to compose reusable queries

---

### 🔹 Query Syntax

**Example**

```csharp
var result = from e in employees
             where e.Salary > 50000
             select e.Name;
```

**When to use**

* When query feels like **SQL**
* Good for:

  * Simple filtering
  * Readability for beginners
  * Multiple conditions
* Mostly used in:

  * LINQ to SQL
  * Entity Framework (basic queries)

**Why use**

* Clean and readable
* Familiar for SQL developers
* Easy to understand logical flow

---

### 🔹 Key Difference

| Feature            | Method Syntax     | Query Syntax                 |
| ------------------ | ----------------- | ---------------------------- |
| Style              | Extension methods | SQL-like                     |
| Flexibility        | ⭐⭐⭐⭐              | ⭐⭐                           |
| Readability        | Good              | Very good for simple queries |
| Complex operations | Best choice       | Limited                      |
| Industry usage     | Most used         | Less used                    |

---

### 🔹 Real-World Rule

👉 Use **Method Syntax** by default
👉 Use **Query Syntax** when:

* Query is simple
* SQL-style readability helps
* Teaching/learning LINQ basics

---

### 🔹 Important Note

Query syntax internally converts to method syntax at compile time.

So ultimately:

> **Method syntax is the core LINQ implementation.**



----------------------------------------------------------------------
## LINQ – Quick Reference (5 Categories)

To easily remember LINQ methods, group them into these 5 categories:

### 1️⃣ Filtering

Used to filter data from collections.

* `Where()`
* `Skip()`
* `Take()`

### 2️⃣ Projection

Used to transform data into a new shape.

* `Select()`
* `SelectMany()`

### 3️⃣ Aggregation

Used to perform calculations on data.

* `Sum()`
* `Count()`
* `Max()`

### 4️⃣ Conversion

Used to convert one collection type into another.

* `ToList()`
* `ToDictionary()`

### 5️⃣ Set / Join Operations

Used to combine or relate multiple collections.

* `Union()`
* `Join()`
* `GroupBy()`

> Tip: Remember LINQ as **FPACS**
> **F**iltering → **P**rojection → **A**ggregation → **C**onversion → **S**et/Join


------------------------------------------------------------------------

## Filtering

### Where

Returns: `IEnumerable<int>` -- filtered collection

### OfType

Returns: `IEnumerable<int>` -- items of a specific type

### Skip / Take

Returns: `IEnumerable<int>` -- subset of collection

### SkipLast / TakeLast

Returns: `IEnumerable<int>` -- subset from end

### SkipWhile / TakeWhile

Returns: `IEnumerable<int>` -- conditional subset

------------------------------------------------------------------------

## Projection

### Select

Returns: `IEnumerable<string>`

### Select with index

Returns: `IEnumerable<int>`

### SelectMany

Returns: `IEnumerable<char>` (flattened collection)

------------------------------------------------------------------------

## Conversion

### Cast

Returns: `IEnumerable<int>`

### Chunk

Returns: `IEnumerable<int[]>`

------------------------------------------------------------------------

## Quantifiers

### Any

Returns: `bool`

### All

Returns: `bool`

### Contains

Returns: `bool`

------------------------------------------------------------------------

## Collection Modifiers

### Append / Prepend

Returns: `IEnumerable<int>`

------------------------------------------------------------------------

## Aggregates

### Count

Returns: `int`

### Sum

Returns: `int`

### Average

Returns: `double`

### Max / Min

Returns: `int`

### MaxBy / MinBy

Returns: `Employee` object

### Aggregate

Returns: single value (based on logic)

------------------------------------------------------------------------

## Element Operators

### First / Last

Returns: element (`int`)

### Single

Returns: element (`int`)

### ElementAt

Returns: element (`int`)

### DefaultIfEmpty

Returns: `IEnumerable<int>`

------------------------------------------------------------------------

## Conversions

### ToArray

Returns: `int[]`

### ToList

Returns: `List<int>`

### ToDictionary

Returns: `Dictionary<TKey, TValue>`

### ToHashSet

Returns: `HashSet<Employee>`

### ToLookup

Returns: `ILookup<TKey, TValue>`

------------------------------------------------------------------------

## Enumerable Helpers

### Range

Returns: `IEnumerable<int>`

### Repeat

Returns: `IEnumerable<string>`

### Empty

Returns: empty `IEnumerable<int>`

------------------------------------------------------------------------

## Distinct

### Distinct

Returns: `IEnumerable<int>`

### DistinctBy

Returns: `IEnumerable<Employee>`

------------------------------------------------------------------------

## Set Operations

### Union

Returns: `IEnumerable<int>`

### Intersect

Returns: `IEnumerable<int>`

### Except

Returns: `IEnumerable<int>`

------------------------------------------------------------------------

## Comparison

### SequenceEqual

Returns: `bool`

------------------------------------------------------------------------

## Zip

Returns: `IEnumerable<string>`

------------------------------------------------------------------------

## Join

Returns: `IEnumerable<string>` (or anonymous object)

------------------------------------------------------------------------

## GroupJoin

Returns: `IEnumerable<anonymous>` containing grouped employees

------------------------------------------------------------------------

## Concat

Returns: `IEnumerable<int>`

------------------------------------------------------------------------

## GroupBy

Returns: `IEnumerable<IGrouping<TKey, Employee>>`

------------------------------------------------------------------------

## Ordering

### Order / OrderBy

Returns: `IOrderedEnumerable<T>`

### OrderByDescending

Returns: `IOrderedEnumerable<T>`

### ThenBy

Returns: `IOrderedEnumerable<T>`

------------------------------------------------------------------------

## Reverse

Returns: `IEnumerable<int>`

------------------------------------------------------------------------

## PLINQ

### AsParallel().Where().ToList()

Returns: `List<int>` (processed in parallel)

------------------------------------------------------------------------

## Notes

-   Most LINQ methods return `IEnumerable<T>`.
-   Execution is deferred until iteration (`foreach`, `ToList`, etc.).
-   Aggregation operators return a single value.
-   Conversion operators materialize data immediately.


