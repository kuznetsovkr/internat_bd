/*
    SQL-скрипты для отчета по базе данных учебного проекта
    "Верхнесаянтуйская санаторная школа-интернат".

    Важно:
    - файл подготовлен для включения в отчет по практике;
    - файл не подключен к запуску приложения;
    - рабочая база проекта изменяется через Entity Framework Core и миграции;
    - перед выполнением этого файла в отдельной учебной базе убедитесь,
      что это не рабочий файл school.db.
*/

PRAGMA foreign_keys = ON;

-- ============================================================
-- 1. Создание таблиц для SQLite
-- ============================================================

-- Таблица классов школы-интерната.
CREATE TABLE IF NOT EXISTS SchoolClasses (
    Id INTEGER NOT NULL CONSTRAINT PK_SchoolClasses PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    Description TEXT NULL
);

-- Таблица учеников. Поле SchoolClassId связано с таблицей SchoolClasses.
CREATE TABLE IF NOT EXISTS Students (
    Id INTEGER NOT NULL CONSTRAINT PK_Students PRIMARY KEY AUTOINCREMENT,
    FullName TEXT NOT NULL,
    BirthDate TEXT NOT NULL,
    SchoolClassId INTEGER NOT NULL,
    CONSTRAINT FK_Students_SchoolClasses_SchoolClassId
        FOREIGN KEY (SchoolClassId)
        REFERENCES SchoolClasses (Id)
        ON DELETE CASCADE
);

CREATE INDEX IF NOT EXISTS IX_Students_SchoolClassId
ON Students (SchoolClassId);

-- Таблица сотрудников.
CREATE TABLE IF NOT EXISTS Employees (
    Id INTEGER NOT NULL CONSTRAINT PK_Employees PRIMARY KEY AUTOINCREMENT,
    FullName TEXT NOT NULL,
    Position TEXT NOT NULL,
    Department TEXT NULL,
    Phone TEXT NULL,
    Email TEXT NULL
);

-- Таблица новостей.
CREATE TABLE IF NOT EXISTS NewsItems (
    Id INTEGER NOT NULL CONSTRAINT PK_NewsItems PRIMARY KEY AUTOINCREMENT,
    Title TEXT NOT NULL,
    ShortDescription TEXT NOT NULL,
    Content TEXT NOT NULL,
    PublishDate TEXT NOT NULL,
    ImageUrl TEXT NULL
);

-- Таблица мероприятий.
CREATE TABLE IF NOT EXISTS EventItems (
    Id INTEGER NOT NULL CONSTRAINT PK_EventItems PRIMARY KEY AUTOINCREMENT,
    Title TEXT NOT NULL,
    Description TEXT NOT NULL,
    EventDate TEXT NOT NULL,
    Place TEXT NULL
);

-- Таблица обращений посетителей.
CREATE TABLE IF NOT EXISTS Appeals (
    Id INTEGER NOT NULL CONSTRAINT PK_Appeals PRIMARY KEY AUTOINCREMENT,
    FullName TEXT NOT NULL,
    Email TEXT NULL,
    Phone TEXT NULL,
    Message TEXT NOT NULL,
    CreatedAt TEXT NOT NULL,
    Status TEXT NOT NULL
);

-- Таблица документов.
CREATE TABLE IF NOT EXISTS DocumentItems (
    Id INTEGER NOT NULL CONSTRAINT PK_DocumentItems PRIMARY KEY AUTOINCREMENT,
    Title TEXT NOT NULL,
    Description TEXT NULL,
    FileUrl TEXT NOT NULL,
    UploadDate TEXT NOT NULL
);

-- ============================================================
-- 2. Наполнение тестовыми данными
-- ============================================================

-- Классы.
INSERT INTO SchoolClasses (Id, Name, Description) VALUES
(1, '5А', 'Учебный класс для обучающихся пятого года обучения.'),
(2, '6А', 'Класс среднего звена с оздоровительным режимом дня.');

-- Ученики.
INSERT INTO Students (FullName, BirthDate, SchoolClassId) VALUES
('Алексеева Дарья Сергеевна', '2014-03-12', 1),
('Борисов Максим Андреевич', '2013-11-04', 1),
('Михайлов Артем Павлович', '2013-09-17', 2);

-- Сотрудники.
INSERT INTO Employees (FullName, Position, Department, Phone, Email) VALUES
('Иванова Мария Петровна', 'Директор', 'Администрация', '+7 (3012) 00-10-01', 'director@school.example'),
('Петров Сергей Николаевич', 'Заместитель директора по учебной работе', 'Учебная часть', '+7 (3012) 00-10-02', 'uch@school.example');

-- Новости.
INSERT INTO NewsItems (Title, ShortDescription, Content, PublishDate, ImageUrl) VALUES
('В школе прошел День здоровья',
 'Для обучающихся организовали прогулки, эстафеты и беседы о режиме дня.',
 'Верхнесаянтуйская санаторная школа-интернат провела День здоровья.',
 '2026-02-06',
 '/images/school-building.svg'),
('Профилактическая беседа',
 'Ребятам рассказали о личной гигиене и профилактике сезонных заболеваний.',
 'Медицинская сестра провела встречу с обучающимися среднего звена.',
 '2026-02-18',
 '/images/school-building.svg');

-- Мероприятие.
INSERT INTO EventItems (Title, Description, EventDate, Place) VALUES
('Классный час о здоровом образе жизни',
 'Беседа с учащимися о режиме дня, питании и профилактике заболеваний.',
 '2026-04-10',
 'Актовый зал');

-- Документ.
INSERT INTO DocumentItems (Title, Description, FileUrl, UploadDate) VALUES
('Правила внутреннего распорядка',
 'Основные правила поведения обучающихся в школе-интернате.',
 '/documents/pravila-vnutrennego-rasporyadka.pdf',
 '2026-01-10');

-- Обращение.
INSERT INTO Appeals (FullName, Email, Phone, Message, CreatedAt, Status) VALUES
('Андреева Наталья Викторовна',
 'andreeva@example.ru',
 '+7 (900) 000-12-34',
 'Прошу уточнить список документов для поступления ребенка в школу-интернат.',
 '2026-03-01 10:30:00',
 'Новое');

-- ============================================================
-- 3. Примеры SELECT-запросов
-- ============================================================

-- Получить список всех учеников с названием класса.
SELECT
    Students.Id,
    Students.FullName,
    Students.BirthDate,
    SchoolClasses.Name AS ClassName
FROM Students
INNER JOIN SchoolClasses ON SchoolClasses.Id = Students.SchoolClassId
ORDER BY SchoolClasses.Name, Students.FullName;

-- Получить новости по дате публикации, начиная с новых.
SELECT
    Id,
    Title,
    ShortDescription,
    PublishDate
FROM NewsItems
ORDER BY PublishDate DESC;

-- Получить обращения со статусом "Новое".
SELECT
    Id,
    FullName,
    Email,
    Phone,
    Message,
    CreatedAt,
    Status
FROM Appeals
WHERE Status = 'Новое'
ORDER BY CreatedAt DESC;

-- Получить количество учеников по классам.
SELECT
    SchoolClasses.Name AS ClassName,
    COUNT(Students.Id) AS StudentsCount
FROM SchoolClasses
LEFT JOIN Students ON Students.SchoolClassId = SchoolClasses.Id
GROUP BY SchoolClasses.Id, SchoolClasses.Name
ORDER BY SchoolClasses.Name;

-- ============================================================
-- 4. Триггеры SQLite
-- ============================================================

-- Триггер автоматически ставит статус "Новое" при добавлении обращения,
-- если статус не указан или передана пустая строка.
CREATE TRIGGER IF NOT EXISTS TR_Appeals_SetDefaultStatus
AFTER INSERT ON Appeals
FOR EACH ROW
WHEN NEW.Status IS NULL OR TRIM(NEW.Status) = ''
BEGIN
    UPDATE Appeals
    SET Status = 'Новое'
    WHERE Id = NEW.Id;
END;

-- Триггер автоматически заполняет дату создания обращения текущей датой и временем,
-- если при добавлении записи дата не указана или передана пустая строка.
CREATE TRIGGER IF NOT EXISTS TR_Appeals_SetCreatedAt
AFTER INSERT ON Appeals
FOR EACH ROW
WHEN NEW.CreatedAt IS NULL OR TRIM(NEW.CreatedAt) = ''
BEGIN
    UPDATE Appeals
    SET CreatedAt = datetime('now')
    WHERE Id = NEW.Id;
END;

-- Дополнительный пример: триггер заполняет дату публикации новости текущей датой,
-- если дата публикации не указана или передана пустая строка.
CREATE TRIGGER IF NOT EXISTS TR_NewsItems_SetPublishDate
AFTER INSERT ON NewsItems
FOR EACH ROW
WHEN NEW.PublishDate IS NULL OR TRIM(NEW.PublishDate) = ''
BEGIN
    UPDATE NewsItems
    SET PublishDate = date('now')
    WHERE Id = NEW.Id;
END;

-- ============================================================
-- 5. Учебные аналоги хранимых процедур
-- ============================================================

/*
    В используемой СУБД SQLite хранимые процедуры не поддерживаются.
    Для демонстрации логики обработки данных в учебном проекте используются
    параметризованные запросы Entity Framework Core и SQL-запросы, приведенные ниже.
*/

-- Аналог процедуры: получение учеников выбранного класса.
-- Параметр :classId передается из приложения.
SELECT
    Students.Id,
    Students.FullName,
    Students.BirthDate,
    SchoolClasses.Name AS ClassName
FROM Students
INNER JOIN SchoolClasses ON SchoolClasses.Id = Students.SchoolClassId
WHERE Students.SchoolClassId = :classId
ORDER BY Students.FullName;

-- Аналог процедуры: изменение статуса обращения.
-- Параметры :appealId и :newStatus передаются из приложения.
UPDATE Appeals
SET Status = :newStatus
WHERE Id = :appealId;

-- Аналог процедуры: получение списка мероприятий за период.
-- Параметры :dateFrom и :dateTo передаются из приложения.
SELECT
    Id,
    Title,
    Description,
    EventDate,
    Place
FROM EventItems
WHERE EventDate BETWEEN :dateFrom AND :dateTo
ORDER BY EventDate;
