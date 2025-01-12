CREATE DATABASE NotificationDB;

USE NotificationDB;

CREATE TABLE Notifications (
    Id CHAR(36) PRIMARY KEY,
    Title VARCHAR(255) NOT NULL,
    PlanId CHAR(36) NOT NULL
);
