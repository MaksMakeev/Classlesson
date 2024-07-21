namespace Classlesson
{
    public class Stack
    {
        public int Size { get; set; }
        public string Top { get; set; }

        private StackItem CurrentStackItem { get; set; }

        public Stack(params string[] stackElements)
        {
            StackItem previousStackItem = null;
            StackItem currentStackItem = null;
            for (int i = 0; i < stackElements.Length; i++)
            {
                currentStackItem = new StackItem(stackElements[i], previousStackItem);
                previousStackItem = currentStackItem;

            }
            CurrentStackItem = currentStackItem;

            Size = stackElements.Length;

            if (Size != 0)
            {
                Top = stackElements[Size - 1];
            }
            else
            {
                Top = null;
            }
        }

        public string Add(string stackElement)
        {
            CurrentStackItem = new StackItem(stackElement, CurrentStackItem);
            Size++;
            Top = stackElement;
            return Top;
        }

        public string Pop()
        {
            if (Size > 0)
            {
                var deleted = Top;
                if (Size > 1)
                {
                    Size--;
                    Top = CurrentStackItem.PreviousValue.CurrentValue;
                    CurrentStackItem = CurrentStackItem.PreviousValue;
                }
                else
                {
                    Size = 0;
                    Top = null;
                }
                return deleted;
            }
            else
            {
                throw new Exception("Стек пустой");
            }
        }

        public static Stack Concat(params Stack[] stacks)
        {
            var s = new Stack();
            foreach (var stack in stacks)
            {
                for (var i = 1; i <= (stack.Size); i++)
                {
                    s.Add(stack.Pop());
                }
                s.Add(stack.Show());
            }
            return s;
        }

        public string Show()
        {
            string showStorage = "";
            StackItem checkingValue = CurrentStackItem;
            while (checkingValue.PreviousValue != null) 
            {
                var a = checkingValue.CurrentValue;
                showStorage += a;
                checkingValue = checkingValue.PreviousValue;
            }
            showStorage += checkingValue.CurrentValue;

            char[] cArray = showStorage.ToCharArray();
            string reverse = String.Empty;
            for (int i = showStorage.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }
            showStorage = reverse;

            return showStorage;
        }

        class StackItem
        {
            public string CurrentValue { get; set; }
            public StackItem PreviousValue { get; set; }
            public StackItem(string currentValue, StackItem previousValue)
            {
                CurrentValue = currentValue;
                PreviousValue = previousValue;
            }
        }
    }
}
