namespace Application;

public class MorseTranslator
{

    private readonly Dictionary<char, string> _morseDictionary = new()
    {
        { ' ', "   "},
        {'A', ".-"},
        {'B', "-..."},
        {'C', "-.-."},
        {'D', "-.."},
        {'E', "."},
        {'F', "..-."},
        {'G', "--."},
        {'H', "...."},
        {'I', ".."},
        {'J', ".---"},
        {'K', "-.-"},
        {'L', ".-.."},
        {'M', "--"},
        {'N', "-."},
        {'O', "---"},
        {'P', ".--."},
        {'Q', "--.-"},
        {'R', ".-."},
        {'S', "..."},
        {'T', "-"},
        {'U', "..-"},
        {'V', "...-"},
        {'W', ".--"},
        {'X', "-..-"},
        {'Y', "-.--"},
        {'Z', "--.."},
        {'0', "-----"},
        {'1', ".----"},
        {'2', "..---"},
        {'3', "...--"},
        {'4', "....-"},
        {'5', "....."},
        {'6', "-...."},
        {'7', "--..."},
        {'8', "---.."},
        {'9', "----."},
        {'.', ".-.-.-"},
        {',', "--..--"},
        {'?', "..--.."},
        {'\'', ".----."},
        {'!', "-.-.--"},
        {'/', "-..-."},
        {'(', "-.--."},
        {')', "-.--.-"},
        {'&', ".-..."},
        {':', "---..."},
        {';', "-.-.-."},
        {'=', "-...-"},
        {'+', ".-.-."},
        {'-', "-....-"},
        {'_', "..--.-"},
        {'$', "...-..-"},
        {'@', ".--.-."}
    };
    
    public string Transform(string text)
    {
        var result = string.Empty;
        //if(text.Length < 2) return string.Empty;
        //use linq foreach and fix bug with 4 spaces
        foreach (var character in text)
        {
            if (_morseDictionary.ContainsKey(char.ToUpper(character)))
            {
                var morseCode = _morseDictionary[char.ToUpper(character)];
                result += morseCode;
            }
            else
            {
                result += "..--..";
            }
            
            var index = text.LastIndexOf(character);
            if(index != text.Length - 1 && character != ' ')
                result += " ";
        }

        return result;
    }
}