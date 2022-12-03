using System.Reflection;

var filePath = Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location);
var lines = File.ReadAllLines($@"{filePath!}\1.txt").ToArray();

Console.WriteLine(GetFirstPartResult(lines));
Console.WriteLine(GetSecondPartResult(lines));

static int GetFirstPartResult(IEnumerable<string> strings)
{
    var sum = (from line in strings
        let firstPart = line[..(line.Length / 2)]
        let secondPart = line[(line.Length / 2)..]
        select secondPart.First(firstPart.Contains)
        into value
        select char.IsUpper(value) ? value - 'A' + 27 : value - 'a' + 1).Sum();

    return sum;
}

static int GetSecondPartResult(IReadOnlyList<string> strings)
{
    var sum = 0;

    for (var i = 0; i < strings.Count; i += 3)
    {
        var line1 = strings[i];
        var line2 = strings[i + 1];
        var line3 = strings[i + 2];
        var value = line1.First(x => line2.Contains(x) && line3.Contains(x));

        sum += char.IsUpper(value) ? value - 'A' + 27 : value - 'a' + 1;
    }

    return sum;
}