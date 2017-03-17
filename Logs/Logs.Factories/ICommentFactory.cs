using System;
using Logs.Models;

namespace Logs.Factories
{
    public interface ICommentFactory
    {
        Comment CreateComment(string content, DateTime date, User user);
    }
}
