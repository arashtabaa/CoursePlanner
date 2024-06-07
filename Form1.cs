using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CoursePlanner
{
    // تعریف کلاس اصلی فرم
    public partial class Form1 : Form
    {
        // تعریف یک نمونه از کلاس CourseGraph برای نگهداری دروس و پیش‌نیازها
        private readonly CourseGraph courseGraph;
        private int addCourseCounter = 0; // شمارنده برای تعداد دروس اضافه شده

        // سازنده فرم
        public Form1()
        {
            InitializeComponent();
            courseGraph = new CourseGraph(); // ایجاد یک نمونه جدید از CourseGraph
        }

        // رویداد کلیک برای دکمه افزودن درس
        private void BtnAddCourse_Click(object sender, EventArgs e)
        {
            string course = txtCourse.Text.Trim(); // دریافت و حذف فضای خالی رشته مربوط به درس
            string prerequisite = txtPrerequisite.Text.Trim(); // دریافت و حذف فضای خالی رشته مربوط به پیش‌نیاز

            // بررسی ورودی‌ها
            if (string.IsNullOrEmpty(course)) // بررسی خالی بودن فیلد درس
            {
                MessageBox.Show("Course field cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (course.Equals(prerequisite, StringComparison.OrdinalIgnoreCase)) // بررسی برابر بودن درس و پیش‌نیاز
            {
                MessageBox.Show("A course cannot be a prerequisite of itself.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // افزودن درس به گراف
            if (!courseGraph.AddCourse(course)) // بررسی موجود بودن درس در گراف
            {
                MessageBox.Show("This course already exists.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // افزودن پیش‌نیاز به درس
            if (!string.IsNullOrEmpty(prerequisite))
            {
                if (!courseGraph.AddPrerequisite(course, prerequisite)) // بررسی موجود بودن پیش‌نیاز یا ایجاد چرخه
                {
                    MessageBox.Show("This prerequisite already exists or creates a cycle.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                lstCourses.Items.Add(new ListViewItem(new[] { course, prerequisite })); // افزودن درس و پیش‌نیاز به لیست نمایش
            }
            else
            {
                lstCourses.Items.Add(new ListViewItem(new[] { course, "None" })); // افزودن درس بدون پیش‌نیاز به لیست نمایش
            }

            // افزایش شمارنده بعد از افزودن موفقیت‌آمیز درس
            addCourseCounter++;

            // بررسی تعداد دروس اضافه شده
            if (addCourseCounter >= 4)
            {
                MessageBox.Show("This is a mini university :) You cannot add more than 4 courses.", "Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // تنظیم وضعیت مرتب‌سازی به false
            IsSorted = false;

            // پاک کردن فیلدهای ورودی
            txtCourse.Clear();
            txtPrerequisite.Clear();
        }

        // متغیری برای نگهداری وضعیت مرتب‌سازی دروس
        private bool isSorted = false;

        public bool IsSorted { get => isSorted; set => isSorted = value; }

        // رویداد کلیک برای دکمه مرتب‌سازی دروس
        private void BtnSortCourses_Click(object sender, EventArgs e)
        {
            // بررسی وجود دروس در گراف
            if (courseGraph.NodesCount == 0)
            {
                MessageBox.Show("No courses available to sort.", "Operation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // انجام مرتب‌سازی توپولوژیکی دروس
                List<string> sortedCourses = courseGraph.TopologicalSort();

                lstSortedCourses.Items.Clear(); // پاک کردن لیست قبلی مرتب‌شده

                // افزودن دروس به لیست مرتب‌شده
                foreach (var course in sortedCourses)
                {
                    string displayedCourse = course;

                    // افزودن شکلک ★ اگر درس پیش‌نیاز داشته باشد
                    if (courseGraph.HasPrerequisites(course))
                    {
                        displayedCourse = "★ " + displayedCourse;
                    }

                    // افزودن شکلک ☆ اگر درس خود پیش‌نیاز باشد
                    if (courseGraph.IsPrerequisite(course))
                    {
                        displayedCourse = "☆ " + displayedCourse;
                    }

                    lstSortedCourses.Items.Add(new ListViewItem(displayedCourse)); // افزودن درس به لیست مرتب‌شده
                }

                // تنظیم وضعیت مرتب‌سازی به true
                IsSorted = true;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Sort Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // نمایش پیام خطا در صورت بروز خطا در مرتب‌سازی
            }
        }
    }
}

// تعریف کلاس CourseGraph برای مدیریت دروس و پیش‌نیازها
public class CourseGraph
{
    // لیست مجاورت برای نگهداری دروس و پیش‌نیازها
    private readonly Dictionary<string, List<string>> adjList;
    // مجموعه‌ای از نودها (دروس)
    private readonly HashSet<string> nodes;

    // سازنده کلاس CourseGraph
    public CourseGraph()
    {
        adjList = new Dictionary<string, List<string>>();
        nodes = new HashSet<string>();
    }

    // افزودن درس به گراف
    public bool AddCourse(string course)
    {
        if (!adjList.ContainsKey(course))
        {
            adjList[course] = new List<string>(); // ایجاد لیست مجاورت برای درس جدید
            nodes.Add(course); // افزودن درس به مجموعه نودها
            return true;
        }
        return false; // درس از قبل وجود دارد
    }

    // افزودن پیش‌نیاز به درس
    public bool AddPrerequisite(string course, string prerequisite)
    {
        AddCourse(course); // اطمینان از اضافه شدن درس به گراف
        AddCourse(prerequisite); // اطمینان از اضافه شدن پیش‌نیاز به عنوان درس

        if (adjList[prerequisite].Contains(course))
        {
            return false; // جلوگیری از ایجاد چرخه
        }
        adjList[prerequisite].Add(course); // افزودن پیش‌نیاز به لیست مجاورت
        return true;
    }

    // متد برای مرتب‌سازی توپولوژیکی دروس
    public List<string> TopologicalSort()
    {
        var inDegree = new Dictionary<string, int>(); // ایجاد دیکشنری برای نگهداری درجه ورودی نودها
        foreach (var node in nodes)
        {
            inDegree[node] = 0; // مقداردهی اولیه درجه ورودی نودها به صفر
        }

        foreach (var kvp in adjList)
        {
            foreach (var neighbor in kvp.Value)
            {
                inDegree[neighbor]++; // افزایش درجه ورودی برای نودهای مجاور
            }
        }

        var queue = new Queue<string>(); // ایجاد صف برای نگهداری نودهایی با درجه ورودی صفر
        foreach (var node in nodes)
        {
            if (inDegree[node] == 0)
            {
                queue.Enqueue(node); // افزودن نودهایی با درجه ورودی صفر به صف
            }
        }

        var sortedList = new List<string>(); // ایجاد لیست برای نگهداری نودهای مرتب‌شده به صورت توپولوژیک
        while (queue.Count > 0)
        {
            var node = queue.Dequeue(); // حذف نود از صف
            sortedList.Add(node); // افزودن نود به لیست مرتب‌شده

            foreach (var neighbor in adjList[node])
            {
                inDegree[neighbor]--; // کاهش درجه ورودی نودهای مجاور
                if (inDegree[neighbor] == 0)
                {
                    queue.Enqueue(neighbor); // افزودن نودهایی با درجه ورودی صفر به صف
                }
            }
        }

        if (sortedList.Count != nodes.Count)
        {
            throw new InvalidOperationException("There exists a cycle in the graph"); // پرتاب استثنا در صورت وجود چرخه در گراف
        }

        return sortedList; // بازگرداندن لیست مرتب‌شده
    }

    // متد برای بررسی اینکه آیا یک درس پیش‌نیاز دارد یا خیر
    public bool HasPrerequisites(string course)
    {
        return adjList.ContainsKey(course) && adjList[course].Count > 0;
    }

    // متد برای بررسی اینکه آیا یک درس خود پیش‌نیاز است یا خیر
    public bool IsPrerequisite(string course)
    {
        foreach (var kvp in adjList)
        {
            if (kvp.Value.Contains(course))
            {
                return true;
            }
        }
        return false;
    }

    // متد برای گرفتن دروسی که پیش‌نیاز ندارند
    public List<string> GetUnprerequisiteCourses()
    {
        var unprerequisiteCourses = new List<string>();
        foreach (var course in nodes)
        {
            if (!HasPrerequisites(course))
            {
                unprerequisiteCourses.Add(course);
            }
        }
        return unprerequisiteCourses;
    }

    // متد برای گرفتن تعداد نودهای گراف
    public int NodesCount => nodes.Count;
}
