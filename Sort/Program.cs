namespace Sort;

class Program
{
    static void Main(string[] args)
    {
        var list = new List<int>() { 1, 3, 4, 6, 1, 2, 3, 4, 5, 6, 1, 2, 3, 56, 7, 1, 2, 5 };
        RadixSort(list);

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
            for (int j = i - 1; j >= 0; j--)
            {
                if (temp < list[j])
                {
                    (list[j], list[j + 1]) = (list[j + 1], list[j]); // 将较大元素后移
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
        int i = start; // 左半部分的指针
        int j = mid + 1; // 右半部分的指针
        int k = start; // 临时数组的指针

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

    /// <summary>
    /// 快速排序
    /// 时间复杂度:O(n log n)
    /// 空间复杂度:O(log n) - 递归调用栈空间
    /// 稳定性:不稳定
    /// 最坏时间复杂度:O(n²) - 每次分区都极度不平衡时（如已排序数组）
    /// 最好时间复杂度:O(n log n) - 每次分区都较为平衡时
    /// </summary>
    static void QuickSort(List<int> list)
    {
        QuickSort(list, 0, list.Count - 1);
    }

    static void QuickSort(List<int> list, int left, int right)
    {
        // 递归终止条件：当区间只有一个或没有元素时
        if (left >= right) return;

        int pivot = list[left]; // 选择基准值，left位置成为第一个坑
        int i = left; // 左指针
        int j = right; // 右指针

        // 分区过程：将小于pivot的元素放左边，大于pivot的元素放右边
        while (i < j)
        {
            // 从右向左找第一个小于pivot的元素
            while (i < j && list[j] >= pivot)
            {
                j--;
            }

            // 找到后填坑，j位置成为新坑
            if (i < j)
            {
                list[i] = list[j];
                i++;
            }

            // 从左向右找第一个大于pivot的元素
            while (i < j && list[i] <= pivot)
            {
                i++;
            }

            // 找到后填坑，i位置成为新坑
            if (i < j)
            {
                list[j] = list[i];
                j--;
            }
        }

        // 将pivot放到最终位置（此时i==j）
        list[i] = pivot;

        // 递归排序左半部分
        QuickSort(list, left, i - 1);
        // 递归排序右半部分
        QuickSort(list, i + 1, right);
    }


    /// <summary>
    /// 堆排序
    /// 时间复杂度:O(n log n)
    /// 空间复杂度:O(1)
    /// 稳定性:不稳定
    /// 最坏时间复杂度:O(n log n) - 任何情况都需要完整的建堆和排序过程
    /// 最好时间复杂度:O(n log n) - 任何情况都需要完整的建堆和排序过程
    /// </summary>
    static void HeapSort(List<int> list)
    {
        int n = list.Count;

        // 第一阶段：建堆，从最后一个非叶子节点开始向下调整
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            SiftDown(list, i, n);
        }

        // 第二阶段：排序，将堆顶元素与末尾元素交换，然后重新调整堆
        for (int i = n - 1; i > 0; i--)
        {
            (list[0], list[i]) = (list[i], list[0]); // 将最大值移到末尾
            SiftDown(list, 0, i); // 重新调整剩余元素为最大堆
        }
    }

    /// <summary>
    /// 向下调整堆，维护最大堆性质
    /// </summary>
    /// <param name="list">待调整的数组</param>
    /// <param name="root">调整的根节点索引</param>
    /// <param name="heapSize">堆的大小</param>
    static void SiftDown(List<int> list, int root, int heapSize)
    {
        int parent = root;
        // 当父节点有左子节点时继续调整
        while (parent * 2 + 1 < heapSize)
        {
            int child = parent * 2 + 1; // 左子节点索引
            // 找到左右子节点中的较大者
            if (child + 1 < heapSize && list[child] < list[child + 1])
            {
                child++; // 右子节点更大，选择右子节点
            }

            // 如果父节点小于子节点，交换并继续向下调整
            if (list[parent] < list[child])
            {
                (list[parent], list[child]) = (list[child], list[parent]);
                parent = child; // 更新父节点位置
            }
            else
            {
                break; // 堆性质已满足，停止调整
            }
        }
    }
    

    /// <summary>
    /// 计数排序
    /// 时间复杂度:O(n + k) - n为元素个数，k为数值范围
    /// 空间复杂度:O(k) - k为数值范围
    /// 稳定性:稳定
    /// 最坏时间复杂度:O(n + k) - 任何情况都需要遍历数组和计数数组
    /// 最好时间复杂度:O(n + k) - 任何情况都需要遍历数组和计数数组
    /// </summary>
    static void CountingSort(List<int> list)
    {
        // 找到数组中的最小值和最大值
        var min = int.MaxValue;
        var max = int.MinValue;

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] < min)
            {
                min = list[i];
            }

            if (list[i] > max)
            {
                max = list[i];
            }
        }
        
        // 创建计数数组，大小为数值范围
        var count = new int[max - min + 1];
        
        // 统计每个元素出现的次数
        for(int i = 0; i < list.Count; i++)
        {
            count[list[i] - min]++;
        }

        // 计算累积计数，count[i]表示小于等于值i+min的元素总数
        for (int i = 1; i < count.Length; i++)
        {
            count[i] += count[i - 1];
        }

        // 从后向前遍历原数组，根据累积计数确定每个元素的最终位置
        List<int> tmp = new List<int>(list);
        for (int i = tmp.Count - 1; i >= 0; i--)
        {
            var value = tmp[i];
            list[--count[value - min]] = value; // 先减1再赋值，保证稳定性
        }
    }
    
    

    

    /// <summary>
    /// 桶排序
    /// 时间复杂度:O(n + k) - n为元素个数，k为桶的数量
    /// 空间复杂度:O(n + k) - 需要额外的桶空间
    /// 稳定性:稳定（取决于桶内排序算法）
    /// 最坏时间复杂度:O(n²) - 所有元素都分到同一个桶中
    /// 最好时间复杂度:O(n) - 元素均匀分布在各个桶中
    /// </summary>
    static void BucketSort(List<int> list)
    {
        if (list.Count <= 1) return;

        // 找到最小值和最大值
        int min = list[0], max = list[0];
        foreach (int num in list)
        {
            if (num < min) min = num;
            if (num > max) max = num;
        }

        // 计算桶的数量和每个桶的范围
        int bucketCount = list.Count;
        int range = max - min + 1;
        int bucketSize = Math.Max(1, range / bucketCount);

        // 创建桶
        List<int>[] buckets = new List<int>[bucketCount];
        for (int i = 0; i < bucketCount; i++)
        {
            buckets[i] = new List<int>();
        }

        // 将元素分配到对应的桶中
        foreach (int num in list)
        {
            int bucketIndex = Math.Min((num - min) / bucketSize, bucketCount - 1);
            buckets[bucketIndex].Add(num);
        }

        // 对每个桶内的元素进行排序，然后合并结果
        int index = 0;
        for (int i = 0; i < bucketCount; i++)
        {
            if (buckets[i].Count > 0)
            {
                buckets[i].Sort(); // 使用内置排序算法
                foreach (int num in buckets[i])
                {
                    list[index++] = num;
                }
            }
        }
    }
    
    /// <summary>
    /// 基数排序
    /// 时间复杂度:O(d * (n + k)) - d为最大数字位数，n为元素个数，k为基数(10)
    /// 空间复杂度:O(n + k) - 需要额外的桶空间
    /// 稳定性:稳定
    /// 最坏时间复杂度:O(d * (n + k)) - 任何情况都需要处理所有位数
    /// 最好时间复杂度:O(d * (n + k)) - 任何情况都需要处理所有位数
    /// </summary>
    static void RadixSort(List<int> list)
    {
        if (list.Count <= 1) return;

        // 找到最大值以确定最大位数
        int max = list[0];
        foreach (int num in list)
        {
            if (num > max) max = num;
        }

        // 从个位开始，对每一位进行计数排序
        for (int exp = 1; max / exp > 0; exp *= 10)
        {
            CountingSortByDigit(list, exp);
        }
    }
    
    /// <summary>
    /// 按指定位数进行计数排序
    /// </summary>
    /// <param name="list">待排序数组</param>
    /// <param name="exp">位数权重(1=个位, 10=十位, 100=百位...)</param>
    static void CountingSortByDigit(List<int> list, int exp)
    {
        int[] count = new int[10]; // 0-9的计数数组
        List<int> output = new List<int>(new int[list.Count]);

        // 统计当前位上每个数字的出现次数
        for (int i = 0; i < list.Count; i++)
        {
            count[(list[i] / exp) % 10]++;
        }

        // 计算累积计数
        for (int i = 1; i < 10; i++)
        {
            count[i] += count[i - 1];
        }

        // 从后向前构建输出数组，保证稳定性
        for (int i = list.Count - 1; i >= 0; i--)
        {
            int digit = (list[i] / exp) % 10;
            output[--count[digit]] = list[i];
        }

        // 将结果复制回原数组
        for (int i = 0; i < list.Count; i++)
        {
            list[i] = output[i];
        }
    }
}