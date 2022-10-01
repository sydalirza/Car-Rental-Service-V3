# Car-Rental-Service-Database

# Introduction
As more and more people tend to move towards renting instead of ownership due to high maintenance and fuel costs, we have created a fully functional database application which could be used to manage a car rental company and its services. Users may sign up for the application. Authorized personnel with a predetermined combination of username and password can create and delete bookings, modify vehicle data, and access multiple other features of the projects.

# Project Breakdown
-![ProjectBreakdown](https://github.com/sydalirza/Car-Rental-Service-V3/blob/main/Project%20Breakdown.png)

# Description: 
Our project consists of two major elements:
# 1. Backend:
  The backend was created by using SQL Server as IDE and SQL as the programming language. The project mainly consists of three tables:
- i. car_info: This table will be used to store and retrieve information of the vehicles under the ownership of the company.
          Primary Key: number_plate
- ii. login_info: This table will be used to store information of the people authorized to access the main dashboard.
          Primary Key: username
- iii. user_info: This table consists of information regarding each booking made. It includes the customers information for example their contact information and CNIC number. 
          Primary Key: CNIC 			         Foreign Key: car_info(number_plate)

# 2. Frontend: 
   The front end of the project has been programmed on the C# programming language, where we have used System.Windows.Forms library that provides a huge amount of options to create an interactive and presentable interface for the user. Our project primarily consists of 9 forms each with its individual functionality. Some of the following functions are stated as below:
- i.	Login and Sign Up: These forms can be used to access the application using a combination of username and passwords. The user may if, not already a member, can sign up by entering their information and choosing a username and password of their choice. They can then use the login information to access the main dashboard. 
- ii.	Search: The users may use the primary keys such as Number Plate in car_info, CNIC in user_info to look up relevant information. This would display all the information present in the database with respect to that primary key using a select query. 
- iii.	Modify and Delete: Similar to search, the primary keys may be used to display information in textboxes, where they can be easily modified and even deleted from the database if required. 
- iv.	View: The data present will be displayed from the tables. This includes the vehicles in the table car_info and all the current bookings in user_info.


