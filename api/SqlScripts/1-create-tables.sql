CREATE DATABASE JobPortal
GO

USE JobPortal
GO

CREATE SCHEMA PortalSchema
GO

CREATE TABLE PortalSchema.Locations (
  LocationId INT PRIMARY KEY,
  LocationName NVARCHAR(100) NOT NULL
);

INSERT INTO PortalSchema.Locations (LocationName)
VALUES 
('Ampara'),
('Anuradhapura'),
('Badulla'),
('Batticaloa'),
('Colombo'),
('Galle'),
('Gampaha'),
('Hambantota'),
('Jaffna'),
('Kalutara'),
('Kandy'),
('Kegalle'),
('Kilinochchi'),
('Kurunegala'),
('Mannar'),
('Matale'),
('Matara'),
('Monaragala'),
('Mullaitivu'),
('Nuwara Eliya'),
('Polonnaruwa'),
('Puttalam'),
('Ratnapura'),
('Trincomalee'),
('Vavuniya');


CREATE TABLE PortalSchema.Users (
  UserId INT IDENTITY(1,1) PRIMARY KEY,
  FirstName VARCHAR(50) NOT NULL,
  LastName VARCHAR(50) NOT NULL,
  Email VARCHAR(100) NOT NULL,
  PasswordHash VARBINARY(MAX) NOT NULL,
  PasswordSalt VARBINARY(MAX) NOT NULL,
  Cv NVARCHAR(100),
  CoverLetter NVARCHAR(255),
  LocationId INT,
  CONSTRAINT Fk_Locations_Users FOREIGN KEY (LocationId)
    REFERENCES PortalSchema.Locations (LocationId)
);

CREATE TABLE PortalSchema.Skills (
  SkillId INT IDENTITY(1,1) PRIMARY KEY,
  Skill NVARCHAR(50) NOT NULL
);

INSERT INTO PortalSchema.Skills (Skill)
VALUES
  ('Java'),
  ('Python'),
  ('C++'),
  ('JavaScript'),
  ('HTML/CSS'),
  ('SQL'),
  ('Agile'),
  ('Scrum'),
  ('Git'),
  ('AWS'),
  ('Docker'),
  ('Kubernetes'),
  ('RESTful API design'),
  ('Test-driven development (TDD)'),
  ('CI/CD'),
  ('Microservices architecture'),
  ('Object-oriented design principles'),
  ('Data structures and algorithms'),
  ('DevOps'),
  ('Machine learning'),
  ('Artificial intelligence'),
  ('Natural language processing (NLP)'),
  ('Big data'),
  ('Cloud computing'),
  ('Security'),
  ('Network administration'),
  ('Database administration'),
  ('Mobile app development (Android/iOS)'),
  ('React'),
  ('Angular'),
  ('Vue'),
  ('Spring'),
  ('Django'),
  ('Flask'),
  ('Express.js'),
  ('Laravel'),
  ('ASP.NET'),
  ('Node.js');

CREATE TABLE PortalSchema.JobTypes (
  JobTypeId INT IDENTITY(1,1) PRIMARY KEY,
  JobType NVARCHAR(100) NOT NULL
);

INSERT INTO PortalSchema.JobTypes (JobType)
VALUES
  ('Full-Time'),
  ('Internship'),
  ('Contract'),
  ('Part-Time'),
  ('Casual');

CREATE TABLE PortalSchema.CompanyCategories (
  CategoryId INT IDENTITY(1,1) PRIMARY KEY,
  Category NVARCHAR(100) NOT NULL
);

INSERT INTO PortalSchema.CompanyCategories (Category)
VALUES
  ('Software development services'),
  ('Custom software development'),
  ('Mobile app development'),
  ('Web development'),
  ('Enterprise software solutions'),
  ('Cloud computing and hosting services'),
  ('Artificial intelligence and machine learning'),
  ('Augmented reality and virtual reality'),
  ('Cybersecurity and IT security'),
  ('Data analytics and business intelligence'),
  ('E-commerce solutions'),
  ('Financial technology (fintech) solutions'),
  ('Gaming and entertainment software'),
  ('Healthcare software solutions'),
  ('Human resources management (HRM) software'),
  ('Marketing automation software'),
  ('Project management software'),
  ('Quality assurance and testing services'),
  ('Software consulting and outsourcing'),
  ('Software training and education services');

CREATE TABLE PortalSchema.JobModalities (
  ModalityId INT IDENTITY(1,1) PRIMARY KEY,
  Modality NVARCHAR(50) NOT NULL
);

INSERT INTO PortalSchema.JobModalities (Modality)
VALUES
  ('In-Office'),
  ('Remote');

CREATE TABLE PortalSchema.Companies (
  CompanyId INT IDENTITY(1,1) PRIMARY KEY,
  CompanyName NVARCHAR(100) NOT NULL,
  Email VARCHAR(100) NOT NULL,
  PasswordHash VARBINARY(MAX) NOT NULL,
  PasswordSalt VARBINARY(MAX) NOT NULL,
  CompanyDescription NVARCHAR(255),
  Logo NVARCHAR(100),
  CategoryId INT,
  LocationId INT,
  CONSTRAINT Fk_CompanyCategories_Companies FOREIGN KEY (CategoryId)
    REFERENCES PortalSchema.CompanyCategories (CategoryId),
  CONSTRAINT Fk_Locations_Companies FOREIGN KEY (LocationId)
    REFERENCES PortalSchema.Locations (LocationId)
);

CREATE TABLE PortalSchema.JobPosts (
  JobPostId INT IDENTITY(1,1) PRIMARY KEY,
  Title NVARCHAR(50) NOT NULL,
  PostDescription NVARCHAR(255) NOT NULL,
  Salary INT,
  CreatedOn DATE NOT NULL,
  UpdatedOn DATE,
  TypeId INT NOT NULL,
  ModalityId INT NOT NULL,
  LocationId INT NOT NULL,
  CompanyId INT NOT NULL,
  CONSTRAINT Fk_JobTypes_JobPosts FOREIGN KEY (TypeId)
    REFERENCES PortalSchema.JobTypes (JobTypeId),
  CONSTRAINT Fk_JobModalities_JobPosts FOREIGN KEY (ModalityId)
    REFERENCES PortalSchema.JobModalities (ModalityId),
  CONSTRAINT Fk_Locations_JobPosts FOREIGN KEY (LocationId)
    REFERENCES PortalSchema.Locations (LocationId),
  CONSTRAINT Fk_Companies_JobPosts FOREIGN KEY (CompanyId)
    REFERENCES PortalSchema.Companies (CompanyId),
);

CREATE TABLE PortalSchema.Applications (
  ApplicationId INT IDENTITY(1,1) PRIMARY KEY,
  SubmittedOn DATE NOT NULL,
  UserId INT NOT NULL,
  JobPostId INT NOT NULL,
  CONSTRAINT Fk_Users_Applications FOREIGN KEY (UserId)
    REFERENCES PortalSchema.Users (UserId),
  CONSTRAINT Fk_JobPosts_Applications FOREIGN KEY (JobPostId)
    REFERENCES PortalSchema.JobPosts (JobPostId)
);

CREATE TABLE PortalSchema.ApplicationStatusTypes (
  StatusTypeId INT IDENTITY(1,1) PRIMARY KEY,
  StatusType NVARCHAR(50) NOT NULL CHECK (StatusType IN ('Screening', 'Shortlisted', 'Rejected'))
);

CREATE TABLE PortalSchema.ApplicationStatuses (
  StatusId INT IDENTITY(1,1) PRIMARY KEY,
  ApplicationId INT NOT NULL,
  StatusTypeId INT NOT NULL,
  UpdatedOn DATE NOT NULL,
  Comment NVARCHAR(100),
  CONSTRAINT Fk_Applications_ApplicationStatuses FOREIGN KEY (ApplicationId)
    REFERENCES PortalSchema.Applications (ApplicationId),
  CONSTRAINT Fk_ApplicationStatusTypes_ApplicationStatuses FOREIGN KEY (StatusTypeId)
    REFERENCES PortalSchema.ApplicationStatusTypes (StatusTypeId)
);

CREATE TABLE PortalSchema.UserSkills (
  UserSkillId INT IDENTITY(1,1) PRIMARY KEY,
  UserId INT NOT NULL,
  SkillId INT NOT NULL,
  CONSTRAINT Fk_Users_UserSkills FOREIGN KEY (UserId)
    REFERENCES PortalSchema.Users (UserId),
  CONSTRAINT Fk_Skills_UserSkills FOREIGN KEY (SkillId)
    REFERENCES PortalSchema.Skills (SkillId),
);

CREATE TABLE PortalSchema.JobPostSkills (
  JobPostSkillId INT IDENTITY(1,1) PRIMARY KEY,
  JobPostId INT NOT NULL,
  SkillId INT NOT NULL,
  CONSTRAINT Fk_JobPost_JobPostSkills FOREIGN KEY (JobPostId)
    REFERENCES PortalSchema.JobPosts (JobPostId),
  CONSTRAINT Fk_Skills_JobPostSkills FOREIGN KEY (SkillId)
    REFERENCES PortalSchema.Skills (SkillId),
);
