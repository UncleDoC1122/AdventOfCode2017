﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay20
{
    class Task1
    {
        public static void Solve(string pathToInput)
        {
            var input = File.ReadAllLines(pathToInput);

            List<ParticleTask1> list = new List<ParticleTask1>();

            foreach (var line in input)
                list.Add(new ParticleTask1(line));



            for (int i = 0; i < 10000; i++) //10000 times is enough to ensure 
            {
                var index = -1;
                var closest = long.MaxValue;
                for (int j = 0; j < list.Count; j++)
                {
                    list[j].Move();

                    if (closest > list[j].GetDistance())
                    {
                        closest = list[j].GetDistance();
                        index = j;
                    }
                }

                Console.WriteLine(String.Format("{0} entry is closest by now \n {1}", index, list[index].ToString()));
            }
            Console.ReadKey();
        }
    }

    class ParticleTask1
    {
        public long[] position;
        public long[] velocity;
        public long[] acceleration;
        public bool isOutOfBound = false;

        //public bool checkCollision(Particle particle)
        //{
        //    if (this.position[0] == particle.position[0]
        //        && this.position[1] == particle.position[1]
        //        && this.position[2] == particle.position[2])
        //        collided = true;
        //    return collided;
        //}

        public ParticleTask1(string input)
        {
            var splitted = input.Split(',');

            position = new long[3];
            velocity = new long[3];
            acceleration = new long[3];

            position[0] = long.Parse(splitted[0].Substring(3));
            position[1] = long.Parse(splitted[1]);
            position[2] = long.Parse(splitted[2].TrimEnd('>'));

            velocity[0] = long.Parse(splitted[3].Substring(4));
            velocity[1] = long.Parse(splitted[4]);
            velocity[2] = long.Parse(splitted[5].TrimEnd('>'));

            acceleration[0] = long.Parse(splitted[6].Substring(4));
            acceleration[1] = long.Parse(splitted[7]);
            acceleration[2] = long.Parse(splitted[8].TrimEnd('>'));
        }

        public bool Move()
        {
            try
            {
                for (int i = 0; i < 3; i++)
                    this.velocity[i] += this.acceleration[i];
                for (int i = 0; i < 3; i++)
                    this.position[i] += this.velocity[i];
                return true;
            }
            catch
            {
                isOutOfBound = true;
                return false;
            }

        }

        public long GetDistance()
        {
            try
            {
                return Math.Abs(position[0]) + Math.Abs(position[1]) + Math.Abs(position[2]);
            }
            catch
            {
                return -1;
            }
        }

        public override string ToString()
        {
            if (isOutOfBound)
                return String.Format("Particle flew out of range");
            else
                return String.Format("Particle is now in {0},{1},{2}, {3} away from 0,0,0", position[0], position[1], position[2], GetDistance());
        }
    }
}
