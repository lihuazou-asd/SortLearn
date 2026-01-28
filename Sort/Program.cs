namespace Sort;

class Program
{
    static void Main(string[] args)
    {
        var list = new List<int>() { 9,8,7,6,5,4,3,2,1 };
        ShellSort(list);

        string info = "";
        foreach (var item in list)
        {
            info += $"{item},";
        }

        Console.Write(info);
    }

    /// <summary>
    /// 冒泡排序
    /// 时间复杂度:O(n²)
    /// 空间复杂度:O(1)
    /// 稳定性:稳定，因为当遇到相同的时候不会交换
    /// 最坏时间复杂度:O(n²) - 完全逆序时
    /// 最好时间复杂度:O(n) - 已排序时，第一轮无交换直接退出
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
    /// 时间复杂度:O(n²)
    /// 空间复杂度:O(1)
    /// 稳定性:不稳定，根本原因在于，被交换出去的值，会跨过与自己相同的值导致不稳定
    /// 最坏时间复杂度:O(n²) - 任何情况都需要遍历所有元素找最小值
    /// 最好时间复杂度:O(n²) - 任何情况都需要遍历所有元素找最小值
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

    /// <summary>
    /// 选择排序降序
    /// 时间复杂度:O(n²)
    /// 空间复杂度:O(1)
    /// 稳定性:不稳定
    /// 最坏时间复杂度:O(n²) - 任何情况都需要遍历所有元素找最大值
    /// 最好时间复杂度:O(n²) - 任何情况都需要遍历所有元素找最大值
    /// </summary>
    /// <param name="list"></param>
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
    /// 时间复杂度:O(n²)
    /// 空间复杂度:O(1)
    /// 稳定性:稳定
    /// 最坏时间复杂度:O(n²) - 完全逆序时，每个元素都要交换到最前面
    /// 最好时间复杂度:O(n) - 已排序时，每个元素只需比较一次
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
    /// 插入排序，移动优化版
    /// 时间复杂度:O(n²)
    /// 空间复杂度:O(1)
    /// 稳定性:稳定
    /// 最坏时间复杂度:O(n²) - 完全逆序时，每个元素都要移动到最前面
    /// 最好时间复杂度:O(n) - 已排序时，每个元素只需比较一次
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
    
    /// <summary>
    /// 希尔排序
    /// 时间复杂度:O(n^1.3) ~ O(n²)
    /// 空间复杂度:O(1)
    /// 稳定性:不稳定
    /// 最坏时间复杂度:O(n²) - 取决于步长序列，最坏情况下退化为插入排序
    /// 最好时间复杂度:O(n log n) - 数据基本有序且步长序列选择合理时
    /// </summary>
    static void ShellSort(List<int> list)
    {
        for (int step = list.Count / 2; step > 0; step /= 2)
        {
            for (int i = step; i < list.Count; i++)
            {
                int temp = list[i];
                int j = i;
                while (j >= step && list[j - step] > temp)
                {
                    list[j] = list[j - step];
                    j -= step;
                }
                list[j] = temp;
            }
        }
    }
    
    
}