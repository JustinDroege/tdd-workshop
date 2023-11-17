using System.Text.RegularExpressions;
using Application;

namespace Tests;

[TestClass]
public class MorseCodeTests
{
    private MorseTranslator morseTranslator = new MorseTranslator();

    // [TestMethod]
    // public void MorseTranslator_Should_Return_Empty_String_If_Input_Less_Then_2_Characters()
    // {
    //     //arrange
    //     //act
    //     var result = morseTranslator.Transform("a");
    //     
    //     //arrange
    //     Assert.AreEqual(result, string.Empty);
    // }
    
    [TestMethod]
    public void MorseTranslator_MorseCode_Should_Only_Contain_Dots_Spaces_And_Dashes()
    {
        //arrange
        //act
        var result = morseTranslator.Transform("EXAMPLE SENTENCE");
        
        //arrange
        StringAssert.Matches(result, new Regex(@"^[\.\- ]+$"));
    }

    [TestMethod]
    public void MorseTranslator_MorseCode_Should_Contain_1_Space_Between_Characters_In_A_Word()
    {
        //arrange
        //act
        var result = morseTranslator.Transform("WORD");
        
        //arrange
        Assert.IsTrue(result.Count(char.IsWhiteSpace) == 3, "We expect 3 spaces");
    }
    
    [TestMethod]
    public void MorseTranslator_Between_Words_Should_Be_3_Spaces()
    {
        //arrange
        //act
        var result = morseTranslator.Transform("EXAMPLE SENTENCE");
        
        //assert
        Assert.IsTrue(Regex.Matches(result, "(?<! ) {3}(?! )").Count == 1, "We expect one substring with 3 spaces");
    }
    
    [TestMethod]
    public void MorseTranslator_Ein_Buchstabe_Kann_In_Morse_Code_Uebersetzt_Werden()
    {
        //arrange
        //act
        var result = morseTranslator.Transform("A");
        
        //assert
        Assert.AreEqual(".-", result);
    }
    
    [TestMethod]
    public void MorseTranslator_Ein_Unbekanntes_Zeichen_Sollte_In_Fragezeigen_MorseCode_Konvertiert_Werden()
    {
        //arrange
        //act
        var result = morseTranslator.Transform("#");
        
        //assert
        Assert.AreEqual("..--..", result);
    }
    
    [TestMethod]
    public void MorseTranslator_Ein_Kleinbuchstabe_Sollte_Als_Großbuchstabe_Behandelt_Werden()
    {
        //arrange
        //act
        var result = morseTranslator.Transform("a");
        
        //assert
        Assert.AreEqual(".-", result);
    }

    [TestMethod]
    public void MorseTranslator_Ein_Satz_Kann_Konvertiert_Werden()
    {
        //arrange
        //act
        var result = morseTranslator.Transform("The pug");
        
        //assert
        Assert.AreEqual("- .... .   .--. ..- --.", result);
    }
    
}