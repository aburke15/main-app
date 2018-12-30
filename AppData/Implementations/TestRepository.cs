using Websites.AppData.Interfaces;
using Websites.AppData.Models;

namespace Websites.AppData.Implementations
{
    public class TestRepository : Repository<Test>, ITestRepository
    {
        private readonly WebsitesContext Context;

        public TestRepository(WebsitesContext context)
            : base(context) => Context = context;
    }
}