// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;
using System.Text;


Game g = new Game();

Console.WriteLine(GetPrintableState());

while (g.GetWinner() == Winner.GameIsUnfinished)
{
    int index = int.Parse(Console.ReadLine());
    g.MakeMove(index);

    Console.Clear();
    Console.WriteLine(GetPrintableState());
}

var winner = g.GetWinner();
if (winner.Equals(Winner.Draw))
    Console.WriteLine("Result: Draw");
else
    Console.WriteLine($"Result: {winner} wins!");

Console.ReadLine();


string GetPrintableState()
{
    var sb = new StringBuilder();

    for (int i = 1; i <= 7; i += 3)
    {
        sb.AppendLine("   |   |   ");
        sb.AppendLine($" {GetPrintableChar(i)} | {GetPrintableChar(i + 1)} | {GetPrintableChar(i + 2)} ");
        sb.AppendLine("___|___|___");
    }
    return sb.ToString();
}

string GetPrintableChar(int i)
{
    State state = g.GetState(i);

    if (state == State.Unset) return i.ToString();

    return state == State.Cross ? "X" : "O";

}