using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.DataAccess.EntityFramework
{
    public class StartUp
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookContext>(options => options.UseSqlite("Data source=books.db"));
        }
    }
}
