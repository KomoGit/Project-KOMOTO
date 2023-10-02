USE KomoDb

INSERT INTO Categories (Name) VALUES ('Sales and Marketing');
INSERT INTO Categories (Name) VALUES ('IT and Software Development');
INSERT INTO Categories (Name) VALUES ('Healthcare');
INSERT INTO Categories (Name) VALUES ('Finance and Accounting');
INSERT INTO Categories (Name) VALUES ('Engineering');
INSERT INTO Categories (Name) VALUES ('Education');
INSERT INTO Categories (Name) VALUES ('Customer Service');
INSERT INTO Categories (Name) VALUES ('Retail');
INSERT INTO Categories (Name) VALUES ('Hospitality and Tourism');
INSERT INTO Categories (Name) VALUES ('Manufacturing');
INSERT INTO Categories (Name) VALUES ('Construction');
INSERT INTO Categories (Name) VALUES ('Human Resources');
INSERT INTO Categories (Name) VALUES ('Art and Design');
INSERT INTO Categories (Name) VALUES ('Legal');
INSERT INTO Categories (Name) VALUES ('Media and Communications');
INSERT INTO Categories (Name) VALUES ('Transportation and Logistics');
INSERT INTO Categories (Name) VALUES ('Science');
INSERT INTO Categories (Name) VALUES ('Real Estate');
INSERT INTO Categories (Name) VALUES ('Agriculture');
INSERT INTO Categories (Name) VALUES ('Non-Profit and Volunteer');
INSERT INTO Categories (Name) VALUES ('Government');
INSERT INTO Categories (Name) VALUES ('Pharmaceutical');
INSERT INTO Categories (Name) VALUES ('Telecommunications');
INSERT INTO Categories (Name) VALUES ('Energy');
INSERT INTO Categories (Name) VALUES ('Environmental');
INSERT INTO Categories (Name) VALUES ('Fashion and Beauty');
INSERT INTO Categories (Name) VALUES ('Sports and Fitness');
INSERT INTO Categories (Name) VALUES ('Consulting');
INSERT INTO Categories (Name) VALUES ('Entertainment');
INSERT INTO Categories (Name) VALUES ('Other');

INSERT INTO Jobs (Title, Description, Link, CategoryId) VALUES
    ('Software Engineer', 'Develop software applications.', 'https://example.com/job1', 2),  -- Software Development
    ('Data Analyst', 'Analyze data for insights.', 'https://example.com/job2', 7),          -- Data Analysis
    ('Web Developer', 'Create interactive web applications.', 'https://example.com/job3', 2), -- Software Development
    ('Graphic Designer', 'Design visual content for marketing.', 'https://example.com/job4', 13),  -- Art and Design
    ('Project Manager', 'Oversee project planning and execution.', 'https://example.com/job5', 11),  -- Project Management
    ('UX Designer', 'Improve user experiences for products.', 'https://example.com/job6', 13),  -- Art and Design
    ('Content Writer', 'Write engaging content for websites.', 'https://example.com/job7', 7),  -- Data Analysis
    ('Marketing Specialist', 'Plan and execute marketing campaigns.', 'https://example.com/job8', 1),  -- Sales and Marketing
    ('Database Administrator', 'Manage and maintain databases.', 'https://example.com/job9', 2),  -- Software Development
    ('Network Engineer', 'Design and maintain network systems.', 'https://example.com/job10', 2), -- Software Development
    ('Financial Analyst', 'Analyze financial data and trends.', 'https://example.com/job11', 4),  -- Finance and Accounting
    ('HR Manager', 'Manage human resources and personnel.', 'https://example.com/job12', 6),  -- Human Resources
    ('Frontend Developer', 'Develop user interfaces for websites.', 'https://example.com/job13', 2), -- Software Development
    ('Sales Representative', 'Promote and sell products or services.', 'https://example.com/job14', 1), -- Sales and Marketing
    ('Customer Support Specialist', 'Assist customers with inquiries.', 'https://example.com/job15', 1), -- Sales and Marketing
    ('Systems Administrator', 'Maintain computer systems and networks.', 'https://example.com/job16', 2), -- Software Development
    ('Data Scientist', 'Analyze and interpret complex data.', 'https://example.com/job17', 7), -- Data Analysis
    ('Accountant', 'Handle financial recordkeeping and reporting.', 'https://example.com/job18', 4), -- Finance and Accounting
    ('Mechanical Engineer', 'Design and develop mechanical systems.', 'https://example.com/job19', 5), -- Engineering
    ('Art Director', 'Lead creative visual projects.', 'https://example.com/job20', 13), -- Art and Design
    ('Legal Counsel', 'Provide legal advice and support.', 'https://example.com/job21', 12), -- Legal
    ('Quality Assurance Analyst', 'Ensure product quality and reliability.', 'https://example.com/job22', 2), -- Software Development
    ('Product Manager', 'Manage product development and strategy.', 'https://example.com/job23', 2), -- Software Development
    ('Teacher', 'Educate and inspire students.', 'https://example.com/job24', 6), -- Human Resources
    ('Nurse', 'Provide healthcare and patient care.', 'https://example.com/job25', 3), -- Healthcare
    ('Architect', 'Design and plan architectural projects.', 'https://example.com/job26', 10), -- Construction
    ('Chef', 'Prepare and cook culinary delights.', 'https://example.com/job27', 8), -- Hospitality and Tourism
    ('Pharmacist', 'Dispense medications and healthcare advice.', 'https://example.com/job28', 3), -- Healthcare
    ('Electrician', 'Install and repair electrical systems.', 'https://example.com/job29', 10), -- Construction
    ('Civil Engineer', 'Plan and oversee civil construction projects.', 'https://example.com/job30', 5); -- Engineering