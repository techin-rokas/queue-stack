namespace MyApp
{
  internal class Program
  {
    static void Main(string[] args)
    {
      //--1--//
      Random rnd = new Random();
      Console.Write("Enter queue length: ");
      if (!int.TryParse(Console.ReadLine(), out int queueLength))
      {
        Console.WriteLine("Invalid input");
        return;
      }

      var queueNumbers = new Queue<int>();

      for (int i = 0; i < queueLength; i++)
      {
        queueNumbers.Enqueue(RandomNumber(rnd, 1, 100));
      }
      Console.WriteLine(string.Join(", ", queueNumbers));

      Console.Write("Enter how many elements to reverse: ");
      if (!int.TryParse(Console.ReadLine(), out int k))
      {
        Console.WriteLine("Invalid input");
        return;
      }

      ReverseFirstK(queueNumbers, k);
      Console.WriteLine(string.Join(", ", queueNumbers));

      //--2--//
      Console.Write("Enter a string: ");
      string input = Console.ReadLine().ToLower().Replace(" ", "");

      Queue<char> queue = new Queue<char>();
      Stack<char> stack = new Stack<char>();

      foreach (char c in input)
      {
        queue.Enqueue(c);
        stack.Push(c);
      }

      bool isPalindrome = true;
      while (queue.Count > 0)
      {
        if (queue.Dequeue() != stack.Pop())
        {
          isPalindrome = false;
          break;
        }
      }

      Console.WriteLine(isPalindrome ? "Is a palindrome!" : "Not a palindrome.");

      //--3--//
      Console.Write("Enter a string: ");
      string line = Console.ReadLine();

      Stack<char> brackets = new Stack<char>();
      bool isValid = true;

      foreach (char c in line)
      {
        if (c == '(' || c == '[' || c == '{')
        {
          brackets.Push(c);
        }
        else if (c == ')' || c == ']' || c == '}')
        {
          if (brackets.Count == 0)
          {
            isValid = false;
            break;
          }

          char top = brackets.Pop();

          if (c == ')' && top != '(' ||
              c == ']' && top != '[' ||
              c == '}' && top != '{')
          {
            isValid = false;
            break;
          }
        }
      }

      if (brackets.Count > 0)
        isValid = false;

      Console.WriteLine(isValid ? "Brackets are valid!" : "Brackets are invalid.");
    }

    static int RandomNumber(Random rnd, int min, int max)
    {
      return rnd.Next(min, max);
    }

    static void ReverseFirstK(Queue<int> queue, int k)
    {
      Stack<int> stack = new Stack<int>();

      int remaining = queue.Count - k;

      for (int i = 0; i < k; i++)
      {
        stack.Push(queue.Dequeue());
      }

      while (stack.Count > 0)
      {
        queue.Enqueue(stack.Pop());
      }

      for (int i = 0; i < remaining; i++)
      {
        queue.Enqueue(queue.Dequeue());
      }
    }
  }
}


