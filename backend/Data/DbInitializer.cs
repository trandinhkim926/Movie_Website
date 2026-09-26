using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                // Tự động Migrate/Tạo DB và bảng nếu chưa có
                context.Database.Migrate();

                // Kiểm tra xem đã có dữ liệu thể loại phim chưa
                if (!context.Categories.Any())
                {
                    var categories = new List<Category>
                    {
                        new Category { Name = "Hành Động", Description = "Phim kịch tính, cháy nổ, võ thuật", IconUrl = "/icons/action.svg" },
                        new Category { Name = "Khoa Học Viễn Tưởng", Description = "Phim vũ trụ, công nghệ tương lai", IconUrl = "/icons/sci-fi.svg" },
                        new Category { Name = "Kinh Dị", Description = "Phim ma, giật gân, hồi hộp", IconUrl = "/icons/horror.svg" },
                        new Category { Name = "Tình Cảm", Description = "Phim lãng mạn, cảm xúc", IconUrl = "/icons/romance.svg" },
                        new Category { Name = "Hài Hước", Description = "Phim giải trí mang lại tiếng cười", IconUrl = "/icons/comedy.svg" },
                        new Category { Name = "Hoạt Hình", Description = "Phim Anime, Animation 3D", IconUrl = "/icons/anime.svg" }
                    };

                    context.Categories.AddRange(categories);
                    context.SaveChanges();
                }

                // Kiểm tra xem đã có dữ liệu phim chưa
                if (!context.Movies.Any())
                {
                    var actionCategory = context.Categories.FirstOrDefault(c => c.Name == "Hành Động");
                    var sciFiCategory = context.Categories.FirstOrDefault(c => c.Name == "Khoa Học Viễn Tưởng");

                    var sampleMovies = new List<Movie>
                    {
                        new Movie
                        {
                            Title = "Inception (Kẻ Đánh Cắp Giấc Mơ)",
                            Description = "Một kẻ cắp chuyên nghiệp xâm nhập vào giấc mơ của người khác để lấy cắp bí mật thương mại.",
                            ReleaseYear = 2010,
                            Duration = 148,
                            AgeRating = "13+",
                            PosterUrl = "https://image.tmdb.org/t/p/w500/9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg",
                            TrailerUrl = "https://www.youtube.com/watch?v=YoHD9XEInc0",
                            IsActive = true
                        },
                        new Movie
                        {
                            Title = "Interstellar (Hố Đen Tử Thần)",
                            Description = "Chuyến du hành không gian tìm kiếm hành tinh mới cho nhân loại khi Trái Đất kiệt quệ.",
                            ReleaseYear = 2014,
                            Duration = 169,
                            AgeRating = "13+",
                            PosterUrl = "https://image.tmdb.org/t/p/w500/gEU2QniE6E77NI6lCU6MxlNBvIx.jpg",
                            TrailerUrl = "https://www.youtube.com/watch?v=zSWdZVtXT7E",
                            IsActive = true
                        },
                        new Movie
                        {
                            Title = "The Dark Knight (Kị Sĩ Bóng Đêm)",
                            Description = "Batman đối đầu với Joker - kẻ tội phạm nguy hiểm bậc nhất thành phố Gotham.",
                            ReleaseYear = 2008,
                            Duration = 152,
                            AgeRating = "16+",
                            PosterUrl = "https://image.tmdb.org/t/p/w500/qJ2tW6WMUDux911r6m7haRef0WH.jpg",
                            TrailerUrl = "https://www.youtube.com/watch?v=EXeTwQWrcwY",
                            IsActive = true
                        }
                    };

                    context.Movies.AddRange(sampleMovies);
                    context.SaveChanges();

                    // Liên kết thể loại cho phim mẫu
                    if (actionCategory != null && sciFiCategory != null)
                    {
                        var inception = context.Movies.FirstOrDefault(m => m.Title.Contains("Inception"));
                        if (inception != null)
                        {
                            context.MovieCategories.Add(new MovieCategory { MovieId = inception.MovieId, CategoryId = actionCategory.CategoryId });
                            context.MovieCategories.Add(new MovieCategory { MovieId = inception.MovieId, CategoryId = sciFiCategory.CategoryId });
                        }
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}
