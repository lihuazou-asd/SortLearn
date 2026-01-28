namespace Sort;

class Program
{
    static void Main(string[] args)
    {
        var list = new List<int>() { 1,3,4,6,1,2,3,4,5,6,1,2,3,56,7,1,2,5 };
        MergeSort(list);

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
        // 外层循环控制排序轮数，n个元素需要n-1轮
        for (int i = 0; i < list.Count - 1; i++)
        {
            bool swap = false; // 优化：标记本轮是否发生交换
            // 内层循环进行相邻元素比较，每轮减少已排序的元素
            for (int j = 0; j < list.Count - 1 - i; j++)
            {
                // 如果前面的元素大于后面的元素，交换它们
                if (list[j] > list[j + 1])
                {
                    (list[j], list[j + 1]) = (list[j + 1], list[j]);
                    swap = true;
                }
            }
            // 如果本轮没有交换，说明已经有序，提前退出
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
        // 外层循环控制未排序部分的起始位置
        for (int i = 0; i < list.Count - 1; i++)
        {
            int minIndex = i; // 假设当前位置是最小值
            // 在未排序部分找到最小元素的索引
            for (int j = i + 1; j < list.Count; j++)
            {
                if (list[j] < list[minIndex])
                {
                    minIndex = j;
                }
            }
            // 将找到的最小元素与未排序部分的第一个元素交换
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
        // 外层循环控制未排序部分的起始位置
        for (int i = 0; i < list.Count - 1; i++)
        {
            int maxIndex = i; // 假设当前位置是最大值
            // 在未排序部分找到最大元素的索引
            for (int j = i + 1; j < list.Count; j++)
            {
                if (list[maxIndex] < list[j])
                {
                    maxIndex = j;
                }
            }
            // 将找到的最大元素与未排序部分的第一个元素交换
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
        // 从第二个元素开始，逐个插入到前面已排序部分
        for (int i = 1; i < list.Count; i++)
        {
            // 将当前元素向前比较交换，直到找到合适位置
            for (int j = i; j >= 1; j--)
            {
                // 如果当前元素小于前一个元素，交换它们
                if (list[j] < list[j - 1])
                {
                    (list[j], list[j - 1]) = (list[j - 1], list[j]);
                }
                else
                {
                    break; // 找到合适位置，停止比较
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
        // 从第二个元素开始，逐个插入到前面已排序部分
        for (int i = 1; i < list.Count; i++)
        {
            int temp = list[i]; // 保存当前要插入的元素
            int insertIndex = i; // 记录插入位置
            // 向前查找插入位置，同时将大于temp的元素后移
            for (int j = i-1; j >= 0; j--)
            {
                if (temp < list[j])
                {
                    (list[j],list[j+1]) = (list[j+1], list[j]); // 将较大元素后移
                    insertIndex = j; // 更新插入位置
                }
                else
                {
                    break; // 找到合适位置，停止查找
                }
            }
            // 将保存的元素插入到找到的位置
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
        // 外层循环：逐步缩小步长，直到步长为1
        for (int step = list.Count / 2; step > 0; step /= 2)
        {
            // 对每个步长进行间隔插入排序
            for (int i = step; i < list.Count; i++)
            {
                int temp = list[i]; // 保存当前要插入的元素
                int j = i;
                // 向前查找插入位置（间隔为step）
                while (j >= step && list[j - step] > temp)
                {
                    list[j] = list[j - step]; // 将较大元素后移step位
                    j -= step;
                }
                // 将元素插入到找到的位置
                list[j] = temp;
            }
        }
    }
    
    
    
    /// <summary>
    /// 归并排序
    /// 时间复杂度:O(n log n)
    /// 空间复杂度:O(n)
    /// 稳定性:稳定
    /// 最坏时间复杂度:O(n log n) - 任何情况都需要完整的分治和合并
    /// 最好时间复杂度:O(n log n) - 任何情况都需要完整的分治和合并
    /// </summary>
    static void MergeSort(List<int> list)
    {
        int[] tmpArray = new int[list.Count]; // 创建临时数组用于合并
        MergeSort(list, 0, list.Count - 1, tmpArray);
    }
    
    static void MergeSort(List<int> list, int start, int end, int[] tmpArray)
    {
        // 递归终止条件：当区间只有一个或没有元素时
        if (start >= end)
        {
            return;
        }
        
        // 计算中点，将数组分为两部分
        int mid = start + (end - start) / 2;
        
        // 递归排序左半部分
        MergeSort(list, start, mid, tmpArray);
        // 递归排序右半部分
        MergeSort(list, mid + 1, end, tmpArray);
        
        // 合并两个有序数组
        int i = start;      // 左半部分的指针
        int j = mid + 1;    // 右半部分的指针
        int k = start;      // 临时数组的指针
        
        // 比较两个有序数组，将较小的元素放入临时数组
        while (i <= mid && j <= end)
        {
            if (list[i] <= list[j])
            {
                tmpArray[k++] = list[i++];
            }
            else
            {
                tmpArray[k++] = list[j++];
            }
        }
        
        // 将左半部分剩余元素复制到临时数组
        while (i <= mid)
        {
            tmpArray[k++] = list[i++];
        }
        
        // 将右半部分剩余元素复制到临时数组
        
        while (j <= end)
        {
            tmpArray[k++] = list[j++];
        }
        
        // 将临时数组的结果复制回原数组
        for (k = start; k <= end; k++)
        {
            list[k] = tmpArray[k];
        }
    }
    
    
    
}