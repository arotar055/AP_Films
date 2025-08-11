using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AP_Films.Models
{
    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public MovieContext(DbContextOptions<MovieContext> o) : base(o)
        {
            if (Database.EnsureCreated() && !Movies.Any())
            {
                Movies.AddRange(
                    new Movie { Title = "The Fast and the Furious", Director = "Rob Cohen", Genre = "Action", Year = 2001, Description = "В фильме недавняя волна угонов грузовиков заставляет О’Коннера, офицера полиции, работать под прикрытием и подружиться с Торетто, местным уличным гонщиком, чтобы расследовать это дело.", Poster = "/images/The Fast and the Furious.jpg" },
                    new Movie { Title = "2 Fast 2 Furious", Director = " John Singleton", Genre = "Action", Year = 2003, Description = "В фильме бывший офицер полиции Лос-Анджелеса Брайан О'Коннер и его друг Роман Пирс (Гибсон) работают под прикрытием для Таможенной службы США и ФБР, чтобы задержать наркобарона в обмен на стирание их судимостей.", Poster = "/images/2 Fast 2 Furious.jpg" },
                    new Movie { Title = "The Fast and the Furious: Tokyo Drift", Director = " Justin Lin", Genre = "Action", Year = 2006, Description = "В фильме абсолютно новые герои и совершенно другая атмосфера (Токио, Япония) по сравнению с предыдущими двумя «Форсажами»..", Poster = "/images/The Fast and the Furious Tokyo Drift.jpg" },
                    new Movie { Title = "Fast & Furious (2009 film)", Director = " Justin Lin", Genre = "Action", Year = 2009, Description = "В фильме Торетто и О'Коннер вынуждены объединиться, чтобы задержать наркобарона, на которого Торетто затаил личную неприязнь.", Poster = "/images/Fast & Furious (2009 film).jpg" },
                    new Movie { Title = "Fast Five", Director = "Justin Lin", Genre = "Action", Year = 2011, Description = "В фильме Доминик Торетто и Брайан О’Коннер набирают команду, чтобы украсть 100 миллионов долларов у коррумпированного бизнесмена", Poster = "/Fast Five.jpg" },
                    new Movie { Title = "Fast & Furious 6", Director = "Justin Lin", Genre = "Action", Year = 2013, Description = "В фильме Торетто, О'Коннер и их команда получают помилование за свои преступления, помогая агенту DSS Люку Хоббсу задержать группу наёмников, одним из членов которой является предполагаемая покойная любовница Торетто", Poster = "/images/Fast & Furious 6.jpg" },
                    new Movie { Title = "Furious 7", Director = "Justin Lin", Genre = "Action", Year = 2015, Description = "Получив амнистию за свои прошлые преступления, Доминик, Брайан и остальная часть их команды возвращаются в США, чтобы жить нормальной жизнью", Poster = "/images/Furious 7.jpg" },
                    new Movie { Title = "The Fate of the Furious", Director = "Justin Lin", Genre = "Action", Year = 2017, Description = "В фильме Доминик Торетто поселился со своей женой Летти Ортис, пока кибертеррористка Сайфер не принуждает его работать на неё и не настраивает его против своей команды.", Poster = "/images/The Fate of the Furious.jpg" },
                    new Movie { Title = "F9: The Fast Saga", Director = "Justin Lin", Genre = "Action", Year = 2021, Description = "В фильме Торетто и его команда объединяются, чтобы остановить всемирный заговор, возглавляемый его младшим братом Джейкобом.", Poster = "/images/F9 The Fast Saga.jpg" },
                    new Movie { Title = "Fast X ", Director = "Louis Leterrier", Genre = "Action", Year = 2023, Description = "Агентство просит Доминика Торетто и его команду украсть компьютерный чип во время его перевозки в Риме.", Poster = "/images/Fast X.jpg" }
                );
                SaveChanges();
            }
        }
    }
}