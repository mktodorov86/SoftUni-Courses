using NUnit.Framework;
using System;

namespace TestApp.Tests;

public class ExtractFileTests
{
    [Test]
    public void Test_GetFile_NullPath_ThrowsArgumentNullException()
    {
        // Arrange
        string path = null;

        // Act + Assert
        Assert.Throws<ArgumentNullException>(() => ExtractFile.GetFile(path));
    }

    [Test]
    public void Test_GetFile_EmptyPath_ThrowsArgumentNullException()
    {
        // Arrange
        string path = "";

        // Act + Assert
        Assert.Throws<ArgumentNullException>(() => ExtractFile.GetFile(path));
    }

    [Test]
    public void Test_GetFile_ValidPath_ReturnsFileNameAndExtension()
    {
        // Arrange
        string path = @"C:\Users\Username\Documents\example.txt";
        string expected = "File name: example\nFile extension: txt";

        // Act
        string result = ExtractFile.GetFile(path);

        // Assert
        Assert.AreEqual(expected, result);
    }
    [Test]
    public void Test_GetFile_PathWithNoExtension_ReturnsFileNameOnly()
    {
        // Arrange
        string path = @"C:\Program Files\FolderName\fileWithoutExtension";
        string expected = "File name: fileWithoutExtension";

        // Act
        string result = ExtractFile.GetFile(path);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_GetFile_PathWithSpecialCharacters_ReturnsFileNameAndExtension()
    {
        // Arrange
        string path = @"C:\Program Files\FolderName\file_with_special[characters].txt";
        string expected = "File name: file_with_special[characters]\nFile extension: txt";

        // Act
        string result = ExtractFile.GetFile(path);

        // Assert
        Assert.AreEqual(expected, result);
    }
}
