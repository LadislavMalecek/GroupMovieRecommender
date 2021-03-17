using System;
using GroupMovieRecommender.Server.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace GroupMovieRecommender.Server.Data
{
    public class ApplicationAuthenticationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationAuthenticationDbContext(
            DbContextOptions<ApplicationAuthenticationDbContext> options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        { }

        public static void EnsureCreated(IServiceProvider serviceProvider)
        {
            var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var db = serviceScope.ServiceProvider.GetService<ApplicationAuthenticationDbContext>();
            db.Database.EnsureCreated();
        }
    }
}