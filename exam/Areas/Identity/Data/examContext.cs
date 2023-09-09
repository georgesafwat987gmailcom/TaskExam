using exam.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace exam.Data;

public class examContext : IdentityDbContext<IdentityUser>
{
    public examContext(DbContextOptions<examContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        //builder.Properties<TimeOnly>()
        //.HaveConversion<TimeOnlyConverter>();
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        base.ConfigureConventions(builder);

        builder.Properties<TimeOnly>()
            .HaveConversion<TimeOnlyConverter>();
    }


    public DbSet<Exams> Exams { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<UserAnswer> UserAnswers { get; set; }
    public DbSet<QuestionsChoices> QuestionsChoices { get; set; }




}
