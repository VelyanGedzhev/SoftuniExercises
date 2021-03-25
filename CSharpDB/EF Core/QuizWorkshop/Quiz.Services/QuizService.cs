using Microsoft.EntityFrameworkCore;
using Quiz.Data;
using Quiz.Models;
using Quiz.Services.Models;
using System;
using System.Collections.Generic;
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
                Id = quizId,
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
                            }).ToList()
                    }).ToList()
            };

            return quizViewModel;
        }

        public IEnumerable<UserQuizViewModel> GetQuizzesByUserName(string userName)
        {
            var quizzes = dbContext.Quizzes.Select(x => new UserQuizViewModel
            {
                QuizId = x.Id,
                Title = x.Title,
            }).ToList();

            foreach (var quiz in quizzes)
            {
                var questionsCount = dbContext.UserAnswers
                    .Count(ua => ua.IdentityUser.UserName == userName
                        && ua.Question.QuizId == quiz.QuizId);

                if (questionsCount <= 0)
                {
                    quiz.Status = QuizStatus.NotStarted;
                    continue;
                }

                var answeredQuestions = dbContext.UserAnswers
                    .Count(ua => ua.IdentityUser.UserName == userName
                        && ua.Question.QuizId == quiz.QuizId
                        && ua.AnswerId.HasValue);

                if (answeredQuestions == questionsCount)
                {
                    quiz.Status = QuizStatus.Finished;
                }
                else
                {
                    quiz.Status = QuizStatus.InProgress;
                }
            }

            return quizzes;
        }

        public void StartQuiz(string username, int quizId)
        {
            if (dbContext.UserAnswers.Any(x => x.IdentityUser.UserName == username
                && x.Question.QuizId == quizId))
            {
                return;
            }
            var userId = this.dbContext.Users
                .Where(x => x.UserName == username)
                .Select(x => x.Id)
                .FirstOrDefault();

            var questions = dbContext.Questions
                .Where(x => x.QuizId == quizId)
                .Select(x => new { x.Id}).ToList();

            foreach (var question in questions)
            {
                dbContext.UserAnswers.Add(new UserAnswer
                {
                    AnswerId = null,
                    IdentityUserId = userId,
                    QuestionId = question.Id,
                });
            }
            dbContext.SaveChanges();
        }
    }
}
