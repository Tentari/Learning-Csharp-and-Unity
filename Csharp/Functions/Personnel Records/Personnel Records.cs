using System;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const char AddCurriculumVitaeCommand = '1';
            const char ShowAllCurriculumVitaeCommand = '2';
            const char DeleteCurriculumVitaeCommand = '3';
            const char FindCurriculumVitaeCommand = '4';
            const char ExitCommand = '5';

            string[] fullName = new string[0];
            string[] job = new string[0];

            bool isOpen = true;

            Console.WriteLine("Hello user");

            while (isOpen)
            {
                Console.WriteLine($"\nPick our task.\n{AddCurriculumVitaeCommand}-Add CV.\n{ShowAllCurriculumVitaeCommand}-Show every CV.\n{DeleteCurriculumVitaeCommand}-Delete CV.\n{FindCurriculumVitaeCommand}-Find CV by last name.\n{ExitCommand}-Exit.");
                string userInput = Console.ReadLine();

                if (userInput.Length == 1)
                {
                    Console.Clear();

                    switch (Convert.ToChar(userInput))
                    {
                        case AddCurriculumVitaeCommand:
                            AddCurriculumVitae(ref fullName, ref job);
                            break;

                        case ShowAllCurriculumVitaeCommand:
                            ShowAllCurriculumVitae(fullName, job);
                            break;

                        case DeleteCurriculumVitaeCommand:
                            DeleteCurriculumVitae(ref fullName, ref job);
                            break;

                        case FindCurriculumVitaeCommand:
                            ShowElementByIndex(fullName, job);
                            break;

                        case ExitCommand:
                            isOpen = false;
                            break;

                        default:
                            Console.WriteLine("I don't know such command.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input.");
                }
            }
        }

        static void AddCurriculumVitae(ref string[] arrayName, ref string[] arrayJob)
        {
            Console.WriteLine("Input your name and last name.");
            string userInput = Console.ReadLine();

            string[] splittedName = userInput.Split(' ');

            int splitCorrect = 2;

            if (splitCorrect == splittedName.Length)
            {
                arrayName = ExpandArray(arrayName, userInput);

                Console.WriteLine("Input your job title.");
                userInput = Console.ReadLine();

                arrayJob = ExpandArray(arrayJob, userInput);
            }
            else
            {
                Console.WriteLine("Incorrect input.");
            }
        }

        static string[] ExpandArray(string[] array,string userInput)
        {
            string[] tempArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }

            array = tempArray;

            array[array.Length - 1] = userInput;

            return array;
        }

        static void ShowAllCurriculumVitae(string[] arrayName, string[] arrayJob)
        {
            if (arrayName.Length > 0)
            {
                for (int i = 0; i < arrayName.Length; i++)
                {
                    Console.WriteLine($"{i + 1}.{arrayName[i]} - {arrayJob[i]}.");
                }
            }
            else
            {
                Console.WriteLine("No CVs!");
            }
        }

        static void ShowElementByIndex(string[] arrayName, string[] arrayJob)
        {
            int foundIndex = FindElementByLastName(arrayName, arrayJob) + 1;

            if (foundIndex > 0)
            {
                Console.WriteLine(foundIndex + " Thats index you need.");
            }
            else
            {
                Console.WriteLine("Index not found.");
            }
        }

        static int FindElementByLastName(string[] arrayName, string[] arrayJob)
        {
            ShowAllCurriculumVitae(arrayName, arrayJob);

            Console.WriteLine("Pick last name to interact.");
            string userInput = Console.ReadLine();

            int curriculumVitaeIndex = -1;
            int lastNameIndex = 1;

            for (int i = 0; i < arrayName.Length; i++)
            {
                string[] namePart = arrayName[i].Split(' ');

                if (userInput.ToLower() == namePart[lastNameIndex].ToLower())
                {
                    curriculumVitaeIndex = i;
                }
            }

            return curriculumVitaeIndex;
        }

        static void DeleteCurriculumVitae(ref string[] arrayName, ref string[] arrayJob)
        {
            ShowAllCurriculumVitae(arrayName, arrayJob);

            Console.WriteLine("Input index to be deleted.");
            int userInput = Convert.ToInt32(Console.ReadLine()) - 1;

            if (userInput > -1)
            {
                Console.WriteLine("Deletion completed.");
                arrayName = ReduceArray(arrayName, userInput);
                arrayJob = ReduceArray(arrayJob, userInput);
            }
            else
            {
                Console.WriteLine("No CV found.");
            }
        }

        static string[] ReduceArray(string[] array, int index)
        {
            string[] tempArray = new string[array.Length - 1];

            for (int i = 0; i < index; i++)
            {
                tempArray[i] = array[i];
            }

            for (int i = index; i < array.Length - 1; i++)
            {
                tempArray[i] = array[i + 1];
            }

            array = tempArray;

            return array;
        }
    }
}
