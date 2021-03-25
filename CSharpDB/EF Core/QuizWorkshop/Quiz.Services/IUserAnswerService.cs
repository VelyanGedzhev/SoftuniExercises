using Quiz.Services.Models;

namespace Quiz.Services
{
    public interface IUserAnswerService
    {
        void AddUserAnswer(string username, int questionId, int answerId);

        int GetUserResult(string username, int quizId);

        void BulkAddUserAnswer(QuizInputModel quizInput);
    }
}
