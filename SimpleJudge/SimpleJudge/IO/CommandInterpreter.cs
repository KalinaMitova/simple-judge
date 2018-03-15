
namespace SimpleJudge
{
    class CommandInterpreter
    {
        public static void InterpredCommand(string input)
        {
            string[] data = input.Split(' ');

            string command = data[0];

            switch (command)
            {
                case "mkdir":
                    TryCreateDirectory(input, data);
                    break;

                case "trdir":
                    TryTraverseFolders(input, data); 
                    break;

                case "cmp":
                    TryCompareFiles(input, data); 
                    break;

                case "cdrel":
                    TryChangePathRelatively(input, data);
                    break;

                case "cdabs":
                    TryChangePathAbsolute(input, data);
                    break;

                case "open":
                    TryOpenFile (input, data);
                    break;

                case "readdb":
                    TryReadDatabaseFromFile (input, data);
                    break;

                case "help":
                    TryGetHelp(input, data);
                    ; break;

                case "filter":
                    TryFilterAndTake(input,data) ;
                    break;

                case "order":
                    TryOrderAndTake(input, data);
                    break;

                case "download":
                    TryDownloadRequestedFile(input, data) ;
                    break;

                case "downloadAsynch":
                    TryDownloadRequestedFileAsync(input,data) ;
                    break;

                case "show":
                    TryShowWantedData(input,data) ;
                    break;

                default: OutputWriter.DisplayExeptionWrongInput(input); break;
            }
        }
        public static void TryGetHelp (string input, string[] data)
        {
            if (data.Length == 1)
            {

                OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "make directory - mkdir path "));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "traverse directory - trdir depth "));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "comparing files - cmp path1 path2"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - cdrel relative path"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - cdabs absolute path"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "read students data base - readbB path"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "filter student by mark - filter {courseName} excelent/average/poor  take 2/5/all students (the\noutput is written on the console)"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "order increasing students - order {courseName} ascending/descending take 20/10/all (the output is\nwritten on the console)"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file - download: path of file (saved in current directory)"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file asinchronously - downloadAsynch: path of file (save in the current directory)"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "get help – help"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "show course student: show {courseName} {courseName}"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "open course student"));
                OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
                OutputWriter.WriteEmptyLine();
            }
            else
            {
                OutputWriter.DisplayExeptionWrongInput(input);
            }
        }

        public static void TryReadDatabaseFromFile(string input, string[] data)
                    {
                        if (data.Length == 2)
                        {
                            string fileName = data[1];
        StudentRepository.InitializedData(fileName);
                        }
                        else
                        {
                            OutputWriter.DisplayExeptionWrongInput(input);
                        }
                    }

        public static void TryOpenFile(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string fileName = data[1];
            }
            else
            {
                OutputWriter.DisplayExeptionWrongInput(input);
            }
        }

        public static void TryChangePathAbsolute(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string absolutePath = data[1];
                IOManager.ChangeCurrentDirectoryAbsolute(absolutePath);
            }
            else
            {
                OutputWriter.DisplayExeptionWrongInput(input);
            }
        }

        public static void TryChangePathRelatively(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string relPath = data[1];
                IOManager.ChangeCurrentDirectoryRelative(relPath);
            }
            else
            {
                OutputWriter.DisplayExeptionWrongInput(input);
            }
        }

        public static void TryCompareFiles(string input,string[] data)
                    {
                        if (data.Length == 3)
                        {
                            string firstPath = data[1];
        string secondPath = data[2];
        Tester.CompareContent(data[1], data[2]);
                        }
                        else
                        {
                            OutputWriter.DisplayExeptionWrongInput(input);
                        }
                    }
        public static void TryTraverseFolders(string input,string[] data)
                    {
                        if (data.Length == 1)
                        {
                            IOManager.TraverseDirectory(0);
                        }
                        else if(data.Length == 2)
                        {
                            int depth;
                             bool hasParsed = int.TryParse(data[1], out depth);
                            if (hasParsed)
                            {
                                IOManager.TraverseDirectory(depth);
                            }
                            else
                            {
                                OutputWriter.DisplayException(ExceptionMessages.UnableToParseNumber);
                            }
                        }
                        else
                        {
                            OutputWriter.DisplayExeptionWrongInput(input);
                        }
                    }

        private static void TryCreateDirectory(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string folderName = data[1];
                IOManager.CreateDirectoryInCurrentFolder(folderName);
            }
            else
            {
                OutputWriter.DisplayExeptionWrongInput(input);
            }
        }

        private static void TryShowWantedData (string input, string[] data)
        {
            if (data.Length == 2)
            {
                string courseName = data[1];
                StudentRepository.GetAllStudentcFromCourse(courseName);
            }
            else if (data.Length == 3)
            {
                string courseName = data[1];
                string userName = data[2];
                StudentRepository.GetStudentsScoresFromCourse(courseName, userName);
            }
            else
            {
                OutputWriter.DisplayExeptionWrongInput(input);
            }
        }

        private static void TryFilterAndTake (string input, string[] data)
        {
            if (data.Length == 5)
            {
                string courseName = data[1];
                string filter = data[2];
                string takeCommand = data[3].ToLower();
                string takeQuantity = data[4].ToLower();
                TryParseParametersForFilterAndTake(takeCommand, takeQuantity, courseName, filter);
            }
            else
            {
                OutputWriter.DisplayExeptionWrongInput(input);
            }
        }
        private static void TryParseParametersForFilterAndTake(
            string takeCommand, string takeQuantity, string courseName, string filter)
        {
            if (takeCommand=="take")
            {
                if (takeQuantity == "all")
                {
                    StudentRepository.FilterAndTake(courseName, filter);
                }
                else
                {
                    int studentsTotake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsTotake);
                    if (hasParsed)
                    {
                        StudentRepository.FilterAndTake(courseName, filter, studentsTotake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeCommand);
            }
        }

        private static void TryOrderAndTake(string input, string[] data)
        {
            if (data.Length == 5)
            {
                string courseName = data[1];
                string comparison = data[2];
                string takeCommand = data[3].ToLower();
                string takeQuantity = data[4].ToLower();
                TryParseParametersForOrderAndTake(takeCommand, takeQuantity, courseName, comparison);
            }
            else
            {
                OutputWriter.DisplayExeptionWrongInput(input);
            }
        }
        private static void TryParseParametersForOrderAndTake(
            string takeCommand, string takeQuantity, string courseName, string comparison)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    StudentRepository.OrderAndTake(courseName, comparison);
                }
                else
                {
                    int studentsTotake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsTotake);
                    if (hasParsed)
                    {
                        StudentRepository.OrderAndTake(courseName, comparison, studentsTotake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeCommand);
            }
        }

        private static void TryDownloadRequestedFileAsync(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string url = data[1];
                DownloadManager.DownloadAsync(url);
            }
            else
            {
                OutputWriter.DisplayExeptionWrongInput(input);
            }
        }

        private static void TryDownloadRequestedFile (string input, string[] data)
        {
            if (data.Length == 2)
            {
                string url = data[1];
                DownloadManager.Download (url);
            }
            else
            {
                OutputWriter.DisplayExeptionWrongInput(input);
            }
        }
    }
}
