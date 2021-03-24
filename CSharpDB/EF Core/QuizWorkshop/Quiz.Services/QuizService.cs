using Microsoft.EntityFrameworkCore;
using Quiz.Data;
using Quiz.Services.Models;
using System;
using System.Linq;

namespace Quiz.Services
{
    public class QuizService : IQuizService
    {
        private readonly ApplicationDbContext dbContext;

        public QuizService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Add(string title)
        {
            var quiz = new Quiz.Models.Quiz
            {
                Title = title,
            };

            this.dbContext.Quizzes.Add(quiz);
            this.dbContext.SaveChanges();

            return quiz.Id;
        }

        public QuizViewModel GetQuizById(int quizId)
        {
            var quiz = this.dbContext.Quizzes
                .Include(x => x.Questions)
                .ThenInclude(x => x.Answers)
                .FirstOrDefault(x => x.Id == quizId);

            var quizViewModel = new QuizViewModel
            {
                Id = quiz.Id,
                Title = quiz.Title,
                Questions = quiz.Questions
                    .Select(x => new QuestionViewModel
                    {
                        Title = x.Title,
                        Id = x.Id,
                        Answers = x.Answers
                            .Select(a => new AnswerViewModel
                            {
                                Id = a.Id,
                                Title = a.Title,
                            }).ToArray()
                    }).ToArray()
            };

            return quizViewModel;
        }
    }
}
