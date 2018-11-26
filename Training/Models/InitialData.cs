using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Training.Models.Entities;

namespace Training.Models
{
    public static class InitialData
    {
        public static void EnsureInitiated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.TrainingGroup.Any())
            {
                context.TrainingGroup.AddRange(
                    // Training Groups
                    new TrainingGroup
                    {
                        Name = "Internal Trainings"
                    },
                    new TrainingGroup
                    {
                        Name = "Hiring Tests"
                    }
                );

                context.Training.AddRange(
                    // Trainings
                    new Entities.Training
                    {
                        Name = "PowerShell: Basics",
                        Descr = "This is all about the subject...",
                        Program = "",
                        Duration = 7
                    },
                    new Entities.Training
                    {
                        Name = "PowerShell: Advanced",
                        Descr = "This is all about the subject but much better than Basics...",
                        Program = "",
                        Duration = 14
                    },

                    new Entities.Training
                    {
                        Name = "Hire ASP.NET Developer",
                        Descr = "This test used when ASP.NET Developer is hiring",
                        Program = "",
                        Duration = 1
                    }
                );                

                context.SaveChanges();
            }
        }
    }
}