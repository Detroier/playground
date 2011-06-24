using System;

using Castle.Core.Logging;

using WebApp.Infrastructure.BaseClassesWithInjection;
using WebApp.Services;

namespace WebApp
{
    public partial class _Default : InjectablePage
    {
        public ILogger Logger { get; set; }

        public ITextFetchService TextFetchService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            _TodayText.Text = TextFetchService.GetTodayText();
            _TodayTextBroughtBy.Text = TextFetchService.GetType().ToString();
        }
    }
}
