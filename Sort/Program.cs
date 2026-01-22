namespace Sort;

class Program
{
    static void Main(string[] args)
    {
        var list = new List<int>() { 1, 3, 2, 6, 4, 7, 1 };
        InsertSort2(list);

        string info = "";
        foreach (var item in list)
        {
            info += $"{item},";
        }

        Console.Write(info);
    }

    /// <summary>
    /// 冒泡排序
    /// 稳定，因为当遇到相同的时候不会交换
    /// </summary>
    /// <param name="list"></param>
    static void BubbleSort(List<int> list)
    {
        for (int i = 0; i < list.Count - 1; i++) //比如有6个元素，其实循环完5轮就已经排序好了
        {
            bool swap = false; //用于检测是否交换，如果没有交换过，说明已经是顺序的了
            for (int j = 0; j < list.Count - 1 - i; j++)
            {
                if (list[j] > list[j + 1])
                {
                    (list[j], list[j + 1]) = (list[j + 1], list[j]);
                    swap = true;
                }
            }

            if (!swap) break;
        }
    }

    /// <summary>
    /// 选择排序升序
    /// 不稳定，根本原因在于被交换出去的值会跨过与自己想通的值导致不稳定
    /// </summary>
    /// <param name="list"></param>
    static void SelectionSort1(List<int> list)
    {
        for (int i = 0; i < list.Count - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < list.Count; j++)
            {
                if (list[j] < list[minIndex])
                {
                    minIndex = j;
                }
            }

            (list[minIndex], list[i]) = (list[i], list[minIndex]);
        }
    }

    //选择排序降序
    static void SelectionSort2(List<int> list)
    {
        for (int i = 0; i < list.Count - 1; i++)
        {
            int maxIndex = i;
            for (int j = i + 1; j < list.Count; j++)
            {
                if (list[maxIndex] < list[j])
                {
                    maxIndex = j;
                }
            }

            (list[maxIndex], list[i]) = (list[i], list[maxIndex]);
        }
    }


    /// <summary>
    /// 插入排序，每步交换版
    /// 稳定的
    /// </summary>
    /// <param name="list"></param>
    static void InsertSort1(List<int> list)
    {
        for (int i = 1; i < list.Count; i++)
        {
            for (int j = i; j >= 1; j--)
            {
                if (list[j] < list[j - 1])
                {
                    (list[j], list[j - 1]) = (list[j - 1], list[j]);
                }
                else
                {
                    break;
                }
            }
        }
    }
    
    /// <summary>
    /// 插入排序，每步交换版
    /// 稳定的
    /// </summary>
    /// <param name="list"></param>
    static void InsertSort2(List<int> list)
    {
        for (int i = 1; i < list.Count; i++)
        {
            int temp = list[i];
            int insertIndex = i;
            for (int j = i-1; j >= 0; j--)
            {
                if (temp < list[j])
                {
                    (list[j],list[j+1]) = (list[j+1], list[j]);
                    insertIndex = j;
                }
                else
                {
                    break;
                }
            }

            list[insertIndex] = temp;
        }
    }
}