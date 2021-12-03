using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2021.Days
{
    internal static class Day2
    {
        public static int Question1()
        {
            var allLines = File.ReadAllLines("inputs/day2.txt").Select(x => x);
            var submarineCommands = allLines.Select(x=> new SubmarineCommand(x));
            return submarineCommands.Where(x => x.SubmarineCommandType == SubmarineCommandType.Horizontal).Sum(x => x.Value) * submarineCommands.Where(x => x.SubmarineCommandType == SubmarineCommandType.Depth).Sum(x => x.Value);
        }
    }

    class Submarine
    {
        int _aim;
        readonly SubmarineCommand[] _submarineCommands;
        public Submarine()
        {
            var allLines = File.ReadAllLines("inputs/day2.txt").Select(x => x);
            _submarineCommands = allLines.Select(x => new SubmarineCommand(x)).ToArray();
        }
    }

    readonly struct SubmarineCommand
    {
        readonly string _command;
        public SubmarineCommand(string command)
        {
            _command = command;
        }

        public int Value => int.Parse($"{Subtract}{string.Join(string.Empty, _command.Where(Char.IsDigit))}");

        public SubmarineCommandType SubmarineCommandType => _command.Contains("forward") ? SubmarineCommandType.Horizontal : SubmarineCommandType.Depth;
        public string Subtract => _command.Contains("up") ? "-" : "";

    }

     
    enum SubmarineCommandType
    {
        Depth, Horizontal
    }
}
