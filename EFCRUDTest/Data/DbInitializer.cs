using EFCRUDTest.Models;
using System;
using System.Linq;

namespace EFCRUDTest.Models
{
    public static class DbInitializer
    {
        public static void Initialize(StuffContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.User.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
            new User{FirstName="Damon",LastName="Leedham",Email="damon@leedham.com"},
            new User{FirstName="Ben",LastName="Leedham",Email="ben@leedham.com"},
            new User{FirstName="Jack",LastName="Taylor",Email="jack@domain.com"},
            new User{FirstName="John",LastName="Smith",Email="john@domain.com"}            
            };
            foreach (User u in users)
            {
                context.User.Add(u);
            }
            context.SaveChanges();

            var projects = new Project[]
            {
            new Project{Description="Project1"},
            new Project{Description="Project2"},
            new Project{Description="Project3"},
            new Project{Description="Project4"},
            new Project{Description="Project5"},
            new Project{Description="Project6"},
            new Project{Description="Project7"}
            };
            foreach (Project p in projects)
            {
                context.Project.Add(p);
            }
            context.SaveChanges();

            var statuses = new Status[]
            {
            new Status{Description="Ongoing"},
            new Status{Description="Fix In Progress"},
            new Status{Description="Resolved"}
            };
            foreach (Status s in statuses)
            {
                context.Status.Add(s);
            }
            context.SaveChanges();

            var bugtypes = new BugType[]
            {
            new BugType{Description="Hardware"},
            new BugType{Description="Database"},
            new BugType{Description="UI"}
            };
            foreach (BugType b in bugtypes)
            {
                context.BugType.Add(b);
            }
            context.SaveChanges();

            var bugs = new Bug[]
            {
            new Bug{UserID=1,ProjectID=1,StatusID=3,BugTypeID=1,Description="Ancient PC said No"},
            new Bug{UserID=1,ProjectID=2,StatusID=1,BugTypeID=2,Description="External DB"},
            new Bug{UserID=1,ProjectID=3,StatusID=2,BugTypeID=3,Description="Make it look nice"}            
            };
            foreach (Bug b in bugs)
            {
                context.Bug.Add(b);
            }
            context.SaveChanges();
        }
    }
}