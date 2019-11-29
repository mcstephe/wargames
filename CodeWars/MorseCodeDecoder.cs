using System;

class MorseCodeDecoder
{
    public static string Decode(string morseCode)
    {
        //Call MorseCode.Get('.--') to convert to letter.

        string result = "";
        string message = morseCode;
        int spacePos = 0;

        //Step through all characters finding words and spaces

        while (message.Length > 0) 
        {
            spacePos = message.IndexOf(" ");

            if (spacePos == -1) //no spaces let, just get last letter
            {
                result += MorseCode.Get(message);
                break;
            }
            if (message.StartsWith("  "))//We have a space between words
                {
                    result += " "; //no need to decode space
                    message = message.Substring(2);
                    continue;
            }

                result += MorseCode.Get(message.Substring(0, spacePos -1)); //ignore space
                message = message.Substring(spacePos + 1); //skip space we found
            

        }

        return result; 



        /*
         *         //result += GetLetter(morseCode);

        int start = 0;
        int count;
        int end = morseCode.Length;
        int at = 0;
        int space;

        int index = 0;
        bool hasLetters = true;

        while ((start <= end) && (at > -1))
        {
            // start+count must be a position within -str-.
            count = end - start;  //10 - 0;


            at = morseCode.IndexOf(" ", start, count); //  4

            if (at == -1) break; //single space not found

            space = 0;
            if (start+2 > end)
            {
                //more here
                space = morseCode.IndexOf("   ", start, start + 2); //  4
            }


            if (space == -1) //no space 
            {
                result += MorseCode.Get(morseCode.Substring(start, at - start));
                start = at + 1;

            }
            else
            {

                result += " ";
                start = at + 3;
            }

            
        }
        */
        //return result;
    }



    public static bool HasSpace(string s)
    {
        if (s.IndexOf(" ") > -1)
            return true;
        else
            return false;
    }

    public static string GetLetter(string w)
    {
        int index = w.IndexOf(" ") - 1;
        string encodedWord = w.Substring(0, index);
        return MorseCode.Get(encodedWord);
    }

}
