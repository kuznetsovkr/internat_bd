using System;
using System.Linq;
using internat_bd.Models;
using Microsoft.EntityFrameworkCore;

namespace internat_bd.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.Migrate();

            if (context.SchoolClasses.Any()
                || context.Students.Any()
                || context.Employees.Any()
                || context.NewsItems.Any()
                || context.EventItems.Any()
                || context.DocumentItems.Any()
                || context.Appeals.Any())
            {
                return;
            }

            var class5A = new SchoolClass
            {
                Name = "5А",
                Description = "Учебный класс для обучающихся пятого года обучения."
            };
            var class6A = new SchoolClass
            {
                Name = "6А",
                Description = "Класс среднего звена с оздоровительным режимом дня."
            };
            var class7A = new SchoolClass
            {
                Name = "7А",
                Description = "Класс для обучающихся с углубленной воспитательной поддержкой."
            };
            var class8A = new SchoolClass
            {
                Name = "8А",
                Description = "Класс основной школы с регулярными профилактическими мероприятиями."
            };
            var class9A = new SchoolClass
            {
                Name = "9А",
                Description = "Выпускной класс основной школы."
            };

            context.SchoolClasses.AddRange(class5A, class6A, class7A, class8A, class9A);

            context.Students.AddRange(
                new Student { FullName = "Алексеева Дарья Сергеевна", BirthDate = new DateTime(2014, 3, 12), SchoolClass = class5A },
                new Student { FullName = "Борисов Максим Андреевич", BirthDate = new DateTime(2013, 11, 4), SchoolClass = class5A },
                new Student { FullName = "Кузнецова Полина Игоревна", BirthDate = new DateTime(2014, 6, 25), SchoolClass = class5A },
                new Student { FullName = "Михайлов Артем Павлович", BirthDate = new DateTime(2013, 9, 17), SchoolClass = class6A },
                new Student { FullName = "Соколова Елизавета Романовна", BirthDate = new DateTime(2012, 12, 8), SchoolClass = class6A },
                new Student { FullName = "Федоров Никита Олегович", BirthDate = new DateTime(2013, 2, 20), SchoolClass = class6A },
                new Student { FullName = "Ильина Мария Алексеевна", BirthDate = new DateTime(2012, 5, 14), SchoolClass = class7A },
                new Student { FullName = "Орлов Даниил Викторович", BirthDate = new DateTime(2011, 10, 2), SchoolClass = class7A },
                new Student { FullName = "Павлова Анна Денисовна", BirthDate = new DateTime(2012, 1, 29), SchoolClass = class7A },
                new Student { FullName = "Григорьев Кирилл Михайлович", BirthDate = new DateTime(2011, 4, 7), SchoolClass = class8A },
                new Student { FullName = "Захарова Софья Евгеньевна", BirthDate = new DateTime(2010, 8, 18), SchoolClass = class8A },
                new Student { FullName = "Тимофеев Иван Аркадьевич", BirthDate = new DateTime(2010, 12, 1), SchoolClass = class8A },
                new Student { FullName = "Васильева Ксения Дмитриевна", BirthDate = new DateTime(2009, 7, 9), SchoolClass = class9A },
                new Student { FullName = "Комаров Егор Александрович", BirthDate = new DateTime(2009, 11, 23), SchoolClass = class9A },
                new Student { FullName = "Лебедева Алина Станиславовна", BirthDate = new DateTime(2010, 2, 16), SchoolClass = class9A }
            );

            context.Employees.AddRange(
                new Employee
                {
                    FullName = "Иванова Мария Петровна",
                    Position = "Директор",
                    Department = "Администрация",
                    Phone = "+7 (3012) 00-10-01",
                    Email = "director@school.example"
                },
                new Employee
                {
                    FullName = "Петров Сергей Николаевич",
                    Position = "Заместитель директора по учебной работе",
                    Department = "Учебная часть",
                    Phone = "+7 (3012) 00-10-02",
                    Email = "uch@school.example"
                },
                new Employee
                {
                    FullName = "Смирнова Ольга Викторовна",
                    Position = "Учитель русского языка",
                    Department = "Методическое объединение учителей",
                    Phone = "+7 (3012) 00-10-03",
                    Email = "russian@school.example"
                },
                new Employee
                {
                    FullName = "Никитин Андрей Валерьевич",
                    Position = "Учитель математики",
                    Department = "Методическое объединение учителей",
                    Phone = "+7 (3012) 00-10-04",
                    Email = "math@school.example"
                },
                new Employee
                {
                    FullName = "Сидорова Анна Викторовна",
                    Position = "Воспитатель",
                    Department = "Воспитательная работа",
                    Phone = "+7 (3012) 00-10-05",
                    Email = "vospitatel@school.example"
                },
                new Employee
                {
                    FullName = "Николаева Елена Андреевна",
                    Position = "Медицинская сестра",
                    Department = "Медицинская служба",
                    Phone = "+7 (3012) 00-10-06",
                    Email = "med@school.example"
                },
                new Employee
                {
                    FullName = "Васильева Татьяна Игоревна",
                    Position = "Педагог-психолог",
                    Department = "Служба сопровождения",
                    Phone = "+7 (3012) 00-10-07",
                    Email = "psycholog@school.example"
                },
                new Employee
                {
                    FullName = "Морозов Алексей Геннадьевич",
                    Position = "Социальный педагог",
                    Department = "Служба сопровождения",
                    Phone = "+7 (3012) 00-10-08",
                    Email = "social@school.example"
                }
            );

            context.NewsItems.AddRange(
                new NewsItem
                {
                    Title = "В школе прошел День здоровья",
                    ShortDescription = "Для обучающихся организовали прогулки, эстафеты и беседы о режиме дня.",
                    Content = "Верхнесаянтуйская санаторная школа-интернат провела День здоровья. Учащиеся участвовали в спортивных эстафетах, прогулках и профилактических занятиях.",
                    PublishDate = new DateTime(2026, 2, 6),
                    ImageUrl = "/images/school-building.svg"
                },
                new NewsItem
                {
                    Title = "Профилактическая беседа с медицинской сестрой",
                    ShortDescription = "Ребятам рассказали о личной гигиене, питании и профилактике сезонных заболеваний.",
                    Content = "Медицинская сестра провела встречу с обучающимися среднего звена. Дети обсудили правила личной гигиены, режим сна и важность своевременного обращения за помощью.",
                    PublishDate = new DateTime(2026, 2, 18),
                    ImageUrl = "/images/school-building.svg"
                },
                new NewsItem
                {
                    Title = "Школьное мероприятие ко Дню защитника Отечества",
                    ShortDescription = "В актовом зале прошла тематическая программа с конкурсами и творческими номерами.",
                    Content = "Педагоги и воспитанники подготовили праздничную программу. В мероприятии участвовали классы основной школы.",
                    PublishDate = new DateTime(2026, 2, 24),
                    ImageUrl = "/images/school-building.svg"
                },
                new NewsItem
                {
                    Title = "Спортивный праздник на свежем воздухе",
                    ShortDescription = "Команды классов приняли участие в подвижных играх и командных соревнованиях.",
                    Content = "Спортивный праздник помог ребятам проявить активность, взаимовыручку и интерес к здоровому образу жизни.",
                    PublishDate = new DateTime(2026, 3, 12),
                    ImageUrl = "/images/school-building.svg"
                },
                new NewsItem
                {
                    Title = "Состоялось родительское собрание",
                    ShortDescription = "Педагоги обсудили с родителями учебный процесс, режим дня и планы мероприятий.",
                    Content = "На родительском собрании администрация рассказала о работе школы-интерната, оздоровительном режиме и взаимодействии семьи со специалистами учреждения.",
                    PublishDate = new DateTime(2026, 3, 28),
                    ImageUrl = "/images/school-building.svg"
                }
            );

            context.EventItems.AddRange(
                new EventItem
                {
                    Title = "Классный час о здоровом образе жизни",
                    Description = "Беседа с учащимися о режиме дня, питании и профилактике заболеваний.",
                    EventDate = new DateTime(2026, 4, 10),
                    Place = "Актовый зал"
                },
                new EventItem
                {
                    Title = "Спортивная эстафета между классами",
                    Description = "Командное мероприятие для развития активности и взаимопомощи.",
                    EventDate = new DateTime(2026, 4, 18),
                    Place = "Спортивная площадка"
                },
                new EventItem
                {
                    Title = "Медицинская профилактика простудных заболеваний",
                    Description = "Встреча с медицинской сестрой и разбор правил профилактики.",
                    EventDate = new DateTime(2026, 4, 24),
                    Place = "Медицинский кабинет"
                },
                new EventItem
                {
                    Title = "Конкурс рисунков Родной край",
                    Description = "Творческий конкурс для учащихся 5-9 классов.",
                    EventDate = new DateTime(2026, 5, 6),
                    Place = "Кабинет изобразительного искусства"
                },
                new EventItem
                {
                    Title = "Открытый урок по математике",
                    Description = "Открытое занятие для учащихся 7А класса.",
                    EventDate = new DateTime(2026, 5, 14),
                    Place = "Кабинет математики"
                }
            );

            context.DocumentItems.AddRange(
                new DocumentItem
                {
                    Title = "Правила внутреннего распорядка",
                    Description = "Основные правила поведения обучающихся в школе-интернате.",
                    FileUrl = "/documents/pravila-vnutrennego-rasporyadka.pdf",
                    UploadDate = new DateTime(2026, 1, 10)
                },
                new DocumentItem
                {
                    Title = "Режим дня обучающихся",
                    Description = "Учебный, оздоровительный и воспитательный распорядок дня.",
                    FileUrl = "/documents/rezhim-dnya.pdf",
                    UploadDate = new DateTime(2026, 1, 10)
                },
                new DocumentItem
                {
                    Title = "Положение о приеме обучающихся",
                    Description = "Порядок приема детей в санаторную школу-интернат.",
                    FileUrl = "/documents/polozhenie-o-prieme.pdf",
                    UploadDate = new DateTime(2026, 1, 15)
                },
                new DocumentItem
                {
                    Title = "Памятка для родителей",
                    Description = "Краткие рекомендации для родителей и законных представителей.",
                    FileUrl = "/documents/pamyatka-dlya-roditeley.pdf",
                    UploadDate = new DateTime(2026, 1, 20)
                }
            );

            context.Appeals.AddRange(
                new Appeal
                {
                    FullName = "Андреева Наталья Викторовна",
                    Email = "andreeva@example.ru",
                    Phone = "+7 (900) 000-12-34",
                    Message = "Прошу уточнить список документов для поступления ребенка в школу-интернат.",
                    CreatedAt = new DateTime(2026, 3, 1, 10, 30, 0),
                    Status = "Новое"
                },
                new Appeal
                {
                    FullName = "Семенов Павел Ильич",
                    Email = "semenov@example.ru",
                    Phone = "+7 (900) 000-56-78",
                    Message = "Подскажите, когда состоится ближайшее родительское собрание?",
                    CreatedAt = new DateTime(2026, 3, 9, 14, 15, 0),
                    Status = "В работе"
                },
                new Appeal
                {
                    FullName = "Крылова Оксана Сергеевна",
                    Email = "krylova@example.ru",
                    Phone = "+7 (900) 000-90-12",
                    Message = "Нужна консультация по режиму дня и медицинскому сопровождению обучающихся.",
                    CreatedAt = new DateTime(2026, 3, 16, 9, 45, 0),
                    Status = "Новое"
                }
            );

            context.SaveChanges();
        }
    }
}
