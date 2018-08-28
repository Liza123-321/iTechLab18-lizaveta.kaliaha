using FilmsCatalog.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmsCatalog.DAL.Initializer
{
    public static class DbContextInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Film>()
            .HasMany(c => c.Photos)
            .WithOne(e => e.Film);

            modelBuilder.Entity<Film>()
          .HasMany(c => c.Comments)
          .WithOne(e => e.Film);

            modelBuilder.Entity<User>()
          .HasMany(c => c.Comments)
          .WithOne(e => e.User);

            modelBuilder.Entity<FilmGenre>()
        .HasKey(bc => new { bc.FilmId, bc.GenreId });

            modelBuilder.Entity<FilmGenre>()
                .HasOne(bc => bc.Film)
                .WithMany(b => b.FilmGenres)
                .HasForeignKey(bc => bc.FilmId);

            modelBuilder.Entity<FilmGenre>()
                .HasOne(bc => bc.Genre)
                .WithMany(c => c.FilmGenres)
                .HasForeignKey(bc => bc.GenreId);

            modelBuilder.Entity<User>().HasData(
             new User { Id = 1, Email = "qwerty@mail.ru", Password = "12345", Role = "user" },
             new User { Id = 2, Email = "admin@mail.ru", Password = "admin", Role = "admin" });

            modelBuilder.Entity<Film>().HasData(
            new Film { Id = 1, Video = "https://www.youtube.com/embed/rs7lyEWy36k", Name = "Атлантида", AverageRating = 0, Country = "Испания", Year = 2017, Description = "События разворачиваются в 1914 году, сразу после убийства Франца Фердинанда, которое повлекло за собой Первую мировую войну. К одинокому пустынному острову, расположенному у Южного полярного круга, подплывает пароход. На нем на остров прибывает новый метеоролог, чтобы занять свой пост и жить там целый год, пока ему не привезут человека на смену. На острове кроме него есть еще один человек – смотритель маяка, угрюмый затворник Грюнер. От него герой узнает, что предыдущий метеоролог умер от тифа какое-то время назад. Однако вскоре герой поймет, что с виду тихий остров на самом деле очень опасен по ночам. Ведь именно в это время из моря на берег выходят представители неизвестной расы, которые боятся любого вида света. Каждую ночь они совершают нападения на маяк, чтобы потушить его.", Producer = "Ксавье Жанс", Poster = "https://st.kp.yandex.net/images/film_big/678639.jpg" },
            new Film { Id = 2, Video = "https://www.youtube.com/embed/oZuUIu-iWAI", Name = "Мстители", AverageRating = 0, Country = "США", Year = 2018, Description = "В то время как Мстители и их союзники неустанно защищают мир от всевозможных опасностей, к ним из космоса подбирается новая угроза – Танос. Этот беспощадный тиран одержим своей целью – собрать все шесть Камней Бесконечности, уникальные артефакты, обладающие невиданной силой, с помощью которых он сможет изменить реальность и сделать ее такой, какой захочет. Все, с чем боролись Мстители ранее, вело именно к этому моменту. Судьба Земли и самой жизни стоит на кону.", Producer = "Энтони Руссо, Джо Руссо", Poster = "http://thr.ru/public/article/2018/03/19/AVNGRS3_PAYOFF_68x100.jpg" },
            new Film { Id = 3, Name = "Гоголь.Начало", Video = "https://www.youtube.com/embed/EvgwUsZ6ioc", AverageRating = 0, Country = "Россия", Year = 2017, Description = "Фильм рассказывает о юном Николае Гоголе, который в 1829 году только начинает пробовать себя в литературе. Однако он слишком критичен к своему творчеству и потому сжигает все, что пишет. Неожиданно он знакомится со следователем Яковом Гуро. Яков отбывает из Петербурга в село Диканька, чтобы расследовать происходящие там странные события. И Гоголь напрашивается к нему в помощники, чтобы написать об этом роман. Производство – канал ТВ-3 и продюсерская компания «Среда».", Producer = "Егор Баранов", Poster = "http://www.cyprusmoms.com/wp-content/uploads/2017/09/21587048_941712105967370_5415383322108884044_o.jpg" },
            new Film { Id = 4, Name = "Я худею", Video = "https://www.youtube.com/embed/jQvRurB13Gg", AverageRating = 0, Country = "Россия", Year = 2018, Description = "Главная героиня фильма, симпатичная девушка Аня, очень любит своего спортивного и стройного парня Женю, но еще она любит вкусно и много поесть. Бесконтрольное поглощение вкусностей приводит к полноте и в результате к уходу любимого человека. Однако героиня не намерена так просто сдаваться. Твердо решив побороться за свое счастье, Аня начинает активно худеть. Вот только скинуть лишние килограммы оказывается сложнее, чем ей представлялось. На помощь Ане приходит толстяк Коля, повернутый на здоровом образе жизни.", Producer = "Алексей Нужный", Poster = "https://www.kino-teatr.ru/movie/poster/126737/89371.jpg" },
            new Film { Id = 5, Name = "Стражи Галактики", Video = "https://www.youtube.com/embed/p7VRUK7ctmU", AverageRating = 0, Country = "США", Year = 2017, Description = "Спустя несколько месяцев после событий первого фильма Стражи Галактики продолжают свои путешествия по просторам необъятного космоса. На этот раз им придется сражаться, чтобы защитить свою вновь обретенную семью, а также им предстоит разгадать тайну истинного происхождения Питера Квилла. Старые враги станут новыми союзниками, а кроме того появятся новые персонажи из классических комиксов, которые придут на помощь нашим героям.", Producer = "Джеймс Ганн", Poster = "https://media.kg-portal.ru/movies/g/guardiansofthegalaxy/posters/guardiansofthegalaxy_3.jpg" }
            );

            modelBuilder.Entity<Comment>().HasData(
                new Comment { Id = 1, CommentMessage = "some comment message", UserId = 1, FilmId = 1, Data = "19/06/2015 17:35:50" },
                 new Comment { Id = 2, CommentMessage = "testing films", UserId = 2, FilmId = 1, Data = "19/07/2015 19:35:50" },
                 new Comment { Id = 3, CommentMessage = "some comment message", UserId = 1, FilmId = 2, Data = "19/07/2015 19:35:50" },
                 new Comment { Id = 4, CommentMessage = "some comment message", UserId = 1, FilmId = 3, Data = "19/07/2015 19:35:50" }

                );


            modelBuilder.Entity<RatingMark>().HasData(
               new RatingMark { Id = 1, FilmId = 1, UserId = 1, Mark = 7 },
               new RatingMark { Id = 2, FilmId = 1, UserId = 2, Mark = 3 }
               );

            modelBuilder.Entity<Photo>().HasData(
                new Photo { Id = 1, Src = "https://i.ytimg.com/vi/rs7lyEWy36k/maxresdefault.jpg", FilmId = 1 },
                new Photo { Id = 2, Src = "https://f.otzyv.ru/f/kino/2017/5527/1311171414432.jpg", FilmId = 1 },
                new Photo { Id = 3, Src = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRwI6v00CUbzC1qyivySLIL1NM-zIvDEt2UNKMlB7CPVEP0qum8TA", FilmId = 1 },
                new Photo { Id = 4, Src = "https://x-torrent.pro/_ld/86/79739157.jpg", FilmId = 1 },
                new Photo { Id = 5, Src = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTT_Sl7ms5xcLReKI8HsMMv4CPfKtkIttyQHMQIjttKPFGw7Iaf", FilmId = 1 },
                new Photo { Id = 6, Src = "http://www.mediapapa.org/uploads/posts/2018-02/1518183136_28.jpg", FilmId = 1 },
                new Photo { Id = 7, Src = "https://www.screengeek.net/wp-content/uploads/2016/11/Captain-America-Chris-Evans-and-The-Winter-Soldier-Sebastian-Stan.jpg", FilmId = 2 },
                new Photo { Id = 8, Src = "https://i1.wp.com/media-news.com.ua/wp-content/uploads/2018/02/infinity-war.jpg?resize=720%2C395&ssl=1", FilmId = 2 },
                new Photo { Id = 9, Src = "https://www.segodnya.ua/img/article/7822/4_main_new.1482431329.jpg", FilmId = 2 },
                new Photo { Id = 10, Src = "https://media.kg-portal.ru/production/avengers3/avengers3_26.jpg", FilmId = 2 },
                new Photo { Id = 11, Src = "https://www.soyuz.ru/public/uploads/files/5/7158148/1005x558_20171130142100e3542c0c87.jpg", FilmId = 2 },
                new Photo { Id = 12, Src = "https://kinolexx.ru/files/film/2017/2/7/112/mstiteli-voina-beskonechnosti-chast-1-006.jpg", FilmId = 2 },
                new Photo { Id = 13, Src = "https://cdn2.img.sputnik.by/images/103012/28/1030122831.jpg", FilmId = 3 },
                new Photo { Id = 14, Src = "https://art1.ru/media/photo/content/gogol.jpg", FilmId = 3 },
                new Photo { Id = 15, Src = "http://static.kinokopilka.pro/system/images/screenshots/images/000/363/244/363244_original.JPG", FilmId = 3 },
                new Photo { Id = 16, Src = "http://media.filmz.ru/players/img_36741.jpg", FilmId = 4 },
                new Photo { Id = 17, Src = "https://tvkinoradio.ru/upload/images/Image/45/59/80/45598013eb42381f8c72895abfbb9a6f.w590.jpg", FilmId = 4 },
                new Photo { Id = 18, Src = "http://info.sibnet.ru/ni/533/533962x630x0_1520597447.png", FilmId = 4 },
                new Photo { Id = 19, Src = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSVIiFQIOAnCHjC65_ESTNbEM7JO78GAYBflR2HSNZRk_j_2Jrj", FilmId = 5 },
                new Photo { Id = 20, Src = "http://www.fashiontime.ru/upload/articles-v3/53d6a58fa3b71w719.jpg", FilmId = 5 },
                new Photo { Id = 21, Src = "https://www.startfilm.ru/images/base/film/f_659425/startfilmru1331764.jpg", FilmId = 5 }

                );

            modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = 1, GenreName = "Ужасы" },
            new Genre { Id = 2, GenreName = "Детективы" },
            new Genre { Id = 3, GenreName = "Комедии" },
            new Genre { Id = 4, GenreName = "Спорт" },
            new Genre { Id = 5, GenreName = "Фантастика" },
            new Genre { Id = 6, GenreName = "Драмы" },
            new Genre { Id = 7, GenreName = "Приключения" }
            );


            modelBuilder.Entity<FilmGenre>().HasData(
           new FilmGenre { FilmId = 1, GenreId = 1 },
           new FilmGenre { FilmId = 2, GenreId = 1 },
           new FilmGenre { FilmId = 3, GenreId = 1 },
           new FilmGenre { FilmId = 1, GenreId = 5 },
           new FilmGenre { FilmId = 1, GenreId = 7 }
           );
        }
    }
}
