namespace gt_code_test
{
    public static class BubbleSorter
    {
        public static IEnumerable<int> Sort(IEnumerable<int> inList)
        {
            var list = inList.ToArray();
            bool didSwap;
            int current, next, index;
            int startIndex = 0;

            //compare element by element until end of list - if no swap it's highest and you can move to next index
            while(startIndex < list.Length)
            {
                didSwap = false;
                current = list[startIndex];
                index = startIndex + 1;
                while(!didSwap && index < list.Length)
                {
                    next = list[index];
                    if (next > current)
                    {
                        list[startIndex] = next;
                        list[index] = current;
                        didSwap = true;
                    }
                    index++;                    
                }
                //No swapping means it's the highest for the rest of list - move to next index
                if (!didSwap)
                {
                    startIndex++;
                }
            }
            return list;
        }
    }
}
