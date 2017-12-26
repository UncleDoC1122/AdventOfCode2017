using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCodeDay25
{
    public class Utils
    {
        public static Tape ReadFile(string inputPath)
        {
            List<State> states = new List<State>();
            var input = File.ReadAllLines(inputPath);

            Regex stateDescription = new Regex("In state .:");
            Regex writeDescription = new Regex(@"\w*- Write the value .\w*");
            Regex moveDescription = new Regex(@"Move one slot to the \w*.");
            Regex continueDescription = new Regex(@"Continue with state \w.");
            Regex beginState = new Regex(@"Begin in state \w.");
            Regex stepsCount = new Regex(@"Perform a diagnostic checksum after \w* steps.");

            var stateArra = input.Where(a => stateDescription.IsMatch(a)).ToList();
            var write = input.Where(a => writeDescription.IsMatch(a)).ToList();
            var move = input.Where(a => moveDescription.IsMatch(a)).ToList();
            var continues = input.Where(a => continueDescription.IsMatch(a)).ToList();
            var begin = input.Where(a => beginState.IsMatch(a)).ToList().First().Split(' ').Last()[0];
            var steps = int.Parse(input.Where(a => stepsCount.IsMatch(a)).ToList().First().Split(' ')[5]);

            stateArra = stateArra.Select(a => a.Substring(a.Length - 2, 1)).ToList();
            write = write.Select(a => a.Substring(a.Length - 2, 1)).ToList();
            move = move.Select(a => a.Split().Last().Substring(0, 1)).ToList();
            continues = continues.Select(a => a.Split().Last().Substring(0, 1)).ToList();

            var iterator = 0;

            foreach(var name in stateArra)
            {
                states.Add(new State(name, write.Take(2).ToArray(), move.Take(2).ToArray()));
                write.RemoveRange(0, 2);
                move.RemoveRange(0, 2);
            }

            foreach(var state in states)
            {
                state.AddContinues(states.Where(a => continues.Take(2).Select(b => b[0]).Contains(a.Name)).ToArray());
                continues.RemoveRange(0, 2);
            }

            return new Tape(states, states.Where(a => a.Name == begin).First(), steps);

        }
    }

    class State
    {
        public char Name { get; set; }

        public StateAction ZeroAction { get; set; }

        public StateAction OneAction { get; set; }

        public State(string name, string[] write, string[] move)
        {
            Name = name[0];
            ZeroAction = new StateAction(int.Parse(write[0]), move[0]);
            OneAction = new StateAction(int.Parse(write[1]), move[1]);
        }

        public void AddContinues(State[] states)
        {
            ZeroAction.AddNextState(states[0]);
            OneAction.AddNextState(states[1]);
        }
    }

    enum Move
    {
        right,
        left
    }

    internal class StateAction
    {
        public int Write { get; set; }

        public Move Move { get; set; }

        public State NextState { get; set; }

        internal StateAction(int write, string move)
        {
            Write = write;

            if (move.Equals("r"))
                Move = Move.right;
            else
                Move = Move.left;

            NextState = null;
        }

        public void AddNextState(State state)
        {
            NextState = state;
        }
    }

    public class Tape
    {
        public List<int> TapeState { get; set; }

        int TapePointer { get; set; }

        State CurrentState { get; set; }

        State BeginState { get; set; }

        public int StepsCount { get; set; }

        internal int CurrentStep { get; set; } = 0;

        List<State> States { get; set; }

        internal Tape(List<State> states, State beginState, int count)
        {
            States = states;
            BeginState = beginState;
            StepsCount = count;

            CurrentState = BeginState;
            TapeState = new List<int>() { 0 };
            TapePointer = 0;
        }

        public bool Step()
        {
            if (CurrentStep >= StepsCount)
                return false;

            var CurrentValue = TapeState[TapePointer];

            if (CurrentValue == 1)
            {
                TapeState[TapePointer] = CurrentState.OneAction.Write;
                if (CurrentState.OneAction.Move == Move.left)
                {
                    TapeState.Insert(0, 0);
                }
                else
                {
                    if (TapeState.Count == (TapePointer + 1))
                        TapeState.Add(0);
                    TapePointer++;
                }

                CurrentState = CurrentState.OneAction.NextState;
            }
            else
            {
                TapeState[TapePointer] = CurrentState.ZeroAction.Write;
                if (CurrentState.ZeroAction.Move == Move.left)
                {
                    TapeState.Insert(0, 0);
                }
                else
                {
                    if (TapeState.Count == (TapePointer + 1))
                        TapeState.Add(0);
                    TapePointer++;
                }

                CurrentState = CurrentState.ZeroAction.NextState;
            }

            return true;
            
        }

        public int GetChecksum()
        {
            return TapeState.Select(a => a == 1).Count();
        }
    }
}
