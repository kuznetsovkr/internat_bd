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
                Summary = "В школе-интернате проходят вводные занятия, медицинские осмотры и организационные классные часы.",
                PublishedAt = new DateTime(2026, 1, 12)
            },
            new NewsItem
            {
                Id = 2,
                Title = "День здоровья",
                Summary = "Для воспитанников подготовлены прогулки, спортивные эстафеты и беседы о правильном режиме дня.",
                PublishedAt = new DateTime(2026, 2, 5)
            },
            new NewsItem
            {
                Id = 3,
                Title = "Творческая выставка",
                Summary = "В школьном холле размещены рисунки и поделки учащихся, посвященные природе родного края.",
                PublishedAt = new DateTime(2026, 3, 18)
            }
        };

        public static List<StaffMember> Staff { get; } = new List<StaffMember>
        {
            new StaffMember
            {
                FullName = "Иванова Мария Петровна",
                Position = "Директор",
                Description = "Организует работу школы-интерната и взаимодействие с родителями."
            },
            new StaffMember
            {
                FullName = "Петров Сергей Николаевич",
                Position = "Заместитель директора по учебной работе",
                Description = "Отвечает за расписание, образовательные программы и методическую работу."
            },
            new StaffMember
            {
                FullName = "Сидорова Анна Викторовна",
                Position = "Педагог-организатор",
                Description = "Проводит воспитательные мероприятия, конкурсы и тематические встречи."
            },
            new StaffMember
            {
                FullName = "Николаева Елена Андреевна",
                Position = "Медицинский работник",
                Description = "Следит за оздоровительным режимом и самочувствием воспитанников."
            }
        };

        public static List<SchoolEvent> Events { get; } = new List<SchoolEvent>
        {
            new SchoolEvent
            {
                Title = "Классный час о здоровом образе жизни",
                Date = new DateTime(2026, 4, 10),
                Place = "Актовый зал",
                Description = "Беседа с учащимися о режиме дня, питании и профилактике заболеваний."
            },
            new SchoolEvent
            {
                Title = "Спортивная эстафета",
                Date = new DateTime(2026, 4, 22),
                Place = "Спортивная площадка",
                Description = "Командные соревнования для укрепления здоровья и развития взаимопомощи."
            },
            new SchoolEvent
            {
                Title = "Конкурс рисунков",
                Date = new DateTime(2026, 5, 6),
                Place = "Кабинет изобразительного искусства",
                Description = "Творческое мероприятие на тему природы, школы и семьи."
            }
        };
    }
}
