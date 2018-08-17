using Microsoft.EntityFrameworkCore;
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
            new Film { Id = 2, Name = "Мстители", AverageRating = 8.6, Country = "Marvel", Year = 2018, Description = "В то время как Мстители и их союзники неустанно защищают мир от всевозможных опасностей, к ним из космоса подбирается новая угроза – Танос. Этот беспощадный тиран одержим своей целью – собрать все шесть Камней Бесконечности, уникальные артефакты, обладающие невиданной силой, с помощью которых он сможет изменить реальность и сделать ее такой, какой захочет. Все, с чем боролись Мстители ранее, вело именно к этому моменту. Судьба Земли и самой жизни стоит на кону.", Producer = "Энтони Руссо, Джо Руссо", Poster = "https://b1.filmpro.ru/c/528084.jpg" },
            new Film { Id = 3, Name = "Гоголь.Начало", AverageRating = 5.7, Country = "Россия", Year = 2017, Description = "Фильм рассказывает о юном Николае Гоголе, который в 1829 году только начинает пробовать себя в литературе. Однако он слишком критичен к своему творчеству и потому сжигает все, что пишет. Неожиданно он знакомится со следователем Яковом Гуро. Яков отбывает из Петербурга в село Диканька, чтобы расследовать происходящие там странные события. И Гоголь напрашивается к нему в помощники, чтобы написать об этом роман. Производство – канал ТВ-3 и продюсерская компания «Среда».", Producer = "Егор Баранов", Poster = "http://www.cyprusmoms.com/wp-content/uploads/2017/09/21587048_941712105967370_5415383322108884044_o.jpg" }
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