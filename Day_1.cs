
using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2024
{
    public class Day_1
    {
        private List<int> leftSide = new List<int>();
        private List<int> rightSide = new List<int>();
        private int totalDistance;
        private int similarityScore;

        public void Run(string filePath)
        {
            LoadFile(filePath);
            CalculateTheDistance();
            CalculateTheSimilarityScore();
            PrintTheResult();
        }

        public void LoadFile (string filePath)
        { 
            string[] lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                //convert to string array
                string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                
                //save to list
                leftSide.Add(int.Parse(parts[0]));
                rightSide.Add(int.Parse(parts[1]));
            }
        }

        public void CalculateTheDistance()
        {
            leftSide.Sort();
            rightSide.Sort();

            for (int i = 0; i < leftSide.Count; i++)
            {
                totalDistance += Math.Abs(leftSide[i] - rightSide[i]);
            }
        }

        public void CalculateTheSimilarityScore()
        {
            leftSide.Sort();
            rightSide.Sort();

            for (int i = 0; i < leftSide.Count; i++)
            {
                int similarNumCount = 0;
                for (int j = 0; j < rightSide.Count; j++)
                {
                    if (leftSide[i] == rightSide[j])
                    {
                        similarNumCount++;
                    }
                }
                similarityScore += leftSide[i] * similarNumCount;
            }
        }

        public void PrintTheResult()
        {
            Console.WriteLine($"The total calculated distance value is: {totalDistance}");
            Console.WriteLine($"The calculated similarity score value is: {similarityScore}");

        }
    }
}