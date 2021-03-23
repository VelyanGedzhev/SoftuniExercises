﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Models
{
    public class UserAnswer
    {
        public string IdentityUserId { get; set; }

        public IdentityUser IdentityUser { get; set; }

        public int QiuzId { get; set; }

        public Quiz Quiz { get; set; }

        public int QuestionId { get; set; }

        public Question Question { get; set; }

        public int AnswerId { get; set; }

        public Answer Answer { get; set; }
    }
}
