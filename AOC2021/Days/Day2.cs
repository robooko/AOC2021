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
            return new Submarine().Calc();
        }

        public static int Question2()
        {
            return new Submarine().Aim();
        }
    }

    class Submarine
    {
        int _aim = 0;
        int _horizontal = 0;
        int _depth = 0;
        readonly SubmarineCommand[] _submarineCommands;
        public Submarine()
        {
            var allLines = File.ReadAllLines("inputs/day2.txt").Select(x => x);
            _submarineCommands = allLines.Select(x => new SubmarineCommand(x)).ToArray();
        }

        public int Aim()
        {
            _submarineCommands.ToList().ForEach(x =>
            {
                if (x.SubmarineCommandType == SubmarineCommandType.Horizontal)
                {
                    _horizontal += x.Value;
                    _depth += x.Value * _aim;
                }
                else
                {
                    _aim += x.Value;
                }
            });
            return _horizontal * _depth;
        }

        public int Calc()
        {
            return _submarineCommands.Where(x => x.SubmarineCommandType == SubmarineCommandType.Horizontal).Sum(x => x.Value) * _submarineCommands.Where(x => x.SubmarineCommandType == SubmarineCommandType.Depth).Sum(x => x.Value);
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
