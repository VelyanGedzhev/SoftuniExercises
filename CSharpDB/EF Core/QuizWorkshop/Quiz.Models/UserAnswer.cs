using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Models
{
    public class UserAnswer
    {
        public int UserId { get; set; }

        public int QiuzId { get; set; }

        public int QuestionId { get; set; }

        public int AnswerId { get; set; }
    }
}
