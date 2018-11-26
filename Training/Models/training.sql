CREATE TABLE "Trainee" (
	"Id" serial NOT NULL,
	"Name" varchar(50) NOT NULL UNIQUE,
	CONSTRAINT Trainee_pk PRIMARY KEY ("Id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "Training" (
	"Id" serial NOT NULL,
	"Name" varchar(100) NOT NULL UNIQUE,
	"Descr" varchar(4096) NOT NULL UNIQUE,
	"Program" varchar(8192),
	"Duration" int NOT NULL,
	CONSTRAINT Training_pk PRIMARY KEY ("Id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "TrainingCurrent" (
	"Id" serial NOT NULL,
	"Training" bigint NOT NULL,
	"TrainingId" varchar(36) NOT NULL UNIQUE,
	CONSTRAINT TrainingCurrent_pk PRIMARY KEY ("Id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "Trainer" (
	"Id" serial NOT NULL,
	"Name" varchar(50) NOT NULL UNIQUE,
	"Descr" varchar(1024) NOT NULL UNIQUE,
	CONSTRAINT Trainer_pk PRIMARY KEY ("Id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "Dates" (
	"Id" serial NOT NULL,
	"Day" DATE NOT NULL UNIQUE,
	CONSTRAINT Dates_pk PRIMARY KEY ("Id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "TrainingCurrentDates" (
	"TrainingCurrent" bigint NOT NULL,
	"Dates" bigint NOT NULL
) WITH (
  OIDS=FALSE
);



CREATE TABLE "TrainingGroup" (
	"Id" serial NOT NULL,
	"Name" varchar(100) NOT NULL UNIQUE,
	CONSTRAINT TrainingGroup_pk PRIMARY KEY ("Id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "TrainingGroupTraining" (
	"TrainingGroup" bigint NOT NULL,
	"Training" bigint NOT NULL
) WITH (
  OIDS=FALSE
);



CREATE TABLE "TraineeCurrent" (
	"Trainee" bigint NOT NULL,
	"TrainingCurrent" bigint NOT NULL,
	"Id" serial NOT NULL,
	"TraineeId" varchar(36) NOT NULL UNIQUE,
	CONSTRAINT TraineeCurrent_pk PRIMARY KEY ("Id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "TraineeCurrentDates" (
	"TraineeCurrent" bigint NOT NULL,
	"Dates" bigint NOT NULL
) WITH (
  OIDS=FALSE
);



CREATE TABLE "TrainerCurrent" (
	"Trainer" bigint NOT NULL,
	"TrainingCurrent" bigint NOT NULL,
	"Id" serial NOT NULL,
	"TrainerId" varchar(36) NOT NULL UNIQUE,
	CONSTRAINT TrainerCurrent_pk PRIMARY KEY ("Id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "TrainerCurrentDates" (
	"TrainerCurrent" bigint NOT NULL,
	"Dates" bigint NOT NULL
) WITH (
  OIDS=FALSE
);



CREATE TABLE "Test" (
	"Id" serial NOT NULL,
	"Name" varchar NOT NULL UNIQUE,
	"Training" bigint NOT NULL,
	"Duration" int,
	CONSTRAINT Test_pk PRIMARY KEY ("Id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "Quest" (
	"Id" serial NOT NULL,
	"Name" varchar(4096) NOT NULL UNIQUE,
	"QuestType" bigint NOT NULL,
	"Duration" int,
	CONSTRAINT Quest_pk PRIMARY KEY ("Id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "TestQuest" (
	"Test" bigint NOT NULL,
	"Quest" bigint NOT NULL
) WITH (
  OIDS=FALSE
);



CREATE TABLE "TestCurrent" (
	"Id" serial NOT NULL,
	"TestId" varchar(36) NOT NULL UNIQUE,
	"Test" bigint NOT NULL,
	"TraineeCurrent" bigint NOT NULL,
	"Started" DATE,
	CONSTRAINT TestCurrent_pk PRIMARY KEY ("Id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "TestCurrentDates" (
	"TestCurrent" bigint NOT NULL,
	"Dates" bigint NOT NULL
) WITH (
  OIDS=FALSE
);



CREATE TABLE "QuestTestCurrent" (
	"Quest" bigint NOT NULL,
	"TestCurrent" bigint NOT NULL,
	"Id" serial NOT NULL,
	"Started" DATE,
	CONSTRAINT QuestTestCurrent_pk PRIMARY KEY ("Id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "Ans" (
	"Id" serial NOT NULL,
	"Name" varchar(512) NOT NULL UNIQUE,
	"Correct" bool NOT NULL,
	CONSTRAINT Ans_pk PRIMARY KEY ("Id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "QuestAns" (
	"Quest" bigint NOT NULL,
	"Ans" bigint NOT NULL
) WITH (
  OIDS=FALSE
);



CREATE TABLE "QuestType" (
	"Id" serial NOT NULL,
	"Name" varchar NOT NULL UNIQUE,
	CONSTRAINT QuestType_pk PRIMARY KEY ("Id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "AnsCurrent" (
	"Id" serial NOT NULL,
	"TraineeCurrent" bigint NOT NULL,
	"QuestTestCurrent" bigint NOT NULL,
	"Ans" bigint NOT NULL,
	"AnsweredAt" DATE,
	CONSTRAINT AnsCurrent_pk PRIMARY KEY ("Id")
) WITH (
  OIDS=FALSE
);





ALTER TABLE "TrainingCurrent" ADD CONSTRAINT "TrainingCurrent_fk0" FOREIGN KEY ("Training") REFERENCES "Training"("Id");



ALTER TABLE "TrainingCurrentDates" ADD CONSTRAINT "TrainingCurrentDates_fk0" FOREIGN KEY ("TrainingCurrent") REFERENCES "TrainingCurrent"("Id");
ALTER TABLE "TrainingCurrentDates" ADD CONSTRAINT "TrainingCurrentDates_fk1" FOREIGN KEY ("Dates") REFERENCES "Dates"("Id");


ALTER TABLE "TrainingGroupTraining" ADD CONSTRAINT "TrainingGroupTraining_fk0" FOREIGN KEY ("TrainingGroup") REFERENCES "TrainingGroup"("Id");
ALTER TABLE "TrainingGroupTraining" ADD CONSTRAINT "TrainingGroupTraining_fk1" FOREIGN KEY ("Training") REFERENCES "Training"("Id");

ALTER TABLE "TraineeCurrent" ADD CONSTRAINT "TraineeCurrent_fk0" FOREIGN KEY ("Trainee") REFERENCES "Trainee"("Id");
ALTER TABLE "TraineeCurrent" ADD CONSTRAINT "TraineeCurrent_fk1" FOREIGN KEY ("TrainingCurrent") REFERENCES "TrainingCurrent"("Id");

ALTER TABLE "TraineeCurrentDates" ADD CONSTRAINT "TraineeCurrentDates_fk0" FOREIGN KEY ("TraineeCurrent") REFERENCES "TraineeCurrent"("Id");
ALTER TABLE "TraineeCurrentDates" ADD CONSTRAINT "TraineeCurrentDates_fk1" FOREIGN KEY ("Dates") REFERENCES "Dates"("Id");

ALTER TABLE "TrainerCurrent" ADD CONSTRAINT "TrainerCurrent_fk0" FOREIGN KEY ("Trainer") REFERENCES "Trainer"("Id");
ALTER TABLE "TrainerCurrent" ADD CONSTRAINT "TrainerCurrent_fk1" FOREIGN KEY ("TrainingCurrent") REFERENCES "TrainingCurrent"("Id");

ALTER TABLE "TrainerCurrentDates" ADD CONSTRAINT "TrainerCurrentDates_fk0" FOREIGN KEY ("TrainerCurrent") REFERENCES "TrainerCurrent"("Id");
ALTER TABLE "TrainerCurrentDates" ADD CONSTRAINT "TrainerCurrentDates_fk1" FOREIGN KEY ("Dates") REFERENCES "Dates"("Id");

ALTER TABLE "Test" ADD CONSTRAINT "Test_fk0" FOREIGN KEY ("Training") REFERENCES "Training"("Id");

ALTER TABLE "Quest" ADD CONSTRAINT "Quest_fk0" FOREIGN KEY ("QuestType") REFERENCES "QuestType"("Id");

ALTER TABLE "TestQuest" ADD CONSTRAINT "TestQuest_fk0" FOREIGN KEY ("Test") REFERENCES "Test"("Id");
ALTER TABLE "TestQuest" ADD CONSTRAINT "TestQuest_fk1" FOREIGN KEY ("Quest") REFERENCES "Quest"("Id");

ALTER TABLE "TestCurrent" ADD CONSTRAINT "TestCurrent_fk0" FOREIGN KEY ("Test") REFERENCES "Test"("Id");
ALTER TABLE "TestCurrent" ADD CONSTRAINT "TestCurrent_fk1" FOREIGN KEY ("TraineeCurrent") REFERENCES "TraineeCurrent"("Id");

ALTER TABLE "TestCurrentDates" ADD CONSTRAINT "TestCurrentDates_fk0" FOREIGN KEY ("TestCurrent") REFERENCES "TestCurrent"("Id");
ALTER TABLE "TestCurrentDates" ADD CONSTRAINT "TestCurrentDates_fk1" FOREIGN KEY ("Dates") REFERENCES "Dates"("Id");

ALTER TABLE "QuestTestCurrent" ADD CONSTRAINT "QuestTestCurrent_fk0" FOREIGN KEY ("Quest") REFERENCES "Quest"("Id");
ALTER TABLE "QuestTestCurrent" ADD CONSTRAINT "QuestTestCurrent_fk1" FOREIGN KEY ("TestCurrent") REFERENCES "TestCurrent"("Id");


ALTER TABLE "QuestAns" ADD CONSTRAINT "QuestAns_fk0" FOREIGN KEY ("Quest") REFERENCES "Quest"("Id");
ALTER TABLE "QuestAns" ADD CONSTRAINT "QuestAns_fk1" FOREIGN KEY ("Ans") REFERENCES "Ans"("Id");


ALTER TABLE "AnsCurrent" ADD CONSTRAINT "AnsCurrent_fk0" FOREIGN KEY ("TraineeCurrent") REFERENCES "TraineeCurrent"("Id");
ALTER TABLE "AnsCurrent" ADD CONSTRAINT "AnsCurrent_fk1" FOREIGN KEY ("QuestTestCurrent") REFERENCES "QuestTestCurrent"("Id");
ALTER TABLE "AnsCurrent" ADD CONSTRAINT "AnsCurrent_fk2" FOREIGN KEY ("Ans") REFERENCES "Ans"("Id");
