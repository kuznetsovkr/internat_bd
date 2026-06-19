using System;
using System.Collections.Generic;
using internat_bd.Models;

namespace internat_bd.Data
{
    public static class StaticSchoolData
    {
        public static List<NewsItem> News { get; } = new List<NewsItem>
        {
            new NewsItem
            {
                Id = 1,
                Title = "Учебная четверть началась",
                ShortDescription = "В школе-интернате проходят вводные занятия, медицинские осмотры и организационные классные часы.",
                Content = "Воспитанники вернулись к учебным занятиям. Педагоги проводят вводные уроки, а медицинские работники помогают соблюдать оздоровительный режим.",
                PublishDate = new DateTime(2026, 1, 12),
                ImageUrl = "/images/school-building.svg"
            },
            new NewsItem
            {
                Id = 2,
                Title = "День здоровья",
                ShortDescription = "Для воспитанников подготовлены прогулки, спортивные эстафеты и беседы о правильном режиме дня.",
                Content = "В рамках Дня здоровья прошли спортивные и профилактические мероприятия. Учащиеся обсудили важность движения, отдыха и правильного питания.",
                PublishDate = new DateTime(2026, 2, 5),
                ImageUrl = "/images/school-building.svg"
            },
            new NewsItem
            {
                Id = 3,
                Title = "Творческая выставка",
                ShortDescription = "В школьном холле размещены рисунки и поделки учащихся, посвященные природе родного края.",
                Content = "Работы учащихся показывают интерес к природе, школе и семье. Выставка помогает развивать творческие способности воспитанников.",
                PublishDate = new DateTime(2026, 3, 18),
                ImageUrl = "/images/school-building.svg"
            }
        };

        public static List<Employee> Staff { get; } = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                FullName = "Иванова Мария Петровна",
                Position = "Директор",
                Department = "Администрация",
                Phone = "+7 (000) 000-00-01",
                Email = "director@example.ru"
            },
            new Employee
            {
                Id = 2,
                FullName = "Петров Сергей Николаевич",
                Position = "Заместитель директора по учебной работе",
                Department = "Учебная часть",
                Phone = "+7 (000) 000-00-02",
                Email = "study@example.ru"
            },
            new Employee
            {
                Id = 3,
                FullName = "Сидорова Анна Викторовна",
                Position = "Педагог-организатор",
                Department = "Воспитательная работа",
                Phone = "+7 (000) 000-00-03",
                Email = "events@example.ru"
            },
            new Employee
            {
                Id = 4,
                FullName = "Николаева Елена Андреевна",
                Position = "Медицинский работник",
                Department = "Медицинская служба",
                Phone = "+7 (000) 000-00-04",
                Email = "medical@example.ru"
            }
        };

        public static List<EventItem> Events { get; } = new List<EventItem>
        {
            new EventItem
            {
                Id = 1,
                Title = "Классный час о здоровом образе жизни",
                EventDate = new DateTime(2026, 4, 10),
                Place = "Актовый зал",
                Description = "Беседа с учащимися о режиме дня, питании и профилактике заболеваний."
            },
            new EventItem
            {
                Id = 2,
                Title = "Спортивная эстафета",
                EventDate = new DateTime(2026, 4, 22),
                Place = "Спортивная площадка",
                Description = "Командные соревнования для укрепления здоровья и развития взаимопомощи."
            },
            new EventItem
            {
                Id = 3,
                Title = "Конкурс рисунков",
                EventDate = new DateTime(2026, 5, 6),
                Place = "Кабинет изобразительного искусства",
                Description = "Творческое мероприятие на тему природы, школы и семьи."
            }
        };
    }
}
