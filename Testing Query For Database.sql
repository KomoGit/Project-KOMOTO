USE KomoDb

DROP TABLE Jobs

USE KomoDb
DELETE FROM Categories

INSERT INTO Categories (Name) VALUES 
('Sales and Marketing'),
('IT and Software Development'),
('Healthcare'),
('Finance and Accounting'),
('Engineering'),
('Education'),
('Retail'),
('Hospitality and Tourism'),
('Fashion and Beauty'),
('Manufacturing'),
('Construction'),
('Human Resources'),
('Environmental'),
('Art and Design'),
('Pharmaceutical'),
('Energy'),
('Legal'),
('Media and Communications'),
('Transportation and Logistics'),
('Telecommunications'),
('Government'),
('Agriculture'),
('Non-Profit and Volunteer'),
('Science'),
('Real Estate'),
('Sports and Fitness'),
('Consulting'),
('Entertainment'),
('Other'),
('Customer Service');

INSERT INTO Tools(Name) VALUES
('Visual Studio'),
('Visual Studio Code'),
('Eclipse'),
('IntelliJ IDEA'),
('Xcode'),
('Android Studio'),
('Git'),
('GitHub'),
('Bitbucket'),
('Jenkins'),
('Travis CI'),
('Docker'),
('Kubernetes'),
('JIRA'),
('Confluence'),
('.NET Framework'),
('C#'),
('GoLang'),
('Java');

INSERT INTO Jobs (Title, Description, Link, CategoryId, ExpirationDate, PublishDate, EmployerId) VALUES
    ('Software Engineer', 'Develop software applications.', 'https://example.com/job1', 2, '2023-09-30', '2023-09-01', 1),
    ('Data Analyst', 'Analyze data for insights.', 'https://example.com/job2', 7, '2023-09-30', '2023-09-01', 2),
    ('Web Developer', 'Create interactive web applications.', 'https://example.com/job3', 2, '2023-09-30', '2023-09-01', 3),
    ('Graphic Designer', 'Design visual content for marketing.', 'https://example.com/job4', 13, '2023-09-30', '2023-09-01', 4),
    ('Project Manager', 'Oversee project planning and execution.', 'https://example.com/job5', 11, '2023-09-30', '2023-09-01', 5),
    ('UX Designer', 'Improve user experiences for products.', 'https://example.com/job6', 13, '2023-09-30', '2023-09-01', 6),
    ('Content Writer', 'Write engaging content for websites.', 'https://example.com/job7', 7, '2023-09-30', '2023-09-01', 7),
    ('Marketing Specialist', 'Plan and execute marketing campaigns.', 'https://example.com/job8', 1, '2023-09-30', '2023-09-01', 8),
    ('Database Administrator', 'Manage and maintain databases.', 'https://example.com/job9', 2, '2023-09-30', '2023-09-01', 9),
    ('Network Engineer', 'Design and maintain network systems.', 'https://example.com/job10', 2, '2023-09-30', '2023-09-01', 10),
    ('Financial Analyst', 'Analyze financial data and trends.', 'https://example.com/job11', 4, '2023-09-30', '2023-09-01', 11),
    ('HR Manager', 'Manage human resources and personnel.', 'https://example.com/job12', 6, '2023-09-30', '2023-09-01', 12),
    ('Frontend Developer', 'Develop user interfaces for websites.', 'https://example.com/job13', 2, '2023-09-30', '2023-09-01', 13),
    ('Sales Representative', 'Promote and sell products or services.', 'https://example.com/job14', 1, '2023-09-30', '2023-09-01', 14),
    ('Customer Support Specialist', 'Assist customers with inquiries.', 'https://example.com/job15', 1, '2023-09-30', '2023-09-01', 15),
    ('Software Developer', 'Develop software applications.', 'https://example.com/job16', 2, '2023-09-30', '2023-09-01', 1),
    ('Data Scientist', 'Analyze and interpret complex data.', 'https://example.com/job17', 7, '2023-09-30', '2023-09-01', 2),
    ('Accountant', 'Handle financial recordkeeping and reporting.', 'https://example.com/job18', 4, '2023-09-30', '2023-09-01', 3),
    ('Mechanical Engineer', 'Design and develop mechanical systems.', 'https://example.com/job19', 5, '2023-09-30', '2023-09-01', 4),
    ('Art Director', 'Lead creative visual projects.', 'https://example.com/job20', 13, '2023-09-30', '2023-09-01', 5),
    ('Legal Counsel', 'Provide legal advice and support.', 'https://example.com/job21', 12, '2023-09-30', '2023-09-01', 6),
    ('Quality Assurance Analyst', 'Ensure product quality and reliability.', 'https://example.com/job22', 2, '2023-09-30', '2023-09-01', 7),
    ('Product Manager', 'Manage product development and strategy.', 'https://example.com/job23', 2, '2023-09-30', '2023-09-01', 8),
    ('Teacher', 'Educate and inspire students.', 'https://example.com/job24', 6, '2023-09-30', '2023-09-01', 9),
    ('Nurse', 'Provide healthcare and patient care.', 'https://example.com/job25', 3, '2023-09-30', '2023-09-01', 10),
    ('Architect', 'Design and plan architectural projects.', 'https://example.com/job26', 10, '2023-09-30', '2023-09-01',3),
    ('Chef', 'Prepare and cook culinary delights.', 'https://example.com/job27', 8, '2023-09-30', '2023-09-01', 2),
    ('Pharmacist', 'Dispense medications and healthcare advice.', 'https://example.com/job28', 3, '2023-09-30', '2023-09-01', 13),
    ('Electrician', 'Install and repair electrical systems.', 'https://example.com/job29', 10, '2023-09-30', '2023-09-01', 14),
    ('Civil Engineer', 'Plan and oversee civil construction projects.', 'https://example.com/job30', 5, '2023-09-30', '2023-09-01', 15),
    ('Frontend Developer', 'Develop user interfaces for websites.', 'https://example.com/job31', 2, '2023-09-30', '2023-09-01', 1),
    ('Marketing Manager', 'Lead marketing campaigns and strategies.', 'https://example.com/job32', 1, '2023-09-30', '2023-09-01', 1),
    ('Database Administrator', 'Manage and maintain databases.', 'https://example.com/job33', 2, '2023-09-30', '2023-09-01', 1),
    ('Customer Support Specialist', 'Assist customers with inquiries.', 'https://example.com/job34', 1, '2023-09-30', '2023-09-01', 2),
    ('Project Manager', 'Oversee project planning and execution.', 'https://example.com/job35', 11, '2023-09-30', '2023-09-01', 2),
    ('UX Designer', 'Improve user experiences for products.', 'https://example.com/job36', 13, '2023-09-30', '2023-09-01', 2),
    ('Content Writer', 'Write engaging content for websites.', 'https://example.com/job37', 7, '2023-09-30', '2023-09-01', 3),
    ('Sales Specialist', 'Promote and sell products or services.', 'https://example.com/job38', 1, '2023-09-30', '2023-09-01', 3);

INSERT INTO Companies (Name) VALUES
('Acme Corporation'),
('Tech Innovators Inc.'),
('Global Solutions Ltd.'),
('Sunrise Technologies'),
('Data Systems International'),
('Innovative Designs LLC'),
('Pioneer Enterprises'),
('NexTech Solutions'),
('Apex Innovations'),
('Eagle Eye Systems'),
('Strategic Ventures Inc.'),
('Precision Technologies'),
('Starlight Software'),
('Crimson Innovations'),
('Blue Sky Industries'),
('Phoenix Software Group'),
('Quantum Technologies'),
('Tech Titans Inc.'),
('FirstClass Enterprises'),
('GreenWave Systems'),
('SilverLining Solutions'),
('FutureTech Innovations'),
('Golden Gate Software'),
('IntelliSys Solutions'),
('Matrix Technologies'),
('Infinite Horizons Inc.'),
('Vertex Solutions'),
('Frontier Software'),
('Pinnacle Innovations');

USE KomoDb
SELECT * FROM Jobs WHERE CategoryId = 2

USE KomoDb
ALTER TABLE [Tools] DROP COLUMN JobId

USE master;
ALTER DATABASE [KomoDb] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE [KomoDb] ;