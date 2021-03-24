using Quiz.Services.Models;

namespace Quiz.Services
{
    public interface IUserAnswerService
    {
        void AddUserAnswer(string userId, int answerId);

        int GetUserResult(string userId, int quizId);

        void BulkAddUserAnswer(QuizInputModel quizInput);
    }
}
