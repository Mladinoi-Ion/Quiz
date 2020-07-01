﻿using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Models
{
    public class QuestionsAndAnswer
    {
        public string Name { get; private set; }
        public IEnumerable<Answer> Answers { get; set; }
        public DifficultyType Difficulty { get; private set; }

        public QuestionsAndAnswer(string name, DifficultyType difficulty, IEnumerable<Answer> answers)
        {
            Name = name;
            Difficulty = difficulty;
            Answers = answers;
        }
    }
}
