//Console.WriteLine("Hangman Game");

string[] words = new string[]{"computer" , "car" , "house" , "planet" , "rocket" , "movie" , "game" , "music" , "dog" , "mouse" , "nintendo" , "spiderman" , "keyboard" , "shirt" , "tennis" , "money" , "bottle" , "war" , "botle" , "table" , "hat"}; //poner 20 palabras
char[] guesses;
string[] fails;
string secretWord;
bool won, lost;

Random random = new Random();
int index = random.Next(words.Length);
secretWord = words[index];
guesses = new char[secretWord.Length];
Array.Fill(guesses, '*');
fails = new string[0];
won = false;
lost = false;

Console.WriteLine("\n\nWelcome to Hang Man\n\n");
gameCicle();

void gameCicle()
{
    //Console.WriteLine("The secret word is " + new String(guesses));
    Console.WriteLine($"The secret word is {new String(guesses)}");
    printHangman();
    if (lost)
    {
       Console.WriteLine("You lost!"); 
    }
    else if (won)
    {
        Console.WriteLine("Congratulations, You WON!");
    }
    else
    {
        playerTurn();
        gameCicle();
    }
}

void playerTurn()
{
    Console.WriteLine("Enter a letter or guess the word: ");
    string attempt = Console.ReadLine() ?? "";
    if (attempt.Length == 0)
    {
         Console.WriteLine("Try again");
    }
    else if (attempt.Length == 1)
    {
       lookForLetter(attempt[0]);
    }
      else
    {
       tryToGuess(attempt);
    }
}

void lookForLetter(char letter)
{
    Console.WriteLine("Searching letter...");
    if (secretWord.IndexOf(letter) > -1)
    {
        Console.WriteLine($"The letter {letter} is correct");
        for (int i = 0; i < secretWord.Length; i++)
        {
            if (secretWord[i] == letter)
            {
                guesses[i] = letter; 
            }
        }
        won = (Array.IndexOf(guesses, '*') == -1);
    }
    else
    {
        Console.WriteLine($"The letter {letter} is not in the word");
        Array.Resize(ref fails, fails.Length +1);
        fails.SetValue(letter.ToString(), fails.Length -1);
    }   
}

void tryToGuess(string word)
{
    if (secretWord == word)
    {
        Console.WriteLine($"The word {word} is correct!");
        guesses = secretWord.ToCharArray();
        won = true;
    }
    else
    {
        Console.WriteLine($"The word {word} is not correct!");
         Array.Resize(ref fails, fails.Length +1);
         fails.SetValue(word, fails.Length -1);
    }
}

void printHangman()
{
    Console.WriteLine("Failed attempts: ");
    for (int i = 0; i < fails.Length; i++)
    {
        Console.Write(fails[i] + ' ');
    }

    int f = fails.Length;
    Console.WriteLine();
    Console.WriteLine("|---");
    Console.WriteLine($"|   {(f > 0 ? 'o' : ' ')}");
    Console.WriteLine($"| {(f > 2 ? '/' : ' ')} {(f > 1 ? '|' : ' ')} {(f > 3 ? '\\' : ' ')}");
    Console.WriteLine($"| {(f > 4 ? '/' : ' ')} {(f > 5 ? '\\' : ' ')}");
    Console.WriteLine("|");
    Console.WriteLine("/--------\\");

    if (f == 6)
    {
        lost = true;
    }
}

