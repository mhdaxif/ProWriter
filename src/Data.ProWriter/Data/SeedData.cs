using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ProWriter
{
    public static class SeedData
    {
        public static IEnumerable<User> GetUsers()
        {
            var usersWithProjects = new List<User>
            {
                 new User
                    {
                        UserName = "ali",
                        HashedPassword = "abc",
                        Email = "seed@writer.com",
                        FirstName = "Ali",
                        LastName = "Khan",
                        IsEmailVerified = true,
                        Projects = new List<Project>
                        {
                            new Project
                            {
                                Name = "Starter",
                                Description = "Just a starter project",
                                Documents = new List<Document>
                                {
                                    new Document
                                    {
                                        Name = "Hello",
                                        Payload = "Initial Hello"
                                    },
                                    new Document
                                    {
                                        Name = "Pro Starter",
                                        Payload = "Basic setup for pro starter"
                                    }
                                }
                            },
                             new Project
                            {
                                Name = "Lestgo",
                                Description = "Just a Lestgo project",
                                Documents = new List<Document>
                                {
                                    new Document
                                    {
                                        Name = "Hello Lestgo",
                                        Payload = "Initial Hello Lestgo"
                                    },
                                    new Document
                                    {
                                        Name = "Pro Starter Lestgo",
                                        Payload = "Basic setup for pro starter Lestgo.."
                                    }
                                }
                            }
                        }
                    },
            };

            return usersWithProjects;
        }
    }
}
