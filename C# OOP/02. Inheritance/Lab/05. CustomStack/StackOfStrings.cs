namespace CustomStack
{
    using System;
    using System.Collections.Generic;

    public class StackOfStrings : Stack<string>
    {
        //Public method: IsEmpty(): bool
        //Public method: AddRange() : Stack<string>

        private Stack<string> collection;

        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public void AddRange(IEnumerable<string> collection)
        {
            foreach (var element in collection)
                this.Push(element);

        }
    }
}
