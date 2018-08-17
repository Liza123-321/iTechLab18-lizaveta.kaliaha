﻿using Microsoft.EntityFrameworkCore;
using server_task4.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server_task4.DAL.Initializer
{
    public static class DbContextInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
             new User {Id= 1, Email = "qwerty@mail.ru", Password = "12345", Role = "user" },
             new User { Id = 2, Email = "admin@mail.ru", Password = "admin", Role = "admin" });

            modelBuilder.Entity<Film>().HasData(
            new Film { Id = 1,Name= "Атлантида", AverageRating=5.9, Country="Испания", Year=2017, Description= "События разворачиваются в 1914 году, сразу после убийства Франца Фердинанда, которое повлекло за собой Первую мировую войну. К одинокому пустынному острову, расположенному у Южного полярного круга, подплывает пароход. На нем на остров прибывает новый метеоролог, чтобы занять свой пост и жить там целый год, пока ему не привезут человека на смену. На острове кроме него есть еще один человек – смотритель маяка, угрюмый затворник Грюнер. От него герой узнает, что предыдущий метеоролог умер от тифа какое-то время назад. Однако вскоре герой поймет, что с виду тихий остров на самом деле очень опасен по ночам. Ведь именно в это время из моря на берег выходят представители неизвестной расы, которые боятся любого вида света. Каждую ночь они совершают нападения на маяк, чтобы потушить его.", Producer= "Ксавье Жанс", Poster= "https://st.kp.yandex.net/images/film_big/678639.jpg" },
            new Film { Id = 2, Name = "Мстители", AverageRating = 8.6, Country = "США", Year = 2018, Description = "В то время как Мстители и их союзники неустанно защищают мир от всевозможных опасностей, к ним из космоса подбирается новая угроза – Танос. Этот беспощадный тиран одержим своей целью – собрать все шесть Камней Бесконечности, уникальные артефакты, обладающие невиданной силой, с помощью которых он сможет изменить реальность и сделать ее такой, какой захочет. Все, с чем боролись Мстители ранее, вело именно к этому моменту. Судьба Земли и самой жизни стоит на кону.", Producer = "Энтони Руссо, Джо Руссо", Poster = "http://thr.ru/public/article/2018/03/19/AVNGRS3_PAYOFF_68x100.jpg" },
            new Film { Id = 3, Name = "Гоголь.Начало", AverageRating = 5.7, Country = "Россия", Year = 2017, Description = "Фильм рассказывает о юном Николае Гоголе, который в 1829 году только начинает пробовать себя в литературе. Однако он слишком критичен к своему творчеству и потому сжигает все, что пишет. Неожиданно он знакомится со следователем Яковом Гуро. Яков отбывает из Петербурга в село Диканька, чтобы расследовать происходящие там странные события. И Гоголь напрашивается к нему в помощники, чтобы написать об этом роман. Производство – канал ТВ-3 и продюсерская компания «Среда».", Producer = "Егор Баранов", Poster = "http://www.cyprusmoms.com/wp-content/uploads/2017/09/21587048_941712105967370_5415383322108884044_o.jpg" },
            new Film { Id = 4, Name = "Я худею", AverageRating = 6.6, Country = "Россия", Year = 2018, Description = "Главная героиня фильма, симпатичная девушка Аня, очень любит своего спортивного и стройного парня Женю, но еще она любит вкусно и много поесть. Бесконтрольное поглощение вкусностей приводит к полноте и в результате к уходу любимого человека. Однако героиня не намерена так просто сдаваться. Твердо решив побороться за свое счастье, Аня начинает активно худеть. Вот только скинуть лишние килограммы оказывается сложнее, чем ей представлялось. На помощь Ане приходит толстяк Коля, повернутый на здоровом образе жизни.", Producer = "Алексей Нужный", Poster = "https://www.kino-teatr.ru/movie/poster/126737/89371.jpg" },
            new Film { Id = 5, Name = "Стражи Галактики", AverageRating = 7.7, Country = "США", Year = 2017, Description = "Спустя несколько месяцев после событий первого фильма Стражи Галактики продолжают свои путешествия по просторам необъятного космоса. На этот раз им придется сражаться, чтобы защитить свою вновь обретенную семью, а также им предстоит разгадать тайну истинного происхождения Питера Квилла. Старые враги станут новыми союзниками, а кроме того появятся новые персонажи из классических комиксов, которые придут на помощь нашим героям.", Producer = "Джеймс Ганн", Poster = "https://media.kg-portal.ru/movies/g/guardiansofthegalaxy/posters/guardiansofthegalaxy_3.jpg" }
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
        }
    }
}