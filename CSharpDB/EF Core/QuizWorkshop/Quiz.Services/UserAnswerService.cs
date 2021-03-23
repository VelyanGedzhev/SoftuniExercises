using Microsoft.EntityFrameworkCore;
using Quiz.Data;
using Quiz.Models;
using Quiz.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace Quiz.Services
{
    public class UserAnswerService : IUserAnswerService
    {
        private readonly ApplicationDbContext dbContext;

        public UserAnswerService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddUserAnswer(string userId, int quizId, int questionId, int answerId)
        {
            var userAnswer = new UserAnswer
            {
                IdentityUserId = userId,
                QuizId = quizId,
                QuestionId = questionId,
                AnswerId = answerId
            };

            this.dbContext.UserAnswers.Add(userAnswer);
            this.dbContext.SaveChanges();
        }

        public void BulkAddUserAnswer(QuizInputModel quizInput)
        {
            var userAnswers = new List<UserAnswer>();

            foreach (var item in quizInput.Questions)
            {
                var userAnswer = new UserAnswer
                {
                    IdentityUserId = quizInput.UserId,
                    QuizId = quizInput.QuizId,
                    AnswerId = item.AnswerId,
                    QuestionId = item.QuestionId,
                };

                userAnswers.Add(userAnswer);
            }

            this.dbContext.AddRange(userAnswers);
            this.dbContext.SaveChanges();
        }

        public int GetUserResult(string userId, int quizId)
        {
            var totalPoints = this.dbContext.Quizzes
                .Include(x => x.Questions)
                .ThenInclude(x => x.Answers)
                .ThenInclude(x => x.UserAnswers)
                .Where(x => x.Id == quizId 
                    && x.UserAnswers.Any(x => x.IdentityUserId == userId))
                .SelectMany(x => x.UserAnswers)
                .Where(x => x.Answer.IsCorrect)
                .Sum(x => x.Answer.Points);

            return totalPoints;
        }
    }
}
