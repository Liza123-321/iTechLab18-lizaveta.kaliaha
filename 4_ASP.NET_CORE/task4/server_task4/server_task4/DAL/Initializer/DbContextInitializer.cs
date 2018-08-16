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
            new Film { Id = 1,Name= "Атлантида", AverageRating=5.9, Country="Испания", Year=2017, Description= "События разворачиваются в 1914 году, сразу после убийства Франца Фердинанда, которое повлекло за собой Первую мировую войну. К одинокому пустынному острову, расположенному у Южного полярного круга, подплывает пароход. На нем на остров прибывает новый метеоролог, чтобы занять свой пост и жить там целый год, пока ему не привезут человека на смену. На острове кроме него есть еще один человек – смотритель маяка, угрюмый затворник Грюнер. От него герой узнает, что предыдущий метеоролог умер от тифа какое-то время назад. Однако вскоре герой поймет, что с виду тихий остров на самом деле очень опасен по ночам. Ведь именно в это время из моря на берег выходят представители неизвестной расы, которые боятся любого вида света. Каждую ночь они совершают нападения на маяк, чтобы потушить его.", Producer= "Ксавье Жанс", Poster= "https://st.kp.yandex.net/images/film_big/678639.jpg" });
        }
    }
}