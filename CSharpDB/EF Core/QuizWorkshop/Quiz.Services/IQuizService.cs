﻿using Quiz.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Services
{
    public interface IQuizService
    {
        int Add(string title);

        QuizViewModel GetQuizById(int quizId);

        IEnumerable<UserQuizViewModel> GetQuizzesByUserName(string userName);

        void StartQuiz(string username, int quizId);
    }
}
