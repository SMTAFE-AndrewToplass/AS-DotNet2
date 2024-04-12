using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace ASDotNet2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AstronomicalProcessing myForm = new AstronomicalProcessing();
            Application.Run(myForm);
        }

        public class AstronomicalProcessing : Form
        {
            public AstronomicalProcessing()
            {
                InitControls();
                FillArray(data);
                ShowArray(data, lstBoxData);
            }

            #region Form setup
            private void InitControls()
            {
                Size = new Size(360, 500);
                MinimumSize = new Size(360, 400);
                Text = "Astronomical Processing";

                tableLayoutMain = new TableLayoutPanel();
                tableLayoutMain.SuspendLayout();
                SuspendLayout();

                tableLayoutMain.ColumnCount = 1;
                tableLayoutMain.RowCount = 4;
                tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
                tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tableLayoutMain.Dock = DockStyle.Fill;
                tableLayoutMain.Padding = new Padding(6);

                #region Edit item table layout panel.

                tableLayoutEditItem = new TableLayoutPanel();
                tableLayoutEditItem.SuspendLayout();
                tableLayoutEditItem.ColumnCount = 2;
                tableLayoutEditItem.RowCount = 2;
                tableLayoutEditItem.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tableLayoutEditItem.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tableLayoutEditItem.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                tableLayoutEditItem.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                tableLayoutEditItem.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                tableLayoutEditItem.AutoSize = true;

                lblEditItem = new Label
                {
                    Text = "Edit item:",
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                };

                txtBoxEditItem = new TextBox
                {
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                };
                txtBoxEditItem.KeyDown += TxtBoxEditItem_KeyDown;

                btnEditItem = new Button
                {
                    Text = "Apply",
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                };
                btnEditItem.Click += BtnEditItem_Click;

                tableLayoutEditItem.Controls.Add(lblEditItem, 0, 0);
                tableLayoutEditItem.SetColumnSpan(lblEditItem, 2);
                tableLayoutEditItem.Controls.Add(txtBoxEditItem, 0, 1);
                tableLayoutEditItem.Controls.Add(btnEditItem, 1, 1);
                tableLayoutEditItem.ResumeLayout(false);
                #endregion

                // Listbox containing data.
                lstBoxData = new ListBox
                {
                    Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                };
                lstBoxData.SelectedIndexChanged += LstBoxData_SelectedIndexChanged;

                #region Search item table layout panel.
                tableLayoutSearch = new TableLayoutPanel();
                tableLayoutSearch.SuspendLayout();
                tableLayoutSearch.ColumnCount = 2;
                tableLayoutSearch.RowCount = 3;
                tableLayoutSearch.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tableLayoutSearch.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tableLayoutSearch.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tableLayoutSearch.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tableLayoutSearch.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tableLayoutSearch.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tableLayoutSearch.Dock = DockStyle.Fill;
                tableLayoutSearch.AutoSize = true;

                lblSearch = new Label
                {
                    Text = "Search:",
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                };

                txtBoxSearch = new TextBox
                {
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                };
                txtBoxSearch.KeyDown += TxtBoxSearch_KeyDown;

                btnBinarySearch = new Button
                {
                    Text = "Binary Search",
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                };
                btnBinarySearch.Click += BtnBinarySearch_Click;

                btnLinearSearch = new Button
                {
                    Text = "Linear Search",
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                };
                btnLinearSearch.Click += BtnLinearSearch_Click;

                btnSort = new Button
                {
                    Text = "Sort data",
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                };
                btnSort.Click += BtnSort_Click;

                tableLayoutSearch.Controls.Add(lblSearch, 0, 0);
                tableLayoutSearch.SetColumnSpan(lblSearch, 2);
                tableLayoutSearch.Controls.Add(txtBoxSearch, 0, 1);
                tableLayoutSearch.SetColumnSpan(txtBoxSearch, 2);
                tableLayoutSearch.Controls.Add(btnBinarySearch, 0, 2);
                tableLayoutSearch.Controls.Add(btnLinearSearch, 1, 2);
                tableLayoutSearch.Controls.Add(btnSort, 0, 3);
                tableLayoutSearch.SetColumnSpan(btnSort, 2);
                tableLayoutSearch.ResumeLayout(false);
                #endregion


                #region Mathematical functions table layout panel.
                tableLayoutMathsFunctions = new TableLayoutPanel();
                tableLayoutMathsFunctions.SuspendLayout();
                tableLayoutMathsFunctions.ColumnCount = 4;
                tableLayoutMathsFunctions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                tableLayoutMathsFunctions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                tableLayoutMathsFunctions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                tableLayoutMathsFunctions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                tableLayoutMathsFunctions.RowCount = 3;
                tableLayoutMathsFunctions.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tableLayoutMathsFunctions.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tableLayoutMathsFunctions.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tableLayoutMathsFunctions.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                tableLayoutMathsFunctions.AutoSize = true;
                //tableLayoutMathsFunctions.MinimumSize = new Size(0,0);

                lblMathsFunctions = new Label
                {
                    Text = "Mathematical functions:",
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                };

                txtBoxMidRange = new TextBox
                {
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                    ReadOnly = true,
                    Size = new Size(10, 0),
                };

                txtBoxMode = new TextBox
                {
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                    Size = new Size(10, 0),
                    ReadOnly = true,
                };

                txtBoxAverage = new TextBox
                {
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                    ReadOnly = true,
                    Size = new Size(10, 0),
                };

                txtBoxRange = new TextBox
                {
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                    ReadOnly = true,
                    Size = new Size(10, 0),
                };

                btnMidRange = new Button
                {
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                    Text = "Mid-range",
                };
                btnMidRange.Click += BtnMidRange_Click;

                btnMode = new Button
                {
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                    Text = "Mode",
                };
                btnMode.Click += BtnMode_Click;

                btnAverage = new Button
                {
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                    Text = "Average",
                };
                btnAverage.Click += BtnAverage_Click;

                btnRange = new Button
                {
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                    Text = "Range",
                };
                btnRange.Click += BtnRange_Click;

                tableLayoutMathsFunctions.Controls.Add(lblMathsFunctions, 0, 0);
                tableLayoutMathsFunctions.SetColumnSpan(lblMathsFunctions, 4);
                tableLayoutMathsFunctions.Controls.Add(txtBoxMidRange, 0, 1);
                tableLayoutMathsFunctions.Controls.Add(txtBoxMode, 1, 1);
                tableLayoutMathsFunctions.Controls.Add(txtBoxAverage, 2, 1);
                tableLayoutMathsFunctions.Controls.Add(txtBoxRange, 3, 1);
                tableLayoutMathsFunctions.Controls.Add(btnMidRange, 0, 2);
                tableLayoutMathsFunctions.Controls.Add(btnMode, 1, 2);
                tableLayoutMathsFunctions.Controls.Add(btnAverage, 2, 2);
                tableLayoutMathsFunctions.Controls.Add(btnRange, 3, 2);
                tableLayoutMathsFunctions.ResumeLayout(false);
                #endregion


                tableLayoutMain.Controls.Add(tableLayoutEditItem, 0, 0);
                tableLayoutMain.Controls.Add(lstBoxData, 0, 1);
                tableLayoutMain.Controls.Add(tableLayoutSearch, 0, 2);
                tableLayoutMain.Controls.Add(tableLayoutMathsFunctions, 0, 3);
                tableLayoutMain.ResumeLayout(false);
                Controls.Add(tableLayoutMain);
                ResumeLayout(true);
            }

            #region Form control definitions.
            private TableLayoutPanel tableLayoutMain;
            private ListBox lstBoxData;

            // Search
            private TableLayoutPanel tableLayoutSearch;
            private Label lblSearch;
            private TextBox txtBoxSearch;
            private Button btnBinarySearch;
            private Button btnLinearSearch;
            private Button btnSort;

            // Edit Item
            private TableLayoutPanel tableLayoutEditItem;
            private TextBox txtBoxEditItem;
            private Label lblEditItem;
            private Button btnEditItem;

            // Mathematical Functions
            private TableLayoutPanel tableLayoutMathsFunctions;
            private Label lblMathsFunctions;

            private Button btnMidRange;
            private TextBox txtBoxMidRange;

            private Button btnAverage;
            private TextBox txtBoxAverage;

            private Button btnMode;
            private TextBox txtBoxMode;

            private Button btnRange;
            private TextBox txtBoxRange;
            #endregion

            #endregion

            #region Form events

            // Array for storing the integer data.
            static readonly int max = 24;
            readonly int[] data = new int[max];

            // Store data sorted status, used for searching.
            private bool isSorted = false;

            // When selecting an item in the listbox, update the edit textbox.
            private void LstBoxData_SelectedIndexChanged(object sender, EventArgs e)
            {
                txtBoxEditItem.Text = lstBoxData.Text;
            }

            // Edit array item of currently selected listbox item with data from
            // the edit textbox when clicking the edit button.
            private void BtnEditItem_Click(object sender, EventArgs e)
            {
                // Try and get a data value from edit textbox.
                if (int.TryParse(txtBoxEditItem.Text, out int value))
                {
                    // Get the index of selected listbox item.
                    int idx = lstBoxData.SelectedIndex;
                    isSorted = false;

                    // Check if index value is within the bounds of the data array.
                    if (idx >= 0 && idx < data.Length)
                    {
                        // Apply edited value to the array and update the listbox.
                        data[idx] = value;
                        ShowArray(data, lstBoxData, true);
                    }
                    else
                    {
                        MessageBox.Show("Please select an item to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("You must enter an integer number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Applies edit from textbox into the data when pressing enter.
            private void TxtBoxEditItem_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // If the key enter key was pressed, click the edit button.
                    btnEditItem.PerformClick();
                    e.SuppressKeyPress = true;
                }
            }

            // Search for data in the array from the search textbox when clicking
            // the search button.
            private void BtnBinarySearch_Click(object sender, EventArgs e)
            {
                // If data is not sorted before search, ask user to sort the data.
                if (!isSorted)
                {
                    // Ask user if they want to sort the data, storing the answer.
                    var answer = MessageBox.Show("Data needs to be sorted before searching. Would you like to sort the data?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (answer == DialogResult.Yes)
                    {
                        // If they answered Yes, click the sort button then search.
                        btnSort.PerformClick();
                    }
                    else
                    {
                        // If they answered No, cancel the operation.
                        return;
                    }
                }

                // Try and get a data value from search textbox.
                if (int.TryParse(txtBoxSearch.Text, out int value))
                {
                    // Run the binary search on the data array with the input from
                    // the search textbox.
                    int idx = BinarySearch(data, value);
                    if (idx >= 0)
                    {
                        // Select & highlight item that was found in the array.
                        lstBoxData.SelectedIndex = idx;
                        // Show message saying where the item was found.
                        MessageBox.Show($"Item {value} found at index: {idx}.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Warn user that the item they searched for was not found.
                        MessageBox.Show($"Item not found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("You must enter an integer number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Performs the Search when pressing enter.
            private void TxtBoxSearch_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // If shift key is held down, then perform sequential search.
                    if (e.Modifiers == Keys.Shift)
                    {
                        // If the key enter key was pressed, click the search button.
                        btnLinearSearch.PerformClick();
                        e.SuppressKeyPress = true;
                    }
                    // Otherwise, perform binary search, which requires sorting.
                    else
                    {
                        // If the key enter key was pressed, click the search button.
                        btnBinarySearch.PerformClick();
                        e.SuppressKeyPress = true;
                    }

                }
            }

            // Performs the sequential search when clicking the sequential search button.
            private void BtnLinearSearch_Click(object sender, EventArgs e)
            {
                // Try and get a data value from search textbox.
                if (int.TryParse(txtBoxSearch.Text, out int value))
                {
                    // Run the binary search on the data array with the input from
                    // the search textbox.
                    int idx = SequentialSearch(data, value);
                    if (idx >= 0)
                    {
                        // Select & highlight item that was found in the array.
                        lstBoxData.SelectedIndex = idx;
                        // Show message saying where the item was found.
                        MessageBox.Show($"Item {value} found at index: {idx}.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Warn user that the item they searched for was not found.
                        MessageBox.Show($"Item not found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("You must enter an integer number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Sorts the data using bubble sort then displaying sorted array.
            private void BtnSort_Click(object sender, EventArgs e)
            {
                BubbleSort(data);
                isSorted = true;
                ShowArray(data, lstBoxData);
            }

            // Finds the range and then displays it.
            private void BtnRange_Click(object sender, EventArgs e)
            {
                txtBoxRange.Text = Range(data).ToString();
            }

            // Finds the Mid-Range and then displays it.
            private void BtnMidRange_Click(object sender, EventArgs e)
            {
                txtBoxMidRange.Text = $"{MidRange(data):f2}";
            }

            // Get the mode of the data when clicking on the mode button.
            private void BtnMode_Click(object sender, EventArgs e)
            {
                int[] mode = Mode(data);
                if (mode[0] < 0)
                {
                    // If mode equals -1, then output: No mode.
                    txtBoxMode.Text = "No mode";
                }
                else
                {
                    // Otherwise, output the mode of the array and the number of
                    // occurrences of the mode.
                    txtBoxMode.Text = $"{mode[0]}, {mode[1]}";
                }
            }

            // Get the average of the data when clicking the average button.
            private void BtnAverage_Click(object sender, EventArgs e)
            {
                txtBoxAverage.Text = $"{Average(data):f2}";
            }

            #endregion

            #region Utility functions

            /// <summary>
            /// Fills array with random integers (between 10 and 90 by default).
            /// </summary>
            /// <param name="array">Array to fill with data.</param>
            /// <param name="min">Minimum value for random data.</param>
            /// <param name="max">Maximum value for random data.</param>
            static private void FillArray(int[] array, int min = 0, int max = 90)
            {
                Random rand = new Random();
                for (int i = 0; i < array.Length; i++)
                {
                    // Add new random number between min & max (0 & 90 by default).
                    array[i] = rand.Next(min, max);
                }
            }

            /// <summary>
            /// Displays array data inside of a ListBox.
            /// </summary>
            /// <param name="array">Array data to display.</param>
            /// <param name="listBox">ListBox to store the array data.</param>
            /// <param name="restore">Restore previously selected item position.</param>
            static private void ShowArray(int[] array, ListBox listBox, bool restore = false)
            {
                // Store the selected index for restoring it after updating.
                int idx = listBox.SelectedIndex;
                // Clear the listbox to write the new data.
                listBox.Items.Clear();
                foreach (int item in array)
                {
                    // Add each array item to the listbox.
                    listBox.Items.Add(item);
                }
                // Restore selected item.
                if (restore) listBox.SelectedIndex = idx;
            }

            /// <summary>
            /// Sorts the data from smallest to largest integer using the Bubble sort algorithm.
            /// </summary>
            /// <param name="array">Array to be sorted.</param
            private static void BubbleSort(int[] array)
            {
                // Use two loops to make sure every value gets sorted.
                for (int outer = 0; outer < array.Length; outer++)
                {
                    // Move larger values to the end of the array.
                    for (int inner = 0; inner < array.Length - 1; inner++)
                    {
                        // If the current item is larger than the next, then swap.
                        if (array[inner] > array[inner + 1])
                        {
                            // Temp hold the value of the next item so it can be swapped.
                            int temp = array[inner];
                            array[inner] = array[inner + 1];
                            array[inner + 1] = temp;
                        }
                    }
                }
            }

            /// <summary>
            /// Search for data inside integer array using the binary search algorithm.
            /// </summary>
            /// <param name="array">Array containing data to search through.</param>
            /// <param name="target">Data to find the index of.</param>
            /// <returns>Index of target inside array, returns -1 is nothing was found.</returns>
            private static int BinarySearch(int[] array, int target)
            {
                int mid,
                    low = 0,
                    high = array.Length - 1;
                while (low <= high)
                {
                    // Midpoint between low and high search limits.
                    mid = (low + high) / 2;
                    if (array[mid] == target)
                    {
                        // Target was found, return index.
                        return mid;
                    }
                    else if (array[mid] > target)
                    {
                        // Target is smaller than middle value, stop searching for
                        // larger values.
                        high = mid - 1;
                    }
                    else
                    {
                        // Target is larger than middle value, stop searching for
                        // smaller values.
                        low = mid + 1;
                    }
                }
                // If search doesn't find any matching items, return -1.
                return -1;
            }

            /// <summary>
            /// Does the Range Calculation.
            /// </summary>
            /// <param name="input">An array of integers.</param>
            /// <returns>The data array you want to find the Range of.</returns>
            private static int Range(int[] input)
            {
                int largest = Largest(input);
                int smallest = Smallest(input);
                return largest - smallest;
            }

            /// <summary>
            /// Does the Mid-Range Calculation.
            /// </summary>
            /// <param name="input">An array of integers.</param>
            /// <returns>The data array you want to find the Mid-Range of.</returns>
            private static double MidRange(int[] input)
            {
                int largest = Largest(input);
                int smallest = Smallest(input);
                return (largest + smallest) / 2.0;
            }

            /// <summary>
            /// Finds the Largest number in an Array.
            /// </summary>
            /// <param name="input">An array of integers.</param>
            /// <returns>The data you want to find the largest number for.</returns>
            static private int Largest(int[] input)
            {
                int largest = input[0];

                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] > largest)
                    {
                        largest = input[i];
                    }
                }
                return largest;
            }

            /// <summary>
            /// Finds the Smallest number in an Array.
            /// </summary>
            /// <param name="input">An array of integers.</param>
            /// <returns>The data you want to find the smallest number for.</returns>
            static private int Smallest(int[] input)
            {
                int smallest = input[0];

                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] < smallest)
                    {
                        smallest = input[i];
                    }
                }
                return smallest;
            }

            /// <summary>
            /// Performs a sequential search.
            /// </summary>
            /// <param name="input">An array of integers to search through.</param>
            /// <param name="target">The integer to search for.</param>
            /// <returns>The index of the target integer, or -1 if is wasn't found.</returns>
            private static int SequentialSearch(int[] input, int target)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    // If the current element is equal to the target, return the index.
                    if (input[i] == target)
                    {
                        return i;
                    }
                }
                // If the target wasn't found, then return -1.
                return -1;
            }

            /// <summary>
            /// Calculate the average from an array of integer inputs.
            /// </summary>
            /// <param name="input">An array of integers.</param>
            /// <returns>The average of all the integers in the input array, as a double.</returns>
            private static double Average(int[] input)
            {
                // Get the sum of the data using a for loop.
                int sum = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    // Add each array value to the sum integer.
                    sum += input[i];
                }
                // Divide the sum by the number of items, converting to a double.
                return sum / (double)input.Length;
            }

            /// <summary>
            /// Calculates the mode from an array of integer inputs.
            /// </summary>
            /// <param name="input">An array of integers</param>
            /// <returns>An array containing the mode (-1 if no mode) and the number of occurrences.</returns>
            private static int[] Mode(int[] input)
            {
                // Use dictionary to keep track of occurrences.
                var count = new Dictionary<int, int>();

                // Keep track of current mode.
                int mode = -1;
                // Number of occurrences of current mode.
                int max = 1;

                // Loop through every array element to search for occurrences.
                for (int i = 0; i < input.Length; i++)
                {
                    // Add dictionary key for array element, defaulting to 1.
                    try
                    {
                        count.Add(input[i], 1);
                    }
                    catch (ArgumentException)
                    {
                        // If key already exists, then increment it by 1.
                        count[input[i]]++;

                        // Check if current number is larger than previous mode.
                        if (count[input[i]] > max)
                        {
                            // Set mode to current number.
                            max = count[input[i]];
                            mode = input[i];
                        }
                    }
                }
                // Return mode and number of occurrences.
                int[] output = { mode, max };
                return output;
            }

            #endregion
        }
    }
}
