using System;

class Program
{
    static void Main(string[] args)
    {
        Resume myResume = new()
        {
            _name = "Allison Rose"
        };
        myResume._jobs.Add(
           new()
           {
               _jobTitle = "Software Engineer",
               _company = "Microsoft",
               _startYear = 2019,
               _endYear = 2022
           }
        );
        myResume._jobs.Add(
            new()
            {
                _jobTitle = "Manager",
                _company = "Apple",
                _startYear = 2022,
                _endYear = 2023
            }
        );

        myResume.Display();
    }
}