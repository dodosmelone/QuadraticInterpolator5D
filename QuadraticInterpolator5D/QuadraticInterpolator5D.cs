using CsvHelper;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace QuadraticInterplator5D
{
    public partial class QuadraticInterpolator5D : Form
    {
        private static int nParams = 21;

        private string nameX1;
        private string nameX2;
        private string nameX3;
        private string nameX4;
        private string nameX5;
        private string nameX6;

        private List<double> X1;
        private List<double> X2;
        private List<double> X3;
        private List<double> X4;
        private List<double> X5;
        private List<double> X6;
        private Vector<double> coefficients;

        public QuadraticInterpolator5D()
        {
            InitializeComponent();
            nameX1 = "X1";
            nameX2 = "X2";
            nameX3 = "X3";
            nameX4 = "X4";
            nameX5 = "X5";
            nameX6 = "X6";
            X1 = new List<double>(0);
            X2 = new List<double>(0);
            X3 = new List<double>(0);
            X4 = new List<double>(0);
            X5 = new List<double>(0);
            X6 = new List<double>(0);
            setXNames();
            lvSamplingPoints.Items.Clear();
            ResetLvCoefficients();
            printAbstractPolynomial();
            lbPolyConcrete.Visible = false;
        }

        private void ResetLvCoefficients()
        {
            lvCoefficients.Items.Clear();
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a1" }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a2" }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a3" }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a4" }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a5" }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a6" }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a7" }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a8" }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a9" }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a10" }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a11" }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a12" }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a13" }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a14" }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a15" }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a16" }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a17" }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a18" }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a19" }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a20" }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a21" }));
        }

        private double GetSamplingPointArg1(int iSample)
        {
            if (rbComputeForX1.Checked)
            {
                return X2[iSample];
            }
            else
            {
                return X1[iSample];
            }
        }

        private double GetSamplingPointArg2(int iSample)
        {
            if (rbComputeForX1.Checked || rbComputeForX2.Checked)
            {
                return X3[iSample];
            }
            else
            {
                return X2[iSample];
            }
        }

        private double GetSamplingPointArg3(int iSample)
        {
            if (rbComputeForX1.Checked || rbComputeForX2.Checked || rbComputeForX3.Checked)
            {
                return X4[iSample];
            }
            else
            {
                return X3[iSample];
            }
        }

        private double GetSamplingPointArg4(int iSample)
        {
            if (rbComputeForX1.Checked || rbComputeForX2.Checked || rbComputeForX3.Checked || rbComputeForX4.Checked)
            {
                return X5[iSample];
            }
            else
            {
                return X4[iSample];
            }
        }

        private double GetSamplingPointArg5(int iSample)
        {
            if (rbComputeForX1.Checked || rbComputeForX2.Checked || rbComputeForX3.Checked || rbComputeForX4.Checked || rbComputeForX5.Checked)
            {
                return X6[iSample];
            }
            else
            {
                return X5[iSample];
            }
        }

        private double GetSamplingPointFuncValue(int iSample)
        {
            if (rbComputeForX1.Checked)
            {
                return X1[iSample];
            }
            else if (rbComputeForX2.Checked)
            {
                return X2[iSample];
            }
            else if (rbComputeForX3.Checked)
            {
                return X3[iSample];
            }
            else if (rbComputeForX4.Checked)
            {
                return X4[iSample];
            }
            else if (rbComputeForX5.Checked)
            {
                return X5[iSample];
            }
            else
            {
                return X6[iSample];
            }
        }

        private void btnLoadSamplingPoints_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "csv files (*.csv)|*.csv";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    try
                    {
                        var fileStream = openFileDialog.OpenFile();
                        int lineCnt = 0;
                        X1.Clear();
                        X2.Clear();
                        X3.Clear();
                        X4.Clear();
                        X5.Clear();
                        X6.Clear();
                        lvSamplingPoints.Items.Clear();

                        using (StreamReader reader = new StreamReader(fileStream))
                        {
                            while (!reader.EndOfStream)
                            {
                                var line = reader.ReadLine();
                                var values = line.Split(';');
                                if (values.Length != 6)
                                {
                                    throw new ArgumentException();
                                }

                                if (lineCnt == 0)
                                {
                                    nameX1 = values[0];
                                    nameX2 = values[1];
                                    nameX3 = values[2];
                                    nameX4 = values[3];
                                    nameX5 = values[4];
                                    nameX6 = values[5];
                                    lvSamplingPoints.Columns[0].Text = nameX1;
                                    lvSamplingPoints.Columns[1].Text = nameX2;
                                    lvSamplingPoints.Columns[2].Text = nameX3;
                                    lvSamplingPoints.Columns[3].Text = nameX4;
                                    lvSamplingPoints.Columns[4].Text = nameX5;
                                    lvSamplingPoints.Columns[5].Text = nameX6;
                                }
                                else
                                {
                                    double x1 = double.Parse(values[0], CultureInfo.InvariantCulture);
                                    double x2 = double.Parse(values[1], CultureInfo.InvariantCulture);
                                    double x3 = double.Parse(values[2], CultureInfo.InvariantCulture);
                                    double x4 = double.Parse(values[3], CultureInfo.InvariantCulture);
                                    double x5 = double.Parse(values[4], CultureInfo.InvariantCulture);
                                    double x6 = double.Parse(values[5], CultureInfo.InvariantCulture);
                                    X1.Add(x1);
                                    X2.Add(x2);
                                    X3.Add(x3);
                                    X4.Add(x4);
                                    X5.Add(x5);
                                    X6.Add(x6);

                                    string[] row =
                                    {
                                    String.Format("{0:0.00000000}", x1),
                                    String.Format("{0:0.00000000}", x2),
                                    String.Format("{0:0.00000000}", x3),
                                    String.Format("{0:0.00000000}", x4),
                                    String.Format("{0:0.00000000}", x5),
                                    String.Format("{0:0.00000000}", x6)
                                    };
                                    ListViewItem listViewItem = new ListViewItem(row);
                                    lvSamplingPoints.Items.Add(listViewItem);
                                }

                                lineCnt++;
                            }
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show("Input csv data in " + openFileDialog.FileName + " is not six-dimensional.", "Failed to load sample data.");
                        openFileDialog.Dispose();
                        return;
                    }
                    catch
                    {
                        MessageBox.Show("Unable to open file " + openFileDialog.FileName + ". Make sure it's not open in another program.", "Failed to load sample data.");
                        openFileDialog.Dispose();
                        return;
                    }
                }
            }

            setXNames();
            printAbstractPolynomial();
            compute();
        }

        private void setXNames()
        {
            rbComputeForX1.Text = nameX1;
            rbComputeForX2.Text = nameX2;
            rbComputeForX3.Text = nameX3;
            rbComputeForX4.Text = nameX4;
            rbComputeForX5.Text = nameX5;
            rbComputeForX6.Text = nameX6;
        }

        private void compute()
        {
            if (X1.Count > 0)
            {
                computePolynomialCoefficients();
                printConcretePolynomial();
                displayCoefficientsInListView();
                btnExport.Enabled = true;
            }
        }

        private void computePolynomialCoefficients()
        {
            int nSamples = X1.Count;
            double[,] matAsArray = new double[nSamples, nParams];
            double[] vecAsArray = new double[nSamples];
            for (int iSample = 0; iSample < nSamples; iSample++)
            {
                double Y1 = GetSamplingPointArg1(iSample);
                double Y2 = GetSamplingPointArg2(iSample);
                double Y3 = GetSamplingPointArg3(iSample);
                double Y4 = GetSamplingPointArg4(iSample);
                double Y5 = GetSamplingPointArg5(iSample);
                double Y6 = GetSamplingPointFuncValue(iSample);
                matAsArray[iSample, 0] = Y1 * Y1;
                matAsArray[iSample, 1] = Y2 * Y2;
                matAsArray[iSample, 2] = Y3 * Y3;
                matAsArray[iSample, 3] = Y4 * Y4;
                matAsArray[iSample, 4] = Y5 * Y5;
                matAsArray[iSample, 5] = Y1 * Y2;
                matAsArray[iSample, 6] = Y1 * Y3;
                matAsArray[iSample, 7] = Y1 * Y4;
                matAsArray[iSample, 8] = Y1 * Y5;
                matAsArray[iSample, 9] = Y2 * Y3;
                matAsArray[iSample, 10] = Y2 * Y4;
                matAsArray[iSample, 11] = Y2 * Y5;
                matAsArray[iSample, 12] = Y3 * Y4;
                matAsArray[iSample, 13] = Y3 * Y5;
                matAsArray[iSample, 14] = Y4 * Y5;
                matAsArray[iSample, 15] = Y1;
                matAsArray[iSample, 16] = Y2;
                matAsArray[iSample, 17] = Y3;
                matAsArray[iSample, 18] = Y4;
                matAsArray[iSample, 19] = Y5;
                matAsArray[iSample, 20] = 1.0;
                vecAsArray[iSample] = Y6;
            }

            Matrix<double> A = Matrix<double>.Build.DenseOfArray(matAsArray);
            Vector<double> b = Vector<double>.Build.Dense(vecAsArray);

            // A^T * A * coefficients = A^T * b:
            coefficients = A.TransposeThisAndMultiply(A).LU().Solve(
                A.TransposeThisAndMultiply(b));
        }

        private void printConcretePolynomial()
        {
            string arg1 = getArg1();
            string arg2 = getArg2();
            string arg3 = getArg3();
            string arg4 = getArg4();
            string arg5 = getArg5();
            string funcVal = getFuncVal();

            lbPolyConcrete.Text = funcVal + " = "
                + String.Format("{0:0.0000}", coefficients[0]) + " * " + arg1 + "^2"
                + ((coefficients[1] >= 0) ? " + " : " - ") + String.Format("{0:0.0000}", Math.Abs(coefficients[1])) + " * " + arg2 + "^2"
                + ((coefficients[2] >= 0) ? " + " : " - ") + String.Format("{0:0.0000}", Math.Abs(coefficients[2])) + " * " + arg3 + "^2" + "\r\n"
                + "    " + ((coefficients[3] >= 0) ? " + " : " - ") + String.Format("{0:0.0000}", Math.Abs(coefficients[3])) + " * " + arg4 + "^2"
                + ((coefficients[4] >= 0) ? " + " : " - ") + String.Format("{0:0.0000}", Math.Abs(coefficients[4])) + " * " + arg5 + "^2"
                + ((coefficients[5] >= 0) ? " + " : " - ") + String.Format("{0:0.0000}", Math.Abs(coefficients[5])) + " * " + arg1 + " * " + arg2 + "\r\n"
                + "    " + ((coefficients[6] >= 0) ? " + " : " - ") + String.Format("{0:0.0000}", Math.Abs(coefficients[6])) + " * " + arg1 + " * " + arg3
                + ((coefficients[7] >= 0) ? " + " : " - ") + String.Format("{0:0.0000}", Math.Abs(coefficients[7])) + " * " + arg1 + " * " + arg4
                + ((coefficients[8] >= 0) ? " + " : " - ") + String.Format("{0:0.0000}", Math.Abs(coefficients[8])) + " * " + arg1 + " * " + arg5 + "\r\n"
                + "    " + ((coefficients[9] >= 0) ? " + " : " - ") + String.Format("{0:0.0000}", Math.Abs(coefficients[9])) + " * " + arg2 + " * " + arg3
                + ((coefficients[10] >= 0) ? " + " : " - ") + String.Format("{0:0.0000}", Math.Abs(coefficients[10])) + " * " + arg2 + " * " + arg4
                + ((coefficients[11] >= 0) ? " + " : " - ") + String.Format("{0:0.0000}", Math.Abs(coefficients[11])) + " * " + arg2 + " * " + arg5 + "\r\n"
                + "    " + ((coefficients[12] >= 0) ? " + " : " - ") + String.Format("{0:0.0000}", Math.Abs(coefficients[12])) + " * " + arg3 + " * " + arg4
                + ((coefficients[13] >= 0) ? " + " : " - ") + String.Format("{0:0.0000}", Math.Abs(coefficients[13])) + " * " + arg3 + " * " + arg5
                + ((coefficients[14] >= 0) ? " + " : " - ") + String.Format("{0:0.0000}", Math.Abs(coefficients[14])) + " * " + arg4 + " * " + arg5 + "\r\n"
                + "    " + ((coefficients[15] >= 0) ? " + " : " - ") + String.Format("{0:0.0000}", Math.Abs(coefficients[15])) + " * " + arg1
                + ((coefficients[16] >= 0) ? " + " : " - ") + String.Format("{0:0.0000}", Math.Abs(coefficients[16])) + " * " + arg2
                + ((coefficients[17] >= 0) ? " + " : " - ") + String.Format("{0:0.0000}", Math.Abs(coefficients[17])) + " * " + arg3 + "\r\n"
                + "    " + ((coefficients[18] >= 0) ? " + " : " - ") + String.Format("{0:0.0000}", Math.Abs(coefficients[18])) + " * " + arg4
                + ((coefficients[19] >= 0) ? " + " : " - ") + String.Format("{0:0.0000}", Math.Abs(coefficients[19])) + " * " + arg5
                + ((coefficients[20] >= 0) ? " + " : " - ") + String.Format("{0:0.0000}", Math.Abs(coefficients[20]));
            lbPolyConcrete.Visible = true;
        }

        private void displayCoefficientsInListView()
        {
            lvCoefficients.Items.Clear();
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a1", String.Format("{0:0.0000000000}", coefficients[0]) }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a2", String.Format("{0:0.0000000000}", coefficients[1]) }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a3", String.Format("{0:0.0000000000}", coefficients[2]) }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a4", String.Format("{0:0.0000000000}", coefficients[3]) }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a5", String.Format("{0:0.0000000000}", coefficients[4]) }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a6", String.Format("{0:0.0000000000}", coefficients[5]) }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a7", String.Format("{0:0.0000000000}", coefficients[6]) }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a8", String.Format("{0:0.0000000000}", coefficients[7]) }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a9", String.Format("{0:0.0000000000}", coefficients[8]) }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a10", String.Format("{0:0.0000000000}", coefficients[9]) }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a11", String.Format("{0:0.0000000000}", coefficients[10]) }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a12", String.Format("{0:0.0000000000}", coefficients[11]) }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a13", String.Format("{0:0.0000000000}", coefficients[12]) }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a14", String.Format("{0:0.0000000000}", coefficients[13]) }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a15", String.Format("{0:0.0000000000}", coefficients[14]) }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a16", String.Format("{0:0.0000000000}", coefficients[15]) }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a17", String.Format("{0:0.0000000000}", coefficients[16]) }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a18", String.Format("{0:0.0000000000}", coefficients[17]) }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a19", String.Format("{0:0.0000000000}", coefficients[18]) }));
            lvCoefficients.Items.Add(new ListViewItem(new string[] { "a20", String.Format("{0:0.0000000000}", coefficients[19]) }));
        }

        private void rbComputeForXCheckedChanged(object sender, EventArgs e)
        {
            printAbstractPolynomial();
            ResetLvCoefficients();
            compute();
        }

        private void ResetPolynomial()
        {
            lbPolyConcrete.Visible = false;
            printAbstractPolynomial();
        }

        private string getArg1()
        {
            if (rbComputeForX1.Checked)
            {
                return nameX2;
            }
            else
            {
                return nameX1;
            }
        }
        private string getArg2() { 
            if (rbComputeForX1.Checked || rbComputeForX2.Checked)
            {
                return nameX3;
            }
            else
            {
                return nameX2;
            }
        }
        private string getArg3()
        {
            if (rbComputeForX1.Checked || rbComputeForX2.Checked || rbComputeForX3.Checked)
            {
                return nameX4;
            }
            else
            {
                return nameX3;
            }
        }

        private string getArg4()
        {
            if (rbComputeForX1.Checked || rbComputeForX2.Checked || rbComputeForX3.Checked || rbComputeForX4.Checked)
            {
                return nameX5;
            }
            else
            {
                return nameX4;
            }
        }

        private string getArg5()
        {
            if (rbComputeForX1.Checked || rbComputeForX2.Checked || rbComputeForX3.Checked || rbComputeForX4.Checked || rbComputeForX5.Checked)
            {
                return nameX6;
            }
            else
            {
                return nameX5;
            }
        }

        private string getFuncVal()
        {
            if (rbComputeForX1.Checked)
            {
                return nameX1;
            }
            else if (rbComputeForX2.Checked)
            {
                return nameX2;
            }
            else if (rbComputeForX3.Checked)
            {
                return nameX3;
            }
            else if (rbComputeForX4.Checked)
            {
                return nameX4;
            }
            else if (rbComputeForX5.Checked)
            {
                return nameX5;
            }
            else
            {
                return nameX6;
            }
        }

        private void printAbstractPolynomial()
        {
            string arg1 = getArg1();
            string arg2 = getArg2();
            string arg3 = getArg3();
            string arg4 = getArg4();
            string arg5 = getArg5();
            string funcVal = getFuncVal();
            

            lbPolyAbstract.Text = funcVal + " = "
                + "a1 * " + arg1 + "^2  + a2 * " + arg2 + "^2  + a3 * " + arg3 + "^2  + a4 * " + arg4 + "^2\r\n"
                + "      + a5 * " + arg5 + "^2" + " + a6 * " + arg1 + " * " + arg2 + "  + a7 * " + arg1 + " * " + arg3 + "\r\n"
                + "      + a8 * " + arg1 + " * " + arg4 + " + a9 * " + arg1 + " * " + arg5 + " + a10 * " + arg2 + " * " + arg3 + "\r\n"
                + "      + a11 * " + arg2 + " * " + arg4 + "  + a12 * " + arg2 + " * " + arg5 + " + a13 * " + arg3 + " * " + arg4 + " \r\n"
                + "      + a14 * " + arg3 + " * " + arg5 + "  + a15 * " + arg4 + " * " + arg5 + " + a16 * " + arg1 + " \r\n"
                + "      + a17 * " + arg2 + "  + a18 * " + arg3 + "  + a19 * " + arg4 + "  + a20 * " + arg5 + "  + a21\r\n";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            nameX1 = "X1";
            nameX2 = "X2";
            nameX3 = "X3";
            nameX4 = "X4";
            nameX5 = "X5";
            nameX6 = "X6";
            ResetPolynomial();
            ResetLvCoefficients();
            ResetLvSamplePoints();
            setXNames();
            btnExport.Enabled = false;
        }

        private void ResetLvSamplePoints()
        {
            lvSamplingPoints.Items.Clear();
            lvSamplingPoints.Columns[0].Text = nameX1;
            lvSamplingPoints.Columns[1].Text = nameX2;
            lvSamplingPoints.Columns[2].Text = nameX3;
            lvSamplingPoints.Columns[3].Text = nameX4;
            lvSamplingPoints.Columns[4].Text = nameX5;
            lvSamplingPoints.Columns[5].Text = nameX6;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "csv files (*.csv)|*.csv";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.Title = "Save quadratic polynomial coefficients";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream stream = (Stream)saveFileDialog.OpenFile();
                StreamWriter writer = new StreamWriter(stream);
                CsvWriter csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

                csvWriter.WriteField("Coefficient name");
                csvWriter.WriteField("Corresponding polynomial");
                csvWriter.WriteField("Coefficient value");
                csvWriter.NextRecord();

                csvWriter.WriteField("a1");
                csvWriter.WriteField(getArg1() + "^2");
                csvWriter.WriteField(coefficients[0]);
                csvWriter.NextRecord();

                csvWriter.WriteField("a2");
                csvWriter.WriteField(getArg2() + "^2");
                csvWriter.WriteField(coefficients[1]);
                csvWriter.NextRecord();

                csvWriter.WriteField("a3");
                csvWriter.WriteField(getArg3() + "^2");
                csvWriter.WriteField(coefficients[2]);
                csvWriter.NextRecord();

                csvWriter.WriteField("a4");
                csvWriter.WriteField(getArg4() + "^2");
                csvWriter.WriteField(coefficients[3]);
                csvWriter.NextRecord();

                csvWriter.WriteField("a5");
                csvWriter.WriteField(getArg5() + "^2");
                csvWriter.WriteField(coefficients[4]);
                csvWriter.NextRecord();

                csvWriter.WriteField("a6");
                csvWriter.WriteField(getArg1() + "*" + getArg2());
                csvWriter.WriteField(coefficients[5]);
                csvWriter.NextRecord();

                csvWriter.WriteField("a7");
                csvWriter.WriteField(getArg1() + "*" + getArg3());
                csvWriter.WriteField(coefficients[6]);
                csvWriter.NextRecord();

                csvWriter.WriteField("a8");
                csvWriter.WriteField(getArg1() + "*" + getArg4());
                csvWriter.WriteField(coefficients[7]);
                csvWriter.NextRecord();

                csvWriter.WriteField("a9");
                csvWriter.WriteField(getArg1() + "*" + getArg5());
                csvWriter.WriteField(coefficients[8]);
                csvWriter.NextRecord();

                csvWriter.WriteField("a10");
                csvWriter.WriteField(getArg2() + "*" + getArg3());
                csvWriter.WriteField(coefficients[9]);
                csvWriter.NextRecord();

                csvWriter.WriteField("a11");
                csvWriter.WriteField(getArg2() + "*" + getArg4());
                csvWriter.WriteField(coefficients[10]);
                csvWriter.NextRecord();

                csvWriter.WriteField("a12");
                csvWriter.WriteField(getArg2() + "*" + getArg5());
                csvWriter.WriteField(coefficients[11]);
                csvWriter.NextRecord();

                csvWriter.WriteField("a13");
                csvWriter.WriteField(getArg3() + "*" + getArg4());
                csvWriter.WriteField(coefficients[12]);
                csvWriter.NextRecord();

                csvWriter.WriteField("a14");
                csvWriter.WriteField(getArg3() + "*" + getArg5());
                csvWriter.WriteField(coefficients[13]);
                csvWriter.NextRecord();

                csvWriter.WriteField("a15");
                csvWriter.WriteField(getArg4() + "*" + getArg5());
                csvWriter.WriteField(coefficients[14]);
                csvWriter.NextRecord();

                csvWriter.WriteField("a16");
                csvWriter.WriteField(getArg1());
                csvWriter.WriteField(coefficients[15]);
                csvWriter.NextRecord();

                csvWriter.WriteField("a17");
                csvWriter.WriteField(getArg2());
                csvWriter.WriteField(coefficients[16]);
                csvWriter.NextRecord();

                csvWriter.WriteField("a18");
                csvWriter.WriteField(getArg3());
                csvWriter.WriteField(coefficients[17]);
                csvWriter.NextRecord();

                csvWriter.WriteField("a19");
                csvWriter.WriteField(getArg4());
                csvWriter.WriteField(coefficients[18]);
                csvWriter.NextRecord();

                csvWriter.WriteField("a20");
                csvWriter.WriteField(getArg5());
                csvWriter.WriteField(coefficients[19]);
                csvWriter.NextRecord();

                csvWriter.Flush();
                writer.Close();
                string message = "Coefficients saved to " + saveFileDialog.FileName;
                string caption = "Save successful";
                MessageBox.Show(message, caption);
                stream.Close();
            }
        }
    }
}
