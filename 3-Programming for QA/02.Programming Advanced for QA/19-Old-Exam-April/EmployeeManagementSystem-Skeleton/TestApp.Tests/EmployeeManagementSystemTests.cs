using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class EmployeeManagementSystemTests
{
    [Test]
    public void Test_Constructor_CheckInitialEmptyEmployeeCollectionAndCount()
    {
        // Arrange & Act
        var system = new EmployeeManagementSystem();

        // Assert
        Assert.AreEqual(0, system.EmployeeCount);
        CollectionAssert.IsEmpty(system.GetAllEmployees());
    }

    [Test]
    public void Test_AddEmployee_ValidEmployeeName_AddNewEmployee()
    {
        // Arrange
        var system = new EmployeeManagementSystem();
        string employeeName = "John Doe";

        // Act
        system.AddEmployee(employeeName);

        // Assert
        Assert.AreEqual(1, system.EmployeeCount);
        CollectionAssert.Contains(system.GetAllEmployees(), employeeName);
    }


    [Test]
    public void Test_AddEmployee_NullOrEmptyEmployeeName_ThrowsArgumentException()
    {
        // Arrange
        var system = new EmployeeManagementSystem();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => system.AddEmployee(null));
        Assert.Throws<ArgumentException>(() => system.AddEmployee(""));
        Assert.Throws<ArgumentException>(() => system.AddEmployee(" "));
    }


    [Test]
    public void Test_RemoveEmployee_ValidEmployeeName_RemoveFirstEmployeeName()
    {
        // Arrange
        var system = new EmployeeManagementSystem();
        string employeeName = "John Doe";
        system.AddEmployee(employeeName);

        // Act
        system.RemoveEmployee(employeeName);

        // Assert
        Assert.AreEqual(0, system.EmployeeCount);
        CollectionAssert.DoesNotContain(system.GetAllEmployees(), employeeName);
    }

    [Test]
    public void Test_RemoveEmployee_NullOrEmptyEmployeeName_ThrowsArgumentException()
    {
        // Arrange
        var system = new EmployeeManagementSystem();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => system.RemoveEmployee("John Doe"));
    }


    [Test]
    public void Test_GetAllEmployees_AddedAndRemovedEmployees_ReturnsExpectedEmployeeCollection()
    {
        // Arrange
        var system = new EmployeeManagementSystem();
        string employee1 = "John Doe";
        string employee2 = "Jane Smith";
        string employee3 = "Robert Brown";

        system.AddEmployee(employee1);
        system.AddEmployee(employee2);
        system.AddEmployee(employee3);
        system.RemoveEmployee(employee2);

        var expected = new List<string> { employee1, employee3 };

        // Act
        var result = system.GetAllEmployees();

        // Assert
        CollectionAssert.AreEquivalent(expected, result);
    }

}

