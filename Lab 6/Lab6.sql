-- 1. (#15)  Напишите SQL запросы  для решения задач ниже.
--   1) Тактовые частоты CPU тех компьютеров, у которых объем
--   памяти 3000 Мб. Вывод: id, cpu, memory
        SELECT id, cpu, memory
          FROM PC
         WHERE memory = 3000
        ORDER BY id;
--   2) Минимальный объём жесткого диска, установленного в
--   компьютере на складе. Вывод: hdd
        SELECT MIN(hdd)
          FROM PC;
--   3) Количество компьютеров с минимальным объемом жесткого диска,
--   доступного на складе. Вывод: count, hdd
        SELECT COUNT (id), (SELECT MIN(hdd) FROM PC) AS min_hdd
          FROM PC
         WHERE min_hdd = hdd;

-- 2. (#30) Есть таблица следующего вида:
      CREATE TABLE track_downloads (
        download_id INTEGER PRIMARY KEY AUTOINCREMENT,
        track_id INT NOT NULL,
        user_id BIGINT(20) NOT NULL,
        download_time TIMESTAMP NOT NULL DEFAULT 0
      );

      INSERT INTO track_downloads
        (track_id, user_id, download_time)
      VALUES
        (4749, 383, '2010-11-19'),
        (4643, 383, '2010-11-19'),
        (844, 232, '2010-11-12'),
        (22, 4949, '2011-03-15'),
        (12, 84, '2010-02-02'),
        (885, 2323, '2010-11-19');

  -- Напишите SQL-запрос, возвращающий все пары (download_count, user_count),
  -- удовлетворяющие следующему условию:
  -- user_count — общее ненулевое число пользователей, сделавших
  -- ровно download_count скачиваний 19 ноября 2010 года.
    SELECT COUNT(download_id) AS download_count, COUNT(DISTINCT user_id) AS user_count
      FROM track_downloads
     WHERE download_time = '2010-11-19';

-- 3. (#10) Опишите разницу типов данных DATETIME и TIMESTAMP
    /*
    DATETIME
Хранит время в виде целого числа вида YYYYMMDDHHMMSS, используя для этого 8 байтов. 
Это время не зависит от временной зоны. Оно всегда отображается при выборке точно так же,
 как было сохранено, независимо от того какой часовой пояс установлен в MySQL
 
 TIMESTAMP
Хранит 4-байтное целое число, равное количеству секунд, прошедших с полуночи 1 января 1970 года 
по усреднённому времени Гринвича (т.е. нулевой часовой пояс, точка отсчёта часовых поясов). 
При получении из базы отображается с учётом часового пояса.
*/

-- 4. (#20) Необходимо создать таблицу студентов (поля id, name) и таблицу курсов (поля id, name).
-- Каждый студент может посещать несколько курсов. Названия курсов и имена студентов - произвольны.
    CREATE TABLE student
    (
      id INTEGER
        CONSTRAINT student_pk
          PRIMARY KEY AUTOINCREMENT,
      name TEXT NOT NULL
    );

    CREATE TABLE course
    (
      id INTEGER
        CONSTRAINT course_pk
          PRIMARY KEY AUTOINCREMENT,
      name TEXT NOT NULL
    );

    CREATE TABLE student_x_course
    (
      id_student INTEGER,
      id_course INTEGER
    );

    INSERT INTO student (name)
    VALUES ('Иван'),
           ('Петр'),
           ('Илья'),
           ('Ибрагим'),
           ('Саша'),
           ('Женя');

    INSERT INTO course
      (name)
    VALUES ('ИВТ'),
           ('ПС'),
           ('БИс');

    INSERT INTO student_x_course
    VALUES (1, 1),
           (1, 2),
           (2, 1),
           (2, 2),
           (2, 3),
           (3, 1),
           (3, 3),
           (4, 1),
           (4, 3),
           (5, 2),
           (5, 1),
           (6, 1);

--   Написать SQL запросы:
--     1. отобразить количество курсов, на которые ходит более 5 студентов
        SELECT COUNT(course.id)
          FROM student_x_course
            LEFT JOIN student ON student.id = student_x_course.id_student
            LEFT JOIN course ON course.id = student_x_course.id_course
        GROUP BY course.name
        HAVING COUNT(student.id) > 5;

--     2. отобразить все курсы, на которые записан определенный студент.
        SELECT student.name, course.name
          FROM student_x_course
            LEFT JOIN student ON student.id = student_x_course.id_student
            LEFT JOIN course ON course.id = student_x_course.id_course
        WHERE student.name = 'Саша';



--   7. (#10) Есть две таблицы:
--     users - таблица с пользователями (users_id, name)
--     orders - таблица с заказами (orders_id, users_id, status)
      create table users
      (
        users_id INTEGER
          constraint users_pk
            primary key,
        name TEXT
      );

      create table orders
      (
        orders_id INTEGER
          constraint orders_pk
            primary key,
        users_id INTEGER
          constraint orders_users_users_id_fk
            references users,
        status INTEGER
      );

      INSERT INTO users (users_id, name)
      VALUES
         (1, 'Иван'),
         (2, 'Петр'),
         (3, 'Илья'),
         (4, 'Ибрагим'),
         (5, 'Саша'),
         (6, 'Женя');

      INSERT INTO orders (orders_id, users_id, status)
      VALUES
         (1, 1, 1),
         (2, 3, 1),
         (3, 1, 0),
         (4, 3, 0),
         (5, 1, 1),
         (6, 6, 0),
         (7, 6, 0),
         (8, 6, 0),
         (9, 2, 1),
         (10, 4, 1),
         (11, 5, 1),
         (12, 1, 1),
         (13, 1, 1),
         (14, 1, 1),
         (15, 1, 1);

--     1) Выбрать всех пользователей из таблицы users,
--     у которых ВСЕ записи в таблице orders имеют status = 0
        SELECT users.name
          FROM users
        EXCEPT
          SELECT users.name
            FROM users
              LEFT JOIN orders o ON users.users_id = o.users_id
           WHERE status != 0;

--     2) Выбрать всех пользователей из таблицы users,
--     у которых больше 5 записей в таблице orders имеют status = 1
        SELECT users.name, COUNT(orders.orders_id) AS orders_count
          FROM users
            LEFT JOIN orders ON orders.users_id = users.users_id
         WHERE orders.status = 1
        GROUP BY orders.users_id
        HAVING orders_count > 5;

-- 8. (#10)  В чем различие между выражениями HAVING и WHERE?
  /*
  WHERE - это ограничивающее выражение. Оно выполняется до того, как будет получен результат операции.

HAVING - фильтрующее выражение. Оно применяется к результату операции и выполняется уже после того
 как этот результат будет получен, в отличии от where.
Выражения WHERE используются вместе с операциями SELECT, UPDATE, DELETE, в то время как 
HAVING только с SELECT и предложением GROUP BY.
Например, WHERE нельзя использовать таким образом:
SELECT name, SUM(salary) FROM Employees WHERE SUM(salary) > 1000 GROUP BY name 
В данном случае больше подходит HAVING:
SELECT name, SUM(salary) FROM Employees GROUP BY name HAVING SUM(salary) > 1000 
То есть, использовать WHERE в запросах с агрегатными функциями нельзя, для этого и был введен HAVING.
  */