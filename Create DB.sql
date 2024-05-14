create table Groups(
id int not null identity constraint PK_Groups primary key,
direction varchar(5),
spec varchar(10),
course int,
number int);

create table Students(
numStud int not null constraint PK_Students primary key,
surname varchar(50),
name varchar(50),
lastname varchar(50),
email varchar(50),
idGroup int not null constraint FK_Group foreign key references Groups(id)
	on update cascade
	on delete cascade);


create table Accounts(
id int not null identity constraint PK_Account primary key,
idStudent int not null constraint FK_Student foreign key references Students(numStud)
	on update cascade
	on delete cascade,
password varchar(50),
points int);


create table Achievements(
id int not null identity constraint PK_Achievement primary key,
title varchar(100),
description varchar(1000),
reward int,
image varchar(200));


create table StudentsAndAchievements(
id int not null identity constraint PK_StudentsAndAchievements primary key,
idAccount int not null constraint FK_Account foreign key references Accounts(id)
	on update cascade
	on delete cascade,
idAchievement int not null constraint FK_Achievement foreign key references Achievements(id)
	on update cascade
	on delete cascade,
dateReceipt date,
receipt bit);


create table Awards(
id int not null identity constraint PK_Award primary key,
title varchar(100),
description varchar(1000),
cost int);


create table StudentsAndAwards(
id int not null identity constraint PK_StudentsAndAwards primary key,
idAccount int not null constraint FK_AccountStudentsAndAwards foreign key references Accounts(id)
	on update cascade
	on delete cascade,
idAward int not null constraint FK_AwardStudentsAndAwards foreign key references Awards(id)
	on update cascade
	on delete cascade,
promocode varchar(30),
isActive bit);


insert into Groups values ('Б1', 'ИФСТ', 2, 2);
insert into Groups values ('Б2', 'ИФСТ', 2, 1);
insert into Groups values ('Б1', 'ИВЧТ', 3, 1);
insert into Groups values ('Б1', 'AТПП', 2, 1);
insert into Groups values ('Б1', 'МВТМ', 1, 1);
insert into Groups values ('Б1', 'РТХН', 3, 2);

insert into Students values (220798, 'Карпенко', 'Никита', 'Алексеевич', 'nik@yandex.ru', 1);
insert into Students values (222953, 'Парамонова', 'Анна', 'Сергеевна', 'annya@mail.ru', 2);
insert into Students values (225235, 'Сиркова', 'Ольга', 'Геннадиевна', 'sir1956@yandex.ru', 4);
insert into Students values (223457, 'Романов', 'Игорь', 'Владимирович', 'igor1918@mail.ru', 4);
insert into Students values (234564, 'Звягинцев', 'Сергей', 'Петрович', 'sergey@mail.ru', 5);
insert into Students values (223056, 'Николаева', 'Алена', 'Алексеевна', 'alenyaalenya@mail.ru', 2);
insert into Students values (220563, 'Романчук', 'Петр', 'Андреевич', 'petyaRylit@mail.ru', 3);
insert into Students values (229345, 'Гудкова', 'Анна', 'Геннадиевна', 'anna1919@yandex.ru', 3);
insert into Students values (220345, 'Дудник', 'Вячеслав', 'Андреевич', 'vacheslav@mail.ru', 5);
insert into Students values (223053, 'Муленко', 'Виктория', 'Тимуровна', 'vika1123@yandex.ru', 6);
insert into Students values (234235, 'Константинов', 'Виктор', 'Павлович', 'vita228@yandex.ru', 1);
insert into Students values (223543, 'Боброва', 'Ольга', 'Юрьевна', 'olgavolockova@yandex.ru', 6);
insert into Students values (223456, 'Кузакин', 'Артем', 'Васильевич', 'art5321@mail.ru', 3);
insert into Students values (224233, 'Ячменков', 'Сергей', 'Владимирович', 'nser2023@yandex.ru', 4);

insert into Accounts values (220798, '5123', 0);
insert into Accounts values (223457, '1111', 0);
insert into Accounts values (223456, '1012', 0);
insert into Accounts values (220345, '4800', 0);

insert into Achievements values('Я отличник', 'Закрыть семестр на отлично', 50, '/Images/ach1.png');
insert into Achievements values('Я ударник', 'Закрыть семестр без троек', 25, '/Images/ach2.png');
insert into Achievements values('Студенческая весна', 'Участие в студенческой весне', 5, '/Images/NotReceived.png');
insert into Achievements values('Я уборщик', 'Участие в субботнике', 3, '/Images/ach3.png');
insert into Achievements values('Не прогульщик', 'Ни одного прогула за месяц', 3, '/Images/NotReceived.png');
insert into Achievements values('Волонтёр', 'Участие на мероприятии волонтером', 2, '/Images/ach2.png');
insert into Achievements values('Активист', 'Участие в 3 мероприятиях', 15, '/Images/NotReceived.png');
insert into Achievements values('Хакатонщик', 'Участие в хакатоне', 30, '/Images/NotReceived.png');

insert into Awards values('Проездной мини', '4 поездки на общественном транспорте', 10);
insert into Awards values('Проездной медиум', '6 поездок на общественном транспорте', 15);
insert into Awards values('Проездной макс', '10 поездок на общественном транспорте', 30);
insert into Awards values('Завтрак', 'Завтрак в столовой', 10);
insert into Awards values('Обед', 'Обед в столовой', 15);
insert into Awards values('Сосиска в тесте', 'Сосиска в тесте', 3);
insert into Awards values('Очередь', 'Первый в очереди в столовую неделю', 10);
