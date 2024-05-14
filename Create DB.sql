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


insert into Groups values ('�1', '����', 2, 2);
insert into Groups values ('�2', '����', 2, 1);
insert into Groups values ('�1', '����', 3, 1);
insert into Groups values ('�1', 'A���', 2, 1);
insert into Groups values ('�1', '����', 1, 1);
insert into Groups values ('�1', '����', 3, 2);

insert into Students values (220798, '��������', '������', '����������', 'nik@yandex.ru', 1);
insert into Students values (222953, '����������', '����', '���������', 'annya@mail.ru', 2);
insert into Students values (225235, '�������', '�����', '�����������', 'sir1956@yandex.ru', 4);
insert into Students values (223457, '�������', '�����', '������������', 'igor1918@mail.ru', 4);
insert into Students values (234564, '���������', '������', '��������', 'sergey@mail.ru', 5);
insert into Students values (223056, '���������', '�����', '����������', 'alenyaalenya@mail.ru', 2);
insert into Students values (220563, '��������', '����', '���������', 'petyaRylit@mail.ru', 3);
insert into Students values (229345, '�������', '����', '�����������', 'anna1919@yandex.ru', 3);
insert into Students values (220345, '������', '��������', '���������', 'vacheslav@mail.ru', 5);
insert into Students values (223053, '�������', '��������', '���������', 'vika1123@yandex.ru', 6);
insert into Students values (234235, '������������', '������', '��������', 'vita228@yandex.ru', 1);
insert into Students values (223543, '�������', '�����', '�������', 'olgavolockova@yandex.ru', 6);
insert into Students values (223456, '�������', '�����', '����������', 'art5321@mail.ru', 3);
insert into Students values (224233, '��������', '������', '������������', 'nser2023@yandex.ru', 4);

insert into Accounts values (220798, '5123', 0);
insert into Accounts values (223457, '1111', 0);
insert into Accounts values (223456, '1012', 0);
insert into Accounts values (220345, '4800', 0);

insert into Achievements values('� ��������', '������� ������� �� �������', 50, '/Images/ach1.png');
insert into Achievements values('� �������', '������� ������� ��� �����', 25, '/Images/ach2.png');
insert into Achievements values('������������ �����', '������� � ������������ �����', 5, '/Images/NotReceived.png');
insert into Achievements values('� �������', '������� � ����������', 3, '/Images/ach3.png');
insert into Achievements values('�� ����������', '�� ������ ������� �� �����', 3, '/Images/NotReceived.png');
insert into Achievements values('�������', '������� �� ����������� ����������', 2, '/Images/ach2.png');
insert into Achievements values('��������', '������� � 3 ������������', 15, '/Images/NotReceived.png');
insert into Achievements values('����������', '������� � ��������', 30, '/Images/NotReceived.png');

insert into Awards values('��������� ����', '4 ������� �� ������������ ����������', 10);
insert into Awards values('��������� ������', '6 ������� �� ������������ ����������', 15);
insert into Awards values('��������� ����', '10 ������� �� ������������ ����������', 30);
insert into Awards values('�������', '������� � ��������', 10);
insert into Awards values('����', '���� � ��������', 15);
insert into Awards values('������� � �����', '������� � �����', 3);
insert into Awards values('�������', '������ � ������� � �������� ������', 10);
