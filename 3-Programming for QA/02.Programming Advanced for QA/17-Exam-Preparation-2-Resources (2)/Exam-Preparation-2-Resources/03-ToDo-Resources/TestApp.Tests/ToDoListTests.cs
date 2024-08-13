using System;
using NUnit.Framework;
using TestApp.Todo;

namespace TestApp.Tests
{
    [TestFixture]
    public class ToDoListTests
    {
        private ToDoList _toDoList = null!;

        [SetUp]
        public void SetUp()
        {
            this._toDoList = new ToDoList();
        }

        [Test]
        public void Test_AddTask_TaskAddedToToDoList()
        {
            // Arrange
            string taskTitle = "Buy groceries";
            DateTime dueDate = DateTime.Today;

            // Act
            this._toDoList.AddTask(taskTitle, dueDate);
            string result = this._toDoList.DisplayTasks();

            // Assert
            string expected = $"To-Do List:{Environment.NewLine}[ ] {taskTitle} - Due: {dueDate:MM/dd/yyyy}";
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Test_CompleteTask_TaskMarkedAsCompleted()
        {
            // Arrange
            string taskTitle = "Do laundry";
            DateTime dueDate = DateTime.Today;
            this._toDoList.AddTask(taskTitle, dueDate);

            // Act
            this._toDoList.CompleteTask(taskTitle);
            string result = this._toDoList.DisplayTasks();

            // Assert
            string expected = $"To-Do List:{Environment.NewLine}[✓] {taskTitle} - Due: {dueDate:MM/dd/yyyy}";
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Test_CompleteTask_TaskNotFound_ThrowsArgumentException()
        {
            // Arrange
            string nonExistentTaskTitle = "Task that does not exist";

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => this._toDoList.CompleteTask(nonExistentTaskTitle));
            Assert.That(ex.Message, Is.EqualTo("Task with given title does not exist."));
        }

        [Test]
        public void Test_DisplayTasks_NoTasks_ReturnsEmptyString()
        {
            // Act
            string result = this._toDoList.DisplayTasks();

            // Assert
            string expected = "To-Do List:";
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Test_DisplayTasks_WithTasks_ReturnsFormattedToDoList()
        {
            // Arrange
            this._toDoList.AddTask("Task 1", new DateTime(2024, 8, 15));
            this._toDoList.AddTask("Task 2", new DateTime(2024, 8, 20));

            // Act
            string result = this._toDoList.DisplayTasks();

            // Assert
            string expected = $"To-Do List:{Environment.NewLine}[ ] Task 1 - Due: 08/15/2024{Environment.NewLine}[ ] Task 2 - Due: 08/20/2024";
            Assert.AreEqual(expected, result);
        }
    }
}
