using BlogAppProject.Entity;
using Microsoft.EntityFrameworkCore;
using static BlogAppProject.Entity.Tag;

namespace BlogAppProject.Data.EfCore
{
    public static class SeedData
    {
        public static async Task Initialize(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User
                        {
                            UserName = "yaren",
                            Email = "yaren@test.com",
                            Image = "yaren.jpg",
                            Password = "Yaren1234"
                        },
                        new User
                        {
                            UserName = "batu",
                            Email = "batu@test.com",
                            Image = "yaren.jpg",
                            Password = "Batu1234"

                        }
                    );
                    context.SaveChanges();
                }
                if (!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new Tag { Text = "Historical Fiction", Url = "historical-fiction", Color = TagColors.primary },
                        new Tag { Text = "Classic Literature", Url = "classic-literature", Color = TagColors.secondary },
                        new Tag { Text = "American Literature", Url = "american-literature", Color = TagColors.success },
                        new Tag { Text = "Turkish Literature", Url = "american-literature", Color = TagColors.success },
                        new Tag { Text = "Romance", Url = "romance", Color = TagColors.warning }
                    );
                    await context.SaveChangesAsync();
                }

                if (!context.Posts.Any())
                {
                    {
                        context.Posts.AddRange(
                             new Post
                             {
                                 Title = "Pomegranate Tree",
                                 Description = "Pomegranate Tree is a novel by Nazan Bekiroğlu published in 2012.",
                                 Content = "It tells the story of a young man from Tabriz living through three loves up until World War II, and his life before meeting his last love, a girl from Trabzon, interwoven with two separate time journeys that change the lives of the young girl and her family due to the Balkan War.",
                                 Image = "naragacı.jpg",
                                 Url = "pomegranate-tree",
                                 PublishedOn = DateTime.Now,
                                 UserId = 1,
                                 Tags = context.Tags.Take(3).ToList(),
                                 Comments = new List<Comment>
                                 {
                                new Comment { Text = "Excellent Book", PublishedOn = DateTime.Now.AddDays(-10), UserId = 2 }
                                 }
                             },
                             new Post
                             {
                                 Title = "Mansfield Park",
                                 Description = "Mansfield Park is the third published novel by English writer Jane Austen.",
                                 Content = "The novel describes the struggle to adapt to life in Mansfield Park, the moral dilemmas, and the secret love for her cousin Edmund. The text explores themes of Balance and Change, Virtue and Evil, Love, Money, and Marriage.",
                                 Image = "masfield.jpg",
                                 Url = "mansfield-park",
                                 PublishedOn = DateTime.Now,
                                 UserId = 2,
                                 Tags = await context.Tags.Take(2).ToListAsync(),
                                 Comments = new List<Comment>
                                {
                               new Comment { Text = "Excellent Book", PublishedOn = DateTime.Now.AddDays(-10), UserId = 1 }
                                }
                             },
                             new Post
                             {
                                 Title = "East of Eden",
                                 Description = "John Steinbeck's Nobel Prize-winning 'East of Eden' is known for its profound subject and captivating characters.",
                                 Content = "Many consider this work to be Steinbeck's most ambitious novel, and Steinbeck himself regards it as his masterpiece. Steinbeck says of 'East of Eden': 'In this novel is everything I have learned about my profession or craft over the years.' It is dedicated to his young sons, Thom and John, and aims to vividly describe the Salinas Valley: the landscapes, sounds, smells, and colors. 'East of Eden' tells the complex details and intertwined stories of the Trask and Hamilton families.",
                                 Image = "cennetindogusu.jpg",
                                 Url = "east-of-eden",
                                 PublishedOn = DateTime.Now,
                                 UserId = 1,
                                 Tags = await context.Tags.Take(1).ToListAsync(),
                                 Comments = new List<Comment>
                                 {
                                new Comment { Text = "Incredible Book", PublishedOn = DateTime.Now, UserId = 2 }
                                 }
                             },
                             new Post
                             {
                                 Title = "Northanger Abbey",
                                 Description = "Northanger Abbey is a novel by Jane Austen that explores the themes of imagination and reality.",
                                 Content = "The novel follows Catherine Morland, a young woman whose love for Gothic novels influences her perceptions of reality. As she navigates the social scene of Bath and Northanger Abbey, she faces the challenge of distinguishing between fantasy and reality.",
                                 Image = "northanger.jpg",
                                 Url = "northanger-abbey",
                                 PublishedOn = DateTime.Now,
                                 UserId = 1,
                                 Tags = await context.Tags.Take(1).ToListAsync(),
                                 Comments = new List<Comment>
                                 {
                                new Comment { Text = "A fascinating read", PublishedOn = DateTime.Now, UserId = 2 }
                                 }
                             }, new Post
                             {
                                 Title = "Love and Other Possibilities",
                                 Description = "A novel exploring the complexities of love and the myriad possibilities it offers.",
                                 Content = "This book delves into the different facets of love, examining how it can shape and change our lives in unexpected ways. Through a series of interconnected stories, the novel portrays the diverse ways in which love manifests and influences our choices.",
                                 Image = "askvedigerihtimaller.jpg",
                                 Url = "love-and-other-possibilities",
                                 PublishedOn = DateTime.Now,
                                 UserId = 2,
                                 Tags = await context.Tags.Take(2).ToListAsync(),
                                 Comments = new List<Comment>
                                 {
                               new Comment { Text = "A thought-provoking book", PublishedOn = DateTime.Now, UserId = 1 }
                                 }
                             },
                             new Post
                             {
                                 Title = "Little Miracles",
                                 Description = "A heartwarming novel about small miracles that make life extraordinary.",
                                 Content = "The novel tells the story of ordinary people who experience extraordinary events that change their lives forever. It highlights the beauty of everyday moments and the miraculous transformations that can occur when least expected.",
                                 Image = "küçükmucizeler3.jpg",
                                 Url = "little-miracles",
                                 PublishedOn = DateTime.Now,
                                 UserId = 1,
                                 Tags = await context.Tags.Take(2).ToListAsync(),
                                 Comments = new List<Comment>
                                 {
                                new Comment { Text = "An inspiring story", PublishedOn = DateTime.Now, UserId = 2 }
                                 }
                             }
                        );
                        await context.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
