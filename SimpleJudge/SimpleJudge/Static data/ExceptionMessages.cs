﻿
namespace SimpleJudge
{
    public static class ExceptionMessages
    {
        public const string ExampleExceptionMessage = "Example message!";
        public const string DataAlreadyInitializedExeption = "Data is already initialized!";
        public const string DataNotInitializedExceptionMessage = "The data structure must be initialised first in order to make any operations with it!";
        public const string InexistingCourseInDataBase = "The course you are trying to get does not exist in the data base!";
        public const string InexistingStudentInDataBase = "The user name for the student you are trying to get does not exist!";
        public const string InvalidPath = "The folder/file you are trying to access at the current address, does not exist!";
        public const string UnauthorizedAccessException = "The folder/file you are trying to get access needs a higher level of rights than you currently have!";
        public const string ComparisonOfFilesWithDifferentSizes = "Files not of equal size, certain mismatch!";
        public const string ForbiddenSymbolsContainedInName = "The given name contains symbols that are not allowed to be used in names of files and folders!";
        public const string UnableToGoHigherInPartitionHierarchy = "Unable to go higher in partition hierarchy!";
        public const string UnableToParseNumber = "The sequence you've written is not a valid number!";
        public const string InvalidStudentFilter = "The given filter is not one of the following: excellent/average/poor!";
        public const string InvalidComparisonQuery = "The given comparison is not one of the following: ascending/descending!";
        public const string InvalidTakeCommand = "The take command expected does not match the format wanted!";
        public const string InvalidTakeQuantityParameter = "The quantity parameter does not match the format wanted!";
    }
}
