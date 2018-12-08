using AppData.Interfaces;
using AppData.Models;

namespace AppData.Implementations
{
    public class TestRepository : Repository<Test>, ITestRepository
    {
        private readonly WebsitesContext Context;

        public TestRepository(WebsitesContext context)
            : base(context) => Context = context;
    }
}