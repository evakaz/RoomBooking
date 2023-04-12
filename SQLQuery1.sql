-- Create Classroom table
CREATE TABLE Classroom (
ClassRoomId INT PRIMARY KEY,
ClassName VARCHAR(50),
TotalSeats INT
);

-- Create Seat table
CREATE TABLE Seat (
SeatId INT PRIMARY KEY,
ClassRoomId INT,
SeatNumber VARCHAR(10),
IsReserved BIT,
FOREIGN KEY (ClassRoomId) REFERENCES Classroom(ClassRoomId)
);

-- Insert sample data into Classroom table
INSERT INTO Classroom (ClassRoomId, ClassName, TotalSeats)
VALUES (1, 'Classroom A', 50),
(2, 'Classroom B', 40),
(3, 'Classroom C', 30);

-- Insert sample data into Seat table
INSERT INTO Seat (SeatId, ClassRoomId, SeatNumber, IsReserved)
VALUES (1, 1, 'A1', 0),
(2, 1, 'A2', 0),
-- ... (insert additional seats for Classroom A)
(51, 2, 'B1', 0),
(52, 2, 'B2', 0),
-- ... (insert additional seats for Classroom B)
(91, 3, 'C1', 0),
(92, 3, 'C2', 0);
-- ... (insert additional seats for Classroom C)