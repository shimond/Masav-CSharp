
# Comprehensive OOP Exercise: Israeli ID Validation System

Design and implement a small C# program that demonstrates the use of classes, inheritance, and polymorphism, while interacting with the user to collect and validate information.

## Requirements

1. **Create a base class** called `Person` with the following properties:
	- `Name` (string)
	- `Tz` (string, Israeli ID number)
	- A method `IsValidTz()` that checks if the `Tz` is a valid Israeli ID (use the logic from your previous exercise).

2. **Create two derived classes**:
	- `Student` (inherits from `Person`), with an additional property: `Grade` (int)
	- `Teacher` (inherits from `Person`), with an additional property: `Subject` (string)

3. **Polymorphism:**
	- Add a virtual method in `Person` called `GetInfo()` that returns a string with the person's details.
	- Override `GetInfo()` in both `Student` and `Teacher` to include their specific properties.

4. **User Interaction:**
	- Ask the user if they want to enter a Student or Teacher.
	- Collect the relevant information from the user (Name, Tz, and Grade or Subject).
	- Create the appropriate object (`Student` or `Teacher`).
	- Use the `IsValidTz()` method to check if the ID is valid and inform the user.
	- Print the result of `GetInfo()`.

## Example

```
Enter type (Student/Teacher): Student
Enter name: Dana
Enter ID (Tz): 123456782
Enter grade: 95
ID is valid!
Student: Dana, ID: 123456782, Grade: 95
```

## Bonus
- Allow the user to enter multiple people and store them in a list.
- After all entries, print the info for all people entered.

---

This exercise will help you practice OOP concepts, inheritance, polymorphism, and user input handling in C#.
