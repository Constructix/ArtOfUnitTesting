using ArtOfUnitTesting.Interfaces;
using NSubstitute;
using Shouldly;
namespace ArtOfUnitTesting.Tests;

public class LogAnalyserTests
{
    // [Fact]
    // public void IsValidFileName_ValidFile_ReturnsTrue()
    // {
    //     // arrange
    //     LogAnalyser analyser = new LogAnalyser();
    //     // act
    //     bool result = analyser.IsValidLogFileName("whatever.slf");
    //     // assert
    //     result.ShouldBeTrue("filename should be valid.");
    // }
    //
    // [Fact]
    // public void IsValidFileName_InValidFile_ReturnsFalse()
    // {
    //     // arrange
    //     LogAnalyser analyser = new LogAnalyser();
    //     //act
    //     var result = analyser.IsValidLogFileName("fileName_InvalidFileName_Extension.txt");
    //     // assert
    //     result.ShouldBeFalse("Filename should be false.");
    // }
    //
    [Fact]
    public void IsValidFileName_MissingFileName_ThrowsException()
    {
        // arrange
        var substituteExtensionManager = Substitute.For<IExtensionManager>();
        
        LogAnalyser analyser = new LogAnalyser(substituteExtensionManager);
        //act
        var exception = Should.Throw<ArgumentException>(()=> analyser.IsValidLogFileName(string.Empty));
        //assert
        exception.ShouldBeOfType<ArgumentException>();
        exception.Message.ShouldBe("File name is missing.");
    }
    [Fact]
    public void IsValidFIleName_ValidFile_ReturnTrue()
    {
        var substituteExtensionManager = Substitute.For<IExtensionManager>();
        substituteExtensionManager.IsValid(Arg.Any<string>()).Returns(true);
        
        var logAnalyser = new LogAnalyser(substituteExtensionManager);
        var result = logAnalyser.IsValidLogFileName("testing.txt");
        substituteExtensionManager.Received().IsValid(Arg.Any<string>());
        result.ShouldBeTrue();
    }
    [Fact]
    public void IsValidFIleName_ValidFile_ReturnFalse()
    {
        var substituteExtensionManager = Substitute.For<IExtensionManager>();
        substituteExtensionManager.IsValid(Arg.Any<string>()).Returns(false);
        var logAnalyser = new LogAnalyser(substituteExtensionManager);
        var result = logAnalyser.IsValidLogFileName("testing.txt");
        substituteExtensionManager.Received().IsValid(Arg.Any<string>());
        result.ShouldBeFalse();
    }
}