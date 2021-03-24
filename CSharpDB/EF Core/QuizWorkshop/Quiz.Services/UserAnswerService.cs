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

        public void AddUserAnswer(string userId, int answerId)
        {
            var userAnswer = new UserAnswer
            {
                IdentityUserId = userId,
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
                    AnswerId = item.AnswerId,
                };

                userAnswers.Add(userAnswer);
            }

            this.dbContext.AddRange(userAnswers);
            this.dbContext.SaveChanges();
        }

        public int GetUserResult(string userId, int quizId)
        {
            var totalPoints = this.dbContext.UserAnswers
                .Where(x => x.IdentityUserId == userId
                    && x.Question.QuizId == quizId)
                .Sum(x => x.Answer.Points);


            return totalPoints;
        }
    }
}
