using System;

namespace WebApp.Services
{
    public class TextFetchService : ITextFetchService
    {
        public string GetTodayText()
        {
            return DateTime.UtcNow.ToShortDateString();
        }
    }
}