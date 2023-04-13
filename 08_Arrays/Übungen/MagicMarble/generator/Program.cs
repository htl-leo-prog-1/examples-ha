using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

var length = int.Parse(args[0]);
if (length % 2 == 0) { throw new ArgumentException("Must be odd"); }

var result = new StringBuilder();

var floors = new List<Floor>();

bool down = true;
for (var i = 0; i < length; i++)
{
    if (result.Length > 0 && result[^1] == '>')
    {
        var isHex = Random.Shared.Next(0, 2) == 0;
        var f = new Floor() { ix = result.Length, visited = false, isHex = isHex };
        floors.Add(f);

        if (f.isHex) { result.Append("0x"); }
        result.Append("0000");
    }

    var sectionLength = Random.Shared.Next(2, 5);
    result.Append(new string(down ? '>' : '<', sectionLength));
    down = !down;
}

var from = floors[0];
for (var i = 0; floors.Count(f => !f.visited) > 1; i++)
{
    var unvisited = floors.Where(f => !f.visited && f != from).ToArray();
    var target = unvisited[Random.Shared.Next(0, unvisited.Length)];

    int nextIx;
    if (Random.Shared.Next(0, 2) == 0)
    {
        var left = FindLeftSection(target.ix - 1);
        nextIx = left.start + Random.Shared.Next(0, left.length);
    }
    else
    {
        var right = FindRightSection(target.ix + (target.isHex ? 6 : 4));
        nextIx = right.start + Random.Shared.Next(0, right.length);
    }

    result.Remove(from.ix, from.isHex ? 6 : 4);
    if (from.isHex) { result.Insert(from.ix, "0x"); }
    result.Insert(from.ix + (from.isHex ? 2 : 0), nextIx.ToString(from.isHex ? "x4": "0000"));
    from.visited = true;
    from = target;
}

var lastUnvisited = floors.Single(f => !f.visited);
var lastIx = (result.Length - 1);
result.Remove(lastUnvisited.ix, lastUnvisited.isHex ? 6 : 4);
if (lastUnvisited.isHex) { result.Insert(lastUnvisited.ix, "0x"); }
result.Insert(lastUnvisited.ix + (lastUnvisited.isHex ? 2 : 0), lastIx.ToString(lastUnvisited.isHex ? "x4": "0000"));

Console.WriteLine(result);
if (!IsValidMaze(result.ToString(), out var rolls, out var teleports)) { Console.WriteLine("INVALID"); }
Console.WriteLine($"Rolls: {rolls}, Teleports: {teleports}");

(int start, int length) FindLeftSection(int ix)
{
    int i;
    for (i = ix - 1; i >= 0 && result[i] == result[ix]; i--) ;
    return (i + 1, ix - i);
}

(int start, int length) FindRightSection(int ix)
{
    int i;
    for (i = ix + 1; i < result.Length && result[i] == result[ix]; i++) ;
    return (ix, i - ix);
}

bool IsValidMaze(string maze, out int rolls, out int teleports)
{
    rolls = teleports = 0;
    var ix = 0;
    while (ix < maze.Length)
    {
        if (maze[ix] == '>') { ix++; rolls++; continue; }
        else if (maze[ix] == '<') { ix--; rolls++; continue; }
        else
        {
            teleports++;
            for (; maze[ix] is not '>' and not '<'; ix--) ;
            ix++;
            var numBase = 10;
            if (maze[ix] == '0' && maze[ix + 1] == 'x') { numBase = 16; }
            var firstOther = maze[ix..].IndexOfAny(new[] { '>', '<' });
            ix = Convert.ToInt32(maze[ix..(ix + firstOther)], numBase);
            if (maze[ix] is not '>' and not '<') { return false; }
        }
    }

    return true;
}

class Floor { public int ix; public bool visited; public bool isHex; }

/*
>>0020<<>>>>0x0036<<>>>>0037<<>>>0x002a<<<>>>>0017<<<>>
*/
