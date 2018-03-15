﻿using System;
using System.Collections.Generic;
using System.Linq;


namespace SimpleJudge
{
    public static class RepositoryFilters
    {
        private static void FilterAndTake (Dictionary<string,List<int>> wantedData, 
            Predicate<double> givenFilter,
            int studentsToTake )
        {
            int counterForPrinted = 0;
            foreach (var userName_Point in wantedData)
            {
                if (counterForPrinted == studentsToTake)
                {
                    break;
                }
                double averageScore = userName_Point.Value.Average();
                double percentageOfAllfilment = averageScore / 100;
                double mark = percentageOfAllfilment * 4 + 2;

                if (givenFilter(mark))
                {
                    OutputWriter.PrintStudent(userName_Point);
                    counterForPrinted++;
                }
            }           
        }
        public static void FilterAndTake(Dictionary<string, List<int>> wantedData, 
            string wantedFilter, 
            int studentsToTake)
        {
            if (wantedFilter == "excellent" )
            {
                FilterAndTake(wantedData, x => x >= 5, studentsToTake);

            }
            else if (wantedFilter == "average")
            {
                FilterAndTake(wantedData, x => x < 5 && x >=3.5, studentsToTake);
            }
            else if (wantedFilter == "poor")
            {
                FilterAndTake(wantedData, x => x < 3.5, studentsToTake);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidStudentFilter);
            }
        }
    }
}